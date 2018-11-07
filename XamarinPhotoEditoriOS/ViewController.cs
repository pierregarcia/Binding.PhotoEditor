using System;
using UIKit;
using PhotoEditor;

namespace XamarinPhotoEditoriOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            Console.WriteLine("");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.

        }

        private void DisplayCameraController()
        {

            //var cameraController = new PhotoEditor.
        }
    }
}
