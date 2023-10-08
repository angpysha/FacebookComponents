using System;

using Foundation;
using ObjCRuntime;

namespace Facebook.LoginKit
{
	[Native]
	public enum FBSDKDefaultAudience : ulong
	{
		Friends = 0,
		OnlyMe = 1,
		Everyone = 2
	}

	[Native]
	public enum FBSDKDeviceLoginError : long
	{
		ExcessivePolling = 1349172,
		AuthorizationDeclined = 1349173,
		AuthorizationPending = 1349174,
		CodeExpired = 1349152
	}

	[Native]
	public enum FBSDKLoginButtonTooltipBehavior : ulong
	{
		Automatic = 0,
		ForceDisplay = 1,
		Disable = 2
	}

	[Native]
	public enum FBSDKTooltipViewArrowDirection : ulong
	{
		Down = 0,
		Up = 1
	}

	[Native]
	public enum FBSDKTooltipColorStyle : ulong
	{
		FriendlyBlue = 0,
		NeutralGray = 1
	}

	[Native]
	public enum FBSDKLoginError : long
	{
		Reserved = 300,
		Unknown = 301,
		PasswordChanged = 302,
		UserCheckpointed = 303,
		UserMismatch = 304,
		UnconfirmedUser = 305,
		SystemAccountAppDisabled = 306,
		SystemAccountUnavailable = 307,
		BadChallengeString = 308,
		InvalidIDToken = 309,
		MissingAccessToken = 310
	}

	[Native]
	public enum FBSDKLoginTracking : ulong
	{
		Enabled = 0,
		Limited = 1
	}

}
