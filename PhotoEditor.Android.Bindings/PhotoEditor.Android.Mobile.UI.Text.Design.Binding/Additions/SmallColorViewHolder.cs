﻿using System;
namespace LY.Img.Android.Pesdk.UI.Viewholder
{
    public partial class SmallColorViewHolder
    {
        protected override void BindData(Java.Lang.Object item)
        {
            BindData(item as LY.Img.Android.Pesdk.UI.Panels.Item.ColorItem);
        }
    }
}