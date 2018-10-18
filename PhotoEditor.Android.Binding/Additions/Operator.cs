//using System;
//using System.Collections.Generic;
//using Android.Runtime;

//namespace LY.Img.Android.Sdk.Operator.Export
//{

//	// Metadata.xml XPath class reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']"
//	[global::Android.Runtime.Register("ly/img/android/sdk/operator/export/Operator", DoNotGenerateAcw = true)]
//	public partial class Operator : global::Java.Util.TreeSet
//	{

//		// Metadata.xml XPath class reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator.BackgroundRunner']"
//		[global::Android.Runtime.Register("ly/img/android/sdk/operator/export/Operator$BackgroundRunner", DoNotGenerateAcw = true)]
//		public partial class BackgroundRunner : global::LY.Img.Android.Sdk.Utils.ThreadUtils.ReplaceThreadRunnable
//		{

//			internal static new IntPtr java_class_handle;
//			internal static new IntPtr class_ref
//			{
//				get
//				{
//					return JNIEnv.FindClass("ly/img/android/sdk/operator/export/Operator$BackgroundRunner", ref java_class_handle);
//				}
//			}

//			protected override IntPtr ThresholdClass
//			{
//				get { return class_ref; }
//			}

//			protected override global::System.Type ThresholdType
//			{
//				get { return typeof(BackgroundRunner); }
//			}

//			protected BackgroundRunner(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

//			static IntPtr id_run;
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator.BackgroundRunner']/method[@name='run' and count(parameter)=0]"
//			[Register("run", "()V", "")]
//			public override sealed unsafe void Run()
//			{
//				if (id_run == IntPtr.Zero)
//					id_run = JNIEnv.GetMethodID(class_ref, "run", "()V");
//				try
//				{
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_run);
//				}
//				finally
//				{
//				}
//			}

//		}

//		// Metadata.xml XPath interface reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/interface[@name='Operator.Callback']"
//		[Register("ly/img/android/sdk/operator/export/Operator$Callback", "", "LY.Img.Android.Sdk.Operator.Export.Operator/ICallbackInvoker")]
//		public partial interface ICallback : IJavaObject
//		{

//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/interface[@name='Operator.Callback']/method[@name='onOperatorResult' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator'] and parameter[2][@type='ly.img.android.sdk.models.chunk.SourceRequestAnswerI']]"
//			[Register("onOperatorResult", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/SourceRequestAnswerI;)V", "GetOnOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_Handler:LY.Img.Android.Sdk.Operator.Export.Operator/ICallbackInvoker, PhotoEditor.Android.Binding")]
//			void OnOperatorResult(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI p1);

//		}

//		[global::Android.Runtime.Register("ly/img/android/sdk/operator/export/Operator$Callback", DoNotGenerateAcw = true)]
//		internal class ICallbackInvoker : global::Java.Lang.Object, ICallback
//		{

//			static IntPtr java_class_ref = JNIEnv.FindClass("ly/img/android/sdk/operator/export/Operator$Callback");

//			protected override IntPtr ThresholdClass
//			{
//				get { return class_ref; }
//			}

//			protected override global::System.Type ThresholdType
//			{
//				get { return typeof(ICallbackInvoker); }
//			}

//			IntPtr class_ref;

//			public static ICallback GetObject(IntPtr handle, JniHandleOwnership transfer)
//			{
//				return global::Java.Lang.Object.GetObject<ICallback>(handle, transfer);
//			}

//			static IntPtr Validate(IntPtr handle)
//			{
//				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
//					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.",
//								JNIEnv.GetClassNameFromInstance(handle), "ly.img.android.sdk.operator.export.Operator.Callback"));
//				return handle;
//			}

//			protected override void Dispose(bool disposing)
//			{
//				if (this.class_ref != IntPtr.Zero)
//					JNIEnv.DeleteGlobalRef(this.class_ref);
//				this.class_ref = IntPtr.Zero;
//				base.Dispose(disposing);
//			}

