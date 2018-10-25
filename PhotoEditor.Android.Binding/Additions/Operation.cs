//using System;
//using System.Collections.Generic;
//using Android.Runtime;

//namespace LY.Img.Android.Sdk.Operator.Export
//{

//	// Metadata.xml XPath class reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']"
//	[global::Android.Runtime.Register("ly/img/android/sdk/operator/export/Operation", DoNotGenerateAcw = true)]
//	[global::Java.Interop.JavaTypeParameters(new string[] { "StateClass extends ly.img.android.sdk.models.state.manager.StateObservable" })]
//	public abstract partial class Operation<T> : global::Java.Lang.Object, global::Java.Lang.IComparable
//		where T : Models.State.Manager.StateObservable
//	{


//		static IntPtr MEMORY_MATH_CONTEXT_jfieldId;

//		// Metadata.xml XPath field reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/field[@name='MEMORY_MATH_CONTEXT']"
//		[Register("MEMORY_MATH_CONTEXT")]
//		protected global::Java.Math.MathContext MemoryMathContext
//		{
//			get
//			{
//				if (MEMORY_MATH_CONTEXT_jfieldId == IntPtr.Zero)
//					MEMORY_MATH_CONTEXT_jfieldId = JNIEnv.GetFieldID(class_ref, "MEMORY_MATH_CONTEXT", "Ljava/math/MathContext;");
//				IntPtr __ret = JNIEnv.GetObjectField(((global::Java.Lang.Object)this).Handle, MEMORY_MATH_CONTEXT_jfieldId);
//				return global::Java.Lang.Object.GetObject<global::Java.Math.MathContext>(__ret, JniHandleOwnership.TransferLocalRef);
//			}
//			set
//			{
//				if (MEMORY_MATH_CONTEXT_jfieldId == IntPtr.Zero)
//					MEMORY_MATH_CONTEXT_jfieldId = JNIEnv.GetFieldID(class_ref, "MEMORY_MATH_CONTEXT", "Ljava/math/MathContext;");
//				IntPtr native_value = JNIEnv.ToLocalJniHandle(value);
//				try
//				{
//					JNIEnv.SetField(((global::Java.Lang.Object)this).Handle, MEMORY_MATH_CONTEXT_jfieldId, native_value);
//				}
//				finally
//				{
//					JNIEnv.DeleteLocalRef(native_value);
//				}
//			}
//		}
//		internal static new IntPtr java_class_handle;
//		internal static new IntPtr class_ref
//		{
//			get
//			{
//				return JNIEnv.FindClass("ly/img/android/sdk/operator/export/Operation", ref java_class_handle);
//			}
//		}

//		protected override IntPtr ThresholdClass
//		{
//			get { return class_ref; }
//		}

//		protected override global::System.Type ThresholdType
//		{
//			get { return typeof(Operation<T>); }
//		}

//		protected Operation(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

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
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return JNIEnv.NewString(__this.Identifier);
//		}
//#pragma warning restore 0169

//		protected abstract string Identifier
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getIdentifier' and count(parameter)=0]"
//			[Register("getIdentifier", "()Ljava/lang/String;", "GetGetIdentifierHandler")]
//			get;
//		}

//		static Delegate cb_isCachable;
//#pragma warning disable 0169
//		static Delegate GetIsCachableHandler()
//		{
//			if (cb_isCachable == null)
//				cb_isCachable = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, bool>)n_IsCachable);
//			return cb_isCachable;
//		}

//		static bool n_IsCachable(IntPtr jnienv, IntPtr native__this)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return __this.IsCachable;
//		}
//#pragma warning restore 0169

//		static IntPtr id_isCachable;
//		protected virtual unsafe bool IsCachable
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='isCachable' and count(parameter)=0]"
//			[Register("isCachable", "()Z", "GetIsCachableHandler")]
//			get
//			{
//				if (id_isCachable == IntPtr.Zero)
//					id_isCachable = JNIEnv.GetMethodID(class_ref, "isCachable", "()Z");
//				try
//				{

