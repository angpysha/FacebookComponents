using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using Facebook.CoreKit;
using CoreGraphics;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Facebook.GamingServicesKit {
// @protocol FBSDKValidatable
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKValidatable
{
	// @required -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Abstract]
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);
}

interface IFBSDKValidatable {}

// @interface FBSDKChooseContextContent : NSObject <FBSDKValidatable>
[BaseType (typeof(NSObject))]
interface FBSDKChooseContextContent : IFBSDKValidatable
{
	// @property (nonatomic) enum FBSDKChooseContextFilter filter;
	[Export ("filter", ArgumentSemantic.Assign)]
	FBSDKChooseContextFilter Filter { get; set; }

	// @property (nonatomic) NSInteger maxParticipants;
	[Export ("maxParticipants")]
	nint MaxParticipants { get; set; }

	// @property (nonatomic) NSInteger minParticipants;
	[Export ("minParticipants")]
	nint MinParticipants { get; set; }

	// +(NSString * _Nonnull)filtersNameForFilters:(enum FBSDKChooseContextFilter)filter __attribute__((warn_unused_result("")));
	[Static]
	[Export ("filtersNameForFilters:")]
	string FiltersNameForFilters (FBSDKChooseContextFilter filter);

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);

	// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
	[Export ("isEqual:")]
	bool IsEqual ([NullAllowed] NSObject @object);
}

// @protocol FBSDKDialog
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKDialog
{
	[Wrap ("WeakDelegate"), Abstract]
	[NullAllowed]
	IFBSDKContextDialogDelegate Delegate { get; set; }

	// @required @property (nonatomic, weak) id<FBSDKContextDialogDelegate> _Nullable delegate;
	[Abstract]
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @required @property (nonatomic, strong) id<FBSDKValidatable> _Nullable dialogContent;
	[Abstract]
	[NullAllowed, Export ("dialogContent", ArgumentSemantic.Strong)]
	IFBSDKValidatable DialogContent { get; set; }

	// @required -(BOOL)show __attribute__((warn_unused_result("")));
	[Abstract]
	[Export ("show")]
	bool Show { get; }

	// @required -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Abstract]
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);
}

// @interface FBSDKContextWebDialog : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKContextWebDialog
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKContextDialogDelegate Delegate { get; set; }

	// @property (nonatomic, strong) id<FBSDKContextDialogDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Strong)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) id<FBSDKValidatable> _Nullable dialogContent;
	[NullAllowed, Export ("dialogContent", ArgumentSemantic.Strong)]
	IFBSDKValidatable DialogContent { get; set; }

	// @property (nonatomic, strong) FBSDKWebDialog * _Nullable currentWebDialog;
	[NullAllowed, Export ("currentWebDialog", ArgumentSemantic.Strong)]
	FBSDKWebDialog CurrentWebDialog { get; set; }

	// -(BOOL)show __attribute__((warn_unused_result("")));
	[Export ("show")]
	bool Show { get; }

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);

	// -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
	[Export ("webDialog:didCompleteWithResults:")]
	void WebDialog (FBSDKWebDialog webDialog, NSDictionary<NSString, NSObject> results);

	// -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didFailWithError:(NSError * _Nonnull)error;
	[Export ("webDialog:didFailWithError:")]
	void WebDialog (FBSDKWebDialog webDialog, NSError error);

	// -(void)webDialogDidCancel:(FBSDKWebDialog * _Nonnull)webDialog;
	[Export ("webDialogDidCancel:")]
	void WebDialogDidCancel (FBSDKWebDialog webDialog);

	// -(CGRect)createWebDialogFrameWithWidth:(CGFloat)width height:(CGFloat)height windowFinder:(id<_FBSDKWindowFinding> _Nonnull)windowFinder __attribute__((warn_unused_result("")));
	[Export ("createWebDialogFrameWithWidth:height:windowFinder:")]
	CGRect CreateWebDialogFrameWithWidth (nfloat width, nfloat height, I_FBSDKWindowFinding windowFinder);
}

