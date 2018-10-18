//using System;
//using System.Collections.Generic;
//using Android.Runtime;

//namespace LY.Img.Android.Sdk.Operator.Export
//{

//	// Metadata.xml XPath class reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']"
//	[global::Android.Runtime.Register("ly/img/android/sdk/operator/export/FilterOperation", DoNotGenerateAcw = true)]
//	public partial class FilterOperation : global::LY.Img.Android.Sdk.Operator.Export.Operation<Models.State.FilterSettings>
//	{

//		internal static new IntPtr java_class_handle;
//		internal static new IntPtr class_ref
//		{
//			get
//			{
//				return JNIEnv.FindClass("ly/img/android/sdk/operator/export/FilterOperation", ref java_class_handle);
//			}
//		}

//		protected override IntPtr ThresholdClass
//		{
//			get { return class_ref; }
//		}

//		protected override global::System.Type ThresholdType
//		{
//			get { return typeof(FilterOperation); }
//		}

//		protected FilterOperation(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

//		static IntPtr id_ctor;
//		// Metadata.xml XPath constructor reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/constructor[@name='FilterOperation' and count(parameter)=0]"
//		[Register(".ctor", "()V", "")]
//		public unsafe FilterOperation()
//			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
//		{
//			if (((global::Java.Lang.Object)this).Handle != IntPtr.Zero)
//				return;

//			try
//			{
//				if (((object)this).GetType() != typeof(FilterOperation))
//				{
//					SetHandle(
//							global::Android.Runtime.JNIEnv.StartCreateInstance(((object)this).GetType(), "()V"),
//							JniHandleOwnership.TransferLocalRef);
//					global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, "()V");
//					return;
//				}

//				if (id_ctor == IntPtr.Zero)
//					id_ctor = JNIEnv.GetMethodID(class_ref, "<init>", "()V");
//				SetHandle(
//						global::Android.Runtime.JNIEnv.StartCreateInstance(class_ref, id_ctor),
//						JniHandleOwnership.TransferLocalRef);
//				JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, class_ref, id_ctor);
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getIdentifier;
//#pragma warning disable 0169
//		static Delegate GetGetIdentifierHandler()
//		{
//			if (cb_getIdentifier == null)
//				cb_getIdentifier = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_GetIdentifier);
//			return cb_getIdentifier;
//		}

//		static IntPtr n_GetIdentifier(IntPtr jnienv, IntPtr native__this)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.FilterOperation __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.FilterOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return JNIEnv.NewString(__this.Identifier);
//		}
//#pragma warning restore 0169

//		static IntPtr id_getIdentifier;
//		protected override unsafe string Identifier
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/method[@name='getIdentifier' and count(parameter)=0]"
//			[Register("getIdentifier", "()Ljava/lang/String;", "GetGetIdentifierHandler")]
//			get
//			{
//				if (id_getIdentifier == IntPtr.Zero)
//					id_getIdentifier = JNIEnv.GetMethodID(class_ref, "getIdentifier", "()Ljava/lang/String;");
//				try
//				{

//					if (((object)this).GetType() == ThresholdType)
//						return JNIEnv.GetString(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getIdentifier), JniHandleOwnership.TransferLocalRef);
//					else
//						return JNIEnv.GetString(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getIdentifier", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
//				}
//				finally
//				{
//				}
//			}
//		}

//		static Delegate cb_getPriority;
//#pragma warning disable 0169
//		static Delegate GetGetPriorityHandler()
//		{
//			if (cb_getPriority == null)
//				cb_getPriority = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_GetPriority);
//			return cb_getPriority;
//		}

//		static IntPtr n_GetPriority(IntPtr jnienv, IntPtr native__this)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.FilterOperation __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.FilterOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return JNIEnv.ToLocalJniHandle(__this.Priority);
//		}
//#pragma warning restore 0169

//		static IntPtr id_getPriority;
//		protected virtual unsafe global::LY.Img.Android.Sdk.Operator.Priority Priority
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/method[@name='getPriority' and count(parameter)=0]"
//			[Register("getPriority", "()Lly/img/android/sdk/operator/Priority;", "GetGetPriorityHandler")]
//			get
//			{
//				if (id_getPriority == IntPtr.Zero)
//					id_getPriority = JNIEnv.GetMethodID(class_ref, "getPriority", "()Lly/img/android/sdk/operator/Priority;");
//				try
//				{

//					if (((object)this).GetType() == ThresholdType)
//						return global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Priority>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getPriority), JniHandleOwnership.TransferLocalRef);
//					else
//						return global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Priority>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getPriority", "()Lly/img/android/sdk/operator/Priority;")), JniHandleOwnership.TransferLocalRef);
//				}
//				finally
//				{
//				}
//			}
//		}

//		static Delegate cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//#pragma warning disable 0169
//		static Delegate GetDoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler()
//		{
//			if (cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_ == null)
//				cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_DoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_);
//			return cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//		}

