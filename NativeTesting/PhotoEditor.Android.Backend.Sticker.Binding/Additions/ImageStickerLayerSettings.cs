using System;
namespace LY.Img.Android.Pesdk.Backend.Model.State.Layer
{
    public partial class ImageStickerLayerSettings
    {
        public override SpriteLayerSettings FlipHorizontal() 
        {
            return FlipHorizontalBase();
        }
        public override SpriteLayerSettings FlipVertical()
        {
            return FlipVerticalBase();
        }

        public override SpriteLayerSettings SetStickerRotation(float rotation)
        {
            return SetStickerRotationBase(rotation);
        }

        public override SpriteLayerSettings SetColorMatrix(global::Android.Graphics.ColorMatrix filter)
        {
            return SetColorMatrixBase(filter);
        }

        public override SpriteLayerSettings SetPosition(double x, double y, float angle, double textSize)
        {
            return SetPositionBase(x, y, angle, textSize);
        }
    }
}