//			public ICallbackInvoker(IntPtr handle, JniHandleOwnership transfer) : base(Validate(handle), transfer)
//			{
//				IntPtr local_ref = JNIEnv.GetObjectClass(((global::Java.Lang.Object)this).Handle);
//				this.class_ref = JNIEnv.NewGlobalRef(local_ref);
//				JNIEnv.DeleteLocalRef(local_ref);
//			}

//			static Delegate cb_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_;
//#pragma warning disable 0169
//			static Delegate GetOnOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_Handler()
//			{
//				if (cb_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_ == null)
//					cb_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_OnOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_);
//				return cb_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_;
//			}

//			static void n_OnOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//			{
//				global::LY.Img.Android.Sdk.Operator.Export.Operator.ICallback __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator.ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//				global::LY.Img.Android.Sdk.Operator.Export.Operator p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(native_p0, JniHandleOwnership.DoNotTransfer);
//				global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI p1 = (global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI)global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI>(native_p1, JniHandleOwnership.DoNotTransfer);
//				__this.OnOperatorResult(p0, p1);
//			}
//#pragma warning restore 0169

//			IntPtr id_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_;
//			public unsafe void OnOperatorResult(global::LY.Img.Android.Sdk.Operator.Export.Operator p0, global::LY.Img.Android.Sdk.Models.Chunk.ISourceRequestAnswerI p1)
//			{
//				if (id_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_ == IntPtr.Zero)
//					id_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_ = JNIEnv.GetMethodID(class_ref, "onOperatorResult", "(Lly/img/android/sdk/operator/export/Operator;Lly/img/android/sdk/models/chunk/SourceRequestAnswerI;)V");
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);
//				JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onOperatorResult_Lly_img_android_sdk_operator_export_Operator_Lly_img_android_sdk_models_chunk_SourceRequestAnswerI_, __args);
//			}

//		}


//		internal static new IntPtr java_class_handle;
//		internal static new IntPtr class_ref
//		{
//			get
//			{
//				return JNIEnv.FindClass("ly/img/android/sdk/operator/export/Operator", ref java_class_handle);
//			}
//		}

//		protected override IntPtr ThresholdClass
//		{
//			get { return class_ref; }
//		}

//		protected override global::System.Type ThresholdType
//		{
//			get { return typeof(Operator); }
//		}

//		protected Operator(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

//		static IntPtr id_ctor_Lly_img_android_sdk_models_state_manager_StateHandler_Z;
//		// Metadata.xml XPath constructor reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/constructor[@name='Operator' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.models.state.manager.StateHandler'] and parameter[2][@type='boolean']]"
//		[Register(".ctor", "(Lly/img/android/sdk/models/state/manager/StateHandler;Z)V", "")]
//		public unsafe Operator(global::LY.Img.Android.Sdk.Models.State.Manager.StateHandler p0, bool p1)
//			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
//		{
//			if (((global::Java.Lang.Object)this).Handle != IntPtr.Zero)
//				return;

//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(p1);
//				if (((object)this).GetType() != typeof(Operator))
//				{
//					SetHandle(
//							global::Android.Runtime.JNIEnv.StartCreateInstance(((object)this).GetType(), "(Lly/img/android/sdk/models/state/manager/StateHandler;Z)V", __args),
//							JniHandleOwnership.TransferLocalRef);
//					global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, "(Lly/img/android/sdk/models/state/manager/StateHandler;Z)V", __args);
//					return;
//				}

//				if (id_ctor_Lly_img_android_sdk_models_state_manager_StateHandler_Z == IntPtr.Zero)
//					id_ctor_Lly_img_android_sdk_models_state_manager_StateHandler_Z = JNIEnv.GetMethodID(class_ref, "<init>", "(Lly/img/android/sdk/models/state/manager/StateHandler;Z)V");
//				SetHandle(
//						global::Android.Runtime.JNIEnv.StartCreateInstance(class_ref, id_ctor_Lly_img_android_sdk_models_state_manager_StateHandler_Z, __args),
//						JniHandleOwnership.TransferLocalRef);
//				JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)this).Handle, class_ref, id_ctor_Lly_img_android_sdk_models_state_manager_StateHandler_Z, __args);
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_getStateHandler;
//#pragma warning disable 0169
//		static Delegate GetGetStateHandlerHandler()
//		{
//			if (cb_getStateHandler == null)
//				cb_getStateHandler = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_GetStateHandler);
//			return cb_getStateHandler;
//		}

