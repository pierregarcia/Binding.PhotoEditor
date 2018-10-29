using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Views;
using LY.Img.Android.Pesdk..Sdk.Models.State.Manager;
using LY.Img.Android.UI.Activities;
using LY.Img.Android.Sdk.Models.State;
using System;
using LY.Img.Android.Sdk.Models.Constant;
using LY.Img.Android;

namespace PhotoEditor.Uno.Samples.Droid
{
	[Activity(
			MainLauncher = true,
			ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
			WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
		)]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			//PESDK.Init(this, "android_license");

			SettingsList settingsList = new SettingsList();

			((EditorSaveSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorSaveSettings)))).SetExportDir(Directory.Dcim, "SomeFolderName").SetExportPrefix("sad").SetSavePolicy(EditorSaveSettings.SavePolicy.ReturnAlwaysOnlyOutput);

			((EditorLoadSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorLoadSettings)))).SetImageSource(Android.Net.Uri.Parse("https://images.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg?auto=compress&cs=tinysrgb&h=350"));

			new PhotoEditorBuilder(this)
				.SetSettingsList(settingsList)
				.StartActivityForResult(this, 1);
		}

	}
}