//					if (((object)this).GetType() == ThresholdType)
//						return JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_isCachable);
//					else
//						return JNIEnv.CallNonvirtualBooleanMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isCachable", "()Z"));
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
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return JNIEnv.ToLocalJniHandle(__this.RawPriority);
//		}
//#pragma warning restore 0169

//		protected abstract LY.Img.Android.Sdk.Operator.OperationPriority RawPriority
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getPriority' and count(parameter)=0]"
//			[global::Java.Interop.JavaTypeParameters(new string[] { "T extends java.lang.Enum" })]
//			[Register("getPriority", "()Ljava/lang/Enum;", "GetGetPriorityHandler")]
//			get;
//		}

//		static Delegate cb_compareTo_Lly_img_android_sdk_operator_export_Operation_;
//#pragma warning disable 0169
//		static Delegate GetCompareTo_Lly_img_android_sdk_operator_export_Operation_Handler()
//		{
//			if (cb_compareTo_Lly_img_android_sdk_operator_export_Operation_ == null)
//				cb_compareTo_Lly_img_android_sdk_operator_export_Operation_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, int>)n_CompareTo_Lly_img_android_sdk_operator_export_Operation_);
//			return cb_compareTo_Lly_img_android_sdk_operator_export_Operation_;
//		}

//		static int n_CompareTo_Lly_img_android_sdk_operator_export_Operation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(native_p0, JniHandleOwnership.DoNotTransfer);
//			int __ret = __this.CompareTo(p0);
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_compareTo_Lly_img_android_sdk_operator_export_Operation_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='compareTo' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operation']]"
//		[Register("compareTo", "(Lly/img/android/sdk/operator/export/Operation;)I", "GetCompareTo_Lly_img_android_sdk_operator_export_Operation_Handler")]
//		public unsafe int CompareTo(global::Java.Lang.Object p0)
//		{
//			if (id_compareTo_Lly_img_android_sdk_operator_export_Operation_ == IntPtr.Zero)
//				id_compareTo_Lly_img_android_sdk_operator_export_Operation_ = JNIEnv.GetMethodID(class_ref, "compareTo", "(Lly/img/android/sdk/operator/export/Operation;)I");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				int __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = JNIEnv.CallIntMethod(((global::Java.Lang.Object)this).Handle, id_compareTo_Lly_img_android_sdk_operator_export_Operation_, __args);
//				else
//					__ret = JNIEnv.CallNonvirtualIntMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "compareTo", "(Lly/img/android/sdk/operator/export/Operation;)I"), __args);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//#pragma warning disable 0169
//		static Delegate GetDoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler()
//		{
//			if (cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_ == null)
//				cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_DoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_);
//			return cb_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//		}

//		static IntPtr n_DoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			T p1 = global::Java.Lang.Object.GetObject<T>(native_p1, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p2 = (global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI)global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI>(native_p2, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.DoOperation(p0, p1, p2));
//			return __ret;
//		}
//#pragma warning restore 0169

//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='doOperation' and count(parameter)=3 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='StateClass'] and parameter[3][@type='ly.img.android.sdk.models.chunk.ResultRegionI']]"
//		[Register("doOperation", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/manager/StateObservable;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;", "GetDoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler")]
//		protected abstract global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI DoOperation(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, T p1, global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p2);

//		static Delegate cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_;
//#pragma warning disable 0169
//		static Delegate GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Handler()
//		{
//			if (cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_ == null)
//				cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr>)n_GetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_);
//			return cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_;
//		}

//		static IntPtr n_GetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetEstimatedMemoryConsumptionFactor(p0));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getEstimatedMemoryConsumptionFactor' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator']]"
//		[Register("getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;)Ljava/math/BigDecimal;", "GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Handler")]
//		protected virtual unsafe global::Java.Math.BigDecimal GetEstimatedMemoryConsumptionFactor(global::LY.Img.Android.Sdk.Operator.Export.Operator p0)
//		{
//			if (id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_ == IntPtr.Zero)
//				id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_ = JNIEnv.GetMethodID(class_ref, "getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;)Ljava/math/BigDecimal;");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				global::Java.Math.BigDecimal __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;)Ljava/math/BigDecimal;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_;
//#pragma warning disable 0169
//		static Delegate GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Handler()
//		{
//			if (cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_ == null)
//				cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_GetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_);
//			return cb_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_;
//		}

