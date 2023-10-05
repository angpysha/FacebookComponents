$BASEDIR = Get-Location

dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-core\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-core-docs\com")
dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-applinks\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-applinks-docs\com")
dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-places\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-places-docs\com")
dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-common\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-common-docs\com")
dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-share\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-share-docs\com")
dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-login\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-login-docs\com")
dotnet run --project .\GenParamNames.csproj -- -o (Join-Path $BASEDIR "..\facebook-messenger\transforms\Metadata-Names.xml") -i (Join-Path $BASEDIR "..\..\externals\facebook-messenger-docs\com")