//		static IntPtr n_GetStateHandler(IntPtr jnienv, IntPtr native__this)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return JNIEnv.ToLocalJniHandle(__this.StateHandler);
//		}
//#pragma warning restore 0169

//		static IntPtr id_getStateHandler;
//		public virtual unsafe global::LY.Img.Android.Sdk.Models.State.Manager.StateHandler StateHandler
//		{
//			// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='getStateHandler' and count(parameter)=0]"
//			[Register("getStateHandler", "()Lly/img/android/sdk/models/state/manager/StateHandler;", "GetGetStateHandlerHandler")]
//			get
//			{
//				if (id_getStateHandler == IntPtr.Zero)
//					id_getStateHandler = JNIEnv.GetMethodID(class_ref, "getStateHandler", "()Lly/img/android/sdk/models/state/manager/StateHandler;");
//				try
//				{

//					if (((object)this).GetType() == ThresholdType)
//						return global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.State.Manager.StateHandler>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_getStateHandler), JniHandleOwnership.TransferLocalRef);
//					else
//						return global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Models.State.Manager.StateHandler>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "getStateHandler", "()Lly/img/android/sdk/models/state/manager/StateHandler;")), JniHandleOwnership.TransferLocalRef);
//				}
//				finally
//				{
//				}
//			}
//		}

//		static Delegate cb_add_Lly_img_android_sdk_operator_export_Operation_;
//#pragma warning disable 0169
//		static Delegate GetAdd_Lly_img_android_sdk_operator_export_Operation_Handler()
//		{
//			if (cb_add_Lly_img_android_sdk_operator_export_Operation_ == null)
//				cb_add_Lly_img_android_sdk_operator_export_Operation_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, bool>)n_Add_Lly_img_android_sdk_operator_export_Operation_);
//			return cb_add_Lly_img_android_sdk_operator_export_Operation_;
//		}

//		static bool n_Add_Lly_img_android_sdk_operator_export_Operation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker>(native_p0, JniHandleOwnership.DoNotTransfer);
//			bool __ret = __this.Add(p0);
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_add_Lly_img_android_sdk_operator_export_Operation_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='add' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operation']]"
//		[Obsolete(@"deprecated")]
//		[Register("add", "(Lly/img/android/sdk/operator/export/Operation;)Z", "GetAdd_Lly_img_android_sdk_operator_export_Operation_Handler")]
//		public virtual unsafe bool Add(global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker p0)
//		{
//			if (id_add_Lly_img_android_sdk_operator_export_Operation_ == IntPtr.Zero)
//				id_add_Lly_img_android_sdk_operator_export_Operation_ = JNIEnv.GetMethodID(class_ref, "add", "(Lly/img/android/sdk/operator/export/Operation;)Z");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				bool __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_add_Lly_img_android_sdk_operator_export_Operation_, __args);
//				else
//					__ret = JNIEnv.CallNonvirtualBooleanMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "add", "(Lly/img/android/sdk/operator/export/Operation;)Z"), __args);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_;
//#pragma warning disable 0169
//		static Delegate GetBindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_Handler()
//		{
//			if (cb_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_ == null)
//				cb_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_BindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_);
//			return cb_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_;
//		}

//		static void n_BindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker>(native_p0, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker[] p1 = (global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker));
//			__this.BindOperation(p0, p1);
//			if (p1 != null)
//				JNIEnv.CopyArray(p1, native_p1);
//		}
//#pragma warning restore 0169

