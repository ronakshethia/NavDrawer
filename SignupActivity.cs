using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    [Activity(Label = "SignupActivity", NoHistory = true)]
    public class SignupActivity : AppCompatActivity
    {
        TextView linklogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_signup);
            // Create your application here
            linklogin = FindViewById<TextView>(Resource.Id.link_loginn);
            linklogin.Click += DisplayLogin;
        }

        private void DisplayLogin(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
            Finish();
        }
    }
}