//		static IntPtr n_GetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			T p1 = global::Java.Lang.Object.GetObject<T>(native_p1, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetEstimatedMemoryConsumptionFactor(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getEstimatedMemoryConsumptionFactor' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='StateClass']]"
//		[Register("getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/manager/StateObservable;)Ljava/math/BigDecimal;", "GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Handler")]
//		protected abstract global::Java.Math.BigDecimal GetEstimatedMemoryConsumptionFactor(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, T p1);

//		static Delegate cb_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_;
//#pragma warning disable 0169
//		static Delegate GetGetNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_Handler()
//		{
//			if (cb_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_ == null)
//				cb_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr>)n_GetNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_);
//			return cb_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_;
//		}

//		static IntPtr n_GetNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetNecessaryMemory(p0));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getNecessaryMemory' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator']]"
//		[Register("getNecessaryMemory", "(Lly/img/android/sdk/operator/export/Operator;)Ljava/math/BigDecimal;", "GetGetNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_Handler")]
//		protected virtual unsafe global::Java.Math.BigDecimal GetNecessaryMemory(global::LY.Img.Android.Sdk.Operator.Export.Operator p0)
//		{
//			if (id_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_ == IntPtr.Zero)
//				id_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_ = JNIEnv.GetMethodID(class_ref, "getNecessaryMemory", "(Lly/img/android/sdk/operator/export/Operator;)Ljava/math/BigDecimal;");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				global::Java.Math.BigDecimal __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getNecessaryMemory_Lly_img_android_sdk_operator_export_Operator_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getNecessaryMemory", "(Lly/img/android/sdk/operator/export/Operator;)Ljava/math/BigDecimal;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_;
//#pragma warning disable 0169
//		static Delegate GetGetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_Handler()
//		{
//			if (cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_ == null)
//				cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr>)n_GetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_);
//			return cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_;
//		}

//		static IntPtr n_GetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetPreviousResultRect(p0));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getPreviousResultRect' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator']]"
//		[Register("getPreviousResultRect", "(Lly/img/android/sdk/operator/export/Operator;)Landroid/graphics/Rect;", "GetGetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_Handler")]
//		protected virtual unsafe global::Android.Graphics.Rect GetPreviousResultRect(global::LY.Img.Android.Sdk.Operator.Export.Operator p0)
//		{
//			if (id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_ == IntPtr.Zero)
//				id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_ = JNIEnv.GetMethodID(class_ref, "getPreviousResultRect", "(Lly/img/android/sdk/operator/export/Operator;)Landroid/graphics/Rect;");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				global::Android.Graphics.Rect __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getPreviousResultRect", "(Lly/img/android/sdk/operator/export/Operator;)Landroid/graphics/Rect;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//#pragma warning disable 0169
//		static Delegate GetGetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_FHandler()
//		{
//			if (cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F == null)
//				cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, float, IntPtr>)n_GetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F);
//			return cb_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//		}

//		static IntPtr n_GetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, float p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetPreviousResultRect(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getPreviousResultRect' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='float']]"
//		[Register("getPreviousResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;", "GetGetPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_FHandler")]
//		protected virtual unsafe global::Android.Graphics.Rect GetPreviousResultRect(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, float p1)
//		{
//			if (id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F == IntPtr.Zero)
//				id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F = JNIEnv.GetMethodID(class_ref, "getPreviousResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;");
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);

