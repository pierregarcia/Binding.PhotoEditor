using System;
namespace LY.Img.Android.Pesdk.UI.Panels
{
    public partial class StickerToolPanel
    {
        public void OnItemClick(Java.Lang.Object entity)
        {
            OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.AbstractIdItem); 
        }
    }
}
