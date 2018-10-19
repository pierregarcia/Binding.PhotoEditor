using System;
using AVFoundation;
using CoreAnimation;
using CoreImage;
using Foundation;
using Metal;
using ObjCRuntime;
using OpenGLES;
using UIKit;
using CoreGraphics;

namespace PhotoEditor
{
	partial interface IPESDKAnalyticsClient { }

	// @interface PESDK : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDK
	{
		// +(void)unlockWithLicenseAt:(NSURL * _Nonnull)url;
		[Static]
		[Export("unlockWithLicenseAt:")]
		void UnlockWithLicenseAt(NSUrl url);

		// @property (readonly, nonatomic, strong, class) PESDKAnalytics * _Nonnull analytics;
		[Static]
		[Export("analytics", ArgumentSemantic.Strong)]
		PESDKAnalytics Analytics { get; }

		// @property (nonatomic, strong, class) id<PESDKProgressView> _Nonnull progressView;
		[Static]
		[Export("progressView", ArgumentSemantic.Strong)]
		PESDKProgressView ProgressView { get; set; }

		// @property (copy, nonatomic, class) NSDictionary<NSString *,NSDictionary<NSString *,NSString *> *> * _Nullable localizationDictionary;
		[Static]
		[NullAllowed, Export("localizationDictionary", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSDictionary<NSString, NSString>> LocalizationDictionary { get; set; }

		// @property (copy, nonatomic, class) NSString * _Nullable (^ _Nullable)(NSString * _Nonnull) localizationBlock;
		[Static]
		[NullAllowed, Export("localizationBlock", ArgumentSemantic.Copy)]
		Func<NSString, NSString> LocalizationBlock { get; set; }

		// @property (copy, nonatomic, class) UIImage * _Nullable (^ _Nullable)(NSString * _Nonnull) bundleImageBlock;
		[Static]
		[NullAllowed, Export("bundleImageBlock", ArgumentSemantic.Copy)]
		Func<NSString, UIImage> BundleImageBlock { get; set; }

		// @property (copy, nonatomic, class) PESDKToolbarItem * _Nullable (^ _Nullable)(UIViewController * _Nonnull, PESDKToolbarItem * _Nullable) toolbarItemBlock;
		[Static]
		[NullAllowed, Export("toolbarItemBlock", ArgumentSemantic.Copy)]
		Func<UIViewController, PESDKToolbarItem, PESDKToolbarItem> ToolbarItemBlock { get; set; }

		// +(BOOL)replaceClass:(Class _Nonnull)builtinClass with:(Class _Nonnull)replacingClass error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export("replaceClass:with:error:")]
		bool ReplaceClass(Class builtinClass, Class replacingClass, [NullAllowed] out NSError error);
	}

	// @protocol PESDKAnalyticsClient
	[Protocol, Model]
	interface PESDKAnalyticsClient
	{
		// @required -(void)logScreenView:(PESDKAnalyticsScreenViewName _Nonnull)screenView;
		[Abstract]
		[Export("logScreenView:")]
		void LogScreenView(string screenView);

		// @required -(void)logEvent:(PESDKAnalyticsEventName _Nonnull)event attributes:(NSDictionary<PESDKAnalyticsEventAttributeName,id> * _Nullable)attributes;
		[Abstract]
		[Export("logEvent:attributes:")]
		void LogEvent(string @event, [NullAllowed] NSDictionary<NSString, NSObject> attributes);
	}

	// @interface PESDKAnalytics : NSObject <PESDKAnalyticsClient>
	[BaseType(typeof(NSObject))]
	interface PESDKAnalytics : IPESDKAnalyticsClient
	{
		// @property (nonatomic) BOOL isEnabled;
		[Export("isEnabled")]
		bool IsEnabled { get; set; }

		// -(void)addAnalyticsClient:(id<PESDKAnalyticsClient> _Nonnull)client;
		[Export("addAnalyticsClient:")]
		void AddAnalyticsClient(PESDKAnalyticsClient client);

		// -(void)removeAnalyticsClient:(id<PESDKAnalyticsClient> _Nonnull)client;
		[Export("removeAnalyticsClient:")]
		void RemoveAnalyticsClient(PESDKAnalyticsClient client);

		// -(void)logScreenView:(PESDKAnalyticsScreenViewName _Nonnull)screenView;
		[Export("logScreenView:")]
		void LogScreenView(string screenView);

		// -(void)logEvent:(PESDKAnalyticsEventName _Nonnull)event attributes:(NSDictionary<PESDKAnalyticsEventAttributeName,id> * _Nullable)attributes;
		[Export("logEvent:attributes:")]
		void LogEvent(string @event, [NullAllowed] NSDictionary<NSString, NSObject> attributes);
	}

	// @protocol PESDKProgressView
	[Protocol, Model]
	interface PESDKProgressView
	{
		// @required -(void)showWithMessage:(NSString * _Nonnull)message;
		[Abstract]
		[Export("showWithMessage:")]
		void ShowWithMessage(string message);

		// @required -(void)hide;
		[Abstract]
		[Export("hide")]
		void Hide();
	}

	// @interface PESDKToolbarItem : NSObject
	[BaseType(typeof(NSObject))]
	interface PESDKToolbarItem
	{
		// @property (nonatomic, strong) UIView * _Nullable titleView;
		[NullAllowed, Export("titleView", ArgumentSemantic.Strong)]
		UIView TitleView { get; set; }

		// @property (nonatomic, strong) PESDKToolbarButton * _Nullable leftButton __attribute__((deprecated("Use `leadingButton` instead.")));
		[NullAllowed, Export("leftButton", ArgumentSemantic.Strong)]
		PESDKToolbarButton LeftButton { get; set; }

		// @property (nonatomic, strong) PESDKToolbarButton * _Nullable rightButton __attribute__((deprecated("Use `trailingButton` instead.")));
		[NullAllowed, Export("rightButton", ArgumentSemantic.Strong)]
		PESDKToolbarButton RightButton { get; set; }

		// @property (nonatomic, strong) PESDKToolbarButton * _Nullable leadingButton;
		[NullAllowed, Export("leadingButton", ArgumentSemantic.Strong)]
		PESDKToolbarButton LeadingButton { get; set; }

		// @property (nonatomic, strong) PESDKToolbarButton * _Nullable trailingButton;
		[NullAllowed, Export("trailingButton", ArgumentSemantic.Strong)]
		PESDKToolbarButton TrailingButton { get; set; }
	}

	// @interface PESDKToolbarButton : PESDKButton
	[BaseType(typeof(PESDKButton))]
	interface PESDKToolbarButton
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();

		// @property (getter = isEnabled, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }

		// -(void)setEnabled:(BOOL)enabled animated:(BOOL)animated;
		[Export("setEnabled:animated:")]
		void SetEnabled(bool enabled, bool animated);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();
	}

	// @protocol PESDKPhotoEditViewControllerDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKPhotoEditViewControllerDelegate
	{
		// @required -(void)photoEditViewController:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController didSaveImage:(UIImage * _Nonnull)image imageAsData:(NSData * _Nonnull)data;
		[Abstract]
		[Export("photoEditViewController:didSaveImage:imageAsData:")]
		void PhotoEditViewController(PESDKPhotoEditViewController photoEditViewController, UIImage image, NSData data);

		// @required -(void)photoEditViewControllerDidFailToGeneratePhoto:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController;
		[Abstract]
		[Export("photoEditViewControllerDidFailToGeneratePhoto:")]
		void PhotoEditViewControllerDidFailToGeneratePhoto(PESDKPhotoEditViewController photoEditViewController);

		// @required -(void)photoEditViewControllerDidCancel:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController;
		[Abstract]
		[Export("photoEditViewControllerDidCancel:")]
		void PhotoEditViewControllerDidCancel(PESDKPhotoEditViewController photoEditViewController);

		// @optional -(void)photoEditViewController:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController willPresentToolController:(PESDKPhotoEditToolController * _Nonnull)toolController;
		[Export("photoEditViewController:willPresentToolController:")]
		void PhotoEditViewControllerWillPresentToolController(PESDKPhotoEditViewController photoEditViewController, PESDKPhotoEditToolController toolController);

		// @optional -(void)photoEditViewController:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController didPresentToolController:(PESDKPhotoEditToolController * _Nonnull)toolController;
		[Export("photoEditViewController:didPresentToolController:")]
		void PhotoEditViewControllerDidPresentToolController(PESDKPhotoEditViewController photoEditViewController, PESDKPhotoEditToolController toolController);

		// @optional -(void)photoEditViewController:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController willDismissToolController:(PESDKPhotoEditToolController * _Nonnull)toolController;
		[Export("photoEditViewController:willDismissToolController:")]
		void PhotoEditViewControllerWillDismissToolController(PESDKPhotoEditViewController photoEditViewController, PESDKPhotoEditToolController toolController);

		// @optional -(void)photoEditViewController:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController didDismissToolController:(PESDKPhotoEditToolController * _Nonnull)toolController;
		[Export("photoEditViewController:didDismissToolController:")]
		void PhotoEditViewControllerDidDismissToolController(PESDKPhotoEditViewController photoEditViewController, PESDKPhotoEditToolController toolController);
	}

	// @interface PESDKPhotoEditToolController : PESDKViewController
	[iOS(9, 0)]
	[BaseType(typeof(PESDKViewController))]
	interface PESDKPhotoEditToolController
	{
		// -(instancetype _Nullable)initWithConfiguration:(PESDKConfiguration * _Nonnull)configuration __attribute__((objc_designated_initializer));
		[Export("initWithConfiguration:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKConfiguration configuration);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)viewDidLoad;
		[Export("viewDidLoad")]
		void ViewDidLoad();

		// -(void)viewDidAppear:(BOOL)animated;
		[Export("viewDidAppear:")]
		void ViewDidAppear(bool animated);

		// -(void)viewWillDisappear:(BOOL)animated;
		[Export("viewWillDisappear:")]
		void ViewWillDisappear(bool animated);

		// @property (readonly, nonatomic) UIStatusBarStyle preferredStatusBarStyle;
		[Export("preferredStatusBarStyle")]
		UIStatusBarStyle PreferredStatusBarStyle { get; }

		// @property (readonly, nonatomic) BOOL prefersStatusBarHidden;
		[Export("prefersStatusBarHidden")]
		bool PrefersStatusBarHidden { get; }

		// @property (nonatomic, strong) PESDKToolbarItem * _Nonnull toolbarItem;
		[Export("toolbarItem", ArgumentSemantic.Strong)]
		PESDKToolbarItem ToolbarItem { get; set; }

		// -(void)configureToolbarItem;
		[Export("configureToolbarItem")]
		void ConfigureToolbarItem();

		// -(void)apply:(PESDKToolbarItem * _Nonnull)sender;
		[Export("apply:")]
		void Apply(PESDKToolbarItem sender);

		// -(void)discard:(PESDKToolbarItem * _Nonnull)sender;
		[Export("discard:")]
		void Discard(PESDKToolbarItem sender);

		// @property (readonly, nonatomic, strong) PESDKConfiguration * _Nonnull configuration;
		[Export("configuration", ArgumentSemantic.Strong)]
		PESDKConfiguration Configuration { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		PESDKPhotoEditToolControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PESDKPhotoEditToolControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) PESDKUndoController * _Nullable undoController;
		[NullAllowed, Export("undoController", ArgumentSemantic.Strong)]
		PESDKUndoController UndoController { get; set; }

		// @property (nonatomic, strong) PESDKAssetManager * _Nullable assetManager;
		[NullAllowed, Export("assetManager", ArgumentSemantic.Strong)]
		PESDKAssetManager AssetManager { get; set; }

		// -(void)updateUserInterfaceState;
		[Export("updateUserInterfaceState")]
		void UpdateUserInterfaceState();

		// -(void)pesdk_willBecomeActiveTool;
		[Export("pesdk_willBecomeActiveTool")]
		void Pesdk_willBecomeActiveTool();

		// -(void)pesdk_didBecomeActiveTool;
		[Export("pesdk_didBecomeActiveTool")]
		void Pesdk_didBecomeActiveTool();

		// -(void)pesdk_willResignActiveTool;
		[Export("pesdk_willResignActiveTool")]
		void Pesdk_willResignActiveTool();

		// -(void)pesdk_didResignActiveTool;
		[Export("pesdk_didResignActiveTool")]
		void Pesdk_didResignActiveTool();

		// -(void)setupForZoomAndPan;
		[Export("setupForZoomAndPan")]
		void SetupForZoomAndPan();

		// -(void)resetForZoomAndPan;
		[Export("resetForZoomAndPan")]
		void ResetForZoomAndPan();

		// @property (readonly, nonatomic) BOOL isModelChangeLocal;
		[Export("isModelChangeLocal")]
		bool IsModelChangeLocal { get; }

		// @property (readonly, nonatomic) BOOL wantsDefaultPreviewView;
		[Export("wantsDefaultPreviewView")]
		bool WantsDefaultPreviewView { get; }

		// @property (readonly, nonatomic) PESDKRenderMode preferredRenderMode;
		[Export("preferredRenderMode")]
		PESDKRenderMode PreferredRenderMode { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nullable preferredPreviewBackgroundColor;
		[NullAllowed, Export("preferredPreviewBackgroundColor", ArgumentSemantic.Strong)]
		UIColor PreferredPreviewBackgroundColor { get; }

		// @property (readonly, nonatomic) UIEdgeInsets preferredPreviewViewInsets;
		[Export("preferredPreviewViewInsets")]
		UIEdgeInsets PreferredPreviewViewInsets { get; }

		// @property (readonly, nonatomic) CGFloat preferredDefaultPreviewViewScale;
		[Export("preferredDefaultPreviewViewScale")]
		nfloat PreferredDefaultPreviewViewScale { get; }
	}

	// @interface PESDKAssetManager : NSObject
	[BaseType(typeof(NSObject))]
	interface PESDKAssetManager
	{
		// -(void)setImage:(UIImage * _Nullable)image forIdentifier:(NSString * _Nonnull)identifier;
		[Export("setImage:forIdentifier:")]
		void SetImage([NullAllowed] UIImage image, string identifier);

		// -(UIImage * _Nullable)imageForIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Export("imageForIdentifier:")]
		[return: NullAllowed]
		UIImage ImageForIdentifier(string identifier);

		// -(void)setCIImage:(CIImage * _Nullable)image forIdentifier:(NSString * _Nonnull)identifier;
		[Export("setCIImage:forIdentifier:")]
		void SetCIImage([NullAllowed] CIImage image, string identifier);

		// -(CIImage * _Nullable)ciImageForIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Export("ciImageForIdentifier:")]
		[return: NullAllowed]
		CIImage CiImageForIdentifier(string identifier);

		// @property (copy, nonatomic) void (^ _Nullable)(BOOL) progressClosure;
		[NullAllowed, Export("progressClosure", ArgumentSemantic.Copy)]
		Action<bool> ProgressClosure { get; set; }

		// -(void)getImagesAt:(NSArray<NSURL *> * _Nonnull)urls completion:(void (^ _Nonnull)(NSDictionary<NSURL *,UIImage *> * _Nonnull, NSArray<NSError *> * _Nonnull))completion;
		[Export("getImagesAt:completion:")]
		void GetImagesAt(NSUrl[] urls, Action<NSDictionary<NSUrl, UIImage>, NSArray<NSError>> completion);

		// -(void)getImageAt:(NSURL * _Nonnull)url completion:(void (^ _Nonnull)(UIImage * _Nullable, NSError * _Nullable))completion;
		[Export("getImageAt:completion:")]
		void GetImageAt(NSUrl url, Action<UIImage, NSError> completion);
	}

	// @interface PESDKUndoController : NSObject
	[BaseType(typeof(NSObject))]
	interface PESDKUndoController
	{
		// @property (nonatomic) BOOL isEnabled;
		[Export("isEnabled")]
		bool IsEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isUndoing;
		[Export("isUndoing")]
		bool IsUndoing { get; }

		// @property (readonly, nonatomic) BOOL isRedoing;
		[Export("isRedoing")]
		bool IsRedoing { get; }

		// -(void)beginUndoGrouping;
		[Export("beginUndoGrouping")]
		void BeginUndoGrouping();

		// -(void)endUndoGrouping;
		[Export("endUndoGrouping")]
		void EndUndoGrouping();

		// -(void)removeAllActions;
		[Export("removeAllActions")]
		void RemoveAllActions();

		// -(void)removeAllActionsInCurrentGroup;
		[Export("removeAllActionsInCurrentGroup")]
		void RemoveAllActionsInCurrentGroup();

		// @property (readonly, nonatomic) BOOL canUndo;
		[Export("canUndo")]
		bool CanUndo { get; }

		// @property (readonly, nonatomic) BOOL canUndoInCurrentGroup;
		[Export("canUndoInCurrentGroup")]
		bool CanUndoInCurrentGroup { get; }

		// -(void)undo;
		[Export("undo")]
		void Undo();

		// -(void)undoStep;
		[Export("undoStep")]
		void UndoStep();

		// -(void)undoStepInCurrentGroup;
		[Export("undoStepInCurrentGroup")]
		void UndoStepInCurrentGroup();

		// -(void)undoAllInCurrentGroup;
		[Export("undoAllInCurrentGroup")]
		void UndoAllInCurrentGroup();

		// -(void)undoGroup;
		[Export("undoGroup")]
		void UndoGroup();

		// @property (readonly, nonatomic) BOOL canRedo;
		[Export("canRedo")]
		bool CanRedo { get; }

		// @property (readonly, nonatomic) BOOL canRedoInCurrentGroup;
		[Export("canRedoInCurrentGroup")]
		bool CanRedoInCurrentGroup { get; }

		// -(void)redo;
		[Export("redo")]
		void Redo();
	}

	// @protocol PESDKPhotoEditToolControllerDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKPhotoEditToolControllerDelegate
	{
		// @required -(PESDKPhotoEditPreviewController * _Nullable)photoEditToolControllerPreviewController:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditToolControllerPreviewController:")]
		[return: NullAllowed]
		PESDKPhotoEditPreviewController PhotoEditToolControllerPreviewController(PESDKPhotoEditToolController photoEditToolController);

		// @required -(UIImage * _Nullable)photoEditToolControllerBaseImage:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditToolControllerBaseImage:")]
		[return: NullAllowed]
		UIImage PhotoEditToolControllerBaseImage(PESDKPhotoEditToolController photoEditToolController);

		// @required -(CIImage * _Nullable)photoEditToolControllerBaseCIImage:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditToolControllerBaseCIImage:")]
		[return: NullAllowed]
		CIImage PhotoEditToolControllerBaseCIImage(PESDKPhotoEditToolController photoEditToolController);

		// @required -(UIView * _Nullable)photoEditToolControllerPreviewView:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditToolControllerPreviewView:")]
		[return: NullAllowed]
		UIView PhotoEditToolControllerPreviewView(PESDKPhotoEditToolController photoEditToolController);

		// @required -(UIScrollView * _Nullable)photoEditToolControllerPreviewScrollView:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditToolControllerPreviewScrollView:")]
		[return: NullAllowed]
		UIScrollView PhotoEditToolControllerPreviewScrollView(PESDKPhotoEditToolController photoEditToolController);

		// @required -(PESDKSpriteViewController * _Nullable)photoEditToolControllerSpriteViewController:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditToolControllerSpriteViewController:")]
		[return: NullAllowed]
		PESDKSpriteViewController PhotoEditToolControllerSpriteViewController(PESDKPhotoEditToolController photoEditToolController);

		// @required -(void)photoEditToolController:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController didChangePreferredPreviewViewInsetsAnimated:(BOOL)animated;
		[Abstract]
		[Export("photoEditToolController:didChangePreferredPreviewViewInsetsAnimated:")]
		void PhotoEditToolController(PESDKPhotoEditToolController photoEditToolController, bool animated);

		// @required -(void)photoEditToolControllerDidChangeWantsDefaultPreviewView:(PESDKPhotoEditToolController * _Nonnull)photoEditToolController;
		[Abstract]
		[Export("photoEditToolControllerDidChangeWantsDefaultPreviewView:")]
		void PhotoEditToolControllerDidChangeWantsDefaultPreviewView(PESDKPhotoEditToolController photoEditToolController);
	}

	// @interface PESDKSpriteViewController : PESDKViewController
	[iOS(9, 0)]
	[BaseType(typeof(PESDKViewController))]
	interface PESDKSpriteViewController
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		PESDKSpriteViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PESDKSpriteViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) PESDKSpriteContainerView * _Nonnull spriteContainerView;
		[Export("spriteContainerView", ArgumentSemantic.Strong)]
		PESDKSpriteContainerView SpriteContainerView { get; }

		// @property (nonatomic, strong) PESDKAssetManager * _Nullable assetManager;
		[NullAllowed, Export("assetManager", ArgumentSemantic.Strong)]
		PESDKAssetManager AssetManager { get; set; }

		// @property (nonatomic) CGSize referenceSize;
		[Export("referenceSize", ArgumentSemantic.Assign)]
		CGSize ReferenceSize { get; set; }

		// @property (nonatomic) CGSize currentSize;
		[Export("currentSize", ArgumentSemantic.Assign)]
		CGSize CurrentSize { get; set; }

		// -(void)loadView;
		[Export("loadView")]
		void LoadView();

		// -(void)viewDidLoad;
		[Export("viewDidLoad")]
		void ViewDidLoad();

		// -(void)tapped:(UITapGestureRecognizer * _Nonnull)gestureRecognizer;
		[Export("tapped:")]
		void Tapped(UITapGestureRecognizer gestureRecognizer);

		// -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((availability(ios, introduced=9.0))) __attribute__((objc_designated_initializer));
		[iOS(9, 0)]
		[Export("initWithNibName:bundle:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((availability(ios, introduced=9.0))) __attribute__((objc_designated_initializer));
		[iOS(9, 0)]
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface PESDKSpriteContainerView : UIView
	[iOS(9, 0)]
	[BaseType(typeof(UIView))]
	interface PESDKSpriteContainerView
	{
		// @property (nonatomic) CGSize referenceSize;
		[Export("referenceSize", ArgumentSemantic.Assign)]
		CGSize ReferenceSize { get; set; }

		// @property (nonatomic) CGSize currentSize;
		[Export("currentSize", ArgumentSemantic.Assign)]
		CGSize CurrentSize { get; set; }

		// @property (readonly, nonatomic) CGFloat imageToViewScaleFactor;
		[Export("imageToViewScaleFactor")]
		nfloat ImageToViewScaleFactor { get; }

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((availability(ios, introduced=9.0))) __attribute__((objc_designated_initializer));
		[iOS(9, 0)]
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((availability(ios, introduced=9.0))) __attribute__((objc_designated_initializer));
		[iOS(9, 0)]
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @protocol PESDKSpriteViewControllerDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKSpriteViewControllerDelegate
	{
		// @required -(void)spriteViewControllerDidChangePhotoEditModel:(PESDKSpriteViewController * _Nonnull)spriteViewController;
		[Abstract]
		[Export("spriteViewControllerDidChangePhotoEditModel:")]
		void SpriteViewControllerDidChangePhotoEditModel(PESDKSpriteViewController spriteViewController);

		// @required -(PESDKUndoController * _Nullable)spriteViewControllerUndoController:(PESDKSpriteViewController * _Nonnull)spriteViewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("spriteViewControllerUndoController:")]
		[return: NullAllowed]
		PESDKUndoController SpriteViewControllerUndoController(PESDKSpriteViewController spriteViewController);
	}

	// @interface PESDKPhotoEditPreviewController : PESDKViewController
	[iOS(9, 0)]
	[BaseType(typeof(PESDKViewController))]
	interface PESDKPhotoEditPreviewController
	{
		// @property (readonly, nonatomic, strong) UIScrollView * _Nonnull previewViewScrollingContainer;
		[Export("previewViewScrollingContainer", ArgumentSemantic.Strong)]
		UIScrollView PreviewViewScrollingContainer { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull previewView;
		[Export("previewView", ArgumentSemantic.Strong)]
		UIView PreviewView { get; }

		// @property (nonatomic) BOOL allowsPreviewImageZoom;
		[Export("allowsPreviewImageZoom")]
		bool AllowsPreviewImageZoom { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		PESDKPhotoEditPreviewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PESDKPhotoEditPreviewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) UIImage * _Nullable baseWorkUIImage;
		[NullAllowed, Export("baseWorkUIImage", ArgumentSemantic.Strong)]
		UIImage BaseWorkUIImage { get; }

		// @property (readonly, nonatomic, strong) CIImage * _Nullable baseWorkCIImage;
		[NullAllowed, Export("baseWorkCIImage", ArgumentSemantic.Strong)]
		CIImage BaseWorkCIImage { get; }

		// @property (readonly, nonatomic, strong) PESDKPhotoEditRenderer * _Nonnull renderer;
		[Export("renderer", ArgumentSemantic.Strong)]
		PESDKPhotoEditRenderer Renderer { get; }

		// @property (readonly, nonatomic, strong) PESDKSpriteViewController * _Nonnull spriteViewController;
		[Export("spriteViewController", ArgumentSemantic.Strong)]
		PESDKSpriteViewController SpriteViewController { get; }

		// @property (nonatomic, strong) PESDKAssetManager * _Nullable assetManager;
		[NullAllowed, Export("assetManager", ArgumentSemantic.Strong)]
		PESDKAssetManager AssetManager { get; set; }

		// @property (nonatomic, strong) PESDKUndoController * _Nullable undoController;
		[NullAllowed, Export("undoController", ArgumentSemantic.Strong)]
		PESDKUndoController UndoController { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(BOOL) loadingProgressClosure;
		[NullAllowed, Export("loadingProgressClosure", ArgumentSemantic.Copy)]
		Action<bool> LoadingProgressClosure { get; set; }

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)viewDidLoad;
		[Export("viewDidLoad")]
		void ViewDidLoad();

		// -(void)viewWillAppear:(BOOL)animated;
		[Export("viewWillAppear:")]
		void ViewWillAppear(bool animated);

		// -(void)viewDidAppear:(BOOL)animated;
		[Export("viewDidAppear:")]
		void ViewDidAppear(bool animated);

		// -(void)viewDidLayoutSubviews;
		[Export("viewDidLayoutSubviews")]
		void ViewDidLayoutSubviews();

		// @property (readonly, nonatomic) UIStatusBarStyle preferredStatusBarStyle;
		[Export("preferredStatusBarStyle")]
		UIStatusBarStyle PreferredStatusBarStyle { get; }

		// @property (readonly, nonatomic) BOOL prefersStatusBarHidden;
		[Export("prefersStatusBarHidden")]
		bool PrefersStatusBarHidden { get; }

		// -(void)updateViewConstraints;
		[Export("updateViewConstraints")]
		void UpdateViewConstraints();

		// -(void)updateLayout;
		[Export("updateLayout")]
		void UpdateLayout();

		// -(void)updateInsetsWithAnimated:(BOOL)animated;
		[Export("updateInsetsWithAnimated:")]
		void UpdateInsetsWithAnimated(bool animated);

		// -(void)updatePreview;
		[Export("updatePreview")]
		void UpdatePreview();
	}

	// @interface PESDKPhotoEditRenderer : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKPhotoEditRenderer
	{
		// @property (nonatomic, strong) CIImage * _Nullable originalImage;
		[NullAllowed, Export("originalImage", ArgumentSemantic.Strong)]
		CIImage OriginalImage { get; set; }

		// @property (nonatomic) PESDKRenderMode renderMode;
		[Export("renderMode", ArgumentSemantic.Assign)]
		PESDKRenderMode RenderMode { get; set; }

		// @property (nonatomic, strong) PESDKAssetManager * _Nullable assetManager;
		[NullAllowed, Export("assetManager", ArgumentSemantic.Strong)]
		PESDKAssetManager AssetManager { get; set; }

		// @property (readonly, nonatomic, strong) CIImage * _Nonnull outputImage;
		[Export("outputImage", ArgumentSemantic.Strong)]
		CIImage OutputImage { get; }

		// @property (readonly, nonatomic) CGSize outputImageSize;
		[Export("outputImageSize")]
		CGSize OutputImageSize { get; }

		// -(void)invalidateCache;
		[Export("invalidateCache")]
		void InvalidateCache();

		// -(CGImageRef _Nonnull)newOutputImage __attribute__((warn_unused_result));
		[Export("newOutputImage")]
		//[Verify(MethodToProperty)]
		unsafe CGImage NewOutputImage { get; }

		// -(void)createOutputImageWithCompletion:(void (^ _Nonnull)(CGImageRef _Nonnull))completion;
		[Export("createOutputImageWithCompletion:")]
		unsafe void CreateOutputImageWithCompletion(Action<CoreGraphics.CGImage> completion);

		// -(void)generateOutputImageDataWithCompressionQuality:(CGFloat)compressionQuality metadataSourceImageURL:(NSURL * _Nullable)metadataSourceImageURL completionHandler:(void (^ _Nonnull)(NSData * _Nullable, CGFloat, CGFloat))completionHandler __attribute__((deprecated("Use `generateOutputImageData(withCompressionQuality:metadataSourcePhoto:completionHandler:)` instead.")));
		[Export("generateOutputImageDataWithCompressionQuality:metadataSourceImageURL:completionHandler:")]
		void GenerateOutputImageDataWithCompressionQuality(nfloat compressionQuality, [NullAllowed] NSUrl metadataSourceImageURL, Action<NSData, nfloat, nfloat> completionHandler);

		// -(void)generateOutputImageDataWithCompressionQuality:(CGFloat)compressionQuality metadataSourcePhoto:(PESDKPhoto * _Nullable)metadataSourcePhoto completionHandler:(void (^ _Nonnull)(NSData * _Nullable, CGFloat, CGFloat))completionHandler __attribute__((deprecated("Use `generateOutputImageData(withFormat:compressionQuality:metadataSourcePhoto:completionHandler:)` instead.")));
		[Export("generateOutputImageDataWithCompressionQuality:metadataSourcePhoto:completionHandler:")]
		void GenerateOutputImageDataWithCompressionQuality(nfloat compressionQuality, [NullAllowed] PESDKPhoto metadataSourcePhoto, Action<NSData, nfloat, nfloat> completionHandler);

		// -(void)generateOutputImageDataWithFormat:(enum PESDKImageFileFormat)imageFormat compressionQuality:(CGFloat)compressionQuality metadataSourcePhoto:(PESDKPhoto * _Nullable)metadataSourcePhoto completionHandler:(void (^ _Nonnull)(NSData * _Nullable, CGFloat, CGFloat))completionHandler;
		[Export("generateOutputImageDataWithFormat:compressionQuality:metadataSourcePhoto:completionHandler:")]
		void GenerateOutputImageDataWithFormat(PESDKImageFileFormat imageFormat, nfloat compressionQuality, [NullAllowed] PESDKPhoto metadataSourcePhoto, Action<NSData, nfloat, nfloat> completionHandler);

		// -(void)drawOutputImageInContext:(EAGLContext * _Nonnull)context toRect:(CGRect)rect viewportWidth:(NSInteger)viewportWidth viewportHeight:(NSInteger)viewportHeight;
		[Export("drawOutputImageInContext:toRect:viewportWidth:viewportHeight:")]
		void DrawOutputImageInContext(EAGLContext context, CGRect rect, nint viewportWidth, nint viewportHeight);

		// -(void)drawOutputImageFor:(id<MTLDevice> _Nonnull)device in:(id<CAMetalDrawable> _Nonnull)drawable to:(CGRect)rect commandQueue:(id<MTLCommandQueue> _Nonnull)commandQueue;
		[Export("drawOutputImageFor:in:to:commandQueue:")]
		void DrawOutputImageFor(MTLDevice device, ICAMetalDrawable drawable, CGRect rect, IMTLCommandQueue commandQueue);
	}

	// @protocol PESDKPhotoEditPreviewControllerDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKPhotoEditPreviewControllerDelegate
	{
		// @required -(BOOL)photoEditPreviewControllerPreviewEnabled:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditPreviewControllerPreviewEnabled:")]
		bool PhotoEditPreviewControllerPreviewEnabled(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(PESDKRenderMode)photoEditPreviewControllerRenderMode:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditPreviewControllerRenderMode:")]
		PESDKRenderMode PhotoEditPreviewControllerRenderMode(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(UIColor * _Nonnull)photoEditPreviewControllerBackgroundColor:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditPreviewControllerBackgroundColor:")]
		UIColor PhotoEditPreviewControllerBackgroundColor(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(UIEdgeInsets)photoEditPreviewControllerPreviewInsets:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditPreviewControllerPreviewInsets:")]
		UIEdgeInsets PhotoEditPreviewControllerPreviewInsets(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(CGFloat)photoEditPreviewControllerPreviewScale:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditPreviewControllerPreviewScale:")]
		nfloat PhotoEditPreviewControllerPreviewScale(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(BOOL)photoEditPreviewControllerProxyZoomingActive:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController __attribute__((warn_unused_result));
		[Abstract]
		[Export("photoEditPreviewControllerProxyZoomingActive:")]
		bool PhotoEditPreviewControllerProxyZoomingActive(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(void)photoEditPreviewControllerResetProxyZooming:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController;
		[Abstract]
		[Export("photoEditPreviewControllerResetProxyZooming:")]
		void PhotoEditPreviewControllerResetProxyZooming(PESDKPhotoEditPreviewController photoEditPreviewController);

		// @required -(void)photoEditPreviewControllerDidChangePhotoEditModel:(PESDKPhotoEditPreviewController * _Nonnull)photoEditPreviewController;
		[Abstract]
		[Export("photoEditPreviewControllerDidChangePhotoEditModel:")]
		void PhotoEditPreviewControllerDidChangePhotoEditModel(PESDKPhotoEditPreviewController photoEditPreviewController);
	}

	// @interface PESDKViewController : UIViewController
	[BaseType(typeof(UIViewController))]
	interface PESDKViewController
	{
		// -(void)viewDidDisappear:(BOOL)animated;
		[Export("viewDidDisappear:")]
		void ViewDidDisappear(bool animated);

		// -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
		[Export("initWithNibName:bundle:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface PESDKCameraViewControllerOptionsBuilder : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKCameraViewControllerOptionsBuilder
	{
		// @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) cancelButtonConfigurationClosure;
		[NullAllowed, Export("cancelButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> CancelButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) flashButtonConfigurationClosure;
		[NullAllowed, Export("flashButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> FlashButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) switchCameraButtonConfigurationClosure;
		[NullAllowed, Export("switchCameraButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> SwitchCameraButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) cameraRollButtonConfigurationClosure;
		[NullAllowed, Export("cameraRollButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> CameraRollButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) photoActionButtonConfigurationClosure;
		[NullAllowed, Export("photoActionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> PhotoActionButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) filterSelectorButtonConfigurationClosure;
		[NullAllowed, Export("filterSelectorButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> FilterSelectorButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UILabel * _Nonnull) timeLabelConfigurationClosure;
		[NullAllowed, Export("timeLabelConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UILabel> TimeLabelConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) filterIntensitySliderConfigurationClosure;
		[NullAllowed, Export("filterIntensitySliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> FilterIntensitySliderConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull, enum RecordingMode) recordingModeButtonConfigurationClosure;
		[NullAllowed, Export("recordingModeButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton, RecordingMode> RecordingModeButtonConfigurationClosure { get; set; }

		// @property (nonatomic) BOOL cropToSquare;
		[Export("cropToSquare")]
		bool CropToSquare { get; set; }

		// @property (nonatomic) NSInteger maximumVideoLength;
		[Export("maximumVideoLength")]
		int MaximumVideoLength { get; set; }

		// @property (nonatomic) BOOL tapToFocusEnabled;
		[Export("tapToFocusEnabled")]
		bool TapToFocusEnabled { get; set; }

		// @property (nonatomic) BOOL showCancelButton;
		[Export("showCancelButton")]
		bool ShowCancelButton { get; set; }

		// @property (nonatomic) BOOL showCameraRoll;
		[Export("showCameraRoll")]
		bool ShowCameraRoll { get; set; }

		// @property (nonatomic) BOOL showFilters;
		[Export("showFilters")]
		bool ShowFilters { get; set; }

		// @property (nonatomic) BOOL showFilterIntensitySlider;
		[Export("showFilterIntensitySlider")]
		bool ShowFilterIntensitySlider { get; set; }

		// @property (nonatomic) CGFloat initialFilterIntensity;
		[Export("initialFilterIntensity")]
		nfloat InitialFilterIntensity { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable videoOutputSettings;
		[NullAllowed, Export("videoOutputSettings", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> VideoOutputSettings { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable audioOutputSettings;
		[NullAllowed, Export("audioOutputSettings", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AudioOutputSettings { get; set; }

		// @property (nonatomic) AVFileType _Nonnull videoRecordingFileType;
		[Export("videoRecordingFileType")]
		string VideoRecordingFileType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull videoRecordingFileExtension;
		[Export("videoRecordingFileExtension")]
		string VideoRecordingFileExtension { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(AVAssetWriter * _Nonnull) assetWriterConfigurationClosure;
		[NullAllowed, Export("assetWriterConfigurationClosure", ArgumentSemantic.Copy)]
		Action<AVAssetWriter> AssetWriterConfigurationClosure { get; set; }

		// @property (nonatomic) BOOL includeUserLocation;
		[Export("includeUserLocation")]
		bool IncludeUserLocation { get; set; }
	}

	// @interface PESDKButton : UIButton
	[BaseType(typeof(UIButton))]
	interface PESDKButton
	{
		// -(void)setActionClosure:(void (^ _Nullable)(id _Nonnull))actionClosure for:(UIControlEvents)controlEvents;
		[Export("setActionClosure:for:")]
		void SetActionClosure([NullAllowed] Action<NSObject> actionClosure, UIControlEvent controlEvents);

		// @property (copy, nonatomic) void (^ _Nullable)(id _Nonnull) actionClosure;
		[NullAllowed, Export("actionClosure", ArgumentSemantic.Copy)]
		Action<NSObject> ActionClosure { get; set; }

		// @property (nonatomic) UIEdgeInsets touchAreaInsets;
		[Export("touchAreaInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets TouchAreaInsets { get; set; }

		// -(BOOL)pointInside:(CGPoint)point withEvent:(UIEvent * _Nullable)event __attribute__((warn_unused_result));
		[Export("pointInside:withEvent:")]
		bool PointInside(CGPoint point, [NullAllowed] UIEvent @event);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface PESDKSlider : UIControl
	[iOS(9, 0)]
	[BaseType(typeof(UIControl))]
	interface PESDKSlider
	{
		// @property (nonatomic, strong) UIColor * _Nullable thumbTintColor;
		[NullAllowed, Export("thumbTintColor", ArgumentSemantic.Strong)]
		UIColor ThumbTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull thumbBackgroundColor;
		[Export("thumbBackgroundColor", ArgumentSemantic.Strong)]
		UIColor ThumbBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable filledTrackColor;
		[NullAllowed, Export("filledTrackColor", ArgumentSemantic.Strong)]
		UIColor FilledTrackColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull unfilledTrackColor;
		[Export("unfilledTrackColor", ArgumentSemantic.Strong)]
		UIColor UnfilledTrackColor { get; set; }

		// @property (nonatomic) CGFloat minimumValue;
		[Export("minimumValue")]
		nfloat MinimumValue { get; set; }

		// @property (nonatomic) CGFloat maximumValue;
		[Export("maximumValue")]
		nfloat MaximumValue { get; set; }

		// @property (nonatomic) CGFloat neutralValue;
		[Export("neutralValue")]
		nfloat NeutralValue { get; set; }

		// @property (readonly, nonatomic, strong) UIPanGestureRecognizer * _Nonnull panGestureRecognizer;
		[Export("panGestureRecognizer", ArgumentSemantic.Strong)]
		UIPanGestureRecognizer PanGestureRecognizer { get; }

		// @property (nonatomic) CGFloat value;
		[Export("value")]
		nfloat Value { get; set; }

		// @property (nonatomic) CGRect frame;
		[Export("frame", ArgumentSemantic.Assign)]
		CGRect Frame { get; set; }

		// @property (nonatomic) CGRect bounds;
		[Export("bounds", ArgumentSemantic.Assign)]
		CGRect Bounds { get; set; }

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)accessibilityIncrement;
		[Export("accessibilityIncrement")]
		void AccessibilityIncrement();

		// -(void)accessibilityDecrement;
		[Export("accessibilityDecrement")]
		void AccessibilityDecrement();

		// -(void)encodeWithCoder:(NSCoder * _Nonnull)aCoder;
		[Export("encodeWithCoder:")]
		void EncodeWithCoder(NSCoder aCoder);

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();

		// @property (readonly, nonatomic) CGSize intrinsicContentSize;
		[Export("intrinsicContentSize")]
		CGSize IntrinsicContentSize { get; }

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(CGRect)thumbRectFor:(CGRect)bounds value:(CGFloat)value __attribute__((warn_unused_result));
		[Export("thumbRectFor:value:")]
		CGRect ThumbRectFor(CGRect bounds, nfloat value);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; }

		// -(BOOL)pointInside:(CGPoint)point withEvent:(UIEvent * _Nullable)event __attribute__((warn_unused_result));
		[Export("pointInside:withEvent:")]
		bool PointInside(CGPoint point, [NullAllowed] UIEvent @event);

		// -(BOOL)beginTrackingWith:(UIPanGestureRecognizer * _Nonnull)panGestureRecognizer __attribute__((warn_unused_result));
		[Export("beginTrackingWith:")]
		bool BeginTrackingWith(UIPanGestureRecognizer panGestureRecognizer);

		// -(void)continueTrackingWith:(UIPanGestureRecognizer * _Nonnull)panGestureRecognizer;
		[Export("continueTrackingWith:")]
		void ContinueTrackingWith(UIPanGestureRecognizer panGestureRecognizer);

		// -(void)endTrackingWith:(UIPanGestureRecognizer * _Nonnull)panGestureRecognizer;
		[Export("endTrackingWith:")]
		void EndTrackingWith(UIPanGestureRecognizer panGestureRecognizer);
	}

	// @interface PESDKPhotoEditViewController : PESDKViewController
	[iOS(9, 0)]
	[BaseType(typeof(PESDKViewController))]
	interface PESDKPhotoEditViewController
	{
		// @property (readonly, nonatomic, strong) PESDKMainFlowController * _Null_unspecified flowController;
		[Export("flowController", ArgumentSemantic.Strong)]
		PESDKMainFlowController FlowController { get; }

		// @property (readonly, nonatomic, strong) PESDKPhotoEditPreviewController * _Nonnull photoEditPreviewController;
		[Export("photoEditPreviewController", ArgumentSemantic.Strong)]
		PESDKPhotoEditPreviewController PhotoEditPreviewController { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull containerView;
		[Export("containerView", ArgumentSemantic.Strong)]
		UIView ContainerView { get; }

		// @property (readonly, nonatomic, strong) PESDKToolbar * _Nonnull toolbar;
		[Export("toolbar", ArgumentSemantic.Strong)]
		PESDKToolbar Toolbar { get; }

		// @property (nonatomic, strong) PESDKToolbarItem * _Nonnull toolbarItem;
		[Export("toolbarItem", ArgumentSemantic.Strong)]
		PESDKToolbarItem ToolbarItem { get; set; }

		// @property (readonly, nonatomic, strong) PESDKConfiguration * _Nonnull configuration;
		[Export("configuration", ArgumentSemantic.Strong)]
		PESDKConfiguration Configuration { get; }

		// @property (nonatomic, strong) PESDKUndoController * _Nonnull undoController;
		[Export("undoController", ArgumentSemantic.Strong)]
		PESDKUndoController UndoController { get; set; }

		// @property (readonly, nonatomic, strong) PESDKAssetManager * _Nonnull assetManager;
		[Export("assetManager", ArgumentSemantic.Strong)]
		PESDKAssetManager AssetManager { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		PESDKPhotoEditViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PESDKPhotoEditViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) BOOL hasChanges;
		[Export("hasChanges")]
		bool HasChanges { get; }

		// @property (readonly, copy, nonatomic) NSData * _Nullable serializedSettings __attribute__((deprecated("Use `serializedSettings(withImageData:)` instead.")));
		[NullAllowed, Export("serializedSettings", ArgumentSemantic.Copy)]
		NSData SerializedSettings { get; }

		// -(NSData * _Nullable)serializedSettingsWithImageData:(BOOL)includeImageData __attribute__((warn_unused_result));
		[Export("serializedSettingsWithImageData:")]
		[return: NullAllowed]
		NSData SerializedSettingsWithImageData(bool includeImageData);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)viewDidLoad;
		[Export("viewDidLoad")]
		void ViewDidLoad();

		// -(void)viewWillAppear:(BOOL)animated;
		[Export("viewWillAppear:")]
		void ViewWillAppear(bool animated);

		// -(void)viewDidAppear:(BOOL)animated;
		[Export("viewDidAppear:")]
		void ViewDidAppear(bool animated);

		// -(void)viewWillDisappear:(BOOL)animated;
		[Export("viewWillDisappear:")]
		void ViewWillDisappear(bool animated);

		// -(void)viewDidDisappear:(BOOL)animated;
		[Export("viewDidDisappear:")]
		void ViewDidDisappear(bool animated);

		// -(void)updateViewConstraints;
		[Export("updateViewConstraints")]
		void UpdateViewConstraints();

		// -(void)willMoveToParentViewController:(UIViewController * _Nullable)parent;
		[Export("willMoveToParentViewController:")]
		void WillMoveToParentViewController([NullAllowed] UIViewController parent);

		// @property (readonly, nonatomic) BOOL prefersStatusBarHidden;
		[Export("prefersStatusBarHidden")]
		bool PrefersStatusBarHidden { get; }

		// @property (readonly, nonatomic) UIStatusBarStyle preferredStatusBarStyle;
		[Export("preferredStatusBarStyle")]
		UIStatusBarStyle PreferredStatusBarStyle { get; }

		// @property (readonly, nonatomic) BOOL shouldAutomaticallyForwardAppearanceMethods;
		[Export("shouldAutomaticallyForwardAppearanceMethods")]
		bool ShouldAutomaticallyForwardAppearanceMethods { get; }

		// @property (readonly, nonatomic) UIRectEdge preferredScreenEdgesDeferringSystemGestures;
		[Export("preferredScreenEdgesDeferringSystemGestures")]
		UIRectEdge PreferredScreenEdgesDeferringSystemGestures { get; }

		// @property (readonly, nonatomic, strong) PESDKOverlayButton * _Nullable undoButton;
		[NullAllowed, Export("undoButton", ArgumentSemantic.Strong)]
		PESDKOverlayButton UndoButton { get; }

		// @property (readonly, nonatomic, strong) PESDKOverlayButton * _Nullable redoButton;
		[NullAllowed, Export("redoButton", ArgumentSemantic.Strong)]
		PESDKOverlayButton RedoButton { get; }

		// @property (readonly, copy, nonatomic) NSArray<PESDKOverlayButton *> * _Nonnull overlayButtons;
		[Export("overlayButtons", ArgumentSemantic.Copy)]
		PESDKOverlayButton[] OverlayButtons { get; }

		// -(void)presentToolFor:(PESDKToolMenuItem * _Nonnull)toolMenuItem;
		[Export("presentToolFor:")]
		void PresentToolFor(PESDKToolMenuItem toolMenuItem);

		// -(void)renderHighResolutionImage;
		[Export("renderHighResolutionImage")]
		void RenderHighResolutionImage();

		// @property (readonly, copy, nonatomic) NSArray<PESDKPhotoEditToolController *> * _Nonnull viewControllers;
		[Export("viewControllers", ArgumentSemantic.Copy)]
		PESDKPhotoEditToolController[] ViewControllers { get; }

		// -(void)pushViewController:(PESDKPhotoEditToolController * _Nonnull)viewController animated:(BOOL)animated completion:(void (^ _Nullable)(void))completion;
		[Export("pushViewController:animated:completion:")]
		void PushViewController(PESDKPhotoEditToolController viewController, bool animated, [NullAllowed] Action completion);

		// -(PESDKPhotoEditToolController * _Nullable)popViewControllerAnimated:(BOOL)animated completion:(void (^ _Nullable)(void))completion;
		[Export("popViewControllerAnimated:completion:")]
		[return: NullAllowed]
		PESDKPhotoEditToolController PopViewControllerAnimated(bool animated, [NullAllowed] Action completion);
	}

	// @interface PESDKOverlayButton : PESDKButton
	[iOS(9, 0)]
	[BaseType(typeof(PESDKButton))]
	interface PESDKOverlayButton
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// @property (readonly, nonatomic) CGSize intrinsicContentSize;
		[Export("intrinsicContentSize")]
		CGSize IntrinsicContentSize { get; }

		// +(PESDKOverlayButton * _Nonnull)makeAddButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeAddButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeAddButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeDeleteButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeDeleteButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeDeleteButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeFlipButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeFlipButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeFlipButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeStraightenButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeStraightenButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeStraightenButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeToFrontButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeToFrontButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeToFrontButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeUndoButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeUndoButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeUndoButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeRedoButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeRedoButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeRedoButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeAlignmentButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeAlignmentButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeAlignmentButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeInvertButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeInvertButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeInvertButton { get; }

		// +(PESDKOverlayButton * _Nonnull)makeDisableInvertButton __attribute__((warn_unused_result));
		[Static]
		[Export("makeDisableInvertButton")]
		//[Verify(MethodToProperty)]
		PESDKOverlayButton MakeDisableInvertButton { get; }
	}

	// @interface PESDKToolbar : UIView
	[iOS(9, 0)]
	[BaseType(typeof(UIView))]
	interface PESDKToolbar
	{
		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// @property (readonly, nonatomic, strong) UIView * _Nonnull contentView;
		[Export("contentView", ArgumentSemantic.Strong)]
		UIView ContentView { get; }

		// @property (copy, nonatomic) NSArray<PESDKToolbarItem *> * _Nonnull items;
		[Export("items", ArgumentSemantic.Copy)]
		PESDKToolbarItem[] Items { get; set; }

		// -(void)setItems:(NSArray<PESDKToolbarItem *> * _Nullable)items animated:(BOOL)animated;
		[Export("setItems:animated:")]
		void SetItems([NullAllowed] PESDKToolbarItem[] items, bool animated);

		// -(void)pushToolbarItem:(PESDKToolbarItem * _Nonnull)item animated:(BOOL)animated;
		[Export("pushToolbarItem:animated:")]
		void PushToolbarItem(PESDKToolbarItem item, bool animated);

		// -(PESDKToolbarItem * _Nullable)popToolbarItemAnimated:(BOOL)animated;
		[Export("popToolbarItemAnimated:")]
		[return: NullAllowed]
		PESDKToolbarItem PopToolbarItemAnimated(bool animated);
	}

	// @interface PESDKMainFlowController : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKMainFlowController
	{
		// @property (readonly, nonatomic, strong) PESDKConfiguration * _Nonnull configuration;
		[Export("configuration", ArgumentSemantic.Strong)]
		PESDKConfiguration Configuration { get; }

		// @property (readonly, nonatomic, weak) PESDKPhotoEditViewController * _Nullable photoEditViewController;
		[NullAllowed, Export("photoEditViewController", ArgumentSemantic.Weak)]
		PESDKPhotoEditViewController PhotoEditViewController { get; }

		// -(instancetype _Nonnull)initWithPhotoEditViewController:(PESDKPhotoEditViewController * _Nonnull)photoEditViewController configuration:(PESDKConfiguration * _Nonnull)configuration;
		[Export("initWithPhotoEditViewController:configuration:")]
		IntPtr Constructor(PESDKPhotoEditViewController photoEditViewController, PESDKConfiguration configuration);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKMainFlowController New();
	}

	// @interface PESDKSticker : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKSticker
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nonnull imageURL;
		[Export("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageURL { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable thumbnailURL;
		[NullAllowed, Export("thumbnailURL", ArgumentSemantic.Copy)]
		NSUrl ThumbnailURL { get; }

		// @property (readonly, nonatomic) enum PESDKStickerTintMode tintMode;
		[Export("tintMode")]
		PESDKStickerTintMode TintMode { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (nonatomic) BOOL allowBrightnessAdjustment;
		[Export("allowBrightnessAdjustment")]
		bool AllowBrightnessAdjustment { get; set; }

		// @property (nonatomic) BOOL allowContrastAdjustment;
		[Export("allowContrastAdjustment")]
		bool AllowContrastAdjustment { get; set; }

		// @property (nonatomic) BOOL allowSaturationAdjustment;
		[Export("allowSaturationAdjustment")]
		bool AllowSaturationAdjustment { get; set; }

		// -(instancetype _Nonnull)initWithImageURL:(NSURL * _Nonnull)imageURL thumbnailURL:(NSURL * _Nullable)thumbnailURL identifier:(NSString * _Nonnull)identifier;
		[Export("initWithImageURL:thumbnailURL:identifier:")]
		IntPtr Constructor(NSUrl imageURL, [NullAllowed] NSUrl thumbnailURL, string identifier);

		// -(instancetype _Nonnull)initWithImageURL:(NSURL * _Nonnull)imageURL thumbnailURL:(NSURL * _Nullable)thumbnailURL tintMode:(enum PESDKStickerTintMode)tintMode identifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithImageURL:thumbnailURL:tintMode:identifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSUrl imageURL, [NullAllowed] NSUrl thumbnailURL, PESDKStickerTintMode tintMode, string identifier);

		// +(PESDKSticker * _Nullable)withIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Static]
		[Export("withIdentifier:")]
		[return: NullAllowed]
		PESDKSticker WithIdentifier(string identifier);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKSticker New();
	}

	// @interface PESDKStickerCategory : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKStickerCategory
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nonnull imageURL;
		[Export("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageURL { get; }

		// @property (readonly, copy, nonatomic) NSArray<PESDKSticker *> * _Nonnull stickers;
		[Export("stickers", ArgumentSemantic.Copy)]
		PESDKSticker[] Stickers { get; }

		// -(instancetype _Nonnull)initWithTitle:(NSString * _Nonnull)title imageURL:(NSURL * _Nonnull)imageURL stickers:(NSArray<PESDKSticker *> * _Nonnull)stickers __attribute__((objc_designated_initializer));
		[Export("initWithTitle:imageURL:stickers:")]
		[DesignatedInitializer]
		IntPtr Constructor(string title, NSUrl imageURL, PESDKSticker[] stickers);

		// @property (copy, nonatomic, class) NSArray<PESDKStickerCategory *> * _Nonnull all;
		[Static]
		[Export("all", ArgumentSemantic.Copy)]
		PESDKStickerCategory[] All { get; set; }

		// +(NSArray<PESDKStickerCategory *> * _Nonnull)createDefaultStickerCategories __attribute__((warn_unused_result));
		[Static]
		[Export("createDefaultStickerCategories")]
		//[Verify(MethodToProperty)]
		PESDKStickerCategory[] CreateDefaultStickerCategories { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKStickerCategory New();
	}

	// @interface PESDKConfiguration : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKConfiguration
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull menuBackgroundColor;
		[Export("menuBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MenuBackgroundColor { get; }

		// @property (readonly, nonatomic, strong) PESDKCameraViewControllerOptions * _Nonnull cameraViewControllerOptions;
		[Export("cameraViewControllerOptions", ArgumentSemantic.Strong)]
		PESDKCameraViewControllerOptions CameraViewControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKPhotoEditViewControllerOptions * _Nonnull photoEditViewControllerOptions;
		[Export("photoEditViewControllerOptions", ArgumentSemantic.Strong)]
		PESDKPhotoEditViewControllerOptions PhotoEditViewControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKFilterToolControllerOptions * _Nonnull filterToolControllerOptions;
		[Export("filterToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKFilterToolControllerOptions FilterToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKOverlayToolControllerOptions * _Nonnull overlayToolControllerOptions;
		[Export("overlayToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKOverlayToolControllerOptions OverlayToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKStickerToolControllerOptions * _Nonnull stickerToolControllerOptions;
		[Export("stickerToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKStickerToolControllerOptions StickerToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKStickerOptionsToolControllerOptions * _Nonnull stickerOptionsToolControllerOptions;
		[Export("stickerOptionsToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKStickerOptionsToolControllerOptions StickerOptionsToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKColorToolControllerOptions * _Nonnull stickerColorToolControllerOptions;
		[Export("stickerColorToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKColorToolControllerOptions StickerColorToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKTransformToolControllerOptions * _Nonnull transformToolControllerOptions;
		[Export("transformToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKTransformToolControllerOptions TransformToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKFocusToolControllerOptions * _Nonnull focusToolControllerOptions;
		[Export("focusToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKFocusToolControllerOptions FocusToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKTextToolControllerOptions * _Nonnull textToolControllerOptions;
		[Export("textToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKTextToolControllerOptions TextToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) IMGLTextOptionsToolControllerOptions * _Nonnull textOptionsToolControllerOptions;
		[Export("textOptionsToolControllerOptions", ArgumentSemantic.Strong)]
		IMGLTextOptionsToolControllerOptions TextOptionsToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKTextFontToolControllerOptions * _Nonnull textFontToolControllerOptions;
		[Export("textFontToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKTextFontToolControllerOptions TextFontToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKTextColorToolControllerOptions * _Nonnull textColorToolControllerOptions;
		[Export("textColorToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKTextColorToolControllerOptions TextColorToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKAdjustToolControllerOptions * _Nonnull adjustToolControllerOptions;
		[Export("adjustToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKAdjustToolControllerOptions AdjustToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKBrushToolControllerOptions * _Nonnull brushToolControllerOptions;
		[Export("brushToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKBrushToolControllerOptions BrushToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKBrushColorToolControllerOptions * _Nonnull brushColorToolControllerOptions;
		[Export("brushColorToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKBrushColorToolControllerOptions BrushColorToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKFrameToolControllerOptions * _Nonnull frameToolControllerOptions;
		[Export("frameToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKFrameToolControllerOptions FrameToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKTextDesignToolControllerOptions * _Nonnull textDesignToolControllerOptions;
		[Export("textDesignToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKTextDesignToolControllerOptions TextDesignToolControllerOptions { get; }

		// @property (readonly, nonatomic, strong) PESDKTextDesignOptionsToolControllerOptions * _Nonnull textDesignOptionsToolControllerOptions;
		[Export("textDesignOptionsToolControllerOptions", ArgumentSemantic.Strong)]
		PESDKTextDesignOptionsToolControllerOptions TextDesignOptionsToolControllerOptions { get; }

		// -(instancetype _Nonnull)initWithBuilder:(void (^ _Nonnull)(PESDKConfigurationBuilder * _Nonnull))builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(Action<PESDKConfigurationBuilder> builder);
	}

	// @interface PESDKToolControllerOptions : NSObject
	[BaseType(typeof(NSObject))]
	interface PESDKToolControllerOptions
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nullable menuBackgroundColor;
		[NullAllowed, Export("menuBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MenuBackgroundColor { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) titleViewConfigurationClosure;
		[NullAllowed, Export("titleViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> TitleViewConfigurationClosure { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) applyButtonConfigurationClosure;
		[NullAllowed, Export("applyButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> ApplyButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) discardButtonConfigurationClosure;
		[NullAllowed, Export("discardButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> DiscardButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(void) didEnterToolClosure;
		[NullAllowed, Export("didEnterToolClosure", ArgumentSemantic.Copy)]
		Action DidEnterToolClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(void) willLeaveToolClosure;
		[NullAllowed, Export("willLeaveToolClosure", ArgumentSemantic.Copy)]
		Action WillLeaveToolClosure { get; }

		// -(instancetype _Nonnull)initWithEditorBuilder:(PESDKToolControllerOptionsBuilder * _Nonnull)editorBuilder __attribute__((objc_designated_initializer));
		[Export("initWithEditorBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKToolControllerOptionsBuilder editorBuilder);
	}

	// @interface PESDKTextDesignOptionsToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKTextDesignOptionsToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, PESDKTextDesign * _Nonnull) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, PESDKTextDesign> ActionButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum TextDesignOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, TextDesignOverlayAction> OverlayButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKTextDesign * _Nonnull) textDesignActionSelectedClosure;
		[NullAllowed, Export("textDesignActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKTextDesign> TextDesignActionSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum TextDesignOverlayAction) overlayActionSelectedClosure;
		[NullAllowed, Export("overlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<TextDesignOverlayAction> OverlayActionSelectedClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKTextDesignOptionsToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTextDesignOptionsToolControllerOptionsBuilder builder);
	}

	// @interface PESDKTextDesign : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKTextDesign
	{
		// @property (copy, nonatomic, class) NSArray<PESDKTextDesign *> * _Nonnull all;
		[Static]
		[Export("all", ArgumentSemantic.Copy)]
		PESDKTextDesign[] All { get; set; }

		// +(PESDKTextDesign * _Nullable)textDesignWithIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Static]
		[Export("textDesignWithIdentifier:")]
		[return: NullAllowed]
		PESDKTextDesign TextDesignWithIdentifier(string identifier);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKTextDesign New();
	}

	// @interface PESDKTextDesignOptionsToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKTextDesignOptionsToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, PESDKTextDesign * _Nonnull) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, PESDKTextDesign> ActionButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum TextDesignOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, TextDesignOverlayAction> OverlayButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKTextDesign * _Nonnull) textDesignActionSelectedClosure;
		[NullAllowed, Export("textDesignActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKTextDesign> TextDesignActionSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum TextDesignOverlayAction) overlayActionSelectedClosure;
		[NullAllowed, Export("overlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<TextDesignOverlayAction> OverlayActionSelectedClosure { get; set; }
	}

	// @interface PESDKTextDesignToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKTextDesignToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UITextView * _Nonnull) textViewConfigurationClosure;
		[NullAllowed, Export("textViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UITextView> TextViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) dimmingViewConfigurationClosure;
		[NullAllowed, Export("dimmingViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> DimmingViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKColorCollectionView * _Nonnull) colorCollectionViewConfigurationClosure;
		[NullAllowed, Export("colorCollectionViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKColorCollectionView> ColorCollectionViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable updateTitle;
		[NullAllowed, Export("updateTitle")]
		string UpdateTitle { get; }

		// @property (readonly, nonatomic, strong) PESDKColorPalette * _Nonnull colorPalette;
		[Export("colorPalette", ArgumentSemantic.Strong)]
		PESDKColorPalette ColorPalette { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKTextDesignToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTextDesignToolControllerOptionsBuilder builder);
	}

	// @interface PESDKColorPalette : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKColorPalette
	{
		// @property (readonly, copy, nonatomic) NSArray<PESDKColor *> * _Nonnull colors;
		[Export("colors", ArgumentSemantic.Copy)]
		PESDKColor[] Colors { get; }

		// -(instancetype _Nonnull)initWithColors:(NSArray<PESDKColor *> * _Nonnull)colors __attribute__((objc_designated_initializer));
		[Export("initWithColors:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKColor[] colors);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKColorPalette New();
	}

	// @interface PESDKColor : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKColor
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nonnull color;
		[Export("color", ArgumentSemantic.Strong)]
		UIColor Color { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull colorName;
		[Export("colorName")]
		string ColorName { get; }

		// -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color colorName:(NSString * _Nonnull)colorName __attribute__((objc_designated_initializer));
		[Export("initWithColor:colorName:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIColor color, string colorName);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKColor New();
	}

	// @interface PESDKColorCollectionView : UIView
	[iOS(9, 0)]
	[BaseType(typeof(UIView))]
	interface PESDKColorCollectionView
	{
		// @property (nonatomic, strong) PESDKColorPalette * _Nonnull colorPalette;
		[Export("colorPalette", ArgumentSemantic.Strong)]
		PESDKColorPalette ColorPalette { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		PESDKColorCollectionViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PESDKColorCollectionViewDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// -(instancetype _Nonnull)initWithColorPalette:(PESDKColorPalette * _Nonnull)colorPalette __attribute__((objc_designated_initializer));
		[Export("initWithColorPalette:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKColorPalette colorPalette);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)selectColorAtIndex:(NSInteger)index animated:(BOOL)animated;
		[Export("selectColorAtIndex:animated:")]
		void SelectColorAtIndex(nint index, bool animated);

		// @property (readonly, nonatomic) CGSize intrinsicContentSize;
		[Export("intrinsicContentSize")]
		CGSize IntrinsicContentSize { get; }
	}

	// @protocol PESDKColorCollectionViewDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKColorCollectionViewDelegate
	{
		// @required -(void)colorCollectionView:(PESDKColorCollectionView * _Nonnull)colorCollectionView didSelectColor:(PESDKColor * _Nonnull)color;
		[Abstract]
		[Export("colorCollectionView:didSelectColor:")]
		void DidSelectColor(PESDKColorCollectionView colorCollectionView, PESDKColor color);
	}

	// @interface PESDKTextDesignToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKTextDesignToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(UITextView * _Nonnull) textViewConfigurationClosure;
		[NullAllowed, Export("textViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UITextView> TextViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) dimmingViewConfigurationClosure;
		[NullAllowed, Export("dimmingViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> DimmingViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKColorCollectionView * _Nonnull) colorCollectionViewConfigurationClosure;
		[NullAllowed, Export("colorCollectionViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKColorCollectionView> ColorCollectionViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable updateTitle;
		[NullAllowed, Export("updateTitle")]
		string UpdateTitle { get; set; }

		// @property (nonatomic, strong) PESDKColorPalette * _Nonnull colorPalette;
		[Export("colorPalette", ArgumentSemantic.Strong)]
		PESDKColorPalette ColorPalette { get; set; }
	}

	// @interface PESDKFrameToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKFrameToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKFrame * _Nullable) selectedFrameClosure;
		[NullAllowed, Export("selectedFrameClosure", ArgumentSemantic.Copy)]
		Action<PESDKFrame> SelectedFrameClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKLabelIconBorderedCollectionViewCell * _Nonnull, PESDKFrame * _Nullable) cellConfigurationClosure;
		[NullAllowed, Export("cellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelIconBorderedCollectionViewCell, PESDKFrame> CellConfigurationClosure { get; }

		// @property (readonly, nonatomic) BOOL rotationEnabled;
		[Export("rotationEnabled")]
		bool RotationEnabled { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKFrameToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKFrameToolControllerOptionsBuilder builder);
	}

	// @interface PESDKFrame : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKFrame
	{
		// @property (nonatomic) UIEdgeInsets imageInsets;
		[Export("imageInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets ImageInsets { get; set; }

		// @property (readonly, nonatomic) CGFloat relativeScale;
		[Export("relativeScale")]
		nfloat RelativeScale { get; }

		// @property (readonly, nonatomic) CGFloat tolerance;
		[Export("tolerance")]
		nfloat Tolerance { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) BOOL isDynamic;
		[Export("isDynamic")]
		bool IsDynamic { get; }

		// -(instancetype _Nonnull)initWithFrameBuilder:(id<PESDKFrameBuilderProtocol> _Nonnull)frameBuilder relativeScale:(CGFloat)relativeScale thumbnailURL:(NSURL * _Nonnull)thumbnailURL identifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithFrameBuilder:relativeScale:thumbnailURL:identifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKFrameBuilderProtocol frameBuilder, nfloat relativeScale, NSUrl thumbnailURL, string identifier);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier tolerance:(CGFloat)tolerance __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:tolerance:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, nfloat tolerance);

		// -(void)addImage:(NSURL * _Nonnull)imageURL thumbnailURL:(NSURL * _Nullable)thumbnailURL forRatio:(CGFloat)ratio;
		[Export("addImage:thumbnailURL:forRatio:")]
		void AddImage(NSUrl imageURL, [NullAllowed] NSUrl thumbnailURL, nfloat ratio);

		// -(NSURL * _Nullable)imageURLForRatio:(CGFloat)ratio __attribute__((warn_unused_result));
		[Export("imageURLForRatio:")]
		[return: NullAllowed]
		NSUrl ImageURLForRatio(nfloat ratio);

		// -(NSURL * _Nullable)maskImageURLForRatio:(CGFloat)ratio withTolerance:(CGFloat)tolerance __attribute__((warn_unused_result));
		[Export("maskImageURLForRatio:withTolerance:")]
		[return: NullAllowed]
		NSUrl MaskImageURLForRatio(nfloat ratio, nfloat tolerance);

		// -(void)imageForSize:(CGSize)size completion:(void (^ _Nonnull)(UIImage * _Nullable))completion;
		[Export("imageForSize:completion:")]
		void ImageForSize(CGSize size, Action<UIImage> completion);

		// -(void)imageForSize:(CGSize)size relativeScale:(CGFloat)relativeScale completion:(void (^ _Nonnull)(UIImage * _Nullable))completion;
		[Export("imageForSize:relativeScale:completion:")]
		void ImageForSize(CGSize size, nfloat relativeScale, Action<UIImage> completion);

		// -(void)staticImageForRatio:(CGFloat)ratio completion:(void (^ _Nonnull)(UIImage * _Nullable))completion;
		[Export("staticImageForRatio:completion:")]
		void StaticImageForRatio(nfloat ratio, Action<UIImage> completion);

		// -(void)saveThumbnailToCameraRollForSize:(CGSize)size;
		[Export("saveThumbnailToCameraRollForSize:")]
		void SaveThumbnailToCameraRollForSize(CGSize size);

		// -(NSURL * _Nullable)thumbnailURLForRatio:(CGFloat)ratio __attribute__((warn_unused_result));
		[Export("thumbnailURLForRatio:")]
		[return: NullAllowed]
		NSUrl ThumbnailURLForRatio(nfloat ratio);

		// -(BOOL)hasImageForRatio:(CGFloat)ratio __attribute__((warn_unused_result));
		[Export("hasImageForRatio:")]
		bool HasImageForRatio(nfloat ratio);

		// @property (copy, nonatomic, class) NSArray<PESDKFrame *> * _Nonnull all;
		[Static]
		[Export("all", ArgumentSemantic.Copy)]
		PESDKFrame[] All { get; set; }

		// +(PESDKFrame * _Nullable)withIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Static]
		[Export("withIdentifier:")]
		[return: NullAllowed]
		PESDKFrame WithIdentifier(string identifier);

		// +(NSArray<PESDKFrame *> * _Nonnull)createDefaultFrames __attribute__((warn_unused_result));
		[Static]
		[Export("createDefaultFrames")]
		//[Verify(MethodToProperty)]
		PESDKFrame[] CreateDefaultFrames { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKFrame New();
	}

	// @protocol PESDKFrameBuilderProtocol
	[Protocol, Model]
	interface PESDKFrameBuilderProtocol
	{
		// @required -(void)buildWithSize:(CGSize)size relativeScale:(CGFloat)relativeScale completion:(void (^ _Nonnull)(UIImage * _Nullable))completion;
		[Abstract]
		[Export("buildWithSize:relativeScale:completion:")]
		void RelativeScale(CGSize size, nfloat relativeScale, Action<UIImage> completion);
	}

	// @interface PESDKLabelIconBorderedCollectionViewCell : PESDKLabelBorderedCollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(PESDKLabelBorderedCollectionViewCell))]
	interface PESDKLabelIconBorderedCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIImageView * _Nonnull iconImageView;
		[Export("iconImageView", ArgumentSemantic.Strong)]
		UIImageView IconImageView { get; }

		// @property (nonatomic) BOOL isIconVisible;
		[Export("isIconVisible")]
		bool IsIconVisible { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKLabelBorderedCollectionViewCell : PESDKActivityBorderedCollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(PESDKActivityBorderedCollectionViewCell))]
	interface PESDKLabelBorderedCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UILabel * _Nonnull textLabel;
		[Export("textLabel", ArgumentSemantic.Strong)]
		UILabel TextLabel { get; }

		// @property (nonatomic, strong) UIColor * _Nonnull textLabelTintColor;
		[Export("textLabelTintColor", ArgumentSemantic.Strong)]
		UIColor TextLabelTintColor { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKActivityBorderedCollectionViewCell : PESDKBorderedCollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(PESDKBorderedCollectionViewCell))]
	interface PESDKActivityBorderedCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIActivityIndicatorView * _Nonnull activityIndicator;
		[Export("activityIndicator", ArgumentSemantic.Strong)]
		UIActivityIndicatorView ActivityIndicator { get; }

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((availability(ios, introduced=9.0))) __attribute__((objc_designated_initializer));
		[iOS(9, 0)]
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((availability(ios, introduced=9.0))) __attribute__((objc_designated_initializer));
		[iOS(9, 0)]
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface PESDKBorderedCollectionViewCell : UICollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(UICollectionViewCell))]
	interface PESDKBorderedCollectionViewCell
	{
		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKFrameToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKFrameToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKFrame * _Nullable) selectedFrameClosure;
		[NullAllowed, Export("selectedFrameClosure", ArgumentSemantic.Copy)]
		Action<PESDKFrame> SelectedFrameClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKLabelIconBorderedCollectionViewCell * _Nonnull, PESDKFrame * _Nullable) cellConfigurationClosure;
		[NullAllowed, Export("cellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelIconBorderedCollectionViewCell, PESDKFrame> CellConfigurationClosure { get; set; }

		// @property (nonatomic) BOOL rotationEnabled;
		[Export("rotationEnabled")]
		bool RotationEnabled { get; set; }
	}

	// @interface PESDKBrushColorToolControllerOptions : PESDKColorToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKColorToolControllerOptions))]
	interface PESDKBrushColorToolControllerOptions
	{
		// -(instancetype _Nonnull)initWithBrushBuilder:(PESDKBrushColorToolControllerOptionsBuilder * _Nonnull)brushBuilder __attribute__((objc_designated_initializer));
		[Export("initWithBrushBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKBrushColorToolControllerOptionsBuilder brushBuilder);
	}

	// @interface PESDKBrushColorToolControllerOptionsBuilder : PESDKColorToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKColorToolControllerOptionsBuilder))]
	interface PESDKBrushColorToolControllerOptionsBuilder
	{
	}

	// @interface PESDKColorToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKColorToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull availableColors;
		[Export("availableColors", ArgumentSemantic.Copy)]
		UIColor[] AvailableColors { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull availableColorNames;
		[Export("availableColorNames", ArgumentSemantic.Copy)]
		string[] AvailableColorNames { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKColorCollectionViewCell * _Nonnull, UIColor * _Nonnull, NSString * _Nonnull) colorActionButtonConfigurationClosure;
		[NullAllowed, Export("colorActionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKColorCollectionViewCell, UIColor, NSString> ColorActionButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIColor * _Nonnull, NSString * _Nonnull) colorActionSelectedClosure;
		[NullAllowed, Export("colorActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<UIColor, NSString> ColorActionSelectedClosure { get; set; }
	}

	// @interface PESDKColorCollectionViewCell : UICollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(UICollectionViewCell))]
	interface PESDKColorCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIView * _Nonnull colorView;
		[Export("colorView", ArgumentSemantic.Strong)]
		UIView ColorView { get; }

		// @property (readonly, nonatomic, strong) UIImageView * _Nonnull imageView;
		[Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKBrushToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKBrushToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, enum BrushTool) brushToolButtonConfigurationClosure;
		[NullAllowed, Export("brushToolButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, BrushTool> BrushToolButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum BrushTool) brushToolSelectedClosure;
		[NullAllowed, Export("brushToolSelectedClosure", ArgumentSemantic.Copy)]
		Action<BrushTool> BrushToolSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) sliderConfigurationClosure;
		[NullAllowed, Export("sliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> SliderConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) sliderContainerConfigurationClosure;
		[NullAllowed, Export("sliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> SliderContainerConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum BrushTool) sliderChangedValueClosure;
		[NullAllowed, Export("sliderChangedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, BrushTool> SliderChangedValueClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum BrushOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, BrushOverlayAction> OverlayButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum BrushOverlayAction) brushActionSelectedClosure;
		[NullAllowed, Export("brushActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<BrushOverlayAction> BrushActionSelectedClosure { get; }

		// @property (readonly, nonatomic) CGFloat minimumBrushSize;
		[Export("minimumBrushSize")]
		nfloat MinimumBrushSize { get; }

		// @property (readonly, nonatomic) CGFloat maximumBrushSize;
		[Export("maximumBrushSize")]
		nfloat MaximumBrushSize { get; }

		// @property (readonly, nonatomic) CGFloat defaultBrushSize;
		[Export("defaultBrushSize")]
		nfloat DefaultBrushSize { get; }

		// @property (readonly, nonatomic) CGFloat minimumBrushHardness;
		[Export("minimumBrushHardness")]
		nfloat MinimumBrushHardness { get; }

		// @property (readonly, nonatomic) CGFloat maximumBrushHardness;
		[Export("maximumBrushHardness")]
		nfloat MaximumBrushHardness { get; }

		// @property (readonly, nonatomic) CGFloat defaultBrushHardness;
		[Export("defaultBrushHardness")]
		nfloat DefaultBrushHardness { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull defaultBrushColor;
		[Export("defaultBrushColor", ArgumentSemantic.Strong)]
		UIColor DefaultBrushColor { get; }

		// @property (readonly, nonatomic) BOOL usesUniformHardness;
		[Export("usesUniformHardness")]
		bool UsesUniformHardness { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKBrushToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKBrushToolControllerOptionsBuilder builder);
	}

	// @interface PESDKBrushToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKBrushToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, enum BrushTool) brushToolButtonConfigurationClosure;
		[NullAllowed, Export("brushToolButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, BrushTool> BrushToolButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum BrushTool) brushToolSelectedClosure;
		[NullAllowed, Export("brushToolSelectedClosure", ArgumentSemantic.Copy)]
		Action<BrushTool> BrushToolSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) sliderConfigurationClosure;
		[NullAllowed, Export("sliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> SliderConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) sliderContainerConfigurationClosure;
		[NullAllowed, Export("sliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> SliderContainerConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum BrushTool) sliderChangedValueClosure;
		[NullAllowed, Export("sliderChangedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, BrushTool> SliderChangedValueClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum BrushOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, BrushOverlayAction> OverlayButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum BrushOverlayAction) brushActionSelectedClosure;
		[NullAllowed, Export("brushActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<BrushOverlayAction> BrushActionSelectedClosure { get; set; }

		// @property (nonatomic) CGFloat minimumBrushSize;
		[Export("minimumBrushSize")]
		nfloat MinimumBrushSize { get; set; }

		// @property (nonatomic) CGFloat maximumBrushSize;
		[Export("maximumBrushSize")]
		nfloat MaximumBrushSize { get; set; }

		// @property (nonatomic) CGFloat defaultBrushSize;
		[Export("defaultBrushSize")]
		nfloat DefaultBrushSize { get; set; }

		// @property (nonatomic) CGFloat minimumBrushHardness;
		[Export("minimumBrushHardness")]
		nfloat MinimumBrushHardness { get; set; }

		// @property (nonatomic) CGFloat maximumBrushHardness;
		[Export("maximumBrushHardness")]
		nfloat MaximumBrushHardness { get; set; }

		// @property (nonatomic) CGFloat defaultBrushHardness;
		[Export("defaultBrushHardness")]
		nfloat DefaultBrushHardness { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull defaultBrushColor;
		[Export("defaultBrushColor", ArgumentSemantic.Strong)]
		UIColor DefaultBrushColor { get; set; }

		// @property (nonatomic) BOOL usesUniformHardness;
		[Export("usesUniformHardness")]
		bool UsesUniformHardness { get; set; }
	}

	// @interface PESDKAdjustToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKAdjustToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKIconCaptionCollectionViewCell * _Nonnull, enum AdjustTool) adjustToolButtonConfigurationClosure;
		[NullAllowed, Export("adjustToolButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCaptionCollectionViewCell, AdjustTool> AdjustToolButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum AdjustTool) adjustToolSelectedClosure;
		[NullAllowed, Export("adjustToolSelectedClosure", ArgumentSemantic.Copy)]
		Action<AdjustTool> AdjustToolSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) sliderConfigurationClosure;
		[NullAllowed, Export("sliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> SliderConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) sliderContainerConfigurationClosure;
		[NullAllowed, Export("sliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> SliderContainerConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum AdjustTool) sliderChangedValueClosure;
		[NullAllowed, Export("sliderChangedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, AdjustTool> SliderChangedValueClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKAdjustToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKAdjustToolControllerOptionsBuilder builder);
	}

	// @interface PESDKAdjustToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKAdjustToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKIconCaptionCollectionViewCell * _Nonnull, enum AdjustTool) adjustToolButtonConfigurationClosure;
		[NullAllowed, Export("adjustToolButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCaptionCollectionViewCell, AdjustTool> AdjustToolButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum AdjustTool) adjustToolSelectedClosure;
		[NullAllowed, Export("adjustToolSelectedClosure", ArgumentSemantic.Copy)]
		Action<AdjustTool> AdjustToolSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) sliderConfigurationClosure;
		[NullAllowed, Export("sliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> SliderConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) sliderContainerConfigurationClosure;
		[NullAllowed, Export("sliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> SliderContainerConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum AdjustTool) sliderChangedValueClosure;
		[NullAllowed, Export("sliderChangedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, AdjustTool> SliderChangedValueClosure { get; set; }
	}

	// @interface PESDKIconCaptionCollectionViewCell : UICollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(UICollectionViewCell))]
	interface PESDKIconCaptionCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIImageView * _Nonnull imageView;
		[Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull captionLabel;
		[Export("captionLabel", ArgumentSemantic.Strong)]
		UILabel CaptionLabel { get; }

		// @property (nonatomic, strong) UIColor * _Nonnull iconTintColor;
		[Export("iconTintColor", ArgumentSemantic.Strong)]
		UIColor IconTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull captionTintColor;
		[Export("captionTintColor", ArgumentSemantic.Strong)]
		UIColor CaptionTintColor { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKToolControllerOptionsBuilder : NSObject
	[BaseType(typeof(NSObject))]
	interface PESDKToolControllerOptionsBuilder
	{
		// @property (nonatomic, strong) UIColor * _Nullable menuBackgroundColor;
		[NullAllowed, Export("menuBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MenuBackgroundColor { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) titleViewConfigurationClosure;
		[NullAllowed, Export("titleViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> TitleViewConfigurationClosure { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(void) didEnterToolClosure;
		[NullAllowed, Export("didEnterToolClosure", ArgumentSemantic.Copy)]
		Action DidEnterToolClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(void) willLeaveToolClosure;
		[NullAllowed, Export("willLeaveToolClosure", ArgumentSemantic.Copy)]
		Action WillLeaveToolClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) applyButtonConfigurationClosure;
		[NullAllowed, Export("applyButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> ApplyButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) discardButtonConfigurationClosure;
		[NullAllowed, Export("discardButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> DiscardButtonConfigurationClosure { get; set; }
	}

	// @interface PESDKTextColorToolControllerOptions : PESDKColorToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKColorToolControllerOptions))]
	interface PESDKTextColorToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<UIColor *> * _Nonnull availableBackgroundTextColors;
		[Export("availableBackgroundTextColors", ArgumentSemantic.Copy)]
		UIColor[] AvailableBackgroundTextColors { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull availableBackgroundTextColorNames;
		[Export("availableBackgroundTextColorNames", ArgumentSemantic.Copy)]
		string[] AvailableBackgroundTextColorNames { get; }

		// -(instancetype _Nonnull)initWithTextBuilder:(PESDKTextColorToolControllerOptionsBuilder * _Nonnull)textBuilder __attribute__((objc_designated_initializer));
		[Export("initWithTextBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTextColorToolControllerOptionsBuilder textBuilder);
	}

	// @interface PESDKTextColorToolControllerOptionsBuilder : PESDKColorToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKColorToolControllerOptionsBuilder))]
	interface PESDKTextColorToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull availableBackgroundTextColors;
		[Export("availableBackgroundTextColors", ArgumentSemantic.Copy)]
		UIColor[] AvailableBackgroundTextColors { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull availableBackgroundTextColorNames;
		[Export("availableBackgroundTextColorNames", ArgumentSemantic.Copy)]
		string[] AvailableBackgroundTextColorNames { get; set; }
	}

	// @interface PESDKTextFontToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKTextFontToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKLabelCaptionCollectionViewCell * _Nonnull, NSString * _Nonnull) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelCaptionCollectionViewCell, NSString> ActionButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(NSString * _Nonnull) textFontActionSelectedClosure;
		[NullAllowed, Export("textFontActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<NSString> TextFontActionSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKFontSelectorView * _Nonnull) fontSelectorViewConfigurationClosure;
		[NullAllowed, Export("fontSelectorViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKFontSelectorView> FontSelectorViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKHandleButton * _Nonnull) handleButtonConfigurationClosure;
		[NullAllowed, Export("handleButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKHandleButton> HandleButtonConfigurationClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKTextFontToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTextFontToolControllerOptionsBuilder builder);
	}

	// @interface PESDKHandleButton : PESDKButton
	[iOS(9, 0)]
	[BaseType(typeof(PESDKButton))]
	interface PESDKHandleButton
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();
	}

	// @interface PESDKFontSelectorView : UIScrollView
	[iOS(9, 0)]
	[BaseType(typeof(UIScrollView))]
	interface PESDKFontSelectorView
	{
		[Wrap("WeakSelectorDelegate")]
		[NullAllowed]
		PESDKFontSelectorViewDelegate SelectorDelegate { get; set; }

		// @property (nonatomic, weak) id<PESDKFontSelectorViewDelegate> _Nullable selectorDelegate;
		[NullAllowed, Export("selectorDelegate", ArgumentSemantic.Weak)]
		NSObject WeakSelectorDelegate { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull labelColor;
		[Export("labelColor", ArgumentSemantic.Strong)]
		UIColor LabelColor { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable selectedFontName;
		[NullAllowed, Export("selectedFontName")]
		string SelectedFontName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable text;
		[NullAllowed, Export("text")]
		string Text { get; set; }

		// @property (nonatomic) CGRect bounds;
		[Export("bounds", ArgumentSemantic.Assign)]
		CGRect Bounds { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();
	}

	// @protocol PESDKFontSelectorViewDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKFontSelectorViewDelegate
	{
		// @required -(void)fontSelectorView:(PESDKFontSelectorView * _Nonnull)fontSelectorView didSelectFontWithName:(NSString * _Nonnull)fontName;
		[Abstract]
		[Export("fontSelectorView:didSelectFontWithName:")]
		void DidSelectFontWithName(PESDKFontSelectorView fontSelectorView, string fontName);
	}

	// @interface PESDKLabelCaptionCollectionViewCell : UICollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(UICollectionViewCell))]
	interface PESDKLabelCaptionCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UILabel * _Nonnull label;
		[Export("label", ArgumentSemantic.Strong)]
		UILabel Label { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull captionLabel;
		[Export("captionLabel", ArgumentSemantic.Strong)]
		UILabel CaptionLabel { get; }

		// @property (nonatomic, strong) UIColor * _Nonnull labelTintColor;
		[Export("labelTintColor", ArgumentSemantic.Strong)]
		UIColor LabelTintColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull captionTintColor;
		[Export("captionTintColor", ArgumentSemantic.Strong)]
		UIColor CaptionTintColor { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKTextFontToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKTextFontToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKLabelCaptionCollectionViewCell * _Nonnull, NSString * _Nonnull) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelCaptionCollectionViewCell, NSString> ActionButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSString * _Nonnull) textFontActionSelectedClosure;
		[NullAllowed, Export("textFontActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<NSString> TextFontActionSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKFontSelectorView * _Nonnull) fontSelectorViewConfigurationClosure;
		[NullAllowed, Export("fontSelectorViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKFontSelectorView> FontSelectorViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKHandleButton * _Nonnull) handleButtonConfigurationClosure;
		[NullAllowed, Export("handleButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKHandleButton> HandleButtonConfigurationClosure { get; set; }
	}

	// @interface IMGLTextOptionsToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface IMGLTextOptionsToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, enum TextAction) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, TextAction> ActionButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum TextOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, TextOverlayAction> OverlayButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum TextAction) textActionSelectedClosure;
		[NullAllowed, Export("textActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<TextAction> TextActionSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum TextOverlayAction) overlayActionSelectedClosure;
		[NullAllowed, Export("overlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<TextOverlayAction> OverlayActionSelectedClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKTextOptionsToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTextOptionsToolControllerOptionsBuilder builder);
	}

	// @interface PESDKTextOptionsToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKTextOptionsToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, enum TextAction) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, TextAction> ActionButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum TextOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, TextOverlayAction> OverlayButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum TextAction) textActionSelectedClosure;
		[NullAllowed, Export("textActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<TextAction> TextActionSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum TextOverlayAction) overlayActionSelectedClosure;
		[NullAllowed, Export("overlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<TextOverlayAction> OverlayActionSelectedClosure { get; set; }
	}

	// @interface PESDKTextToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKTextToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UITextView * _Nonnull) textViewConfigurationClosure;
		[NullAllowed, Export("textViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UITextView> TextViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) dimmingViewConfigurationClosure;
		[NullAllowed, Export("dimmingViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> DimmingViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable updateTitle;
		[NullAllowed, Export("updateTitle")]
		string UpdateTitle { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull defaultTextColor;
		[Export("defaultTextColor", ArgumentSemantic.Strong)]
		UIColor DefaultTextColor { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKTextToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTextToolControllerOptionsBuilder builder);
	}

	// @interface PESDKTextToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKTextToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(UITextView * _Nonnull) textViewConfigurationClosure;
		[NullAllowed, Export("textViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UITextView> TextViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) dimmingViewConfigurationClosure;
		[NullAllowed, Export("dimmingViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> DimmingViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable updateTitle;
		[NullAllowed, Export("updateTitle")]
		string UpdateTitle { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull defaultTextColor;
		[Export("defaultTextColor", ArgumentSemantic.Strong)]
		UIColor DefaultTextColor { get; set; }
	}

	// @interface PESDKFocusToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKFocusToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKIconCaptionCollectionViewCell * _Nonnull, enum PESDKFocusType) focusTypeButtonConfigurationClosure __attribute__((deprecated("Use `focusModeButtonConfigurationClosure` instead.")));
		[NullAllowed, Export("focusTypeButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCaptionCollectionViewCell, PESDKFocusType> FocusTypeButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKIconCaptionCollectionViewCell * _Nonnull, enum PESDKFocusMode) focusModeButtonConfigurationClosure;
		[NullAllowed, Export("focusModeButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCaptionCollectionViewCell, PESDKFocusMode> FocusModeButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum PESDKFocusType) focusTypeSelectedClosure __attribute__((deprecated("Use `focusModeSelectedClosure` instead.")));
		[NullAllowed, Export("focusTypeSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKFocusType> FocusTypeSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum PESDKFocusMode) focusModeSelectedClosure;
		[NullAllowed, Export("focusModeSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKFocusMode> FocusModeSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) sliderConfigurationClosure;
		[NullAllowed, Export("sliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> SliderConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) sliderContainerConfigurationClosure;
		[NullAllowed, Export("sliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> SliderContainerConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum PESDKFocusType) sliderChangedValueClosure __attribute__((deprecated("Use `sliderUpdatedValueClosure` instead.")));
		[NullAllowed, Export("sliderChangedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKFocusType> SliderChangedValueClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum PESDKFocusMode) sliderUpdatedValueClosure;
		[NullAllowed, Export("sliderUpdatedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKFocusMode> SliderUpdatedValueClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKCircleGradientView * _Nonnull) circleGradientViewConfigurationClosure;
		[NullAllowed, Export("circleGradientViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKCircleGradientView> CircleGradientViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKBoxGradientView * _Nonnull) boxGradientViewConfigurationClosure;
		[NullAllowed, Export("boxGradientViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKBoxGradientView> BoxGradientViewConfigurationClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKFocusToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKFocusToolControllerOptionsBuilder builder);
	}

	// @interface PESDKFocusToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKFocusToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKIconCaptionCollectionViewCell * _Nonnull, enum PESDKFocusType) focusTypeButtonConfigurationClosure __attribute__((deprecated("Use `focusModeButtonConfigurationClosure` instead.")));
		[NullAllowed, Export("focusTypeButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCaptionCollectionViewCell, PESDKFocusType> FocusTypeButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKIconCaptionCollectionViewCell * _Nonnull, enum PESDKFocusMode) focusModeButtonConfigurationClosure;
		[NullAllowed, Export("focusModeButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCaptionCollectionViewCell, PESDKFocusMode> FocusModeButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum PESDKFocusType) focusTypeSelectedClosure __attribute__((deprecated("Use `focusModeSelectedClosure` instead.")));
		[NullAllowed, Export("focusTypeSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKFocusType> FocusTypeSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum PESDKFocusMode) focusModeSelectedClosure;
		[NullAllowed, Export("focusModeSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKFocusMode> FocusModeSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) sliderConfigurationClosure;
		[NullAllowed, Export("sliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> SliderConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) sliderContainerConfigurationClosure;
		[NullAllowed, Export("sliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> SliderContainerConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum PESDKFocusType) sliderChangedValueClosure __attribute__((deprecated("Use `sliderUpdatedValueClosure` instead.")));
		[NullAllowed, Export("sliderChangedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKFocusType> SliderChangedValueClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, enum PESDKFocusMode) sliderUpdatedValueClosure;
		[NullAllowed, Export("sliderUpdatedValueClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKFocusMode> SliderUpdatedValueClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKCircleGradientView * _Nonnull) circleGradientViewConfigurationClosure;
		[NullAllowed, Export("circleGradientViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKCircleGradientView> CircleGradientViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKBoxGradientView * _Nonnull) boxGradientViewConfigurationClosure;
		[NullAllowed, Export("boxGradientViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKBoxGradientView> BoxGradientViewConfigurationClosure { get; set; }
	}

	// @interface PESDKBoxGradientView : PESDKFocusGradientView
	[iOS(9, 0)]
	[BaseType(typeof(PESDKFocusGradientView))]
	interface PESDKBoxGradientView
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)drawRect:(CGRect)rect;
		[Export("drawRect:")]
		void DrawRect(CGRect rect);

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();
	}

	// @interface PESDKFocusGradientView : UIControl
	[iOS(9, 0)]
	[BaseType(typeof(UIControl))]
	interface PESDKFocusGradientView
	{
		// @property (readonly, nonatomic) CGPoint centerPoint;
		[Export("centerPoint")]
		CGPoint CenterPoint { get; }

		// @property (nonatomic) CGFloat fadeWidth;
		[Export("fadeWidth")]
		nfloat FadeWidth { get; set; }

		// @property (readonly, nonatomic) CGFloat normalizedFadeWidth;
		[Export("normalizedFadeWidth")]
		nfloat NormalizedFadeWidth { get; }

		// @property (nonatomic, strong) UIColor * _Nonnull color;
		[Export("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();

		// -(void)accessibilityIncrement;
		[Export("accessibilityIncrement")]
		void AccessibilityIncrement();

		// -(void)accessibilityDecrement;
		[Export("accessibilityDecrement")]
		void AccessibilityDecrement();
	}

	// @interface PESDKCircleGradientView : PESDKFocusGradientView
	[iOS(9, 0)]
	[BaseType(typeof(PESDKFocusGradientView))]
	interface PESDKCircleGradientView
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)drawRect:(CGRect)rect;
		[Export("drawRect:")]
		void DrawRect(CGRect rect);

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();
	}

	// @interface PESDKTransformToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKTransformToolControllerOptions
	{
		// @property (readonly, nonatomic) BOOL allowFreeCrop;
		[Export("allowFreeCrop")]
		bool AllowFreeCrop { get; }

		// @property (readonly, copy, nonatomic) NSArray<PESDKCropAspect *> * _Nonnull allowedCropAspects;
		[Export("allowedCropAspects", ArgumentSemantic.Copy)]
		PESDKCropAspect[] AllowedCropAspects { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKLabelBorderedCollectionViewCell * _Nonnull, PESDKCropAspect * _Nullable) cropAspectButtonConfigurationClosure;
		[NullAllowed, Export("cropAspectButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelBorderedCollectionViewCell, PESDKCropAspect> CropAspectButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKCropAspect * _Nullable) cropAspectSelectedClosure;
		[NullAllowed, Export("cropAspectSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKCropAspect> CropAspectSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull, enum TransformAction) transformButtonConfigurationClosure;
		[NullAllowed, Export("transformButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton, TransformAction> TransformButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKScalePicker * _Nonnull) scalePickerConfigurationClosure;
		[NullAllowed, Export("scalePickerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKScalePicker> ScalePickerConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) scalePickerContainerViewConfigurationClosure;
		[NullAllowed, Export("scalePickerContainerViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> ScalePickerContainerViewConfigurationClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKTransformToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKTransformToolControllerOptionsBuilder builder);
	}

	// @interface PESDKTransformToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKTransformToolControllerOptionsBuilder
	{
		// @property (nonatomic) BOOL allowFreeCrop;
		[Export("allowFreeCrop")]
		bool AllowFreeCrop { get; set; }

		// @property (copy, nonatomic) NSArray<PESDKCropAspect *> * _Nonnull allowedCropRatios;
		[Export("allowedCropRatios", ArgumentSemantic.Copy)]
		PESDKCropAspect[] AllowedCropRatios { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull, enum TransformAction) transformButtonConfigurationClosure;
		[NullAllowed, Export("transformButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton, TransformAction> TransformButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKLabelBorderedCollectionViewCell * _Nonnull, PESDKCropAspect * _Nullable) cropAspectButtonConfigurationClosure;
		[NullAllowed, Export("cropAspectButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelBorderedCollectionViewCell, PESDKCropAspect> CropAspectButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKCropAspect * _Nullable) cropAspectSelectedClosure;
		[NullAllowed, Export("cropAspectSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKCropAspect> CropAspectSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKScalePicker * _Nonnull) scalePickerConfigurationClosure;
		[NullAllowed, Export("scalePickerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKScalePicker> ScalePickerConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) scalePickerContainerViewConfigurationClosure;
		[NullAllowed, Export("scalePickerContainerViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> ScalePickerContainerViewConfigurationClosure { get; set; }
	}

	// @interface PESDKScalePicker : UIView
	[iOS(9, 0)]
	[BaseType(typeof(UIView))]
	interface PESDKScalePicker
	{
		// @property (nonatomic) CGFloat currentValue;
		[Export("currentValue")]
		nfloat CurrentValue { get; set; }

		// @property (nonatomic) NSInteger minValue;
		[Export("minValue")]
		nint MinValue { get; set; }

		// @property (nonatomic) NSInteger maxValue;
		[Export("maxValue")]
		nint MaxValue { get; set; }

		// @property (nonatomic) CGSize tickSize;
		[Export("tickSize", ArgumentSemantic.Assign)]
		CGSize TickSize { get; set; }

		// @property (nonatomic) CGSize mainTickSize;
		[Export("mainTickSize", ArgumentSemantic.Assign)]
		CGSize MainTickSize { get; set; }

		// @property (nonatomic) CGFloat spaceBetweenTicks;
		[Export("spaceBetweenTicks")]
		nfloat SpaceBetweenTicks { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull tickColor;
		[Export("tickColor", ArgumentSemantic.Strong)]
		UIColor TickColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull valueLabelBackgroundColor;
		[Export("valueLabelBackgroundColor", ArgumentSemantic.Strong)]
		UIColor ValueLabelBackgroundColor { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		PESDKScalePickerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<PESDKScalePickerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)layoutSubviews;
		[Export("layoutSubviews")]
		void LayoutSubviews();

		// -(void)scrollToValue:(CGFloat)value;
		[Export("scrollToValue:")]
		void ScrollToValue(nfloat value);

		// -(void)accessibilityIncrement;
		[Export("accessibilityIncrement")]
		void AccessibilityIncrement();

		// -(void)accessibilityDecrement;
		[Export("accessibilityDecrement")]
		void AccessibilityDecrement();
	}

	// @protocol PESDKScalePickerDelegate
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[Model]
	interface PESDKScalePickerDelegate
	{
		// @required -(void)scalePicker:(CGFloat)value didChangeValue:(PESDKScalePicker * _Nonnull)scalePicker;
		[Abstract]
		[Export("scalePicker:didChangeValue:")]
		void DidChangeValue(nfloat value, PESDKScalePicker scalePicker);
	}

	// @interface PESDKCropAspect : NSObject
	[BaseType(typeof(NSObject))]
	interface PESDKCropAspect
	{
		// -(instancetype _Nonnull)initWithWidth:(CGFloat)width height:(CGFloat)height;
		[Export("initWithWidth:height:")]
		IntPtr Constructor(nfloat width, nfloat height);

		// -(instancetype _Nonnull)initWithWidth:(CGFloat)width height:(CGFloat)height rotatable:(BOOL)rotatable;
		[Export("initWithWidth:height:rotatable:")]
		IntPtr Constructor(nfloat width, nfloat height, bool rotatable);

		// -(instancetype _Nonnull)initWithWidth:(CGFloat)width height:(CGFloat)height localizedName:(NSString * _Nonnull)localizedName;
		[Export("initWithWidth:height:localizedName:")]
		IntPtr Constructor(nfloat width, nfloat height, string localizedName);

		// -(instancetype _Nonnull)initWithWidth:(CGFloat)width height:(CGFloat)height localizedName:(NSString * _Nonnull)localizedName rotatable:(BOOL)rotatable __attribute__((objc_designated_initializer));
		[Export("initWithWidth:height:localizedName:rotatable:")]
		[DesignatedInitializer]
		IntPtr Constructor(nfloat width, nfloat height, string localizedName, bool rotatable);

		// @property (readonly, nonatomic) CGFloat width;
		[Export("width")]
		nfloat Width { get; }

		// @property (readonly, nonatomic) CGFloat height;
		[Export("height")]
		nfloat Height { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull localizedName;
		[Export("localizedName")]
		string LocalizedName { get; }

		// @property (readonly, nonatomic) BOOL isRotatable;
		[Export("isRotatable")]
		bool IsRotatable { get; }

		// @property (readonly, nonatomic) CGFloat ratio;
		[Export("ratio")]
		nfloat Ratio { get; }

		// -(CGFloat)widthForHeight:(CGFloat)height __attribute__((warn_unused_result));
		[Export("widthForHeight:")]
		nfloat WidthForHeight(nfloat height);

		// -(CGFloat)heightForWidth:(CGFloat)width __attribute__((warn_unused_result));
		[Export("heightForWidth:")]
		nfloat HeightForWidth(nfloat width);

		// @property (readonly, nonatomic, strong) PESDKCropAspect * _Nonnull inversed;
		[Export("inversed", ArgumentSemantic.Strong)]
		PESDKCropAspect Inversed { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; }
	}

	// @interface PESDKColorToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKColorToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<UIColor *> * _Nonnull availableColors;
		[Export("availableColors", ArgumentSemantic.Copy)]
		UIColor[] AvailableColors { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull availableColorNames;
		[Export("availableColorNames", ArgumentSemantic.Copy)]
		string[] AvailableColorNames { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKColorCollectionViewCell * _Nonnull, UIColor * _Nonnull, NSString * _Nonnull) colorActionButtonConfigurationClosure;
		[NullAllowed, Export("colorActionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKColorCollectionViewCell, UIColor, NSString> ColorActionButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIColor * _Nonnull, NSString * _Nonnull) colorActionSelectedClosure;
		[NullAllowed, Export("colorActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<UIColor, NSString> ColorActionSelectedClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKColorToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKColorToolControllerOptionsBuilder builder);
	}

	// @interface PESDKStickerOptionsToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKStickerOptionsToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum StickerAction) stickerActionSelectedClosure;
		[NullAllowed, Export("stickerActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<StickerAction> StickerActionSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, enum StickerAction) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, StickerAction> ActionButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum StickerOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, StickerOverlayAction> OverlayButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum StickerOverlayAction) stickerOverlayActionSelectedClosure;
		[NullAllowed, Export("stickerOverlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<StickerOverlayAction> StickerOverlayActionSelectedClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKStickerOptionsToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKStickerOptionsToolControllerOptionsBuilder builder);
	}

	// @interface PESDKStickerOptionsToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKStickerOptionsToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(enum StickerAction) stickerActionSelectedClosure;
		[NullAllowed, Export("stickerActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<StickerAction> StickerActionSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UICollectionViewCell * _Nonnull, enum StickerAction) actionButtonConfigurationClosure;
		[NullAllowed, Export("actionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionViewCell, StickerAction> ActionButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum StickerOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, StickerOverlayAction> OverlayButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum StickerOverlayAction) stickerOverlayActionSelectedClosure;
		[NullAllowed, Export("stickerOverlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<StickerOverlayAction> StickerOverlayActionSelectedClosure { get; set; }
	}

	// @interface PESDKStickerToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKStickerToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSticker * _Nonnull) addedStickerClosure;
		[NullAllowed, Export("addedStickerClosure", ArgumentSemantic.Copy)]
		Action<PESDKSticker> AddedStickerClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKIconBorderedCollectionViewCell * _Nonnull, PESDKStickerCategory * _Nonnull) stickerCategoryButtonConfigurationClosure;
		[NullAllowed, Export("stickerCategoryButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconBorderedCollectionViewCell, PESDKStickerCategory> StickerCategoryButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKIconCollectionViewCell * _Nonnull, PESDKSticker * _Nonnull) stickerButtonConfigurationClosure;
		[NullAllowed, Export("stickerButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCollectionViewCell, PESDKSticker> StickerButtonConfigurationClosure { get; }

		// @property (readonly, nonatomic) CGSize stickerPreviewSize;
		[Export("stickerPreviewSize")]
		CGSize StickerPreviewSize { get; }

		// @property (readonly, nonatomic) NSInteger defaultStickerCategoryIndex;
		[Export("defaultStickerCategoryIndex")]
		nint DefaultStickerCategoryIndex { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKStickerToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKStickerToolControllerOptionsBuilder builder);
	}

	// @interface PESDKIconCollectionViewCell : UICollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(UICollectionViewCell))]
	interface PESDKIconCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIImageView * _Nonnull imageView;
		[Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; }

		// @property (readonly, nonatomic, strong) UIActivityIndicatorView * _Nonnull activityIndicator;
		[Export("activityIndicator", ArgumentSemantic.Strong)]
		UIActivityIndicatorView ActivityIndicator { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKIconBorderedCollectionViewCell : PESDKActivityBorderedCollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(PESDKActivityBorderedCollectionViewCell))]
	interface PESDKIconBorderedCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIImageView * _Nonnull imageView;
		[Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();
	}

	// @interface PESDKOverlayToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKOverlayToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) overlayIntensitySliderConfigurationClosure;
		[NullAllowed, Export("overlayIntensitySliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> OverlayIntensitySliderConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) overlayIntensitySliderContainerConfigurationClosure;
		[NullAllowed, Export("overlayIntensitySliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> OverlayIntensitySliderContainerConfigurationClosure { get; }

		// @property (readonly, nonatomic) BOOL showOverlayIntensitySlider;
		[Export("showOverlayIntensitySlider")]
		bool ShowOverlayIntensitySlider { get; }

		// @property (readonly, nonatomic) BOOL showModeSelectionView;
		[Export("showModeSelectionView")]
		bool ShowModeSelectionView { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKOverlay * _Nonnull) overlaySelectedClosure;
		[NullAllowed, Export("overlaySelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlay> OverlaySelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum PESDKBlendMode) blendModeSelectedClosure;
		[NullAllowed, Export("blendModeSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKBlendMode> BlendModeSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, PESDKOverlay * _Nonnull) overlayIntensityChangedClosure;
		[NullAllowed, Export("overlayIntensityChangedClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKOverlay> OverlayIntensityChangedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKFilterCollectionViewCell * _Nonnull, PESDKOverlay * _Nonnull) overlayCellConfigurationClosure;
		[NullAllowed, Export("overlayCellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKFilterCollectionViewCell, PESDKOverlay> OverlayCellConfigurationClosure { get; }

		// @property (readonly, nonatomic) CGFloat initialOverlayIntensity;
		[Export("initialOverlayIntensity")]
		nfloat InitialOverlayIntensity { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UICollectionView * _Nonnull) overlayModeSelectionViewConfigurationClosure;
		[NullAllowed, Export("overlayModeSelectionViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionView> OverlayModeSelectionViewConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKLabelBorderedCollectionViewCell * _Nonnull, enum PESDKBlendMode) overlayModeSelectionCellConfigurationClosure;
		[NullAllowed, Export("overlayModeSelectionCellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelBorderedCollectionViewCell, PESDKBlendMode> OverlayModeSelectionCellConfigurationClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKOverlayToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKOverlayToolControllerOptionsBuilder builder);
	}

	// @interface PESDKOverlayToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKOverlayToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) overlayIntensitySliderConfigurationClosure;
		[NullAllowed, Export("overlayIntensitySliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> OverlayIntensitySliderConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) overlayIntensitySliderContainerConfigurationClosure;
		[NullAllowed, Export("overlayIntensitySliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> OverlayIntensitySliderContainerConfigurationClosure { get; set; }

		// @property (nonatomic) BOOL showOverlayIntensitySlider;
		[Export("showOverlayIntensitySlider")]
		bool ShowOverlayIntensitySlider { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKOverlay * _Nonnull) overlaySelectedClosure;
		[NullAllowed, Export("overlaySelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlay> OverlaySelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum PESDKBlendMode) blendModeSelectedClosure;
		[NullAllowed, Export("blendModeSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKBlendMode> BlendModeSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, PESDKOverlay * _Nonnull) overlayIntensityChangedClosure;
		[NullAllowed, Export("overlayIntensityChangedClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKOverlay> OverlayIntensityChangedClosure { get; set; }

		// @property (nonatomic) BOOL showModeSelectionView;
		[Export("showModeSelectionView")]
		bool ShowModeSelectionView { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKFilterCollectionViewCell * _Nonnull, PESDKOverlay * _Nonnull) overlayCellConfigurationClosure;
		[NullAllowed, Export("overlayCellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKFilterCollectionViewCell, PESDKOverlay> OverlayCellConfigurationClosure { get; set; }

		// @property (nonatomic) CGFloat initialOverlayIntensity;
		[Export("initialOverlayIntensity")]
		nfloat InitialOverlayIntensity { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UICollectionView * _Nonnull) overlayModeSelectionViewConfigurationClosure;
		[NullAllowed, Export("overlayModeSelectionViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UICollectionView> OverlayModeSelectionViewConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKLabelBorderedCollectionViewCell * _Nonnull, enum PESDKBlendMode) overlayModeSelectionCellConfigurationClosure;
		[NullAllowed, Export("overlayModeSelectionCellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKLabelBorderedCollectionViewCell, PESDKBlendMode> OverlayModeSelectionCellConfigurationClosure { get; set; }
	}

	// @interface PESDKFilterCollectionViewCell : UICollectionViewCell
	[iOS(9, 0)]
	[BaseType(typeof(UICollectionViewCell))]
	interface PESDKFilterCollectionViewCell
	{
		// @property (readonly, nonatomic, strong) UIImageView * _Nonnull imageView;
		[Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; }

		// @property (readonly, nonatomic, strong) PESDKGradientView * _Nonnull gradientView;
		[Export("gradientView", ArgumentSemantic.Strong)]
		PESDKGradientView GradientView { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull captionLabel;
		[Export("captionLabel", ArgumentSemantic.Strong)]
		UILabel CaptionLabel { get; }

		// @property (readonly, nonatomic, strong) UIActivityIndicatorView * _Nonnull activityIndicator;
		[Export("activityIndicator", ArgumentSemantic.Strong)]
		UIActivityIndicatorView ActivityIndicator { get; }

		// @property (readonly, nonatomic, strong) PESDKGradientView * _Nonnull selectionOverlay;
		[Export("selectionOverlay", ArgumentSemantic.Strong)]
		PESDKGradientView SelectionOverlay { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull selectionIndicator;
		[Export("selectionIndicator", ArgumentSemantic.Strong)]
		UIView SelectionIndicator { get; }

		// @property (readonly, nonatomic, strong) UILabel * _Nonnull selectionLabel;
		[Export("selectionLabel", ArgumentSemantic.Strong)]
		UILabel SelectionLabel { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)tintColorDidChange;
		[Export("tintColorDidChange")]
		void TintColorDidChange();

		// -(void)prepareForReuse;
		[Export("prepareForReuse")]
		void PrepareForReuse();

		// @property (getter = isSelected, nonatomic) BOOL selected;
		[Export("selected")]
		bool Selected { [Bind("isSelected")] get; set; }

		// @property (getter = isHighlighted, nonatomic) BOOL highlighted;
		[Export("highlighted")]
		bool Highlighted { [Bind("isHighlighted")] get; set; }
	}

	// @interface PESDKGradientView : UIView
	[BaseType(typeof(UIView))]
	interface PESDKGradientView
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nonnull topColor;
		[Export("topColor", ArgumentSemantic.Strong)]
		UIColor TopColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nonnull bottomColor;
		[Export("bottomColor", ArgumentSemantic.Strong)]
		UIColor BottomColor { get; }

		// -(instancetype _Nonnull)initWithTopColor:(UIColor * _Nonnull)topColor bottomColor:(UIColor * _Nonnull)bottomColor __attribute__((objc_designated_initializer));
		[Export("initWithTopColor:bottomColor:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIColor topColor, UIColor bottomColor);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// @property (readonly, nonatomic, class) Class _Nonnull layerClass;
		[Static]
		[Export("layerClass")]
		Class LayerClass { get; }
	}

	// @interface PESDKOverlay : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKOverlay
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable thumbnailURL;
		[NullAllowed, Export("thumbnailURL", ArgumentSemantic.Copy)]
		NSUrl ThumbnailURL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull displayName;
		[Export("displayName")]
		string DisplayName { get; }

		// @property (readonly, nonatomic) enum PESDKBlendMode initialBlendMode;
		[Export("initialBlendMode")]
		PESDKBlendMode InitialBlendMode { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier displayName:(NSString * _Nonnull)displayName url:(NSURL * _Nullable)url thumbnailURL:(NSURL * _Nullable)thumbnailURL initialBlendMode:(enum PESDKBlendMode)initialBlendMode __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:displayName:url:thumbnailURL:initialBlendMode:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, string displayName, [NullAllowed] NSUrl url, [NullAllowed] NSUrl thumbnailURL, PESDKBlendMode initialBlendMode);

		// +(PESDKOverlay * _Nullable)overlayWithIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Static]
		[Export("overlayWithIdentifier:")]
		[return: NullAllowed]
		PESDKOverlay OverlayWithIdentifier(string identifier);

		// @property (readonly, nonatomic, strong, class) PESDKOverlay * _Nonnull none;
		[Static]
		[Export("none", ArgumentSemantic.Strong)]
		PESDKOverlay None { get; }

		// @property (copy, nonatomic, class) NSArray<PESDKOverlay *> * _Nonnull all;
		[Static]
		[Export("all", ArgumentSemantic.Copy)]
		PESDKOverlay[] All { get; set; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKOverlay New();
	}

	// @interface PESDKFilterToolControllerOptions : PESDKToolControllerOptions
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptions))]
	interface PESDKFilterToolControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) filterIntensitySliderConfigurationClosure;
		[NullAllowed, Export("filterIntensitySliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> FilterIntensitySliderConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) filterIntensitySliderContainerConfigurationClosure;
		[NullAllowed, Export("filterIntensitySliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> FilterIntensitySliderContainerConfigurationClosure { get; }

		// @property (readonly, nonatomic) BOOL showFilterIntensitySlider;
		[Export("showFilterIntensitySlider")]
		bool ShowFilterIntensitySlider { get; }

		// @property (readonly, nonatomic) CGFloat initialFilterIntensity;
		[Export("initialFilterIntensity")]
		nfloat InitialFilterIntensity { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKPhotoEffect * _Nonnull) filterSelectedClosure;
		[NullAllowed, Export("filterSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKPhotoEffect> FilterSelectedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, PESDKPhotoEffect * _Nonnull) filterIntensityChangedClosure;
		[NullAllowed, Export("filterIntensityChangedClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKPhotoEffect> FilterIntensityChangedClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKFilterCollectionViewCell * _Nonnull, PESDKPhotoEffect * _Nonnull) filterCellConfigurationClosure;
		[NullAllowed, Export("filterCellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKFilterCollectionViewCell, PESDKPhotoEffect> FilterCellConfigurationClosure { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKFilterToolControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKFilterToolControllerOptionsBuilder builder);
	}

	// @interface PESDKFilterToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKFilterToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) filterIntensitySliderConfigurationClosure;
		[NullAllowed, Export("filterIntensitySliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> FilterIntensitySliderConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) filterIntensitySliderContainerConfigurationClosure;
		[NullAllowed, Export("filterIntensitySliderContainerConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> FilterIntensitySliderContainerConfigurationClosure { get; set; }

		// @property (nonatomic) BOOL showFilterIntensitySlider;
		[Export("showFilterIntensitySlider")]
		bool ShowFilterIntensitySlider { get; set; }

		// @property (nonatomic) CGFloat initialFilterIntensity;
		[Export("initialFilterIntensity")]
		nfloat InitialFilterIntensity { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKPhotoEffect * _Nonnull) filterSelectedClosure;
		[NullAllowed, Export("filterSelectedClosure", ArgumentSemantic.Copy)]
		Action<PESDKPhotoEffect> FilterSelectedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull, PESDKPhotoEffect * _Nonnull) filterIntensityChangedClosure;
		[NullAllowed, Export("filterIntensityChangedClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider, PESDKPhotoEffect> FilterIntensityChangedClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKFilterCollectionViewCell * _Nonnull, PESDKPhotoEffect * _Nonnull) filterCellConfigurationClosure;
		[NullAllowed, Export("filterCellConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKFilterCollectionViewCell, PESDKPhotoEffect> FilterCellConfigurationClosure { get; set; }
	}

	// @interface PESDKPhotoEffect : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKPhotoEffect
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable ciFilterName;
		[NullAllowed, Export("ciFilterName")]
		string CiFilterName { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable lutURL;
		[NullAllowed, Export("lutURL", ArgumentSemantic.Copy)]
		NSUrl LutURL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull displayName;
		[Export("displayName")]
		string DisplayName { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable options;
		[NullAllowed, Export("options", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Options { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier ciFilterName:(NSString * _Nullable)filterName displayName:(NSString * _Nonnull)displayName options:(NSDictionary<NSString *,id> * _Nullable)options __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:ciFilterName:displayName:options:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, [NullAllowed] string filterName, string displayName, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier lutURL:(NSURL * _Nullable)lutURL displayName:(NSString * _Nonnull)displayName __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:lutURL:displayName:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, [NullAllowed] NSUrl lutURL, string displayName);

		// @property (readonly, nonatomic, strong) CIFilter * _Nullable newEffectFilter;
		[NullAllowed, Export("newEffectFilter", ArgumentSemantic.Strong)]
		CIFilter NewEffectFilter { get; }

		// @property (copy, nonatomic, class) NSArray<PESDKPhotoEffect *> * _Nonnull allEffects;
		[Static]
		[Export("allEffects", ArgumentSemantic.Copy)]
		PESDKPhotoEffect[] AllEffects { get; set; }

		// +(PESDKPhotoEffect * _Nullable)effectWithIdentifier:(NSString * _Nonnull)identifier __attribute__((warn_unused_result));
		[Static]
		[Export("effectWithIdentifier:")]
		[return: NullAllowed]
		PESDKPhotoEffect EffectWithIdentifier(string identifier);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKPhotoEffect New();
	}

	// @interface PESDKPhotoEditViewControllerOptions : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKPhotoEditViewControllerOptions
	{
		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) titleViewConfigurationClosure;
		[NullAllowed, Export("titleViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> TitleViewConfigurationClosure { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; }

		// @property (readonly, nonatomic, strong) UIColor * _Nullable menuBackgroundColor;
		[NullAllowed, Export("menuBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MenuBackgroundColor { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) applyButtonConfigurationClosure;
		[NullAllowed, Export("applyButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> ApplyButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) discardButtonConfigurationClosure;
		[NullAllowed, Export("discardButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> DiscardButtonConfigurationClosure { get; }

		// @property (readonly, nonatomic) BOOL allowsPreviewImageZoom;
		[Export("allowsPreviewImageZoom")]
		bool AllowsPreviewImageZoom { get; }

		// @property (readonly, nonatomic) BOOL forceCropMode;
		[Export("forceCropMode")]
		bool ForceCropMode { get; }

		// @property (readonly, nonatomic) enum PESDKImageFileFormat outputImageFileFormat;
		[Export("outputImageFileFormat")]
		PESDKImageFileFormat OutputImageFileFormat { get; }

		// @property (readonly, nonatomic) CGFloat compressionQuality;
		[Export("compressionQuality")]
		nfloat CompressionQuality { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum PhotoEditOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, PhotoEditOverlayAction> OverlayButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(enum PhotoEditOverlayAction) photoEditOverlayActionSelectedClosure;
		[NullAllowed, Export("photoEditOverlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<PhotoEditOverlayAction> PhotoEditOverlayActionSelectedClosure { get; }

		// @property (readonly, nonatomic) BOOL undoStepByStep;
		[Export("undoStepByStep")]
		bool UndoStepByStep { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKPhotoEditViewController * _Nonnull, void (^ _Nonnull)(void)) discardConfirmationClosure;
		[NullAllowed, Export("discardConfirmationClosure", ArgumentSemantic.Copy)]
		Action<PESDKPhotoEditViewController, Action> DiscardConfirmationClosure { get; }

		// @property (readonly, nonatomic) BOOL useParentNavigationItem;
		[Export("useParentNavigationItem")]
		bool UseParentNavigationItem { get; }

		// -(instancetype _Nonnull)initWithBuilder:(PESDKPhotoEditViewControllerOptionsBuilder * _Nonnull)builder __attribute__((objc_designated_initializer));
		[Export("initWithBuilder:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKPhotoEditViewControllerOptionsBuilder builder);
	}

	// @interface PESDKPhotoEditViewControllerOptionsBuilder : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKPhotoEditViewControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(UIView * _Nonnull) titleViewConfigurationClosure;
		[NullAllowed, Export("titleViewConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UIView> TitleViewConfigurationClosure { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable menuBackgroundColor;
		[NullAllowed, Export("menuBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MenuBackgroundColor { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) applyButtonConfigurationClosure;
		[NullAllowed, Export("applyButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> ApplyButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) discardButtonConfigurationClosure;
		[NullAllowed, Export("discardButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> DiscardButtonConfigurationClosure { get; set; }

		// @property (nonatomic) BOOL forceCropMode;
		[Export("forceCropMode")]
		bool ForceCropMode { get; set; }

		// @property (nonatomic) BOOL allowsPreviewImageZoom;
		[Export("allowsPreviewImageZoom")]
		bool AllowsPreviewImageZoom { get; set; }

		// @property (nonatomic) enum PESDKImageFileFormat outputImageFileFormat;
		[Export("outputImageFileFormat", ArgumentSemantic.Assign)]
		PESDKImageFileFormat OutputImageFileFormat { get; set; }

		// @property (nonatomic) CGFloat compressionQuality;
		[Export("compressionQuality")]
		nfloat CompressionQuality { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKOverlayButton * _Nonnull, enum PhotoEditOverlayAction) overlayButtonConfigurationClosure;
		[NullAllowed, Export("overlayButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKOverlayButton, PhotoEditOverlayAction> OverlayButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum PhotoEditOverlayAction) photoEditOverlayActionSelectedClosure;
		[NullAllowed, Export("photoEditOverlayActionSelectedClosure", ArgumentSemantic.Copy)]
		Action<PhotoEditOverlayAction> PhotoEditOverlayActionSelectedClosure { get; set; }

		// @property (nonatomic) BOOL undoStepByStep;
		[Export("undoStepByStep")]
		bool UndoStepByStep { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKPhotoEditViewController * _Nonnull, void (^ _Nonnull)(void)) discardConfirmationClosure;
		[NullAllowed, Export("discardConfirmationClosure", ArgumentSemantic.Copy)]
		Action<PESDKPhotoEditViewController, Action> DiscardConfirmationClosure { get; set; }

		// @property (nonatomic) BOOL useParentNavigationItem;
		[Export("useParentNavigationItem")]
		bool UseParentNavigationItem { get; set; }
	}

	// @interface PESDKCameraViewControllerOptions : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKCameraViewControllerOptions
	{
		// @property (readonly, nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) cancelButtonConfigurationClosure;
		[NullAllowed, Export("cancelButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> CancelButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) flashButtonConfigurationClosure;
		[NullAllowed, Export("flashButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> FlashButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) switchCameraButtonConfigurationClosure;
		[NullAllowed, Export("switchCameraButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> SwitchCameraButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) cameraRollButtonConfigurationClosure;
		[NullAllowed, Export("cameraRollButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> CameraRollButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) photoActionButtonConfigurationClosure;
		[NullAllowed, Export("photoActionButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> PhotoActionButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull) filterSelectorButtonConfigurationClosure;
		[NullAllowed, Export("filterSelectorButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton> FilterSelectorButtonConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(UILabel * _Nonnull) timeLabelConfigurationClosure;
		[NullAllowed, Export("timeLabelConfigurationClosure", ArgumentSemantic.Copy)]
		Action<UILabel> TimeLabelConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKSlider * _Nonnull) filterIntensitySliderConfigurationClosure;
		[NullAllowed, Export("filterIntensitySliderConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKSlider> FilterIntensitySliderConfigurationClosure { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(PESDKButton * _Nonnull, enum RecordingMode) recordingModeButtonConfigurationClosure;
		[NullAllowed, Export("recordingModeButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKButton, RecordingMode> RecordingModeButtonConfigurationClosure { get; }

		// @property (readonly, nonatomic) BOOL cropToSquare;
		[Export("cropToSquare")]
		bool CropToSquare { get; }

		// @property (readonly, nonatomic) NSInteger maximumVideoLength;
		[Export("maximumVideoLength")]
		nint MaximumVideoLength { get; }

		// @property (readonly, nonatomic) BOOL tapToFocusEnabled;
		[Export("tapToFocusEnabled")]
		bool TapToFocusEnabled { get; }

		// @property (readonly, nonatomic) BOOL showCancelButton;
		[Export("showCancelButton")]
		bool ShowCancelButton { get; }

		// @property (readonly, nonatomic) BOOL showCameraRoll;
		[Export("showCameraRoll")]
		bool ShowCameraRoll { get; }

		// @property (readonly, nonatomic) BOOL showFilters;
		[Export("showFilters")]
		bool ShowFilters { get; }

		// @property (readonly, nonatomic) BOOL showFilterIntensitySlider;
		[Export("showFilterIntensitySlider")]
		bool ShowFilterIntensitySlider { get; }

		// @property (readonly, nonatomic) CGFloat initialFilterIntensity;
		[Export("initialFilterIntensity")]
		nfloat InitialFilterIntensity { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable videoOutputSettings;
		[NullAllowed, Export("videoOutputSettings", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> VideoOutputSettings { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable audioOutputSettings;
		[NullAllowed, Export("audioOutputSettings", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AudioOutputSettings { get; }

		// @property (readonly, nonatomic) AVFileType _Nonnull videoRecordingFileType;
		[Export("videoRecordingFileType")]
		string VideoRecordingFileType { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull videoRecordingFileExtension;
		[Export("videoRecordingFileExtension")]
		string VideoRecordingFileExtension { get; }

		// @property (readonly, copy, nonatomic) void (^ _Nullable)(AVAssetWriter * _Nonnull) assetWriterConfigurationClosure;
		[NullAllowed, Export("assetWriterConfigurationClosure", ArgumentSemantic.Copy)]
		Action<AVAssetWriter> AssetWriterConfigurationClosure { get; }

		// @property (readonly, nonatomic) BOOL includeUserLocation;
		[Export("includeUserLocation")]
		bool IncludeUserLocation { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKCameraViewControllerOptions New();
	}

	// @interface PESDKConfigurationBuilder : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKConfigurationBuilder
	{
		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull menuBackgroundColor;
		[Export("menuBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MenuBackgroundColor { get; set; }

		// -(void)configureCameraViewController:(void (^ _Nonnull)(PESDKCameraViewControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureCameraViewController:")]
		void ConfigureCameraViewController(Action<PESDKCameraViewControllerOptionsBuilder> builder);

		// -(void)configurePhotoEditorViewController:(void (^ _Nonnull)(PESDKPhotoEditViewControllerOptionsBuilder * _Nonnull))builder;
		[Export("configurePhotoEditorViewController:")]
		void ConfigurePhotoEditorViewController(Action<PESDKPhotoEditViewControllerOptionsBuilder> builder);

		// -(void)configureFilterToolController:(void (^ _Nonnull)(PESDKFilterToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureFilterToolController:")]
		void ConfigureFilterToolController(Action<PESDKFilterToolControllerOptionsBuilder> builder);

		// -(void)configureOverlayToolController:(void (^ _Nonnull)(PESDKOverlayToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureOverlayToolController:")]
		void ConfigureOverlayToolController(Action<PESDKOverlayToolControllerOptionsBuilder> builder);

		// -(void)configureStickerToolController:(void (^ _Nonnull)(PESDKStickerToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureStickerToolController:")]
		void ConfigureStickerToolController(Action<PESDKStickerToolControllerOptionsBuilder> builder);

		// -(void)configureStickerOptionsToolController:(void (^ _Nonnull)(PESDKStickerOptionsToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureStickerOptionsToolController:")]
		void ConfigureStickerOptionsToolController(Action<PESDKStickerOptionsToolControllerOptionsBuilder> builder);

		// -(void)configureStickerColorToolController:(void (^ _Nonnull)(PESDKColorToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureStickerColorToolController:")]
		void ConfigureStickerColorToolController(Action<PESDKColorToolControllerOptionsBuilder> builder);

		// -(void)configureFocusToolController:(void (^ _Nonnull)(PESDKFocusToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureFocusToolController:")]
		void ConfigureFocusToolController(Action<PESDKFocusToolControllerOptionsBuilder> builder);

		// -(void)transformToolControllerOptions:(void (^ _Nonnull)(PESDKTransformToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("transformToolControllerOptions:")]
		void TransformToolControllerOptions(Action<PESDKTransformToolControllerOptionsBuilder> builder);

		// -(void)configureTextToolController:(void (^ _Nonnull)(PESDKTextToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTextToolController:")]
		void ConfigureTextToolController(Action<PESDKTextToolControllerOptionsBuilder> builder);

		// -(void)configureTextOptionsToolController:(void (^ _Nonnull)(PESDKTextOptionsToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTextOptionsToolController:")]
		void ConfigureTextOptionsToolController(Action<PESDKTextOptionsToolControllerOptionsBuilder> builder);

		// -(void)configureTextFontToolController:(void (^ _Nonnull)(PESDKTextFontToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTextFontToolController:")]
		void ConfigureTextFontToolController(Action<PESDKTextFontToolControllerOptionsBuilder> builder);

		// -(void)configureTextColorToolController:(void (^ _Nonnull)(PESDKTextColorToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTextColorToolController:")]
		void ConfigureTextColorToolController(Action<PESDKTextColorToolControllerOptionsBuilder> builder);

		// -(void)configureAdjustToolController:(void (^ _Nonnull)(PESDKAdjustToolControllerOptionsBuilder * _Nonnull))builder __attribute__((availability(ios, introduced=9.0)));
		[iOS(9, 0)]
		[Export("configureAdjustToolController:")]
		void ConfigureAdjustToolController(Action<PESDKAdjustToolControllerOptionsBuilder> builder);

		// -(void)configureBrushToolController:(void (^ _Nonnull)(PESDKBrushToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureBrushToolController:")]
		void ConfigureBrushToolController(Action<PESDKBrushToolControllerOptionsBuilder> builder);

		// -(void)configureBrushColorToolController:(void (^ _Nonnull)(PESDKBrushColorToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureBrushColorToolController:")]
		void ConfigureBrushColorToolController(Action<PESDKBrushColorToolControllerOptionsBuilder> builder);

		// -(void)configureTransformToolController:(void (^ _Nonnull)(PESDKTransformToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTransformToolController:")]
		void ConfigureTransformToolController(Action<PESDKTransformToolControllerOptionsBuilder> builder);

		// -(void)configureFrameToolController:(void (^ _Nonnull)(PESDKFrameToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureFrameToolController:")]
		void ConfigureFrameToolController(Action<PESDKFrameToolControllerOptionsBuilder> builder);

		// -(void)configureTextDesignToolController:(void (^ _Nonnull)(PESDKTextDesignToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTextDesignToolController:")]
		void ConfigureTextDesignToolController(Action<PESDKTextDesignToolControllerOptionsBuilder> builder);

		// -(void)configureTextDesignOptionsToolController:(void (^ _Nonnull)(PESDKTextDesignOptionsToolControllerOptionsBuilder * _Nonnull))builder;
		[Export("configureTextDesignOptionsToolController:")]
		void ConfigureTextDesignOptionsToolController(Action<PESDKTextDesignOptionsToolControllerOptionsBuilder> builder);
	}

	// @interface PESDKPhoto : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKPhoto
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, copy, nonatomic) NSData * _Nullable data;
		[NullAllowed, Export("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		// @property (readonly, nonatomic, strong) UIImage * _Nullable image;
		[NullAllowed, Export("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		// @property (readonly, nonatomic) CGSize size;
		[Export("size")]
		CGSize Size { get; }

		// -(instancetype _Nonnull)initWithUrl:(NSURL * _Nonnull)url __attribute__((objc_designated_initializer));
		[Export("initWithUrl:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSUrl url);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data __attribute__((objc_designated_initializer));
		[Export("initWithData:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSData data);

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export("initWithImage:")]
		[DesignatedInitializer]
		IntPtr Constructor(UIImage image);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKPhoto New();
	}

	// @interface PESDKPhotoEditMenuItem : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKPhotoEditMenuItem
	{
		// @property (readonly, nonatomic, strong) PESDKToolMenuItem * _Nullable toolMenuItem;
		[NullAllowed, Export("toolMenuItem", ArgumentSemantic.Strong)]
		PESDKToolMenuItem ToolMenuItem { get; }

		// @property (readonly, nonatomic, strong) PESDKActionMenuItem * _Nullable actionMenuItem;
		[NullAllowed, Export("actionMenuItem", ArgumentSemantic.Strong)]
		PESDKActionMenuItem ActionMenuItem { get; }

		// @property (readonly, copy, nonatomic, class) NSArray<PESDKPhotoEditMenuItem *> * _Nonnull defaultItems;
		[Static]
		[Export("defaultItems", ArgumentSemantic.Copy)]
		PESDKPhotoEditMenuItem[] DefaultItems { get; }

		// -(instancetype _Nullable)initWithToolMenuItem:(PESDKToolMenuItem * _Nullable)toolMenuItem __attribute__((objc_designated_initializer));
		[Export("initWithToolMenuItem:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] PESDKToolMenuItem toolMenuItem);

		// -(instancetype _Nullable)initWithActionMenuItem:(PESDKActionMenuItem * _Nullable)actionMenuItem __attribute__((objc_designated_initializer));
		[Export("initWithActionMenuItem:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] PESDKActionMenuItem actionMenuItem);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKPhotoEditMenuItem New();
	}

	// @interface PESDKActionMenuItem : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKActionMenuItem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export("title")]
		string Title { get; }

		// @property (readonly, nonatomic, strong) UIImage * _Nonnull icon;
		[Export("icon", ArgumentSemantic.Strong)]
		UIImage Icon { get; }

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKActionMenuItem New();
	}

	// @interface PESDKToolMenuItem : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKToolMenuItem
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull title;
		[Export("title")]
		string Title { get; }

		// @property (readonly, nonatomic, strong) UIImage * _Nonnull icon;
		[Export("icon", ArgumentSemantic.Strong)]
		UIImage Icon { get; }

		// @property (readonly, nonatomic) Class _Nonnull toolControllerClass;
		[Export("toolControllerClass")]
		Class ToolControllerClass { get; }

		// -(instancetype _Nonnull)initWithTitle:(NSString * _Nonnull)title icon:(UIImage * _Nonnull)icon toolControllerClass:(Class _Nonnull)toolControllerClass __attribute__((objc_designated_initializer));
		[Export("initWithTitle:icon:toolControllerClass:")]
		[DesignatedInitializer]
		IntPtr Constructor(string title, UIImage icon, Class toolControllerClass);

		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKToolMenuItem New();
	}

	// @interface PESDKPhotoEditModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKPhotoEditModel
	{
		// -(instancetype _Nullable)initWithDeserializedFrom:(NSData * _Nonnull)data toImage:(UIImage * _Nullable)image __attribute__((deprecated("Use `init?(serializedData:referenceSize:)` instead."))) __attribute__((objc_designated_initializer));
		[Export("initWithDeserializedFrom:toImage:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSData data, [NullAllowed] UIImage image);

		// -(instancetype _Nullable)initWithSerializedData:(NSData * _Nonnull)data referenceSize:(CGSize)referenceSize __attribute__((objc_designated_initializer));
		[Export("initWithSerializedData:referenceSize:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSData data, CGSize referenceSize);

		// @property (nonatomic, strong) PESDKAdjustmentModel * _Nonnull adjustmentModel;
		[Export("adjustmentModel", ArgumentSemantic.Strong)]
		PESDKAdjustmentModel AdjustmentModel { get; set; }

		// @property (nonatomic, strong) PESDKEffectFilterModel * _Nonnull effectFilterModel;
		[Export("effectFilterModel", ArgumentSemantic.Strong)]
		PESDKEffectFilterModel EffectFilterModel { get; set; }

		// @property (nonatomic, strong) PESDKFocusModel * _Nonnull focusModel;
		[Export("focusModel", ArgumentSemantic.Strong)]
		PESDKFocusModel FocusModel { get; set; }

		// @property (nonatomic, strong) PESDKOverlayModel * _Nonnull overlayModel;
		[Export("overlayModel", ArgumentSemantic.Strong)]
		PESDKOverlayModel OverlayModel { get; set; }

		// @property (copy, nonatomic) NSArray<PESDKSpriteModel *> * _Nonnull spriteModels;
		[Export("spriteModels", ArgumentSemantic.Copy)]
		PESDKSpriteModel[] SpriteModels { get; set; }

		// @property (nonatomic, strong) PESDKTransformModel * _Nonnull transformModel;
		[Export("transformModel", ArgumentSemantic.Strong)]
		PESDKTransformModel TransformModel { get; set; }

		// @property (nonatomic) BOOL isAutoEnhancementEnabled;
		[Export("isAutoEnhancementEnabled")]
		bool IsAutoEnhancementEnabled { get; set; }
	}

	// @interface PESDKTransformModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKTransformModel
	{
		// -(instancetype _Nonnull)initWithAppliedOrientation:(enum PESDKOrientation)appliedOrientation normalizedCropRect:(CGRect)normalizedCropRect straightenAngle:(double)straightenAngle imageInsets:(UIEdgeInsets)imageInsets __attribute__((objc_designated_initializer));
		[Export("initWithAppliedOrientation:normalizedCropRect:straightenAngle:imageInsets:")]
		[DesignatedInitializer]
		IntPtr Constructor(PESDKOrientation appliedOrientation, CGRect normalizedCropRect, double straightenAngle, UIEdgeInsets imageInsets);

		// @property (nonatomic) enum PESDKOrientation appliedOrientation;
		[Export("appliedOrientation", ArgumentSemantic.Assign)]
		PESDKOrientation AppliedOrientation { get; set; }

		// @property (nonatomic) CGRect normalizedCropRect;
		[Export("normalizedCropRect", ArgumentSemantic.Assign)]
		CGRect NormalizedCropRect { get; set; }

		// @property (nonatomic) double straightenAngle;
		[Export("straightenAngle")]
		double StraightenAngle { get; set; }

		// @property (nonatomic) UIEdgeInsets imageInsets;
		[Export("imageInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets ImageInsets { get; set; }

		// @property (readonly, nonatomic) double adjustedStraightenAngle;
		[Export("adjustedStraightenAngle")]
		double AdjustedStraightenAngle { get; }

		// @property (readonly, nonatomic) BOOL isGeometryIdentity;
		[Export("isGeometryIdentity")]
		bool IsGeometryIdentity { get; }

		// @property (readonly, nonatomic, class) enum PESDKOrientation identityOrientation;
		[Static]
		[Export("identityOrientation")]
		PESDKOrientation IdentityOrientation { get; }

		// @property (readonly, nonatomic, class) CGRect identityNormalizedCropRect;
		[Static]
		[Export("identityNormalizedCropRect")]
		CGRect IdentityNormalizedCropRect { get; }
	}

	// @interface PESDKSpriteModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface PESDKSpriteModel
	{
		// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
		[Static]
		[Export("new")]
		PESDKSpriteModel New();
	}

	// @interface PESDKOverlayModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKOverlayModel
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier blendMode:(enum PESDKBlendMode)blendMode intensity:(double)intensity __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:blendMode:intensity:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, PESDKBlendMode blendMode, double intensity);

		// @property (copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; set; }

		// @property (nonatomic) enum PESDKBlendMode blendMode;
		[Export("blendMode", ArgumentSemantic.Assign)]
		PESDKBlendMode BlendMode { get; set; }

		// @property (nonatomic) double intensity;
		[Export("intensity")]
		double Intensity { get; set; }
	}

	// @interface PESDKFocusModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKFocusModel
	{
		// -(instancetype _Nonnull)initWithNormalizedControlPoint1:(CGPoint)normalizedControlPoint1 normalizedControlPoint2:(CGPoint)normalizedControlPoint2 normalizedBlurRadius:(double)normalizedBlurRadius normalizedFadeWidth:(double)normalizedFadeWidth type:(enum PESDKFocusType)type blurQuality:(enum BlurQuality)blurQuality __attribute__((deprecated("Use `init(normalizedControlPoint1:normalizedControlPoint2:normalizedBlurRadius:normalizedFadeWidth:mode:blurQuality:)` instead."))) __attribute__((objc_designated_initializer));
		[Export("initWithNormalizedControlPoint1:normalizedControlPoint2:normalizedBlurRadius:normalizedFadeWidth:type:blurQuality:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGPoint normalizedControlPoint1, CGPoint normalizedControlPoint2, double normalizedBlurRadius, double normalizedFadeWidth, PESDKFocusType type, BlurQuality blurQuality);

		// -(instancetype _Nonnull)initWithNormalizedControlPoint1:(CGPoint)normalizedControlPoint1 normalizedControlPoint2:(CGPoint)normalizedControlPoint2 normalizedBlurRadius:(double)normalizedBlurRadius normalizedFadeWidth:(double)normalizedFadeWidth mode:(enum PESDKFocusMode)mode blurQuality:(enum BlurQuality)blurQuality __attribute__((objc_designated_initializer));
		[Export("initWithNormalizedControlPoint1:normalizedControlPoint2:normalizedBlurRadius:normalizedFadeWidth:mode:blurQuality:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGPoint normalizedControlPoint1, CGPoint normalizedControlPoint2, double normalizedBlurRadius, double normalizedFadeWidth, PESDKFocusMode mode, BlurQuality blurQuality);

		// @property (nonatomic) CGPoint normalizedControlPoint1;
		[Export("normalizedControlPoint1", ArgumentSemantic.Assign)]
		CGPoint NormalizedControlPoint1 { get; set; }

		// @property (nonatomic) CGPoint normalizedControlPoint2;
		[Export("normalizedControlPoint2", ArgumentSemantic.Assign)]
		CGPoint NormalizedControlPoint2 { get; set; }

		// @property (nonatomic) double normalizedBlurRadius;
		[Export("normalizedBlurRadius")]
		double NormalizedBlurRadius { get; set; }

		// @property (nonatomic) double normalizedFadeWidth;
		[Export("normalizedFadeWidth")]
		double NormalizedFadeWidth { get; set; }

		// @property (nonatomic) enum PESDKFocusType type __attribute__((deprecated("Use `mode` instead.")));
		[Export("type", ArgumentSemantic.Assign)]
		PESDKFocusType Type { get; set; }

		// @property (nonatomic) enum PESDKFocusMode mode;
		[Export("mode", ArgumentSemantic.Assign)]
		PESDKFocusMode Mode { get; set; }

		// @property (nonatomic) enum BlurQuality blurQuality;
		[Export("blurQuality", ArgumentSemantic.Assign)]
		BlurQuality BlurQuality { get; set; }
	}

	// @interface PESDKEffectFilterModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKEffectFilterModel
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier intensity:(double)intensity __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:intensity:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier, double intensity);

		// @property (copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; set; }

		// @property (nonatomic) double intensity;
		[Export("intensity")]
		double Intensity { get; set; }
	}

	// @interface PESDKAdjustmentModel : NSObject
	[iOS(9, 0)]
	[BaseType(typeof(NSObject))]
	interface PESDKAdjustmentModel
	{
		// -(instancetype _Nonnull)initWithBrightness:(double)brightness contrast:(double)contrast shadows:(double)shadows highlights:(double)highlights exposure:(double)exposure clarity:(double)clarity saturation:(double)saturation gamma:(double)gamma blacks:(double)blacks whites:(double)whites temperature:(double)temperature __attribute__((objc_designated_initializer));
		[Export("initWithBrightness:contrast:shadows:highlights:exposure:clarity:saturation:gamma:blacks:whites:temperature:")]
		[DesignatedInitializer]
		IntPtr Constructor(double brightness, double contrast, double shadows, double highlights, double exposure, double clarity, double saturation, double gamma, double blacks, double whites, double temperature);

		// @property (nonatomic) double brightness;
		[Export("brightness")]
		double Brightness { get; set; }

		// @property (nonatomic) double contrast;
		[Export("contrast")]
		double Contrast { get; set; }

		// @property (nonatomic) double shadows;
		[Export("shadows")]
		double Shadows { get; set; }

		// @property (nonatomic) double highlights;
		[Export("highlights")]
		double Highlights { get; set; }

		// @property (nonatomic) double exposure;
		[Export("exposure")]
		double Exposure { get; set; }

		// @property (nonatomic) double clarity;
		[Export("clarity")]
		double Clarity { get; set; }

		// @property (nonatomic) double saturation;
		[Export("saturation")]
		double Saturation { get; set; }

		// @property (nonatomic) double gamma;
		[Export("gamma")]
		double Gamma { get; set; }

		// @property (nonatomic) double blacks;
		[Export("blacks")]
		double Blacks { get; set; }

		// @property (nonatomic) double whites;
		[Export("whites")]
		double Whites { get; set; }

		// @property (nonatomic) double temperature;
		[Export("temperature")]
		double Temperature { get; set; }
	}

	// @interface PESDKStickerToolControllerOptionsBuilder : PESDKToolControllerOptionsBuilder
	[iOS(9, 0)]
	[BaseType(typeof(PESDKToolControllerOptionsBuilder))]
	interface PESDKStickerToolControllerOptionsBuilder
	{
		// @property (copy, nonatomic) void (^ _Nullable)(PESDKSticker * _Nonnull) addedStickerClosure;
		[NullAllowed, Export("addedStickerClosure", ArgumentSemantic.Copy)]
		Action<PESDKSticker> AddedStickerClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKIconBorderedCollectionViewCell * _Nonnull, PESDKStickerCategory * _Nonnull) stickerCategoryButtonConfigurationClosure;
		[NullAllowed, Export("stickerCategoryButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconBorderedCollectionViewCell, PESDKStickerCategory> StickerCategoryButtonConfigurationClosure { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(PESDKIconCollectionViewCell * _Nonnull, PESDKSticker * _Nonnull) stickerButtonConfigurationClosure;
		[NullAllowed, Export("stickerButtonConfigurationClosure", ArgumentSemantic.Copy)]
		Action<PESDKIconCollectionViewCell, PESDKSticker> StickerButtonConfigurationClosure { get; set; }

		// @property (nonatomic) CGSize stickerPreviewSize;
		[Export("stickerPreviewSize", ArgumentSemantic.Assign)]
		CGSize StickerPreviewSize { get; set; }

		// @property (nonatomic) NSInteger defaultStickerCategoryIndex;
		[Export("defaultStickerCategoryIndex")]
		int DefaultStickerCategoryIndex { get; set; }
	}
}
