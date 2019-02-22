using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LY.Img.Android.Pesdk.Backend.Model.Chunk
{
	public partial class Request
	{
		public void SetMatrix(Matrix p0)
		{
			Matrix = p0;
		}

		public void SetPreviewMode(bool p0)
		{
			PreviewMode = p0;
		}

		public void SetRect(Rect p0)
		{
			Rect = p0;
		}

		public void SetSourceSampling(float p0)
		{
			SourceSampling = p0;
		}
	}
}