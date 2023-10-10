using System;
using System.Diagnostics.CodeAnalysis;
using Foundation;
using ObjCRuntime;
using StoreKit;
using UIKit;
using WebKit;
using CoreGraphics;
using CoreAnimation;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Facebook.CoreKit {

	#region FBSDKCoreKitBasics
	// @interface FBSDKBase64 : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKBase64 {
		// +(NSData * _Nullable)decodeAsData:(NSString * _Nullable)string;
		[Static]
		[Export ("decodeAsData:")]
		[return: NullAllowed]
		NSData DecodeAsData ([NullAllowed] string @string);

		// +(NSString * _Nullable)decodeAsString:(NSString * _Nullable)string;
		[Static]
		[Export ("decodeAsString:")]
		[return: NullAllowed]
		string DecodeAsString ([NullAllowed] string @string);

		// +(NSString * _Nullable)encodeString:(NSString * _Nullable)string;
		[Static]
		[Export ("encodeString:")]
		[return: NullAllowed]
		string EncodeString ([NullAllowed] string @string);

		// +(NSString * _Nonnull)base64FromBase64Url:(NSString * _Nonnull)base64Url;
		[Static]
		[Export ("base64FromBase64Url:")]
		string Base64FromBase64Url (string base64Url);
	}

	// typedef id _Nullable (^FBSDKInvalidObjectHandler)(id _Nonnull, BOOL * _Nonnull);
	delegate NSObject FBSDKInvalidObjectHandler ([NotNull] NSObject arg0, IntPtr arg1);

	// @interface FBSDKBasicUtility : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKBasicUtility {
		// +(NSString * _Nullable)JSONStringForObject:(id _Nonnull)object error:(NSError * _Nullable * _Nullable)errorRef invalidObjectHandler:(FBSDKInvalidObjectHandler _Nullable)invalidObjectHandler;
		[Static]
		[Export ("JSONStringForObject:error:invalidObjectHandler:")]
		[return: NullAllowed]
		string JSONStringForObject (NSObject @object, [NullAllowed] out NSError errorRef, [NullAllowed] FBSDKInvalidObjectHandler invalidObjectHandler);

		// +(BOOL)dictionary:(NSMutableDictionary<id,id> * _Nonnull)dictionary setJSONStringForObject:(id _Nonnull)object forKey:(id<NSCopying> _Nonnull)key error:(NSError * _Nullable * _Nullable)errorRef;
		[Static]
		[Export ("dictionary:setJSONStringForObject:forKey:error:")]
		bool Dictionary (NSMutableDictionary<NSObject, NSObject> dictionary, NSObject @object, NSCopying key, [NullAllowed] out NSError errorRef);

		// +(id _Nullable)objectForJSONString:(NSString * _Nonnull)string error:(NSError * _Nullable * _Nullable)errorRef;
		[Static]
		[Export ("objectForJSONString:error:")]
		[return: NullAllowed]
		NSObject ObjectForJSONString (string @string, [NullAllowed] out NSError errorRef);

		// +(NSString * _Nullable)queryStringWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary error:(NSError * _Nullable * _Nullable)errorRef invalidObjectHandler:(FBSDKInvalidObjectHandler _Nullable)invalidObjectHandler;
		[Static]
		[Export ("queryStringWithDictionary:error:invalidObjectHandler:")]
		[return: NullAllowed]
		string QueryStringWithDictionary (NSDictionary<NSString, NSObject> dictionary, [NullAllowed] out NSError errorRef, [NullAllowed] FBSDKInvalidObjectHandler invalidObjectHandler);

		// +(id _Nonnull)convertRequestValue:(id _Nonnull)value;
		[Static]
		[Export ("convertRequestValue:")]
		NSObject ConvertRequestValue (NSObject value);

		// +(NSString * _Nonnull)URLEncode:(NSString * _Nonnull)value;
		[Static]
		[Export ("URLEncode:")]
		string URLEncode (string value);

		// +(NSDictionary<NSString *,NSString *> * _Nonnull)dictionaryWithQueryString:(NSString * _Nonnull)queryString;
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary<NSString, NSString> DictionaryWithQueryString (string queryString);

		// +(NSString * _Nonnull)URLDecode:(NSString * _Nonnull)value;
		[Static]
		[Export ("URLDecode:")]
		string URLDecode (string value);

		// +(NSData * _Nullable)gzip:(NSData * _Nonnull)data;
		[Static]
		[Export ("gzip:")]
		[return: NullAllowed]
		NSData Gzip (NSData data);

		// +(NSString * _Nonnull)anonymousID;
		[Static]
		[Export ("anonymousID")]
		string AnonymousID { get; }

		// +(NSString * _Nonnull)persistenceFilePath:(NSString * _Nonnull)filename;
		[Static]
		[Export ("persistenceFilePath:")]
		string PersistenceFilePath (string filename);

		// +(NSString * _Nullable)SHA256Hash:(NSObject * _Nullable)input;
		[Static]
		[Export ("SHA256Hash:")]
		[return: NullAllowed]
		string SHA256Hash ([NullAllowed] NSObject input);
	}

	// @protocol FBSDKCrashHandler
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
	interface IFBSDKCrashHandler {
		// @required -(void)addObserver:(id<FBSDKCrashObserving> _Nonnull)observer;
		[Abstract]
		[Export ("addObserver:")]
		void AddObserver (IFBSDKCrashObserving observer);

		// @required -(void)clearCrashReportFiles;
		[Abstract]
		[Export ("clearCrashReportFiles")]
		void ClearCrashReportFiles ();

		// @required -(void)saveException:(NSException * _Nonnull)exception;
		[Abstract]
		[Export ("saveException:")]
		void SaveException (NSException exception);
	}

	interface IIFBSDKCrashHandler { }

	// @protocol FBSDKCrashObserving
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
	interface FBSDKCrashObserving {
		// @required @property (copy, nonatomic) NSArray<NSString *> * _Nonnull prefixes;
		[Abstract]
		[Export ("prefixes", ArgumentSemantic.Copy)]
		string [] Prefixes { get; set; }

		// @required @property (copy, nonatomic) NSArray<NSString *> * _Nullable frameworks;
		[Abstract]
		[NullAllowed, Export ("frameworks", ArgumentSemantic.Copy)]
		string [] Frameworks { get; set; }

		// @required -(void)didReceiveCrashLogs:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)crashLogs;
		[Abstract]
		[Export ("didReceiveCrashLogs:")]
		void DidReceiveCrashLogs (NSDictionary<NSString, NSObject> [] crashLogs);
	}

	interface IFBSDKCrashObserving { }

	// @interface FBSDKCrashHandler : NSObject <FBSDKCrashHandler>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKCrashHandler : IIFBSDKCrashHandler {
		// @property (readonly, nonatomic, class) FBSDKCrashHandler * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKCrashHandler Shared { get; }

		// +(void)disable;
		[Static]
		[Export ("disable")]
		void Disable ();

		// +(void)addObserver:(id<FBSDKCrashObserving> _Nonnull)observer;
		[Static]
		[Export ("addObserver:")]
		void AddObserver (IFBSDKCrashObserving observer);

		// +(void)removeObserver:(id<FBSDKCrashObserving> _Nonnull)observer;
		[Static]
		[Export ("removeObserver:")]
		void RemoveObserver (IFBSDKCrashObserving observer);

		// +(void)clearCrashReportFiles;
		[Static]
		[Export ("clearCrashReportFiles")]
		void ClearCrashReportFiles ();

		// +(NSString * _Nonnull)getFBSDKVersion;
		[Static]
		[Export ("getFBSDKVersion")]
		string FBSDKVersion { get; }

		// -(void)saveException:(NSException * _Nonnull)exception;
		[Export ("saveException:")]
		void SaveException (NSException exception);
	}

	// @protocol FBSDKDataPersisting
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
	interface FBSDKDataPersisting {
		// @required -(void)fb_setInteger:(NSInteger)integer forKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_setInteger:forKey:")]
		void Fb_setInteger (nint integer, string key);

		// @required -(void)fb_setObject:(id _Nonnull)object forKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_setObject:forKey:")]
		void Fb_setObject (NSObject @object, string key);

		// @required -(NSData * _Nullable)fb_dataForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_dataForKey:")]
		[return: NullAllowed]
		NSData Fb_dataForKey (string key);

		// @required -(NSInteger)fb_integerForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_integerForKey:")]
		nint Fb_integerForKey (string key);

		// @required -(NSString * _Nullable)fb_stringForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_stringForKey:")]
		[return: NullAllowed]
		string Fb_stringForKey (string key);

		// @required -(id _Nullable)fb_objectForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_objectForKey:")]
		[return: NullAllowed]
		NSObject Fb_objectForKey (string key);

		// @required -(BOOL)fb_boolForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_boolForKey:")]
		bool Fb_boolForKey (string key);

		// @required -(void)fb_setBool:(BOOL)value forKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_setBool:forKey:")]
		void Fb_setBool (bool value, string key);

		// @required -(void)fb_removeObjectForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("fb_removeObjectForKey:")]
		void Fb_removeObjectForKey (string key);
	}
	

	interface IFBSDKDataPersisting { }

	// @interface DataPersisting (NSUserDefaults) <FBSDKDataPersisting>
	[Category]
	[BaseType (typeof (NSUserDefaults))]
	interface NSUserDefaults_DataPersisting : IFBSDKDataPersisting {
	}

	// @protocol FBSDKFileDataExtracting
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
	interface FBSDKFileDataExtracting {
		// @required +(NSData * _Nullable)fb_dataWithContentsOfFile:(NSString * _Nonnull)path options:(NSDataReadingOptions)readOptionsMask error:(NSError * _Nullable * _Nullable)error;
		[Static, Abstract]
		[Export ("fb_dataWithContentsOfFile:options:error:")]
		[return: NullAllowed]
		NSData Options (string path, NSDataReadingOptions readOptionsMask, [NullAllowed] out NSError error);
	}

	interface IFBSDKFileDataExtracting { }

	// @interface FileDataExtracting (NSData) <FBSDKFileDataExtracting>
	[Category]
	[BaseType (typeof (NSData))]
	interface NSData_FileDataExtracting : IFBSDKFileDataExtracting {
	}

	// @protocol FBSDKFileManaging
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
	interface FBSDKFileManaging {
		// @required -(BOOL)fb_createDirectoryAtPath:(NSString * _Nonnull)path withIntermediateDirectories:(BOOL)createIntermediates attributes:(NSDictionary<NSFileAttributeKey,id> * _Nullable)attributes error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("fb_createDirectoryAtPath:withIntermediateDirectories:attributes:error:")]
		bool Fb_createDirectoryAtPath (string path, bool createIntermediates, [NullAllowed] NSDictionary<NSString, NSObject> attributes, [NullAllowed] out NSError error);

		// @required -(BOOL)fb_fileExistsAtPath:(NSString * _Nonnull)path;
		[Abstract]
		[Export ("fb_fileExistsAtPath:")]
		bool Fb_fileExistsAtPath (string path);

		// @required -(BOOL)fb_removeItemAtPath:(NSString * _Nonnull)path error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("fb_removeItemAtPath:error:")]
		bool Fb_removeItemAtPath (string path, [NullAllowed] out NSError error);

		// @required -(NSArray<NSString *> * _Nonnull)fb_contentsOfDirectoryAtPath:(NSString * _Nonnull)path error:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error")));
		[Abstract]
		[Export ("fb_contentsOfDirectoryAtPath:error:")]
		string [] Fb_contentsOfDirectoryAtPath (string path, [NullAllowed] out NSError error);
	}

	interface IFBSDKFileManaging { }

	// @interface FileManaging (NSFileManager) <FBSDKFileManaging>
	[Category]
	[BaseType (typeof (NSFileManager))]
	interface NSFileManager_FileManaging : IFBSDKFileManaging {
	}

	// @protocol FBSDKInfoDictionaryProviding
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
	interface FBSDKInfoDictionaryProviding {
		// @required @property (readonly, copy) NSDictionary<NSString *,id> * _Nullable fb_infoDictionary;
		[Abstract]
		[NullAllowed, Export ("fb_infoDictionary", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Fb_infoDictionary { get; }

		// @required @property (readonly, copy) NSString * _Nullable fb_bundleIdentifier;
		[Abstract]
		[NullAllowed, Export ("fb_bundleIdentifier")]
		string Fb_bundleIdentifier { get; }

		// @required -(id _Nullable)fb_objectForInfoDictionaryKey:(NSString * _Nonnull)key __attribute__((swift_name("fb_object(forInfoDictionaryKey:)")));
		[Abstract]
		[Export ("fb_objectForInfoDictionaryKey:")]
		[return: NullAllowed]
		NSObject Fb_objectForInfoDictionaryKey (string key);
	}

	interface IFBSDKInfoDictionaryProviding { }

	// @interface InfoDictionaryProviding (NSBundle) <FBSDKInfoDictionaryProviding>
	[Category]
	[BaseType (typeof (NSBundle))]
	interface NSBundle_InfoDictionaryProviding : IFBSDKInfoDictionaryProviding {
	}

	// @interface FBSDKLibAnalyzer : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKLibAnalyzer {
		// +(NSDictionary<NSString *,NSString *> * _Nonnull)getMethodsTable:(NSArray<NSString *> * _Nonnull)prefixes frameworks:(NSArray<NSString *> * _Nullable)frameworks;
		[Static]
		[Export ("getMethodsTable:frameworks:")]
		NSDictionary<NSString, NSString> GetMethodsTable (string [] prefixes, [NullAllowed] string [] frameworks);

		// +(NSArray<NSString *> * _Nullable)symbolicateCallstack:(NSArray<NSString *> * _Nonnull)callstack methodMapping:(NSDictionary<NSString *,id> * _Nonnull)methodMapping;
		[Static]
		[Export ("symbolicateCallstack:methodMapping:")]
		[return: NullAllowed]
		string [] SymbolicateCallstack (string [] callstack, NSDictionary<NSString, NSObject> methodMapping);
	}

	// @protocol FBSDKNetworkTask <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKNetworkTask {
		// @required @property (readonly) NSURLSessionTaskState fb_state;
		[Abstract]
		[Export ("fb_state")]
		NSUrlSessionTaskState Fb_state { get; }

		// @required -(void)fb_resume;
		[Abstract]
		[Export ("fb_resume")]
		void Fb_resume ();

		// @required -(void)fb_cancel;
		[Abstract]
		[Export ("fb_cancel")]
		void Fb_cancel ();
	}

	interface IFBSDKNetworkTask { }

	// @interface NetworkTask (NSURLSessionTask) <FBSDKNetworkTask>
	[Category]
	[BaseType (typeof (NSUrlSessionTask))]
	interface NSURLSessionTask_NetworkTask : IFBSDKNetworkTask {
	}

	// @interface FBSDKTypeUtility : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKTypeUtility {
		// +(NSArray<id> * _Nullable)arrayValue:(id _Nullable)object;
		[Static]
		[Export ("arrayValue:")]
		[return: NullAllowed]
		NSObject [] ArrayValue ([NullAllowed] NSObject @object);

		// +(id _Nullable)array:(NSArray<id> * _Nonnull)array objectAtIndex:(NSUInteger)index;
		[Static]
		[Export ("array:objectAtIndex:")]
		[return: NullAllowed]
		NSObject Array (NSObject [] array, nuint index);

		// +(void)array:(NSMutableArray * _Nonnull)array addObject:(id _Nullable)object;
		[Static]
		[Export ("array:addObject:")]
		void Array (NSMutableArray array, [NullAllowed] NSObject @object);

		// +(BOOL)boolValue:(id _Nonnull)object;
		[Static]
		[Export ("boolValue:")]
		bool BoolValue (NSObject @object);

		// +(NSDictionary<NSString *,id> * _Nullable)dictionaryValue:(id _Nullable)object;
		[Static]
		[Export ("dictionaryValue:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> DictionaryValue ([NullAllowed] NSObject @object);

		// +(id _Nullable)dictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary objectForKey:(NSString * _Nonnull)key ofType:(Class _Nonnull)type;
		[Static]
		[Export ("dictionary:objectForKey:ofType:")]
		[return: NullAllowed]
		NSObject Dictionary (NSDictionary<NSString, NSObject> dictionary, string key, Class type);

		// +(void)dictionary:(NSMutableDictionary * _Nonnull)dictionary setObject:(id _Nullable)object forKey:(id<NSCopying> _Nullable)key;
		[Static]
		[Export ("dictionary:setObject:forKey:")]
		void Dictionary (NSMutableDictionary dictionary, [NullAllowed] NSObject @object, [NullAllowed] NSCopying key);

		// +(void)dictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary enumerateKeysAndObjectsUsingBlock:(void (^ _Nonnull)(id _Nonnull, id _Nonnull, BOOL * _Nonnull))block;
		[Static]
		[Export ("dictionary:enumerateKeysAndObjectsUsingBlock:")]
		unsafe void Dictionary (NSDictionary<NSString, NSObject> dictionary, Action<NSObject, NSObject, bool> block);

		// +(NSInteger)integerValue:(id _Nonnull)object;
		[Static]
		[Export ("integerValue:")]
		nint IntegerValue (NSObject @object);

		// +(double)doubleValue:(id _Nonnull)object;
		[Static]
		[Export ("doubleValue:")]
		double DoubleValue (NSObject @object);

		// +(NSNumber * _Nonnull)numberValue:(id _Nonnull)object;
		[Static]
		[Export ("numberValue:")]
		NSNumber NumberValue (NSObject @object);

		// +(NSString * _Nonnull)stringValueOrNil:(id _Nonnull)object;
		[Static]
		[Export ("stringValueOrNil:")]
		string StringValueOrNil (NSObject @object);

		// +(id _Nullable)objectValue:(id _Nonnull)object;
		[Static]
		[Export ("objectValue:")]
		[return: NullAllowed]
		NSObject ObjectValue (NSObject @object);

		// +(NSString * _Nullable)coercedToStringValue:(id _Nonnull)object;
		[Static]
		[Export ("coercedToStringValue:")]
		[return: NullAllowed]
		string CoercedToStringValue (NSObject @object);

		// +(NSTimeInterval)timeIntervalValue:(id _Nonnull)object;
		[Static]
		[Export ("timeIntervalValue:")]
		double TimeIntervalValue (NSObject @object);

		// +(NSUInteger)unsignedIntegerValue:(id _Nonnull)object;
		[Static]
		[Export ("unsignedIntegerValue:")]
		nuint UnsignedIntegerValue (NSObject @object);

		// +(NSURL * _Nullable)coercedToURLValue:(id _Nonnull)object;
		[Static]
		[Export ("coercedToURLValue:")]
		[return: NullAllowed]
		NSUrl CoercedToURLValue (NSObject @object);

		// +(NSData * _Nullable)dataWithJSONObject:(id _Nonnull)obj options:(NSJSONWritingOptions)opt error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export ("dataWithJSONObject:options:error:")]
		[return: NullAllowed]
		NSData DataWithJSONObject (NSObject obj, NSJsonWritingOptions opt, [NullAllowed] out NSError error);

		// +(id _Nullable)JSONObjectWithData:(NSData * _Nonnull)data options:(NSJSONReadingOptions)opt error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export ("JSONObjectWithData:options:error:")]
		[return: NullAllowed]
		NSObject JSONObjectWithData (NSData data, NSJsonReadingOptions opt, [NullAllowed] out NSError error);
	}

	// @protocol FBSDKURLSessionProviding <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKURLSessionProviding {
		// @required -(id<FBSDKNetworkTask> _Nonnull)fb_dataTaskWithRequest:(NSURLRequest * _Nonnull)request completionHandler:(void (^ _Nonnull)(NSData * _Nullable, NSURLResponse * _Nullable, NSError * _Nullable))completionHandler;
		[Abstract]
		[Export ("fb_dataTaskWithRequest:completionHandler:")]
		FBSDKNetworkTask CompletionHandler (NSUrlRequest request, Action<NSData, NSUrlResponse, NSError> completionHandler);
	}

	interface IFBSDKURLSessionProviding { }

	// @interface URLSessionProviding (NSURLSession) <FBSDKURLSessionProviding>
	[Category]
	[BaseType (typeof (NSUrlSession))]
	interface NSURLSession_URLSessionProviding : IFBSDKURLSessionProviding {
	}

	// typedef void (^FBSDKURLSessionTaskBlock)(NSData * _Nullable, NSURLResponse * _Nullable, NSError * _Nullable);
	delegate void FBSDKURLSessionTaskBlock ([NullAllowed] NSData arg0, [NullAllowed] NSUrlResponse arg1, [NullAllowed] NSError arg2);

	// @interface FBSDKURLSessionTask : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKURLSessionTask {
		// @property (nonatomic, strong) id<FBSDKNetworkTask> _Nonnull task;
		[Export ("task", ArgumentSemantic.Strong)]
		FBSDKNetworkTask Task { get; set; }

		// @property (readonly, atomic) NSURLSessionTaskState state;
		[Export ("state")]
		NSUrlSessionTaskState State { get; }

		// @property (readonly, nonatomic, strong) NSDate * _Nonnull requestStartDate;
		[Export ("requestStartDate", ArgumentSemantic.Strong)]
		NSDate RequestStartDate { get; }

		// @property (copy, nonatomic) FBSDKURLSessionTaskBlock _Nullable handler;
		[NullAllowed, Export ("handler", ArgumentSemantic.Copy)]
		FBSDKURLSessionTaskBlock Handler { get; set; }

		// @property (assign, nonatomic) uint64_t requestStartTime;
		[Export ("requestStartTime")]
		ulong RequestStartTime { get; set; }

		// @property (assign, nonatomic) NSUInteger loggerSerialNumber;
		[Export ("loggerSerialNumber")]
		nuint LoggerSerialNumber { get; set; }

		// -(instancetype _Nullable)initWithRequest:(NSURLRequest * _Nonnull)request fromSession:(id<FBSDKURLSessionProviding> _Nonnull)session completionHandler:(FBSDKURLSessionTaskBlock _Nullable)handler;
		[Export ("initWithRequest:fromSession:completionHandler:")]
		IntPtr Constructor (NSUrlRequest request, FBSDKURLSessionProviding session, [NullAllowed] FBSDKURLSessionTaskBlock handler);

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();
	}

	// @interface FBSDKURLSession : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKURLSession {
		// @property (atomic, strong) NSURLSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		NSUrlSession Session { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		NSUrlSessionDataDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<NSURLSessionDataDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (retain, nonatomic) NSOperationQueue * _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Retain)]
		NSOperationQueue DelegateQueue { get; set; }

		// -(instancetype _Nonnull)initWithDelegate:(id<NSURLSessionDataDelegate> _Nonnull)delegate delegateQueue:(NSOperationQueue * _Nonnull)delegateQueue;
		[Export ("initWithDelegate:delegateQueue:")]
		IntPtr Constructor (NSUrlSessionDataDelegate @delegate, NSOperationQueue delegateQueue);

		// -(void)executeURLRequest:(NSURLRequest * _Nonnull)request completionHandler:(FBSDKURLSessionTaskBlock _Nonnull)handler;
		[Export ("executeURLRequest:completionHandler:")]
		void ExecuteURLRequest (NSUrlRequest request, FBSDKURLSessionTaskBlock handler);

		// -(void)updateSessionWithBlock:(dispatch_block_t _Nonnull)block;
		[Export ("updateSessionWithBlock:")]
		void UpdateSessionWithBlock (IntPtr block);

		// -(void)invalidateAndCancel;
		[Export ("invalidateAndCancel")]
		void InvalidateAndCancel ();

		// -(BOOL)valid;
		[Export ("valid")]
		bool Valid { get; }
	}

	// @protocol FBSDKNotificationDelivering
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
	interface FBSDKNotificationDelivering {
		// @required -(void)fb_addObserver:(id _Nonnull)observer selector:(SEL _Nonnull)selector name:(NSNotificationName _Nullable)name object:(id _Nullable)object;
		[Abstract]
		[Export ("fb_addObserver:selector:name:object:")]
		void Fb_addObserver (NSObject observer, Selector selector, [NullAllowed] string name, [NullAllowed] NSObject @object);

		// @required -(id<NSObject> _Nonnull)fb_addObserverForName:(NSNotificationName _Nullable)name object:(id _Nullable)obj queue:(NSOperationQueue * _Nullable)queue usingBlock:(void (^ _Nonnull)(NSNotification * _Nonnull))block;
		[Abstract]
		[Export ("fb_addObserverForName:object:queue:usingBlock:")]
		NSObject Fb_addObserverForName ([NullAllowed] string name, [NullAllowed] NSObject obj, [NullAllowed] NSOperationQueue queue, Action<NSNotification> block);

		// @required -(void)fb_removeObserver:(id _Nonnull)observer;
		[Abstract]
		[Export ("fb_removeObserver:")]
		void Fb_removeObserver (NSObject observer);
	}

	interface IFBSDKNotificationDelivering { }

	// @interface NotificationDelivering (NSNotificationCenter) <FBSDKNotificationDelivering>
	[Category]
	[BaseType (typeof (NSNotificationCenter))]
	interface NSNotificationCenter_NotificationDelivering : IFBSDKNotificationDelivering {
	}

	#endregion

	#region FBAEMKit
	// @protocol FBAEMNetworking
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
	interface FBAEMNetworking {
		// @required -(void)startGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters tokenString:(NSString * _Nullable)tokenString HTTPMethod:(NSString * _Nullable)method completion:(void (^ _Nonnull)(id _Nullable, NSError * _Nullable))completion;
		[Abstract]
		[Export ("startGraphRequestWithGraphPath:parameters:tokenString:HTTPMethod:completion:")]
		void Parameters (string graphPath, NSDictionary<NSString, NSObject> parameters, [NullAllowed] string tokenString, [NullAllowed] string method, Action<NSObject, NSError> completion);
	}

	interface IFBAEMNetworking { }

	// @interface FBAEMReporter : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBAEMReporter {
		// +(void)configureWithNetworker:(id<FBAEMNetworking> _Nullable)networker appID:(NSString * _Nullable)appID reporter:(id<FBSKAdNetworkReporting> _Nullable)reporter;
		[Static]
		[Export ("configureWithNetworker:appID:reporter:")]
		void ConfigureWithNetworker ([NullAllowed] IFBAEMNetworking networker, [NullAllowed] string appID, [NullAllowed] IFBSKAdNetworkReporting reporter);

		// +(void)configureWithNetworker:(id<FBAEMNetworking> _Nullable)networker appID:(NSString * _Nullable)appID reporter:(id<FBSKAdNetworkReporting> _Nullable)reporter analyticsAppID:(NSString * _Nullable)analyticsAppID store:(id<FBSDKDataPersisting> _Nullable)store;
		[Static]
		[Export ("configureWithNetworker:appID:reporter:analyticsAppID:store:")]
		void ConfigureWithNetworker ([NullAllowed] IFBAEMNetworking networker, [NullAllowed] string appID, [NullAllowed] IFBSKAdNetworkReporting reporter, [NullAllowed] string analyticsAppID, [NullAllowed] IFBSDKDataPersisting store);

		// +(void)enable;
		[Static]
		[Export ("enable")]
		void Enable ();

		// +(void)setConversionFilteringEnabled:(BOOL)enabled;
		[Static]
		[Export ("setConversionFilteringEnabled:")]
		void SetConversionFilteringEnabled (bool enabled);

		// +(void)setCatalogMatchingEnabled:(BOOL)enabled;
		[Static]
		[Export ("setCatalogMatchingEnabled:")]
		void SetCatalogMatchingEnabled (bool enabled);

		// +(void)setAdvertiserRuleMatchInServerEnabled:(BOOL)enabled;
		[Static]
		[Export ("setAdvertiserRuleMatchInServerEnabled:")]
		void SetAdvertiserRuleMatchInServerEnabled (bool enabled);

		// +(void)handle:(NSURL * _Nullable)url;
		[Static]
		[Export ("handle:")]
		void Handle ([NullAllowed] NSUrl url);

		// +(void)recordAndUpdateEvent:(NSString * _Nonnull)event currency:(NSString * _Nullable)currency value:(NSNumber * _Nullable)value parameters:(NSDictionary<NSString *,id> * _Nullable)parameters;
		[Static]
		[Export ("recordAndUpdateEvent:currency:value:parameters:")]
		void RecordAndUpdateEvent (string @event, [NullAllowed] string currency, [NullAllowed] NSNumber value, [NullAllowed] NSDictionary<NSString, NSObject> parameters);
	}

	// @protocol FBSKAdNetworkReporting
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
	interface FBSKAdNetworkReporting {
		// @required -(BOOL)shouldCutoff __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("shouldCutoff")]
		bool ShouldCutoff { get; }

		// @required -(BOOL)isReportingEvent:(NSString * _Nonnull)event __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("isReportingEvent:")]
		bool IsReportingEvent (string @event);

		// @required -(void)checkAndRevokeTimer;
		[Abstract]
		[Export ("checkAndRevokeTimer")]
		void CheckAndRevokeTimer ();
	}

	interface IFBSKAdNetworkReporting { }
	#endregion

	#region FBSDKCoreKit
	// @protocol FBSDKLogging
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
	interface FBSDKLogging {
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull contents;
		[Abstract]
		[Export ("contents")]
		string Contents { get; }

		// @required @property (readonly, copy, nonatomic) FBSDKLoggingBehavior _Nonnull loggingBehavior;
		[Abstract]
		[Export ("loggingBehavior")]
		string LoggingBehavior { get; }

		// @required -(instancetype _Nonnull)initWithLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
		[Abstract]
		[Export ("initWithLoggingBehavior:")]
		NativeHandle Constructor (string loggingBehavior);

		// @required +(void)singleShotLogEntry:(FBSDKLoggingBehavior _Nonnull)loggingBehavior logEntry:(NSString * _Nonnull)logEntry;
		[Static, Abstract]
		[Export ("singleShotLogEntry:logEntry:")]
		void SingleShotLogEntry (string loggingBehavior, string logEntry);

		// @required -(void)logEntry:(NSString * _Nonnull)logEntry;
		[Abstract]
		[Export ("logEntry:")]
		void LogEntry (string logEntry);
	}

	interface IFBSDKLogging { }

	// @protocol __FBSDKLoggerCreating
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
	interface __FBSDKLoggerCreating {
		// @required -(id<FBSDKLogging> _Nonnull)createLoggerWithLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
		[Abstract]
		[Export ("createLoggerWithLoggingBehavior:")]
		IFBSDKLogging CreateLoggerWithLoggingBehavior (string loggingBehavior);
	}
	
	interface I__FBSDKLoggerCreating {}

	// @protocol _FBSDKNotificationPosting
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
	interface _FBSDKNotificationPosting {
		// @required -(void)fb_postNotificationName:(NSNotificationName _Nonnull)name object:(id _Nullable)object userInfo:(NSDictionary<NSString *,id> * _Nullable)userInfo __attribute__((swift_name("fb_post(name:object:userInfo:)")));
		[Abstract]
		[Export ("fb_postNotificationName:object:userInfo:")]
		void Object (string name, [NullAllowed] NSObject @object, [NullAllowed] NSDictionary<NSString, NSObject> userInfo);
	}
	
	interface I_FBSDKNotificationPosting {}

	// @protocol _FBSDKWindowFinding
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
	interface _FBSDKWindowFinding {
		// @required -(UIWindow * _Nullable)findWindow;
		[Abstract]
		[NullAllowed, Export ("findWindow")]
		UIWindow FindWindow { get; }
	}

	// @protocol FBSDKAccessTokenProviding
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
	interface FBSDKAccessTokenProviding {
		// @required @property (copy, nonatomic, class) NS_SWIFT_NAME(current) FBSDKAccessToken * currentAccessToken __attribute__((swift_name("current")));
		[Static, Abstract]
		[Export ("currentAccessToken", ArgumentSemantic.Copy)]
		FBSDKAccessToken CurrentAccessToken { get; set; }

		// @required @property (copy, nonatomic, class) id<FBSDKTokenCaching> _Nullable tokenCache;
		[Static, Abstract]
		[NullAllowed, Export ("tokenCache", ArgumentSemantic.Copy)]
		IFBSDKTokenCaching TokenCache { get; set; }
	}

	// @protocol FBSDKTokenStringProviding
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
	interface FBSDKTokenStringProviding {
		// @required @property (readonly, copy, nonatomic, class) NSString * _Nullable tokenString;
		[Static, Abstract]
		[NullAllowed, Export ("tokenString")]
		string TokenString { get; }
	}

	// typedef void (^FBSDKGraphRequestCompletion)(id<FBSDKGraphRequestConnecting> _Nullable, id _Nullable, NSError * _Nullable);
	delegate void FBSDKGraphRequestCompletion ([NullAllowed] IFBSDKGraphRequestConnecting arg0, [NullAllowed] NSObject arg1, [NullAllowed] NSError arg2);

	// @protocol FBSDKGraphRequestConnecting
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
	interface FBSDKGraphRequestConnecting {
		// @required @property (assign, nonatomic) NSTimeInterval timeout;
		[Abstract]
		[Export ("timeout")]
		double Timeout { get; set; }

		[Wrap ("WeakDelegate"), Abstract]
		[NullAllowed]
		FBSDKGraphRequestConnectionDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<FBSDKGraphRequestConnectionDelegate> _Nullable delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required -(void)addRequest:(id<FBSDKGraphRequest> _Nonnull)request completion:(FBSDKGraphRequestCompletion _Nonnull)handler;
		[Abstract]
		[Export ("addRequest:completion:")]
		void AddRequest (IFBSDKGraphRequestProtocol request, FBSDKGraphRequestCompletion handler);

		// @required -(void)start;
		[Abstract]
		[Export ("start")]
		void Start ();

		// @required -(void)cancel;
		[Abstract]
		[Export ("cancel")]
		void Cancel ();

		// @required @property (readonly, nonatomic) NSMutableArray<FBSDKGraphRequestMetadata *> * _Nonnull requests;
		[Abstract]
		[Export ("requests")]
		NSMutableArray<FBSDKGraphRequestMetadata> Requests { get; }
	}

	interface IFBSDKGraphRequestConnecting {
	}

	// @protocol FBSDKGraphRequestConnectionDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface FBSDKGraphRequestConnectionDelegate {
		// @optional -(void)requestConnectionWillBeginLoading:(id<FBSDKGraphRequestConnecting> _Nonnull)connection;
		[Export ("requestConnectionWillBeginLoading:")]
		void RequestConnectionWillBeginLoading (IFBSDKGraphRequestConnecting connection);

		// @optional -(void)requestConnectionDidFinishLoading:(id<FBSDKGraphRequestConnecting> _Nonnull)connection;
		[Export ("requestConnectionDidFinishLoading:")]
		void RequestConnectionDidFinishLoading (IFBSDKGraphRequestConnecting connection);

		// @optional -(void)requestConnection:(id<FBSDKGraphRequestConnecting> _Nonnull)connection didFailWithError:(NSError * _Nonnull)error;
		[Export ("requestConnection:didFailWithError:")]
		void RequestConnection (IFBSDKGraphRequestConnecting connection, NSError error);

		// @optional -(void)requestConnection:(id<FBSDKGraphRequestConnecting> _Nonnull)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
		[Export ("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
		void RequestConnection (IFBSDKGraphRequestConnecting connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
	}

	// @interface FBSDKGraphRequestConnection : NSObject <FBSDKGraphRequestConnecting>
	[BaseType (typeof (NSObject))]
	interface FBSDKGraphRequestConnection : IFBSDKGraphRequestConnecting {
		// @property (assign, nonatomic, class) NSTimeInterval defaultConnectionTimeout;
		[Static]
		[Export ("defaultConnectionTimeout")]
		double DefaultConnectionTimeout { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		FBSDKGraphRequestConnectionDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<FBSDKGraphRequestConnectionDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; set; }

		// @property (readonly, retain, nonatomic) NSHTTPURLResponse * _Nullable urlResponse;
		[NullAllowed, Export ("urlResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		// @property (nonatomic) NSOperationQueue * _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Assign)]
		NSOperationQueue DelegateQueue { get; set; }

		// -(void)addRequest:(id<FBSDKGraphRequest> _Nonnull)request completion:(FBSDKGraphRequestCompletion _Nonnull)completion;
		[Export ("addRequest:completion:")]
		void AddRequest (IFBSDKGraphRequestProtocol request, FBSDKGraphRequestCompletion completion);

		// -(void)addRequest:(id<FBSDKGraphRequest> _Nonnull)request name:(NSString * _Nonnull)name completion:(FBSDKGraphRequestCompletion _Nonnull)completion;
		[Export ("addRequest:name:completion:")]
		void AddRequest (IFBSDKGraphRequestProtocol request, string name, FBSDKGraphRequestCompletion completion);

		// -(void)addRequest:(id<FBSDKGraphRequest> _Nonnull)request parameters:(NSDictionary<NSString *,id> * _Nullable)parameters completion:(FBSDKGraphRequestCompletion _Nonnull)completion;
		[Export ("addRequest:parameters:completion:")]
		void AddRequest (IFBSDKGraphRequestProtocol request, [NullAllowed] NSDictionary<NSString, NSObject> parameters, FBSDKGraphRequestCompletion completion);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)overrideGraphAPIVersion:(NSString * _Nonnull)version;
		[Export ("overrideGraphAPIVersion:")]
		void OverrideGraphAPIVersion (string version);

		// +(void)setCanMakeRequests;
		[Static]
		[Export ("setCanMakeRequests")]
		void SetCanMakeRequests ();

		// +(void)configureWithURLSessionProxyFactory:(id<FBSDKURLSessionProxyProviding> _Nonnull)proxyFactory errorConfigurationProvider:(id<FBSDKErrorConfigurationProviding> _Nonnull)errorConfigurationProvider piggybackManager:(id<FBSDKGraphRequestPiggybackManaging> _Nonnull)piggybackManager settings:(id<FBSDKSettings> _Nonnull)settings graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)factory eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger operatingSystemVersionComparer:(id<FBSDKOperatingSystemVersionComparing> _Nonnull)operatingSystemVersionComparer macCatalystDeterminator:(id<FBSDKMacCatalystDetermining> _Nonnull)macCatalystDeterminator accessTokenProvider:(Class<FBSDKAccessTokenProviding> _Nonnull)accessTokenProvider errorFactory:(id<FBSDKErrorCreating> _Nonnull)errorFactory authenticationTokenProvider:(Class<FBSDKAuthenticationTokenProviding> _Nonnull)authenticationTokenProvider __attribute__((swift_name("configure(urlSessionProxyFactory:errorConfigurationProvider:piggybackManager:settings:graphRequestConnectionFactory:eventLogger:operatingSystemVersionComparer:macCatalystDeterminator:accessTokenProvider:errorFactory:authenticationTokenProvider:)")));
		[Static]
		[Export ("configureWithURLSessionProxyFactory:errorConfigurationProvider:piggybackManager:settings:graphRequestConnectionFactory:eventLogger:operatingSystemVersionComparer:macCatalystDeterminator:accessTokenProvider:errorFactory:authenticationTokenProvider:")]
		void ConfigureWithURLSessionProxyFactory (IFBSDKURLSessionProxyProviding proxyFactory, IFBSDKErrorConfigurationProviding errorConfigurationProvider, IFBSDKGraphRequestPiggybackManaging piggybackManager, IFBSDKSettings settings, IFBSDKGraphRequestConnectionFactory factory, IFBSDKEventLogging eventLogger, IFBSDKOperatingSystemVersionComparing operatingSystemVersionComparer, IFBSDKMacCatalystDetermining macCatalystDeterminator, IFBSDKAccessTokenProviding accessTokenProvider, IFBSDKErrorCreating errorFactory, IFBSDKAuthenticationTokenProviding authenticationTokenProvider);
	}


	// @protocol FBSDKTokenCaching
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
	interface FBSDKTokenCaching {
		// @required @property (copy, nonatomic) FBSDKAccessToken * _Nullable accessToken;
		[Abstract]
		[NullAllowed, Export ("accessToken", ArgumentSemantic.Copy)]
		FBSDKAccessToken AccessToken { get; set; }

		// @required @property (copy, nonatomic) FBSDKAuthenticationToken * _Nullable authenticationToken;
		[Abstract]
		[NullAllowed, Export ("authenticationToken", ArgumentSemantic.Copy)]
		FBSDKAuthenticationToken AuthenticationToken { get; set; }
	}
	
	interface IFBSDKTokenCaching {}

	interface IFBSDKAccessTokenProviding {
		
	}
	
	interface IFBSDKTokenStringProviding {}
	// @interface FBSDKAccessToken : NSObject <NSCopying, NSObject, NSSecureCoding, FBSDKAccessTokenProviding, FBSDKTokenStringProviding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAccessToken : INSCopying, INSSecureCoding, IFBSDKAccessTokenProviding, IFBSDKTokenStringProviding {
		// @property (copy, nonatomic, class) NS_SWIFT_NAME(current) FBSDKAccessToken * currentAccessToken __attribute__((swift_name("current")));
		[Static]
		[Export ("currentAccessToken", ArgumentSemantic.Copy)]
		FBSDKAccessToken CurrentAccessToken { get; set; }

		// @property (readonly, getter = isCurrentAccessTokenActive, assign, nonatomic, class) BOOL currentAccessTokenIsActive;
		[Static]
		[Export ("currentAccessTokenIsActive")]
		bool CurrentAccessTokenIsActive { [Bind ("isCurrentAccessTokenActive")] get; }

		// @property (copy, nonatomic, class) id<FBSDKTokenCaching> _Nullable tokenCache;
		[Static]
		[NullAllowed, Export ("tokenCache", ArgumentSemantic.Copy)]
		IFBSDKTokenCaching TokenCache { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appID;
		[Export ("appID")]
		string AppID { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull dataAccessExpirationDate;
		[Export ("dataAccessExpirationDate", ArgumentSemantic.Copy)]
		NSDate DataAccessExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * declinedPermissions __attribute__((swift_private));
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet<NSString> DeclinedPermissions { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * expiredPermissions __attribute__((swift_private));
		[Export ("expiredPermissions", ArgumentSemantic.Copy)]
		NSSet<NSString> ExpiredPermissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * permissions __attribute__((swift_private));
		[Export ("permissions", ArgumentSemantic.Copy)]
		NSSet<NSString> Permissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull refreshDate;
		[Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
		[Export ("tokenString")]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
		[Export ("userID")]
		string UserID { get; }

		// @property (readonly, getter = isExpired, assign, nonatomic) BOOL expired;
		[Export ("expired")]
		bool Expired { [Bind ("isExpired")] get; }

		// @property (readonly, getter = isDataAccessExpired, assign, nonatomic) BOOL dataAccessExpired;
		[Export ("dataAccessExpired")]
		bool DataAccessExpired { [Bind ("isDataAccessExpired")] get; }

		// -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString permissions:(NSArray<NSString *> * _Nonnull)permissions declinedPermissions:(NSArray<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSArray<NSString *> * _Nonnull)expiredPermissions appID:(NSString * _Nonnull)appID userID:(NSString * _Nonnull)userID expirationDate:(NSDate * _Nullable)expirationDate refreshDate:(NSDate * _Nullable)refreshDate dataAccessExpirationDate:(NSDate * _Nullable)dataAccessExpirationDate __attribute__((objc_designated_initializer));
		[Export ("initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string tokenString, string [] permissions, string [] declinedPermissions, string [] expiredPermissions, string appID, string userID, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate);

		// -(BOOL)hasGranted:(NSString * _Nonnull)permission __attribute__((swift_name("hasGranted(permission:)")));
		[Export ("hasGranted:")]
		bool HasGranted (string permission);

		// -(BOOL)isEqualToAccessToken:(FBSDKAccessToken * _Nonnull)token;
		[Export ("isEqualToAccessToken:")]
		bool IsEqualToAccessToken (FBSDKAccessToken token);

		// +(void)refreshCurrentAccessTokenWithCompletion:(FBSDKGraphRequestCompletion _Nullable)completion;
		[Static]
		[Export ("refreshCurrentAccessTokenWithCompletion:")]
		void RefreshCurrentAccessTokenWithCompletion ([NullAllowed] FBSDKGraphRequestCompletion completion);

		// +(void)configureWithTokenCache:(id<FBSDKTokenCaching> _Nonnull)tokenCache graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)graphRequestConnectionFactory graphRequestPiggybackManager:(id<FBSDKGraphRequestPiggybackManaging> _Nonnull)graphRequestPiggybackManager errorFactory:(id<FBSDKErrorCreating> _Nonnull)errorFactory __attribute__((swift_name("configure(tokenCache:graphRequestConnectionFactory:graphRequestPiggybackManager:errorFactory:)")));
		[Static]
		[Export ("configureWithTokenCache:graphRequestConnectionFactory:graphRequestPiggybackManager:errorFactory:")]
		void ConfigureWithTokenCache (IFBSDKTokenCaching tokenCache, IFBSDKGraphRequestConnectionFactory graphRequestConnectionFactory, IFBSDKGraphRequestPiggybackManaging graphRequestPiggybackManager, IFBSDKErrorCreating errorFactory);
	}

	// @protocol FBSDKAdvertiserIDProviding
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
	interface FBSDKAdvertiserIDProviding {
		// @required @property (readonly, copy, nonatomic) NSString * _Nullable advertiserID;
		[Abstract]
		[NullAllowed, Export ("advertiserID")]
		string AdvertiserID { get; }
	}

	interface IFBSDKAdvertiserIDProviding { }

	// @protocol FBSDKAutoSetup
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
	interface FBSDKAutoSetup {
		// @required -(void)configureWithSwizzler:(Class<FBSDKSwizzling> _Nonnull)swizzler aemReporter:(Class<FBSDKAEMReporter> _Nonnull)aemReporter eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger crashHandler:(id<FBSDKCrashHandler> _Nonnull)crashHandler featureChecker:(id<FBSDKFeatureDisabling> _Nonnull)featureChecker appEventsUtility:(id<FBSDKAppEventsUtility> _Nonnull)appEventsUtility __attribute__((swift_name("configure(swizzler:reporter:eventLogger:crashHandler:featureChecker:appEventsUtility:)")));
		[Abstract]
		[Export ("configureWithSwizzler:aemReporter:eventLogger:crashHandler:featureChecker:appEventsUtility:")]
		void ConfigureWithSwizzler (IFBSDKSwizzling swizzler, FBAEMReporter aemReporter, IFBSDKEventLogging eventLogger, FBSDKCrashHandler crashHandler, IFBSDKFeatureDisabling featureChecker, IFBSDKAppEventsUtility appEventsUtility);

		// @required -(void)enableAutoSetup:(BOOL)proxyEnabled;
		[Abstract]
		[Export ("enableAutoSetup:")]
		void EnableAutoSetup (bool proxyEnabled);

		// @required -(void)logAutoSetupStatus:(BOOL)optin source:(NSString * _Nonnull)source;
		[Abstract]
		[Export ("logAutoSetupStatus:source:")]
		void LogAutoSetupStatus (bool optin, string source);
	}
	
	interface IFBSDKAutoSetup{}

	// @interface FBSDKAEMManager : NSObject <FBSDKAutoSetup>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAEMManager : IFBSDKAutoSetup {
		// @property (readonly, nonatomic, strong, class) FBSDKAEMManager * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		FBSDKAEMManager Shared { get; }

		// -(void)configureWithSwizzler:(Class<FBSDKSwizzling> _Nonnull)swizzler aemReporter:(Class<FBSDKAEMReporter> _Nonnull)aemReporter eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger crashHandler:(id<FBSDKCrashHandler> _Nonnull)crashHandler featureChecker:(id<FBSDKFeatureDisabling> _Nonnull)featureChecker appEventsUtility:(id<FBSDKAppEventsUtility> _Nonnull)appEventsUtility __attribute__((swift_name("configure(swizzler:reporter:eventLogger:crashHandler:featureChecker:appEventsUtility:)")));
		[Export ("configureWithSwizzler:aemReporter:eventLogger:crashHandler:featureChecker:appEventsUtility:")]
		void ConfigureWithSwizzler (IFBSDKSwizzling swizzler, FBAEMReporter aemReporter, IFBSDKEventLogging eventLogger, FBSDKCrashHandler crashHandler, IFBSDKFeatureDisabling featureChecker, IFBSDKAppEventsUtility appEventsUtility);

		// -(void)enableAutoSetup:(BOOL)proxyEnabled;
		[Export ("enableAutoSetup:")]
		void EnableAutoSetup (bool proxyEnabled);

		// -(void)logAutoSetupStatus:(BOOL)optin source:(NSString * _Nonnull)source;
		[Export ("logAutoSetupStatus:source:")]
		void LogAutoSetupStatus (bool optin, string source);
	}

	// @protocol FBSDKAppAvailabilityChecker
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
	interface FBSDKAppAvailabilityChecker {
		// @required @property (readonly, assign, nonatomic) BOOL isMessengerAppInstalled;
		[Abstract]
		[Export ("isMessengerAppInstalled")]
		bool IsMessengerAppInstalled { get; }

		// @required @property (readonly, assign, nonatomic) BOOL isFacebookAppInstalled;
		[Abstract]
		[Export ("isFacebookAppInstalled")]
		bool IsFacebookAppInstalled { get; }
	}

	// @protocol FBSDKAppEventDropDetermining
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
	interface FBSDKAppEventDropDetermining {
		// @required @property (readonly, nonatomic) BOOL shouldDropAppEvents;
		[Abstract]
		[Export ("shouldDropAppEvents")]
		bool ShouldDropAppEvents { get; }
	}
	
	interface IFBSDKAppEventDropDetermining  {}
	// @protocol FBSDKAppEventsConfiguring
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
	interface FBSDKAppEventsConfiguring {
		// @required -(void)configureWithGateKeeperManager:(Class<FBSDKGateKeeperManaging> _Nonnull)gateKeeperManager appEventsConfigurationProvider:(id<FBSDKAppEventsConfigurationProviding> _Nonnull)appEventsConfigurationProvider serverConfigurationProvider:(id<FBSDKServerConfigurationProviding> _Nonnull)serverConfigurationProvider graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory featureChecker:(id<FBSDKFeatureChecking> _Nonnull)featureChecker primaryDataStore:(id<FBSDKDataPersisting> _Nonnull)primaryDataStore logger:(Class<FBSDKLogging> _Nonnull)logger settings:(id<FBSDKSettings> _Nonnull)settings paymentObserver:(id<FBSDKPaymentObserving> _Nonnull)paymentObserver timeSpentRecorder:(id<FBSDKSourceApplicationTracking,FBSDKTimeSpentRecording> _Nonnull)timeSpentRecorder appEventsStateStore:(id<FBSDKAppEventsStatePersisting> _Nonnull)appEventsStateStore eventDeactivationParameterProcessor:(id<FBSDKAppEventsParameterProcessing> _Nonnull)eventDeactivationParameterProcessor restrictiveDataFilterParameterProcessor:(id<FBSDKAppEventsParameterProcessing> _Nonnull)restrictiveDataFilterParameterProcessor atePublisherFactory:(id<FBSDKATEPublisherCreating> _Nonnull)atePublisherFactory appEventsStateProvider:(id<FBSDKAppEventsStateProviding> _Nonnull)appEventsStateProvider advertiserIDProvider:(id<FBSDKAdvertiserIDProviding> _Nonnull)advertiserIDProvider userDataStore:(id<FBSDKUserDataPersisting> _Nonnull)userDataStore appEventsUtility:(id<FBSDKAppEventDropDetermining,FBSDKAppEventParametersExtracting,FBSDKAppEventsUtility,FBSDKLoggingNotifying> _Nonnull)appEventsUtility internalUtility:(id<FBSDKInternalUtility> _Nonnull)internalUtility capiReporter:(id<FBSDKCAPIReporter> _Nonnull)capiReporter protectedModeManager:(id<FBSDKAppEventsParameterProcessing> _Nonnull)protectedModeManager macaRuleMatchingManager:(id<FBSDKMACARuleMatching> _Nonnull)macaRuleMatchingManager __attribute__((swift_name("configure(gateKeeperManager:appEventsConfigurationProvider:serverConfigurationProvider:graphRequestFactory:featureChecker:primaryDataStore:logger:settings:paymentObserver:timeSpentRecorder:appEventsStateStore:eventDeactivationParameterProcessor:restrictiveDataFilterParameterProcessor:atePublisherFactory:appEventsStateProvider:advertiserIDProvider:userDataStore:appEventsUtility:internalUtility:capiReporter:protectedModeManager:macaRuleMatchingManager:)")));
		[Abstract]
		[Export ("configureWithGateKeeperManager:appEventsConfigurationProvider:serverConfigurationProvider:graphRequestFactory:featureChecker:primaryDataStore:logger:settings:paymentObserver:timeSpentRecorder:appEventsStateStore:eventDeactivationParameterProcessor:restrictiveDataFilterParameterProcessor:atePublisherFactory:appEventsStateProvider:advertiserIDProvider:userDataStore:appEventsUtility:internalUtility:capiReporter:protectedModeManager:macaRuleMatchingManager:")]
		void ConfigureWithGateKeeperManager (IFBSDKGateKeeperManaging gateKeeperManager, IFBSDKAppEventsConfigurationProviding appEventsConfigurationProvider, IFBSDKServerConfigurationProviding serverConfigurationProvider, IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKFeatureChecking featureChecker, IFBSDKDataPersisting primaryDataStore, IFBSDKLogging logger, IFBSDKSettings settings, IFBSDKPaymentObserving paymentObserver, NSObject timeSpentRecorder, IFBSDKAppEventsStatePersisting appEventsStateStore, IFBSDKAppEventsParameterProcessing eventDeactivationParameterProcessor, IFBSDKAppEventsParameterProcessing restrictiveDataFilterParameterProcessor, IFBSDKATEPublisherCreating atePublisherFactory, IFBSDKAppEventsStateProviding appEventsStateProvider, IFBSDKAdvertiserIDProviding advertiserIDProvider, IFBSDKUserDataPersisting userDataStore, NSObject appEventsUtility, IFBSDKInternalUtility internalUtility, IFBSDKCAPIReporter capiReporter, IFBSDKAppEventsParameterProcessing protectedModeManager, IFBSDKMACARuleMatching macaRuleMatchingManager);

		// @required -(void)configureNonTVComponentsWithOnDeviceMLModelManager:(id<FBSDKEventProcessing> _Nonnull)modelManager metadataIndexer:(id<FBSDKMetadataIndexing> _Nonnull)metadataIndexer skAdNetworkReporter:(id<FBSDKAppEventsReporter> _Nullable)skAdNetworkReporter skAdNetworkReporterV2:(id<FBSDKAppEventsReporter> _Nullable)skAdNetworkReporterV2 codelessIndexer:(Class<FBSDKCodelessIndexing> _Nonnull)codelessIndexer swizzler:(Class<FBSDKSwizzling> _Nonnull)swizzler aemReporter:(Class<FBSDKAEMReporter> _Nonnull)aemReporter __attribute__((swift_name("configureNonTVComponents(onDeviceMLModelManager:metadataIndexer:skAdNetworkReporter:skAdNetworkReporterV2:codelessIndexer:swizzler:aemReporter:)")));
		[Abstract]
		[Export ("configureNonTVComponentsWithOnDeviceMLModelManager:metadataIndexer:skAdNetworkReporter:skAdNetworkReporterV2:codelessIndexer:swizzler:aemReporter:")]
		void ConfigureNonTVComponentsWithOnDeviceMLModelManager (IFBSDKEventProcessing modelManager, IFBSDKMetadataIndexing metadataIndexer, [NullAllowed] IFBSDKAppEventsReporter skAdNetworkReporter, [NullAllowed] IFBSDKAppEventsReporter skAdNetworkReporterV2, IFBSDKCodelessIndexing codelessIndexer, IFBSDKSwizzling swizzler, FBAEMReporter aemReporter);
	}
	// @protocol FBSDKCAPIReporter
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FBSDKCAPIReporter
	{
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();

		// @required -(void)configureWithFactory:(id<FBSDKGraphRequestFactory> _Nonnull)factory settings:(id<FBSDKSettings> _Nonnull)settings;
		[Abstract]
		[Export ("configureWithFactory:settings:")]
		void ConfigureWithFactory (IFBSDKGraphRequestFactory factory, IFBSDKSettings settings);

		// @required -(void)recordEvent:(NSDictionary<NSString *,id> * _Nonnull)parameters;
		[Abstract]
		[Export ("recordEvent:")]
		void RecordEvent (NSDictionary<NSString, NSObject> parameters);
	}

	interface IFBSDKAppEventsConfiguring {
	}

	// @protocol FBSDKMACARuleMatching
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FBSDKMACARuleMatching
	{
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();

		// @required -(NSDictionary * _Nullable)processParameters:(NSDictionary * _Nullable)params event:(NSString * _Nullable)event __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("processParameters:event:")]
		[return: NullAllowed]
		NSDictionary ProcessParameters ([NullAllowed] NSDictionary @params, [NullAllowed] string @event);
	}
	
	// @protocol FBSDKApplicationActivating
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
	interface FBSDKApplicationActivating {
		// @required -(void)activateApp;
		[Abstract]
		[Export ("activateApp")]
		void ActivateApp ();
	}

	interface IFBSDKApplicationActivating {
	}

	// @protocol FBSDKApplicationLifecycleObserving
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
	interface FBSDKApplicationLifecycleObserving {
		// @required -(void)startObservingApplicationLifecycleNotifications __attribute__((swift_name("startObservingApplicationLifecycleNotifications()")));
		[Abstract]
		[Export ("startObservingApplicationLifecycleNotifications")]
		void StartObservingApplicationLifecycleNotifications ();
	}

	interface IFBSDKApplicationLifecycleObserving {
	}

	// @protocol FBSDKApplicationStateSetting
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
	interface FBSDKApplicationStateSetting {
		// @required -(void)setApplicationState:(UIApplicationState)state;
		[Abstract]
		[Export ("setApplicationState:")]
		void SetApplicationState (UIApplicationState state);
	}
	
	interface IFBSDKApplicationStateSetting{}

	// @protocol FBSDKEventLogging
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
	interface FBSDKEventLogging {
		// @required @property (readonly, nonatomic) FBSDKAppEventsFlushBehavior flushBehavior;
		[Abstract]
		[Export ("flushBehavior")]
		FBSDKAppEventsFlushBehavior FlushBehavior { get; }

		// @required -(void)flushForReason:(FBSDKAppEventsFlushReason)flushReason;
		[Abstract]
		[Export ("flushForReason:")]
		void FlushForReason (FBSDKAppEventsFlushReason flushReason);

		// @required -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Abstract]
		[Export ("logEvent:parameters:")]
		void LogEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// @required -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Abstract]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (string eventName, double valueToSum, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// @required -(void)logInternalEvent:(FBSDKAppEventName _Nonnull)eventName isImplicitlyLogged:(BOOL)isImplicitlyLogged;
		[Abstract]
		[Export ("logInternalEvent:isImplicitlyLogged:")]
		void LogInternalEvent (string eventName, bool isImplicitlyLogged);

		// @required -(void)logInternalEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters isImplicitlyLogged:(BOOL)isImplicitlyLogged;
		[Abstract]
		[Export ("logInternalEvent:parameters:isImplicitlyLogged:")]
		void LogInternalEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters, bool isImplicitlyLogged);

		// @required -(void)logInternalEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters isImplicitlyLogged:(BOOL)isImplicitlyLogged accessToken:(FBSDKAccessToken * _Nullable)accessToken;
		[Abstract]
		[Export ("logInternalEvent:parameters:isImplicitlyLogged:accessToken:")]
		void LogInternalEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters, bool isImplicitlyLogged, [NullAllowed] FBSDKAccessToken accessToken);

		// @required -(void)logInternalEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum isImplicitlyLogged:(BOOL)isImplicitlyLogged;
		[Abstract]
		[Export ("logInternalEvent:valueToSum:isImplicitlyLogged:")]
		void LogInternalEvent (string eventName, double valueToSum, bool isImplicitlyLogged);
	}

	interface IFBSDKEventLogging {
	}

	// @protocol FBSDKGraphRequestConnectionFactory
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
	interface FBSDKGraphRequestConnectionFactory {
		// @required -(id<FBSDKGraphRequestConnecting> _Nonnull)createGraphRequestConnection;
		[Abstract]
		[Export ("createGraphRequestConnection")]
		IFBSDKGraphRequestConnecting CreateGraphRequestConnection { get; }
	}
	
	interface IFBSDKGraphRequestConnectionFactory {}

	// @protocol FBSDKGraphRequest
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
	interface FBSDKGraphRequestProtocol {
		// @required @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull parameters;
		[Abstract]
		[Export ("parameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Parameters { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable tokenString;
		[Abstract]
		[NullAllowed, Export ("tokenString")]
		string TokenString { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull graphPath;
		[Abstract]
		[Export ("graphPath")]
		string GraphPath { get; }

		// @required @property (readonly, copy, nonatomic) FBSDKHTTPMethod _Nonnull HTTPMethod;
		[Abstract]
		[Export ("HTTPMethod")]
		string HTTPMethod { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Abstract]
		[Export ("version")]
		string Version { get; }

		// @required @property (readonly, assign, nonatomic) FBSDKGraphRequestFlags flags;
		[Abstract]
		[Export ("flags", ArgumentSemantic.Assign)]
		FBSDKGraphRequestFlags Flags { get; }

		// @required @property (getter = isGraphErrorRecoveryDisabled, nonatomic) BOOL graphErrorRecoveryDisabled;
		[Abstract]
		[Export ("graphErrorRecoveryDisabled")]
		bool GraphErrorRecoveryDisabled { [Bind ("isGraphErrorRecoveryDisabled")] get; set; }

		// @required @property (readonly, nonatomic) BOOL hasAttachments;
		[Abstract]
		[Export ("hasAttachments")]
		bool HasAttachments { get; }

		// @required -(id<FBSDKGraphRequestConnecting> _Nonnull)startWithCompletion:(FBSDKGraphRequestCompletion _Nullable)completion;
		[Abstract]
		[Export ("startWithCompletion:")]
		IFBSDKGraphRequestConnecting StartWithCompletion ([NullAllowed] FBSDKGraphRequestCompletion completion);

		// @required -(NSString * _Nonnull)formattedDescription;
		[Abstract]
		[Export ("formattedDescription")]
		string FormattedDescription { get; }
	}

	interface IFBSDKGraphRequestProtocol {
		
	}
	
	[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKGraphRequest : FBSDKGraphRequestProtocol
{
	// +(void)configureWithSettings:(id<FBSDKSettings> _Nonnull)settings currentAccessTokenStringProvider:(Class<FBSDKTokenStringProviding> _Nonnull)accessTokenProvider graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)_graphRequestConnectionFactory __attribute__((swift_name("configure(settings:currentAccessTokenStringProvider:graphRequestConnectionFactory:)")));
	[Static]
	[Export ("configureWithSettings:currentAccessTokenStringProvider:graphRequestConnectionFactory:")]
	void ConfigureWithSettings (IFBSDKSettings settings, IFBSDKTokenStringProviding accessTokenProvider, IFBSDKGraphRequestConnectionFactory _graphRequestConnectionFactory);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath;
	[Export ("initWithGraphPath:")]
	NativeHandle Constructor (string graphPath);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
	[Export ("initWithGraphPath:HTTPMethod:")]
	NativeHandle Constructor (string graphPath, string method);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
	[Export ("initWithGraphPath:parameters:")]
	NativeHandle Constructor (string graphPath, NSDictionary<NSString, NSObject> parameters);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
	[Export ("initWithGraphPath:parameters:HTTPMethod:")]
	NativeHandle Constructor (string graphPath, NSDictionary<NSString, NSObject> parameters, string method);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters tokenString:(NSString * _Nullable)tokenString version:(NSString * _Nullable)version HTTPMethod:(FBSDKHTTPMethod _Nonnull)method __attribute__((objc_designated_initializer));
	[Export ("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string graphPath, NSDictionary<NSString, NSObject> parameters, [NullAllowed] string tokenString, [NullAllowed] string version, string method);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nullable)parameters flags:(FBSDKGraphRequestFlags)requestFlags;
	[Export ("initWithGraphPath:parameters:flags:")]
	NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary<NSString, NSObject> parameters, FBSDKGraphRequestFlags requestFlags);

	// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nullable)parameters tokenString:(NSString * _Nullable)tokenString HTTPMethod:(NSString * _Nullable)HTTPMethod flags:(FBSDKGraphRequestFlags)flags;
	[Export ("initWithGraphPath:parameters:tokenString:HTTPMethod:flags:")]
	NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] string tokenString, [NullAllowed] string HTTPMethod, FBSDKGraphRequestFlags flags);

	// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull parameters;
	[Export ("parameters", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSObject> Parameters { get; set; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable tokenString;
	[NullAllowed, Export ("tokenString")]
	string TokenString { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull graphPath;
	[Export ("graphPath")]
	string GraphPath { get; }

	// @property (readonly, copy, nonatomic) FBSDKHTTPMethod _Nonnull HTTPMethod;
	[Export ("HTTPMethod")]
	string HTTPMethod { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
	[Export ("version")]
	string Version { get; }

	// -(void)setGraphErrorRecoveryDisabled:(BOOL)disable __attribute__((swift_name("setGraphErrorRecovery(disabled:)")));
	// [Export ("setGraphErrorRecoveryDisabled:")]
	// void SetGraphErrorRecoveryDisabled (bool disable);

	// -(id<FBSDKGraphRequestConnecting> _Nonnull)startWithCompletion:(FBSDKGraphRequestCompletion _Nullable)completion;
	[Export ("startWithCompletion:")]
	IFBSDKGraphRequestConnecting StartWithCompletion ([NullAllowed] FBSDKGraphRequestCompletion completion);
}
	
	
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
	interface FBSDKSourceApplicationTracking {
		// @required -(void)setSourceApplication:(NSString * _Nullable)sourceApplication openURL:(NSURL * _Nullable)url;
		[Abstract]
		[Export ("setSourceApplication:openURL:")]
		void SetSourceApplication ([NullAllowed] string sourceApplication, [NullAllowed] NSUrl url);

		// @required -(void)setSourceApplication:(NSString * _Nullable)sourceApplication isFromAppLink:(BOOL)isFromAppLink;
		[Abstract]
		[Export ("setSourceApplication:isFromAppLink:")]
		void SetSourceApplication ([NullAllowed] string sourceApplication, bool isFromAppLink);

		// @required -(void)registerAutoResetSourceApplication;
		[Abstract]
		[Export ("registerAutoResetSourceApplication")]
		void RegisterAutoResetSourceApplication ();
	}

	interface IFBSDKSourceApplicationTracking {
	}

	// @protocol FBSDKUserIDProviding
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
	interface FBSDKUserIDProviding {
		// @required @property (copy, nonatomic) NSString * _Nullable userID;
		[Abstract]
		[NullAllowed, Export ("userID")]
		string UserID { get; set; }
	}

	interface IFBSDKUserIDProviding {
	}

	// @interface FBSDKAppEvents : NSObject <FBSDKEventLogging, FBSDKAppEventsConfiguring, FBSDKApplicationActivating, FBSDKApplicationLifecycleObserving, FBSDKApplicationStateSetting, FBSDKSourceApplicationTracking, FBSDKUserIDProviding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAppEvents : IFBSDKEventLogging, IFBSDKAppEventsConfiguring, IFBSDKApplicationActivating, IFBSDKApplicationLifecycleObserving, IFBSDKApplicationStateSetting, IFBSDKSourceApplicationTracking, IFBSDKUserIDProviding {
		// @property (readonly, nonatomic, strong, class) FBSDKAppEvents * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		FBSDKAppEvents Shared { get; }

		// @property (nonatomic) FBSDKAppEventsFlushBehavior flushBehavior;
		[Export ("flushBehavior", ArgumentSemantic.Assign)]
		FBSDKAppEventsFlushBehavior FlushBehavior { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable loggingOverrideAppID;
		[NullAllowed, Export ("loggingOverrideAppID")]
		string LoggingOverrideAppID { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userID;
		[NullAllowed, Export ("userID")]
		string UserID { get; set; }

		// @property (readonly, nonatomic) NSString * _Nonnull anonymousID;
		[Export ("anonymousID")]
		string AnonymousID { get; }

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName;
		[Export ("logEvent:")]
		void LogEvent (string eventName);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum;
		[Export ("logEvent:valueToSum:")]
		void LogEvent (string eventName, double valueToSum);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Export ("logEvent:parameters:")]
		void LogEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (string eventName, double valueToSum, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(NSNumber * _Nullable)valueToSum parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters accessToken:(FBSDKAccessToken * _Nullable)accessToken;
		[Export ("logEvent:valueToSum:parameters:accessToken:")]
		void LogEvent (string eventName, [NullAllowed] NSNumber valueToSum, [NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] FBSDKAccessToken accessToken);

		// -(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency __attribute__((swift_name("logPurchase(amount:currency:)")));
		[Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		// -(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters __attribute__((swift_name("logPurchase(amount:currency:parameters:)")));
		[Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// -(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters accessToken:(FBSDKAccessToken * _Nullable)accessToken __attribute__((swift_name("logPurchase(amount:currency:parameters:accessToken:)")));
		[Export ("logPurchase:currency:parameters:accessToken:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] FBSDKAccessToken accessToken);

		// -(void)logPushNotificationOpen:(NSDictionary<NSString *,id> * _Nonnull)payload __attribute__((swift_name("logPushNotificationOpen(payload:)")));
		[Export ("logPushNotificationOpen:")]
		void LogPushNotificationOpen (NSDictionary<NSString, NSObject> payload);

		// -(void)logPushNotificationOpen:(NSDictionary<NSString *,id> * _Nonnull)payload action:(NSString * _Nonnull)action __attribute__((swift_name("logPushNotificationOpen(payload:action:)")));
		[Export ("logPushNotificationOpen:action:")]
		void LogPushNotificationOpen (NSDictionary<NSString, NSObject> payload, string action);

		// -(void)logProductItem:(NSString * _Nonnull)itemID availability:(FBSDKProductAvailability)availability condition:(FBSDKProductCondition)condition description:(NSString * _Nonnull)description imageLink:(NSString * _Nonnull)imageLink link:(NSString * _Nonnull)link title:(NSString * _Nonnull)title priceAmount:(double)priceAmount currency:(NSString * _Nonnull)currency gtin:(NSString * _Nullable)gtin mpn:(NSString * _Nullable)mpn brand:(NSString * _Nullable)brand parameters:(NSDictionary<NSString *,id> * _Nullable)parameters __attribute__((swift_name("logProductItem(id:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:)")));
		[Export ("logProductItem:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:")]
		void LogProductItem (string itemID, FBSDKProductAvailability availability, FBSDKProductCondition condition, string description, string imageLink, string link, string title, double priceAmount, string currency, [NullAllowed] string gtin, [NullAllowed] string mpn, [NullAllowed] string brand, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// -(void)activateApp;
		[Export ("activateApp")]
		void ActivateApp ();

		// -(void)setPushNotificationsDeviceToken:(NSData * _Nullable)deviceToken;
		[Export ("setPushNotificationsDeviceToken:")]
		void SetPushNotificationsDeviceToken ([NullAllowed] NSData deviceToken);

		// -(void)setPushNotificationsDeviceTokenString:(NSString * _Nullable)deviceTokenString __attribute__((swift_name("setPushNotificationsDeviceToken(_:)")));
		[Export ("setPushNotificationsDeviceTokenString:")]
		void SetPushNotificationsDeviceTokenString ([NullAllowed] string deviceTokenString);

		// -(void)flush;
		[Export ("flush")]
		void Flush ();

		// -(FBSDKGraphRequestProtocol * _Nullable)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken * _Nullable)accessToken __attribute__((swift_name("requestForCustomAudienceThirdPartyID(accessToken:)")));
		[Export ("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
		[return: NullAllowed]
		IFBSDKGraphRequestProtocol RequestForCustomAudienceThirdPartyIDWithAccessToken ([NullAllowed] FBSDKAccessToken accessToken);

		// -(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country __attribute__((swift_name("setUser(email:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:)")));
		[Export ("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:")]
		void SetUserEmail ([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country);

		// -(NSString * _Nullable)getUserData;
		[NullAllowed, Export ("getUserData")]
		string UserData { get; }

		// -(void)clearUserData;
		[Export ("clearUserData")]
		void ClearUserData ();

		// -(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Export ("setUserData:forType:")]
		void SetUserData ([NullAllowed] string data, string type);

		// -(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Export ("clearUserDataForType:")]
		void ClearUserDataForType (string type);

		// -(void)augmentHybridWebView:(WKWebView * _Nonnull)webView;
		[Export ("augmentHybridWebView:")]
		void AugmentHybridWebView (WKWebView webView);

		// -(void)setIsUnityInitialized:(BOOL)isUnityInitialized;
		[Export ("setIsUnityInitialized:")]
		void SetIsUnityInitialized (bool isUnityInitialized);

		// -(void)sendEventBindingsToUnity;
		[Export ("sendEventBindingsToUnity")]
		void SendEventBindingsToUnity ();

		// -(void)logInternalEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters isImplicitlyLogged:(BOOL)isImplicitlyLogged;
		[Export ("logInternalEvent:parameters:isImplicitlyLogged:")]
		void LogInternalEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters, bool isImplicitlyLogged);

		// -(void)logInternalEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters isImplicitlyLogged:(BOOL)isImplicitlyLogged accessToken:(FBSDKAccessToken * _Nullable)accessToken;
		[Export ("logInternalEvent:parameters:isImplicitlyLogged:accessToken:")]
		void LogInternalEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters, bool isImplicitlyLogged, [NullAllowed] FBSDKAccessToken accessToken);

		// -(void)flushForReason:(FBSDKAppEventsFlushReason)flushReason;
		[Export ("flushForReason:")]
		void FlushForReason (FBSDKAppEventsFlushReason flushReason);
	}

	// @protocol FBSDKAppEventsConfiguration
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
	[DisableDefaultCtor]
	interface FBSDKAppEventsConfiguration {
		// @required @property (readonly, assign, nonatomic) FBSDKAdvertisingTrackingStatus defaultATEStatus;
		[Abstract]
		[Export ("defaultATEStatus", ArgumentSemantic.Assign)]
		FBSDKAdvertisingTrackingStatus DefaultATEStatus { get; }

		// @required @property (readonly, assign, nonatomic) BOOL advertiserIDCollectionEnabled;
		[Abstract]
		[Export ("advertiserIDCollectionEnabled")]
		bool AdvertiserIDCollectionEnabled { get; }

		// @required @property (readonly, assign, nonatomic) BOOL eventCollectionEnabled;
		[Abstract]
		[Export ("eventCollectionEnabled")]
		bool EventCollectionEnabled { get; }

		// @required -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nullable)dict;
		[Abstract]
		[Export ("initWithJSON:")]
		NativeHandle Constructor ([NullAllowed] NSDictionary<NSString, NSObject> dict);

		// @required +(instancetype _Nonnull)defaultConfiguration;
		[Static, Abstract]
		[Export ("defaultConfiguration")]
		IFBSDKAppEventsConfiguration DefaultConfiguration ();
	}
	
	interface IFBSDKAppEventsConfiguration {}

	// @interface FBSDKAppEventsConfiguration : NSObject <NSCopying, NSObject, NSSecureCoding, FBSDKAppEventsConfiguration>
	// [BaseType (typeof (NSObject)), BaseType (typeof (NSObject))]
	// [DisableDefaultCtor]
	// interface FBSDKAppEventsConfiguration : INSCopying, INSSecureCoding, IFBSDKAppEventsConfiguration {
	// 	// @property (readonly, assign, nonatomic) FBSDKAdvertisingTrackingStatus defaultATEStatus;
	// 	[Export ("defaultATEStatus", ArgumentSemantic.Assign)]
	// 	FBSDKAdvertisingTrackingStatus DefaultATEStatus { get; }
	//
	// 	// @property (readonly, assign, nonatomic) BOOL advertiserIDCollectionEnabled;
	// 	[Export ("advertiserIDCollectionEnabled")]
	// 	bool AdvertiserIDCollectionEnabled { get; }
	//
	// 	// @property (readonly, assign, nonatomic) BOOL eventCollectionEnabled;
	// 	[Export ("eventCollectionEnabled")]
	// 	bool EventCollectionEnabled { get; }
	//
	// 	// -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nullable)dict;
	// 	[Export ("initWithJSON:")]
	// 	NativeHandle Constructor ([NullAllowed] NSDictionary<NSString, NSObject> dict);
	//
	// 	// +(instancetype _Nonnull)defaultConfiguration;
	// 	[Static]
	// 	[Export ("defaultConfiguration")]
	// 	FBSDKAppEventsConfiguration DefaultConfiguration ();
	// }

	// typedef void (^FBSDKAppEventsConfigurationProvidingBlock)();
	delegate void FBSDKAppEventsConfigurationProvidingBlock ();

	// @protocol FBSDKAppEventsConfigurationProviding
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
	interface FBSDKAppEventsConfigurationProviding {
		// @required @property (readonly, nonatomic) id<FBSDKAppEventsConfiguration> _Nonnull cachedAppEventsConfiguration;
		[Abstract]
		[Export ("cachedAppEventsConfiguration")]
		IFBSDKAppEventsConfiguration CachedAppEventsConfiguration { get; }

		// @required -(void)loadAppEventsConfigurationWithBlock:(FBSDKAppEventsConfigurationProvidingBlock _Nonnull)block;
		[Abstract]
		[Export ("loadAppEventsConfigurationWithBlock:")]
		void LoadAppEventsConfigurationWithBlock (FBSDKAppEventsConfigurationProvidingBlock block);
	}
	
	interface IFBSDKAppEventsConfigurationProviding {}

	// typedef void (^FBSDKAppEventsConfigurationManagerBlock)();
	delegate void FBSDKAppEventsConfigurationManagerBlock ();
	
	

	// @interface FBSDKAppEventsConfigurationManager : NSObject <FBSDKAppEventsConfigurationProviding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAppEventsConfigurationManager : IFBSDKAppEventsConfigurationProviding {
		// @property (readonly, nonatomic, class) FBSDKAppEventsConfigurationManager * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKAppEventsConfigurationManager Shared { get; }

		// @property (readonly, nonatomic) id<FBSDKAppEventsConfiguration> _Nonnull cachedAppEventsConfiguration;
		[Export ("cachedAppEventsConfiguration")]
		IFBSDKAppEventsConfiguration CachedAppEventsConfiguration { get; }

		// -(void)configureWithStore:(id<FBSDKDataPersisting> _Nonnull)store settings:(id<FBSDKSettings> _Nonnull)settings graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)graphRequestConnectionFactory __attribute__((swift_name("configure(store:settings:graphRequestFactory:graphRequestConnectionFactory:)")));
		[Export ("configureWithStore:settings:graphRequestFactory:graphRequestConnectionFactory:")]
		void ConfigureWithStore (IFBSDKDataPersisting store, IFBSDKSettings settings, IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKGraphRequestConnectionFactory graphRequestConnectionFactory);

		// -(void)loadAppEventsConfigurationWithBlock:(FBSDKAppEventsConfigurationManagerBlock _Nonnull)block;
		[Export ("loadAppEventsConfigurationWithBlock:")]
		void LoadAppEventsConfigurationWithBlock (FBSDKAppEventsConfigurationManagerBlock block);
	}

	// @protocol FBSDKDeviceInformationProviding
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
	interface FBSDKDeviceInformationProviding {
		// @required @property (readonly, nonatomic) NSString * _Nonnull storageKey;
		[Abstract]
		[Export ("storageKey")]
		string StorageKey { get; }

		// @required @property (readonly, nonatomic) NSString * _Nullable encodedDeviceInfo;
		[Abstract]
		[NullAllowed, Export ("encodedDeviceInfo")]
		string EncodedDeviceInfo { get; }

		// @required @property (nonatomic) NSString * _Nullable carrierName;
		[Abstract]
		[NullAllowed, Export ("carrierName")]
		string CarrierName { get; set; }

		// @required @property (nonatomic) NSString * _Nullable timeZoneAbbrev;
		[Abstract]
		[NullAllowed, Export ("timeZoneAbbrev")]
		string TimeZoneAbbrev { get; set; }

		// @required @property (nonatomic) unsigned long long remainingDiskSpaceGB;
		[Abstract]
		[Export ("remainingDiskSpaceGB")]
		ulong RemainingDiskSpaceGB { get; set; }

		// @required @property (nonatomic) NSString * _Nullable timeZoneName;
		[Abstract]
		[NullAllowed, Export ("timeZoneName")]
		string TimeZoneName { get; set; }

		// @required @property (nonatomic) NSString * _Nullable bundleIdentifier;
		[Abstract]
		[NullAllowed, Export ("bundleIdentifier")]
		string BundleIdentifier { get; set; }

		// @required @property (nonatomic) NSString * _Nullable longVersion;
		[Abstract]
		[NullAllowed, Export ("longVersion")]
		string LongVersion { get; set; }

		// @required @property (nonatomic) NSString * _Nullable shortVersion;
		[Abstract]
		[NullAllowed, Export ("shortVersion")]
		string ShortVersion { get; set; }

		// @required @property (nonatomic) NSString * _Nullable sysVersion;
		[Abstract]
		[NullAllowed, Export ("sysVersion")]
		string SysVersion { get; set; }

		// @required @property (nonatomic) NSString * _Nullable machine;
		[Abstract]
		[NullAllowed, Export ("machine")]
		string Machine { get; set; }

		// @required @property (nonatomic) NSString * _Nullable language;
		[Abstract]
		[NullAllowed, Export ("language")]
		string Language { get; set; }

		// @required @property (nonatomic) unsigned long long totalDiskSpaceGB;
		[Abstract]
		[Export ("totalDiskSpaceGB")]
		ulong TotalDiskSpaceGB { get; set; }

		// @required @property (nonatomic) unsigned long long coreCount;
		[Abstract]
		[Export ("coreCount")]
		ulong CoreCount { get; set; }

		// @required @property (nonatomic) CGFloat width;
		[Abstract]
		[Export ("width")]
		nfloat Width { get; set; }

		// @required @property (nonatomic) CGFloat height;
		[Abstract]
		[Export ("height")]
		nfloat Height { get; set; }

		// @required @property (nonatomic) CGFloat density;
		[Abstract]
		[Export ("density")]
		nfloat Density { get; set; }
	}

	interface IFBSDKDeviceInformationProviding { }

	// @interface FBSDKAppEventsDeviceInfo : NSObject <FBSDKDeviceInformationProviding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAppEventsDeviceInfo : IFBSDKDeviceInformationProviding {
		// @property (readonly, nonatomic, class) FBSDKAppEventsDeviceInfo * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKAppEventsDeviceInfo Shared { get; }

		// @property (readonly, nonatomic) id<FBSDKSettings> _Nullable settings;
		[NullAllowed, Export ("settings")]
		IFBSDKSettings Settings { get; }

		// @property (nonatomic) NSString * _Nonnull carrierName;
		[Export ("carrierName")]
		string CarrierName { get; set; }

		// @property (nonatomic) NSString * _Nonnull timeZoneAbbrev;
		[Export ("timeZoneAbbrev")]
		string TimeZoneAbbrev { get; set; }

		// @property (nonatomic) unsigned long long remainingDiskSpaceGB;
		[Export ("remainingDiskSpaceGB")]
		ulong RemainingDiskSpaceGB { get; set; }

		// @property (nonatomic) NSString * _Nonnull timeZoneName;
		[Export ("timeZoneName")]
		string TimeZoneName { get; set; }

		// @property (nonatomic) NSString * _Nonnull bundleIdentifier;
		[Export ("bundleIdentifier")]
		string BundleIdentifier { get; set; }

		// @property (nonatomic) NSString * _Nonnull longVersion;
		[Export ("longVersion")]
		string LongVersion { get; set; }

		// @property (nonatomic) NSString * _Nonnull shortVersion;
		[Export ("shortVersion")]
		string ShortVersion { get; set; }

		// @property (nonatomic) NSString * _Nonnull sysVersion;
		[Export ("sysVersion")]
		string SysVersion { get; set; }

		// @property (nonatomic) NSString * _Nonnull machine;
		[Export ("machine")]
		string Machine { get; set; }

		// @property (nonatomic) NSString * _Nonnull language;
		[Export ("language")]
		string Language { get; set; }

		// @property (nonatomic) unsigned long long totalDiskSpaceGB;
		[Export ("totalDiskSpaceGB")]
		ulong TotalDiskSpaceGB { get; set; }

		// @property (nonatomic) unsigned long long coreCount;
		[Export ("coreCount")]
		ulong CoreCount { get; set; }

		// @property (nonatomic) CGFloat width;
		[Export ("width")]
		nfloat Width { get; set; }

		// @property (nonatomic) CGFloat height;
		[Export ("height")]
		nfloat Height { get; set; }

		// @property (nonatomic) CGFloat density;
		[Export ("density")]
		nfloat Density { get; set; }

		// -(void)configureWithSettings:(id<FBSDKSettings> _Nonnull)settings __attribute__((swift_name("configure(settings:)")));
		[Export ("configureWithSettings:")]
		void ConfigureWithSettings (IFBSDKSettings settings);
	}

	// @protocol FBSDKAppEventsParameterProcessing
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
	interface FBSDKAppEventsParameterProcessing {
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();

		// @required -(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)processParameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters eventName:(FBSDKAppEventName _Nullable)eventName;
		[Abstract]
		[Export ("processParameters:eventName:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> ProcessParameters ([NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] string eventName);
	}

	interface IFBSDKAppEventsParameterProcessing { }

	// @protocol FBSDKAppEventsReporter
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
	interface FBSDKAppEventsReporter {
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();

		// @required -(void)recordAndUpdateEvent:(NSString * _Nonnull)event currency:(NSString * _Nullable)currency value:(NSNumber * _Nullable)value parameters:(NSDictionary<NSString *,id> * _Nullable)parameters __attribute__((swift_name("recordAndUpdate(event:currency:value:parameters:)")));
		[Abstract]
		[Export ("recordAndUpdateEvent:currency:value:parameters:")]
		void RecordAndUpdateEvent (string @event, [NullAllowed] string currency, [NullAllowed] NSNumber value, [NullAllowed] NSDictionary<NSString, NSObject> parameters);
	}

	interface IFBSDKAppEventsReporter { }

	// @protocol FBSDKEventsProcessing
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
	interface FBSDKEventsProcessing {
		// @required -(void)processEvents:(NSMutableArray<NSDictionary<NSString *,id> *> * _Nonnull)events;
		[Abstract]
		[Export ("processEvents:")]
		void ProcessEvents (NSMutableArray<NSDictionary<NSString, NSObject>> events);
	}

	interface IFBSDKEventsProcessing {}

	// @interface FBSDKAppEventsState : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAppEventsState : INSCopying, INSSecureCoding {
		// @property (nonatomic, class) NSArray<id<FBSDKEventsProcessing>> * _Nullable eventProcessors;
		[Static]
		[NullAllowed, Export ("eventProcessors", ArgumentSemantic.Assign)]
		IFBSDKEventsProcessing [] EventProcessors { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<NSDictionary<NSString *,id> *> * _Nonnull events;
		[Export ("events", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> [] Events { get; }

		// @property (readonly, assign, nonatomic) NSUInteger numSkipped;
		[Export ("numSkipped")]
		nuint NumSkipped { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
		[Export ("tokenString")]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appID;
		[Export ("appID")]
		string AppID { get; }

		// @property (readonly, getter = areAllEventsImplicit, nonatomic) BOOL allEventsImplicit;
		[Export ("allEventsImplicit")]
		bool AllEventsImplicit { [Bind ("areAllEventsImplicit")] get; }

		// -(instancetype _Nonnull)initWithToken:(NSString * _Nullable)tokenString appID:(NSString * _Nullable)appID __attribute__((objc_designated_initializer));
		[Export ("initWithToken:appID:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] string tokenString, [NullAllowed] string appID);

		// -(void)addEvent:(NSDictionary<NSString *,id> * _Nonnull)eventDictionary isImplicit:(BOOL)isImplicit;
		[Export ("addEvent:isImplicit:")]
		void AddEvent (NSDictionary<NSString, NSObject> eventDictionary, bool isImplicit);

		// -(void)addEventsFromAppEventState:(FBSDKAppEventsState * _Nonnull)appEventsState;
		[Export ("addEventsFromAppEventState:")]
		void AddEventsFromAppEventState (FBSDKAppEventsState appEventsState);

		// -(BOOL)isCompatibleWithAppEventsState:(FBSDKAppEventsState * _Nullable)appEventsState;
		[Export ("isCompatibleWithAppEventsState:")]
		bool IsCompatibleWithAppEventsState ([NullAllowed] FBSDKAppEventsState appEventsState);

		// -(BOOL)isCompatibleWithTokenString:(NSString * _Nonnull)tokenString appID:(NSString * _Nonnull)appID;
		[Export ("isCompatibleWithTokenString:appID:")]
		bool IsCompatibleWithTokenString (string tokenString, string appID);

		// -(NSString * _Nonnull)JSONStringForEventsIncludingImplicitEvents:(BOOL)includeImplicitEvents;
		[Export ("JSONStringForEventsIncludingImplicitEvents:")]
		string JSONStringForEventsIncludingImplicitEvents (bool includeImplicitEvents);

		// -(NSString * _Nonnull)extractReceiptData;
		[Export ("extractReceiptData")]
		string ExtractReceiptData { get; }
	}

	// @protocol FBSDKAppEventsStatePersisting
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
	interface FBSDKAppEventsStatePersisting {
		// @required -(void)clearPersistedAppEventsStates;
		[Abstract]
		[Export ("clearPersistedAppEventsStates")]
		void ClearPersistedAppEventsStates ();

		// @required -(void)persistAppEventsData:(FBSDKAppEventsState * _Nonnull)appEventsState;
		[Abstract]
		[Export ("persistAppEventsData:")]
		void PersistAppEventsData (FBSDKAppEventsState appEventsState);

		// @required -(NSArray<id> * _Nonnull)retrievePersistedAppEventsStates;
		[Abstract]
		[Export ("retrievePersistedAppEventsStates")]
		NSObject [] RetrievePersistedAppEventsStates { get; }
	}

	interface IFBSDKAppEventsStatePersisting {
	}

	// @interface FBSDKAppEventsStateManager : NSObject <FBSDKAppEventsStatePersisting>
	[BaseType (typeof (NSObject))]
	interface FBSDKAppEventsStateManager : IFBSDKAppEventsStatePersisting {
		// @property (readonly, nonatomic, class) FBSDKAppEventsStateManager * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKAppEventsStateManager Shared { get; }

		// -(void)clearPersistedAppEventsStates;
		[Export ("clearPersistedAppEventsStates")]
		void ClearPersistedAppEventsStates ();

		// -(void)persistAppEventsData:(FBSDKAppEventsState * _Nonnull)appEventsState;
		[Export ("persistAppEventsData:")]
		void PersistAppEventsData (FBSDKAppEventsState appEventsState);

		// -(NSArray<FBSDKAppEventsState *> * _Nonnull)retrievePersistedAppEventsStates;
		[Export ("retrievePersistedAppEventsStates")]
		FBSDKAppEventsState [] RetrievePersistedAppEventsStates { get; }
	}

	// @protocol FBSDKAppEventsStateProviding
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
	interface FBSDKAppEventsStateProviding {
		// @required -(FBSDKAppEventsState * _Nonnull)createStateWithToken:(NSString * _Nonnull)tokenString appID:(NSString * _Nonnull)appID __attribute__((swift_name("createState(tokenString:appID:)")));
		[Abstract]
		[Export ("createStateWithToken:appID:")]
		FBSDKAppEventsState AppID (string tokenString, string appID);
	}
	
	interface IFBSDKAppEventsStateProviding {}

	// @protocol FBSDKAppEventParametersExtracting
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
	interface FBSDKAppEventParametersExtracting {
		// @required -(NSMutableDictionary<NSString *,NSString *> * _Nonnull)activityParametersDictionaryForEvent:(NSString * _Nonnull)eventCategory shouldAccessAdvertisingID:(BOOL)shouldAccessAdvertisingID userID:(NSString * _Nullable)userID userData:(NSString * _Nullable)userData;
		[Abstract]
		[Export ("activityParametersDictionaryForEvent:shouldAccessAdvertisingID:userID:userData:")]
		NSMutableDictionary<NSString, NSString> ShouldAccessAdvertisingID (string eventCategory, bool shouldAccessAdvertisingID, [NullAllowed] string userID, [NullAllowed] string userData);
	}
	
	interface IFBSDKAppEventParametersExtracting {}

	// @protocol FBSDKAppEventsUtility
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
	interface FBSDKAppEventsUtility {
		// @required @property (readonly, nonatomic) NSTimeInterval unixTimeNow;
		[Abstract]
		[Export ("unixTimeNow")]
		double UnixTimeNow { get; }

		// @required -(void)ensureOnMainThread:(NSString * _Nonnull)methodName className:(NSString * _Nonnull)className;
		[Abstract]
		[Export ("ensureOnMainThread:className:")]
		void EnsureOnMainThread (string methodName, string className);

		// @required -(NSTimeInterval)convertToUnixTime:(NSDate * _Nullable)date;
		[Abstract]
		[Export ("convertToUnixTime:")]
		double ConvertToUnixTime ([NullAllowed] NSDate date);

		// @required -(BOOL)validateIdentifier:(NSString * _Nullable)identifier;
		[Abstract]
		[Export ("validateIdentifier:")]
		bool ValidateIdentifier ([NullAllowed] string identifier);

		// @required -(NSString * _Nullable)tokenStringToUseFor:(FBSDKAccessToken * _Nullable)token loggingOverrideAppID:(NSString * _Nullable)loggingOverrideAppID;
		[Abstract]
		[Export ("tokenStringToUseFor:loggingOverrideAppID:")]
		[return: NullAllowed]
		string TokenStringToUseFor ([NullAllowed] FBSDKAccessToken token, [NullAllowed] string loggingOverrideAppID);

		// @required -(NSString * _Nonnull)flushReasonToString:(FBSDKAppEventsFlushReason)flushReason;
		[Abstract]
		[Export ("flushReasonToString:")]
		string FlushReasonToString (FBSDKAppEventsFlushReason flushReason);

		// @required -(void)saveCampaignIDs:(NSURL * _Nonnull)url;
		[Abstract]
		[Export ("saveCampaignIDs:")]
		void SaveCampaignIDs (NSUrl url);

		// @required -(NSString * _Nullable)getCampaignIDs;
		[Abstract]
		[NullAllowed, Export ("getCampaignIDs")]
		string CampaignIDs { get; }
	}
	
	interface IFBSDKAppEventsUtility {}

	// @protocol FBSDKLoggingNotifying
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
	interface FBSDKLoggingNotifying {
		// @required -(void)logAndNotify:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("logAndNotify:")]
		void LogAndNotify (string message);

		// @required -(void)logAndNotify:(NSString * _Nonnull)message allowLogAsDeveloperError:(BOOL)allowLogAsDeveloperError;
		[Abstract]
		[Export ("logAndNotify:allowLogAsDeveloperError:")]
		void AllowLogAsDeveloperError (string message, bool allowLogAsDeveloperError);
	}
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
	interface FBSDKApplicationObserving {
		// @optional -(void)applicationDidBecomeActive:(UIApplication * _Nullable)application;
		[Export ("applicationDidBecomeActive:")]
		void ApplicationDidBecomeActive ([NullAllowed] UIApplication application);

		// @optional -(void)applicationWillResignActive:(UIApplication * _Nullable)application;
		[Export ("applicationWillResignActive:")]
		void ApplicationWillResignActive ([NullAllowed] UIApplication application);

		// @optional -(void)applicationDidEnterBackground:(UIApplication * _Nullable)application;
		[Export ("applicationDidEnterBackground:")]
		void ApplicationDidEnterBackground ([NullAllowed] UIApplication application);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool Application (UIApplication application, [NullAllowed] NSDictionary<NSString, NSObject> launchOptions);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool Application (UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
	}
	
	interface IFBSDKApplicationObserving {}

	// @protocol FBSDKAppLinkCreating
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
	interface FBSDKAppLinkCreating {
		// @required -(id<FBSDKAppLink> _Nonnull)createAppLinkWithSourceURL:(NSURL * _Nullable)sourceURL targets:(NSArray<id<FBSDKAppLinkTarget>> * _Nonnull)targets webURL:(NSURL * _Nullable)webURL isBackToReferrer:(BOOL)isBackToReferrer __attribute__((swift_name("createAppLink(sourceURL:targets:webURL:isBackToReferrer:)")));
		[Abstract]
		[Export ("createAppLinkWithSourceURL:targets:webURL:isBackToReferrer:")]
		IFBSDKAppLink Targets ([NullAllowed] NSUrl sourceURL, IFBSDKAppLinkTarget [] targets, [NullAllowed] NSUrl webURL, bool isBackToReferrer);
	}

	interface IFBSDKAppLinkCreating {
		
	}

	// @protocol FBSDKAppLinkEventPosting
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
	interface FBSDKAppLinkEventPosting {
		// @required -(void)postNotificationForEventName:(NSString * _Nonnull)name args:(NSDictionary<NSString *,id> * _Nonnull)args __attribute__((swift_name("postNotification(eventName:arguments:)")));
		[Abstract]
		[Export ("postNotificationForEventName:args:")]
		void Args (string name, NSDictionary<NSString, NSObject> args);
	}
	
	interface IFBSDKAppLinkEventPosting {}

	// typedef void (^FBSDKAppLinkNavigationBlock)(FBSDKAppLinkNavigationType, NSError * _Nullable);
	delegate void FBSDKAppLinkNavigationBlock (FBSDKAppLinkNavigationType arg0, [NullAllowed] NSError arg1);

	// @protocol FBSDKAppLink
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
	interface FBSDKAppLink {
		// @required @property (readonly, nonatomic, strong) NSURL * _Nullable sourceURL;
		[Abstract]
		[NullAllowed, Export ("sourceURL", ArgumentSemantic.Strong)]
		NSUrl SourceURL { get; }

		// @required @property (readonly, copy, nonatomic) NSArray<id<FBSDKAppLinkTarget>> * _Nonnull targets;
		[Abstract]
		[Export ("targets", ArgumentSemantic.Copy)]
		IFBSDKAppLinkTarget [] Targets { get; }

		// @required @property (readonly, nonatomic, strong) NSURL * _Nullable webURL;
		[Abstract]
		[NullAllowed, Export ("webURL", ArgumentSemantic.Strong)]
		NSUrl WebURL { get; }

		// @required @property (readonly, getter = isBackToReferrer, assign, nonatomic) BOOL backToReferrer;
		[Abstract]
		[Export ("backToReferrer")]
		bool BackToReferrer { [Bind ("isBackToReferrer")] get; }
	}

	interface IFBSDKAppLink : INativeObject{
		
	}

	// @protocol FBSDKAppLinkResolverRequestBuilding
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
	interface FBSDKAppLinkResolverRequestBuilding {
		// @required -(id<FBSDKGraphRequest> _Nonnull)requestForURLs:(NSArray<NSURL *> * _Nonnull)urls;
		[Abstract]
		[Export ("requestForURLs:")]
		IFBSDKGraphRequestProtocol RequestForURLs (NSUrl [] urls);

		// @required -(NSString * _Nullable)getIdiomSpecificField;
		[Abstract]
		[NullAllowed, Export ("getIdiomSpecificField")]
		string IdiomSpecificField { get; }
	}

	// typedef void (^FBSDKAppLinkBlock)(FBSDKAppLink * _Nullable, NSError * _Nullable);
	delegate void FBSDKAppLinkBlock ([NullAllowed] IFBSDKAppLink arg0, [NullAllowed] NSError arg1);

	// @protocol FBSDKAppLinkResolving <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKAppLinkResolving {
		// @required -(void)appLinkFromURL:(NSURL * _Nonnull)url handler:(FBSDKAppLinkBlock _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)))
		[Abstract]
		[Export ("appLinkFromURL:handler:")]
		void Handler (NSUrl url, FBSDKAppLinkBlock handler);
	}
	
	interface IFBSDKAppLinkResolving {}

	// typedef void (^FBSDKAppLinksBlock)(NSDictionary<NSURL *,FBSDKAppLink *> * _Nonnull, NSError * _Nullable);
	delegate void FBSDKAppLinksBlock (NSDictionary<NSUrl, IFBSDKAppLink> arg0, [NullAllowed] NSError arg1);

	// @protocol FBSDKAppLinkTarget
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
	interface FBSDKAppLinkTarget {
		// @required +(instancetype _Nonnull)appLinkTargetWithURL:(NSURL * _Nullable)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName __attribute__((swift_name("init(url:appStoreId:appName:)")));
		[Static, Abstract]
		[Export ("appLinkTargetWithURL:appStoreId:appName:")]
		IFBSDKAppLinkTarget GetAppStoreId ([NullAllowed] NSUrl url, [NullAllowed] string appStoreId, string appName);

		// @required @property (readonly, nonatomic) NSURL * _Nullable URL;
		[Abstract]
		[NullAllowed, Export ("URL")]
		NSUrl URL { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable appStoreId;
		[Abstract]
		[NullAllowed, Export ("appStoreId")]
		string AppStoreId { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull appName;
		[Abstract]
		[Export ("appName")]
		string AppName { get; }
	}
	
	interface IFBSDKAppLinkTarget {}

	// @protocol FBSDKAppLinkTargetCreating
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
	interface FBSDKAppLinkTargetCreating {
		// @required -(id<FBSDKAppLinkTarget> _Nonnull)createAppLinkTargetWithURL:(NSURL * _Nullable)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName __attribute__((swift_name("createAppLinkTarget(url:appStoreId:appName:)")));
		[Abstract]
		[Export ("createAppLinkTargetWithURL:appStoreId:appName:")]
		IFBSDKAppLinkTarget AppStoreId ([NullAllowed] NSUrl url, [NullAllowed] string appStoreId, string appName);
	}
	interface IFBSDKAppLinkTargetCreating {}

	// @protocol FBSDKAppLinkURL
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
	interface FBSDKAppLinkURL {
		// @required @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nullable appLinkExtras;
		[Abstract]
		[NullAllowed, Export ("appLinkExtras", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkExtras { get; }
	}
	
	interface IFBSDKAppLinkURL {}

	// @protocol FBSDKAppLinkURLCreating
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
	interface FBSDKAppLinkURLCreating {
		// @required -(id<FBSDKAppLinkURL> _Nonnull)createAppLinkURLWithURL:(NSURL * _Nonnull)url;
		[Abstract]
		[Export ("createAppLinkURLWithURL:")]
		IFBSDKAppLinkURL CreateAppLinkURLWithURL (NSUrl url);
	}
	
	interface IFBSDKAppLinkURLCreating  {}

	// typedef void (^FBSDKURLBlock)(NSURL * _Nullable, NSError * _Nullable);
	delegate void FBSDKURLBlock ([NullAllowed] NSUrl arg0, [NullAllowed] NSError arg1);

	// @interface FBSDKAppLinkUtility : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAppLinkUtility {
		// +(void)fetchDeferredAppLink:(FBSDKURLBlock _Nullable)handler;
		[Static]
		[Export ("fetchDeferredAppLink:")]
		void FetchDeferredAppLink ([NullAllowed] FBSDKURLBlock handler);

		// +(NSString * _Nullable)appInvitePromotionCodeFromURL:(NSURL * _Nonnull)url;
		[Static]
		[Export ("appInvitePromotionCodeFromURL:")]
		[return: NullAllowed]
		string AppInvitePromotionCodeFromURL (NSUrl url);

		// +(BOOL)isMatchURLScheme:(NSString * _Nonnull)scheme;
		[Static]
		[Export ("isMatchURLScheme:")]
		bool IsMatchURLScheme (string scheme);

		// +(void)configureWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory infoDictionaryProvider:(id<FBSDKInfoDictionaryProviding> _Nonnull)infoDictionaryProvider settings:(id<FBSDKSettings> _Nonnull)settings appEventsConfigurationProvider:(id<FBSDKAppEventsConfigurationProviding> _Nonnull)appEventsConfigurationProvider advertiserIDProvider:(id<FBSDKAdvertiserIDProviding> _Nonnull)advertiserIDProvider appEventsDropDeterminer:(id<FBSDKAppEventDropDetermining> _Nonnull)appEventsDropDeterminer appEventParametersExtractor:(id<FBSDKAppEventParametersExtracting> _Nonnull)appEventParametersExtractor appLinkURLFactory:(id<FBSDKAppLinkURLCreating> _Nonnull)appLinkURLFactory userIDProvider:(id<FBSDKUserIDProviding> _Nonnull)userIDProvider userDataStore:(id<FBSDKUserDataPersisting> _Nonnull)userDataStore __attribute__((swift_name("configure(graphRequestFactory:infoDictionaryProvider:settings:appEventsConfigurationProvider:advertiserIDProvider:appEventsDropDeterminer:appEventParametersExtractor:appLinkURLFactory:userIDProvider:userDataStore:)")));
		[Static]
		[Export ("configureWithGraphRequestFactory:infoDictionaryProvider:settings:appEventsConfigurationProvider:advertiserIDProvider:appEventsDropDeterminer:appEventParametersExtractor:appLinkURLFactory:userIDProvider:userDataStore:")]
		void ConfigureWithGraphRequestFactory (IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKInfoDictionaryProviding infoDictionaryProvider, IFBSDKSettings settings, IFBSDKAppEventsConfigurationProviding appEventsConfigurationProvider, IFBSDKAdvertiserIDProviding advertiserIDProvider, IFBSDKAppEventDropDetermining appEventsDropDeterminer, IFBSDKAppEventParametersExtracting appEventParametersExtractor, IFBSDKAppLinkURLCreating appLinkURLFactory, IFBSDKUserIDProviding userIDProvider, IFBSDKUserDataPersisting userDataStore);
	}
	

	// @protocol FBSDKAppStoreReceiptProviding
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
	interface FBSDKAppStoreReceiptProviding {
		// @required @property (readonly, copy) NSURL * _Nullable appStoreReceiptURL;
		[Abstract]
		[NullAllowed, Export ("appStoreReceiptURL", ArgumentSemantic.Copy)]
		NSUrl AppStoreReceiptURL { get; }
	}

	interface IFBSDKAppStoreReceiptProviding {
	}

	// @interface  (NSBundle) <FBSDKAppStoreReceiptProviding>
	[Category]
	[BaseType (typeof (NSBundle))]
	interface NSBundle_ : IFBSDKAppStoreReceiptProviding {
	}

	// @protocol FBSDKAppURLSchemeProviding
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
	interface FBSDKAppURLSchemeProviding {
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull appURLScheme;
		[Abstract]
		[Export ("appURLScheme")]
		string AppURLScheme { get; }

		// @required -(void)validateURLSchemes;
		[Abstract]
		[Export ("validateURLSchemes")]
		void ValidateURLSchemes ();
	}

	// @protocol FBSDKATEPublisherCreating
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
	interface FBSDKATEPublisherCreating {
		// @required -(id<FBSDKATEPublishing> _Nullable)createPublisherWithAppID:(NSString * _Nonnull)appID __attribute__((swift_name("createPublisher(appID:)")));
		[Abstract]
		[Export ("createPublisherWithAppID:")]
		[return: NullAllowed]
		IntPtr CreatePublisherWithAppID (string appID);
	}
	
	interface IFBSDKATEPublisherCreating {}

	// @interface FBSDKATEPublisherFactory : NSObject <FBSDKATEPublisherCreating>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKATEPublisherFactory : IFBSDKATEPublisherCreating {
		// @property (nonatomic) id<FBSDKDataPersisting> _Nonnull dataStore;
		[Export ("dataStore", ArgumentSemantic.Assign)]
		IFBSDKDataPersisting DataStore { get; set; }

		// @property (nonatomic) id<FBSDKGraphRequestFactory> _Nonnull graphRequestFactory;
		[Export ("graphRequestFactory", ArgumentSemantic.Assign)]
		IFBSDKGraphRequestFactory GraphRequestFactory { get; set; }

		// @property (nonatomic) id<FBSDKSettings> _Nonnull settings;
		[Export ("settings", ArgumentSemantic.Assign)]
		IFBSDKSettings Settings { get; set; }

		// @property (nonatomic) id<FBSDKDeviceInformationProviding> _Nonnull deviceInformationProvider;
		[Export ("deviceInformationProvider", ArgumentSemantic.Assign)]
		IFBSDKDeviceInformationProviding DeviceInformationProvider { get; set; }

		// -(instancetype _Nonnull)initWithDataStore:(id<FBSDKDataPersisting> _Nonnull)dataStore graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory settings:(id<FBSDKSettings> _Nonnull)settings deviceInformationProvider:(id<FBSDKDeviceInformationProviding> _Nonnull)deviceInformationProvider;
		[Export ("initWithDataStore:graphRequestFactory:settings:deviceInformationProvider:")]
		NativeHandle Constructor (IFBSDKDataPersisting dataStore, IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKSettings settings, IFBSDKDeviceInformationProviding deviceInformationProvider);
	}

	// @protocol FBSDKAuthenticationTokenProviding
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
	interface FBSDKAuthenticationTokenProviding {
		// @required @property (copy, nonatomic, class) NS_SWIFT_NAME(current) FBSDKAuthenticationToken * currentAuthenticationToken __attribute__((swift_name("current")));
		[Static, Abstract]
		[Export ("currentAuthenticationToken", ArgumentSemantic.Copy)]
		FBSDKAuthenticationToken CurrentAuthenticationToken { get; set; }

		// @required @property (copy, nonatomic, class) id<FBSDKTokenCaching> _Nullable tokenCache;
		[Static, Abstract]
		[NullAllowed, Export ("tokenCache", ArgumentSemantic.Copy)]
		IFBSDKTokenCaching TokenCache { get; set; }
	}
	
	interface IFBSDKAuthenticationTokenProviding {}
	
	[BaseType (typeof (NSObject))]
	interface FBSDKAuthenticationStatusUtility {
		// @property (nonatomic, class) Class<FBSDKProfileProviding> _Nullable profileSetter;
		[Static]
		[NullAllowed, Export ("profileSetter", ArgumentSemantic.Assign)]
		IFBSDKProfileProviding ProfileSetter { get; set; }

		// @property (nonatomic, class) id<FBSDKURLSessionProviding> _Nullable sessionDataTaskProvider;
		[Static]
		[NullAllowed, Export ("sessionDataTaskProvider", ArgumentSemantic.Assign)]
		FBSDKURLSessionProviding SessionDataTaskProvider { get; set; }

		// @property (nonatomic, class) Class<FBSDKAccessTokenProviding> _Nullable accessTokenWallet;
		[Static]
		[NullAllowed, Export ("accessTokenWallet", ArgumentSemantic.Assign)]
		IFBSDKAccessTokenProviding AccessTokenWallet { get; set; }

		// @property (nonatomic, class) Class<FBSDKAuthenticationTokenProviding> _Nullable authenticationTokenWallet;
		[Static]
		[NullAllowed, Export ("authenticationTokenWallet", ArgumentSemantic.Assign)]
		IFBSDKAuthenticationTokenProviding AuthenticationTokenWallet { get; set; }

		// +(void)configureWithProfileSetter:(Class<FBSDKProfileProviding> _Nonnull)profileSetter sessionDataTaskProvider:(id<FBSDKURLSessionProviding> _Nonnull)sessionDataTaskProvider accessTokenWallet:(Class<FBSDKAccessTokenProviding> _Nonnull)accessTokenWallet authenticationTokenWallet:(Class<FBSDKAuthenticationTokenProviding> _Nonnull)authenticationWallet __attribute__((swift_name("configure(profileSetter:sessionDataTaskProvider:accessTokenWallet:authenticationTokenWallet:)")));
		[Static]
		[Export ("configureWithProfileSetter:sessionDataTaskProvider:accessTokenWallet:authenticationTokenWallet:")]
		void ConfigureWithProfileSetter (IFBSDKProfileProviding profileSetter, FBSDKURLSessionProviding sessionDataTaskProvider, IFBSDKAccessTokenProviding accessTokenWallet, IFBSDKAuthenticationTokenProviding authenticationWallet);

		// +(void)checkAuthenticationStatus;
		[Static]
		[Export ("checkAuthenticationStatus")]
		void CheckAuthenticationStatus ();
	}

	// @interface FBSDKAuthenticationToken : NSObject <NSCopying, NSObject, NSSecureCoding, FBSDKAuthenticationTokenProviding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAuthenticationToken : INSCopying, INSSecureCoding, IFBSDKAuthenticationTokenProviding {
		// -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString nonce:(NSString * _Nonnull)nonce graphDomain:(NSString * _Nonnull)graphDomain;
		[Export ("initWithTokenString:nonce:graphDomain:")]
		NativeHandle Constructor (string tokenString, string nonce, string graphDomain);

		// @property (copy, nonatomic, class) NS_SWIFT_NAME(current) FBSDKAuthenticationToken * currentAuthenticationToken __attribute__((swift_name("current")));
		[Static]
		[Export ("currentAuthenticationToken", ArgumentSemantic.Copy)]
		FBSDKAuthenticationToken CurrentAuthenticationToken { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
		[Export ("tokenString")]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
		[Export ("nonce")]
		string Nonce { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull graphDomain;
		[Export ("graphDomain")]
		string GraphDomain { get; }

		// -(FBSDKAuthenticationTokenClaims * _Nullable)claims;
		[NullAllowed, Export ("claims")]
		FBSDKAuthenticationTokenClaims Claims { get; }

		// @property (copy, nonatomic, class) id<FBSDKTokenCaching> _Nullable tokenCache;
		[Static]
		[NullAllowed, Export ("tokenCache", ArgumentSemantic.Copy)]
		IFBSDKTokenCaching TokenCache { get; set; }
	}

	// @protocol FBSDKBridgeAPIProtocol <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKBridgeAPIProtocol {
		// @required -(NSURL * _Nullable)requestURLWithActionID:(NSString * _Nonnull)actionID scheme:(NSString * _Nonnull)scheme methodName:(NSString * _Nonnull)methodName parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("requestURL(actionID:scheme:methodName:parameters:)")));
		[Abstract]
		[Export ("requestURLWithActionID:scheme:methodName:parameters:error:")]
		[return: NullAllowed]
		NSUrl RequestURLWithActionID (string actionID, string scheme, string methodName, NSDictionary<NSString, NSObject> parameters, [NullAllowed] out NSError errorRef);

		// @required -(NSDictionary<NSString *,id> * _Nullable)responseParametersForActionID:(NSString * _Nonnull)actionID queryParameters:(NSDictionary<NSString *,id> * _Nonnull)queryParameters cancelled:(BOOL * _Nullable)cancelledRef error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("responseParameters(actionID:queryParameters:cancelled:)")));
		[Abstract]
		[Export ("responseParametersForActionID:queryParameters:cancelled:error:")]
		[return: NullAllowed]
		unsafe NSDictionary<NSString, NSObject> ResponseParametersForActionID (string actionID, NSDictionary<NSString, NSObject> queryParameters, [NullAllowed] IntPtr cancelledRef, [NullAllowed] out NSError errorRef);
	}

	// @protocol FBSDKBridgeAPIRequest <NSObject, NSCopying>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKBridgeAPIRequest : INSCopying {
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull scheme;
		[Abstract]
		[Export ("scheme")]
		string Scheme { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull actionID;
		[Abstract]
		[Export ("actionID")]
		string ActionID { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable methodName;
		[Abstract]
		[NullAllowed, Export ("methodName")]
		string MethodName { get; }

		// @required @property (readonly, assign, nonatomic) FBSDKBridgeAPIProtocolType protocolType;
		[Abstract]
		[Export ("protocolType", ArgumentSemantic.Assign)]
		FBSDKBridgeAPIProtocolType ProtocolType { get; }

		// @required @property (readonly, nonatomic, strong) id<FBSDKBridgeAPIProtocol> _Nullable protocol;
		[Abstract]
		[NullAllowed, Export ("protocol", ArgumentSemantic.Strong)]
		FBSDKBridgeAPIProtocol Protocol { get; }

		// @required -(NSURL * _Nullable)requestURL:(NSError * _Nullable * _Nullable)errorRef;
		[Abstract]
		[Export ("requestURL:")]
		[return: NullAllowed]
		NSUrl RequestURL ([NullAllowed] out NSError errorRef);
	}
	
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
	interface FBSDKBridgeAPIRequestCreating {
		// @required -(id<FBSDKBridgeAPIRequest> _Nullable)bridgeAPIRequestWithProtocolType:(FBSDKBridgeAPIProtocolType)protocolType scheme:(NSString * _Nonnull)scheme methodName:(NSString * _Nullable)methodName parameters:(NSDictionary<NSString *,id> * _Nullable)parameters userInfo:(NSDictionary<NSString *,id> * _Nullable)userInfo;
		[Abstract]
		[Export ("bridgeAPIRequestWithProtocolType:scheme:methodName:parameters:userInfo:")]
		[return: NullAllowed]
		FBSDKBridgeAPIRequest Scheme (FBSDKBridgeAPIProtocolType protocolType, string scheme, [NullAllowed] string methodName, [NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] NSDictionary<NSString, NSObject> userInfo);
	}

	// typedef void (^FBSDKBridgeAPIResponseBlock)(FBSDKBridgeAPIResponse * _Nonnull);
	delegate void FBSDKBridgeAPIResponseBlock (FBSDKBridgeAPIResponse arg0);

	// @interface FBSDKBridgeAPIResponse : NSObject <NSCopying, NSObject>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKBridgeAPIResponse : INSCopying {
		// +(instancetype _Nonnull)bridgeAPIResponseWithRequest:(NSObject<FBSDKBridgeAPIRequest> * _Nonnull)request error:(NSError * _Nullable)error;
		[Static]
		[Export ("bridgeAPIResponseWithRequest:error:")]
		FBSDKBridgeAPIResponse BridgeAPIResponseWithRequest (FBSDKBridgeAPIRequest request, [NullAllowed] NSError error);

		// +(instancetype _Nullable)bridgeAPIResponseWithRequest:(NSObject<FBSDKBridgeAPIRequest> * _Nonnull)request responseURL:(NSURL * _Nonnull)responseURL sourceApplication:(NSString * _Nullable)sourceApplication error:(NSError * _Nullable * _Nullable)errorRef;
		[Static]
		[Export ("bridgeAPIResponseWithRequest:responseURL:sourceApplication:error:")]
		[return: NullAllowed]
		FBSDKBridgeAPIResponse BridgeAPIResponseWithRequest (FBSDKBridgeAPIRequest request, NSUrl responseURL, [NullAllowed] string sourceApplication, [NullAllowed] out NSError errorRef);

		// +(instancetype _Nonnull)bridgeAPIResponseCancelledWithRequest:(NSObject<FBSDKBridgeAPIRequest> * _Nonnull)request;
		[Static]
		[Export ("bridgeAPIResponseCancelledWithRequest:")]
		FBSDKBridgeAPIResponse BridgeAPIResponseCancelledWithRequest (FBSDKBridgeAPIRequest request);

		// @property (readonly, getter = isCancelled, assign, nonatomic) BOOL cancelled;
		[Export ("cancelled")]
		bool Cancelled { [Bind ("isCancelled")] get; }

		// @property (readonly, copy, nonatomic) NSError * _Nullable error;
		[NullAllowed, Export ("error", ArgumentSemantic.Copy)]
		NSError Error { get; }

		// @property (readonly, copy, nonatomic) NSObject<FBSDKBridgeAPIRequest> * _Nonnull request;
		[Export ("request", ArgumentSemantic.Copy)]
		FBSDKBridgeAPIRequest Request { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable responseParameters;
		[NullAllowed, Export ("responseParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ResponseParameters { get; }
	}
	
	delegate void FBSDKCodeBlock ();

	// typedef void (^FBSDKErrorBlock)(NSError * _Nullable);
	delegate void FBSDKErrorBlock ([NullAllowed] NSError arg0);

	// typedef void (^FBSDKSuccessBlock)(BOOL, NSError * _Nullable);
	delegate void FBSDKSuccessBlock (bool arg0, [NullAllowed] NSError arg1);
	
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
	interface FBSDKBridgeAPIRequestOpening {
		// @required -(void)openBridgeAPIRequest:(NSObject<FBSDKBridgeAPIRequest> * _Nonnull)request useSafariViewController:(BOOL)useSafariViewController fromViewController:(UIViewController * _Nullable)fromViewController completionBlock:(FBSDKBridgeAPIResponseBlock _Nonnull)completionBlock;
		[Abstract]
		[Export ("openBridgeAPIRequest:useSafariViewController:fromViewController:completionBlock:")]
		void OpenBridgeAPIRequest (FBSDKBridgeAPIRequest request, bool useSafariViewController, [NullAllowed] UIViewController fromViewController, FBSDKBridgeAPIResponseBlock completionBlock);

		// @required -(void)openURLWithSafariViewController:(NSURL * _Nonnull)url sender:(id<FBSDKURLOpening> _Nullable)sender fromViewController:(UIViewController * _Nullable)fromViewController handler:(FBSDKSuccessBlock _Nonnull)handler __attribute__((swift_name("openURLWithSafariViewController(url:sender:from:handler:)")));
		[Abstract]
		[Export ("openURLWithSafariViewController:sender:fromViewController:handler:")]
		void OpenURLWithSafariViewController (NSUrl url, [NullAllowed] FBSDKURLOpening sender, [NullAllowed] UIViewController fromViewController, FBSDKSuccessBlock handler);

		// @required -(void)openURL:(NSURL * _Nonnull)url sender:(id<FBSDKURLOpening> _Nullable)sender handler:(FBSDKSuccessBlock _Nonnull)handler;
		[Abstract]
		[Export ("openURL:sender:handler:")]
		void OpenURL (NSUrl url, [NullAllowed] FBSDKURLOpening sender, FBSDKSuccessBlock handler);
	}

	// @interface FBSDKImpressionLoggingButton : UIButton
	[BaseType (typeof (UIButton))]
	interface FBSDKImpressionLoggingButton {
		// +(void)configureWithImpressionLoggerFactory:(id<FBSDKImpressionLoggerFactory> _Nonnull)impressionLoggerFactory __attribute__((swift_name("configure(impressionLoggerFactory:)")));
		[Static]
		[Export ("configureWithImpressionLoggerFactory:")]
		void ConfigureWithImpressionLoggerFactory (IFBSDKImpressionLoggerFactory impressionLoggerFactory);
	}

	// @interface FBSDKButton : FBSDKImpressionLoggingButton
	[BaseType (typeof (FBSDKImpressionLoggingButton))]
	interface FBSDKButton {
		// @property (readonly, getter = isImplicitlyDisabled, nonatomic) BOOL implicitlyDisabled;
		[Export ("implicitlyDisabled")]
		bool ImplicitlyDisabled { [Bind ("isImplicitlyDisabled")] get; }

		// -(void)checkImplicitlyDisabled;
		[Export ("checkImplicitlyDisabled")]
		void CheckImplicitlyDisabled ();

		// -(void)configureWithIcon:(FBSDKIcon * _Nullable)icon title:(NSString * _Nullable)title backgroundColor:(UIColor * _Nullable)backgroundColor highlightedColor:(UIColor * _Nullable)highlightedColor;
		[Export ("configureWithIcon:title:backgroundColor:highlightedColor:")]
		void ConfigureWithIcon ([NullAllowed] FBSDKIcon icon, [NullAllowed] string title, [NullAllowed] UIColor backgroundColor, [NullAllowed] UIColor highlightedColor);

		// -(void)configureWithIcon:(FBSDKIcon * _Nullable)icon title:(NSString * _Nullable)title backgroundColor:(UIColor * _Nullable)backgroundColor highlightedColor:(UIColor * _Nullable)highlightedColor selectedTitle:(NSString * _Nullable)selectedTitle selectedIcon:(FBSDKIcon * _Nullable)selectedIcon selectedColor:(UIColor * _Nullable)selectedColor selectedHighlightedColor:(UIColor * _Nullable)selectedHighlightedColor;
		[Export ("configureWithIcon:title:backgroundColor:highlightedColor:selectedTitle:selectedIcon:selectedColor:selectedHighlightedColor:")]
		void ConfigureWithIcon ([NullAllowed] FBSDKIcon icon, [NullAllowed] string title, [NullAllowed] UIColor backgroundColor, [NullAllowed] UIColor highlightedColor, [NullAllowed] string selectedTitle, [NullAllowed] FBSDKIcon selectedIcon, [NullAllowed] UIColor selectedColor, [NullAllowed] UIColor selectedHighlightedColor);

		// -(UIColor * _Nonnull)defaultBackgroundColor;
		[Export ("defaultBackgroundColor")]
		UIColor DefaultBackgroundColor { get; }

		// -(CGSize)sizeThatFits:(CGSize)size title:(NSString * _Nonnull)title;
		[Export ("sizeThatFits:title:")]
		CGSize SizeThatFits (CGSize size, string title);

		// -(CGSize)textSizeForText:(NSString * _Nonnull)text font:(UIFont * _Nonnull)font constrainedSize:(CGSize)constrainedSize lineBreakMode:(NSLineBreakMode)lineBreakMode;
		[Export ("textSizeForText:font:constrainedSize:lineBreakMode:")]
		CGSize TextSizeForText (string text, UIFont font, CGSize constrainedSize, UILineBreakMode lineBreakMode);
		
		// -(void)logTapEventWithEventName:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Export ("logTapEventWithEventName:parameters:")]
		void LogTapEventWithEventName (string eventName, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// +(void)configureWithApplicationActivationNotifier:(id _Nonnull)applicationActivationNotifier eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger accessTokenProvider:(Class<FBSDKAccessTokenProviding> _Nonnull)accessTokenProvider __attribute__((swift_name("configure(applicationActivationNotifier:eventLogger:accessTokenProvider:)")));
		[Static]
		[Export ("configureWithApplicationActivationNotifier:eventLogger:accessTokenProvider:")]
		void ConfigureWithApplicationActivationNotifier (NSObject applicationActivationNotifier, IFBSDKEventLogging eventLogger, IFBSDKAccessTokenProviding accessTokenProvider);
	}

	// @protocol FBSDKButtonImpressionLogging <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKButtonImpressionLogging {
		// @required @property (readonly, copy, nonatomic) NSDictionary<FBSDKAppEventParameterName,id> * _Nullable analyticsParameters;
		[Abstract]
		[NullAllowed, Export ("analyticsParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AnalyticsParameters { get; }

		// @required @property (readonly, copy, nonatomic) FBSDKAppEventName _Nonnull impressionTrackingEventName;
		[Abstract]
		[Export ("impressionTrackingEventName")]
		string ImpressionTrackingEventName { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull impressionTrackingIdentifier;
		[Abstract]
		[Export ("impressionTrackingIdentifier")]
		string ImpressionTrackingIdentifier { get; }
	}

	// @protocol FBSDKClientTokenProviding
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
	interface FBSDKClientTokenProviding {
		// @required @property (readonly, copy, nonatomic) NSString * _Nullable clientToken;
		[Abstract]
		[NullAllowed, Export ("clientToken")]
		string ClientToken { get; }
	}
	
	interface IFBSDKClientTokenProviding  {}

	// @protocol FBSDKCodelessIndexing
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
	interface FBSDKCodelessIndexing {
		// @required +(void)enable;
		[Static, Abstract]
		[Export ("enable")]
		void Enable ();
	}

	interface IFBSDKCodelessIndexing {
	}

	// typedef void (^FBSDKCodelessSettingLoadBlock)(BOOL, NSError * _Nullable);
	delegate void FBSDKCodelessSettingLoadBlock (bool arg0, [NullAllowed] NSError arg1);

	// @interface FBSDKCodelessIndexer : NSObject <FBSDKCodelessIndexing>
	[BaseType (typeof (NSObject))]
	interface FBSDKCodelessIndexer : IFBSDKCodelessIndexing {
		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull extInfo;
		[Static]
		[Export ("extInfo")]
		string ExtInfo { get; }

		// +(void)enable;
		[Static]
		[Export ("enable")]
		void Enable ();

		// +(void)configureWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory serverConfigurationProvider:(id<FBSDKServerConfigurationProviding> _Nonnull)serverConfigurationProvider dataStore:(id<FBSDKDataPersisting> _Nonnull)dataStore graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)graphRequestConnectionFactory swizzler:(Class<FBSDKSwizzling> _Nonnull)swizzler settings:(id<FBSDKSettings> _Nonnull)settings advertiserIDProvider:(id<FBSDKAdvertiserIDProviding> _Nonnull)advertisingIDProvider __attribute__((swift_name("configure(graphRequestFactory:serverConfigurationProvider:dataStore:graphRequestConnectionFactory:swizzler:settings:advertiserIDProvider:)")));
		[Static]
		[Export ("configureWithGraphRequestFactory:serverConfigurationProvider:dataStore:graphRequestConnectionFactory:swizzler:settings:advertiserIDProvider:")]
		void ConfigureWithGraphRequestFactory (IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKServerConfigurationProviding serverConfigurationProvider, IFBSDKDataPersisting dataStore, IFBSDKGraphRequestConnectionFactory graphRequestConnectionFactory, IFBSDKSwizzling swizzler, IFBSDKSettings settings, IFBSDKAdvertiserIDProviding advertisingIDProvider);
	}

	// @protocol FBSDKContainerViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface FBSDKContainerViewControllerDelegate {
		// @required -(void)viewControllerDidDisappear:(FBSDKContainerViewController * _Nonnull)viewController animated:(BOOL)animated;
		[Abstract]
		[Export ("viewControllerDidDisappear:animated:")]
		void Animated (FBSDKContainerViewController viewController, bool animated);
	}

	// @interface FBSDKContainerViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface FBSDKContainerViewController {
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		FBSDKContainerViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<FBSDKContainerViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)displayChildController:(UIViewController * _Nonnull)childController;
		[Export ("displayChildController:")]
		void DisplayChildController (UIViewController childController);
	}

	// @protocol FBSDKConversionValueUpdating
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
	interface FBSDKConversionValueUpdating {
		// @required +(void)updateConversionValue:(NSInteger)conversionValue;
		[Static, Abstract]
		[Export ("updateConversionValue:")]
		void UpdateConversionValue (nint conversionValue);

		// @required +(void)updateCoarseConversionValue:(NSString * _Nonnull)coarseConversionValue;
		[Static, Abstract]
		[Export ("updateCoarseConversionValue:")]
		void UpdateCoarseConversionValue (string coarseConversionValue);

		// @required +(void)updatePostbackConversionValue:(NSInteger)conversionValue completionHandler:(void (^ _Nullable)(NSError * _Nullable))completion __attribute__((availability(ios, introduced=15.4)));
		[Static, Abstract]
		[Export ("updatePostbackConversionValue:completionHandler:")]
		void UpdatePostbackConversionValue (nint conversionValue, [NullAllowed] Action<NSError> completion);

		// @required +(void)updatePostbackConversionValue:(NSInteger)fineValue coarseValue:(SKAdNetworkCoarseConversionValue _Nonnull)coarseValue completionHandler:(void (^ _Nullable)(NSError * _Nullable))completion __attribute__((availability(ios, introduced=16.1)
		[Static, Abstract]
		[Export ("updatePostbackConversionValue:coarseValue:completionHandler:")]
		void UpdatePostbackConversionValue (nint fineValue, string coarseValue, [NullAllowed] Action<NSError> completion);

		// @required +(void)updatePostbackConversionValue:(NSInteger)fineValue coarseValue:(SKAdNetworkCoarseConversionValue _Nonnull)coarseValue lockWindow:(BOOL)lockWindow completionHandler:(void (^ _Nullable)(NSError * _Nullable))completion __attribute__((availability(ios, introduced=16.1)));
		[Static, Abstract]
		[Export ("updatePostbackConversionValue:coarseValue:lockWindow:completionHandler:")]
		void UpdatePostbackConversionValue (nint fineValue, string coarseValue, bool lockWindow, [NullAllowed] Action<NSError> completion);
	}

	interface IFBSDKConversionValueUpdating {
	}

	// @interface ConversionValueUpdating (SKAdNetwork) <FBSDKConversionValueUpdating>
	[Category]
	[BaseType (typeof (SKAdNetwork))]
	interface SKAdNetwork_ConversionValueUpdating : IFBSDKConversionValueUpdating {
	}

	// @interface FBSDKCrashObserver : NSObject <FBSDKCrashObserving>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKCrashObserver : IFBSDKCrashObserving {
		// -(instancetype _Nonnull)initWithFeatureChecker:(id<FBSDKFeatureChecking> _Nonnull)featureChecker graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory settings:(id<FBSDKSettings> _Nonnull)settings crashHandler:(id<FBSDKCrashHandler> _Nonnull)crashHandler __attribute__((swift_name("init(featureChecker:graphRequestFactory:settings:crashHandler:)")));
		[Export ("initWithFeatureChecker:graphRequestFactory:settings:crashHandler:")]
		NativeHandle Constructor (IFBSDKFeatureChecking featureChecker, IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKSettings settings, FBSDKCrashHandler crashHandler);
	}

	// @interface FBSDKCrashShield : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKCrashShield {
		// +(void)analyze:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)crashLogs;
		[Static]
		[Export ("analyze:")]
		void Analyze (NSDictionary<NSString, NSObject> [] crashLogs);

		// +(void)configureWithSettings:(id<FBSDKSettings> _Nonnull)settings graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory featureChecking:(id<FBSDKFeatureChecking,FBSDKFeatureDisabling> _Nonnull)featureChecking __attribute__((swift_name("configure(settings:graphRequestFactory:featureChecking:)")));
		[Static]
		[Export ("configureWithSettings:graphRequestFactory:featureChecking:")]
		void ConfigureWithSettings (IFBSDKSettings settings, IFBSDKGraphRequestFactory graphRequestFactory, NSObject featureChecking);
	}
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKDialogConfiguration : INSCopying, INSSecureCoding {
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name URL:(NSURL * _Nonnull)URL appVersions:(NSArray<id> * _Nonnull)appVersions __attribute__((objc_designated_initializer));
		[Export ("initWithName:URL:appVersions:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string name, NSUrl URL, NSObject [] appVersions);

		// @property (readonly, copy, nonatomic) NSArray<id> * _Nonnull appVersions;
		[Export ("appVersions", ArgumentSemantic.Copy)]
		NSObject [] AppVersions { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nonnull URL;
		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl URL { get; }
	}
	
	// @interface FBSDKAuthenticationTokenClaims : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FBSDKAuthenticationTokenClaims
	{
		// -(instancetype _Nullable)initWithEncodedClaims:(NSString * _Nonnull)encodedClaims nonce:(NSString * _Nonnull)expectedNonce;
		[Export ("initWithEncodedClaims:nonce:")]
		NativeHandle Constructor (string encodedClaims, string expectedNonce);
	}

	// @protocol FBSDKDialogConfigurationMapBuilding
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
	interface FBSDKDialogConfigurationMapBuilding {
		// @required -(NSDictionary<NSString *,FBSDKDialogConfiguration *> * _Nonnull)buildDialogConfigurationMapWithRawConfigurations:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)rawConfigurations __attribute__((swift_name("buildDialogConfigurationMap(from:)")));
		[Abstract]
		[Export ("buildDialogConfigurationMapWithRawConfigurations:")]
		NSDictionary<NSString, FBSDKDialogConfiguration> BuildDialogConfigurationMapWithRawConfigurations (NSDictionary<NSString, NSObject> [] rawConfigurations);
	}
	
	interface IFBSDKDialogConfigurationMapBuilding {}

	// @interface FBSDKDynamicFrameworkLoaderProxy : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKDynamicFrameworkLoaderProxy {
		// +(CFTypeRef _Nonnull)loadkSecAttrAccessibleAfterFirstUnlockThisDeviceOnly;
		[Static]
		[Export ("loadkSecAttrAccessibleAfterFirstUnlockThisDeviceOnly")]
		IntPtr LoadkSecAttrAccessibleAfterFirstUnlockThisDeviceOnly { get; }
	}

	// @protocol FBSDKErrorConfiguration
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
	interface FBSDKErrorConfiguration {
		// @required -(FBSDKErrorRecoveryConfiguration * _Nullable)recoveryConfigurationForCode:(NSString * _Nullable)code subcode:(NSString * _Nullable)subcode request:(id<FBSDKGraphRequest> _Nonnull)request;
		[Abstract]
		[Export ("recoveryConfigurationForCode:subcode:request:")]
		[return: NullAllowed]
		FBSDKErrorRecoveryConfiguration Subcode ([NullAllowed] string code, [NullAllowed] string subcode, IFBSDKGraphRequestProtocol request);
	}
	
	interface IFBSDKErrorConfiguration {}

	// @protocol FBSDKDecodableErrorConfiguration <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKDecodableErrorConfiguration {
		// @required -(instancetype _Nonnull)initWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary;
		[Export ("initWithDictionary:")]
		NativeHandle Constructor (NSDictionary<NSString, NSObject> dictionary);

		// @required -(void)updateWithArray:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)array;
		[Abstract]
		[Export ("updateWithArray:")]
		void UpdateWithArray (NSDictionary<NSString, NSObject> [] array);
	}

	// @interface FBSDKErrorConfigurationProvider : NSObject <FBSDKErrorConfigurationProviding>
	[BaseType (typeof (NSObject))]
	interface FBSDKErrorConfigurationProvider : IFBSDKErrorConfigurationProviding {
	}

	// @protocol FBSDKErrorCreating
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
	interface FBSDKErrorCreating {
		// @required -(NSError * _Nonnull)errorWithCode:(NSInteger)code userInfo:(NSDictionary<NSErrorUserInfoKey,id> * _Nullable)userInfo message:(NSString * _Nullable)message underlyingError:(NSError * _Nullable)underlyingError __attribute__((swift_name("error(code:userInfo:message:underlyingError:)")));
		[Abstract]
		[Export ("errorWithCode:userInfo:message:underlyingError:")]
		NSError ErrorWithCode (nint code, [NullAllowed] NSDictionary<NSString, NSObject> userInfo, [NullAllowed] string message, [NullAllowed] NSError underlyingError);

		// @required -(NSError * _Nonnull)errorWithDomain:(NSErrorDomain _Nonnull)domain code:(NSInteger)code userInfo:(NSDictionary<NSErrorUserInfoKey,id> * _Nullable)userInfo message:(NSString * _Nullable)message underlyingError:(NSError * _Nullable)underlyingError __attribute__((swift_name("error(domain:code:userInfo:message:underlyingError:)")));
		[Abstract]
		[Export ("errorWithDomain:code:userInfo:message:underlyingError:")]
		NSError ErrorWithDomain (string domain, nint code, [NullAllowed] NSDictionary<NSString, NSObject> userInfo, [NullAllowed] string message, [NullAllowed] NSError underlyingError);

		// @required -(NSError * _Nonnull)invalidArgumentErrorWithName:(NSString * _Nonnull)name value:(id _Nullable)value message:(NSString * _Nullable)message underlyingError:(NSError * _Nullable)underlyingError __attribute__((swift_name("invalidArgumentError(name:value:message:underlyingError:)")));
		[Abstract]
		[Export ("invalidArgumentErrorWithName:value:message:underlyingError:")]
		NSError InvalidArgumentErrorWithName (string name, [NullAllowed] NSObject value, [NullAllowed] string message, [NullAllowed] NSError underlyingError);

		// @required -(NSError * _Nonnull)invalidArgumentErrorWithDomain:(NSErrorDomain _Nonnull)domain name:(NSString * _Nonnull)name value:(id _Nullable)value message:(NSString * _Nullable)message underlyingError:(NSError * _Nullable)underlyingError __attribute__((swift_name("invalidArgumentError(domain:name:value:message:underlyingError:)")));
		[Abstract]
		[Export ("invalidArgumentErrorWithDomain:name:value:message:underlyingError:")]
		NSError InvalidArgumentErrorWithDomain (string domain, string name, [NullAllowed] NSObject value, [NullAllowed] string message, [NullAllowed] NSError underlyingError);

		// @required -(NSError * _Nonnull)requiredArgumentErrorWithName:(NSString * _Nonnull)name message:(NSString * _Nullable)message underlyingError:(NSError * _Nullable)underlyingError __attribute__((swift_name("requiredArgumentError(name:message:underlyingError:)")));
		[Abstract]
		[Export ("requiredArgumentErrorWithName:message:underlyingError:")]
		NSError RequiredArgumentErrorWithName (string name, [NullAllowed] string message, [NullAllowed] NSError underlyingError);

		// @required -(NSError * _Nonnull)requiredArgumentErrorWithDomain:(NSErrorDomain _Nonnull)domain name:(NSString * _Nonnull)name message:(NSString * _Nullable)message underlyingError:(NSError * _Nullable)underlyingError __attribute__((swift_name("requiredArgumentError(domain:name:message:underlyingError:)")));
		[Abstract]
		[Export ("requiredArgumentErrorWithDomain:name:message:underlyingError:")]
		NSError RequiredArgumentErrorWithDomain (string domain, string name, [NullAllowed] string message, [NullAllowed] NSError underlyingError);

		// @required -(NSError * _Nonnull)unknownErrorWithMessage:(NSString * _Nullable)message userInfo:(NSDictionary<NSErrorUserInfoKey,id> * _Nullable)userInfo __attribute__((swift_name("unknownError(message:userInfo:)")));
		[Abstract]
		[Export ("unknownErrorWithMessage:userInfo:")]
		NSError UnknownErrorWithMessage ([NullAllowed] string message, [NullAllowed] NSDictionary<NSString, NSObject> userInfo);
	}

	interface IFBSDKErrorCreating {
	}

	// @protocol FBSDKErrorRecoveryAttempting
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
	interface FBSDKErrorRecoveryAttempting {
		// @required -(void)attemptRecoveryFromError:(NSError * _Nonnull)error completionHandler:(void (^ _Nonnull)(BOOL))completionHandler __attribute__((swift_name("attemptRecovery(from:completion:)")));
		[Abstract]
		[Export ("attemptRecoveryFromError:completionHandler:")]
		void CompletionHandler (NSError error, Action<bool> completionHandler);
	}

	// @interface FBSDKErrorRecoveryConfiguration : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKErrorRecoveryConfiguration : INSCopying, INSSecureCoding {
		// @property (readonly, nonatomic) NSString * _Nonnull localizedRecoveryDescription;
		[Export ("localizedRecoveryDescription")]
		string LocalizedRecoveryDescription { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull localizedRecoveryOptionDescriptions;
		[Export ("localizedRecoveryOptionDescriptions")]
		string [] LocalizedRecoveryOptionDescriptions { get; }

		// @property (readonly, nonatomic) FBSDKGraphRequestError errorCategory;
		[Export ("errorCategory")]
		FBSDKGraphRequestError ErrorCategory { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull recoveryActionName;
		[Export ("recoveryActionName")]
		string RecoveryActionName { get; }

		// -(instancetype _Nonnull)initWithRecoveryDescription:(NSString * _Nonnull)description optionDescriptions:(NSArray<NSString *> * _Nonnull)optionDescriptions category:(FBSDKGraphRequestError)category recoveryActionName:(NSString * _Nonnull)recoveryActionName __attribute__((objc_designated_initializer));
		[Export ("initWithRecoveryDescription:optionDescriptions:category:recoveryActionName:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string description, string [] optionDescriptions, FBSDKGraphRequestError category, string recoveryActionName);
	}

	// @protocol FBSDKErrorReporting
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
	interface FBSDKErrorReporting {
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();

		// @required -(void)saveError:(NSInteger)errorCode errorDomain:(NSErrorDomain _Nonnull)errorDomain message:(NSString * _Nullable)message;
		[Abstract]
		[Export ("saveError:errorDomain:message:")]
		void SaveError (nint errorCode, string errorDomain, [NullAllowed] string message);
	}
	
	interface IFBSDKErrorReporting {}

	// @interface FBSDKErrorReporter : NSObject <FBSDKErrorReporting>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKErrorReporter : IFBSDKErrorReporting {
		// @property (readonly, nonatomic, class) FBSDKErrorReporter * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKErrorReporter Shared { get; }

		// @property (nonatomic, strong) id<FBSDKGraphRequestFactory> _Nonnull graphRequestFactory;
		[Export ("graphRequestFactory", ArgumentSemantic.Strong)]
		IFBSDKGraphRequestFactory GraphRequestFactory { get; set; }

		// @property (nonatomic, strong) id<FBSDKFileManaging> _Nonnull fileManager;
		[Export ("fileManager", ArgumentSemantic.Strong)]
		IFBSDKFileManaging FileManager { get; set; }

		// @property (nonatomic, strong) id<FBSDKSettings> _Nonnull settings;
		[Export ("settings", ArgumentSemantic.Strong)]
		IFBSDKSettings Settings { get; set; }

		// @property (nonatomic, strong) Class<FBSDKFileDataExtracting> _Nonnull dataExtractor;
		[Export ("dataExtractor", ArgumentSemantic.Strong)]
		IFBSDKFileDataExtracting DataExtractor { get; set; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull directoryPath;
		[Export ("directoryPath", ArgumentSemantic.Strong)]
		string DirectoryPath { get; }

		// @property (nonatomic) BOOL isEnabled;
		[Export ("isEnabled")]
		bool IsEnabled { get; set; }

		// -(void)saveError:(NSInteger)errorCode errorDomain:(NSErrorDomain _Nonnull)errorDomain message:(NSString * _Nullable)message;
		[Export ("saveError:errorDomain:message:")]
		void SaveError (nint errorCode, string errorDomain, [NullAllowed] string message);

		// -(instancetype _Nonnull)initWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory fileManager:(id<FBSDKFileManaging> _Nonnull)fileManager settings:(id<FBSDKSettings> _Nonnull)settings fileDataExtractor:(Class<FBSDKFileDataExtracting> _Nonnull)dataExtractor;
		[Export ("initWithGraphRequestFactory:fileManager:settings:fileDataExtractor:")]
		NativeHandle Constructor (IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKFileManaging fileManager, IFBSDKSettings settings, IFBSDKFileDataExtracting dataExtractor);

		// -(void)enable;
		[Export ("enable")]
		void Enable ();
	}

	// @protocol FBSDKEventProcessing
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
	interface FBSDKEventProcessing {
		// @required -(NSString * _Nonnull)processSuggestedEvents:(NSString * _Nonnull)textFeature denseData:(float * _Nullable)denseData;
		[Abstract]
		[Export ("processSuggestedEvents:denseData:")]
		unsafe string ProcessSuggestedEvents (string textFeature, [NullAllowed] IntPtr denseData);

		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();
	}
	interface IFBSDKEventProcessing {}

	// typedef void (^FBSDKFeatureManagerBlock)(BOOL);
	delegate void FBSDKFeatureManagerBlock (bool arg0);

	// @protocol FBSDKFeatureChecking
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
	interface FBSDKFeatureChecking {
		// @required -(BOOL)isEnabled:(FBSDKFeature)feature;
		[Abstract]
		[Export ("isEnabled:")]
		bool IsEnabled (FBSDKFeature feature);

		// @required -(void)checkFeature:(FBSDKFeature)feature completionBlock:(FBSDKFeatureManagerBlock _Nonnull)completionBlock;
		[Abstract]
		[Export ("checkFeature:completionBlock:")]
		void CheckFeature (FBSDKFeature feature, FBSDKFeatureManagerBlock completionBlock);
	}
	
	interface IFBSDKFeatureChecking {}

	// @protocol FBSDKFeatureDisabling
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
	interface FBSDKFeatureDisabling {
		// @required -(void)disableFeature:(FBSDKFeature)feature;
		[Abstract]
		[Export ("disableFeature:")]
		void DisableFeature (FBSDKFeature feature);
	}
	
	interface IFBSDKFeatureDisabling {}

	// @protocol FBSDKFeatureExtracting
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
	interface FBSDKFeatureExtracting {
		// @required +(float * _Nullable)getDenseFeatures:(NSDictionary<NSString *,id> * _Nonnull)viewHierarchy;
		[Static, Abstract]
		[Export ("getDenseFeatures:")]
		[return: NullAllowed]
		IntPtr GetDenseFeatures (NSDictionary<NSString, NSObject> viewHierarchy);

		// @required +(NSString * _Nonnull)getTextFeature:(NSString * _Nonnull)text withScreenName:(NSString * _Nonnull)screenName;
		[Static, Abstract]
		[Export ("getTextFeature:withScreenName:")]
		string GetTextFeature (string text, string screenName);

		// @required +(void)loadRulesForKey:(NSString * _Nonnull)useCaseKey;
		[Static, Abstract]
		[Export ("loadRulesForKey:")]
		void LoadRulesForKey (string useCaseKey);
	}

	interface IFBSDKFeatureExtracting {
	}

	// @protocol FBSDKRulesFromKeyProvider
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
	interface FBSDKRulesFromKeyProvider {
		// @required -(NSDictionary<NSString *,id> * _Nullable)getRulesForKey:(NSString * _Nonnull)useCase;
		[Abstract]
		[Export ("getRulesForKey:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> GetRulesForKey (string useCase);
	}
	
	interface IFBSDKRulesFromKeyProvider {}

	// @interface FBSDKFeatureExtractor : NSObject <FBSDKFeatureExtracting>
	[BaseType (typeof (NSObject))]
	interface FBSDKFeatureExtractor : IFBSDKFeatureExtracting {
		// @property (nonatomic, class) id<FBSDKRulesFromKeyProvider> _Nullable rulesFromKeyProvider;
		[Static]
		[NullAllowed, Export ("rulesFromKeyProvider", ArgumentSemantic.Assign)]
		IFBSDKRulesFromKeyProvider RulesFromKeyProvider { get; set; }

		// +(void)configureWithRulesFromKeyProvider:(id<FBSDKRulesFromKeyProvider> _Nonnull)rulesFromKeyProvider __attribute__((swift_name("configure(rulesFromKeyProvider:)")));
		[Static]
		[Export ("configureWithRulesFromKeyProvider:")]
		void ConfigureWithRulesFromKeyProvider (IFBSDKRulesFromKeyProvider rulesFromKeyProvider);

		// +(void)loadRulesForKey:(NSString * _Nonnull)useCaseKey;
		[Static]
		[Export ("loadRulesForKey:")]
		void LoadRulesForKey (string useCaseKey);

		// +(NSString * _Nonnull)getTextFeature:(NSString * _Nonnull)text withScreenName:(NSString * _Nonnull)screenName;
		[Static]
		[Export ("getTextFeature:withScreenName:")]
		string GetTextFeature (string text, string screenName);

		// +(float * _Nullable)getDenseFeatures:(NSDictionary<NSString *,id> * _Nonnull)viewHierarchy;
		[Static]
		[Export ("getDenseFeatures:")]
		[return: NullAllowed]
		 IntPtr GetDenseFeatures (NSDictionary<NSString, NSObject> viewHierarchy);
	}

	// typedef void (^FBSDKGKManagerBlock)(NSError * _Nullable);
	delegate void FBSDKGKManagerBlock ([NullAllowed] NSError arg0);

	// @protocol FBSDKGateKeeperManaging
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
	interface FBSDKGateKeeperManaging {
		// @required +(BOOL)boolForKey:(NSString * _Nonnull)key defaultValue:(BOOL)defaultValue;
		[Static, Abstract]
		[Export ("boolForKey:defaultValue:")]
		bool BoolForKey (string key, bool defaultValue);

		// @required +(void)loadGateKeepers:(FBSDKGKManagerBlock _Nonnull)completionBlock;
		[Static, Abstract]
		[Export ("loadGateKeepers:")]
		void LoadGateKeepers (FBSDKGKManagerBlock completionBlock);
	}

	interface IFBSDKGateKeeperManaging { }

	// typedef void (^FBSDKGKManagerBlock)(NSError * _Nullable);
	// delegate void FBSDKGKManagerBlock ([NullAllowed] NSError arg0);

	// @interface FBSDKGateKeeperManager : NSObject <FBSDKGateKeeperManaging>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKGateKeeperManager : IFBSDKGateKeeperManaging {
		// +(void)configureWithSettings:(id<FBSDKSettings> _Nonnull)settings graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)graphRequestConnectionFactory store:(id<FBSDKDataPersisting> _Nonnull)store __attribute__((swift_name("configure(settings:graphRequestFactory:graphRequestConnectionFactory:store:)")));
		[Static]
		[Export ("configureWithSettings:graphRequestFactory:graphRequestConnectionFactory:store:")]
		void ConfigureWithSettings (IFBSDKSettings settings, IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKGraphRequestConnectionFactory graphRequestConnectionFactory, IFBSDKDataPersisting store);

		// +(BOOL)boolForKey:(NSString * _Nonnull)key defaultValue:(BOOL)defaultValue;
		[Static]
		[Export ("boolForKey:defaultValue:")]
		bool BoolForKey (string key, bool defaultValue);

		// +(void)loadGateKeepers:(FBSDKGKManagerBlock _Nullable)completionBlock;
		[Static]
		[Export ("loadGateKeepers:")]
		void LoadGateKeepers ([NullAllowed] FBSDKGKManagerBlock completionBlock);
	}

	// @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface FBSDKGraphErrorRecoveryProcessorDelegate {
		// @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor * _Nonnull)processor didRecover:(BOOL)didRecover error:(NSError * _Nullable)error;
		[Abstract]
		[Export ("processorDidAttemptRecovery:didRecover:error:")]
		void ProcessorDidAttemptRecovery (FBSDKGraphErrorRecoveryProcessor processor, bool didRecover, [NullAllowed] NSError error);

		// @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor * _Nonnull)processor error:(NSError * _Nullable)error;
		[Export ("processorWillProcessError:error:")]
		bool ProcessorWillProcessError (FBSDKGraphErrorRecoveryProcessor processor, [NullAllowed] NSError error);
	}

	// @interface FBSDKGraphErrorRecoveryProcessor : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKGraphErrorRecoveryProcessor {
		// -(instancetype _Nonnull)initWithAccessTokenString:(NSString * _Nonnull)accessTokenString;
		[Export ("initWithAccessTokenString:")]
		NativeHandle Constructor (string accessTokenString);

		// -(BOOL)processError:(NSError * _Nonnull)error request:(id<FBSDKGraphRequest> _Nonnull)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate> _Nullable)delegate;
		[Export ("processError:request:delegate:")]
		bool ProcessError (NSError error, IFBSDKGraphRequestProtocol request, [NullAllowed] FBSDKGraphErrorRecoveryProcessorDelegate @delegate);
	}

	// @interface FBSDKGraphRequestConnectionFactory : NSObject <FBSDKGraphRequestConnectionFactory>
	// [BaseType (typeof (NSObject))]
	// interface FBSDKGraphRequestConnectionFactory : IFBSDKGraphRequestConnectionFactory {
	// }

	// @interface FBSDKGraphRequestDataAttachment : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKGraphRequestDataAttachment {
		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data filename:(NSString * _Nonnull)filename contentType:(NSString * _Nonnull)contentType __attribute__((objc_designated_initializer));
		[Export ("initWithData:filename:contentType:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSData data, string filename, string contentType);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull contentType;
		[Export ("contentType")]
		string ContentType { get; }

		// @property (readonly, nonatomic, strong) NSData * _Nonnull data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull filename;
		[Export ("filename")]
		string Filename { get; }
	}

	// @protocol FBSDKGraphRequestFactory
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
	interface FBSDKGraphRequestFactory {
		// @required -(id<FBSDKGraphRequest> _Nonnull)createGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters tokenString:(NSString * _Nullable)tokenString HTTPMethod:(FBSDKHTTPMethod _Nullable)method flags:(FBSDKGraphRequestFlags)flags;
		[Abstract]
		[Export ("createGraphRequestWithGraphPath:parameters:tokenString:HTTPMethod:flags:")]
		IFBSDKGraphRequestProtocol Parameters (string graphPath, NSDictionary<NSString, NSObject> parameters, [NullAllowed] string tokenString, [NullAllowed] string method, FBSDKGraphRequestFlags flags);

		// @required -(id<FBSDKGraphRequest> _Nonnull)createGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
		[Abstract]
		[Export ("createGraphRequestWithGraphPath:parameters:")]
		IFBSDKGraphRequestProtocol Parameters (string graphPath, NSDictionary<NSString, NSObject> parameters);

		// @required -(id<FBSDKGraphRequest> _Nonnull)createGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath;
		[Abstract]
		[Export ("createGraphRequestWithGraphPath:")]
		IFBSDKGraphRequestProtocol CreateGraphRequestWithGraphPath (string graphPath);

		// @required -(id<FBSDKGraphRequest> _Nonnull)createGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
		[Abstract]
		[Export ("createGraphRequestWithGraphPath:parameters:HTTPMethod:")]
		IFBSDKGraphRequestProtocol Parameters (string graphPath, NSDictionary<NSString, NSObject> parameters, string method);

		// @required -(id<FBSDKGraphRequest> _Nonnull)createGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters tokenString:(NSString * _Nullable)tokenString version:(NSString * _Nullable)version HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
		[Abstract]
		[Export ("createGraphRequestWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
		IFBSDKGraphRequestProtocol Parameters (string graphPath, NSDictionary<NSString, NSObject> parameters, [NullAllowed] string tokenString, [NullAllowed] string version, string method);

		// @required -(id<FBSDKGraphRequest> _Nonnull)createGraphRequestWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters flags:(FBSDKGraphRequestFlags)flags;
		[Abstract]
		[Export ("createGraphRequestWithGraphPath:parameters:flags:")]
		IFBSDKGraphRequestProtocol Parameters (string graphPath, NSDictionary<NSString, NSObject> parameters, FBSDKGraphRequestFlags flags);
	}
	
	interface IFBSDKGraphRequestFactory {}

	// @interface FBSDKGraphRequestFactory : NSObject <FBSDKGraphRequestFactory>
	// [BaseType (typeof (NSObject))]
	// interface FBSDKGraphRequestFactory : IFBSDKGraphRequestFactory {
	// }

	// @interface FBSDKGraphRequestMetadata : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKGraphRequestMetadata : INativeObject {
		// @property (retain, nonatomic) id<FBSDKGraphRequest> _Nonnull request;
		[Export ("request", ArgumentSemantic.Retain)]
		IFBSDKGraphRequestProtocol Request { get; set; }

		// @property (copy, nonatomic) FBSDKGraphRequestCompletion _Nonnull completionHandler;
		[Export ("completionHandler", ArgumentSemantic.Copy)]
		FBSDKGraphRequestCompletion CompletionHandler { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull batchParameters;
		[Export ("batchParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> BatchParameters { get; set; }

		// -(instancetype _Nonnull)initWithRequest:(id<FBSDKGraphRequest> _Nonnull)request completionHandler:(FBSDKGraphRequestCompletion _Nullable)handler batchParameters:(NSDictionary<NSString *,id> * _Nullable)batchParameters __attribute__((objc_designated_initializer));
		[Export ("initWithRequest:completionHandler:batchParameters:")]
		[DesignatedInitializer]
		NativeHandle Constructor (IFBSDKGraphRequestProtocol request, [NullAllowed] FBSDKGraphRequestCompletion handler, [NullAllowed] NSDictionary<NSString, NSObject> batchParameters);

		// -(void)invokeCompletionHandlerForConnection:(id<FBSDKGraphRequestConnecting> _Nonnull)connection withResults:(id _Nonnull)results error:(NSError * _Nullable)error;
		[Export ("invokeCompletionHandlerForConnection:withResults:error:")]
		void InvokeCompletionHandlerForConnection (IFBSDKGraphRequestConnecting connection, NSObject results, [NullAllowed] NSError error);
	}

	// @protocol FBSDKGraphRequestPiggybackManaging
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
	interface FBSDKGraphRequestPiggybackManaging {
		// @required -(void)addPiggybackRequests:(id<FBSDKGraphRequestConnecting> _Nonnull)connection;
		[Abstract]
		[Export ("addPiggybackRequests:")]
		void AddPiggybackRequests (IFBSDKGraphRequestConnecting connection);

		// @required -(void)addRefreshPiggyback:(id<FBSDKGraphRequestConnecting> _Nonnull)connection permissionHandler:(FBSDKGraphRequestCompletion _Nullable)permissionHandler;
		[Abstract]
		[Export ("addRefreshPiggyback:permissionHandler:")]
		void AddRefreshPiggyback (IFBSDKGraphRequestConnecting connection, [NullAllowed] FBSDKGraphRequestCompletion permissionHandler);
	}

	interface IFBSDKGraphRequestPiggybackManaging {
		
	}

	// @protocol FBSDKImpressionLogging
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
	interface FBSDKImpressionLogging {
		// @required -(void)logImpressionWithIdentifier:(NSString * _Nonnull)identifier parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Abstract]
		[Export ("logImpressionWithIdentifier:parameters:")]
		void Parameters (string identifier, [NullAllowed] NSDictionary<NSString, NSObject> parameters);
	}

	interface IFBSDKImpressionLogging {}
	// @protocol FBSDKImpressionLoggerFactory
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
	interface FBSDKImpressionLoggerFactory {
		// @required -(id<FBSDKImpressionLogging> _Nonnull)makeImpressionLoggerWithEventName:(FBSDKAppEventName _Nonnull)eventName;
		[Abstract]
		[Export ("makeImpressionLoggerWithEventName:")]
		IFBSDKImpressionLogging MakeImpressionLoggerWithEventName (string eventName);
	}
	
	interface IFBSDKImpressionLoggerFactory {}

	// @interface FBSDKImpressionLoggerFactory : NSObject <FBSDKImpressionLoggerFactory>
	// [BaseType (typeof (NSObject))]
	// [DisableDefaultCtor]
	// interface FBSDKImpressionLoggerFactory : IFBSDKImpressionLoggerFactory {
	// 	// @property (readonly, nonatomic) id<FBSDKGraphRequestFactory> _Nonnull graphRequestFactory;
	// 	[Export ("graphRequestFactory")]
	// 	FBSDKGraphRequestFactory GraphRequestFactory { get; }
	//
	// 	// @property (readonly, nonatomic) id<FBSDKEventLogging> _Nonnull eventLogger;
	// 	[Export ("eventLogger")]
	// 	FBSDKEventLogging EventLogger { get; }
	//
	// 	// @property (readonly, nonatomic) id<FBSDKNotificationDelivering> _Nonnull notificationCenter;
	// 	[Export ("notificationCenter")]
	// 	FBSDKNotificationDelivering NotificationCenter { get; }
	//
	// 	// @property (readonly, nonatomic) Class<FBSDKAccessTokenProviding> _Nonnull accessTokenWallet;
	// 	[Export ("accessTokenWallet")]
	// 	FBSDKAccessTokenProviding AccessTokenWallet { get; }
	//
	// 	// -(instancetype _Nonnull)initWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger notificationCenter:(id<FBSDKNotificationDelivering> _Nonnull)notificationCenter accessTokenWallet:(Class<FBSDKAccessTokenProviding> _Nonnull)accessTokenWallet __attribute__((objc_designated_initializer)) __attribute__((swift_name("init(graphRequestFactory:eventLogger:notificationCenter:accessTokenWallet:)")));
	// 	[Export ("initWithGraphRequestFactory:eventLogger:notificationCenter:accessTokenWallet:")]
	// 	[DesignatedInitializer]
	// 	NativeHandle Constructor (FBSDKGraphRequestFactory graphRequestFactory, FBSDKEventLogging eventLogger, FBSDKNotificationDelivering notificationCenter, FBSDKAccessTokenProviding accessTokenWallet);
	// }

	// @protocol FBSDKIntegrityParametersProcessorProvider
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
	interface FBSDKIntegrityParametersProcessorProvider {
		// @required @property (nonatomic) id<FBSDKAppEventsParameterProcessing> _Nullable integrityParametersProcessor;
		[Abstract]
		[NullAllowed, Export ("integrityParametersProcessor", ArgumentSemantic.Assign)]
		IFBSDKAppEventsParameterProcessing IntegrityParametersProcessor { get; set; }
	}
	
	interface IFBSDKIntegrityParametersProcessorProvider {}

	// @protocol FBSDKIntegrityProcessing
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
	interface FBSDKIntegrityProcessing {
		// @required -(BOOL)processIntegrity:(NSString * _Nullable)parameter;
		[Abstract]
		[Export ("processIntegrity:")]
		bool ProcessIntegrity ([NullAllowed] string parameter);
	}
	
	interface IFBSDKIntegrityProcessing {}

	// @protocol FBSDKInternalURLOpener
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
	interface FBSDKInternalURLOpener {
		// @required -(BOOL)canOpenURL:(NSURL * _Nonnull)url;
		[Abstract]
		[Export ("canOpenURL:")]
		bool CanOpenURL (NSUrl url);

		// @required -(BOOL)openURL:(NSURL * _Nonnull)url;
		[Abstract]
		[Export ("openURL:")]
		bool OpenURL (NSUrl url);

		// @required -(void)openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenExternalURLOptionsKey,id> * _Nonnull)options completionHandler:(void (^ _Nullable)(BOOL))completion;
		[Abstract]
		[Export ("openURL:options:completionHandler:")]
		void OpenURL (NSUrl url, NSDictionary<NSString, NSObject> options, [NullAllowed] Action<bool> completion);
	}
	
	interface IFBSDKInternalURLOpener {}

	// @protocol FBSDKInternalUtility
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
	interface FBSDKInternalUtility {
		// @required @property (readonly, nonatomic) BOOL isFacebookAppInstalled;
		[Abstract]
		[Export ("isFacebookAppInstalled")]
		bool IsFacebookAppInstalled { get; }

		// @required @property (readonly, nonatomic) BOOL isUnity;
		[Abstract]
		[Export ("isUnity")]
		bool IsUnity { get; }

		// @required -(NSURL * _Nullable)URLWithScheme:(NSString * _Nonnull)scheme host:(NSString * _Nonnull)host path:(NSString * _Nonnull)path queryParameters:(NSDictionary<NSString *,NSString *> * _Nonnull)queryParameters error:(NSError * _Nullable * _Nullable)errorRef;
		[Abstract]
		[Export ("URLWithScheme:host:path:queryParameters:error:")]
		[return: NullAllowed]
		NSUrl URLWithScheme (string scheme, string host, string path, NSDictionary<NSString, NSString> queryParameters, [NullAllowed] out NSError errorRef);

		// @required -(NSURL * _Nullable)appURLWithHost:(NSString * _Nonnull)host path:(NSString * _Nonnull)path queryParameters:(NSDictionary<NSString *,NSString *> * _Nonnull)queryParameters error:(NSError * _Nullable * _Nullable)errorRef;
		[Abstract]
		[Export ("appURLWithHost:path:queryParameters:error:")]
		[return: NullAllowed]
		NSUrl AppURLWithHost (string host, string path, NSDictionary<NSString, NSString> queryParameters, [NullAllowed] out NSError errorRef);

		// @required -(NSURL * _Nullable)facebookURLWithHostPrefix:(NSString * _Nonnull)hostPrefix path:(NSString * _Nonnull)path queryParameters:(NSDictionary<NSString *,NSString *> * _Nonnull)queryParameters error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("facebookURL(hostPrefix:path:queryParameters:)")));
		[Abstract]
		[Export ("facebookURLWithHostPrefix:path:queryParameters:error:")]
		[return: NullAllowed]
		NSUrl FacebookURLWithHostPrefix (string hostPrefix, string path, NSDictionary<NSString, NSString> queryParameters, [NullAllowed] out NSError errorRef);

		// @required -(void)registerTransientObject:(id _Nonnull)object;
		[Abstract]
		[Export ("registerTransientObject:")]
		void RegisterTransientObject (NSObject @object);

		// @required -(void)unregisterTransientObject:(__weak id _Nonnull)object;
		[Abstract]
		[Export ("unregisterTransientObject:")]
		void UnregisterTransientObject (NSObject @object);

		// @required -(void)checkRegisteredCanOpenURLScheme:(NSString * _Nonnull)urlScheme;
		[Abstract]
		[Export ("checkRegisteredCanOpenURLScheme:")]
		void CheckRegisteredCanOpenURLScheme (string urlScheme);

		// @required -(void)validateURLSchemes;
		[Abstract]
		[Export ("validateURLSchemes")]
		void ValidateURLSchemes ();

		// @required -(void)extendDictionaryWithDataProcessingOptions:(NSMutableDictionary<NSString *,NSString *> * _Nonnull)parameters;
		[Abstract]
		[Export ("extendDictionaryWithDataProcessingOptions:")]
		void ExtendDictionaryWithDataProcessingOptions (NSMutableDictionary<NSString, NSString> parameters);

		// @required -(NSString * _Nullable)hexadecimalStringFromData:(NSData * _Nonnull)data;
		[Abstract]
		[Export ("hexadecimalStringFromData:")]
		[return: NullAllowed]
		string HexadecimalStringFromData (NSData data);

		// @required -(void)validateAppID;
		[Abstract]
		[Export ("validateAppID")]
		void ValidateAppID ();

		// @required -(NSString * _Nonnull)validateRequiredClientAccessToken;
		[Abstract]
		[Export ("validateRequiredClientAccessToken")]
		string ValidateRequiredClientAccessToken { get; }

		// @required -(void)extractPermissionsFromResponse:(NSDictionary<NSString *,id> * _Nonnull)responseObject grantedPermissions:(NSMutableSet<NSString *> * _Nonnull)grantedPermissions declinedPermissions:(NSMutableSet<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSMutableSet<NSString *> * _Nonnull)expiredPermissions;
		[Abstract]
		[Export ("extractPermissionsFromResponse:grantedPermissions:declinedPermissions:expiredPermissions:")]
		void ExtractPermissionsFromResponse (NSDictionary<NSString, NSObject> responseObject, NSMutableSet<NSString> grantedPermissions, NSMutableSet<NSString> declinedPermissions, NSMutableSet<NSString> expiredPermissions);

		// @required -(void)validateFacebookReservedURLSchemes;
		[Abstract]
		[Export ("validateFacebookReservedURLSchemes")]
		void ValidateFacebookReservedURLSchemes ();

		// @required -(NSDictionary<NSString *,id> * _Nonnull)parametersFromFBURL:(NSURL * _Nonnull)url;
		[Abstract]
		[Export ("parametersFromFBURL:")]
		NSDictionary<NSString, NSObject> ParametersFromFBURL (NSUrl url);

		// @required @property (readonly, nonatomic, strong) NSBundle * _Nonnull bundleForStrings;
		[Abstract]
		[Export ("bundleForStrings", ArgumentSemantic.Strong)]
		NSBundle BundleForStrings { get; }

		// @required -(UIViewController * _Nullable)topMostViewController;
		[Abstract]
		[NullAllowed, Export ("topMostViewController")]
		UIViewController TopMostViewController { get; }
	}

	interface IFBSDKInternalUtility {
		
	}

	// @protocol FBSDKURLHosting
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
	interface FBSDKURLHosting {
		// @required -(NSURL * _Nullable)appURLWithHost:(NSString * _Nonnull)host path:(NSString * _Nonnull)path queryParameters:(NSDictionary<NSString *,NSString *> * _Nonnull)queryParameters error:(NSError * _Nullable * _Nullable)errorRef;
		[Abstract]
		[Export ("appURLWithHost:path:queryParameters:error:")]
		[return: NullAllowed]
		NSUrl AppURLWithHost (string host, string path, NSDictionary<NSString, NSString> queryParameters, [NullAllowed] out NSError errorRef);

		// @required -(NSURL * _Nullable)facebookURLWithHostPrefix:(NSString * _Nonnull)hostPrefix path:(NSString * _Nonnull)path queryParameters:(NSDictionary<NSString *,NSString *> * _Nonnull)queryParameters error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("facebookURL(hostPrefix:path:queryParameters:)")));
		[Abstract]
		[Export ("facebookURLWithHostPrefix:path:queryParameters:error:")]
		[return: NullAllowed]
		NSUrl FacebookURLWithHostPrefix (string hostPrefix, string path, NSDictionary<NSString, NSString> queryParameters, [NullAllowed] out NSError errorRef);
	}
	
	interface IFBSDKURLHosting  {}
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKInstrumentManager {
		// @property (readonly, nonatomic, class) FBSDKInstrumentManager * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKInstrumentManager Shared { get; }

		// -(void)configureWithFeatureChecker:(id<FBSDKFeatureChecking> _Nonnull)featureChecker settings:(id<FBSDKSettings> _Nonnull)settings crashObserver:(id<FBSDKCrashObserving> _Nonnull)crashObserver errorReporter:(id<FBSDKErrorReporting> _Nonnull)errorReporter crashHandler:(id<FBSDKCrashHandler> _Nonnull)crashHandler __attribute__((swift_name("configure(featureChecker:settings:crashObserver:errorReporter:crashHandler:)")));
		[Export ("configureWithFeatureChecker:settings:crashObserver:errorReporter:crashHandler:")]
		void ConfigureWithFeatureChecker (IFBSDKFeatureChecking featureChecker, IFBSDKSettings settings, IFBSDKCrashObserving crashObserver, IFBSDKErrorReporting errorReporter, FBSDKCrashHandler crashHandler);

		// -(void)enable;
		[Export ("enable")]
		void Enable ();
	}

	// @protocol FBSDKKeychainStore
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
	interface FBSDKKeychainStore {
		// @required -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("stringForKey:")]
		[return: NullAllowed]
		string StringForKey (string key);

		// @required -(NSDictionary<NSString *,id> * _Nullable)dictionaryForKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("dictionaryForKey:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> DictionaryForKey (string key);

		// @required -(BOOL)setString:(NSString * _Nullable)value forKey:(NSString * _Nonnull)key accessibility:(CFTypeRef _Nullable)accessibility;
		[Abstract]
		[Export ("setString:forKey:accessibility:")]
		bool SetString ([NullAllowed] string value, string key, [NullAllowed] IntPtr accessibility);

		// @required -(BOOL)setDictionary:(NSDictionary<NSString *,id> * _Nullable)value forKey:(NSString * _Nonnull)key accessibility:(CFTypeRef _Nullable)accessibility;
		[Abstract]
		[Export ("setDictionary:forKey:accessibility:")]
		bool SetDictionary ([NullAllowed] NSDictionary<NSString, NSObject> value, string key, [NullAllowed] IntPtr accessibility);
	}
	
	interface IFBSDKKeychainStore {}

	// @interface FBSDKKeychainStore : NSObject <FBSDKKeychainStore>
	// [BaseType (typeof (NSObject))]
	// [DisableDefaultCtor]
	// interface FBSDKKeychainStore : IFBSDKKeychainStore {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull service;
	// 	[Export ("service")]
	// 	string Service { get; }
	//
	// 	// @property (readonly, copy, nonatomic) NSString * _Nullable accessGroup;
	// 	[NullAllowed, Export ("accessGroup")]
	// 	string AccessGroup { get; }
	//
	// 	// -(instancetype _Nonnull)initWithService:(NSString * _Nonnull)service accessGroup:(NSString * _Nullable)accessGroup __attribute__((objc_designated_initializer));
	// 	[Export ("initWithService:accessGroup:")]
	// 	[DesignatedInitializer]
	// 	NativeHandle Constructor (string service, [NullAllowed] string accessGroup);
	//
	// 	// -(BOOL)setData:(NSData * _Nullable)value forKey:(NSString * _Nonnull)key accessibility:(CFTypeRef _Nonnull)accessibility;
	// 	[Export ("setData:forKey:accessibility:")]
	// 	unsafe bool SetData ([NullAllowed] NSData value, string key, void* accessibility);
	//
	// 	// -(NSData * _Nullable)dataForKey:(NSString * _Nonnull)key;
	// 	[Export ("dataForKey:")]
	// 	[return: NullAllowed]
	// 	NSData DataForKey (string key);
	//
	// 	// -(NSMutableDictionary<NSString *,id> * _Nonnull)queryForKey:(NSString * _Nonnull)key;
	// 	[Export ("queryForKey:")]
	// 	NSMutableDictionary<NSString, NSObject> QueryForKey (string key);
	// }

	// @protocol FBSDKKeychainStoreProviding
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
	interface FBSDKKeychainStoreProviding {
		// @required -(id<FBSDKKeychainStore> _Nonnull)createKeychainStoreWithService:(NSString * _Nonnull)service accessGroup:(NSString * _Nullable)accessGroup __attribute__((swift_name("createKeychainStore(service:accessGroup:)")));
		[Abstract]
		[Export ("createKeychainStoreWithService:accessGroup:")]
		IFBSDKKeychainStore AccessGroup (string service, [NullAllowed] string accessGroup);
	}

	// @interface FBSDKLocation : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKLocation : INSCopying, INSSecureCoding {
		// @property (readonly, nonatomic, strong) NSString * _Nonnull id;
		[Export ("id", ArgumentSemantic.Strong)]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; }

		// +(instancetype _Nullable)locationFromDictionary:(NSDictionary<NSString *,NSString *> * _Nonnull)dictionary;
		[Static]
		[Export ("locationFromDictionary:")]
		[return: NullAllowed]
		FBSDKLocation LocationFromDictionary (NSDictionary<NSString, NSString> dictionary);
	}

	// @interface FBSDKLogger : NSObject <FBSDKLogging>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKLogger : IFBSDKLogging {
		// +(void)singleShotLogEntry:(FBSDKLoggingBehavior _Nonnull)loggingBehavior logEntry:(NSString * _Nonnull)logEntry;
		[Static]
		[Export ("singleShotLogEntry:logEntry:")]
		void SingleShotLogEntry (string loggingBehavior, string logEntry);
	}

	// @interface FBSDKLoggerFactory : NSObject <__FBSDKLoggerCreating>
	[BaseType (typeof (NSObject))]
	interface FBSDKLoggerFactory : I__FBSDKLoggerCreating {
	}

	// @interface FBSDKLoginTooltip : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKLoginTooltip {
		// @property (readonly, getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// -(instancetype _Nonnull)initWithText:(NSString * _Nonnull)text enabled:(BOOL)enabled __attribute__((objc_designated_initializer));
		[Export ("initWithText:enabled:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string text, bool enabled);
	}

	// @protocol FBSDKMacCatalystDetermining
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
	interface FBSDKMacCatalystDetermining {
		// @required @property (readonly) BOOL fb_isMacCatalystApp;
		[Abstract]
		[Export ("fb_isMacCatalystApp")]
		bool Fb_isMacCatalystApp { get; }
	}
	
	interface IFBSDKMacCatalystDetermining {}

	// @interface FBSDKMath : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKMath {
		// +(CGSize)ceilForSize:(CGSize)value;
		[Static]
		[Export ("ceilForSize:")]
		CGSize CeilForSize (CGSize value);

		// +(CGSize)floorForSize:(CGSize)value;
		[Static]
		[Export ("floorForSize:")]
		CGSize FloorForSize (CGSize value);

		// +(NSUInteger)hashWithInteger:(NSUInteger)value;
		[Static]
		[Export ("hashWithInteger:")]
		nuint HashWithInteger (nuint value);

		// +(NSUInteger)hashWithIntegerArray:(NSUInteger * _Nonnull)values count:(NSUInteger)count;
		[Static]
		[Export ("hashWithIntegerArray:count:")]
		unsafe nuint HashWithIntegerArray (IntPtr values, nuint count);
	}
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKMeasurementEventListener {
		// -(instancetype _Nonnull)initWithEventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger sourceApplicationTracker:(id<FBSDKSourceApplicationTracking> _Nonnull)sourceApplicationTracker;
		[Export ("initWithEventLogger:sourceApplicationTracker:")]
		NativeHandle Constructor (IFBSDKEventLogging eventLogger, IFBSDKSourceApplicationTracking sourceApplicationTracker);

		// -(void)registerForAppLinkMeasurementEvents;
		[Export ("registerForAppLinkMeasurementEvents")]
		void RegisterForAppLinkMeasurementEvents ();
	}

	// @protocol FBSDKMetadataIndexing
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
	interface FBSDKMetadataIndexing {
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();
	}
	interface IFBSDKMetadataIndexing{}

	// @interface FBSDKMetadataIndexer : NSObject <FBSDKMetadataIndexing>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKMetadataIndexer : IFBSDKMetadataIndexing {
		// -(instancetype _Nonnull)initWithUserDataStore:(id<FBSDKUserDataPersisting> _Nonnull)userDataStore swizzler:(Class<FBSDKSwizzling> _Nonnull)swizzler __attribute__((objc_designated_initializer));
		[Export ("initWithUserDataStore:swizzler:")]
		[DesignatedInitializer]
		NativeHandle Constructor (IFBSDKUserDataPersisting userDataStore, IFBSDKSwizzling swizzler);

		// -(void)enable;
		[Export ("enable")]
		void Enable ();
	}

	// @interface FBSDKModelManager : NSObject <FBSDKEventProcessing, FBSDKIntegrityParametersProcessorProvider, FBSDKIntegrityProcessing, FBSDKRulesFromKeyProvider>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKModelManager : IFBSDKEventProcessing, IFBSDKIntegrityParametersProcessorProvider, IFBSDKIntegrityProcessing, IFBSDKRulesFromKeyProvider {
		// @property (readonly, class) FBSDKModelManager * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKModelManager Shared { get; }

		// -(void)enable;
		[Export ("enable")]
		void Enable ();

		// -(NSData * _Nullable)getWeightsForKey:(NSString * _Nonnull)useCase;
		[Export ("getWeightsForKey:")]
		[return: NullAllowed]
		NSData GetWeightsForKey (string useCase);

		// -(NSArray<NSNumber *> * _Nullable)getThresholdsForKey:(NSString * _Nonnull)useCase;
		[Export ("getThresholdsForKey:")]
		[return: NullAllowed]
		NSNumber [] GetThresholdsForKey (string useCase);

		// -(BOOL)processIntegrity:(NSString * _Nullable)param;
		[Export ("processIntegrity:")]
		bool ProcessIntegrity ([NullAllowed] string param);

		// -(NSString * _Nonnull)processSuggestedEvents:(NSString * _Nonnull)textFeature denseData:(float * _Nullable)denseData;
		[Export ("processSuggestedEvents:denseData:")]
		unsafe string ProcessSuggestedEvents (string textFeature, [NullAllowed] IntPtr denseData);

		// -(void)configureWithFeatureChecker:(id<FBSDKFeatureChecking> _Nonnull)featureChecker graphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory fileManager:(id<FBSDKFileManaging> _Nonnull)fileManager store:(id<FBSDKDataPersisting> _Nonnull)store getAppID:(NSString * _Nonnull (^ _Nonnull)(void))getAppID dataExtractor:(Class<FBSDKFileDataExtracting> _Nonnull)dataExtractor gateKeeperManager:(Class<FBSDKGateKeeperManaging> _Nonnull)gateKeeperManager suggestedEventsIndexer:(id<FBSDKSuggestedEventsIndexer> _Nonnull)suggestedEventsIndexer featureExtractor:(Class<FBSDKFeatureExtracting> _Nonnull)featureExtractor __attribute__((swift_name("configure(featureChecker:graphRequestFactory:fileManager:store:getAppID:dataExtractor:gateKeeperManager:suggestedEventsIndexer:featureExtractor:)")));
		[Export ("configureWithFeatureChecker:graphRequestFactory:fileManager:store:getAppID:dataExtractor:gateKeeperManager:suggestedEventsIndexer:featureExtractor:")]
		void ConfigureWithFeatureChecker (IFBSDKFeatureChecking featureChecker, IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKFileManaging fileManager, IFBSDKDataPersisting store, Func<NSString> getAppID, IFBSDKFileDataExtracting dataExtractor, IFBSDKGateKeeperManaging gateKeeperManager, IFBSDKSuggestedEventsIndexer suggestedEventsIndexer, IFBSDKFeatureExtracting featureExtractor);
	}

	// @protocol FBSDKMutableCopying <NSCopying, NSObject, NSMutableCopying>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKMutableCopying : INSCopying, INSMutableCopying {
	}

	// @protocol FBSDKNetworkErrorChecking
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
	interface FBSDKNetworkErrorChecking {
		// @required -(BOOL)isNetworkError:(NSError *)error;
		[Abstract]
		[Export ("isNetworkError:")]
		bool IsNetworkError (NSError error);
	}

	interface IFBSDKNetworkErrorChecking {
	}

	// @interface FBSDKNetworkErrorChecker : NSObject <FBSDKNetworkErrorChecking>
	[BaseType (typeof (NSObject))]
	interface FBSDKNetworkErrorChecker : IFBSDKNetworkErrorChecking {
	}

	// @protocol FBSDKObjectDecoding <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKObjectDecoding {
		// @required -(id _Nullable)decodeObjectOfClass:(Class _Nonnull)aClass forKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("decodeObjectOfClass:forKey:")]
		[return: NullAllowed]
		NSObject DecodeObjectOfClass (Class aClass, string key);

		// @required -(id _Nullable)decodeObjectOfClasses:(NSSet<Class> * _Nonnull)classes forKey:(NSString * _Nonnull)key;
		[Abstract]
		[Export ("decodeObjectOfClasses:forKey:")]
		[return: NullAllowed]
		NSObject DecodeObjectOfClasses (NSSet<Class> classes, string key);
	}

	// @protocol FBSDKOperatingSystemVersionComparing
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
	interface FBSDKOperatingSystemVersionComparing {
		// @required -(BOOL)fb_isOperatingSystemAtLeastVersion:(NSOperatingSystemVersion)version __attribute__((swift_name("fb_isOperatingSystemAtLeast(_:)")));
		[Abstract]
		[Export ("fb_isOperatingSystemAtLeastVersion:")]
		bool Fb_isOperatingSystemAtLeastVersion (NSOperatingSystemVersion version);
	}
	interface IFBSDKOperatingSystemVersionComparing {}

	// @protocol FBSDKPasteboard
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
	interface FBSDKPasteboard {
		// @required @property (readonly, nonatomic) NSString * _Nonnull name;
		[Abstract]
		[Export ("name")]
		string Name { get; }

		// @required @property (readonly, nonatomic) BOOL _isGeneralPasteboard;
		[Abstract]
		[Export ("_isGeneralPasteboard")]
		bool _isGeneralPasteboard { get; }

		// @required -(NSData * _Nullable)dataForPasteboardType:(NSString * _Nonnull)pasteboardType;
		[Abstract]
		[Export ("dataForPasteboardType:")]
		[return: NullAllowed]
		NSData DataForPasteboardType (string pasteboardType);

		// @required -(void)setData:(NSData * _Nonnull)data forPasteboardType:(NSString * _Nonnull)pasteboardType;
		[Abstract]
		[Export ("setData:forPasteboardType:")]
		void SetData (NSData data, string pasteboardType);
	}
	
	interface IFBSDKPasteboard {}

	// @protocol FBSDKPaymentObserving
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
	interface FBSDKPaymentObserving {
		// @required -(void)startObservingTransactions __attribute__((swift_name("startObservingTransactions()")));
		[Abstract]
		[Export ("startObservingTransactions")]
		void StartObservingTransactions ();

		// @required -(void)stopObservingTransactions __attribute__((swift_name("stopObservingTransactions()")));
		[Abstract]
		[Export ("stopObservingTransactions")]
		void StopObservingTransactions ();
	}
	
	interface IFBSDKPaymentObserving {}

	// @interface FBSDKPaymentProductRequestor : NSObject <SKProductsRequestDelegate>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKPaymentProductRequestor : ISKProductsRequestDelegate {
		// -(instancetype _Nonnull)initWithTransaction:(SKPaymentTransaction * _Nonnull)transaction settings:(id<FBSDKSettings> _Nonnull)settings eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger gateKeeperManager:(Class<FBSDKGateKeeperManaging> _Nonnull)gateKeeperManager store:(id<FBSDKDataPersisting> _Nonnull)store loggerFactory:(id<__FBSDKLoggerCreating> _Nonnull)loggerFactory productsRequestFactory:(id<FBSDKProductsRequestCreating> _Nonnull)productRequestFactory appStoreReceiptProvider:(id<FBSDKAppStoreReceiptProviding> _Nonnull)receiptProvider;
		[Export ("initWithTransaction:settings:eventLogger:gateKeeperManager:store:loggerFactory:productsRequestFactory:appStoreReceiptProvider:")]
		NativeHandle Constructor (SKPaymentTransaction transaction, IFBSDKSettings settings, IFBSDKEventLogging eventLogger, IFBSDKGateKeeperManaging gateKeeperManager, IFBSDKDataPersisting store, I__FBSDKLoggerCreating loggerFactory, IFBSDKProductsRequestCreating productRequestFactory, IFBSDKAppStoreReceiptProviding receiptProvider);

		// -(void)resolveProducts;
		[Export ("resolveProducts")]
		void ResolveProducts ();
	}

	// @protocol FBSDKPaymentProductRequestorCreating
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
	interface FBSDKPaymentProductRequestorCreating {
		// @required -(FBSDKPaymentProductRequestor * _Nonnull)createRequestorWithTransaction:(SKPaymentTransaction * _Nonnull)transaction __attribute__((swift_name("createRequestor(transaction:)")));
		[Abstract]
		[Export ("createRequestorWithTransaction:")]
		FBSDKPaymentProductRequestor CreateRequestorWithTransaction (SKPaymentTransaction transaction);
	}

	// @protocol FBSDKProductsRequest
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
	interface FBSDKProductsRequest {
		[Wrap ("WeakDelegate"), Abstract]
		[NullAllowed]
		SKProductsRequestDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<SKProductsRequestDelegate> _Nullable delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required -(void)cancel;
		[Abstract]
		[Export ("cancel")]
		void Cancel ();

		// @required -(void)start;
		[Abstract]
		[Export ("start")]
		void Start ();
	}

	interface IFBSDKProductsRequest {
		
	}

	// @protocol FBSDKProductsRequestCreating
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
	interface FBSDKProductsRequestCreating {
		// @required -(id<FBSDKProductsRequest> _Nonnull)createWithProductIdentifiers:(NSSet<NSString *> * _Nonnull)identifiers;
		[Abstract]
		[Export ("createWithProductIdentifiers:")]
		IFBSDKProductsRequest CreateWithProductIdentifiers (NSSet<NSString> identifiers);
	}

	interface IFBSDKProductsRequestCreating { }

	// @interface FBSDKProductRequestFactory : NSObject <FBSDKProductsRequestCreating>
	[BaseType (typeof (NSObject))]
	interface FBSDKProductRequestFactory : IFBSDKProductsRequestCreating {
	}

	// typedef void (^FBSDKProfileBlock)(FBSDKProfile * _Nullable, NSError * _Nullable);
	delegate void FBSDKProfileBlock ([NullAllowed] FBSDKProfile arg0, [NullAllowed] NSError arg1);
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKRestrictiveDataFilterManager : IFBSDKAppEventsParameterProcessing, IFBSDKEventsProcessing {
		// -(instancetype _Nonnull)initWithServerConfigurationProvider:(id<FBSDKServerConfigurationProviding> _Nonnull)serverConfigurationProvider __attribute__((objc_designated_initializer));
		[Export ("initWithServerConfigurationProvider:")]
		[DesignatedInitializer]
		NativeHandle Constructor (IFBSDKServerConfigurationProviding serverConfigurationProvider);

		// -(void)enable;
		[Export ("enable")]
		void Enable ();

		// -(void)processEvents:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)events;
		[Export ("processEvents:")]
		void ProcessEvents (NSDictionary<NSString, NSObject> [] events);

		// -(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)processParameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters eventName:(FBSDKAppEventName _Nullable)eventName;
		[Export ("processParameters:eventName:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> ProcessParameters ([NullAllowed] NSDictionary<NSString, NSObject> parameters, [NullAllowed] string eventName);
	}
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKServerConfiguration : INSCopying, INSSecureCoding {
		// -(instancetype _Nonnull)initWithAppID:(NSString * _Nonnull)appID appName:(NSString * _Nullable)appName loginTooltipEnabled:(BOOL)loginTooltipEnabled loginTooltipText:(NSString * _Nullable)loginTooltipText defaultShareMode:(NSString * _Nullable)defaultShareMode advertisingIDEnabled:(BOOL)advertisingIDEnabled implicitLoggingEnabled:(BOOL)implicitLoggingEnabled implicitPurchaseLoggingEnabled:(BOOL)implicitPurchaseLoggingEnabled codelessEventsEnabled:(BOOL)codelessEventsEnabled uninstallTrackingEnabled:(BOOL)uninstallTrackingEnabled dialogConfigurations:(NSDictionary<NSString *,id> * _Nullable)dialogConfigurations dialogFlows:(NSDictionary<NSString *,id> * _Nullable)dialogFlows timestamp:(NSDate * _Nullable)timestamp errorConfiguration:(IFBSDKErrorConfiguration * _Nullable)errorConfiguration sessionTimeoutInterval:(NSTimeInterval)sessionTimeoutInterval defaults:(BOOL)defaults loggingToken:(NSString * _Nullable)loggingToken smartLoginOptions:(FBSDKServerConfigurationSmartLoginOptions)smartLoginOptions smartLoginBookmarkIconURL:(NSURL * _Nullable)smartLoginBookmarkIconURL smartLoginMenuIconURL:(NSURL * _Nullable)smartLoginMenuIconURL updateMessage:(NSString * _Nullable)updateMessage eventBindings:(NSArray<NSDictionary<NSString *,id> *> * _Nullable)eventBindings restrictiveParams:(NSDictionary<NSString *,id> * _Nullable)restrictiveParams AAMRules:(NSDictionary<NSString *,id> * _Nullable)AAMRules suggestedEventsSetting:(NSDictionary<NSString *,id> * _Nullable)suggestedEventsSetting protectedModeRules:(NSDictionary<NSString *,id> * _Nullable)protectedModeRules __attribute__((objc_designated_initializer));
		[Export ("initWithAppID:appName:loginTooltipEnabled:loginTooltipText:defaultShareMode:advertisingIDEnabled:implicitLoggingEnabled:implicitPurchaseLoggingEnabled:codelessEventsEnabled:uninstallTrackingEnabled:dialogConfigurations:dialogFlows:timestamp:errorConfiguration:sessionTimeoutInterval:defaults:loggingToken:smartLoginOptions:smartLoginBookmarkIconURL:smartLoginMenuIconURL:updateMessage:eventBindings:restrictiveParams:AAMRules:suggestedEventsSetting:protectedModeRules:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string appID, [NullAllowed] string appName, bool loginTooltipEnabled, [NullAllowed] string loginTooltipText, [NullAllowed] string defaultShareMode, bool advertisingIDEnabled, bool implicitLoggingEnabled, bool implicitPurchaseLoggingEnabled, bool codelessEventsEnabled, bool uninstallTrackingEnabled, [NullAllowed] NSDictionary<NSString, NSObject> dialogConfigurations, [NullAllowed] NSDictionary<NSString, NSObject> dialogFlows, [NullAllowed] NSDate timestamp, [NullAllowed] IFBSDKErrorConfiguration errorConfiguration, double sessionTimeoutInterval, bool defaults, [NullAllowed] string loggingToken, FBSDKServerConfigurationSmartLoginOptions smartLoginOptions, [NullAllowed] NSUrl smartLoginBookmarkIconURL, [NullAllowed] NSUrl smartLoginMenuIconURL, [NullAllowed] string updateMessage, [NullAllowed] NSDictionary<NSString, NSObject> [] eventBindings, [NullAllowed] NSDictionary<NSString, NSObject> restrictiveParams, [NullAllowed] NSDictionary<NSString, NSObject> AAMRules, [NullAllowed] NSDictionary<NSString, NSObject> suggestedEventsSetting, [NullAllowed] NSDictionary<NSString, NSObject> protectedModeRules);

		// @property (readonly, getter = isAdvertisingIDEnabled, assign, nonatomic) BOOL advertisingIDEnabled;
		[Export ("advertisingIDEnabled")]
		bool AdvertisingIDEnabled { [Bind ("isAdvertisingIDEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appID;
		[Export ("appID")]
		string AppID { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable appName;
		[NullAllowed, Export ("appName")]
		string AppName { get; }

		// @property (readonly, getter = isDefaults, assign, nonatomic) BOOL defaults;
		[Export ("defaults")]
		bool Defaults { [Bind ("isDefaults")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable defaultShareMode;
		[NullAllowed, Export ("defaultShareMode")]
		string DefaultShareMode { get; }

		// @property (readonly, nonatomic, strong) IFBSDKErrorConfiguration * _Nullable errorConfiguration;
		[NullAllowed, Export ("errorConfiguration", ArgumentSemantic.Strong)]
		IFBSDKErrorConfiguration ErrorConfiguration { get; }

		// @property (readonly, getter = isImplicitLoggingSupported, assign, nonatomic) BOOL implicitLoggingEnabled;
		[Export ("implicitLoggingEnabled")]
		bool ImplicitLoggingEnabled { [Bind ("isImplicitLoggingSupported")] get; }

		// @property (readonly, getter = isImplicitPurchaseLoggingSupported, assign, nonatomic) BOOL implicitPurchaseLoggingEnabled;
		[Export ("implicitPurchaseLoggingEnabled")]
		bool ImplicitPurchaseLoggingEnabled { [Bind ("isImplicitPurchaseLoggingSupported")] get; }

		// @property (readonly, getter = isCodelessEventsEnabled, assign, nonatomic) BOOL codelessEventsEnabled;
		[Export ("codelessEventsEnabled")]
		bool CodelessEventsEnabled { [Bind ("isCodelessEventsEnabled")] get; }

		// @property (readonly, getter = isLoginTooltipEnabled, assign, nonatomic) BOOL loginTooltipEnabled;
		[Export ("loginTooltipEnabled")]
		bool LoginTooltipEnabled { [Bind ("isLoginTooltipEnabled")] get; }

		// @property (readonly, getter = isUninstallTrackingEnabled, assign, nonatomic) BOOL uninstallTrackingEnabled;
		[Export ("uninstallTrackingEnabled")]
		bool UninstallTrackingEnabled { [Bind ("isUninstallTrackingEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable loginTooltipText;
		[NullAllowed, Export ("loginTooltipText")]
		string LoginTooltipText { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable timestamp;
		[NullAllowed, Export ("timestamp", ArgumentSemantic.Copy)]
		NSDate Timestamp { get; }

		// @property (assign, nonatomic) NSTimeInterval sessionTimeoutInterval;
		[Export ("sessionTimeoutInterval")]
		double SessionTimeoutInterval { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable loggingToken;
		[NullAllowed, Export ("loggingToken")]
		string LoggingToken { get; }

		// @property (readonly, assign, nonatomic) FBSDKServerConfigurationSmartLoginOptions smartLoginOptions;
		[Export ("smartLoginOptions", ArgumentSemantic.Assign)]
		FBSDKServerConfigurationSmartLoginOptions SmartLoginOptions { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable smartLoginBookmarkIconURL;
		[NullAllowed, Export ("smartLoginBookmarkIconURL", ArgumentSemantic.Copy)]
		NSUrl SmartLoginBookmarkIconURL { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable smartLoginMenuIconURL;
		[NullAllowed, Export ("smartLoginMenuIconURL", ArgumentSemantic.Copy)]
		NSUrl SmartLoginMenuIconURL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable updateMessage;
		[NullAllowed, Export ("updateMessage")]
		string UpdateMessage { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSDictionary<NSString *,id> *> * _Nullable eventBindings;
		[NullAllowed, Export ("eventBindings", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> [] EventBindings { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable restrictiveParams;
		[NullAllowed, Export ("restrictiveParams", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> RestrictiveParams { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable AAMRules;
		[NullAllowed, Export ("AAMRules", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AAMRules { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable suggestedEventsSetting;
		[NullAllowed, Export ("suggestedEventsSetting", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> SuggestedEventsSetting { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable protectedModeRules;
		[NullAllowed, Export ("protectedModeRules", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ProtectedModeRules { get; }

		// @property (readonly, nonatomic) NSInteger version;
		[Export ("version")]
		nint Version { get; }

		// -(FBSDKDialogConfiguration * _Nullable)dialogConfigurationForDialogName:(NSString * _Nonnull)dialogName;
		[Export ("dialogConfigurationForDialogName:")]
		[return: NullAllowed]
		FBSDKDialogConfiguration DialogConfigurationForDialogName (string dialogName);

		// -(BOOL)useNativeDialogForDialogName:(NSString * _Nonnull)dialogName;
		[Export ("useNativeDialogForDialogName:")]
		bool UseNativeDialogForDialogName (string dialogName);

		// -(BOOL)useSafariViewControllerForDialogName:(NSString * _Nonnull)dialogName;
		[Export ("useSafariViewControllerForDialogName:")]
		bool UseSafariViewControllerForDialogName (string dialogName);
	}

	// typedef void (^FBSDKServerConfigurationBlock)(FBSDKServerConfiguration * _Nullable, NSError * _Nullable);
	delegate void FBSDKServerConfigurationBlock ([NullAllowed] FBSDKServerConfiguration arg0, [NullAllowed] NSError arg1);

	// @protocol FBSDKServerConfigurationProviding
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
	interface FBSDKServerConfigurationProviding {
		// @required -(FBSDKServerConfiguration * _Nonnull)cachedServerConfiguration;
		[Abstract]
		[Export ("cachedServerConfiguration")]
		FBSDKServerConfiguration CachedServerConfiguration { get; }

		// @required -(void)loadServerConfigurationWithCompletionBlock:(FBSDKServerConfigurationBlock _Nullable)completionBlock;
		[Abstract]
		[Export ("loadServerConfigurationWithCompletionBlock:")]
		void LoadServerConfigurationWithCompletionBlock ([NullAllowed] FBSDKServerConfigurationBlock completionBlock);

		// @required -(void)processLoadRequestResponse:(id _Nonnull)result error:(NSError * _Nullable)error appID:(NSString * _Nonnull)appID;
		[Abstract]
		[Export ("processLoadRequestResponse:error:appID:")]
		void ProcessLoadRequestResponse (NSObject result, [NullAllowed] NSError error, string appID);

		// @required -(FBSDKGraphRequestProtocol * _Nullable)requestToLoadServerConfiguration:(NSString * _Nonnull)appID;
		[Abstract]
		[Export ("requestToLoadServerConfiguration:")]
		[return: NullAllowed]
		IFBSDKGraphRequestProtocol RequestToLoadServerConfiguration (string appID);
	}

	interface IFBSDKServerConfigurationProviding {
	}

	// @interface FBSDKServerConfigurationManager : NSObject <FBSDKServerConfigurationProviding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKServerConfigurationManager : IFBSDKServerConfigurationProviding {
		// @property (readonly, class) FBSDKServerConfigurationManager * _Nonnull shared;
		[Static]
		[Export ("shared")]
		FBSDKServerConfigurationManager Shared { get; }

		// @property (nonatomic) id<FBSDKGraphRequestFactory> _Nullable graphRequestFactory;
		[NullAllowed, Export ("graphRequestFactory", ArgumentSemantic.Assign)]
		IFBSDKGraphRequestFactory GraphRequestFactory { get; set; }

		// @property (nonatomic) id<FBSDKGraphRequestConnectionFactory> _Nullable graphRequestConnectionFactory;
		[NullAllowed, Export ("graphRequestConnectionFactory", ArgumentSemantic.Assign)]
		IFBSDKGraphRequestConnectionFactory GraphRequestConnectionFactory { get; set; }

		// @property (nonatomic) id<FBSDKDialogConfigurationMapBuilding> _Nullable dialogConfigurationMapBuilder;
		[NullAllowed, Export ("dialogConfigurationMapBuilder", ArgumentSemantic.Assign)]
		IFBSDKDialogConfigurationMapBuilding DialogConfigurationMapBuilder { get; set; }

		// -(void)configureWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory graphRequestConnectionFactory:(id<FBSDKGraphRequestConnectionFactory> _Nonnull)graphRequestConnectionFactory dialogConfigurationMapBuilder:(id<FBSDKDialogConfigurationMapBuilding> _Nonnull)dialogConfigurationMapBuilder __attribute__((swift_name("configure(graphRequestFactory:graphRequestConnectionFactory:dialogConfigurationMapBuilder:)")));
		[Export ("configureWithGraphRequestFactory:graphRequestConnectionFactory:dialogConfigurationMapBuilder:")]
		void ConfigureWithGraphRequestFactory (IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKGraphRequestConnectionFactory graphRequestConnectionFactory, IFBSDKDialogConfigurationMapBuilding dialogConfigurationMapBuilder);

		// -(void)clearCache;
		[Export ("clearCache")]
		void ClearCache ();
	}

	// @protocol FBSDKSettingsLogging
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
	interface FBSDKSettingsLogging {
		// @required -(void)logWarnings;
		[Abstract]
		[Export ("logWarnings")]
		void LogWarnings ();

		// @required -(void)logIfSDKSettingsChanged;
		[Abstract]
		[Export ("logIfSDKSettingsChanged")]
		void LogIfSDKSettingsChanged ();

		// @required -(void)recordInstall;
		[Abstract]
		[Export ("recordInstall")]
		void RecordInstall ();
	}
	
	interface IFBSDKSettingsLogging {}
	
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKSKAdNetworkReporter : IFBSKAdNetworkReporting, IFBSDKAppEventsReporter {
		// @property (nonatomic) id<FBSDKGraphRequestFactory> _Nonnull graphRequestFactory;
		[Export ("graphRequestFactory", ArgumentSemantic.Assign)]
		IFBSDKGraphRequestFactory GraphRequestFactory { get; set; }

		// @property (nonatomic) id<FBSDKDataPersisting> _Nonnull dataStore;
		[Export ("dataStore", ArgumentSemantic.Assign)]
		IFBSDKDataPersisting DataStore { get; set; }

		// @property (nonatomic) Class<FBSDKConversionValueUpdating> _Nonnull conversionValueUpdater;
		[Export ("conversionValueUpdater", ArgumentSemantic.Assign)]
		IFBSDKConversionValueUpdating ConversionValueUpdater { get; set; }

		// -(instancetype _Nonnull)initWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory dataStore:(id<FBSDKDataPersisting> _Nonnull)dataStore conversionValueUpdater:(Class<FBSDKConversionValueUpdating> _Nonnull)conversionValueUpdater __attribute__((swift_name("init(graphRequestFactory:dataStore:conversionValueUpdater:)")));
		[Export ("initWithGraphRequestFactory:dataStore:conversionValueUpdater:")]
		NativeHandle Constructor (IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKDataPersisting dataStore, IFBSDKConversionValueUpdating conversionValueUpdater);

		// -(void)enable;
		[Export ("enable")]
		void Enable ();

		// -(void)recordAndUpdateEvent:(NSString * _Nonnull)event currency:(NSString * _Nullable)currency value:(NSNumber * _Nullable)value;
		[Export ("recordAndUpdateEvent:currency:value:")]
		void RecordAndUpdateEvent (string @event, [NullAllowed] string currency, [NullAllowed] NSNumber value);

		// -(BOOL)shouldCutoff __attribute__((warn_unused_result("")));
		[Export ("shouldCutoff")]

		bool ShouldCutoff { get; }

		// -(BOOL)isReportingEvent:(NSString * _Nonnull)event __attribute__((warn_unused_result("")));
		[Export ("isReportingEvent:")]
		bool IsReportingEvent (string @event);

		// -(void)checkAndRevokeTimer;
		[Export ("checkAndRevokeTimer")]
		void CheckAndRevokeTimer ();
	}

	// @interface FBSDKSKAdNetworkReporterV2 : NSObject <FBSKAdNetworkReporting, FBSDKAppEventsReporter>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKSKAdNetworkReporterV2 : IFBSKAdNetworkReporting, IFBSDKAppEventsReporter {
		// @property (nonatomic) id<FBSDKGraphRequestFactory> _Nonnull graphRequestFactory;
		[Export ("graphRequestFactory", ArgumentSemantic.Assign)]
		IFBSDKGraphRequestFactory GraphRequestFactory { get; set; }

		// @property (nonatomic) id<FBSDKDataPersisting> _Nonnull dataStore;
		[Export ("dataStore", ArgumentSemantic.Assign)]
		IFBSDKDataPersisting DataStore { get; set; }

		// @property (nonatomic) Class<FBSDKConversionValueUpdating> _Nonnull conversionValueUpdater;
		[Export ("conversionValueUpdater", ArgumentSemantic.Assign)]
		IFBSDKConversionValueUpdating ConversionValueUpdater { get; set; }

		// -(instancetype _Nonnull)initWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory dataStore:(id<FBSDKDataPersisting> _Nonnull)dataStore conversionValueUpdater:(Class<FBSDKConversionValueUpdating> _Nonnull)conversionValueUpdater __attribute__((swift_name("init(graphRequestFactory:dataStore:conversionValueUpdater:)")));
		[Export ("initWithGraphRequestFactory:dataStore:conversionValueUpdater:")]
		NativeHandle Constructor (IFBSDKGraphRequestFactory graphRequestFactory, IFBSDKDataPersisting dataStore, IFBSDKConversionValueUpdating conversionValueUpdater);

		// -(void)enable;
		[Export ("enable")]
		void Enable ();

		// -(void)recordAndUpdateEvent:(NSString * _Nonnull)event currency:(NSString * _Nullable)currency value:(NSNumber * _Nullable)value;
		[Export ("recordAndUpdateEvent:currency:value:")]
		void RecordAndUpdateEvent (string @event, [NullAllowed] string currency, [NullAllowed] NSNumber value);

		// -(BOOL)shouldCutoff __attribute__((warn_unused_result("")));
		[Export ("shouldCutoff")]
		bool ShouldCutoff { get; }

		// -(BOOL)isReportingEvent:(NSString * _Nonnull)event __attribute__((warn_unused_result("")));
		[Export ("isReportingEvent:")]
		bool IsReportingEvent (string @event);

		// -(void)checkAndRevokeTimer;
		[Export ("checkAndRevokeTimer")]
		void CheckAndRevokeTimer ();
	}

	// @protocol FBSDKSuggestedEventsIndexer
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
	interface FBSDKSuggestedEventsIndexer {
		// @required -(void)enable;
		[Abstract]
		[Export ("enable")]
		void Enable ();
	}
	
	interface IFBSDKSuggestedEventsIndexer {}

	// @interface FBSDKSuggestedEventsIndexer : NSObject <FBSDKSuggestedEventsIndexer>
	// [BaseType (typeof (NSObject))]
	// [DisableDefaultCtor]
	// interface FBSDKSuggestedEventsIndexer : IFBSDKSuggestedEventsIndexer {
	// 	// -(instancetype _Nonnull)initWithGraphRequestFactory:(id<FBSDKGraphRequestFactory> _Nonnull)graphRequestFactory serverConfigurationProvider:(id<FBSDKServerConfigurationProviding> _Nonnull)serverConfigurationProvider swizzler:(Class<FBSDKSwizzling> _Nonnull)swizzler settings:(id<FBSDKSettings> _Nonnull)settings eventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger featureExtractor:(Class<FBSDKFeatureExtracting> _Nonnull)featureExtractor eventProcessor:(id<FBSDKEventProcessing> _Nonnull)eventProcessor __attribute__((objc_designated_initializer));
	// 	[Export ("initWithGraphRequestFactory:serverConfigurationProvider:swizzler:settings:eventLogger:featureExtractor:eventProcessor:")]
	// 	[DesignatedInitializer]
	// 	NativeHandle Constructor (FBSDKGraphRequestFactory graphRequestFactory, FBSDKServerConfigurationProviding serverConfigurationProvider, FBSDKSwizzling swizzler, FBSDKSettings settings, FBSDKEventLogging eventLogger, FBSDKFeatureExtracting featureExtractor, FBSDKEventProcessing eventProcessor);
	//
	// 	// -(void)enable;
	// 	[Export ("enable")]
	// 	void Enable ();
	// }

	// typedef void (^_swizzleBlock)();
	delegate void _swizzleBlock ();

	// @protocol FBSDKSwizzling
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
	interface FBSDKSwizzling {
		// @required +(void)swizzleSelector:(SEL _Nonnull)aSelector onClass:(Class _Nonnull)aClass withBlock:(_swizzleBlock _Nonnull)block named:(NSString * _Nonnull)aName;
		[Static, Abstract]
		[Export ("swizzleSelector:onClass:withBlock:named:")]
		void OnClass (Selector aSelector, Class aClass, _swizzleBlock block, string aName);
	}

	interface IFBSDKSwizzling {
	}

	// typedef void (^_swizzleBlock)();
	// delegate void _swizzleBlock ();

	// @interface FBSDKSwizzler : NSObject <FBSDKSwizzling>
	[BaseType (typeof (NSObject))]
	interface FBSDKSwizzler : IFBSDKSwizzling {
		// +(void)swizzleSelector:(SEL _Nonnull)aSelector onClass:(Class _Nonnull)aClass withBlock:(_swizzleBlock _Nonnull)block named:(NSString * _Nonnull)aName;
		[Static]
		[Export ("swizzleSelector:onClass:withBlock:named:")]
		void SwizzleSelector (Selector aSelector, Class aClass, _swizzleBlock block, string aName);

		// +(void)unswizzleSelector:(SEL _Nonnull)aSelector onClass:(Class _Nonnull)aClass named:(NSString * _Nonnull)aName;
		[Static]
		[Export ("unswizzleSelector:onClass:named:")]
		void UnswizzleSelector (Selector aSelector, Class aClass, string aName);

		// +(void)printSwizzles;
		[Static]
		[Export ("printSwizzles")]
		void PrintSwizzles ();
	}

	// @protocol FBSDKTimeSpentRecording
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
	interface FBSDKTimeSpentRecording {
		// @required -(void)suspend;
		[Abstract]
		[Export ("suspend")]
		void Suspend ();

		// @required -(void)restore:(BOOL)calledFromActivateApp;
		[Abstract]
		[Export ("restore:")]
		void Restore (bool calledFromActivateApp);
	}

	interface IFBSDKTimeSpentRecording {
		
	}

	// @interface FBSDKTimeSpentData : NSObject <FBSDKSourceApplicationTracking, FBSDKTimeSpentRecording>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKTimeSpentData : IFBSDKSourceApplicationTracking, IFBSDKTimeSpentRecording {
		// -(instancetype _Nonnull)initWithEventLogger:(id<FBSDKEventLogging> _Nonnull)eventLogger serverConfigurationProvider:(id<FBSDKServerConfigurationProviding> _Nonnull)serverConfigurationProvider;
		[Export ("initWithEventLogger:serverConfigurationProvider:")]
		NativeHandle Constructor (IFBSDKEventLogging eventLogger, IFBSDKServerConfigurationProviding serverConfigurationProvider);

		// -(void)setSourceApplication:(NSString * _Nullable)sourceApplication openURL:(NSURL * _Nullable)url;
		[Export ("setSourceApplication:openURL:")]
		void SetSourceApplication ([NullAllowed] string sourceApplication, [NullAllowed] NSUrl url);

		// -(void)setSourceApplication:(NSString * _Nullable)sourceApplication isFromAppLink:(BOOL)isFromAppLink;
		[Export ("setSourceApplication:isFromAppLink:")]
		void SetSourceApplication ([NullAllowed] string sourceApplication, bool isFromAppLink);

		// -(void)registerAutoResetSourceApplication;
		[Export ("registerAutoResetSourceApplication")]
		void RegisterAutoResetSourceApplication ();

		// -(void)suspend;
		[Export ("suspend")]
		void Suspend ();

		// -(void)restore:(BOOL)calledFromActivateApp;
		[Export ("restore:")]
		void Restore (bool calledFromActivateApp);
	}

	// @interface FBSDKTransformer : NSObject
	[BaseType (typeof (NSObject))]
	interface FBSDKTransformer {
		// -(CATransform3D)CATransform3DMakeScale:(CGFloat)sx sy:(CGFloat)sy sz:(CGFloat)sz;
		[Export ("CATransform3DMakeScale:sy:sz:")]
		CATransform3D CATransform3DMakeScale (nfloat sx, nfloat sy, nfloat sz);

		// -(CATransform3D)CATransform3DMakeTranslation:(CGFloat)tx ty:(CGFloat)ty tz:(CGFloat)tz;
		[Export ("CATransform3DMakeTranslation:ty:tz:")]
		CATransform3D CATransform3DMakeTranslation (nfloat tx, nfloat ty, nfloat tz);

		// -(CATransform3D)CATransform3DConcat:(CATransform3D)a b:(CATransform3D)b;
		[Export ("CATransform3DConcat:b:")]
		CATransform3D CATransform3DConcat (CATransform3D a, CATransform3D b);
	}

	// @interface FBSDKURL : NSObject <FBSDKAppLinkURL>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKURL : IFBSDKAppLinkURL {
		// +(instancetype _Nonnull)URLWithURL:(NSURL * _Nonnull)url __attribute__((swift_name("init(url:)")));
		[Static]
		[Export ("URLWithURL:")]
		FBSDKURL URLWithURL (NSUrl url);

		// +(instancetype _Nonnull)URLWithInboundURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication __attribute__((swift_name("init(inboundURL:sourceApplication:)")));
		[Static]
		[Export ("URLWithInboundURL:sourceApplication:")]
		FBSDKURL URLWithInboundURL (NSUrl url, string sourceApplication);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull targetURL;
		[Export ("targetURL", ArgumentSemantic.Strong)]
		NSUrl TargetURL { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull targetQueryParameters;
		[Export ("targetQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> TargetQueryParameters { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nullable appLinkData;
		[NullAllowed, Export ("appLinkData", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nullable appLinkExtras;
		[NullAllowed, Export ("appLinkExtras", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkExtras { get; }

		// @property (readonly, nonatomic, strong) id<FBSDKAppLink> _Nullable appLinkReferer;
		[NullAllowed, Export ("appLinkReferer", ArgumentSemantic.Strong)]
		IFBSDKAppLink AppLinkReferer { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull inputURL;
		[Export ("inputURL", ArgumentSemantic.Strong)]
		NSUrl InputURL { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull inputQueryParameters;
		[Export ("inputQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> InputQueryParameters { get; }

		// @property (readonly, getter = isAutoAppLink, nonatomic) BOOL isAutoAppLink;
		[Export ("isAutoAppLink")]
		bool IsAutoAppLink { [Bind ("isAutoAppLink")] get; }

		// +(void)configureWithSettings:(id<FBSDKSettings> _Nonnull)settings appLinkFactory:(id<FBSDKAppLinkCreating> _Nonnull)appLinkFactory appLinkTargetFactory:(id<FBSDKAppLinkTargetCreating> _Nonnull)appLinkTargetFactory appLinkEventPoster:(id<FBSDKAppLinkEventPosting> _Nonnull)appLinkEventPoster __attribute__((swift_name("configure(settings:appLinkFactory:appLinkTargetFactory:appLinkEventPoster:)")));
		[Static]
		[Export ("configureWithSettings:appLinkFactory:appLinkTargetFactory:appLinkEventPoster:")]
		void ConfigureWithSettings (IFBSDKSettings settings, IFBSDKAppLinkCreating appLinkFactory, IFBSDKAppLinkTargetCreating appLinkTargetFactory, IFBSDKAppLinkEventPosting appLinkEventPoster);
	}

	// @protocol FBSDKURLOpener
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
	interface FBSDKURLOpener {
		// @required -(void)openURL:(NSURL * _Nonnull)url sender:(id<FBSDKURLOpening> _Nullable)sender handler:(FBSDKSuccessBlock _Nonnull)handler;
		[Abstract]
		[Export ("openURL:sender:handler:")]
		void OpenURL (NSUrl url, [NullAllowed] FBSDKURLOpening sender, FBSDKSuccessBlock handler);

		// @required -(void)openURLWithSafariViewController:(NSURL * _Nonnull)url sender:(id<FBSDKURLOpening> _Nullable)sender fromViewController:(UIViewController * _Nullable)fromViewController handler:(FBSDKSuccessBlock _Nonnull)handler __attribute__((swift_name("openURLWithSafariViewController(url:sender:from:handler:)")));
		[Abstract]
		[Export ("openURLWithSafariViewController:sender:fromViewController:handler:")]
		void OpenURLWithSafariViewController (NSUrl url, [NullAllowed] FBSDKURLOpening sender, [NullAllowed] UIViewController fromViewController, FBSDKSuccessBlock handler);
	}

	// @protocol FBSDKURLOpening <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKURLOpening {
		// @required -(BOOL)application:(UIApplication * _Nullable)application openURL:(NSURL * _Nullable)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
		[Abstract]
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool Application ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// @required -(BOOL)canOpenURL:(NSURL * _Nonnull)url forApplication:(UIApplication * _Nullable)application sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
		[Abstract]
		[Export ("canOpenURL:forApplication:sourceApplication:annotation:")]
		bool CanOpenURL (NSUrl url, [NullAllowed] UIApplication application, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// @required -(void)applicationDidBecomeActive:(UIApplication * _Nonnull)application;
		[Abstract]
		[Export ("applicationDidBecomeActive:")]
		void ApplicationDidBecomeActive (UIApplication application);

		// @required -(BOOL)isAuthenticationURL:(NSURL * _Nonnull)url;
		[Abstract]
		[Export ("isAuthenticationURL:")]
		bool IsAuthenticationURL (NSUrl url);

		// @optional +(instancetype _Nonnull)makeOpener;
		[Static]
		[Export ("makeOpener")]
		FBSDKURLOpening MakeOpener ();

		// @optional -(BOOL)shouldStopPropagationOfURL:(NSURL * _Nonnull)url;
		[Export ("shouldStopPropagationOfURL:")]
		bool ShouldStopPropagationOfURL (NSUrl url);
	}

	// @protocol FBSDKURLSessionProxying
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
	interface FBSDKURLSessionProxying {
		// @required @property (retain, nonatomic) NSOperationQueue * _Nullable delegateQueue;
		[Abstract]
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Retain)]
		NSOperationQueue DelegateQueue { get; set; }

		// @required -(void)executeURLRequest:(NSURLRequest * _Nonnull)request completionHandler:(FBSDKURLSessionTaskBlock _Nonnull)handler;
		[Abstract]
		[Export ("executeURLRequest:completionHandler:")]
		void ExecuteURLRequest (NSUrlRequest request, FBSDKURLSessionTaskBlock handler);

		// @required -(void)invalidateAndCancel;
		[Abstract]
		[Export ("invalidateAndCancel")]
		void InvalidateAndCancel ();
	}
	
	interface IFBSDKURLSessionProxying {}

	// @protocol FBSDKURLSessionProxyProviding
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
	interface FBSDKURLSessionProxyProviding {
		// @required -(id<FBSDKURLSessionProxying> _Nonnull)createSessionProxyWithDelegate:(id<NSURLSessionDataDelegate> _Nullable)delegate queue:(NSOperationQueue * _Nullable)queue;
		[Abstract]
		[Export ("createSessionProxyWithDelegate:queue:")]
		IFBSDKURLSessionProxying Queue ([NullAllowed] NSUrlSessionDataDelegate @delegate, [NullAllowed] NSOperationQueue queue);
	}
	interface IFBSDKURLSessionProxyProviding { }

	// @interface FBSDKURLSessionProxyFactory : NSObject <FBSDKURLSessionProxyProviding>
	[BaseType (typeof (NSObject))]
	interface FBSDKURLSessionProxyFactory : IFBSDKURLSessionProxyProviding {
	}

	// @protocol FBSDKUnarchiverProviding <NSObject>
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
	[BaseType (typeof (NSObject))]
	interface FBSDKUnarchiverProviding {
		// @required +(id<FBSDKObjectDecoding> _Nonnull)createSecureUnarchiverFor:(NSData * _Nonnull)data;
		[Static]
		[Export ("createSecureUnarchiverFor:")]
		FBSDKObjectDecoding CreateSecureUnarchiverFor (NSData data);

		// @required +(id<FBSDKObjectDecoding> _Nonnull)createInsecureUnarchiverFor:(NSData * _Nonnull)data;
		[Static]
		[Export ("createInsecureUnarchiverFor:")]
		FBSDKObjectDecoding CreateInsecureUnarchiverFor (NSData data);
	}

	interface IFBSDKUnarchiverProviding { }

	// @interface FBSDKUnarchiverProvider : NSObject <FBSDKUnarchiverProviding>
	[BaseType (typeof (NSObject))]
	interface FBSDKUnarchiverProvider : IFBSDKUnarchiverProviding {
	}

	// @interface FBSDKUserAgeRange : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKUserAgeRange : INSCopying, INSSecureCoding {
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable min;
		[NullAllowed, Export ("min", ArgumentSemantic.Strong)]
		NSNumber Min { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable max;
		[NullAllowed, Export ("max", ArgumentSemantic.Strong)]
		NSNumber Max { get; }

		// +(instancetype _Nullable)ageRangeFromDictionary:(NSDictionary<NSString *,NSNumber *> * _Nonnull)dictionary;
		[Static]
		[Export ("ageRangeFromDictionary:")]
		[return: NullAllowed]
		FBSDKUserAgeRange AgeRangeFromDictionary (NSDictionary<NSString, NSNumber> dictionary);
	}

	// @protocol FBSDKUserDataPersisting
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
	interface FBSDKUserDataPersisting {
		// @required -(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country externalId:(NSString * _Nullable)externalId __attribute__((swift_name("setUser(email:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:externalId:)")));
		[Abstract]
		[Export ("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:externalId:")]
		void SetUserEmail ([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country, [NullAllowed] string externalId);

		// @required -(NSString * _Nullable)getUserData;
		[Abstract]
		[NullAllowed, Export ("getUserData")]
		string UserData { get; }

		// @required -(void)clearUserData;
		[Abstract]
		[Export ("clearUserData")]
		void ClearUserData ();

		// @required -(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Abstract]
		[Export ("setUserData:forType:")]
		void SetUserData ([NullAllowed] string data, string type);

		// @required -(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Abstract]
		[Export ("clearUserDataForType:")]
		void ClearUserDataForType (string type);

		// @required -(void)setEnabledRules:(NSArray<NSString *> * _Nonnull)rules;
		[Abstract]
		[Export ("setEnabledRules:")]
		void SetEnabledRules (string [] rules);

		// @required -(NSString * _Nullable)getInternalHashedDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Abstract]
		[Export ("getInternalHashedDataForType:")]
		[return: NullAllowed]
		string GetInternalHashedDataForType (string type);

		// @required -(void)setInternalHashData:(NSString * _Nullable)hashData forType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Abstract]
		[Export ("setInternalHashData:forType:")]
		void SetInternalHashData ([NullAllowed] string hashData, string type);
	}

	interface IFBSDKUserDataPersisting {
	}

	// @interface FBSDKUserDataStore : NSObject <FBSDKUserDataPersisting>
	[BaseType (typeof (NSObject))]
	interface FBSDKUserDataStore : IFBSDKUserDataPersisting {
		// -(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country externalId:(NSString * _Nullable)externalId __attribute__((swift_name("setUser(email:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:externalId:)")));
		[Export ("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:externalId:")]
		void SetUserEmail ([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country, [NullAllowed] string externalId);

		// -(NSString * _Nullable)getUserData;
		[NullAllowed, Export ("getUserData")]
		string UserData { get; }

		// -(void)clearUserData;
		[Export ("clearUserData")]
		void ClearUserData ();

		// -(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Export ("setUserData:forType:")]
		void SetUserData ([NullAllowed] string data, string type);

		// -(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Export ("clearUserDataForType:")]
		void ClearUserDataForType (string type);
	}

	// @interface FBSDKUtility : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface FBSDKUtility {
		// +(NSDictionary<NSString *,NSString *> * _Nonnull)dictionaryWithQueryString:(NSString * _Nonnull)queryString __attribute__((swift_name("dictionary(withQuery:)")));
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary<NSString, NSString> DictionaryWithQueryString (string queryString);

		// +(NSString * _Nonnull)queryStringWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("query(from:)"))) __attribute__((swift_error("nonnull_error")));
		[Static]
		[Export ("queryStringWithDictionary:error:")]
		string QueryStringWithDictionary (NSDictionary<NSString, NSObject> dictionary, [NullAllowed] out NSError errorRef);

		// +(NSString * _Nonnull)URLDecode:(NSString * _Nonnull)value __attribute__((swift_name("decode(urlString:)")));
		[Static]
		[Export ("URLDecode:")]
		string URLDecode (string value);

		// +(NSString * _Nonnull)URLEncode:(NSString * _Nonnull)value __attribute__((swift_name("encode(urlString:)")));
		[Static]
		[Export ("URLEncode:")]
		string URLEncode (string value);

		// +(dispatch_source_t _Nonnull)startGCDTimerWithInterval:(double)interval block:(dispatch_block_t _Nonnull)block;
		[Static]
		[Export ("startGCDTimerWithInterval:block:")]
		IntPtr StartGCDTimerWithInterval (double interval, IntPtr block);

		// +(void)stopGCDTimer:(dispatch_source_t _Nonnull)timer;
		[Static]
		[Export ("stopGCDTimer:")]
		unsafe void StopGCDTimer (IntPtr timer);

		// +(NSString * _Nullable)SHA256Hash:(NSObject * _Nonnull)input __attribute__((swift_name("sha256Hash(_:)")));
		[Static]
		[Export ("SHA256Hash:")]
		[return: NullAllowed]
		string SHA256Hash (NSObject input);

		// +(NSString * _Nullable)getGraphDomainFromToken;
		[Static]
		[NullAllowed, Export ("getGraphDomainFromToken")]
		string GraphDomainFromToken { get; }

		// +(NSURL * _Nonnull)unversionedFacebookURLWithHostPrefix:(NSString * _Nonnull)hostPrefix path:(NSString * _Nonnull)path queryParameters:(NSDictionary<NSString *,id> * _Nonnull)queryParameters error:(NSError * _Nullable * _Nullable)errorRef;
		[Static]
		[Export ("unversionedFacebookURLWithHostPrefix:path:queryParameters:error:")]
		NSUrl UnversionedFacebookURLWithHostPrefix (string hostPrefix, string path, NSDictionary<NSString, NSObject> queryParameters, [NullAllowed] out NSError errorRef);
	}

	// @protocol FBSDKWebDialogDelegate
	[Protocol, Model]
	interface FBSDKWebDialogDelegate {
		// @required -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
		[Abstract]
		[Export ("webDialog:didCompleteWithResults:")]
		void WebDialog (FBSDKWebDialog webDialog, NSDictionary<NSString, NSObject> results);

		// @required -(void)webDialog:(FBSDKWebDialog * _Nonnull)webDialog didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("webDialog:didFailWithError:")]
		void WebDialog (FBSDKWebDialog webDialog, NSError error);

		// @required -(void)webDialogDidCancel:(FBSDKWebDialog * _Nonnull)webDialog;
		[Abstract]
		[Export ("webDialogDidCancel:")]
		void WebDialogDidCancel (FBSDKWebDialog webDialog);
	}
	
	interface IFBSDKWebDialogDelegate {}

	// @interface FBSDKWebDialogView : UIView
	[BaseType (typeof (UIView))]
	interface FBSDKWebDialogView {
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		FBSDKWebDialogViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<FBSDKWebDialogViewDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)loadURL:(NSURL * _Nonnull)URL;
		[Export ("loadURL:")]
		void LoadURL (NSUrl URL);

		// -(void)stopLoading;
		[Export ("stopLoading")]
		void StopLoading ();

		// +(void)configureWithWebViewProvider:(id<FBSDKWebViewProviding> _Nonnull)webViewProvider urlOpener:(id<FBSDKInternalURLOpener> _Nonnull)urlOpener errorFactory:(id<FBSDKErrorCreating> _Nonnull)errorFactory __attribute__((swift_name("configure(webViewProvider:urlOpener:errorFactory:)")));
		[Static]
		[Export ("configureWithWebViewProvider:urlOpener:errorFactory:")]
		void ConfigureWithWebViewProvider (IFBSDKWebViewProviding webViewProvider, IFBSDKInternalURLOpener urlOpener, IFBSDKErrorCreating errorFactory);
	}

	// @protocol FBSDKWebDialogViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface FBSDKWebDialogViewDelegate {
		// @required -(void)webDialogView:(FBSDKWebDialogView * _Nonnull)webDialogView didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
		[Abstract]
		[Export ("webDialogView:didCompleteWithResults:")]
		void WebDialogView (FBSDKWebDialogView webDialogView, NSDictionary<NSString, NSObject> results);

		// @required -(void)webDialogView:(FBSDKWebDialogView * _Nonnull)webDialogView didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("webDialogView:didFailWithError:")]
		void WebDialogView (FBSDKWebDialogView webDialogView, NSError error);

		// @required -(void)webDialogViewDidCancel:(FBSDKWebDialogView * _Nonnull)webDialogView;
		[Abstract]
		[Export ("webDialogViewDidCancel:")]
		void WebDialogViewDidCancel (FBSDKWebDialogView webDialogView);

		// @required -(void)webDialogViewDidFinishLoad:(FBSDKWebDialogView * _Nonnull)webDialogView;
		[Abstract]
		[Export ("webDialogViewDidFinishLoad:")]
		void WebDialogViewDidFinishLoad (FBSDKWebDialogView webDialogView);
	}

	// @protocol FBSDKWebView
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
	interface FBSDKWebView {
		[Wrap ("WeakNavigationDelegate"), Abstract]
		[NullAllowed]
		WKNavigationDelegate NavigationDelegate { get; set; }
		
		// @required @property (nonatomic, weak) id<WKNavigationDelegate> _Nullable navigationDelegate;
		[Abstract]
		[NullAllowed, Export ("navigationDelegate", ArgumentSemantic.Weak)]
		NSObject WeakNavigationDelegate { get; set; }

		// @required @property (nonatomic) CGRect frame;
		[Abstract]
		[Export ("frame", ArgumentSemantic.Assign)]
		CGRect Frame { get; set; }

		// @required @property (nonatomic) CGRect bounds;
		[Abstract]
		[Export ("bounds", ArgumentSemantic.Assign)]
		CGRect Bounds { get; set; }

		// @required -(WKNavigation * _Nullable)loadRequest:(NSURLRequest * _Nonnull)request;
		[Abstract]
		[Export ("loadRequest:")]
		[return: NullAllowed]
		WKNavigation LoadRequest (NSUrlRequest request);

		// @required -(void)stopLoading;
		[Abstract]
		[Export ("stopLoading")]
		void StopLoading ();
	}

	interface IFBSDKWebView { }

	// @interface FBSDKWebViewAppLinkResolver : NSObject <FBSDKAppLinkResolving>
	[BaseType (typeof (NSObject))]
	interface FBSDKWebViewAppLinkResolver : IFBSDKAppLinkResolving {
		// @property (readonly, nonatomic, strong, class) NS_SWIFT_NAME(shared) FBSDKWebViewAppLinkResolver * sharedInstance __attribute__((swift_name("shared")));
		[Static]
		[Export ("sharedInstance", ArgumentSemantic.Strong)]
		FBSDKWebViewAppLinkResolver SharedInstance { get; }
	}

	// @protocol FBSDKWebViewProviding
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
	interface FBSDKWebViewProviding {
		// @required -(id<FBSDKWebView> _Nonnull)createWebViewWithFrame:(CGRect)frame __attribute__((swift_name("createWebView(frame:)")));
		[Abstract]
		[Export ("createWebViewWithFrame:")]
		IFBSDKWebView CreateWebViewWithFrame (CGRect frame);
	}
	
	interface IFBSDKWebViewProviding {}
	
	[Category]
	[BaseType (typeof (NSNotificationCenter))]
	interface NSNotificationCenter_NotificationPosting : I_FBSDKNotificationPosting {
	}
	
	[Category]
	[BaseType (typeof (NSProcessInfo))]
	interface NSProcessInfo_MacCatalystDetermining : IFBSDKMacCatalystDetermining {
	}
	
	[Category]
	[BaseType (typeof (NSProcessInfo))]
	interface NSProcessInfo_OperatingSystemVersionComparing : IFBSDKOperatingSystemVersionComparing {
	}

	// @interface URLOpener (UIApplication) <FBSDKInternalURLOpener>
	[Category]
	[BaseType (typeof (UIApplication))]
	interface UIApplication_URLOpener : IFBSDKInternalURLOpener {
	}

	// @interface FBSDKPasteboard (UIPasteboard) <FBSDKPasteboard>
	[Category]
	[BaseType (typeof (UIPasteboard))]
	interface UIPasteboard_FBSDKPasteboard : IFBSDKPasteboard {
	}

	// @interface FBSDKWebView (WKWebView) <FBSDKWebView>
	[Category]
	[BaseType (typeof (WKWebView))]
	interface WKWebView_FBSDKWebView : IFBSDKWebView {
	}

	// @protocol FBSDKSettings
	/*
	  Check whether adding [Model] to this declaration is appropriate.
	  [Model] is used to generate a C# class that implements this protocol,
	  and might be useful for protocols that consumers are supposed to implement,
	  since consumers can subclass the generated class instead of implementing
	  the generated interface. If consumers are not supposed to implement this
	  protocol, then [Model] is redundant and will generate code that will never
	  be used.
	*/
/*	[Protocol]
    [DisableDefaultCtor]
	interface FBSDKSettings {
		// @required @property (copy, nonatomic) NSString * _Nullable appID;
		[Abstract]
		[NullAllowed, Export ("appID")]
		string AppID { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable clientToken;
		[Abstract]
		[NullAllowed, Export ("clientToken")]
		string ClientToken { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable userAgentSuffix;
		[Abstract]
		[NullAllowed, Export ("userAgentSuffix")]
		string UserAgentSuffix { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull sdkVersion;
		[Abstract]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// @required @property (copy, nonatomic) NSString * _Nullable displayName;
		[Abstract]
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable facebookDomainPart;
		[Abstract]
		[NullAllowed, Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		// @required @property (copy, nonatomic) NSSet<FBSDKLoggingBehavior> * _Nonnull loggingBehaviors;
		[Abstract]
		[Export ("loggingBehaviors", ArgumentSemantic.Copy)]
		NSSet<NSString> LoggingBehaviors { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable appURLSchemeSuffix;
		[Abstract]
		[NullAllowed, Export ("appURLSchemeSuffix")]
		string AppURLSchemeSuffix { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDataProcessingRestricted;
		[Abstract]
		[Export ("isDataProcessingRestricted")]
		bool IsDataProcessingRestricted { get; }

		// @required @property (readonly, nonatomic) BOOL isAutoLogAppEventsEnabled;
		[Abstract]
		[Export ("isAutoLogAppEventsEnabled")]
		bool IsAutoLogAppEventsEnabled { get; }

		// @required @property (nonatomic) BOOL codelessDebugLogEnabled __attribute__((deprecated("
		//This property is deprecated and will be removed in the next major release.Use `isCodelessDebugLogEnabled` instead.
  //      ")));

	  [Abstract]
	[Export ("codelessDebugLogEnabled")]
	bool CodelessDebugLogEnabled { get; set; }

		// @required @property (nonatomic) BOOL isCodelessDebugLogEnabled;
		[Abstract]
		[Export ("isCodelessDebugLogEnabled")]
		bool IsCodelessDebugLogEnabled { get; set; }

		// @required @property (nonatomic) BOOL advertiserIDCollectionEnabled __attribute__((deprecated("
		//This property is deprecated and will be removed in the next major release.Use `isAdvertiserIDCollectionEnabled` instead.
  //      ")));

	  [Abstract]
	[Export ("advertiserIDCollectionEnabled")]
	bool AdvertiserIDCollectionEnabled { get; set; }

		// @required @property (nonatomic) BOOL isAdvertiserIDCollectionEnabled;
		[Abstract]
		[Export ("isAdvertiserIDCollectionEnabled")]
		bool IsAdvertiserIDCollectionEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isSetATETimeExceedsInstallTime __attribute__((deprecated("
		//This property is deprecated and will be removed in the next major release.Use `isATETimeSufficientlyDelayed` instead.
  //      ")));

	  [Abstract]
	[Export ("isSetATETimeExceedsInstallTime")]
	bool IsSetATETimeExceedsInstallTime { get; }

		// @required @property (readonly, nonatomic) BOOL isATETimeSufficientlyDelayed;
		[Abstract]
		[Export ("isATETimeSufficientlyDelayed")]
		bool IsATETimeSufficientlyDelayed { get; }

		// @required @property (readonly, nonatomic) BOOL isSKAdNetworkReportEnabled;
		[Abstract]
		[Export ("isSKAdNetworkReportEnabled")]
		bool IsSKAdNetworkReportEnabled { get; }

		// @required @property (readonly, nonatomic) FBSDKAdvertisingTrackingStatus advertisingTrackingStatus;
		[Abstract]
		[Export ("advertisingTrackingStatus")]
		FBSDKAdvertisingTrackingStatus AdvertisingTrackingStatus { get; }

		// @required @property (readonly, copy, nonatomic) NSDate * _Nullable installTimestamp;
		[Abstract]
		[NullAllowed, Export ("installTimestamp", ArgumentSemantic.Copy)]
		NSDate InstallTimestamp { get; }

		// @required @property (readonly, copy, nonatomic) NSDate * _Nullable advertiserTrackingEnabledTimestamp;
		[Abstract]
		[NullAllowed, Export ("advertiserTrackingEnabledTimestamp", ArgumentSemantic.Copy)]
		NSDate AdvertiserTrackingEnabledTimestamp { get; }

		// @required @property (nonatomic) BOOL isEventDataUsageLimited;
		[Abstract]
		[Export ("isEventDataUsageLimited")]
		bool IsEventDataUsageLimited { get; set; }

		// @required @property (nonatomic) BOOL shouldUseTokenOptimizations;
		[Abstract]
		[Export ("shouldUseTokenOptimizations")]
		bool ShouldUseTokenOptimizations { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nonnull graphAPIVersion;
		[Abstract]
		[Export ("graphAPIVersion")]
		string GraphAPIVersion { get; set; }

		// @required @property (nonatomic) BOOL isGraphErrorRecoveryEnabled;
		[Abstract]
		[Export ("isGraphErrorRecoveryEnabled")]
		bool IsGraphErrorRecoveryEnabled { get; set; }

		// @required @property (readonly, copy, nonatomic) SWIFT_DEPRECATED_MSG("\n      This property is deprecated and will be removed in the next major release.       Use `graphAPIDebugParameterValue` instead.\n      ") NSString * graphAPIDebugParamValue __attribute__((deprecated("
		//This property is deprecated and will be removed in the next major release.Use `graphAPIDebugParameterValue` instead.
  //      ")));

	  [Abstract]
	[Export ("graphAPIDebugParamValue")]
	string GraphAPIDebugParamValue { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable graphAPIDebugParameterValue;
		[Abstract]
		[NullAllowed, Export ("graphAPIDebugParameterValue")]
		string GraphAPIDebugParameterValue { get; }

		// @required @property (nonatomic) BOOL advertiserTrackingEnabled __attribute__((deprecated("
		//This property is deprecated and will be removed in the next major release.Use `isAdvertiserTrackingEnabled` instead.
  //      ")));

	  [Abstract]
	[Export ("advertiserTrackingEnabled")]
	bool AdvertiserTrackingEnabled { get; set; }

		// @required @property (nonatomic) BOOL isAdvertiserTrackingEnabled;
		[Abstract]
		[Export ("isAdvertiserTrackingEnabled")]
		bool IsAdvertiserTrackingEnabled { get; set; }

		// @required @property (nonatomic) BOOL shouldUseCachedValuesForExpensiveMetadata;
		[Abstract]
		[Export ("shouldUseCachedValuesForExpensiveMetadata")]
		bool ShouldUseCachedValuesForExpensiveMetadata { get; set; }

		// @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable persistableDataProcessingOptions;
		[Abstract]
		[NullAllowed, Export ("persistableDataProcessingOptions", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> PersistableDataProcessingOptions { get; }

		// @required -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options;
		[Abstract]
		[Export ("setDataProcessingOptions:")]
		void SetDataProcessingOptions ([NullAllowed] string [] options);

		// @required -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options country:(int32_t)country state:(int32_t)state;
		[Abstract]
		[Export ("setDataProcessingOptions:country:state:")]
		void Country ([NullAllowed] string [] options, int country, int state);
	}

	interface IFBSDKSettings { }
	
	[BaseType(NSObject)]
	interface FBSDKSettingsModel : FBSDKSettings{
	
	}*/
	
// @protocol FBSDKSettings
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. IFBSDKATEPublishingf consumers are not supposed to implement this
  be used.
*/[Protocol]
interface FBSDKSettings
{
	// @required @property (copy, nonatomic) NSString * _Nullable appID;
	[Abstract]
	[NullAllowed, Export ("appID")]
	string AppID { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable clientToken;
	[Abstract]
	[NullAllowed, Export ("clientToken")]
	string ClientToken { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable userAgentSuffix;
	[Abstract]
	[NullAllowed, Export ("userAgentSuffix")]
	string UserAgentSuffix { get; set; }

	// @required @property (readonly, copy, nonatomic) NSString * _Nonnull sdkVersion;
	[Abstract]
	[Export ("sdkVersion")]
	string SdkVersion { get; }

	// @required @property (copy, nonatomic) NSString * _Nullable displayName;
	[Abstract]
	[NullAllowed, Export ("displayName")]
	string DisplayName { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable facebookDomainPart;
	[Abstract]
	[NullAllowed, Export ("facebookDomainPart")]
	string FacebookDomainPart { get; set; }

	// @required @property (copy, nonatomic) NSSet<FBSDKLoggingBehavior> * _Nonnull loggingBehaviors;
	[Abstract]
	[Export ("loggingBehaviors", ArgumentSemantic.Copy)]
	NSSet<NSString> LoggingBehaviors { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nullable appURLSchemeSuffix;
	[Abstract]
	[NullAllowed, Export ("appURLSchemeSuffix")]
	string AppURLSchemeSuffix { get; set; }

	// @required @property (readonly, nonatomic) BOOL isDataProcessingRestricted;
	[Abstract]
	[Export ("isDataProcessingRestricted")]
	bool IsDataProcessingRestricted { get; }

	// @required @property (readonly, nonatomic) BOOL isAutoLogAppEventsEnabled;
	[Abstract]
	[Export ("isAutoLogAppEventsEnabled")]
	bool IsAutoLogAppEventsEnabled { get; }

	// @required @property (nonatomic) BOOL codelessDebugLogEnabled __attribute__((deprecated("
	[Abstract]
	[Export ("codelessDebugLogEnabled")]
	bool CodelessDebugLogEnabled { get; set; }

	// @required @property (nonatomic) BOOL isCodelessDebugLogEnabled;
	[Abstract]
	[Export ("isCodelessDebugLogEnabled")]
	bool IsCodelessDebugLogEnabled { get; set; }

	// @required @property (nonatomic) BOOL advertiserIDCollectionEnabled __attribute__((deprecated("
	[Abstract]
	[Export ("advertiserIDCollectionEnabled")]
	bool AdvertiserIDCollectionEnabled { get; set; }

	// @required @property (nonatomic) BOOL isAdvertiserIDCollectionEnabled;
	[Abstract]
	[Export ("isAdvertiserIDCollectionEnabled")]
	bool IsAdvertiserIDCollectionEnabled { get; set; }

	// @required @property (readonly, nonatomic) BOOL isSetATETimeExceedsInstallTime __attribute__((deprecated("
	[Abstract]
	[Export ("isSetATETimeExceedsInstallTime")]
	bool IsSetATETimeExceedsInstallTime { get; }

	// @required @property (readonly, nonatomic) BOOL isATETimeSufficientlyDelayed;
	[Abstract]
	[Export ("isATETimeSufficientlyDelayed")]
	bool IsATETimeSufficientlyDelayed { get; }

	// @required @property (readonly, nonatomic) BOOL isSKAdNetworkReportEnabled;
	[Abstract]
	[Export ("isSKAdNetworkReportEnabled")]
	bool IsSKAdNetworkReportEnabled { get; }

	// @required @property (readonly, nonatomic) FBSDKAdvertisingTrackingStatus advertisingTrackingStatus;
	[Abstract]
	[Export ("advertisingTrackingStatus")]
	FBSDKAdvertisingTrackingStatus AdvertisingTrackingStatus { get; }

	// @required @property (readonly, copy, nonatomic) NSDate * _Nullable installTimestamp;
	[Abstract]
	[NullAllowed, Export ("installTimestamp", ArgumentSemantic.Copy)]
	NSDate InstallTimestamp { get; }

	// @required @property (readonly, copy, nonatomic) NSDate * _Nullable advertiserTrackingEnabledTimestamp;
	[Abstract]
	[NullAllowed, Export ("advertiserTrackingEnabledTimestamp", ArgumentSemantic.Copy)]
	NSDate AdvertiserTrackingEnabledTimestamp { get; }

	// @required @property (nonatomic) BOOL isEventDataUsageLimited;
	[Abstract]
	[Export ("isEventDataUsageLimited")]
	bool IsEventDataUsageLimited { get; set; }

	// @required @property (nonatomic) BOOL shouldUseTokenOptimizations;
	[Abstract]
	[Export ("shouldUseTokenOptimizations")]
	bool ShouldUseTokenOptimizations { get; set; }

	// @required @property (copy, nonatomic) NSString * _Nonnull graphAPIVersion;
	[Abstract]
	[Export ("graphAPIVersion")]
	string GraphAPIVersion { get; set; }

	// @required @property (nonatomic) BOOL isGraphErrorRecoveryEnabled;
	[Abstract]
	[Export ("isGraphErrorRecoveryEnabled")]
	bool IsGraphErrorRecoveryEnabled { get; set; }

	// @required @property (readonly, copy, nonatomic) SWIFT_DEPRECATED_MSG("\n      This property is deprecated and will be removed in the next major release.       Use `graphAPIDebugParameterValue` instead.\n      ") NSString * graphAPIDebugParamValue __attribute__((deprecated("
   
	[Abstract]
	[Export ("graphAPIDebugParamValue")]
	string GraphAPIDebugParamValue { get; }

	// @required @property (readonly, copy, nonatomic) NSString * _Nullable graphAPIDebugParameterValue;
	[Abstract]
	[NullAllowed, Export ("graphAPIDebugParameterValue")]
	string GraphAPIDebugParameterValue { get; }

	// @required @property (nonatomic) BOOL advertiserTrackingEnabled __attribute__((deprecated("
	[Abstract]
	[Export ("advertiserTrackingEnabled")]
	bool AdvertiserTrackingEnabled { get; set; }

	// @required @property (nonatomic) BOOL isAdvertiserTrackingEnabled;
	[Abstract]
	[Export ("isAdvertiserTrackingEnabled")]
	bool IsAdvertiserTrackingEnabled { get; set; }

	// @required @property (nonatomic) BOOL shouldUseCachedValuesForExpensiveMetadata;
	[Abstract]
	[Export ("shouldUseCachedValuesForExpensiveMetadata")]
	bool ShouldUseCachedValuesForExpensiveMetadata { get; set; }

	// @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable persistableDataProcessingOptions;
	[Abstract]
	[NullAllowed, Export ("persistableDataProcessingOptions", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSObject> PersistableDataProcessingOptions { get; }

	// @required -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options;
	[Abstract]
	[Export ("setDataProcessingOptions:")]
	void SetDataProcessingOptions ([NullAllowed] string[] options);

	// @required -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options country:(int32_t)country state:(int32_t)state;
	[Abstract]
	[Export ("setDataProcessingOptions:country:state:")]
	void Country ([NullAllowed] string[] options, int country, int state);
}

interface IFBSDKSettings {
}

// @interface FBSDKSettings : NSObject <FBSDKSettingsLogging, FBSDKSettings, FBSDKClientTokenProviding>
[BaseType (typeof(NSObject), Name = "FBSDKSettings")]
interface FBSDKSettingsModel : IFBSDKSettingsLogging, IFBSDKSettings, IFBSDKClientTokenProviding
{
	// @property (readonly, nonatomic, strong, class) FBSDKSettings * _Nonnull sharedSettings;
	[Static]
	[Export ("sharedSettings", ArgumentSemantic.Strong)]
	FBSDKSettingsModel SharedSettings { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull sdkVersion;
	[Export ("sdkVersion")]
	string SdkVersion { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nonnull defaultGraphAPIVersion;
	[Export ("defaultGraphAPIVersion")]
	string DefaultGraphAPIVersion { get; }

	// @property (nonatomic) CGFloat JPEGCompressionQuality;
	[Export ("JPEGCompressionQuality")]
	nfloat JPEGCompressionQuality { get; set; }

	// @property (nonatomic) BOOL autoLogAppEventsEnabled __attribute__((deprecated("

	[Export ("autoLogAppEventsEnabled")]
	bool AutoLogAppEventsEnabled { get; set; }

	// @property (nonatomic) BOOL isAutoLogAppEventsEnabled;
	[Export ("isAutoLogAppEventsEnabled")]
	bool IsAutoLogAppEventsEnabled { get; set; }

	// @property (nonatomic) BOOL codelessDebugLogEnabled __attribute__((deprecated("
	[Export ("codelessDebugLogEnabled")]
	bool CodelessDebugLogEnabled { get; set; }

	// @property (nonatomic) BOOL isCodelessDebugLogEnabled;
	[Export ("isCodelessDebugLogEnabled")]
	bool IsCodelessDebugLogEnabled { get; set; }

	// @property (nonatomic) BOOL advertiserIDCollectionEnabled __attribute__((deprecated("
	[Export ("advertiserIDCollectionEnabled")]
	bool AdvertiserIDCollectionEnabled { get; set; }

	// @property (nonatomic) BOOL isAdvertiserIDCollectionEnabled;
	[Export ("isAdvertiserIDCollectionEnabled")]
	bool IsAdvertiserIDCollectionEnabled { get; set; }

	// @property (nonatomic) BOOL skAdNetworkReportEnabled __attribute__((deprecated("
	[Export ("skAdNetworkReportEnabled")]
	bool SkAdNetworkReportEnabled { get; set; }

	// @property (nonatomic) BOOL isSKAdNetworkReportEnabled;
	[Export ("isSKAdNetworkReportEnabled")]
	bool IsSKAdNetworkReportEnabled { get; set; }

	// @property (nonatomic) BOOL isEventDataUsageLimited;
	[Export ("isEventDataUsageLimited")]
	bool IsEventDataUsageLimited { get; set; }

	// @property (nonatomic) BOOL shouldUseCachedValuesForExpensiveMetadata;
	[Export ("shouldUseCachedValuesForExpensiveMetadata")]
	bool ShouldUseCachedValuesForExpensiveMetadata { get; set; }

	// @property (nonatomic) BOOL isGraphErrorRecoveryEnabled;
	[Export ("isGraphErrorRecoveryEnabled")]
	bool IsGraphErrorRecoveryEnabled { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable appID;
	[NullAllowed, Export ("appID")]
	string AppID { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable appURLSchemeSuffix;
	[NullAllowed, Export ("appURLSchemeSuffix")]
	string AppURLSchemeSuffix { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable clientToken;
	[NullAllowed, Export ("clientToken")]
	string ClientToken { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable displayName;
	[NullAllowed, Export ("displayName")]
	string DisplayName { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable facebookDomainPart;
	[NullAllowed, Export ("facebookDomainPart")]
	string FacebookDomainPart { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull graphAPIVersion;
	[Export ("graphAPIVersion")]
	string GraphAPIVersion { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable userAgentSuffix;
	[NullAllowed, Export ("userAgentSuffix")]
	string UserAgentSuffix { get; set; }

	// @property (nonatomic) BOOL advertiserTrackingEnabled __attribute__((deprecated("
 
	[Export ("advertiserTrackingEnabled")]
	bool AdvertiserTrackingEnabled { get; set; }

	// @property (nonatomic) BOOL isAdvertiserTrackingEnabled;
	[Export ("isAdvertiserTrackingEnabled")]
	bool IsAdvertiserTrackingEnabled { get; set; }

	// @property (nonatomic) FBSDKAdvertisingTrackingStatus advertisingTrackingStatus;
	[Export ("advertisingTrackingStatus", ArgumentSemantic.Assign)]
	FBSDKAdvertisingTrackingStatus AdvertisingTrackingStatus { get; set; }

	// @property (readonly, nonatomic) BOOL isDataProcessingRestricted;
	[Export ("isDataProcessingRestricted")]
	bool IsDataProcessingRestricted { get; }

	// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable persistableDataProcessingOptions;
	[NullAllowed, Export ("persistableDataProcessingOptions", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSObject> PersistableDataProcessingOptions { get; }

	// -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options;
	[Export ("setDataProcessingOptions:")]
	void SetDataProcessingOptions ([NullAllowed] string[] options);

	// -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options country:(int32_t)country state:(int32_t)state;
	[Export ("setDataProcessingOptions:country:state:")]
	void SetDataProcessingOptions ([NullAllowed] string[] options, int country, int state);

	// @property (copy, nonatomic) NSSet<FBSDKLoggingBehavior> * _Nonnull loggingBehaviors;
	[Export ("loggingBehaviors", ArgumentSemantic.Copy)]
	NSSet<NSString> LoggingBehaviors { get; set; }

	// -(void)enableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
	[Export ("enableLoggingBehavior:")]
	void EnableLoggingBehavior (string loggingBehavior);

	// -(void)disableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
	[Export ("disableLoggingBehavior:")]
	void DisableLoggingBehavior (string loggingBehavior);

	// @property (nonatomic) BOOL shouldUseTokenOptimizations;
	[Export ("shouldUseTokenOptimizations")]
	bool ShouldUseTokenOptimizations { get; set; }

	// @property (readonly, nonatomic) BOOL isSetATETimeExceedsInstallTime __attribute__((deprecated("
	[Export ("isSetATETimeExceedsInstallTime")]
	bool IsSetATETimeExceedsInstallTime { get; }

	// @property (readonly, nonatomic) BOOL isATETimeSufficientlyDelayed;
	[Export ("isATETimeSufficientlyDelayed")]
	bool IsATETimeSufficientlyDelayed { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable installTimestamp;
	[NullAllowed, Export ("installTimestamp", ArgumentSemantic.Copy)]
	NSDate InstallTimestamp { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable advertiserTrackingEnabledTimestamp;
	[NullAllowed, Export ("advertiserTrackingEnabledTimestamp", ArgumentSemantic.Copy)]
	NSDate AdvertiserTrackingEnabledTimestamp { get; }

	// @property (readonly, copy, nonatomic) SWIFT_DEPRECATED_MSG("\n      This property is deprecated and will be removed in the next major release.       Use `graphAPIDebugParameterValue` instead.\n      ") NSString * graphAPIDebugParamValue __attribute__((deprecated("
   
	[Export ("graphAPIDebugParamValue")]
	string GraphAPIDebugParamValue { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable graphAPIDebugParameterValue;
	[NullAllowed, Export ("graphAPIDebugParameterValue")]
	string GraphAPIDebugParameterValue { get; }
}
	
	// @interface FBSDKWebDialog : NSObject
    [BaseType (typeof(NSObject))]
    [DisableDefaultCtor]
    interface FBSDKWebDialog
    {
    	// @property (nonatomic) BOOL shouldDeferVisibility;
    	[Export ("shouldDeferVisibility")]
    	bool ShouldDeferVisibility { get; set; }
    
    	[Wrap ("WeakDelegate")]
    	[NullAllowed]
    	IFBSDKWebDialogDelegate Delegate { get; set; }
    
    	// @property (nonatomic, weak) id<FBSDKWebDialogDelegate> _Nullable delegate;
    	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
    	NSObject WeakDelegate { get; set; }
    
    	// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name parameters:(NSDictionary<NSString *,NSString *> * _Nullable)parameters webViewFrame:(CGRect)webViewFrame path:(NSString * _Nullable)path __attribute__((objc_designated_initializer));
    	[Export ("initWithName:parameters:webViewFrame:path:")]
    	[DesignatedInitializer]
    	NativeHandle Constructor (string name, [NullAllowed] NSDictionary<NSString, NSString> parameters, CGRect webViewFrame, [NullAllowed] string path);
    
    	// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name;
    	[Export ("initWithName:")]
    	NativeHandle Constructor (string name);
    
    	// -(void)show;
    	[Export ("show")]
    	void Show ();
    }
    
    // @interface FBSDKIcon : NSObject
    [BaseType (typeof(NSObject))]
    interface FBSDKIcon
    {
    	// -(CGPathRef _Nullable)pathWith:(CGSize)size __attribute__((warn_unused_result("")));
    	[Export ("pathWith:")]
    	[return: NullAllowed]
    	CGPath PathWith (CGSize size);
    
    	// -(UIImage * _Nullable)imageWithSize:(CGSize)size __attribute__((warn_unused_result("")));
    	[Export ("imageWithSize:")]
    	[return: NullAllowed]
    	UIImage ImageWithSize (CGSize size);
    
    	// -(UIImage * _Nullable)imageWithSize:(CGSize)size color:(UIColor * _Nonnull)color __attribute__((warn_unused_result("")));
    	[Export ("imageWithSize:color:")]
    	[return: NullAllowed]
    	UIImage ImageWithSize (CGSize size, UIColor color);
    
    	// -(UIImage * _Nullable)imageWithSize:(CGSize)size scale:(CGFloat)scale color:(UIColor * _Nonnull)color __attribute__((warn_unused_result("")));
    	[Export ("imageWithSize:scale:color:")]
    	[return: NullAllowed]
    	UIImage ImageWithSize (CGSize size, nfloat scale, UIColor color);
    }
    
    // @interface FBSDKProfile : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKProfile
{
	// @property (readonly, copy, nonatomic) FBSDKUserIdentifier _Nonnull userID;
	[Export ("userID")]
	string UserID { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable firstName;
	[NullAllowed, Export ("firstName")]
	string FirstName { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable middleName;
	[NullAllowed, Export ("middleName")]
	string MiddleName { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable lastName;
	[NullAllowed, Export ("lastName")]
	string LastName { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; }

	// @property (readonly, copy, nonatomic) NSURL * _Nullable linkURL;
	[NullAllowed, Export ("linkURL", ArgumentSemantic.Copy)]
	NSUrl LinkURL { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nonnull refreshDate;
	[Export ("refreshDate", ArgumentSemantic.Copy)]
	NSDate RefreshDate { get; }

	// @property (readonly, copy, nonatomic) NSURL * _Nullable imageURL;
	[NullAllowed, Export ("imageURL", ArgumentSemantic.Copy)]
	NSUrl ImageURL { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable email;
	[NullAllowed, Export ("email")]
	string Email { get; }

	// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable friendIDs;
	[NullAllowed, Export ("friendIDs", ArgumentSemantic.Copy)]
	string[] FriendIDs { get; }

	// @property (readonly, copy, nonatomic) NSDate * _Nullable birthday;
	[NullAllowed, Export ("birthday", ArgumentSemantic.Copy)]
	NSDate Birthday { get; }

	// @property (readonly, nonatomic, strong) FBSDKUserAgeRange * _Nullable ageRange;
	[NullAllowed, Export ("ageRange", ArgumentSemantic.Strong)]
	FBSDKUserAgeRange AgeRange { get; }

	// @property (readonly, nonatomic, strong) FBSDKLocation * _Nullable hometown;
	[NullAllowed, Export ("hometown", ArgumentSemantic.Strong)]
	FBSDKLocation Hometown { get; }

	// @property (readonly, nonatomic, strong) FBSDKLocation * _Nullable location;
	[NullAllowed, Export ("location", ArgumentSemantic.Strong)]
	FBSDKLocation Location { get; }

	// @property (readonly, copy, nonatomic) NSString * _Nullable gender;
	[NullAllowed, Export ("gender")]
	string Gender { get; }

	// @property (nonatomic, class) BOOL isUpdatedWithAccessTokenChange;
	[Static]
	[Export ("isUpdatedWithAccessTokenChange")]
	bool IsUpdatedWithAccessTokenChange { get; set; }

	// -(instancetype _Nonnull)initWithUserID:(FBSDKUserIdentifier _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate;
	[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:")]
	NativeHandle Constructor (string userID, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkURL, [NullAllowed] NSDate refreshDate);

	// -(instancetype _Nonnull)initWithUserID:(FBSDKUserIdentifier _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate imageURL:(NSURL * _Nullable)imageURL email:(NSString * _Nullable)email friendIDs:(NSArray<NSString *> * _Nullable)friendIDs birthday:(NSDate * _Nullable)birthday ageRange:(FBSDKUserAgeRange * _Nullable)ageRange hometown:(FBSDKLocation * _Nullable)hometown location:(FBSDKLocation * _Nullable)location gender:(NSString * _Nullable)gender;
	[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:imageURL:email:friendIDs:birthday:ageRange:hometown:location:gender:")]
	NativeHandle Constructor (string userID, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkURL, [NullAllowed] NSDate refreshDate, [NullAllowed] NSUrl imageURL, [NullAllowed] string email, [NullAllowed] string[] friendIDs, [NullAllowed] NSDate birthday, [NullAllowed] FBSDKUserAgeRange ageRange, [NullAllowed] FBSDKLocation hometown, [NullAllowed] FBSDKLocation location, [NullAllowed] string gender);

	// -(instancetype _Nonnull)initWithUserID:(FBSDKUserIdentifier _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate imageURL:(NSURL * _Nullable)imageURL email:(NSString * _Nullable)email friendIDs:(NSArray<NSString *> * _Nullable)friendIDs birthday:(NSDate * _Nullable)birthday ageRange:(FBSDKUserAgeRange * _Nullable)ageRange hometown:(FBSDKLocation * _Nullable)hometown location:(FBSDKLocation * _Nullable)location gender:(NSString * _Nullable)gender isLimited:(BOOL)isLimited __attribute__((objc_designated_initializer));
	[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:imageURL:email:friendIDs:birthday:ageRange:hometown:location:gender:isLimited:")]
	[DesignatedInitializer]
	NativeHandle Constructor (string userID, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkURL, [NullAllowed] NSDate refreshDate, [NullAllowed] NSUrl imageURL, [NullAllowed] string email, [NullAllowed] string[] friendIDs, [NullAllowed] NSDate birthday, [NullAllowed] FBSDKUserAgeRange ageRange, [NullAllowed] FBSDKLocation hometown, [NullAllowed] FBSDKLocation location, [NullAllowed] string gender, bool isLimited);

	// +(void)enableUpdatesOnAccessTokenChange:(BOOL)enabled __attribute__((deprecated("This method is deprecated and will be removed in the next major release. Use `isUpdatedWithAccessTokenChange` instead.")));
	[Static]
	[Export ("enableUpdatesOnAccessTokenChange:")]
	void EnableUpdatesOnAccessTokenChange (bool enabled);
}
// @protocol FBSDKErrorConfigurationProviding
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKErrorConfigurationProviding
{
	// @required -(id<FBSDKErrorConfiguration> _Nullable)errorConfiguration;
	[Abstract]
	[NullAllowed, Export ("errorConfiguration")]
	IFBSDKErrorConfiguration ErrorConfiguration { get; }
}

interface IFBSDKErrorConfigurationProviding { }

// @protocol FBSDKProfileProviding
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
interface FBSDKProfileProviding
{
	// @required @property (nonatomic, strong, class) FBSDKProfile * _Nullable currentProfile;
	[Static, Abstract]
	[NullAllowed, Export ("currentProfile", ArgumentSemantic.Strong)]
	FBSDKProfile CurrentProfile { get; set; }

	// @required +(FBSDKProfile * _Nullable)fetchCachedProfile __attribute__((warn_unused_result("")));
	[Static, Abstract]
	[NullAllowed, Export ("fetchCachedProfile")]
	FBSDKProfile FetchCachedProfile { get; }
}

// @protocol FBSDKCAPIReporter
// /*
//   Check whether adding [Model] to this declaration is appropriate.
//   [Model] is used to generate a C# class that implements this protocol,
//   and might be useful for protocols that consumers are supposed to implement,
//   since consumers can subclass the generated class instead of implementing
//   the generated interface. If consumers are not supposed to implement this
//   protocol, then [Model] is redundant and will generate code that will never
//   be used.
// */[Protocol]
// interface FBSDKCAPIReporter
// {
// 	// @required -(void)enable;
// 	[Abstract]
// 	[Export ("enable")]
// 	void Enable ();
//
// 	// @required -(void)configureWithFactory:(id<FBSDKGraphRequestFactory> _Nonnull)factory settings:(id<FBSDKSettings> _Nonnull)settings;
// 	[Abstract]
// 	[Export ("configureWithFactory:settings:")]
// 	void ConfigureWithFactory (FBSDKGraphRequestFactory factory, FBSDKSettings settings);
//
// 	// @required -(void)recordEvent:(NSDictionary<NSString *,id> * _Nonnull)parameters;
// 	[Abstract]
// 	[Export ("recordEvent:")]
// 	void RecordEvent (NSDictionary<NSString, NSObject> parameters);
// }

interface IFBSDKCAPIReporter {
}

interface IFBSDKProfileProviding {}

// @protocol FBSDKMACARuleMatching
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
// 	[Protocol]
// interface FBSDKMACARuleMatching
// {
// 	// @required -(void)enable;
// 	[Abstract]
// 	[Export ("enable")]
// 	void Enable ();
//
// 	// @required -(NSDictionary * _Nullable)processParameters:(NSDictionary * _Nullable)params event:(NSString * _Nullable)event __attribute__((warn_unused_result("")));
// 	[Abstract]
// 	[Export ("processParameters:event:")]
// 	[return: NullAllowed]
// 	NSDictionary ProcessParameters ([NullAllowed] NSDictionary @params, [NullAllowed] string @event);
// }
// @protocol FBSDKWebViewProviding
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.*/
	
	//interface IFBSDKWebViewProviding {}
interface IFBSDKMACARuleMatching {}

// @interface FBSDKProfilePictureView : UIView
[BaseType (typeof(UIView))]
interface FBSDKProfilePictureView
{
	// @property (nonatomic) enum FBSDKProfilePictureMode pictureMode;
	[Export ("pictureMode", ArgumentSemantic.Assign)]
	FBSDKProfilePictureMode PictureMode { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull profileID;
	[Export ("profileID")]
	string ProfileID { get; set; }

	// @property (nonatomic) CGRect bounds;
	[Export ("bounds", ArgumentSemantic.Assign)]
	CGRect Bounds { get; set; }

	// @property (nonatomic) UIViewContentMode contentMode;
	[Export ("contentMode", ArgumentSemantic.Assign)]
	UIViewContentMode ContentMode { get; set; }

	// -(instancetype _Nonnull)initWith:(CGRect)frame profile:(FBSDKProfile * _Nullable)profile __attribute__((objc_designated_initializer));
	[Export ("initWith:profile:")]
	[DesignatedInitializer]
	NativeHandle Constructor (CGRect frame, [NullAllowed] FBSDKProfile profile);

	// -(instancetype _Nonnull)initWithProfile:(FBSDKProfile * _Nullable)profile;
	[Export ("initWithProfile:")]
	NativeHandle Constructor ([NullAllowed] FBSDKProfile profile);

	// -(void)setNeedsImageUpdate;
	[Export ("setNeedsImageUpdate")]
	void SetNeedsImageUpdate ();
}

// @interface FBSDKApplicationDelegate : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface FBSDKApplicationDelegate
{
	// @property (readonly, nonatomic, strong, class) FBSDKApplicationDelegate * _Nonnull sharedInstance;
	[Static]
	[Export ("sharedInstance", ArgumentSemantic.Strong)]
	FBSDKApplicationDelegate SharedInstance { get; }

	// -(void)initializeSDK;
	[Export ("initializeSDK")]
	void InitializeSDK ();

	// -(BOOL)application:(UIApplication * _Nonnull)application continueUserActivity:(NSUserActivity * _Nonnull)userActivity;
	[Export ("application:continueUserActivity:")]
	bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity);

	// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
	[Export ("application:openURL:options:")]
	bool OpenURL (UIApplication application, NSUrl url, NSDictionary options);

	// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
	[Export ("application:openURL:sourceApplication:annotation:")]
	bool OpenURL (UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

	// -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
	[Export ("application:didFinishLaunchingWithOptions:")]
	bool FinishedLaunching (UIApplication application, [NullAllowed] NSDictionary launchOptions);

	// -(void)addObserver:(id<FBSDKApplicationObserving> _Nonnull)observer;
	[Export ("addObserver:")]
	void AddObserver (IFBSDKApplicationObserving observer);

	// -(void)removeObserver:(id<FBSDKApplicationObserving> _Nonnull)observer;
	[Export ("removeObserver:")]
	void RemoveObserver (IFBSDKApplicationObserving observer);
}
#endregion
}