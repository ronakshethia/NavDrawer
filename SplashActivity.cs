﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    [Activity(Label = "SplashActivity",Icon ="@drawable/icon",Theme ="@style/Theme.Splash" ,MainLauncher = true, NoHistory =true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splashLayout);


            
            StartActivity(typeof(LoginActivity));
            // Create your application here
        }
    }
}