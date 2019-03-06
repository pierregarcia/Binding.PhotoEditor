using LY.Img.Android.Pesdk.Backend.Model.State.Manager;

namespace LY.Img.Android.Pesdk.All
{
	public static class PhotoEditorAndroidExtensions
	{

		public static T GetModel<T>(this SettingsList settingsList) where T:Java.Lang.Object
		{
			return ((T)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(T))));
		}
	}
}