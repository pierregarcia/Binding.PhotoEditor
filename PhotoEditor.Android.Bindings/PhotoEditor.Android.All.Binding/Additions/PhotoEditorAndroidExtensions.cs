using System.Collections.Generic;
using LY.Img.Android.Pesdk.Backend.Model.State.Manager;
using LY.Img.Android.Pesdk.UI.Utils;
using LY.Img.Android.Pesdk.UI.Panels.Item;

namespace LY.Img.Android.Pesdk.All
{
	public static class PhotoEditorAndroidExtensions
	{
		public static T GetModel<T>(this SettingsList settingsList) where T:Java.Lang.Object
		{
			return ((T)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(T))));
		}

		public static List<T> ToList<T>(this DataSourceIdItemList list) where T : AbstractItem
		{
			var typedList = new List<T>();
			for (int i = 0; i < list.Size(); i++)
			{
				typedList.Add((T)list.Get(i));
			}
			return typedList;
		}
	}
}