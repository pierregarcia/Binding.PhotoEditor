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
using Java.Math;
using LY.Img.Android.Pesdk.Backend.Model.Chunk;
using LY.Img.Android.Pesdk.Backend.Model.State;

namespace LY.Img.Android.Pesdk.Backend.Operator.Export
{
	public partial class TransformOperation
	{
		protected override IRequestResultI DoOperation(Operator @operator, Java.Lang.Object settings, IResultRegionI request)
		{
			return this.DoOperation(@operator, settings as TransformSettings, request);
		}

		protected override BigDecimal GetEstimatedMemoryConsumptionFactor(Operator @operator, Java.Lang.Object settings)
		{
			return this.GetEstimatedMemoryConsumptionFactor(@operator, settings as TransformSettings);
		}

		public override bool IsReady(Java.Lang.Object settings)
		{
			return this.IsReady(settings as TransformSettings);
		}
	}
}