using System;
namespace LY.Img.Android.Pesdk.UI.Viewholder
{
    public partial class ColorViewHolder
    {
        protected override void BindData(Java.Lang.Object item)
        {
            this.BindData(item as LY.Img.Android.Pesdk.UI.Panels.Item.ColorItem);
        }
    }
}