//				global::Android.Graphics.Rect __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getPreviousResultRect_Lly_img_android_sdk_operator_export_Operator_F, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getPreviousResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;"), __args), JniHandleOwnership.TransferLocalRef);
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
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetResultRect(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getResultRect' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='float']]"
//		[Register("getResultRect", "(Lly/img/android/sdk/operator/export/Operator;F)Landroid/graphics/Rect;", "GetGetResultRect_Lly_img_android_sdk_operator_export_Operator_FHandler")]
//		public abstract global::Android.Graphics.Rect GetResultRect(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, float p1);

//		static Delegate cb_getState_Lly_img_android_sdk_operator_export_Operator_;
//#pragma warning disable 0169
//		static Delegate GetGetState_Lly_img_android_sdk_operator_export_Operator_Handler()
//		{
//			if (cb_getState_Lly_img_android_sdk_operator_export_Operator_ == null)
//				cb_getState_Lly_img_android_sdk_operator_export_Operator_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr>)n_GetState_Lly_img_android_sdk_operator_export_Operator_);
//			return cb_getState_Lly_img_android_sdk_operator_export_Operator_;
//		}

//		static IntPtr n_GetState_Lly_img_android_sdk_operator_export_Operator_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.GetState(p0));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_getState_Lly_img_android_sdk_operator_export_Operator_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getState' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator']]"
//		[Register("getState", "(Lly/img/android/sdk/operator/export/Operator;)Lly/img/android/sdk/models/state/manager/StateObservable;", "GetGetState_Lly_img_android_sdk_operator_export_Operator_Handler")]
//		protected virtual unsafe global::Java.Lang.Object GetState(global::LY.Img.Android.Sdk.Operator.Export.Operator p0)
//		{
//			if (id_getState_Lly_img_android_sdk_operator_export_Operator_ == IntPtr.Zero)
//				id_getState_Lly_img_android_sdk_operator_export_Operator_ = JNIEnv.GetMethodID(class_ref, "getState", "(Lly/img/android/sdk/operator/export/Operator;)Lly/img/android/sdk/models/state/manager/StateObservable;");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				global::Java.Lang.Object __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getState_Lly_img_android_sdk_operator_export_Operator_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getState", "(Lly/img/android/sdk/operator/export/Operator;)Lly/img/android/sdk/models/state/manager/StateObservable;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_;
//#pragma warning disable 0169
//		static Delegate GetIsReady_Lly_img_android_sdk_models_state_manager_StateObservable_Handler()
//		{
//			if (cb_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_ == null)
//				cb_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, bool>)n_IsReady_Lly_img_android_sdk_models_state_manager_StateObservable_);
//			return cb_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_;
//		}

//		static bool n_IsReady_Lly_img_android_sdk_models_state_manager_StateObservable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			T p0 = global::Java.Lang.Object.GetObject<T>(native_p0, JniHandleOwnership.DoNotTransfer);
//			bool __ret = __this.IsReady(p0);
//			return __ret;
//		}
//#pragma warning restore 0169

//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='isReady' and count(parameter)=1 and parameter[1][@type='StateClass']]"
//		[Register("isReady", "(Lly/img/android/sdk/models/state/manager/StateObservable;)Z", "GetIsReady_Lly_img_android_sdk_models_state_manager_StateObservable_Handler")]
//		public abstract bool IsReady(T p0);

//		static Delegate cb_operatorReady_Lly_img_android_sdk_operator_export_Operator_;
//#pragma warning disable 0169
//		static Delegate GetOperatorReady_Lly_img_android_sdk_operator_export_Operator_Handler()
//		{
//			if (cb_operatorReady_Lly_img_android_sdk_operator_export_Operator_ == null)
//				cb_operatorReady_Lly_img_android_sdk_operator_export_Operator_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, bool>)n_OperatorReady_Lly_img_android_sdk_operator_export_Operator_);
//			return cb_operatorReady_Lly_img_android_sdk_operator_export_Operator_;
//		}

//		static bool n_OperatorReady_Lly_img_android_sdk_operator_export_Operator_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			bool __ret = __this.OperatorReady(p0);
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_operatorReady_Lly_img_android_sdk_operator_export_Operator_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='operatorReady' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator']]"
//		[Register("operatorReady", "(Lly/img/android/sdk/operator/export/Operator;)Z", "GetOperatorReady_Lly_img_android_sdk_operator_export_Operator_Handler")]
//		public virtual unsafe bool OperatorReady(global::LY.Img.Android.Sdk.Operator.Export.Operator p0)
//		{
//			if (id_operatorReady_Lly_img_android_sdk_operator_export_Operator_ == IntPtr.Zero)
//				id_operatorReady_Lly_img_android_sdk_operator_export_Operator_ = JNIEnv.GetMethodID(class_ref, "operatorReady", "(Lly/img/android/sdk/operator/export/Operator;)Z");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				bool __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_operatorReady_Lly_img_android_sdk_operator_export_Operator_, __args);
//				else
//					__ret = JNIEnv.CallNonvirtualBooleanMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "operatorReady", "(Lly/img/android/sdk/operator/export/Operator;)Z"), __args);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_;
//#pragma warning disable 0169
//		static Delegate GetRequestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_Handler()
//		{
//			if (cb_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_ == null)
//				cb_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_RequestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_);
//			return cb_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_;
//		}

//		static IntPtr n_RequestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.Chunk.IRequestI p1 = (global::LY.Img.Android.Sdk.Models.Chunk.IRequestI)global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IRequestI>(native_p1, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.RequestSourceAnswer(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='requestSourceAnswer' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='ly.img.android.sdk.models.chunk.RequestI']]"
//		[Register("requestSourceAnswer", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/RequestI;)Lly/img/android/sdk/models/chunk/SourceRequestAnswerI;", "GetRequestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_Handler")]
//		protected virtual unsafe global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI RequestSourceAnswer(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, global::LY.Img.Android.Sdk.Models.Chunk.IRequestI p1)
//		{
//			if (id_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_ == IntPtr.Zero)
//				id_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_ = JNIEnv.GetMethodID(class_ref, "requestSourceAnswer", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/RequestI;)Lly/img/android/sdk/models/chunk/SourceRequestAnswerI;");
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);

