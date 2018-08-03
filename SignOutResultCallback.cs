using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
   public class SignOutResultCallback : Java.Lang.Object, IResultCallback
    {
        public MainActivity Activity { get; set; }

        public void OnResult(Java.Lang.Object result)
        {
          //  Activity.UpdateUI(false);
        }
    }
}