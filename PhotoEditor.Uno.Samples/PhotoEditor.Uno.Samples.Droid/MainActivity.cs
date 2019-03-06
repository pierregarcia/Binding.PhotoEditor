using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Views;
using System;
using LY.Img.Android.Pesdk.All;
using LY.Img.Android.Pesdk.Backend.Model.State.Manager;
using LY.Img.Android.Pesdk.Backend.Model.State;
using LY.Img.Android.Pesdk.Backend.Model.Config;
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

			SetupStickers(settingsList);

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

		private void SetupStickers(SettingsList settingsList)
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
			settingsList.Config.AddAsset(new[]
			{
				new ImageStickerAsset( "sticker.dog.puppy_love", ImageSource.Create(Resource.Drawable.puppy_love), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.lifes_ruff", ImageSource.Create(Resource.Drawable.lifes_ruff), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.going_mutts", ImageSource.Create(Resource.Drawable.going_mutts), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.the_bark_side", ImageSource.Create(Resource.Drawable.the_bark_side), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.i_woof_you", ImageSource.Create(Resource.Drawable.i_woof_you), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.woof", ImageSource.Create(Resource.Drawable.woof), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.looking_good", ImageSource.Create(Resource.Drawable.looking_good), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.bubble_bone", ImageSource.Create(Resource.Drawable.bubble_bone), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.dog.bone", ImageSource.Create(Resource.Drawable.bone), ImageStickerAsset.OPTION_MODE.TintSticker),
			});

			return new StickerCategoryItem(Guid.NewGuid().ToString(), Resource.String.dogs_category, ImageSource.Create(Resource.Drawable.puppy_love), new[]
				{
					new ImageStickerItem("sticker.dog.lifes_ruff", Resource.String.lifes_ruff_name, ImageSource.Create(Resource.Drawable.lifes_ruff_preview)),
					new ImageStickerItem("sticker.dog.going_mutts", Resource.String.going_mutts_name, ImageSource.Create(Resource.Drawable.going_mutts_preview)),
					new ImageStickerItem("sticker.dogthe_bark_side.", Resource.String.the_bark_side_name, ImageSource.Create(Resource.Drawable.the_bark_side_preview)),
					new ImageStickerItem("sticker.dog.i_woof_you", Resource.String.i_woof_you_name, ImageSource.Create(Resource.Drawable.i_woof_you_preview)),
					new ImageStickerItem("sticker.dog.woof", Resource.String.woof_name, ImageSource.Create(Resource.Drawable.woof_preview)),
					new ImageStickerItem("sticker.dog.looking_good", Resource.String.looking_good_name, ImageSource.Create(Resource.Drawable.looking_good_preview)),
					new ImageStickerItem("sticker.dog.bubble_bone", Resource.String.bubble_bone_name, ImageSource.Create(Resource.Drawable.bubble_bone_preview)),
					new ImageStickerItem("sticker.dog.bone", Resource.String.bone_name, ImageSource.Create(Resource.Drawable.bone_preview)),
				});
		}

		private StickerCategoryItem ConfigureAndGetStickerCatCategory(SettingsList settingsList)
		{
			settingsList.Config.AddAsset(new[]
			{
				new ImageStickerAsset( "sticker.cat.meeeow_category", ImageSource.Create(Resource.Drawable.meeeow), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.purrfect", ImageSource.Create(Resource.Drawable.purrfect), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.cattastic", ImageSource.Create(Resource.Drawable.cattastic), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.cattitude", ImageSource.Create(Resource.Drawable.cattitude), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.meeeow", ImageSource.Create(Resource.Drawable.meeeow), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.bubble_fish", ImageSource.Create(Resource.Drawable.bubble_fish), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.ball_of_yarn", ImageSource.Create(Resource.Drawable.ball_of_yarn), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.snap_cat_v1a", ImageSource.Create(Resource.Drawable.snap_cat_v1a), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.cat.snap_cat_v1c", ImageSource.Create(Resource.Drawable.snap_cat_v1c), ImageStickerAsset.OPTION_MODE.TintSticker),
			});

			return new StickerCategoryItem("sticker.cat.meeeow_category", Resource.String.cats_category, ImageSource.Create(Resource.Drawable.meeeow), new[]
				{
					new ImageStickerItem("sticker.cat.purrfect", Resource.String.purrfect_name, ImageSource.Create(Resource.Drawable.purrfect_preview)),
					new ImageStickerItem("sticker.cat.cattastic", Resource.String.cattastic_name, ImageSource.Create(Resource.Drawable.cattastic_preview)),
					new ImageStickerItem("sticker.cat.cattitude", Resource.String.cattitude_name, ImageSource.Create(Resource.Drawable.cattitude_preview)),
					new ImageStickerItem("sticker.cat.meeeow", Resource.String.meeeow_name, ImageSource.Create(Resource.Drawable.meeeow_preview)),
					new ImageStickerItem("sticker.cat.bubble_fish", Resource.String.bubble_fish_name, ImageSource.Create(Resource.Drawable.bubble_fish_preview)),
					new ImageStickerItem("sticker.cat.ball_of_yarn", Resource.String.ball_of_yarn_name, ImageSource.Create(Resource.Drawable.ball_of_yarn_preview)),
					new ImageStickerItem("sticker.cat.snap_cat_v1a", Resource.String.snap_cat_v1a_name, ImageSource.Create(Resource.Drawable.snap_cat_v1a_preview)),
					new ImageStickerItem("sticker.cat.snap_cat_v1c", Resource.String.snap_cat_v1c_name, ImageSource.Create(Resource.Drawable.snap_cat_v1c_preview)),
				});
		}

		private StickerCategoryItem ConfigureAndGetStickerCostumeCategory(SettingsList settingsList)
		{
			settingsList.Config.AddAsset(new[]
			{
				new ImageStickerAsset( "sticker.costume.hat_1", ImageSource.Create(Resource.Drawable.hat_1), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.hat_2", ImageSource.Create(Resource.Drawable.hat_2), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.bowtie", ImageSource.Create(Resource.Drawable.bowtie), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.glasses", ImageSource.Create(Resource.Drawable.glasses), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.sunglasses", ImageSource.Create(Resource.Drawable.sunglasses), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.mustache", ImageSource.Create(Resource.Drawable.mustache), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.beard", ImageSource.Create(Resource.Drawable.beard), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.pawsome", ImageSource.Create(Resource.Drawable.pawsome), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.so_fluffy", ImageSource.Create(Resource.Drawable.so_fluffy), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.ball", ImageSource.Create(Resource.Drawable.ball), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.just_chilling", ImageSource.Create(Resource.Drawable.just_chilling), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.feeling_good", ImageSource.Create(Resource.Drawable.feeling_good), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.four_leg_love", ImageSource.Create(Resource.Drawable.four_leg_love), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.love", ImageSource.Create(Resource.Drawable.love), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.harts", ImageSource.Create(Resource.Drawable.harts), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.stars", ImageSource.Create(Resource.Drawable.stars), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.vca_logo", ImageSource.Create(Resource.Drawable.vca_logo), ImageStickerAsset.OPTION_MODE.TintSticker),
				new ImageStickerAsset( "sticker.costume.vca_canada_logo", ImageSource.Create(Resource.Drawable.vca_canada_logo), ImageStickerAsset.OPTION_MODE.TintSticker),
			});

			return new StickerCategoryItem(Guid.NewGuid().ToString(), Resource.String.costumes_category, ImageSource.Create(Resource.Drawable.bowtie_preview), new[]
				{
					new ImageStickerItem("sticker.costume.hat_1", Resource.String.hat_1_name, ImageSource.Create(Resource.Drawable.hat_1_preview)),
					new ImageStickerItem("sticker.costume.hat_2", Resource.String.hat_2_name, ImageSource.Create(Resource.Drawable.hat_2_preview)),
					new ImageStickerItem("sticker.costume.bowtie", Resource.String.bowtie_name, ImageSource.Create(Resource.Drawable.bowtie_preview)),
					new ImageStickerItem("sticker.costume.glasses", Resource.String.glasses_name, ImageSource.Create(Resource.Drawable.glasses_preview)),
					new ImageStickerItem("sticker.costume.sunglasses", Resource.String.sunglasses_name, ImageSource.Create(Resource.Drawable.sunglasses_preview)),
					new ImageStickerItem("sticker.costume.mustache", Resource.String.mustache_name, ImageSource.Create(Resource.Drawable.mustache_preview)),
					new ImageStickerItem("sticker.costume.beard", Resource.String.beard_name, ImageSource.Create(Resource.Drawable.beard_preview)),
					new ImageStickerItem("sticker.costume.pawsome", Resource.String.pawsome_name, ImageSource.Create(Resource.Drawable.pawsome_preview)),
					new ImageStickerItem("sticker.costume.so_fluffy", Resource.String.so_fluffy_name, ImageSource.Create(Resource.Drawable.so_fluffy_preview)),
					new ImageStickerItem("sticker.costume.ball", Resource.String.ball_name, ImageSource.Create(Resource.Drawable.ball_preview)),
					new ImageStickerItem("sticker.costume.just_chilling", Resource.String.just_chilling_name, ImageSource.Create(Resource.Drawable.just_chilling_preview)),
					new ImageStickerItem("sticker.costume.feeling_good", Resource.String.feeling_good_name, ImageSource.Create(Resource.Drawable.feeling_good_preview)),
					new ImageStickerItem("sticker.costume.four_leg_love", Resource.String.four_leg_love_name, ImageSource.Create(Resource.Drawable.four_leg_love_preview)),
					new ImageStickerItem("sticker.costume.love", Resource.String.love_name, ImageSource.Create(Resource.Drawable.love_preview)),
					new ImageStickerItem("sticker.costume.harts", Resource.String.harts_name, ImageSource.Create(Resource.Drawable.harts_preview)),
					new ImageStickerItem("sticker.costume.stars", Resource.String.stars_name, ImageSource.Create(Resource.Drawable.stars_preview)),
					new ImageStickerItem("sticker.costume.vca_logo", Resource.String.vca_logo_name, ImageSource.Create(Resource.Drawable.vca_logo_preview)),
					new ImageStickerItem("sticker.costume.vca_canada_logo", Resource.String.vca_canada_logo_name, ImageSource.Create(Resource.Drawable.vca_canada_logo_preview)),
				});
		}

		private StickerCategoryItem ConfigureAndGetStickerCareclubCategory(SettingsList settingsList)
		{
			settingsList.Config.AddAsset(new[]
			{
				new ImageStickerAsset( "sticker.careclub.birthdayhat_cc_01", ImageSource.Create(Resource.Drawable.birthdayhat_cc_01)),
				new ImageStickerAsset( "sticker.careclub.dreamingbone_cc_01", ImageSource.Create(Resource.Drawable.dreamingbone_cc_01)),
				new ImageStickerAsset( "sticker.careclub.dreamingfish_cc", ImageSource.Create(Resource.Drawable.dreamingfish_cc)),
				new ImageStickerAsset( "sticker.careclub.glasses_cc_01", ImageSource.Create(Resource.Drawable.glasses_cc_01)),
				new ImageStickerAsset( "sticker.careclub.hearts_icon_8_cc_01", ImageSource.Create(Resource.Drawable.hearts_icon_8_cc_01)),
				new ImageStickerAsset( "sticker.careclub.largebowtie_cc_01", ImageSource.Create(Resource.Drawable.largebowtie_cc_01)),
				new ImageStickerAsset( "sticker.careclub.largecrown_cc_01", ImageSource.Create(Resource.Drawable.largecrown_cc_01)),
				new ImageStickerAsset( "sticker.careclub.tophat_cc_01", ImageSource.Create(Resource.Drawable.tophat_cc_01)),
				new ImageStickerAsset( "sticker.careclub.vca_careclub_01", ImageSource.Create(Resource.Drawable.vca_careclub_01)),
				new ImageStickerAsset( "sticker.careclub.zzz_cc_01", ImageSource.Create(Resource.Drawable.zzz_cc_01)),
			});

			return new StickerCategoryItem(Guid.NewGuid().ToString(), Resource.String.logos_category, ImageSource.Create(Resource.Drawable.vca_careclub_01), new[]
			{
				new ImageStickerItem("sticker.careclub.birthdayhat_cc_01", Resource.String.birthdayhat_cc_01_name, ImageSource.Create(Resource.Drawable.birthdayhat_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.dreamingbone_cc_01", Resource.String.dreamingbone_cc_01_name, ImageSource.Create(Resource.Drawable.dreamingbone_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.dreamingfish_cc", Resource.String.dreamingfish_cc_name, ImageSource.Create(Resource.Drawable.dreamingfish_cc_preview)),
				new ImageStickerItem("sticker.careclub.glasses_cc_01", Resource.String.glasses_cc_01_name, ImageSource.Create(Resource.Drawable.glasses_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.hearts_icon_8_cc_01", Resource.String.hearts_icon_8_cc_01_name, ImageSource.Create(Resource.Drawable.hearts_icon_8_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.largebowtie_cc_01", Resource.String.largebowtie_cc_01_name, ImageSource.Create(Resource.Drawable.largebowtie_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.largecrown_cc_01", Resource.String.largecrown_cc_01_name, ImageSource.Create(Resource.Drawable.largecrown_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.tophat_cc_01", Resource.String.tophat_cc_01_name, ImageSource.Create(Resource.Drawable.tophat_cc_01_preview)),
				new ImageStickerItem("sticker.careclub.vca_careclub_01", Resource.String.vca_careclub_01_name, ImageSource.Create(Resource.Drawable.vca_careclub_01_preview)),
				new ImageStickerItem("sticker.careclub.zzz_cc_01", Resource.String.zzz_cc_01_name, ImageSource.Create(Resource.Drawable.zzz_cc_01_preview)),
			});
		}

	}
}