// @interface FBSDKChooseContextDialog : FBSDKContextWebDialog
[BaseType (typeof(FBSDKContextWebDialog))]
interface FBSDKChooseContextDialog
{
	// -(instancetype _Nonnull)initWithContent:(FBSDKChooseContextContent * _Nonnull)content delegate:(id<FBSDKContextDialogDelegate> _Nonnull)delegate;
	[Export ("initWithContent:delegate:")]
	NativeHandle Constructor (FBSDKChooseContextContent content, IFBSDKContextDialogDelegate @delegate);

	// -(BOOL)show __attribute__((warn_unused_result("")));
	[Export ("show")]
	bool Show { get; }

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);

	// -(BOOL)application:(UIApplication * _Nullable)application openURL:(NSURL * _Nullable)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
	[Export ("application:openURL:sourceApplication:annotation:")]
	bool Application ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

	// -(BOOL)canOpenURL:(NSURL * _Nonnull)url forApplication:(UIApplication * _Nullable)application sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
	[Export ("canOpenURL:forApplication:sourceApplication:annotation:")]
	bool CanOpenURL (NSUrl url, [NullAllowed] UIApplication application, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

	// -(void)applicationDidBecomeActive:(UIApplication * _Nonnull)application;
	[Export ("applicationDidBecomeActive:")]
	void ApplicationDidBecomeActive (UIApplication application);

	// -(BOOL)isAuthenticationURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
	[Export ("isAuthenticationURL:")]
	bool IsAuthenticationURL (NSUrl url);
}

// @protocol FBSDKShowable
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKShowable
{
	// @required -(BOOL)show __attribute__((warn_unused_result("")));
	[Abstract]
	[Export ("show")]
	bool Show { get; }
}

interface IFBSDKShowable {}

// @interface FBSDKGamingServicesKit_Swift_374 (FBSDKChooseContextDialog) <FBSDKShowable>
// [Category]
// [BaseType (typeof(FBSDKChooseContextDialog))]
// interface FBSDKChooseContextDialog_FBSDKGamingServicesKit_Swift_374 : IFBSDKShowable
// {
// }

// @protocol FBSDKContextDialogDelegate
[Protocol, Model]
interface FBSDKContextDialogDelegate
{
	// @required -(void)contextDialogDidComplete:(FBSDKContextWebDialog * _Nonnull)contextDialog;
	[Abstract]
	[Export ("contextDialogDidComplete:")]
	void ContextDialogDidComplete (FBSDKContextWebDialog contextDialog);

	// @required -(void)contextDialog:(FBSDKContextWebDialog * _Nonnull)contextDialog didFailWithError:(NSError * _Nonnull)error;
	[Abstract]
	[Export ("contextDialog:didFailWithError:")]
	void ContextDialog (FBSDKContextWebDialog contextDialog, NSError error);

	// @required -(void)contextDialogDidCancel:(FBSDKContextWebDialog * _Nonnull)contextDialog;
	[Abstract]
	[Export ("contextDialogDidCancel:")]
	void ContextDialogDidCancel (FBSDKContextWebDialog contextDialog);
}

interface IFBSDKContextDialogDelegate {
	
}

// @interface FBSDKContextDialogPresenter : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKContextDialogPresenter
{
	// -(BOOL)makeAndShowCreateContextDialogWithContent:(FBSDKCreateContextContent * _Nonnull)content delegate:(id<FBSDKContextDialogDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
	[Export ("makeAndShowCreateContextDialogWithContent:delegate:error:")]
	bool MakeAndShowCreateContextDialogWithContent (FBSDKCreateContextContent content, IFBSDKContextDialogDelegate @delegate, [NullAllowed] out NSError error);

	// -(BOOL)makeAndShowSwitchContextDialogWithContent:(FBSDKSwitchContextContent * _Nonnull)content delegate:(id<FBSDKContextDialogDelegate> _Nonnull)delegate error:(NSError * _Nullable * _Nullable)error;
	[Export ("makeAndShowSwitchContextDialogWithContent:delegate:error:")]
	bool MakeAndShowSwitchContextDialogWithContent (FBSDKSwitchContextContent content, IFBSDKContextDialogDelegate @delegate, [NullAllowed] out NSError error);

	// -(void)makeAndShowChooseContextDialogWithContent:(FBSDKChooseContextContent * _Nonnull)content delegate:(id<FBSDKContextDialogDelegate> _Nonnull)delegate;
	[Export ("makeAndShowChooseContextDialogWithContent:delegate:")]
	void MakeAndShowChooseContextDialogWithContent (FBSDKChooseContextContent content, IFBSDKContextDialogDelegate @delegate);
}

