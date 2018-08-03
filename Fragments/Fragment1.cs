using System;

using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;

namespace NavDrawer.Fragments
{
    public class Fragment1 : Fragment
    {
        BottomNavigationView bottomNavigation;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
           // bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            //bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
        }

        


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment1, container, false);
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            Fragment f = null;
            f= new HairListFragment();
            ft.Add(Resource.Id.content_frame2,f).Commit();
          
            bottomNavigation = view.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            return view;
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }


        void LoadFragment(int id)
        {
           Fragment fragment = null;

            switch (id)
            {
                case Resource.Id.menu_home:
                    Fragment s = new HairListFragment();
                    fragment = s;
                    break;
                case Resource.Id.menu_audio:
                   fragment = BookingStatusListFragment.NewInstance();
                    break;
                case Resource.Id.menu_video:
                    fragment = Fragment4.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

            FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame2, fragment).Commit();
         //   Activity.SupportFragmentManager.BeginTransaction().Remove(fragment);


            //Activity.SupportFragmentManager.BeginTransaction()
            //  .Add(Resource.Id.content_frame, fragment)
            //  .Commit();
        }

        public static Fragment1 NewInstance()
        {
            var frag1 = new Fragment1 { Arguments = new Bundle() };
            return frag1;
        }


        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    var ignored = base.OnCreateView(inflater, container, savedInstanceState);
        //    return inflater.Inflate(Resource.Layout.fragment1, null);
        //}
    }
}