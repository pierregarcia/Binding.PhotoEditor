using System;
namespace LY.Img.Android.Pesdk.UI.Panels
{
    public partial class AdjustmentToolPanel
    {
        public void OnItemClick(Java.Lang.Object entity)
        {
            OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.AdjustOption); 
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
