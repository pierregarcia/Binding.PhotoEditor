using System;
using System.Collections.Generic;
using Android.Runtime;

namespace LY.Img.Android.Sdk.Utils
{
	partial class ThreadUtils
	{
		partial class WorkerThreadRunnable
		{
			[Register("run", "()V", "GetRunHandler")]
			public abstract override void Run();
		}

		partial class MainThreadRunnable
		{
			[Register ("run", "()V", "GetRunHandler")]
			public abstract override void Run();
		}
	}
}