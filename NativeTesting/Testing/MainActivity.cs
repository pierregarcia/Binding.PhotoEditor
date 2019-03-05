using System;
using System.Linq;
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
using LY.Img.Android.Pesdk.UI.Model.State;
using LY.Img.Android.Pesdk.UI.Panels.Item;
using LY.Img.Android.Pesdk.Backend.Decoder;
using LY.Img.Android.Pesdk.UI.Panels;
using LY.Img.Android.Pesdk.Assets.Sticker.Emoticons;
using LY.Img.Android.Pesdk.Assets.Sticker.Shapes;
using LY.Img.Android.Pesdk.Assets.Filter.Basic;
using LY.Img.Android.Pesdk.Assets.Font.Basic;
using LY.Img.Android.Pesdk.Assets.Frame.Basic;
using System.Collections.Generic;
using LY.Img.Android.Pesdk.Assets.Overlay.Basic;

namespace Testing
{
    [Activity(Label = "Img Nventive", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
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
        }

        private void MainActivity_Click(object sender, EventArgs e)
        {
            SettingsList settingsList = new SettingsList();

            ((EditorSaveSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorSaveSettings)))).SetExportDir(Directory.Dcim, "SomeFolderName").SetExportPrefix("sad").SetSavePolicy(EditorSaveSettings.SavePolicy.ReturnAlwaysOnlyOutput);

            ((EditorLoadSettings)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(EditorLoadSettings)))).SetImageSource(Android.Net.Uri.Parse("https://images.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg?auto=compress&cs=tinysrgb&h=350"));

            //((UiConfigMainMenu)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(UiConfigMainMenu)))).SetToolList(new[]
            //{
            //    new ToolItem(TransformToolPanel.ToolId, Resource.String.pesdk_transform_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_transform)),
            //    new ToolItem(FilterToolPanel.ToolId, Resource.String.pesdk_filter_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_filters)),
            //    new ToolItem(AdjustmentToolPanel.ToolId, Resource.String.pesdk_adjustments_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_adjust)),
            //    new ToolItem(StickerToolPanel.ToolId, Resource.String.pesdk_sticker_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_sticker)),
            //    new ToolItem(TextToolPanel.ToolId, Resource.String.pesdk_text_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_text)),
            //    //new ToolItem(TextDesignToolPanel.ToolId, Resource.String.pesdk_textDesign_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_text_design)),
            //    new ToolItem(OverlayToolPanel.ToolId, Resource.String.pesdk_overlay_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_overlay)),
            //    new ToolItem(FrameToolPanel.ToolId, Resource.String.pesdk_frame_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_frame)),
            //    new ToolItem(BrushToolPanel.ToolId, Resource.String.pesdk_brush_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_brush)),
            //    new ToolItem(FocusToolPanel.ToolId, Resource.String.pesdk_focus_title_name, ImageSource.Create(Resource.Drawable.imgly_icon_tool_focus)),
            //});

            ((UiConfigSticker)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(UiConfigSticker)))).SetStickerLists(new[]
            {
                StickerPackEmoticons.StickerCategory,
                StickerPackShapes.StickerCategory,
            });
            var fonts = new List<FontItem>();
            for (int i = 0; i < FontPackBasic.FontPack.Size(); i++)
            {
                fonts.Add(FontPackBasic.FontPack.Get(i) as FontItem);
            }
            ((UiConfigText)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(UiConfigText))))
            .SetFontList(fonts);

            var filters = new List<FilterItem>();
            for (int i = 0; i < FilterPackBasic.FilterPack.Size(); i++)
            {
                filters.Add(FilterPackBasic.FilterPack.Get(i) as FilterItem);
            }
            ((UiConfigFilter)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(UiConfigFilter))))
            .SetFilterList(filters);

            var frames = new List<FrameItem>();
            for (int i = 0; i < FramePackBasic.FramePack.Size(); i++)
            {
                frames.Add(FramePackBasic.FramePack.Get(i) as FrameItem);
            }

            ((UiConfigFrame)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(UiConfigFrame))))
            .SetFrameList(frames);

            var overlays = new List<OverlayItem>();
            for (int i = 0; i < OverlayPackBasic.OverlayPack.Size(); i++)
            {
                overlays.Add(OverlayPackBasic.OverlayPack.Get(i) as OverlayItem);
            }

            ((UiConfigOverlay)settingsList.GetSettingsModel(Java.Lang.Class.FromType(typeof(UiConfigOverlay))))
            .SetOverlayList(overlays);

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

