using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Model;
using NavDrawer.Services;

namespace NavDrawer.Fragments
{
   public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected List<MainModel> mainmodel;
      protected  MenuDataServices menuDataServices;
        protected List<BookingStatusModel> bookingstats;
        protected ListView bookingstat;



        public BaseFragment()
        {
            menuDataServices = new MenuDataServices();
        }

     
        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }

        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.AvailableServiceListView);
            bookingstat = this.View.FindViewById<ListView>(Resource.Id.BookingStatusListView);
        }


    }
}