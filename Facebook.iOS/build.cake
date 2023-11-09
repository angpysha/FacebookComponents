#addin "Cake.FileHelpers"

var TARGET = Argument ("t", Argument ("target", "ci"));
var NAMES = Argument ("names", "");

var FB_VERSION = "16.2.0";
var NUGET_VERSION = "16.2.0";

var BUILD_COMMIT = EnvironmentVariable("BUILD_COMMIT") ?? "DEV";
var BUILD_NUMBER = EnvironmentVariable("BUILD_NUMBER") ?? "DEBUG";
var BUILD_TIMESTAMP = DateTime.UtcNow.ToString();

var IS_LOCAL_BUILD = true;

var SOLUTION_PATH = "./Xamarin.Facebook.sln";
var EXTERNALS_PATH = new DirectoryPath ("./externals");

class ArtifactInfo
{
    public ArtifactInfo(string id, string version, string nugetVersion = null)
    {
        ArtifactId = id;
        Version = version;
        NugetVersion = nugetVersion ?? version;
    }

    public string ArtifactId { get;set; }
    public string Version { get;set; }
    public string NugetVersion { get;set; }
}

// Artifacts that need to be built from pods or be copied from pods
var ARTIFACTS_TO_BUILD = new List<ArtifactInfo>  
{
	new ArtifactInfo("CoreKit", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("LoginKit", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("ShareKit", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("GamingServicesKit", FB_VERSION, NUGET_VERSION),
	new ArtifactInfo("FacebookSdks", FB_VERSION, NUGET_VERSION)
};

var SOURCES_TARGETS = new List<string> ();
var SAMPLES_TARGETS = new List<string> ();

Setup (context =>
{
	IS_LOCAL_BUILD = string.IsNullOrWhiteSpace (EnvironmentVariable ("AGENT_ID"));
	Information ($"Is a local build? {IS_LOCAL_BUILD}");
});

Task("prepare-artifacts")
.Does(() => {
	foreach (var artifact in ARTIFACTS_TO_BUILD) {
		//var projectPath = $"./source/{artifact.ArtifactId}/{artifact.ArtifactId}.csproj";
		SOURCES_TARGETS.Add(artifact.ArtifactId);
	}
});

Task("externals")
 .Does (() => 
{
    EnsureDirectoryExists("./output");
    EnsureDirectoryExists ("./externals/");

	var downloadUrl = $"https://github.com/facebook/facebook-ios-sdk/releases/download/v{FB_VERSION}/FacebookSDK_Dynamic.xcframework.zip";
	DownloadFile(downloadUrl, "./externals/FacebookSDK_Dynamic.xcframework.zip");
	Unzip("./externals/FacebookSDK_Dynamic.xcframework.zip","./externals/");
	var directories = GetDirectories("./externals/XCFrameworks");

	foreach (var dir in directories)
	{
		CopyDirectory(dir, "./externals");
	}

	DeleteFile("./externals/FacebookSDK_Dynamic.xcframework.zip");
	DeleteDirectory("./externals/XCFrameworks", new DeleteDirectorySettings 
	{
    	Recursive = true,
    	Force = true
	});
	
});

Task ("ci-setup")
	.WithCriteria (!BuildSystem.IsLocalBuild)
	.Does (() => 
{
	var glob = "./source/**/AssemblyInfo.cs";

	ReplaceTextInFiles(glob, "{BUILD_COMMIT}", BUILD_COMMIT);
	ReplaceTextInFiles(glob, "{BUILD_NUMBER}", BUILD_NUMBER);
	ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", BUILD_TIMESTAMP);
});

Task ("libs")
	.IsDependentOn("externals")
	.IsDependentOn("ci-setup")
	.Does(() =>
{
	var msBuildSettings = new DotNetMSBuildSettings { 
			MaxCpuCount = 1,
	};
	var dotNetCoreBuildSettings = new DotNetBuildSettings { 
		Configuration = "Release",
		Verbosity = DotNetVerbosity.Diagnostic,
		MSBuildSettings = msBuildSettings
	};
	
	foreach (var target in SOURCES_TARGETS)
		msBuildSettings.Targets.Add($@"source\{target}");
	
	DotNetBuild(SOLUTION_PATH, dotNetCoreBuildSettings);
});

Task ("samples")
	.IsDependentOn("libs")
	.Does(() =>
{
	var msBuildSettings = new DotNetMSBuildSettings { 
			MaxCpuCount = 1,
	};
	var dotNetCoreBuildSettings = new DotNetBuildSettings { 
		Configuration = "Release",
		Verbosity = DotNetVerbosity.Diagnostic,
		MSBuildSettings = msBuildSettings
	};
	
	foreach (var target in SAMPLES_TARGETS)
		msBuildSettings.Targets.Add($@"samples-using-source\{target}");
	
	DotNetBuild(SOLUTION_PATH, dotNetCoreBuildSettings);
});

Task ("nuget")
	.IsDependentOn("libs")
	.IsDependentOn("prepare-artifacts")
	.Does(() =>
{
	EnsureDirectoryExists("./output");

	foreach (var artifact in ARTIFACTS_TO_BUILD)
	{
		var msBuildSettings = new DotNetMSBuildSettings { 
			MaxCpuCount = 1,
			PackageVersion = artifact.NugetVersion,
		};

		var dotNetCorePackSettings = new DotNetPackSettings {
			Configuration = "Release",
			NoRestore = true,
			NoBuild = true,
			OutputDirectory = "./output/",
			Verbosity = DotNetVerbosity.Diagnostic,
			MSBuildSettings = msBuildSettings
		};

		DotNetPack($"./source/{artifact.ArtifactId}", dotNetCorePackSettings);
	}
});

Task ("clean")
	.Does (() => 
{
	var deleteDirectorySettings = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};

	var bins = GetDirectories("./**/bin");
	DeleteDirectories (bins, deleteDirectorySettings);

	var objs = GetDirectories("./**/obj");
	DeleteDirectories (objs, deleteDirectorySettings);

	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", deleteDirectorySettings);

	if (DirectoryExists ("./output/"))
		DeleteDirectory ("./output", deleteDirectorySettings);
});

Task ("ci")
	.IsDependentOn("externals")
	.IsDependentOn("libs")
	.IsDependentOn("nuget")
	.IsDependentOn("samples");

Teardown (context =>
{
	var artifacts = GetFiles ("./output/**/*");

	if (artifacts?.Count () <= 0)
		return;

	Information ($"Found Artifacts ({artifacts.Count ()})");
	foreach (var a in artifacts)
		Information ("{0}", a);
});

RunTarget (TARGET);
