using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace NavDrawer
{
    public class SignInResultCallback : Java.Lang.Object, IResultCallback
    {
        public LoginActivity Activity { get; set; }
        public void OnResult(Java.Lang.Object result)
        {
            var googleSignInResult = result as GoogleSignInResult;
            //  Activity.HideProgressDialog();
            Activity.HandleSignInResult(googleSignInResult);
        }
    }
}