//				global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_requestSourceAnswer_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_RequestI_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "requestSourceAnswer", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/RequestI;)Lly/img/android/sdk/models/chunk/SourceRequestAnswerI;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//#pragma warning disable 0169
//		static Delegate GetRunAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler()
//		{
//			if (cb_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_ == null)
//				cb_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_RunAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_);
//			return cb_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//		}

//		static IntPtr n_RunAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p1 = (global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI)global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI>(native_p1, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.RunAndDelegate(p0, p1));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='runAndDelegate' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='ly.img.android.sdk.models.chunk.ResultRegionI']]"
//		[Register("runAndDelegate", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;", "GetRunAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler")]
//		public virtual unsafe global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI RunAndDelegate(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p1)
//		{
//			if (id_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_ == IntPtr.Zero)
//				id_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_ = JNIEnv.GetMethodID(class_ref, "runAndDelegate", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;");
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);

//				global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_runAndDelegate_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_ResultRegionI_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "runAndDelegate", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III;
//#pragma warning disable 0169
//		static Delegate GetSetLevelProgress_Lly_img_android_sdk_operator_export_Operator_IIIHandler()
//		{
//			if (cb_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III == null)
//				cb_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, int, int, int>)n_SetLevelProgress_Lly_img_android_sdk_operator_export_Operator_III);
//			return cb_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III;
//		}

//		static void n_SetLevelProgress_Lly_img_android_sdk_operator_export_Operator_III(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, int p3)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//			__this.SetLevelProgress(p0, p1, p2, p3);
//		}
//#pragma warning restore 0169

//		static IntPtr id_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='setLevelProgress' and count(parameter)=4 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
//		[Register("setLevelProgress", "(Lly/img/android/sdk/operator/export/Operator;III)V", "GetSetLevelProgress_Lly_img_android_sdk_operator_export_Operator_IIIHandler")]
//		protected virtual unsafe void SetLevelProgress(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, int p1, int p2, int p3)
//		{
//			if (id_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III == IntPtr.Zero)
//				id_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III = JNIEnv.GetMethodID(class_ref, "setLevelProgress", "(Lly/img/android/sdk/operator/export/Operator;III)V");
//			try
//			{
//				JValue* __args = stackalloc JValue[4];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);
//				__args[2] = new JValue(p2);
//				__args[3] = new JValue(p3);