//		static IntPtr id_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='bindOperation' and count(parameter)=2 and parameter[1][@type='ly.img.android.sdk.operator.export.Operation'] and parameter[2][@type='ly.img.android.sdk.operator.export.Operation...']]"
//		[Register("bindOperation", "(Lly/img/android/sdk/operator/export/Operation;[Lly/img/android/sdk/operator/export/Operation;)V", "GetBindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_Handler")]
//		public virtual unsafe void BindOperation(global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker p0, params global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker[] p1)
//		{
//			if (id_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_ == IntPtr.Zero)
//				id_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_ = JNIEnv.GetMethodID(class_ref, "bindOperation", "(Lly/img/android/sdk/operator/export/Operation;[Lly/img/android/sdk/operator/export/Operation;)V");
//			IntPtr native_p1 = JNIEnv.NewArray(p1);
//			try
//			{
//				JValue* __args = stackalloc JValue[2];
//				__args[0] = new JValue(p0);
//				__args[1] = new JValue(native_p1);

//				if (((object)this).GetType() == ThresholdType)
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_bindOperation_Lly_img_android_sdk_operator_export_Operation_arrayLly_img_android_sdk_operator_export_Operation_, __args);
//				else
//					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "bindOperation", "(Lly/img/android/sdk/operator/export/Operation;[Lly/img/android/sdk/operator/export/Operation;)V"), __args);
//			}
//			finally
//			{
//				if (p1 != null)
//				{
//					JNIEnv.CopyArray(native_p1, p1);
//					JNIEnv.DeleteLocalRef(native_p1);
//				}
//			}
//		}

//		static Delegate cb_ceiling_Lly_img_android_sdk_operator_export_Operation_;
//#pragma warning disable 0169
//		static Delegate GetCeiling_Lly_img_android_sdk_operator_export_Operation_Handler()
//		{
//			if (cb_ceiling_Lly_img_android_sdk_operator_export_Operation_ == null)
//				cb_ceiling_Lly_img_android_sdk_operator_export_Operation_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr>)n_Ceiling_Lly_img_android_sdk_operator_export_Operation_);
//			return cb_ceiling_Lly_img_android_sdk_operator_export_Operation_;
//		}

//		static IntPtr n_Ceiling_Lly_img_android_sdk_operator_export_Operation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker p0 = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker>(native_p0, JniHandleOwnership.DoNotTransfer);
//			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.Ceiling(p0));
//			return __ret;
//		}
//#pragma warning restore 0169

//		static IntPtr id_ceiling_Lly_img_android_sdk_operator_export_Operation_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='ceiling' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operation']]"
//		[Obsolete(@"deprecated")]
//		[Register("ceiling", "(Lly/img/android/sdk/operator/export/Operation;)Lly/img/android/sdk/operator/export/Operation;", "GetCeiling_Lly_img_android_sdk_operator_export_Operation_Handler")]
//		public virtual unsafe global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker Ceiling(global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker p0)
//		{
//			if (id_ceiling_Lly_img_android_sdk_operator_export_Operation_ == IntPtr.Zero)
//				id_ceiling_Lly_img_android_sdk_operator_export_Operation_ = JNIEnv.GetMethodID(class_ref, "ceiling", "(Lly/img/android/sdk/operator/export/Operation;)Lly/img/android/sdk/operator/export/Operation;");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker __ret;
//				if (((object)this).GetType() == ThresholdType)
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker>(JNIEnv.CallObjectMethod(((global::Java.Lang.Object)this).Handle, id_ceiling_Lly_img_android_sdk_operator_export_Operation_, __args), JniHandleOwnership.TransferLocalRef);
//				else
//					__ret = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.OperationInvoker>(JNIEnv.CallNonvirtualObjectMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "ceiling", "(Lly/img/android/sdk/operator/export/Operation;)Lly/img/android/sdk/operator/export/Operation;"), __args), JniHandleOwnership.TransferLocalRef);
//				return __ret;
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_release;
//#pragma warning disable 0169
//		static Delegate GetReleaseHandler()
//		{
//			if (cb_release == null)
//				cb_release = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>)n_Release);
//			return cb_release;
//		}

//		static void n_Release(IntPtr jnienv, IntPtr native__this)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			__this.Release();
//		}
//#pragma warning restore 0169

//		static IntPtr id_release;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='release' and count(parameter)=0]"
//		[Register("release", "()V", "GetReleaseHandler")]
//		public virtual unsafe void Release()
//		{
//			if (id_release == IntPtr.Zero)
//				id_release = JNIEnv.GetMethodID(class_ref, "release", "()V");
//			try
//			{

