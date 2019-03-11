using System;
using UIKit;
using PhotoEditor.iOS;
using Foundation;
using System.Threading.Tasks;
using System.Threading;

namespace XamarinPhotoEditoriOS
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		private async Task EditPhoto(CancellationToken ct)
		{
			var task = new TaskCompletionSource<NSData>();
			var photo = new PESDKPhoto(new NSUrl("https://images.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg?auto=compress&cs=tinysrgb&h=350"));
			var viewController = new PESDKPhotoEditViewController(photo, new PESDKConfiguration())
			{
				Delegate = new EditViewControllerDelegate(task)
			};

			using (ct.Register(() =>
			{
				task?.TrySetResult(null);
				viewController.DismissViewController(true, null);
			}))
			{
				PresentViewController(viewController, true, null);

				var test = await task.Task;
			}
		}

		partial void UIButton1770_TouchUpInside(UIButton sender)
		{
			EditPhoto(new CancellationToken(false));
		}

		private  class EditViewControllerDelegate : PESDKPhotoEditViewControllerDelegate
		{
			private readonly TaskCompletionSource<NSData> _taskCompletionSource;

			public EditViewControllerDelegate(TaskCompletionSource<NSData> taskCompletionSource)
			{
				_taskCompletionSource = taskCompletionSource;
			}
			public override void PhotoEditViewController(PESDKPhotoEditViewController photoEditViewController, global::UIKit.UIImage image, NSData data)
			{
				_taskCompletionSource?.TrySetResult(data);
				photoEditViewController.DismissViewController(true, null);
			}

			public override void PhotoEditViewControllerDidCancel(PESDKPhotoEditViewController photoEditViewController)
			{
				_taskCompletionSource?.TrySetResult(null);
				photoEditViewController.DismissViewController(true, null);
			}

			public override void PhotoEditViewControllerDidFailToGeneratePhoto(PESDKPhotoEditViewController photoEditViewController)
			{
				_taskCompletionSource?.TrySetResult(null);
				photoEditViewController.DismissViewController(true, null);
			}
		}
	}
}
