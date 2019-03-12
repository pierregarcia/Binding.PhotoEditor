using System;
using UIKit;
using PhotoEditor.iOS;

namespace XamarinPhotoEditoriOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        private void DisplayCameraController()
        {
            var cameraController = new PESDKCameraViewController();
            PresentViewController(cameraController, true, null);
        }

        partial void UIButton1770_TouchUpInside(UIButton sender)
        {
            DisplayCameraController();
        }
    }
}