//				if (((object)this).GetType() == ThresholdType)
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setLevelProgress_Lly_img_android_sdk_operator_export_Operator_III, __args);
//				else
//					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setLevelProgress", "(Lly/img/android/sdk/operator/export/Operator;III)V"), __args);
//			}
//			finally
//			{
//			}
//		}

//		//		static Delegate cb_compareTo_Ljava_lang_Object_;
//		//#pragma warning disable 0169
//		//		static Delegate GetCompareTo_Ljava_lang_Object_Handler()
//		//		{
//		//			if (cb_compareTo_Ljava_lang_Object_ == null)
//		//				cb_compareTo_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, int>)n_CompareTo_Ljava_lang_Object_);
//		//			return cb_compareTo_Ljava_lang_Object_;
//		//		}

//		//		static int n_CompareTo_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_o)
//		//		{
//		//			global::LY.Img.Android.Sdk.Operator.Export.Operation<T> __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operation<T>>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//		//			global::Java.Lang.Object o = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
//		//			int __ret = __this.CompareTo(o);
//		//			return __ret;
//		//		}
//		//#pragma warning restore 0169

//		//		[Register("compareTo", "(Ljava/lang/Object;)I", "GetCompareTo_Ljava_lang_Object_Handler")]
//		//		public abstract global::System.Int32 CompareTo(global::Java.Lang.Object o);

//	}

//	[global::Android.Runtime.Register("ly/img/android/sdk/operator/export/Operation", DoNotGenerateAcw = true)]
//	internal partial class OperationInvoker : Operation<Models.State.Manager.StateObservable>
//	{
//		public OperationInvoker(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

//		protected override global::System.Type ThresholdType
//		{
//			get { return typeof(OperationInvoker); }
//		}

//		static IntPtr id_getIdentifier;
//		protected override unsafe string Identifier
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getIdentifier' and count(parameter)=0]"
//			[Register("getIdentifier", "()Ljava/lang/String;", "GetGetIdentifierHandler")]
//			get
//			{
//				if (id_getIdentifier == IntPtr.Zero)
//					id_getIdentifier = JNIEnv.GetMethodID(class_ref, "getIdentifier", "()Ljava/lang/String;");
//				try
//				{
//					return JNIEnv.GetString(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getIdentifier), JniHandleOwnership.TransferLocalRef);
//				}
//				finally
//				{
//				}
//			}
//		}

//		static IntPtr id_getPriority;
//		[global::Java.Interop.JavaTypeParameters(new string[] { "T extends java.lang.Enum" })]
//		protected override unsafe Models.State.Manager.StateObservable RawPriority
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getPriority' and count(parameter)=0]"
//			[Register("getPriority", "()Ljava/lang/Enum;", "GetGetPriorityHandler")]
//			get
//			{
//				if (id_getPriority == IntPtr.Zero)
//					id_getPriority = JNIEnv.GetMethodID(class_ref, "getPriority", "()Ljava/lang/Enum;");
//				try
//				{
//					return (Models.State.Manager.StateObservable)global::Java.Lang.Object.GetObject<Models.State.Manager.StateObservable>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getPriority), JniHandleOwnership.TransferLocalRef);
//				}
//				finally
//				{
//				}
//			}
//		}