// @interface FBSDKCreateContextContent : NSObject <FBSDKValidatable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKCreateContextContent : IFBSDKValidatable
{
	// @property (copy, nonatomic) NSString * _Nonnull playerID;
	[Export ("playerID")]
	string PlayerID { get; set; }

	// -(instancetype _Nonnull)initDialogContentWithPlayerID:(NSString * _Nonnull)playerID __attribute__((objc_designated_initializer));
	[Export ("initDialogContentWithPlayerID:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string playerID);

	// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
	[Export ("isEqual:")]
	bool IsEqual ([NullAllowed] NSObject @object);

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);
}

// @interface FBSDKCreateContextDialog : FBSDKContextWebDialog
[BaseType (typeof(FBSDKContextWebDialog))]
interface FBSDKCreateContextDialog
{
	// -(instancetype _Nonnull)initWithContent:(FBSDKCreateContextContent * _Nonnull)content windowFinder:(id<_FBSDKWindowFinding> _Nonnull)windowFinder delegate:(id<FBSDKContextDialogDelegate> _Nonnull)delegate __attribute__((objc_designated_initializer));
	[Export ("initWithContent:windowFinder:delegate:")]
	[DesignatedInitializer]
	NativeHandle Constructor (FBSDKCreateContextContent content, I_FBSDKWindowFinding windowFinder, IFBSDKContextDialogDelegate @delegate);

	// -(BOOL)show __attribute__((warn_unused_result("")));
	[Export ("show")]
	bool Show { get; }

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);
}

// @interface FBSDKGamingServicesKit_Swift_462 (FBSDKCreateContextDialog) <FBSDKShowable>
// [Category]
// [BaseType (typeof(FBSDKCreateContextDialog))]
// interface FBSDKCreateContextDialog_FBSDKGamingServicesKit_Swift_462 : IFBSDKShowable
// {
// }

// @interface FBSDKFriendFinderDialog : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKFriendFinderDialog
{
	// +(void)launchFriendFinderDialogWithCompletionHandler:(void (^ _Nonnull)(BOOL, NSError * _Nullable))completionHandler;
	[Static]
	[Export ("launchFriendFinderDialogWithCompletionHandler:")]
	void LaunchFriendFinderDialogWithCompletionHandler (Action<bool, NSError> completionHandler);
}