//				if (((object)this).GetType() == ThresholdType)
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_release);
//				else
//					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "release", "()V"));
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_;
//#pragma warning disable 0169
//		static Delegate GetRenderResult_Lly_img_android_sdk_operator_export_Operator_Callback_Handler()
//		{
//			if (cb_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_ == null)
//				cb_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_RenderResult_Lly_img_android_sdk_operator_export_Operator_Callback_);
//			return cb_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_;
//		}

//		static void n_RenderResult_Lly_img_android_sdk_operator_export_Operator_Callback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::LY.Img.Android.Sdk.Operator.Export.Operator.ICallback p0 = (global::LY.Img.Android.Sdk.Operator.Export.Operator.ICallback)global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator.ICallback>(native_p0, JniHandleOwnership.DoNotTransfer);
//			__this.RenderResult(p0);
//		}
//#pragma warning restore 0169

//		static IntPtr id_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='renderResult' and count(parameter)=1 and parameter[1][@type='ly.img.android.sdk.operator.export.Operator.Callback']]"
//		[Register("renderResult", "(Lly/img/android/sdk/operator/export/Operator$Callback;)V", "GetRenderResult_Lly_img_android_sdk_operator_export_Operator_Callback_Handler")]
//		public virtual unsafe void RenderResult(global::LY.Img.Android.Sdk.Operator.Export.Operator.ICallback p0)
//		{
//			if (id_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_ == IntPtr.Zero)
//				id_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_ = JNIEnv.GetMethodID(class_ref, "renderResult", "(Lly/img/android/sdk/operator/export/Operator$Callback;)V");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				if (((object)this).GetType() == ThresholdType)
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_renderResult_Lly_img_android_sdk_operator_export_Operator_Callback_, __args);
//				else
//					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "renderResult", "(Lly/img/android/sdk/operator/export/Operator$Callback;)V"), __args);
//			}
//			finally
//			{
//			}
//		}

//		static Delegate cb_setPriorityTableClass_Ljava_lang_Class_;
//#pragma warning disable 0169
//		static Delegate GetSetPriorityTableClass_Ljava_lang_Class_Handler()
//		{
//			if (cb_setPriorityTableClass_Ljava_lang_Class_ == null)
//				cb_setPriorityTableClass_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_SetPriorityTableClass_Ljava_lang_Class_);
//			return cb_setPriorityTableClass_Ljava_lang_Class_;
//		}

//		static void n_SetPriorityTableClass_Ljava_lang_Class_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//		{
//			global::LY.Img.Android.Sdk.Operator.Export.Operator __this = global::Java.Lang.Object.GetObject<global::LY.Img.Android.Sdk.Operator.Export.Operator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			global::Java.Lang.Class p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Class>(native_p0, JniHandleOwnership.DoNotTransfer);
//			__this.SetPriorityTableClass(p0);
//		}
//#pragma warning restore 0169

//		static IntPtr id_setPriorityTableClass_Ljava_lang_Class_;
//		// Metadata.xml XPath method reference: path="/api/package[@name='ly.img.android.sdk.operator.export']/class[@name='Operator']/method[@name='setPriorityTableClass' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;? extends java.lang.Enum&gt;']]"
//		[Register("setPriorityTableClass", "(Ljava/lang/Class;)V", "GetSetPriorityTableClass_Ljava_lang_Class_Handler")]
//		public virtual unsafe void SetPriorityTableClass(global::Java.Lang.Class p0)
//		{
//			if (id_setPriorityTableClass_Ljava_lang_Class_ == IntPtr.Zero)
//				id_setPriorityTableClass_Ljava_lang_Class_ = JNIEnv.GetMethodID(class_ref, "setPriorityTableClass", "(Ljava/lang/Class;)V");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(p0);

//				if (((object)this).GetType() == ThresholdType)
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setPriorityTableClass_Ljava_lang_Class_, __args);
//				else
//					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setPriorityTableClass", "(Ljava/lang/Class;)V"), __args);
//			}
//			finally
//			{
//			}
//		}

//	}
//}
