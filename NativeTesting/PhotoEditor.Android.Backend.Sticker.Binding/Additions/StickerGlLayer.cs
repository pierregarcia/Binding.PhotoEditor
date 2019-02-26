using Java.Math;
using LY.Img.Android.Pesdk.Backend.Model.Chunk;
using LY.Img.Android.Pesdk.Backend.Model.State;
using LY.Img.Android.Pesdk.Backend.Model.State.Layer;

namespace LY.Img.Android.Pesdk.Backend.Layer
{
	public partial class StickerGlLayer
	{
		public void OnStateChangeEvent(Java.Lang.Object @object)
		{
			OnStateChangeEvent(@object as ImageStickerLayerSettings.Event);
		}
	}
}