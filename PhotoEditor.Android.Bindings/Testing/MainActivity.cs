using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using LY.Img.Android.Pesdk.All;
using LY.Img.Android.Pesdk.Backend.Model.State.Manager;
using LY.Img.Android.Pesdk.Backend.Model.State;
using LY.Img.Android.Pesdk.Backend.Model.Config;
using LY.Img.Android.Pesdk.Backend.Model.Constant;
using LY.Img.Android.Pesdk.UI.Activity;
using LY.Img.Android.Pesdk.UI.Model.State;
using LY.Img.Android.Pesdk.UI.Panels.Item;
using LY.Img.Android.Pesdk.Assets.Filter.Basic;
using LY.Img.Android.Pesdk.Assets.Font.Basic;
using LY.Img.Android.Pesdk.Assets.Frame.Basic;
using System.Collections.Generic;
using LY.Img.Android.Pesdk.Assets.Overlay.Basic;
using LY.Img.Android.Pesdk.UI.Panels;
using LY.Img.Android.Pesdk.Backend.Decoder;
using System.Linq;

namespace Testing
{
    [Activity(Label = "Img Nventive", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
	{
		private const string DrawableDefType = "drawable";
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

			ConfigureStickers(settingsList);

			settingsList.GetModel<UiConfigText>()
				.SetFontList(FontPackBasic.FontPack.ToList<FontItem>());

			settingsList.GetModel<UiConfigFilter>()
				.SetFilterList(FilterPackBasic.FilterPack.ToList<FilterItem>());

			settingsList.GetModel<UiConfigFrame>()
				.SetFrameList(FramePackBasic.FramePack.ToList<FrameItem>());

			settingsList.GetModel<UiConfigOverlay>()
				.SetOverlayList(OverlayPackBasic.OverlayPack.ToList<OverlayItem>());

			new PhotoEditorBuilder(this)
							.SetSettingsList(settingsList)
							.StartActivityForResult(this, EDITOR_ACTIVITY_RESULT);
		}

		private void ConfigureStickers(SettingsList settingsList)
		{
			settingsList.GetModel<UiConfigSticker>()
			.SetStickerLists(new[]
			{
				ConfigureAndGetStickerDogCategory(settingsList),
				ConfigureAndGetStickerCatCategory(settingsList),
				ConfigureAndGetStickerCostumeCategory(settingsList),
				ConfigureAndGetStickerCareclubCategory(settingsList),
			});
		}

		private StickerCategoryItem ConfigureAndGetStickerDogCategory(SettingsList settingsList)
		{
			return CreateCatgoryItem(settingsList, "puppy_love_preview", new[]
			{
					"lifes_ruff",
					"going_mutts",
					"the_bark_side",
					"i_woof_you",
					"woof",
					"looking_good",
					"bubble_bone",
					"bone"
			});
		}

		private StickerCategoryItem ConfigureAndGetStickerCatCategory(SettingsList settingsList)
		{
			return CreateCatgoryItem(settingsList, "meeeow_preview", new[]
			{
					"purrfect",
					"cattastic",
					"cattitude",
					"meeeow",
					"bubble_fish",
					"ball_of_yarn",
					"snap_cat_v1a",
					"snap_cat_v1c"
			});
		}

		private StickerCategoryItem ConfigureAndGetStickerCostumeCategory(SettingsList settingsList)
		{
			return CreateCatgoryItem(settingsList, "bowtie_preview", new[]
			{
					"hat_1",
					"hat_2",
					"bowtie",
					"glasses",
					"sunglasses",
					"mustache",
					"beard",
					"pawsome",
					"so_fluffy",
					"ball",
					"just_chilling",
					"feeling_good",
					"four_leg_love",
					"love",
					"harts",
					"stars",
					"vca_logo",
					"vca_canada_logo"
			});
		}

		private StickerCategoryItem ConfigureAndGetStickerCareclubCategory(SettingsList settingsList)
		{
			return CreateCatgoryItem(settingsList, "vca_careclub_01", new[]
			{
				"birthdayhat_cc_01",
				"dreamingbone_cc_01",
				"dreamingfish_cc",
				"glasses_cc_01",
				"hearts_icon_8_cc_01",
				"largebowtie_cc_01",
				"largecrown_cc_01",
				"tophat_cc_01",
				"vca_careclub_01",
				"zzz_cc_01",
			});
		}

		private StickerCategoryItem CreateCatgoryItem(SettingsList settingsList, string categoryDrawableName, IList<string> drawableNames)
		{
			var categoryId = Guid.NewGuid().ToString();
			var categoryDrawableId = GetDrawableId(categoryDrawableName);

			var stickerItems = drawableNames.Select(d => CreateImageStickerItem(settingsList, d, categoryId)).ToArray();

			return new StickerCategoryItem(categoryId, categoryDrawableName, ImageSource.Create(categoryDrawableId), stickerItems);
		}

		private ImageStickerItem CreateImageStickerItem(SettingsList settingsList, string drawableName, string categoryId)
		{
			var drawableId = GetDrawableId(drawableName);
			var previewDawableId = GetDrawableId($"{drawableName}_preview");
			var stickerItemId = $"{categoryId}.{drawableName}";

			settingsList.Config.AddAsset(new[] { new ImageStickerAsset(stickerItemId, ImageSource.Create(drawableId), ImageStickerAsset.OPTION_MODE.TintSticker) });

			return new ImageStickerItem(stickerItemId, drawableName, ImageSource.Create(previewDawableId));
		}

		private int GetDrawableId(string name) => Resources.GetIdentifier(name, DrawableDefType, PackageName);

	}
}

