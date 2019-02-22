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

namespace LY.Img.Android.Pesdk.Backend.Model.State.Manager
{
	interface IStateListenerInterface
	{
		void OnStateChangeEvent(StateObservable observable, int @event);

	}
}