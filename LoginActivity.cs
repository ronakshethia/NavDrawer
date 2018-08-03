using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NavDrawer
{
    [Activity(Label = "LoginActivity", MainLauncher = true, NoHistory = true)]
    public class LoginActivity : AppCompatActivity, View.IOnClickListener, GoogleApiClient.IOnConnectionFailedListener
    {
        TextView register;
        Button login;
        Button google;
        Button signout;
      public static GoogleApiClient mgoogleApiClient;


        const int RC_SIGN_IN = 9001;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            // Create your application here

            register = FindViewById<TextView>(Resource.Id.link_signup);
          //  google = FindViewById<TextView>(Resource.Id.google_button);

            login = FindViewById<Button>(Resource.Id.btn_login);
           // signout = FindViewById<Button>(Resource.Id.logout);
            register.Click += OnClickedEvent;
             login.Click += OnLoginEvent;
            // Create your application here
            FindViewById(Resource.Id.google_button).SetOnClickListener(this);
           // FindViewById(Resource.Id.logout).SetOnClickListener(this);
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestEmail()
                .Build();

            mgoogleApiClient = new GoogleApiClient.Builder(this)
                    .EnableAutoManage(this /* FragmentActivity */, this /* OnConnectionFailedListener */)
                    .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                    .Build();
        }


        protected override void OnStart()
        {
            base.OnStart();

            var opr = Auth.GoogleSignInApi.SilentSignIn(mgoogleApiClient);
            if (opr.IsDone)
            {
                // If the user's cached credentials are valid, the OptionalPendingResult will be "done"
                // and the GoogleSignInResult will be available instantly.
                //Log.Debug(TAG, "Got cached sign-in");
                var result = opr.Get() as GoogleSignInResult;
                HandleSignInResult(result);
            }
            else
            {
                // If the user has not previously signed in on this device or the sign-in has expired,
                // this asynchronous branch will attempt to sign in the user silently.  Cross-device
                // single sign-on will occur in this branch.
             //   ShowProgressDialog();
                opr.SetResultCallback(new SignInResultCallback { Activity = this });
            }
        }

        public void HandleSignInResult(GoogleSignInResult result)
        {
     //       Log.Debug(TAG, "handleSignInResult:" + result.IsSuccess);
            if (result.IsSuccess)
            {
                // Signed in successfully, show authenticated UI.
                var acct = result.SignInAccount;
                var homepage = new Intent(this, typeof(MainActivity));
                // StartActivity(typeof(MainActivity));
                homepage.PutExtra("UserName", acct.DisplayName);

                string picurl;
                if(acct.PhotoUrl==null)
                {
                    picurl = "http://icons.iconarchive.com/icons/icons8/android/512/Messaging-Question-icon.png";
                }
                else
                {
                    picurl = acct.PhotoUrl.ToString();
                }
                
                homepage.PutExtra("UserPic", picurl);  
            //    Bundle bundle = new Bundle();
              //  bundle.PutString("UserPic", acct.PhotoUrl.ToString());
              //  bundle.PutString("UserName", acct.DisplayName);
                Intent.PutExtras(homepage);
                StartActivity(homepage);
                Finish();
             //   Finish();
                //  mStatusTextView.Text = string.Format(GetString(Resource.String.signed_in_fmt), acct.DisplayName);
                //   UpdateUI(true);
            }
            else
            {
                // Signed out, show unauthenticated UI.
               // UpdateUI(false);
            }
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
           // Log.Debug(TAG, "onActivityResult:" + requestCode + ":" + resultCode + ":" + data);

            // Result returned from launching the Intent from GoogleSignInApi.getSignInIntent(...);
            if (requestCode == RC_SIGN_IN)
            {
                var result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                HandleSignInResult(result);
            }
        }

        private void OnLoginEvent(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        private void OnClickedEvent(object sender, EventArgs e)
        {
            StartActivity(typeof(SignupActivity));
            Finish();
        }


        void SignIn()
        {
            var signInIntent = Auth.GoogleSignInApi.GetSignInIntent(mgoogleApiClient);
            StartActivityForResult(signInIntent, RC_SIGN_IN);
        }


        public void OnClick(View v)
        {
            SignIn();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            
        }
    }
}