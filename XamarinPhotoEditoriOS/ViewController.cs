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

		private void ConfigureStickers()
		{
			var catStickersImages = new[] { "meeeo", "purrfect", "cattitud", "cattastic", "bubble_fish", "ball_of_yarn", "snap_cat_v1a", "snap_cat_v1c" };
			var dogStickersImages = new[] { "puppy_love", "woof", "the_bark_side", "going_mutts", "i_woof_you", "lifes_ruff", "looking_good_gone_good", "bubble_bone", "bone" };
			var costumeStickersImages = new[] { "bowtie", "sun_glasses", "hat1", "hat2", "mustache", "beard", "glasses", "stars", "ball", "pawesome", "so_fuffly", "harts", "feeling_good", "just_chill", "love", "four_legs_love", "VCA_Logo", "VCA_Canada_Logo" };

			var catStickerCategory = CreateStickerCategory("Cat", catStickersImages);
			var dogStickerCategory = CreateStickerCategory("Dog", dogStickersImages);
			var costumeStickerCategory = CreateStickerCategory("Costume", costumeStickersImages);

			PESDKStickerCategory.All = new[] { catStickerCategory, dogStickerCategory, costumeStickerCategory };
		}

		private PESDKStickerCategory CreateStickerCategory(string title, string[] stickerImages)
		{
			var stickers = stickerImages.Select(i =>
			{
				var stickerImageUrl = NSBundle.MainBundle.GetUrlForResource(i, "png");
				var identifier = $"vca_messenger_{Guid.NewGuid()}_i";
				return new PESDKSticker(stickerImageUrl, null, identifier);
			}).ToArray();

			var categoryImageUrl = NSBundle.MainBundle.GetUrlForResource(stickerImages.First(), "png");

			return new PESDKStickerCategory(title, categoryImageUrl, stickers);
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
