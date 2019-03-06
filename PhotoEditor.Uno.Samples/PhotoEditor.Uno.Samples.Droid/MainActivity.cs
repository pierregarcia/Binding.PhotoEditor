using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Views;
using System;
using LY.Img.Android.Pesdk.All;
using LY.Img.Android.Pesdk.Backend.Model.State.Manager;
using LY.Img.Android.Pesdk.Backend.Model.State;
using LY.Img.Android.Pesdk.Backend.Model.Constant;
using LY.Img.Android.Pesdk.UI.Activity;
using Android.Content;
using LY.Img.Android.Pesdk.UI.Model.State;
using LY.Img.Android.Pesdk.UI.Panels.Item;
using LY.Img.Android.Pesdk.Assets.Sticker.Emoticons;
using LY.Img.Android.Pesdk.Assets.Sticker.Shapes;
using LY.Img.Android.Pesdk.Assets.Filter.Basic;
using LY.Img.Android.Pesdk.Assets.Font.Basic;
using LY.Img.Android.Pesdk.Assets.Frame.Basic;
using System.Collections.Generic;
using LY.Img.Android.Pesdk.Assets.Overlay.Basic;
using LY.Img.Android.Pesdk.UI.Panels;
using LY.Img.Android.Pesdk.Backend.Decoder;

namespace PhotoEditor.Uno.Samples.Droid
{
	[Activity(
			MainLauncher = true,
			ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
			WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
		)]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
		private static int EDITOR_ACTIVITY_RESULT = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SettingsList settingsList = new SettingsList();

			settingsList.GetModel<EditorSaveSettings>()
				.SetExportDir(Directory.Dcim, "SomeFolderName")
				.SetExportPrefix("sad")
				.SetSavePolicy(EditorSaveSettings.SavePolicy.ReturnAlwaysOnlyOutput);

			settingsList.GetModel<EditorLoadSettings>()
				.SetImageSource(Android.Net.Uri.Parse("https://images.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg?auto=compress&cs=tinysrgb&h=350"));

			settingsList.GetModel<UiConfigMainMenu>()
				.SetToolList(new[]
				{
						new ToolItem(TransformToolPanel.ToolId, Resource.String.pesdk_transform_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_transform)),
						new ToolItem(FilterToolPanel.ToolId, Resource.String.pesdk_filter_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_filters)),
						new ToolItem(AdjustmentToolPanel.ToolId, Resource.String.pesdk_adjustments_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_adjust)),
						new ToolItem(StickerToolPanel.ToolId, Resource.String.pesdk_sticker_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_sticker)),
						new ToolItem(TextToolPanel.ToolId, Resource.String.pesdk_text_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_text)),
						new ToolItem(TextDesignToolPanel.ToolId, Resource.String.pesdk_textDesign_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_text_design)),
						new ToolItem(OverlayToolPanel.ToolId, Resource.String.pesdk_overlay_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_overlay)),
						new ToolItem(FrameToolPanel.ToolId, Resource.String.pesdk_frame_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_frame)),
						new ToolItem(BrushToolPanel.ToolId, Resource.String.pesdk_brush_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_brush)),
						new ToolItem(FocusToolPanel.ToolId, Resource.String.pesdk_focus_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_focus)),
				});

			settingsList.GetModel<UiConfigSticker>()
				.SetStickerLists(new[]
				{
					StickerPackEmoticons.StickerCategory,
					StickerPackShapes.StickerCategory,
				});

			var fonts = new List<FontItem>();
			for (int i = 0; i < FontPackBasic.FontPack.Size(); i++)
			{
				fonts.Add(FontPackBasic.FontPack.Get(i) as FontItem);
			}
			settingsList.GetModel<UiConfigText>().SetFontList(fonts);

			var filters = new List<FilterItem>();
			for (int i = 0; i < FilterPackBasic.FilterPack.Size(); i++)
			{
				filters.Add(FilterPackBasic.FilterPack.Get(i) as FilterItem);
			}
			settingsList.GetModel<UiConfigFilter>().SetFilterList(filters);

			var frames = new List<FrameItem>();
			for (int i = 0; i < FramePackBasic.FramePack.Size(); i++)
			{
				frames.Add(FramePackBasic.FramePack.Get(i) as FrameItem);
			}
			settingsList.GetModel<UiConfigFrame>().SetFrameList(frames);

			var overlays = new List<OverlayItem>();
			for (int i = 0; i < OverlayPackBasic.OverlayPack.Size(); i++)
			{
				overlays.Add(OverlayPackBasic.OverlayPack.Get(i) as OverlayItem);
			}
			settingsList.GetModel<UiConfigOverlay>().SetOverlayList(overlays);

			new PhotoEditorBuilder(this)
							.SetSettingsList(settingsList)
							.StartActivityForResult(this, EDITOR_ACTIVITY_RESULT);
		}
	}
}

