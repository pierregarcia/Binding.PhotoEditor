using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using LY.Img.Android;
using LY.Img.Android.Pesdk.Backend.Model.State.Manager;
using LY.Img.Android.Pesdk.Backend.Model.State;
using LY.Img.Android.Pesdk.Backend.Model.Constant;
using LY.Img.Android.Pesdk.UI.Activity;
using Android.Content;

namespace Testing
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
	{
		private static int EDITOR_ACTIVITY_RESULT = 1;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

			FindViewById<Button>(Resource.Id.myButton).Click += MainActivity_Click;

			//StartActivity(typeof(Com.Photoeditorsdk.Android.App.MainActivity));
		}

		private void MainActivity_Click(object sender, EventArgs e)
		{
			SettingsList settingsList = new SettingsList();

			((EditorSaveSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorSaveSettings)))).SetExportDir(Directory.Dcim, "SomeFolderName").SetExportPrefix("sad").SetSavePolicy(EditorSaveSettings.SavePolicy.ReturnAlwaysOnlyOutput);

			((EditorLoadSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorLoadSettings)))).SetImageSource(Android.Net.Uri.Parse("https://images.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg?auto=compress&cs=tinysrgb&h=350"));

			((EditorLoadSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorLoadSettings)))).SetImageSource(Android.Net.Uri.Parse("https://images.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg?auto=compress&cs=tinysrgb&h=350"));

			new PhotoEditorBuilder(this)
				.SetSettingsList(settingsList)
				.StartActivityForResult(this, EDITOR_ACTIVITY_RESULT);
		}

		protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Ok && requestCode == EDITOR_ACTIVITY_RESULT)
			{

				var resultPath = data.GetParcelableExtra(ImgLyIntent.ResultImageUri) as Android.Net.Uri;
				var sourcePath = data.GetParcelableExtra(ImgLyIntent.SourceImageUri) as Android.Net.Uri;

				if (resultPath != null)
				{
					// Add result file to Gallery

					SendBroadcast(new Intent(Intent.ActionMediaScannerScanFile, resultPath));
				}

				if (sourcePath != null)
				{
					// Add sourceType file to Gallery
					SendBroadcast(new Intent(Intent.ActionMediaScannerScanFile, sourcePath));
				}

				Toast.MakeText(this, "Image saved on: " + resultPath, ToastLength.Long).Show();
			}
			else if (resultCode == Result.Canceled && requestCode == EDITOR_ACTIVITY_RESULT && data != null)
			{
				var sourcePath = data.GetParcelableExtra(ImgLyIntent.SourceImageUri);
				Toast.MakeText(this, "Editor canceled, sourceType image is:\n" + sourcePath, ToastLength.Long).Show();
			}
		}
	}
}

