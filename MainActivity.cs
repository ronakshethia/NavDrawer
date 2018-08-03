using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;

using NavDrawer.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Webkit;
using NavDrawer.Customs;
using System;
using NavDrawer.Utility;
using Refractored.Controls;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;

namespace NavDrawer
{
    [Activity(Label = "@string/app_name", MainLauncher = false, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {

        DrawerLayout drawerLayout;
        NavigationView navigationView;
        Toolbar toolbars;
        Android.Widget.TextView usrnametext;
        IMenuItem previousItem;
        GoogleApiClient googleApiClient;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
           // usrnametext.SetText(5);
            SetContentView(Resource.Layout.main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbars = FindViewById<Toolbar>(Resource.Id.toolbarnew);
           
            // var dd = FindViewById<Android.Widget.TextView>(Resource.Id.usrnaming);
            toolbars.SetTitle(Resource.String.fragment1);
            // toolbar.SetTitle(Resource.String.abc_action_bar_home_description);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                if (previousItem != null)
                    previousItem.SetChecked(false);

                navigationView.SetCheckedItem(e.MenuItem.ItemId);

                previousItem = e.MenuItem;

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home_1:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.special_offer:
                        ListItemClicked(1);
                        break;
                    case Resource.Id.booking_status:
                        ListItemClicked(2);
                        break;
                    case Resource.Id.issue_booking:
                        ListItemClicked(3);
                        break;
                    case Resource.Id.store:
                        ListItemClicked(4);
                        break;
                    case Resource.Id.about_us:
                        ListItemClicked(5);
                        break;
                    case Resource.Id.acc_settings:
                        ListItemClicked(6);
                        break;
                    case Resource.Id.logout:
                        ListItemClicked(7);
                        break;
                }


                drawerLayout.CloseDrawers();
            };


            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                navigationView.SetCheckedItem(Resource.Id.nav_home_1);
                ListItemClicked(0);
            }
            NavigationView navigationVieww = (NavigationView)FindViewById(Resource.Id.nav_view);
            View headerView = navigationVieww.GetHeaderView(0);
            Android.Widget.TextView navUsername = (Android.Widget.TextView)headerView.FindViewById(Resource.Id.usrnaming);
            CircleImageView userimage = (CircleImageView)headerView.FindViewById(Resource.Id.icon);          
            string usrnme = Intent.GetStringExtra("UserName") ??"Unknow User Name";
            string imageurl = Intent.GetStringExtra("UserPic")?? "http://icons.iconarchive.com/icons/icons8/android/512/Messaging-Question-icon.png";
          var image =  ImageHelper.GetImageBitmapFromUrl(imageurl);
            userimage.SetImageBitmap(image);
            navUsername.Text = "Hello, "+usrnme;
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = Fragment1.NewInstance();
                    break;
                case Resource.Id.menu_audio:
                    fragment = Fragment2.NewInstance();
                    break;
                    
                // case Resource.Id.menu_video:
                //     fragment = Fragment3.NewInstance();
                //    break;
             
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }


        int oldPosition = -1;
        private void ListItemClicked(int position)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (position == oldPosition)
                return;

            oldPosition = position;

            Android.Support.V4.App.Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = Fragment1.NewInstance();
                    break;
                case 1:
                    fragment = Fragment2.NewInstance();
                    break;
                case 2:
                    fragment = BookingStatusListFragment.NewInstance();
                    break;
                
                case 7:
                    Auth.GoogleSignInApi.SignOut(googleApiClient).SetResultCallback(new SignOutResultCallback { Activity = this });
                     LoginActivity.mgoogleApiClient.Disconnect();
                    


            StartActivity(typeof(LoginActivity));
                    Finish();
                    break;
                
            }
            if (position != 7 && fragment!=null)
            {
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, fragment)
                    .Commit();
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
                //case Resource.Id.miCompose:

                 //   return true;
          //      case Resource.Id.miProfile:
              //      return true;
             }

           

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // return base.OnCreateOptionsMenu(menu);
            MenuInflater.Inflate(Resource.Menu.actionmenu, menu);
            // var dd = menu.FindItem(Resource.Id.icon_group);
            IMenuItem item = menu.FindItem(Resource.Id.ic_group);
            LayerDrawable icon = item.Icon as LayerDrawable;
            
            // LayerDrawable icon = (LayerDrawable)item.Icon;
            CountDrawable badge;
            Drawable reuse = icon.FindDrawableByLayerId(Resource.Id.ic_group_count);
            if (reuse != null && reuse is CountDrawable)
            {
                badge = (CountDrawable)reuse;
            }
            else
            {
                badge = new CountDrawable(this);

            }
            badge.setCount("8");
            badge.GetBounds=icon.Bounds;
            
            icon.Mutate();
            icon.SetDrawableByLayerId(Resource.Id.ic_group_count, badge);
            return true;
        }

        //public override bool OnPrepareOptionsMenu(IMenu menu)
        //{
        //    // MenuInflater.Inflate(Resource.Id.icon_group, menu);
        
        //}

        public void setCount(Context context, string count)
        {
            
            var menuItem = (Resource.Id.icon_group);
        //    Drawable icon = (Drawable)menuItem.
        }

        protected override void OnStart()
        {
            
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
            .RequestEmail()
            .Build();
            googleApiClient = new GoogleApiClient.Builder(this)
                    .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                    .Build();
            googleApiClient.Connect();

            base.OnStart();
        }


        void signOut()
        {

        }


        public void OnClick(View v)
        {
            signOut();
        }
    }
}