//		static IntPtr id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='doOperation' and count(parameter)=3 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='StateClass'] and parameter[3][@type='ly.img.android.sdk.models.chunk.ResultRegionI']]"
//		[Register("doOperation", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/manager/StateObservable;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;", "GetDoOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_Handler")]
//		protected override unsafe global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI DoOperation(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, Models.State.Manager.StateObservable p1, global::LY.Img.Android.Sdk.Models.Chunk.IResultRegionI p2)
//		{
//			if (id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_ == IntPtr.Zero)
//				id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_ = JNIEnv.GetMethodID(class_ref, "doOperation", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/manager/StateObservable;Lly/img/android/sdk/models/chunk/ResultRegionI;)Lly/img/android/sdk/models/chunk/RequestResultI;");
//			IntPtr native_p1 = JNIEnv.ToLocalJniHandle(p1);
//			try
//			{
//				JValue* __args = stackalloc JValue[3];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(native_p1);
//				__args[2] = new JValue(p2);
//				global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI __ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.IRequestResultI>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_doOperation_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Lly_img_android_sdk_models_chunk_ResultRegionI_, __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//				JNIEnv.DeleteLocalRef(native_p1);
//			}
//		}

//		static IntPtr id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getEstimatedMemoryConsumptionFactor' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='StateClass']]"
//		[Register("getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/manager/StateObservable;)Ljava/math/BigDecimal;", "GetGetEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_Handler")]
//		protected override unsafe global::Java.Math.BigDecimal GetEstimatedMemoryConsumptionFactor(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, Models.State.Manager.StateObservable p1)
//		{
//			if (id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_ == IntPtr.Zero)
//				id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_ = JNIEnv.GetMethodID(class_ref, "getEstimatedMemoryConsumptionFactor", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/state/manager/StateObservable;)Ljava/math/BigDecimal;");
//			IntPtr native_p1 = JNIEnv.ToLocalJniHandle(p1);
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(native_p1);
//				global::Java.Math.BigDecimal __ret = global::Java.Lang.Object.GetObject<global::Java.Math.BigDecimal>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getEstimatedMemoryConsumptionFactor_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_state_manager_StateObservable_, __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//				JNIEnv.DeleteLocalRef(native_p1);
//			}
//		}

//		static IntPtr id_getResultRect_Lly_img_android_sdk_operator_export_Operator_F;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='getResultRect' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='float']]"
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
//				global::Android.Graphics.Rect __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Rect>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getResultRect_Lly_img_android_sdk_operator_export_Operator_F, __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static IntPtr id_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operation']/method[@name='isReady' and count(parameter)=1 and parameter[1][@type='StateClass']]"
//		[Register("isReady", "(Lly/img/android/sdk/models/state/manager/StateObservable;)Z", "GetIsReady_Lly_img_android_sdk_models_state_manager_StateObservable_Handler")]
//		public override unsafe bool IsReady(Models.State.Manager.StateObservable p0)
//		{
//			if (id_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_ == IntPtr.Zero)
//				id_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_ = JNIEnv.GetMethodID(class_ref, "isReady", "(Lly/img/android/sdk/models/state/manager/StateObservable;)Z");
//			IntPtr native_p0 = JNIEnv.ToLocalJniHandle(p0);
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(native_p0);
//				bool __ret = JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_isReady_Lly_img_android_sdk_models_state_manager_StateObservable_, __args);
//				return __ret;
//			}
//			finally
//			{
//				JNIEnv.DeleteLocalRef(native_p0);
//			}
//		}

//		//static IntPtr id_compareTo_Ljava_lang_Object_;
//		//[Register("compareTo", "(Ljava/lang/Object;)I", "GetCompareTo_Ljava_lang_Object_Handler")]
//		//public override unsafe global::System.Int32 CompareTo(global::Java.Lang.Object o)
//		//{
//		//	if (id_compareTo_Ljava_lang_Object_ == IntPtr.Zero)
//		//		id_compareTo_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "compareTo", "(Ljava/lang/Object;)I");
//		//	try
//		//	{
//		//		JValue* __args = stackalloc JValue[1];
//		//		__args[0] = new JValue(o);
//		//		global::System.Int32 __ret = JNIEnv.CallIntMethod(((global::Java.Lang.Object)this).Handle, id_compareTo_Ljava_lang_Object_, __args);
//		//		return __ret;
//		//	}
//		//	finally
//		//	{
//		//	}
//		//}

//	}

//}
