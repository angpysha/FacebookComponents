using System;

using ObjCRuntime;

namespace Facebook.ShareKit
{
	[Flags]
	[Native]
	public enum FBSDKShareBridgeOptions : ulong
	{
		Default = 0x0,
		PhotoAsset = 1uL << 0,
		PhotoImageURL = 1uL << 1,
		VideoAsset = 1uL << 2,
		VideoData = 1uL << 3,
		WebHashtag = 1uL << 4
	}

	[Native]
	public enum FBSDKAppInviteDestination : long
	{
		Facebook = 0,
		Messenger = 1
	}

	[Native]
	public enum FBSDKShareDialogMode : ulong
	{
		Automatic = 0,
		Native = 1,
		ShareSheet = 2,
		Browser = 3,
		Web = 4,
		FeedBrowser = 5,
		FeedWeb = 6
	}

	[Native]
	public enum FBSDKShareError : long
	{
		Reserved = 200,
		OpenGraph = 201,
		DialogNotAvailable = 202,
		Unknown = 203
	}

}