//		static IntPtr n_DoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.FilterOperation __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.FilterOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.State.FilterSettings p1 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.State.FilterSettings>(native_p1, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p2 = (global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI)global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI>(native_p2, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.DoOperation(p0, p1, p2));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/method[@name='doOperation' and count(parameter)=3 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='ly.img.android.sdk.models.state.FilterSettings'] and parameter[3][@type='ly.img.android.sdk.models.chunk.ResultRegionI']]"
//		[Register("doOperation", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/FilterSettings;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;", "GetDoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler")]
//		protected override unsafe global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI DoOperation(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, global::LY.Img.Android.Sdk.Models.State.FilterSettings p1, global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p2)
//		{
//			if (id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_ == IntPtr.Zero)
//				id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_ = JNIEnv.GetMethodID(class_ref, "doOperation", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/FilterSettings;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;");
//			try
//			{
//				JValue* __args = stackalloc JValue[3];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);
//				__args[2] = new JValue(p2);

//				global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Lly_img_android_sdk_models_chunk_ResultRegionI_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "doOperation", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/FilterSettings;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_;
//#pragma warning disable 0169
//		static Delegate GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Handler()
//		{
//			if (cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_ == null)
//				cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_GetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_);
//			return cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_;
//		}

//		static IntPtr n_GetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.FilterOperation __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.FilterOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.State.FilterSettings p1 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.State.FilterSettings>(native_p1, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetEstimatedMemoryConsumptionFactor(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/method[@name='getEstimatedMemoryConsumptionFactor' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='ly.img.android.sdk.models.state.FilterSettings']]"
//		[Register("getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/FilterSettings;)Ljava/math/BigDecimal;", "GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_Handler")]
//		protected override unsafe global::Java.Math.BigDecimal GetEstimatedMemoryConsumptionFactor(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, global::LY.Img.Android.Sdk.Models.State.FilterSettings p1)
//		{
//			if (id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_ == IntPtr.Zero)
//				id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_ = JNIEnv.GetMethodID(class_ref, "getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/FilterSettings;)Ljava/math/BigDecimal;");
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);

//				global::Java.Math.BigDecimal __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_FilterSettings_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/FilterSettings;)Ljava/math/BigDecimal;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//#pragma warning disable 0169
//		static Delegate GetGetResultRect_Lly_img_android_sdk_operator_export_Operator_FHandler()
//		{
//			if (cb_getResultRect_Lly_img_android_sdk_operator_export_Operator_F == null)
//				cb_getResultRect_Lly_img_android_sdk_operator_export_Operator_F = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, float, IntPtr>)n_GetResultRect_Lly_img_android_sdk_operator_export_Operator_F);
//			return cb_getResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//		}

//		static IntPtr n_GetResultRect_Lly_img_android_sdk_operator_export_Operator_F(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, float p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.FilterOperation __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.FilterOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetResultRect(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/method[@name='getResultRect' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='float']]"
//		[Register("getResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;", "GetGetResultRect_Lly_img_android_sdk_operator_export_Operator_FHandler")]
//		public override unsafe global::Android.Graphics.Rect GetResultRect(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, float p1)
//		{
//			if (id_getResultRect_Lly_img_android_sdk_operator_export_Operator_F == IntPtr.Zero)
//				id_getResultRect_Lly_img_android_sdk_operator_export_Operator_F = JNIEnv.GetMethodID(class_ref, "getResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;");
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);

//				global::Android.Graphics.Rect __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getResultRect_Lly_img_android_sdk_operator_export_Operator_F, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_isReady_Lly_img_android_sdk_models_state_FilterSettings_;
//#pragma warning disable 0169
//		static Delegate GetIsReady_Lly_img_android_sdk_models_state_FilterSettings_Handler()
//		{
//			if (cb_isReady_Lly_img_android_sdk_models_state_FilterSettings_ == null)
//				cb_isReady_Lly_img_android_sdk_models_state_FilterSettings_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, bool>)n_IsReady_Lly_img_android_sdk_models_state_FilterSettings_);
//			return cb_isReady_Lly_img_android_sdk_models_state_FilterSettings_;
//		}

//		static bool n_IsReady_Lly_img_android_sdk_models_state_FilterSettings_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.FilterOperation __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.FilterOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.State.FilterSettings p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.State.FilterSettings>(native_p0, JniHandleOwnership.DoNotTransfer);
//			bool __ret = __this.IsReady(p0);
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_isReady_Lly_img_android_sdk_models_state_FilterSettings_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='FilterOperation']/method[@name='isReady' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.models.state.FilterSettings']]"
//		[Register("isReady", "(Lly/img/android/sdk/models/state/FilterSettings;)Z", "GetIsReady_Lly_img_android_sdk_models_state_FilterSettings_Handler")]
//		public override unsafe bool IsReady(global::LY.Img.Android.Sdk.Models.State.FilterSettings p0)
//		{
//			if (id_isReady_Lly_img_android_sdk_models_state_FilterSettings_ == IntPtr.Zero)
//				id_isReady_Lly_img_android_sdk_models_state_FilterSettings_ = JNIEnv.GetMethodID(class_ref, "isReady", "(Lly/img/android/sdk/models/state/FilterSettings;)Z");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				bool __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_isReady_Lly_img_android_sdk_models_state_FilterSettings_, __args);
//				else
//					__ret = JNIEnv.CallNonvirtualBooleanMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isReady", "(Lly/img/android/sdk/models/state/FilterSettings;)Z"), __args);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//	}
//}