// @interface FBSDKGameRequestContent : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKGameRequestContent
{
	// @property (nonatomic) enum FBSDKGameRequestActionType actionType;
	[Export ("actionType", ArgumentSemantic.Assign)]
	FBSDKGameRequestActionType ActionType { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable data;
	[NullAllowed, Export ("data")]
	string Data { get; set; }

	// @property (nonatomic) enum FBSDKGameRequestFilter filters;
	[Export ("filters", ArgumentSemantic.Assign)]
	FBSDKGameRequestFilter Filters { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull message;
	[Export ("message")]
	string Message { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull objectID;
	[Export ("objectID")]
	string ObjectID { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull recipients;
	[Export ("recipients", ArgumentSemantic.Copy)]
	string[] Recipients { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull recipientSuggestions;
	[Export ("recipientSuggestions", ArgumentSemantic.Copy)]
	string[] RecipientSuggestions { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull title;
	[Export ("title")]
	string Title { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull cta;
	[Export ("cta")]
	string Cta { get; set; }

	// -(BOOL)validateWithOptions:(id)options error:(NSError * _Nullable * _Nullable)error;
	[Export ("validateWithOptions:error:")]
	bool ValidateWithOptions (NSObject options, [NullAllowed] out NSError error);

	// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
	[Export ("isEqual:")]
	bool IsEqual ([NullAllowed] NSObject @object);

	// -(BOOL)isEqualToGameRequestContent:(FBSDKGameRequestContent * _Nonnull)content __attribute__((warn_unused_result("")));
	[Export ("isEqualToGameRequestContent:")]
	bool IsEqualToGameRequestContent (FBSDKGameRequestContent content);

	// @property (readonly, nonatomic, class) BOOL supportsSecureCoding;
	[Static]
	[Export ("supportsSecureCoding")]
	bool SupportsSecureCoding { get; }

	// -(instancetype _Nonnull)initWithCoder:(NSCoder * _Nonnull)decoder;
	[Export ("initWithCoder:")]
	NativeHandle Constructor (NSCoder decoder);

	// -(void)encodeWithCoder:(NSCoder * _Nonnull)encoder;
	[Export ("encodeWithCoder:")]
	void EncodeWithCoder (NSCoder encoder);
}

// @interface FBSDKGameRequestDialog : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGameRequestDialog
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKGameRequestDialogDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKGameRequestDialogDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) FBSDKGameRequestContent * _Nonnull content;
	[Export ("content", ArgumentSemantic.Strong)]
	FBSDKGameRequestContent Content { get; set; }

	// @property (nonatomic) BOOL isFrictionlessRequestsEnabled;
	[Export ("isFrictionlessRequestsEnabled")]
	bool IsFrictionlessRequestsEnabled { get; set; }

	// @property (readonly, nonatomic) BOOL canShow;
	[Export ("canShow")]
	bool CanShow { get; }

	// -(instancetype _Nonnull)initWithContent:(FBSDKGameRequestContent * _Nonnull)content delegate:(id<FBSDKGameRequestDialogDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
	[Export ("initWithContent:delegate:")]
	[DesignatedInitializer]
	NativeHandle Constructor (FBSDKGameRequestContent content, [NullAllowed] IFBSDKGameRequestDialogDelegate @delegate);

	// +(FBSDKGameRequestDialog * _Nonnull)dialogWithContent:(FBSDKGameRequestContent * _Nonnull)content delegate:(id<FBSDKGameRequestDialogDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
	[Static]
	[Export ("dialogWithContent:delegate:")]
	FBSDKGameRequestDialog DialogWithContent (FBSDKGameRequestContent content, [NullAllowed] IFBSDKGameRequestDialogDelegate @delegate);

	// +(FBSDKGameRequestDialog * _Nonnull)showWithContent:(FBSDKGameRequestContent * _Nonnull)content delegate:(id<FBSDKGameRequestDialogDelegate> _Nullable)delegate;
	[Static]
	[Export ("showWithContent:delegate:")]
	FBSDKGameRequestDialog ShowWithContent (FBSDKGameRequestContent content, [NullAllowed] IFBSDKGameRequestDialogDelegate @delegate);

	// -(BOOL)show;
	[Export ("show")]
	bool Show { get; }

	// -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateWithError:")]
	bool ValidateWithError ([NullAllowed] out NSError error);
}

// @interface FBSDKGamingServicesKit_Swift_580 (FBSDKGameRequestDialog)
// [Category]
// [BaseType (typeof(FBSDKGameRequestDialog))]
// interface FBSDKGameRequestDialog_FBSDKGamingServicesKit_Swift_580
// {
// 	// -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
// 	[Export ("webDialog:didCompleteWithResults:")]
// 	void WebDialog (FBSDKWebDialog webDialog, NSDictionary<NSString, NSObject> results);
//
// 	// -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didFailWithError:(NSError * _Nonnull)error;
// 	[Export ("webDialog:didFailWithError:")]
// 	void WebDialog (FBSDKWebDialog webDialog, NSError error);
//
// 	// -(void)webDialogDidCancel:(FBSDKWebDialog * _Nonnull)webDialog;
// 	[Export ("webDialogDidCancel:")]
// 	void WebDialogDidCancel (FBSDKWebDialog webDialog);
// }
//
// // @interface FBSDKGamingServicesKit_Swift_587 (FBSDKGameRequestDialog)
// [Category]
// [BaseType (typeof(FBSDKGameRequestDialog))]
// interface FBSDKGameRequestDialog_FBSDKGamingServicesKit_Swift_587
// {
// 	// -(BOOL)application:(UIApplication * _Nullable)application openURL:(NSURL * _Nullable)potentialURL sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
// 	[Export ("application:openURL:sourceApplication:annotation:")]
// 	bool Application ([NullAllowed] UIApplication application, [NullAllowed] NSUrl potentialURL, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
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
// }

// @protocol FBSDKGameRequestDialogDelegate
[Protocol, Model]
interface FBSDKGameRequestDialogDelegate
{
	// @required -(void)gameRequestDialog:(FBSDKGameRequestDialog * _Nonnull)gameRequestDialog didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
	[Abstract]
	[Export ("gameRequestDialog:didCompleteWithResults:")]
	void GameRequestDialog (FBSDKGameRequestDialog gameRequestDialog, NSDictionary<NSString, NSObject> results);

	// @required -(void)gameRequestDialog:(FBSDKGameRequestDialog * _Nonnull)gameRequestDialog didFailWithError:(NSError * _Nonnull)error;
	[Abstract]
	[Export ("gameRequestDialog:didFailWithError:")]
	void GameRequestDialog (FBSDKGameRequestDialog gameRequestDialog, NSError error);

	// @required -(void)gameRequestDialogDidCancel:(FBSDKGameRequestDialog * _Nonnull)gameRequestDialog;
	[Abstract]
	[Export ("gameRequestDialogDidCancel:")]
	void GameRequestDialogDidCancel (FBSDKGameRequestDialog gameRequestDialog);
}

interface IFBSDKGameRequestDialogDelegate {
	
}

// @interface FBSDKGameRequestURLProvider : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKGameRequestURLProvider
{
	// +(NSURL * _Nullable)createDeepLinkURLWithQueryDictionary:(NSDictionary<NSString *,id> * _Nonnull)queryDictionary __attribute__((warn_unused_result("")));
	[Static]
	[Export ("createDeepLinkURLWithQueryDictionary:")]
	[return: NullAllowed]
	NSUrl CreateDeepLinkURLWithQueryDictionary (NSDictionary<NSString, NSObject> queryDictionary);

	// +(NSString * _Nullable)filtersNameForFilters:(enum FBSDKGameRequestFilter)filters __attribute__((warn_unused_result("")));
	[Static]
	[Export ("filtersNameForFilters:")]
	[return: NullAllowed]
	string FiltersNameForFilters (FBSDKGameRequestFilter filters);

	// +(NSString * _Nullable)actionTypeNameForActionType:(enum FBSDKGameRequestActionType)actionType __attribute__((warn_unused_result("")));
	[Static]
	[Export ("actionTypeNameForActionType:")]
	[return: NullAllowed]
	string ActionTypeNameForActionType (FBSDKGameRequestActionType actionType);
}

// @interface FBSDKGamingContext : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingContext
{
	// @property (nonatomic, strong, class) FBSDKGamingContext * _Nullable currentContext;
	[Static]
	[NullAllowed, Export ("currentContext", ArgumentSemantic.Strong)]
	FBSDKGamingContext CurrentContext { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
	[Export ("identifier")]
	string Identifier { get; }

	// @property (readonly, nonatomic) NSInteger size;
	[Export ("size")]
	nint Size { get; }

	// -(instancetype _Nullable)initWithIdentifier:(NSString * _Nonnull)identifier size:(NSInteger)size __attribute__((objc_designated_initializer));
	[Export ("initWithIdentifier:size:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string identifier, nint size);
}

// @interface FBSDKGamingGroupIntegration : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingGroupIntegration
{
	// +(void)openGroupPageWithCompletionHandler:(void (^ _Nonnull)(BOOL, NSError * _Nullable))completionHandler;
	[Static]
	[Export ("openGroupPageWithCompletionHandler:")]
	void OpenGroupPageWithCompletionHandler (Action<bool, NSError> completionHandler);
}

// @interface FBSDKGamingImageUploader : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingImageUploader
{
	// +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration andResultCompletion:(void (^ _Nonnull)(BOOL, NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))completion;
	[Static]
	[Export ("uploadImageWithConfiguration:andResultCompletion:")]
	void UploadImageWithConfiguration (FBSDKGamingImageUploaderConfiguration configuration, Action<bool, NSDictionary<NSString, NSObject>, NSError> completion);

	// +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration completion:(void (^ _Nonnull)(BOOL, NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))completion andProgressHandler:(void (^ _Nullable)(int64_t, int64_t, int64_t))progressHandler;
	[Static]
	[Export ("uploadImageWithConfiguration:completion:andProgressHandler:")]
	void UploadImageWithConfiguration (FBSDKGamingImageUploaderConfiguration configuration, Action<bool, NSDictionary<NSString, NSObject>, NSError> completion, [NullAllowed] Action<long, long, long> progressHandler);
}

// @interface FBSDKGamingServicesKit_Swift_685 (FBSDKGamingImageUploader)
// [Category]
// [BaseType (typeof(FBSDKGamingImageUploader))]
// interface FBSDKGamingImageUploader_FBSDKGamingServicesKit_Swift_685
// {
// 	// -(void)requestConnection:(id<FBSDKGraphRequestConnecting> _Nonnull)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
// 	[Export ("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
// 	void RequestConnection (IFBSDKGraphRequestConnecting connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
// }

// @interface FBSDKGamingImageUploaderConfiguration : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingImageUploaderConfiguration
{
	// @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
	[Export ("image", ArgumentSemantic.Strong)]
	UIImage Image { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable caption;
	[NullAllowed, Export ("caption")]
	string Caption { get; }

	// @property (readonly, nonatomic) BOOL shouldLaunchMediaDialog;
	[Export ("shouldLaunchMediaDialog")]
	bool ShouldLaunchMediaDialog { get; }

	// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image caption:(NSString * _Nullable)caption shouldLaunchMediaDialog:(BOOL)shouldLaunchMediaDialog __attribute__((objc_designated_initializer));
	[Export ("initWithImage:caption:shouldLaunchMediaDialog:")]
	[DesignatedInitializer]
	NativeHandle Constructor (UIImage image, [NullAllowed] string caption, bool shouldLaunchMediaDialog);
}

// @interface FBSDKGamingPayload : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingPayload
{
	// @property (nonatomic, strong) FBSDKURL * _Nonnull URL;
	[Export ("URL", ArgumentSemantic.Strong)]
	FBSDKURL URL { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull payload;
	[Export ("payload")]
	string Payload { get; set; }

	// -(instancetype _Nonnull)initWithURL:(FBSDKURL * _Nonnull)URL __attribute__((objc_designated_initializer));
	[Export ("initWithURL:")]
	[DesignatedInitializer]
	NativeHandle Constructor (FBSDKURL URL);
}

// @protocol FBSDKGamingPayloadDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface FBSDKGamingPayloadDelegate
{
	// @optional -(void)parsedGameRequestURLContaining:(FBSDKGamingPayload * _Nonnull)payload gameRequestID:(NSString * _Nonnull)gameRequestID;
	[Export ("parsedGameRequestURLContaining:gameRequestID:")]
	void ParsedGameRequestURLContaining (FBSDKGamingPayload payload, string gameRequestID);

	// @optional -(void)parsedGamingContextURLContaining:(FBSDKGamingPayload * _Nonnull)payload;
	[Export ("parsedGamingContextURLContaining:")]
	void ParsedGamingContextURLContaining (FBSDKGamingPayload payload);

	// @optional -(void)parsedTournamentURLContaining:(FBSDKGamingPayload * _Nonnull)payload tournamentID:(NSString * _Nonnull)tournamentID;
	[Export ("parsedTournamentURLContaining:tournamentID:")]
	void ParsedTournamentURLContaining (FBSDKGamingPayload payload, string tournamentID);
}

// @interface FBSDKGamingPayloadObserver : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingPayloadObserver
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	FBSDKGamingPayloadDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKGamingPayloadDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(instancetype _Nonnull)initWithDelegate:(id<FBSDKGamingPayloadDelegate> _Nullable)delegate;
	[Export ("initWithDelegate:")]
	NativeHandle Constructor ([NullAllowed] FBSDKGamingPayloadDelegate @delegate);
}

// @interface FBSDKGamingServicesKit_Swift_743 (FBSDKGamingPayloadObserver)
// [Category]
// [BaseType (typeof(FBSDKGamingPayloadObserver))]
// interface FBSDKGamingPayloadObserver_FBSDKGamingServicesKit_Swift_743
// {
// 	// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
// 	[Export ("application:openURL:sourceApplication:annotation:")]
// 	bool Application (UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
// }

// @interface FBSDKGamingVideoUploader : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingVideoUploader
{
	// +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration andResultCompletion:(void (^ _Nonnull)(BOOL, NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))completion;
	[Static]
	[Export ("uploadVideoWithConfiguration:andResultCompletion:")]
	void UploadVideoWithConfiguration (FBSDKGamingVideoUploaderConfiguration configuration, Action<bool, NSDictionary<NSString, NSObject>, NSError> completion);

	// +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration completion:(void (^ _Nonnull)(BOOL, NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))completion andProgressHandler:(void (^ _Nullable)(int64_t, int64_t, int64_t))progressHandler;
	[Static]
	[Export ("uploadVideoWithConfiguration:completion:andProgressHandler:")]
	void UploadVideoWithConfiguration (FBSDKGamingVideoUploaderConfiguration configuration, Action<bool, NSDictionary<NSString, NSObject>, NSError> completion, [NullAllowed] Action<long, long, long> progressHandler);
}

// @interface FBSDKGamingVideoUploaderConfiguration : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGamingVideoUploaderConfiguration
{
	// @property (readonly, copy, nonatomic) NSURL * _Nonnull videoURL;
	[Export ("videoURL", ArgumentSemantic.Copy)]
	NSUrl VideoURL { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable caption;
	[NullAllowed, Export ("caption")]
	string Caption { get; }

	// -(instancetype _Nonnull)initWithVideoURL:(NSURL * _Nonnull)videoURL caption:(NSString * _Nullable)caption __attribute__((objc_designated_initializer));
	[Export ("initWithVideoURL:caption:")]
	[DesignatedInitializer]
	NativeHandle Constructor (NSUrl videoURL, [NullAllowed] string caption);
}

// @interface ShareTournamentDialog : NSObject
[BaseType (typeof(NSObject), Name = "_TtC22FBSDKGamingServicesKit21ShareTournamentDialog")]
[DisableDefaultCtor]
interface ShareTournamentDialog
{
	// -(BOOL)isAuthenticationURL:(NSURL * _Nonnull)url __attribute__((warn_unused_result("")));
	[Export ("isAuthenticationURL:")]
	bool IsAuthenticationURL (NSUrl url);

	// -(BOOL)application:(UIApplication * _Nullable)application openURL:(NSURL * _Nullable)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
	[Export ("application:openURL:sourceApplication:annotation:")]
	bool Application ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

	// -(BOOL)canOpenURL:(NSURL * _Nonnull)url forApplication:(UIApplication * _Nullable)application sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation __attribute__((warn_unused_result("")));
	[Export ("canOpenURL:forApplication:sourceApplication:annotation:")]
	bool CanOpenURL (NSUrl url, [NullAllowed] UIApplication application, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

	// -(void)applicationDidBecomeActive:(UIApplication * _Nonnull)application;
	[Export ("applicationDidBecomeActive:")]
	void ApplicationDidBecomeActive (UIApplication application);
}

// @interface FBSDKSwitchContextContent : NSObject <FBSDKValidatable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKSwitchContextContent : IFBSDKValidatable
{
	// -(instancetype _Nonnull)initDialogContentWithContextID:(NSString * _Nonnull)contextID __attribute__((objc_designated_initializer));
	[Export ("initDialogContentWithContextID:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string contextID);

	// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
	[Export ("isEqual:")]
	bool IsEqual ([NullAllowed] NSObject @object);

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);
}

// @interface FBSDKSwitchContextDialog : FBSDKContextWebDialog <FBSDKShowable>
[BaseType (typeof(FBSDKContextWebDialog))]
interface FBSDKSwitchContextDialog : IFBSDKShowable
{
	// -(instancetype _Nonnull)initWithContent:(FBSDKSwitchContextContent * _Nonnull)content windowFinder:(id<_FBSDKWindowFinding> _Nonnull)windowFinder delegate:(id<FBSDKContextDialogDelegate> _Nonnull)delegate __attribute__((objc_designated_initializer));
	[Export ("initWithContent:windowFinder:delegate:")]
	[DesignatedInitializer]
	NativeHandle Constructor (FBSDKSwitchContextContent content, I_FBSDKWindowFinding windowFinder, IFBSDKContextDialogDelegate @delegate);
	
	// -(BOOL)show __attribute__((warn_unused_result("")));
	[Export ("show")]
	bool Show { get; }

	// -(BOOL)validateAndReturnError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateAndReturnError:")]
	bool ValidateAndReturnError ([NullAllowed] out NSError error);
}
}
