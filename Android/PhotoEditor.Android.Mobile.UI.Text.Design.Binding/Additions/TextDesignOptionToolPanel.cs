using System;
namespace LY.Img.Android.Pesdk.UI.Panels
{
    public partial class TextDesignOptionToolPanel
    {
        public partial class OptionItemClickListener
        {
            public void OnItemClick(Java.Lang.Object entity)
            {
                OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.OptionItem);
            }
        }

        public partial class TextDesignClickListener
        {
            public void OnItemClick(Java.Lang.Object entity)
            {
                OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.TextDesignItem);
            }
        }
    }
}
