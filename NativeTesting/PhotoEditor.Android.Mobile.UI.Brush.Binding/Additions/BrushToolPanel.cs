using System;
namespace LY.Img.Android.Pesdk.UI.Panels
{
    public partial class BrushToolPanel
    {
        public void OnItemClick(Java.Lang.Object entity)
        {
            OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.OptionItem); 
        }

        public void OnTimeOut(Java.Lang.Object entity)
        {
        }

        protected internal partial class QuickListClickListener
        {
            public void OnItemClick(Java.Lang.Object entity)
            {
                OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.OptionItem);
            }
        }
    }
}
