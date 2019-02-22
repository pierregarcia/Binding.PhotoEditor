using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LY.Img.Android.Pesdk.Backend.Brush.Models
{
	public partial class Painting
	{
		public void RevertState(Java.Lang.Object state)
		{
			RevertState(state as PaintingChunkList);
		}
	}
}