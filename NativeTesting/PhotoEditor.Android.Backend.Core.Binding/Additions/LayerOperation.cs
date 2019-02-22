﻿using Java.Math;
using LY.Img.Android.Pesdk.Backend.Model.Chunk;
using LY.Img.Android.Pesdk.Backend.Model.State;

namespace LY.Img.Android.Pesdk.Backend.Operator.Export
{
	public partial class LayerOperation
	{
		protected override IRequestResultI DoOperation(Operator @operator, Java.Lang.Object settings, IResultRegionI request)
		{
			return this.DoOperation(@operator, settings as LayerListSettings, request);
		}

		protected override BigDecimal GetEstimatedMemoryConsumptionFactor(Operator @operator, Java.Lang.Object settings)
		{
			return this.GetEstimatedMemoryConsumptionFactor(@operator, settings as LayerListSettings);
		}

		public override bool IsReady(Java.Lang.Object settings)
		{
			return this.IsReady(settings as LayerListSettings);
		}
	}
}