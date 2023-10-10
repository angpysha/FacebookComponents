using System;

using Accounts;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using Facebook.CoreKit;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Facebook.LoginKit {
// typedef void (^FBSDKLoginCompletionParametersBlock)(FBSDKLoginCompletionParameters * _Nonnull);
delegate void FBSDKLoginCompletionParametersBlock (FBSDKLoginCompletionParameters arg0);

// typedef void (^FBSDKLoginManagerLoginResultBlock)(FBSDKLoginManagerLoginResult * _Nullable, NSError * _Nullable);
delegate void FBSDKLoginManagerLoginResultBlock ([NullAllowed] FBSDKLoginManagerLoginResult arg0, [NullAllowed] NSError arg1);

// @interface FBSDKCodeVerifier : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKCodeVerifier
{
	// @property (readonly, copy, nonatomic) NSString * _Nonnull value;
	[Export ("value")]
	string Value { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull challenge;
	[Export ("challenge")]
	string Challenge { get; }

	// -(instancetype _Nullable)initWithString:(NSString * _Nonnull)string;
	[Export ("initWithString:")]
	NativeHandle Constructor (string @string);
}

// @interface FBSDKDeviceLoginCodeInfo : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKDeviceLoginCodeInfo
{
	// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
	[Export ("identifier")]
	string Identifier { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull loginCode;
	[Export ("loginCode")]
	string LoginCode { get; }

	// @property (readonly, copy, nonatomic) NSURL * _Nonnull verificationURL;
	[Export ("verificationURL", ArgumentSemantic.Copy)]
	NSUrl VerificationURL { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nonnull expirationDate;
	[Export ("expirationDate", ArgumentSemantic.Copy)]
	NSDate ExpirationDate { get; }

	// @property (readonly, nonatomic) NSUInteger pollingInterval;
	[Export ("pollingInterval")]
	nuint PollingInterval { get; }

	// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier loginCode:(NSString * _Nonnull)loginCode verificationURL:(NSURL * _Nonnull)verificationURL expirationDate:(NSDate * _Nonnull)expirationDate pollingInterval:(NSUInteger)pollingInterval __attribute__((objc_designated_initializer));
	[Export ("initWithIdentifier:loginCode:verificationURL:expirationDate:pollingInterval:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string identifier, string loginCode, NSUrl verificationURL, NSDate expirationDate, nuint pollingInterval);
}

// @interface FBSDKDeviceLoginManager : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKDeviceLoginManager
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKDeviceLoginManagerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKDeviceLoginManagerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull permissions;
	[Export ("permissions", ArgumentSemantic.Copy)]
	string[] Permissions { get; }

	// @property (copy, nonatomic) NSURL * _Nullable redirectURL;
	[NullAllowed, Export ("redirectURL", ArgumentSemantic.Copy)]
	NSUrl RedirectURL { get; set; }

	// -(instancetype _Nonnull)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions enableSmartLogin:(BOOL)enableSmartLogin __attribute__((objc_designated_initializer));
	[Export ("initWithPermissions:enableSmartLogin:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string[] permissions, bool enableSmartLogin);

	// -(void)start;
	[Export ("start")]
	void Start ();

	// -(void)cancel;
	[Export ("cancel")]
	void Cancel ();
}

// @interface FBSDKLoginKit_Swift_392 (FBSDKDeviceLoginManager) <NSNetServiceDelegate>
// [Category]
// [BaseType (typeof(FBSDKDeviceLoginManager))]
// interface FBSDKDeviceLoginManager_FBSDKLoginKit_Swift_392 : INSNetServiceDelegate
// {
// 	// -(void)netService:(NSNetService * _Nonnull)service didNotPublish:(NSDictionary<NSString *,NSNumber *> * _Nonnull)errorValues;
// 	[Export ("netService:didNotPublish:")]
// 	void NetService (NSNetService service, NSDictionary<NSString, NSNumber> errorValues);
// }

// @protocol FBSDKDeviceLoginManagerDelegate
[Protocol, Model]
interface FBSDKDeviceLoginManagerDelegate
{
	// @required -(void)deviceLoginManager:(FBSDKDeviceLoginManager * _Nonnull)loginManager startedWithCodeInfo:(FBSDKDeviceLoginCodeInfo * _Nonnull)codeInfo;
	[Abstract]
	[Export ("deviceLoginManager:startedWithCodeInfo:")]
	void StartedWithCodeInfo (FBSDKDeviceLoginManager loginManager, FBSDKDeviceLoginCodeInfo codeInfo);

	// @required -(void)deviceLoginManager:(FBSDKDeviceLoginManager * _Nonnull)loginManager completedWithResult:(FBSDKDeviceLoginManagerResult * _Nullable)result error:(NSError * _Nullable)error;
	[Abstract]
	[Export ("deviceLoginManager:completedWithResult:error:")]
	void CompletedWithResult (FBSDKDeviceLoginManager loginManager, [NullAllowed] FBSDKDeviceLoginManagerResult result, [NullAllowed] NSError error);
}

interface IFBSDKDeviceLoginManagerDelegate {
}

// @interface FBSDKDeviceLoginManagerResult : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKDeviceLoginManagerResult
{
	// @property (readonly, nonatomic, strong) FBSDKAccessToken * _Nullable accessToken;
	[NullAllowed, Export ("accessToken", ArgumentSemantic.Strong)]
	FBSDKAccessToken AccessToken { get; }

	// @property (readonly, nonatomic) BOOL isCancelled;
	[Export ("isCancelled")]
	bool IsCancelled { get; }

	// -(instancetype _Nonnull)initWithToken:(FBSDKAccessToken * _Nullable)token isCancelled:(BOOL)cancelled __attribute__((objc_designated_initializer));
	[Export ("initWithToken:isCancelled:")]
	[DesignatedInitializer]
	NativeHandle Constructor ([NullAllowed] FBSDKAccessToken token, bool cancelled);
}

// @interface FBSDKLoginButton : FBSDKButton
[BaseType (typeof(FBSDKButton))]
interface FBSDKLoginButton
{
	// @property (nonatomic) enum FBSDKDefaultAudience defaultAudience;
	[Export ("defaultAudience", ArgumentSemantic.Assign)]
	FBSDKDefaultAudience DefaultAudience { get; set; }

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKLoginButtonDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKLoginButtonDelegate> _Nullable delegate __attribute__((iboutlet));
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull permissions;
	[Export ("permissions", ArgumentSemantic.Copy)]
	string[] Permissions { get; set; }

	// @property (nonatomic) enum FBSDKLoginButtonTooltipBehavior tooltipBehavior;
	[Export ("tooltipBehavior", ArgumentSemantic.Assign)]
	FBSDKLoginButtonTooltipBehavior TooltipBehavior { get; set; }

	// @property (nonatomic) enum FBSDKTooltipColorStyle tooltipColorStyle;
	[Export ("tooltipColorStyle", ArgumentSemantic.Assign)]
	FBSDKTooltipColorStyle TooltipColorStyle { get; set; }

	// @property (nonatomic) enum FBSDKLoginTracking loginTracking;
	[Export ("loginTracking", ArgumentSemantic.Assign)]
	FBSDKLoginTracking LoginTracking { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable nonce;
	[NullAllowed, Export ("nonce")]
	string Nonce { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable messengerPageId;
	[NullAllowed, Export ("messengerPageId")]
	string MessengerPageId { get; set; }

	// @property (nonatomic) FBSDKLoginAuthType _Nullable authType;
	[NullAllowed, Export ("authType")]
	string AuthType { get; set; }

	// @property (nonatomic, strong) FBSDKCodeVerifier * _Nonnull codeVerifier;
	[Export ("codeVerifier", ArgumentSemantic.Strong)]
	FBSDKCodeVerifier CodeVerifier { get; set; }

	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	[Export ("initWithFrame:")]
	[DesignatedInitializer]
	NativeHandle Constructor (CGRect frame);

	// -(void)didMoveToWindow;
	[Export ("didMoveToWindow")]
	void DidMoveToWindow ();

	// -(CGRect)imageRectForContentRect:(CGRect)contentRect __attribute__((warn_unused_result("")));
	[Export ("imageRectForContentRect:")]
	CGRect ImageRectForContentRect (CGRect contentRect);

	// -(CGRect)titleRectForContentRect:(CGRect)contentRect __attribute__((warn_unused_result("")));
	[Export ("titleRectForContentRect:")]
	CGRect TitleRectForContentRect (CGRect contentRect);

	// -(void)layoutSubviews;
	[Export ("layoutSubviews")]
	void LayoutSubviews ();

	// -(CGSize)sizeThatFits:(CGSize)size __attribute__((warn_unused_result("")));
	[Export ("sizeThatFits:")]
	CGSize SizeThatFits (CGSize size);
}

// @interface FBSDKTooltipView : UIView
[BaseType (typeof(UIView))]
[DisableDefaultCtor]
interface FBSDKTooltipView
{
	// @property (nonatomic) NSTimeInterval displayDuration;
	[Export ("displayDuration")]
	double DisplayDuration { get; set; }

	// @property (nonatomic) enum FBSDKTooltipColorStyle colorStyle;
	[Export ("colorStyle", ArgumentSemantic.Assign)]
	FBSDKTooltipColorStyle ColorStyle { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable message;
	[NullAllowed, Export ("message")]
	string Message { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable tagline;
	[NullAllowed, Export ("tagline")]
	string Tagline { get; set; }

	// -(instancetype _Nonnull)initWithTagline:(NSString * _Nullable)tagline message:(NSString * _Nullable)message colorStyle:(enum FBSDKTooltipColorStyle)colorStyle __attribute__((objc_designated_initializer));
	[Export ("initWithTagline:message:colorStyle:")]
	[DesignatedInitializer]
	NativeHandle Constructor ([NullAllowed] string tagline, [NullAllowed] string message, FBSDKTooltipColorStyle colorStyle);

	// -(void)presentFromView:(UIView * _Nonnull)anchorView;
	[Export ("presentFromView:")]
	void PresentFromView (UIView anchorView);

	// -(void)presentInView:(UIView * _Nonnull)view withArrowPosition:(CGPoint)arrowPosition direction:(enum FBSDKTooltipViewArrowDirection)direction;
	[Export ("presentInView:withArrowPosition:direction:")]
	void PresentInView (UIView view, CGPoint arrowPosition, FBSDKTooltipViewArrowDirection direction);

	// -(void)dismiss;
	[Export ("dismiss")]
	void Dismiss ();

	// -(void)drawRect:(CGRect)rect;
	[Export ("drawRect:")]
	void DrawRect (CGRect rect);

	// -(void)layoutSubviews;
	[Export ("layoutSubviews")]
	void LayoutSubviews ();
}

// @interface FBSDKLoginTooltipView : FBSDKTooltipView
[BaseType (typeof(FBSDKTooltipView))]
interface FBSDKLoginTooltipView
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKLoginTooltipViewDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKLoginTooltipViewDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic) BOOL forceDisplay;
	[Export ("forceDisplay")]
	bool ForceDisplay { get; set; }

	// @property (nonatomic) BOOL shouldForceDisplay;
	[Export ("shouldForceDisplay")]
	bool ShouldForceDisplay { get; set; }

	// -(instancetype _Nonnull)initWithTagline:(NSString * _Nullable)tagline message:(NSString * _Nullable)message colorStyle:(enum FBSDKTooltipColorStyle)colorStyle __attribute__((objc_designated_initializer));
	[Export ("initWithTagline:message:colorStyle:")]
	[DesignatedInitializer]
	NativeHandle Constructor ([NullAllowed] string tagline, [NullAllowed] string message, FBSDKTooltipColorStyle colorStyle);

	// -(void)presentInView:(UIView * _Nonnull)view withArrowPosition:(CGPoint)arrowPosition direction:(enum FBSDKTooltipViewArrowDirection)direction;
	[Export ("presentInView:withArrowPosition:direction:")]
	void PresentInView (UIView view, CGPoint arrowPosition, FBSDKTooltipViewArrowDirection direction);
}

// @interface FBSDKPermission : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKPermission : INativeObject
{
	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	[Export ("description")]
	string Description { get; }

	// @property (readonly, nonatomic) NSUInteger hash;
	[Export ("hash")]
	nuint Hash { get; }

	// -(instancetype _Nullable)initWithString:(NSString * _Nonnull)string __attribute__((objc_designated_initializer));
	[Export ("initWithString:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string @string);

	// +(NSSet<FBSDKPermission *> * _Nullable)permissionsFromRawPermissions:(NSSet<NSString *> * _Nonnull)rawPermissions __attribute__((warn_unused_result("")));
	[Static]
	[Export ("permissionsFromRawPermissions:")]
	[return: NullAllowed]
	NSSet<FBSDKPermission> PermissionsFromRawPermissions (NSSet<NSString> rawPermissions);

	// +(NSSet<NSString *> * _Nonnull)rawPermissionsFromPermissions:(NSSet<FBSDKPermission *> * _Nonnull)permissions __attribute__((warn_unused_result("")));
	[Static]
	[Export ("rawPermissionsFromPermissions:")]
	NSSet<NSString> RawPermissionsFromPermissions (NSSet<FBSDKPermission> permissions);

	// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
	[Export ("isEqual:")]
	bool IsEqual ([NullAllowed] NSObject @object);
}

// @protocol FBSDKLoginButtonDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FBSDKLoginButtonDelegate
{
	// @required -(void)loginButton:(FBSDKLoginButton * _Nonnull)loginButton didCompleteWithResult:(FBSDKLoginManagerLoginResult * _Nullable)result error:(NSError * _Nullable)error;
	[Abstract]
	[Export ("loginButton:didCompleteWithResult:error:")]
	void LoginButton (FBSDKLoginButton loginButton, [NullAllowed] FBSDKLoginManagerLoginResult result, [NullAllowed] NSError error);

	// @required -(void)loginButtonDidLogOut:(FBSDKLoginButton * _Nonnull)loginButton;
	[Abstract]
	[Export ("loginButtonDidLogOut:")]
	void LoginButtonDidLogOut (FBSDKLoginButton loginButton);

	// @optional -(BOOL)loginButtonWillLogin:(FBSDKLoginButton * _Nonnull)loginButton __attribute__((warn_unused_result("")));
	[Export ("loginButtonWillLogin:")]
	bool LoginButtonWillLogin (FBSDKLoginButton loginButton);
}

interface IFBSDKLoginButtonDelegate {}

// @interface FBSDKLoginConfiguration : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKLoginConfiguration
{
	// @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
	[Export ("nonce")]
	string Nonce { get; }

	// @property (readonly, nonatomic) enum FBSDKLoginTracking tracking;
	[Export ("tracking")]
	FBSDKLoginTracking Tracking { get; }

	// @property (readonly, copy, nonatomic) NSSet<FBSDKPermission *> * _Nonnull requestedPermissions;
	[Export ("requestedPermissions", ArgumentSemantic.Copy)]
	NSSet<FBSDKPermission> RequestedPermissions { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable messengerPageId;
	[NullAllowed, Export ("messengerPageId")]
	string MessengerPageId { get; }

	// @property (readonly, nonatomic) FBSDKLoginAuthType _Nullable authType;
	[NullAllowed, Export ("authType")]
	string AuthType { get; }

	// @property (readonly, nonatomic, strong) FBSDKCodeVerifier * _Nonnull codeVerifier;
	[Export ("codeVerifier", ArgumentSemantic.Strong)]
	FBSDKCodeVerifier CodeVerifier { get; }

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking nonce:(NSString * _Nonnull)nonce messengerPageId:(NSString * _Nullable)messengerPageId;
	[Export ("initWithPermissions:tracking:nonce:messengerPageId:")]
	NativeHandle Constructor (string[] permissions, FBSDKLoginTracking tracking, string nonce, [NullAllowed] string messengerPageId);

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking nonce:(NSString * _Nonnull)nonce messengerPageId:(NSString * _Nullable)messengerPageId authType:(FBSDKLoginAuthType _Nullable)authType;
	[Export ("initWithPermissions:tracking:nonce:messengerPageId:authType:")]
	NativeHandle Constructor (string[] permissions, FBSDKLoginTracking tracking, string nonce, [NullAllowed] string messengerPageId, [NullAllowed] string authType);

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking nonce:(NSString * _Nonnull)nonce;
	[Export ("initWithPermissions:tracking:nonce:")]
	[Static]
	NativeHandle CreateWithNonce (string[] permissions, FBSDKLoginTracking tracking, string nonce);

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking messengerPageId:(NSString * _Nullable)messengerPageId;
	[Export ("initWithPermissions:tracking:messengerPageId:")]
	[Static]
	NativeHandle CreateWithMessengerPageId (string[] permissions, FBSDKLoginTracking tracking, [NullAllowed] string messengerPageId);

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking messengerPageId:(NSString * _Nullable)messengerPageId authType:(FBSDKLoginAuthType _Nullable)authType;
	[Export ("initWithPermissions:tracking:messengerPageId:authType:")]
	[Static]
	NativeHandle CreateWithAuthtype (string[] permissions, FBSDKLoginTracking tracking, [NullAllowed] string messengerPageId, [NullAllowed] string authType);

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking nonce:(NSString * _Nonnull)nonce messengerPageId:(NSString * _Nullable)messengerPageId authType:(FBSDKLoginAuthType _Nullable)authType codeVerifier:(FBSDKCodeVerifier * _Nonnull)codeVerifier __attribute__((objc_designated_initializer));
	[Export ("initWithPermissions:tracking:nonce:messengerPageId:authType:codeVerifier:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string[] permissions, FBSDKLoginTracking tracking, string nonce, [NullAllowed] string messengerPageId, [NullAllowed] string authType, FBSDKCodeVerifier codeVerifier);

	// -(instancetype _Nullable)initWithPermissions:(NSArray<NSString *> * _Nonnull)permissions tracking:(enum FBSDKLoginTracking)tracking;
	[Export ("initWithPermissions:tracking:")]
	NativeHandle Constructor (string[] permissions, FBSDKLoginTracking tracking);

	// -(instancetype _Nullable)initWithTracking:(enum FBSDKLoginTracking)tracking;
	[Export ("initWithTracking:")]
	NativeHandle Constructor (FBSDKLoginTracking tracking);
}

// @interface FBSDKLoginManager : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKLoginManager
{
	// @property (nonatomic) enum FBSDKDefaultAudience defaultAudience;
	[Export ("defaultAudience", ArgumentSemantic.Assign)]
	FBSDKDefaultAudience DefaultAudience { get; set; }

	// -(instancetype _Nonnull)initWithDefaultAudience:(enum FBSDKDefaultAudience)defaultAudience;
	[Export ("initWithDefaultAudience:")]
	NativeHandle Constructor (FBSDKDefaultAudience defaultAudience);

	// -(void)logInFromViewController:(UIViewController * _Nullable)viewController configuration:(FBSDKLoginConfiguration * _Nullable)configuration completion:(FBSDKLoginManagerLoginResultBlock _Nonnull)completion;
	[Export ("logInFromViewController:configuration:completion:")]
	void LogInFromViewController ([NullAllowed] UIViewController viewController, [NullAllowed] FBSDKLoginConfiguration configuration, FBSDKLoginManagerLoginResultBlock completion);

	// -(void)logInWithPermissions:(NSArray<NSString *> * _Nonnull)permissions fromViewController:(UIViewController * _Nullable)viewController handler:(FBSDKLoginManagerLoginResultBlock _Nullable)handler;
	[Export ("logInWithPermissions:fromViewController:handler:")]
	void LogInWithPermissions (string[] permissions, [NullAllowed] UIViewController viewController, [NullAllowed] FBSDKLoginManagerLoginResultBlock handler);

	// -(void)reauthorizeDataAccess:(UIViewController * _Nonnull)viewController handler:(FBSDKLoginManagerLoginResultBlock _Nonnull)handler;
	[Export ("reauthorizeDataAccess:handler:")]
	void ReauthorizeDataAccess (UIViewController viewController, FBSDKLoginManagerLoginResultBlock handler);

	// -(void)logOut;
	[Export ("logOut")]
	void LogOut ();
}

// @interface FBSDKLoginKit_Swift_813 (FBSDKLoginManager) <FBSDKURLOpening>
// [Category]
// [BaseType (typeof(FBSDKLoginManager))]
// interface FBSDKLoginManager_FBSDKLoginKit_Swift_813 : IFBSDKURLOpening
// {
// 	// +(FBSDKLoginManager * _Nonnull)makeOpener __attribute__((warn_unused_result("")));
// 	[Static]
// 	[Export ("makeOpener")]
// 	FBSDKLoginManager MakeOpener { get; }
//
// 	// -(BOOL)application:(UIApplication * _Nullable)application openURL:(NSURL * _Nullable)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
// 	[Export ("application:openURL:sourceApplication:annotation:")]
// 	bool Application ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
//
// 	// -(BOOL)canOpenURL:(NSURL * _Nonnull)url forApplication:(UIApplication * _Nullable)application sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
// 	[Export ("canOpenURL:forApplication:sourceApplication:annotation:")]
// 	bool CanOpenURL (NSUrl url, [NullAllowed] UIApplication application, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
//
// 	// -(void)applicationDidBecomeActive:(UIApplication * _Nonnull)application;
// 	[Export ("applicationDidBecomeActive:")]
// 	void ApplicationDidBecomeActive (UIApplication application);
//
// 	// -(BOOL)isAuthenticationURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
// 	[Export ("isAuthenticationURL:")]
// 	bool IsAuthenticationURL (NSUrl url);
//
// 	// -(BOOL)shouldStopPropagationOfURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
// 	[Export ("shouldStopPropagationOfURL:")]
// 	bool ShouldStopPropagationOfURL (NSUrl url);
// }

// @interface FBSDKLoginManagerLoginResult : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKLoginManagerLoginResult
{
	// @property (readonly, nonatomic, strong) FBSDKAccessToken * _Nullable token;
	[NullAllowed, Export ("token", ArgumentSemantic.Strong)]
	FBSDKAccessToken Token { get; }

	// @property (readonly, nonatomic, strong) FBSDKAuthenticationToken * _Nullable authenticationToken;
	[NullAllowed, Export ("authenticationToken", ArgumentSemantic.Strong)]
	FBSDKAuthenticationToken AuthenticationToken { get; }

	// @property (readonly, nonatomic) BOOL isCancelled;
	[Export ("isCancelled")]
	bool IsCancelled { get; }

	// @property (readonly, copy, nonatomic) NSSet<NSString *> * _Nonnull grantedPermissions;
	[Export ("grantedPermissions", ArgumentSemantic.Copy)]
	NSSet<NSString> GrantedPermissions { get; }

	// @property (readonly, copy, nonatomic) NSSet<NSString *> * _Nonnull declinedPermissions;
	[Export ("declinedPermissions", ArgumentSemantic.Copy)]
	NSSet<NSString> DeclinedPermissions { get; }

	// -(instancetype _Nonnull)initWithToken:(FBSDKAccessToken * _Nullable)token authenticationToken:(FBSDKAuthenticationToken * _Nullable)authenticationToken isCancelled:(BOOL)isCancelled grantedPermissions:(NSSet<NSString *> * _Nonnull)grantedPermissions declinedPermissions:(NSSet<NSString *> * _Nonnull)declinedPermissions __attribute__((objc_designated_initializer));
	[Export ("initWithToken:authenticationToken:isCancelled:grantedPermissions:declinedPermissions:")]
	[DesignatedInitializer]
	NativeHandle Constructor ([NullAllowed] FBSDKAccessToken token, [NullAllowed] FBSDKAuthenticationToken authenticationToken, bool isCancelled, NSSet<NSString> grantedPermissions, NSSet<NSString> declinedPermissions);
}

// @protocol FBSDKLoginTooltipViewDelegate
[Protocol, Model]
interface FBSDKLoginTooltipViewDelegate
{
	// @optional -(BOOL)loginTooltipView:(FBSDKLoginTooltipView * _Nonnull)view shouldAppear:(BOOL)appIsEligible __attribute__((warn_unused_result("")));
	[Export ("loginTooltipView:shouldAppear:")]
	bool LoginTooltipView (FBSDKLoginTooltipView view, bool appIsEligible);

	// @optional -(void)loginTooltipViewWillAppear:(FBSDKLoginTooltipView * _Nonnull)view;
	[Export ("loginTooltipViewWillAppear:")]
	void LoginTooltipViewWillAppear (FBSDKLoginTooltipView view);

	// @optional -(void)loginTooltipViewWillNotAppear:(FBSDKLoginTooltipView * _Nonnull)view;
	[Export ("loginTooltipViewWillNotAppear:")]
	void LoginTooltipViewWillNotAppear (FBSDKLoginTooltipView view);
}

interface IFBSDKLoginTooltipViewDelegate {}

// @interface FBSDKLoginCompletionParameters : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKLoginCompletionParameters
{
	// @property (nonatomic, strong) FBSDKAuthenticationToken * _Nullable authenticationToken;
	[NullAllowed, Export ("authenticationToken", ArgumentSemantic.Strong)]
	FBSDKAuthenticationToken AuthenticationToken { get; set; }

	// @property (nonatomic, strong) FBSDKProfile * _Nullable profile;
	[NullAllowed, Export ("profile", ArgumentSemantic.Strong)]
	FBSDKProfile Profile { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable accessTokenString;
	[NullAllowed, Export ("accessTokenString")]
	string AccessTokenString { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable nonceString;
	[NullAllowed, Export ("nonceString")]
	string NonceString { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable authenticationTokenString;
	[NullAllowed, Export ("authenticationTokenString")]
	string AuthenticationTokenString { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable code;
	[NullAllowed, Export ("code")]
	string Code { get; set; }

	// @property (copy, nonatomic) NSSet<FBSDKPermission *> * _Nullable permissions;
	[NullAllowed, Export ("permissions", ArgumentSemantic.Copy)]
	NSSet<FBSDKPermission> Permissions { get; set; }

	// @property (copy, nonatomic) NSSet<FBSDKPermission *> * _Nullable declinedPermissions;
	[NullAllowed, Export ("declinedPermissions", ArgumentSemantic.Copy)]
	NSSet<FBSDKPermission> DeclinedPermissions { get; set; }

	// @property (copy, nonatomic) NSSet<FBSDKPermission *> * _Nullable expiredPermissions;
	[NullAllowed, Export ("expiredPermissions", ArgumentSemantic.Copy)]
	NSSet<FBSDKPermission> ExpiredPermissions { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable appID;
	[NullAllowed, Export ("appID")]
	string AppID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable userID;
	[NullAllowed, Export ("userID")]
	string UserID { get; set; }

	// @property (nonatomic) NSError * _Nullable error;
	[NullAllowed, Export ("error", ArgumentSemantic.Assign)]
	NSError Error { get; set; }

	// @property (copy, nonatomic) NSDate * _Nullable expirationDate;
	[NullAllowed, Export ("expirationDate", ArgumentSemantic.Copy)]
	NSDate ExpirationDate { get; set; }

	// @property (copy, nonatomic) NSDate * _Nullable dataAccessExpirationDate;
	[NullAllowed, Export ("dataAccessExpirationDate", ArgumentSemantic.Copy)]
	NSDate DataAccessExpirationDate { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable challenge;
	[NullAllowed, Export ("challenge")]
	string Challenge { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable graphDomain;
	[NullAllowed, Export ("graphDomain")]
	string GraphDomain { get; set; }
}

}
