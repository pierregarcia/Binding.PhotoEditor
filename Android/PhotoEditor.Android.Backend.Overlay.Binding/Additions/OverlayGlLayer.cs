using Java.Math;
using LY.Img.Android.Pesdk.Backend.Model.Chunk;
using LY.Img.Android.Pesdk.Backend.Model.State;

namespace LY.Img.Android.Pesdk.Backend.Layer
{
	public partial class OverlayGlLayer
	{
		public void OnStateChangeEvent(Java.Lang.Object @object)
		{
			OnStateChangeEvent(@object as OverlaySettings.Event);
		}
	}
}