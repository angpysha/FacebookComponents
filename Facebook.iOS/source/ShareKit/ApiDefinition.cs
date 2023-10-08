using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Photos;
using Facebook.CoreKit;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Facebook.ShareKit {
	
// @interface FBSDKAppInviteContent : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKAppInviteContent
{
	// @property (copy, nonatomic) NSURL * _Nullable appInvitePreviewImageURL;
	[NullAllowed, Export ("appInvitePreviewImageURL", ArgumentSemantic.Copy)]
	NSUrl AppInvitePreviewImageURL { get; set; }

	// @property (copy, nonatomic) NSURL * _Nonnull appLinkURL;
	[Export ("appLinkURL", ArgumentSemantic.Copy)]
	NSUrl AppLinkURL { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable promotionCode;
	[NullAllowed, Export ("promotionCode")]
	string PromotionCode { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable promotionText;
	[NullAllowed, Export ("promotionText")]
	string PromotionText { get; set; }

	// @property (nonatomic) enum FBSDKAppInviteDestination destination;
	[Export ("destination", ArgumentSemantic.Assign)]
	FBSDKAppInviteDestination Destination { get; set; }

	// -(instancetype _Nonnull)initWithAppLinkURL:(NSURL * _Nonnull)appLinkURL __attribute__((objc_designated_initializer));
	[Export ("initWithAppLinkURL:")]
	[DesignatedInitializer]
	NativeHandle Constructor (NSUrl appLinkURL);
}

// @protocol FBSDKSharingValidatable
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKSharingValidatable
{
	// @required -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)options error:(NSError * _Nullable * _Nullable)error;
	[Abstract]
	[Export ("validateWithOptions:error:")]
	bool Error (FBSDKShareBridgeOptions options, [NullAllowed] out NSError error);
}

interface IFBSDKSharingValidatable {}

// @interface FBSDKShareKit_Swift_338 (FBSDKAppInviteContent) <FBSDKSharingValidatable>
// [Category]
// [BaseType (typeof(FBSDKAppInviteContent))]
// interface FBSDKAppInviteContent_FBSDKShareKit_Swift_338 : IFBSDKSharingValidatable
// {
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @interface FBSDKCameraEffectArguments : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKCameraEffectArguments
{
	// -(void)setString:(NSString * _Nullable)string forKey:(NSString * _Nonnull)key;
	[Export ("setString:forKey:")]
	void SetString ([NullAllowed] string @string, string key);

	// -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
	[Export ("stringForKey:")]
	[return: NullAllowed]
	string StringForKey (string key);

	// -(void)setArray:(NSArray<NSString *> * _Nullable)array forKey:(NSString * _Nonnull)key;
	[Export ("setArray:forKey:")]
	void SetArray ([NullAllowed] string[] array, string key);

	// -(NSArray<NSString *> * _Nullable)arrayForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
	[Export ("arrayForKey:")]
	[return: NullAllowed]
	string[] ArrayForKey (string key);
}

// @interface FBSDKCameraEffectTextures : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKCameraEffectTextures
{
	// -(void)setImage:(UIImage * _Nullable)image forKey:(NSString * _Nonnull)key;
	[Export ("setImage:forKey:")]
	void SetImage ([NullAllowed] UIImage image, string key);

	// -(UIImage * _Nullable)imageForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
	[Export ("imageForKey:")]
	[return: NullAllowed]
	UIImage ImageForKey (string key);
}

// @protocol FBSDKSharingButton
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKSharingButton
{
	// @required @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
	[Abstract]
	[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
	IFBSDKSharingContent ShareContent { get; set; }
}

interface IFBSDKSharingButton {}

// @interface FBSDKSendButton
interface FBSDKSendButton
{
	// @property (nonatomic, strong) FBSDKMessageDialog * _Nullable dialog;
	[NullAllowed, Export ("dialog", ArgumentSemantic.Strong)]
	FBSDKMessageDialog Dialog { get; set; }

	// @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
	[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
	IFBSDKSharingContent ShareContent { get; set; }

	// @property (readonly, copy, nonatomic) NSDictionary * _Nullable analyticsParameters;
	[NullAllowed, Export ("analyticsParameters", ArgumentSemantic.Copy)]
	NSDictionary AnalyticsParameters { get; }

	// @property (readonly, nonatomic) int impressionTrackingEventName;
	[Export ("impressionTrackingEventName")]
	int ImpressionTrackingEventName { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull impressionTrackingIdentifier;
	[Export ("impressionTrackingIdentifier")]
	string ImpressionTrackingIdentifier { get; }

	// @property (readonly, getter = isImplicitlyDisabled, nonatomic) BOOL implicitlyDisabled;
	[Export ("implicitlyDisabled")]
	bool ImplicitlyDisabled { [Bind ("isImplicitlyDisabled")] get; }

	// -(void)configureButton;
	[Export ("configureButton")]
	void ConfigureButton ();

	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	[Export ("initWithFrame:")]
	[DesignatedInitializer]
	NativeHandle Constructor (CGRect frame);

	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
	[Export ("initWithCoder:")]
	[DesignatedInitializer]
	NativeHandle Constructor (NSCoder coder);
}

// @interface FBSDKShareButton <FBSDKSharingButton>
interface FBSDKShareButton : IFBSDKSharingButton
{
	// @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
	[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
	IFBSDKSharingContent ShareContent { get; set; }

	// @property (readonly, copy, nonatomic) NSDictionary * _Nullable analyticsParameters;
	[NullAllowed, Export ("analyticsParameters", ArgumentSemantic.Copy)]
	NSDictionary AnalyticsParameters { get; }

	// @property (readonly, nonatomic) int impressionTrackingEventName;
	[Export ("impressionTrackingEventName")]
	int ImpressionTrackingEventName { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull impressionTrackingIdentifier;
	[Export ("impressionTrackingIdentifier")]
	string ImpressionTrackingIdentifier { get; }

	// @property (readonly, getter = isImplicitlyDisabled, nonatomic) BOOL implicitlyDisabled;
	[Export ("implicitlyDisabled")]
	bool ImplicitlyDisabled { [Bind ("isImplicitlyDisabled")] get; }

	// -(void)configureButton;
	[Export ("configureButton")]
	void ConfigureButton ();

	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	[Export ("initWithFrame:")]
	[DesignatedInitializer]
	NativeHandle Constructor (CGRect frame);

	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
	[Export ("initWithCoder:")]
	[DesignatedInitializer]
	NativeHandle Constructor (NSCoder coder);
}

// @interface FBSDKHashtag : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKHashtag
{
	// @property (copy, nonatomic) NSString * _Nonnull stringRepresentation;
	[Export ("stringRepresentation")]
	string StringRepresentation { get; set; }

	// -(instancetype _Nonnull)initWithString:(NSString * _Nonnull)string __attribute__((objc_designated_initializer));
	[Export ("initWithString:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string @string);

	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	[Export ("description")]
	string Description { get; }

	// @property (readonly, nonatomic) BOOL isValid;
	[Export ("isValid")]
	bool IsValid { get; }

	// @property (readonly, nonatomic) NSUInteger hash;
	[Export ("hash")]
	nuint Hash { get; }

	// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
	[Export ("isEqual:")]
	bool IsEqual ([NullAllowed] NSObject @object);
}

// @protocol FBSDKSharing
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKSharing
{
	[Wrap ("WeakDelegate"), Abstract]
	[NullAllowed]
	IFBSDKSharingDelegate Delegate { get; set; }

	// @required @property (nonatomic, weak) id<FBSDKSharingDelegate> _Nullable delegate;
	[Abstract]
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @required @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
	[Abstract]
	[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
	IFBSDKSharingContent ShareContent { get; set; }

	// @required @property (nonatomic) BOOL shouldFailOnDataError;
	[Abstract]
	[Export ("shouldFailOnDataError")]
	bool ShouldFailOnDataError { get; set; }

	// @required -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)error;
	[Abstract]
	[Export ("validateWithError:")]
	bool ValidateWithError ([NullAllowed] out NSError error);
}

interface IFBSDKSharing {}

// @protocol FBSDKSharingDialog <FBSDKSharing>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKSharingDialog : FBSDKSharing
{
	// @required @property (readonly, nonatomic) BOOL canShow;
	[Abstract]
	[Export ("canShow")]
	bool CanShow { get; }

	// @required -(BOOL)show;
	[Abstract]
	[Export ("show")]
	bool Show { get; }
}

interface IFBSDKSharingDialog {}

// @interface FBSDKMessageDialog : NSObject <FBSDKSharingDialog>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKMessageDialog : IFBSDKSharingDialog
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKSharingDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKSharingDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
	[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
	IFBSDKSharingContent ShareContent { get; set; }

	// @property (nonatomic) BOOL shouldFailOnDataError;
	[Export ("shouldFailOnDataError")]
	bool ShouldFailOnDataError { get; set; }

	// -(instancetype _Nonnull)initWithContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate;
	[Export ("initWithContent:delegate:")]
	NativeHandle Constructor ([NullAllowed] IFBSDKSharingContent content, [NullAllowed] IFBSDKSharingDelegate @delegate);

	// +(FBSDKMessageDialog * _Nonnull)dialogWithContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
	[Static]
	[Export ("dialogWithContent:delegate:")]
	FBSDKMessageDialog DialogWithContent ([NullAllowed] IFBSDKSharingContent content, [NullAllowed] IFBSDKSharingDelegate @delegate);

	// +(FBSDKMessageDialog * _Nonnull)showWithContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
	[Static]
	[Export ("showWithContent:delegate:")]
	FBSDKMessageDialog ShowWithContent ([NullAllowed] IFBSDKSharingContent content, [NullAllowed] IFBSDKSharingDelegate @delegate);

	// @property (readonly, nonatomic) BOOL canShow;
	[Export ("canShow")]
	bool CanShow { get; }

	// -(BOOL)show;
	[Export ("show")]
	bool Show { get; }

	// -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)error;
	[Export ("validateWithError:")]
	bool ValidateWithError ([NullAllowed] out NSError error);
}

// @interface FBSDKShareCameraEffectContent : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKShareCameraEffectContent
{
	// @property (copy, nonatomic) NSString * _Nonnull effectID;
	[Export ("effectID")]
	string EffectID { get; set; }

	// @property (nonatomic, strong) FBSDKCameraEffectArguments * _Nonnull effectArguments;
	[Export ("effectArguments", ArgumentSemantic.Strong)]
	FBSDKCameraEffectArguments EffectArguments { get; set; }

	// @property (nonatomic, strong) FBSDKCameraEffectTextures * _Nonnull effectTextures;
	[Export ("effectTextures", ArgumentSemantic.Strong)]
	FBSDKCameraEffectTextures EffectTextures { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable contentURL;
	[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
	NSUrl ContentURL { get; set; }

	// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
	[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
	FBSDKHashtag Hashtag { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
	[Export ("peopleIDs", ArgumentSemantic.Copy)]
	string[] PeopleIDs { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable placeID;
	[NullAllowed, Export ("placeID")]
	string PlaceID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable ref;
	[NullAllowed, Export ("ref")]
	string Ref { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable pageID;
	[NullAllowed, Export ("pageID")]
	string PageID { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
	[NullAllowed, Export ("shareUUID")]
	string ShareUUID { get; }
}

// @protocol FBSDKSharingContent <FBSDKSharingValidatable, NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/ 
	[Protocol]
[BaseType (typeof(NSObject))]
interface FBSDKSharingContent : FBSDKSharingValidatable
{
	// @required @property (copy, nonatomic) NSURL * _Nullable contentURL;
	[Abstract]
	[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
	NSUrl ContentURL { get; set; }

	// @required @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
	[Abstract]
	[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
	FBSDKHashtag Hashtag { get; set; }

	// @required @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
	[Abstract]
	[Export ("peopleIDs", ArgumentSemantic.Copy)]
	string[] PeopleIDs { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable placeID;
	[Abstract]
	[NullAllowed, Export ("placeID")]
	string PlaceID { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable ref;
	[Abstract]
	[NullAllowed, Export ("ref")]
	string Ref { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable pageID;
	[Abstract]
	[NullAllowed, Export ("pageID")]
	string PageID { get; set; }

	// @required @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
	[Abstract]
	[NullAllowed, Export ("shareUUID")]
	string ShareUUID { get; }

	// @required -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
	[Abstract]
	[Export ("addParameters:bridgeOptions:")]
	NSDictionary<NSString, NSObject> BridgeOptions (NSDictionary<NSString, NSObject> existingParameters, FBSDKShareBridgeOptions bridgeOptions);
}

interface IFBSDKSharingContent  {}

// @interface FBSDKShareKit_Swift_623 (FBSDKShareCameraEffectContent) <FBSDKSharingContent>
// [Category]
// [BaseType (typeof(FBSDKShareCameraEffectContent))]
// interface FBSDKShareCameraEffectContent_FBSDKShareKit_Swift_623 : IFBSDKSharingContent
// {
// 	// -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
// 	[Export ("addParameters:bridgeOptions:")]
// 	NSDictionary<NSString, NSObject> AddParameters (NSDictionary<NSString, NSObject> existingParameters, FBSDKShareBridgeOptions bridgeOptions);
//
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @interface FBSDKShareDialog : NSObject <FBSDKSharingDialog>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKShareDialog : IFBSDKSharingDialog
{
	// @property (nonatomic, weak) UIViewController * _Nullable fromViewController;
	[NullAllowed, Export ("fromViewController", ArgumentSemantic.Weak)]
	UIViewController FromViewController { get; set; }

	// @property (nonatomic) enum FBSDKShareDialogMode mode;
	[Export ("mode", ArgumentSemantic.Assign)]
	FBSDKShareDialogMode Mode { get; set; }

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	IFBSDKSharingDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<FBSDKSharingDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
	[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
	IFBSDKSharingContent ShareContent { get; set; }

	// @property (nonatomic) BOOL shouldFailOnDataError;
	[Export ("shouldFailOnDataError")]
	bool ShouldFailOnDataError { get; set; }

	// -(instancetype _Nonnull)initWithViewController:(UIViewController * _Nullable)viewController content:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
	[Export ("initWithViewController:content:delegate:")]
	[DesignatedInitializer]
	NativeHandle Constructor ([NullAllowed] UIViewController viewController, [NullAllowed] IFBSDKSharingContent content, [NullAllowed] IFBSDKSharingDelegate @delegate);

	// +(FBSDKShareDialog * _Nonnull)dialogWithViewController:(UIViewController * _Nullable)viewController withContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
	[Static]
	[Export ("dialogWithViewController:withContent:delegate:")]
	FBSDKShareDialog DialogWithViewController ([NullAllowed] UIViewController viewController, [NullAllowed] IFBSDKSharingContent content, [NullAllowed] IFBSDKSharingDelegate @delegate);

	// +(FBSDKShareDialog * _Nonnull)showFromViewController:(UIViewController * _Nullable)viewController withContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate;
	[Static]
	[Export ("showFromViewController:withContent:delegate:")]
	FBSDKShareDialog ShowFromViewController ([NullAllowed] UIViewController viewController, [NullAllowed] IFBSDKSharingContent content, [NullAllowed] IFBSDKSharingDelegate @delegate);
}

// @interface FBSDKShareKit_Swift_674 (FBSDKShareDialog)
[Category]
[BaseType (typeof(FBSDKShareDialog))]
interface FBSDKShareDialog_FBSDKShareKit_Swift_674
{
}

// @interface FBSDKShareKit_Swift_699 (FBSDKShareDialog)
[Category]
[BaseType (typeof(FBSDKShareDialog))]
interface FBSDKShareDialog_FBSDKShareKit_Swift_699
{
	// -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
	[Export ("webDialog:didCompleteWithResults:")]
	void WebDialog (FBSDKWebDialog webDialog, NSDictionary<NSString, NSObject> results);

	// -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didFailWithError:(NSError * _Nonnull)error;
	[Export ("webDialog:didFailWithError:")]
	void WebDialog (FBSDKWebDialog webDialog, NSError error);

	// -(void)webDialogDidCancel:(FBSDKWebDialog * _Nonnull)webDialog;
	[Export ("webDialogDidCancel:")]
	void WebDialogDidCancel (FBSDKWebDialog webDialog);
}

// @interface FBSDKShareKit_Swift_707 (FBSDKShareDialog)
// [Category]
// [BaseType (typeof(FBSDKShareDialog))]
// interface FBSDKShareDialog_FBSDKShareKit_Swift_707
// {
// 	// @property (readonly, nonatomic) BOOL canShow;
// 	[Export ("canShow")]
// 	bool CanShow { get; }
//
// 	// -(BOOL)show;
// 	[Export ("show")]
// 	bool Show { get; }
//
// 	// -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithError:")]
// 	bool ValidateWithError ([NullAllowed] out NSError error);
// }

// @interface FBSDKShareLinkContent : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKShareLinkContent
{
	// @property (copy, nonatomic) NSString * _Nullable quote;
	[NullAllowed, Export ("quote")]
	string Quote { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable contentURL;
	[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
	NSUrl ContentURL { get; set; }

	// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
	[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
	FBSDKHashtag Hashtag { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
	[Export ("peopleIDs", ArgumentSemantic.Copy)]
	string[] PeopleIDs { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable placeID;
	[NullAllowed, Export ("placeID")]
	string PlaceID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable ref;
	[NullAllowed, Export ("ref")]
	string Ref { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable pageID;
	[NullAllowed, Export ("pageID")]
	string PageID { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
	[NullAllowed, Export ("shareUUID")]
	string ShareUUID { get; }
}

// @interface FBSDKShareKit_Swift_756 (FBSDKShareLinkContent) <FBSDKSharingContent>
// [Category]
// [BaseType (typeof(FBSDKShareLinkContent))]
// interface FBSDKShareLinkContent_FBSDKShareKit_Swift_756 : IFBSDKSharingContent
// {
// 	// -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
// 	[Export ("addParameters:bridgeOptions:")]
// 	NSDictionary<NSString, NSObject> AddParameters (NSDictionary<NSString, NSObject> existingParameters, FBSDKShareBridgeOptions bridgeOptions);
// }

// @interface FBSDKShareKit_Swift_766 (FBSDKShareLinkContent) <FBSDKSharingValidatable>
// [Category]
// [BaseType (typeof(FBSDKShareLinkContent))]
// interface FBSDKShareLinkContent_FBSDKShareKit_Swift_766 : IFBSDKSharingValidatable
// {
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @protocol FBSDKShareMedia
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKShareMedia
{
}

interface IFBSDKShareMedia {}

// @interface FBSDKShareMediaContent : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKShareMediaContent
{
	// @property (copy, nonatomic) NSArray<id<FBSDKShareMedia>> * _Nonnull media;
	[Export ("media", ArgumentSemantic.Copy)]
	IFBSDKShareMedia[] Media { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable contentURL;
	[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
	NSUrl ContentURL { get; set; }

	// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
	[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
	FBSDKHashtag Hashtag { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
	[Export ("peopleIDs", ArgumentSemantic.Copy)]
	string[] PeopleIDs { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable placeID;
	[NullAllowed, Export ("placeID")]
	string PlaceID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable ref;
	[NullAllowed, Export ("ref")]
	string Ref { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable pageID;
	[NullAllowed, Export ("pageID")]
	string PageID { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
	[NullAllowed, Export ("shareUUID")]
	string ShareUUID { get; }
}

// @interface FBSDKShareKit_Swift_805 (FBSDKShareMediaContent) <FBSDKSharingValidatable>
// [Category]
// [BaseType (typeof(FBSDKShareMediaContent))]
// interface FBSDKShareMediaContent_FBSDKShareKit_Swift_805 : IFBSDKSharingValidatable
// {
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @interface FBSDKShareKit_Swift_811 (FBSDKShareMediaContent) <FBSDKSharingContent>
// [Category]
// [BaseType (typeof(FBSDKShareMediaContent))]
// interface FBSDKShareMediaContent_FBSDKShareKit_Swift_811 : IFBSDKSharingContent
// {
// 	// -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
// 	[Export ("addParameters:bridgeOptions:")]
// 	NSDictionary<NSString, NSObject> AddParameters (NSDictionary<NSString, NSObject> existingParameters, FBSDKShareBridgeOptions bridgeOptions);
// }

// @interface FBSDKSharePhoto : NSObject <FBSDKShareMedia>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKSharePhoto : IFBSDKShareMedia
{
	// @property (nonatomic, strong) UIImage * _Nullable image;
	[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
	UIImage Image { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable imageURL;
	[NullAllowed, Export ("imageURL", ArgumentSemantic.Copy)]
	NSUrl ImageURL { get; set; }

	// @property (nonatomic, strong) PHAsset * _Nullable photoAsset;
	[NullAllowed, Export ("photoAsset", ArgumentSemantic.Strong)]
	PHAsset PhotoAsset { get; set; }

	// @property (nonatomic) BOOL isUserGenerated;
	[Export ("isUserGenerated")]
	bool IsUserGenerated { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable caption;
	[NullAllowed, Export ("caption")]
	string Caption { get; set; }

	// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image isUserGenerated:(BOOL)isUserGenerated;
	[Export ("initWithImage:isUserGenerated:")]
	NativeHandle Constructor (UIImage image, bool isUserGenerated);

	// -(instancetype _Nonnull)initWithImageURL:(NSURL * _Nonnull)imageURL isUserGenerated:(BOOL)isUserGenerated;
	[Export ("initWithImageURL:isUserGenerated:")]
	NativeHandle Constructor (NSUrl imageURL, bool isUserGenerated);

	// -(instancetype _Nonnull)initWithPhotoAsset:(PHAsset * _Nonnull)photoAsset isUserGenerated:(BOOL)isUserGenerated;
	[Export ("initWithPhotoAsset:isUserGenerated:")]
	NativeHandle Constructor (PHAsset photoAsset, bool isUserGenerated);
}

// @interface FBSDKShareKit_Swift_867 (FBSDKSharePhoto) <FBSDKSharingValidatable>
// [Category]
// [BaseType (typeof(FBSDKSharePhoto))]
// interface FBSDKSharePhoto_FBSDKShareKit_Swift_867 : IFBSDKSharingValidatable
// {
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @interface FBSDKSharePhotoContent : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKSharePhotoContent
{
	// @property (copy, nonatomic) NSArray<FBSDKSharePhoto *> * _Nonnull photos;
	[Export ("photos", ArgumentSemantic.Copy)]
	FBSDKSharePhoto[] Photos { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable contentURL;
	[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
	NSUrl ContentURL { get; set; }

	// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
	[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
	FBSDKHashtag Hashtag { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
	[Export ("peopleIDs", ArgumentSemantic.Copy)]
	string[] PeopleIDs { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable placeID;
	[NullAllowed, Export ("placeID")]
	string PlaceID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable ref;
	[NullAllowed, Export ("ref")]
	string Ref { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable pageID;
	[NullAllowed, Export ("pageID")]
	string PageID { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
	[NullAllowed, Export ("shareUUID")]
	string ShareUUID { get; }
}

// @interface FBSDKShareKit_Swift_901 (FBSDKSharePhotoContent) <FBSDKSharingContent>
// [Category]
// [BaseType (typeof(FBSDKSharePhotoContent))]
// interface FBSDKSharePhotoContent_FBSDKShareKit_Swift_901 : IFBSDKSharingContent
// {
// 	// -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
// 	[Export ("addParameters:bridgeOptions:")]
// 	NSDictionary<NSString, NSObject> AddParameters (NSDictionary<NSString, NSObject> existingParameters, FBSDKShareBridgeOptions bridgeOptions);
// }

// @interface FBSDKShareKit_Swift_911 (FBSDKSharePhotoContent) <FBSDKSharingValidatable>
// [Category]
// [BaseType (typeof(FBSDKSharePhotoContent))]
// interface FBSDKSharePhotoContent_FBSDKShareKit_Swift_911 : IFBSDKSharingValidatable
// {
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @interface FBSDKShareVideo : NSObject <FBSDKShareMedia>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKShareVideo : IFBSDKShareMedia
{
	// @property (copy, nonatomic) NSData * _Nullable data;
	[NullAllowed, Export ("data", ArgumentSemantic.Copy)]
	NSData Data { get; set; }

	// @property (nonatomic, strong) PHAsset * _Nullable videoAsset;
	[NullAllowed, Export ("videoAsset", ArgumentSemantic.Strong)]
	PHAsset VideoAsset { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable videoURL;
	[NullAllowed, Export ("videoURL", ArgumentSemantic.Copy)]
	NSUrl VideoURL { get; set; }

	// @property (nonatomic, strong) FBSDKSharePhoto * _Nullable previewPhoto;
	[NullAllowed, Export ("previewPhoto", ArgumentSemantic.Strong)]
	FBSDKSharePhoto PreviewPhoto { get; set; }

	// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data previewPhoto:(FBSDKSharePhoto * _Nullable)previewPhoto;
	[Export ("initWithData:previewPhoto:")]
	NativeHandle Constructor (NSData data, [NullAllowed] FBSDKSharePhoto previewPhoto);

	// -(instancetype _Nonnull)initWithVideoAsset:(PHAsset * _Nonnull)videoAsset previewPhoto:(FBSDKSharePhoto * _Nullable)previewPhoto;
	[Export ("initWithVideoAsset:previewPhoto:")]
	NativeHandle Constructor (PHAsset videoAsset, [NullAllowed] FBSDKSharePhoto previewPhoto);

	// -(instancetype _Nonnull)initWithVideoURL:(NSURL * _Nonnull)videoURL previewPhoto:(FBSDKSharePhoto * _Nullable)previewPhoto;
	[Export ("initWithVideoURL:previewPhoto:")]
	NativeHandle Constructor (NSUrl videoURL, [NullAllowed] FBSDKSharePhoto previewPhoto);
}

// @interface FBSDKShareKit_Swift_954 (FBSDKShareVideo) <FBSDKSharingValidatable>
[Category]
[BaseType (typeof(FBSDKShareVideo))]
interface FBSDKShareVideo_FBSDKShareKit_Swift_954 : IFBSDKSharingValidatable
{
	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
	[Export ("validateWithOptions:error:")]
	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
}

// @interface FBSDKShareVideoContent : NSObject
[BaseType (typeof(NSObject))]
interface FBSDKShareVideoContent
{
	// @property (nonatomic, strong) FBSDKShareVideo * _Nonnull video;
	[Export ("video", ArgumentSemantic.Strong)]
	FBSDKShareVideo Video { get; set; }

	// @property (copy, nonatomic) NSURL * _Nullable contentURL;
	[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
	NSUrl ContentURL { get; set; }

	// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
	[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
	FBSDKHashtag Hashtag { get; set; }

	// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
	[Export ("peopleIDs", ArgumentSemantic.Copy)]
	string[] PeopleIDs { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable placeID;
	[NullAllowed, Export ("placeID")]
	string PlaceID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable ref;
	[NullAllowed, Export ("ref")]
	string Ref { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable pageID;
	[NullAllowed, Export ("pageID")]
	string PageID { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
	[NullAllowed, Export ("shareUUID")]
	string ShareUUID { get; }
}

// @interface FBSDKShareKit_Swift_988 (FBSDKShareVideoContent) <FBSDKSharingContent>
// [Category]
// [BaseType (typeof(FBSDKShareVideoContent))]
// interface FBSDKShareVideoContent_FBSDKShareKit_Swift_988 : IFBSDKSharingContent
// {
// 	// -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
// 	[Export ("addParameters:bridgeOptions:")]
// 	NSDictionary<NSString, NSObject> AddParameters (NSDictionary<NSString, NSObject> existingParameters, FBSDKShareBridgeOptions bridgeOptions);
// }

// @interface FBSDKShareKit_Swift_998 (FBSDKShareVideoContent) <FBSDKSharingValidatable>
// [Category]
// [BaseType (typeof(FBSDKShareVideoContent))]
// interface FBSDKShareVideoContent_FBSDKShareKit_Swift_998 : IFBSDKSharingValidatable
// {
// 	// -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)error;
// 	[Export ("validateWithOptions:error:")]
// 	bool ValidateWithOptions (FBSDKShareBridgeOptions bridgeOptions, [NullAllowed] out NSError error);
// }

// @protocol FBSDKSharingDelegate
[Protocol, Model]
interface FBSDKSharingDelegate
{
	// @required -(void)sharer:(id<FBSDKSharing> _Nonnull)sharer didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
	[Abstract]
	[Export ("sharer:didCompleteWithResults:")]
	void Sharer (IFBSDKSharing sharer, NSDictionary<NSString, NSObject> results);

	// @required -(void)sharer:(id<FBSDKSharing> _Nonnull)sharer didFailWithError:(NSError * _Nonnull)error;
	[Abstract]
	[Export ("sharer:didFailWithError:")]
	void Sharer (IFBSDKSharing sharer, NSError error);

	// @required -(void)sharerDidCancel:(id<FBSDKSharing> _Nonnull)sharer;
	[Abstract]
	[Export ("sharerDidCancel:")]
	void SharerDidCancel (IFBSDKSharing sharer);
}

interface IFBSDKSharingDelegate {}
}
