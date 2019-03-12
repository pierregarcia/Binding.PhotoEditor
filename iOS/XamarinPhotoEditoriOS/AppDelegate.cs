using Foundation;
using PhotoEditor.iOS;
using UIKit;

namespace XamarinPhotoEditoriOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var url = NSBundle.MainBundle.GetUrlForResource("ios_pesdk_license_prod", "");
            PESDK.UnlockWithLicenseAt(url);

            return true;
        }
    }
}