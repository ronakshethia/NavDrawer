using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Adapters;
using NavDrawer.Model;

namespace NavDrawer.Fragments
{
   public class BookingStatusListFragment : BaseFragment
    {
       // ListView bookingstats;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
           // 
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
             FindViews();
            // HandleEvents();
            //   mainmodel = menuDataServices.GetAllServiceMenu();

            //  listView.Adapter = new OfferingsListAdapter(this.Activity, mainmodel);
            
            List<BookingStatusModel> list = new List<BookingStatusModel>();
            list.Add(new BookingStatusModel { BookingId = "12345678", BookingDate = DateTime.Now.ToShortDateString(), Amount = "900", BookingTime = DateTime.Now.ToShortTimeString(), PaymentMode = "Cash", ServiceChoosen = "Basic Haircut", status = "Pending"
            });
            list.Add(new BookingStatusModel
            {
                BookingId = "12558725",
                BookingDate = DateTime.Now.ToShortDateString(),
                Amount = "100",
                BookingTime = DateTime.Now.ToShortTimeString(),
                PaymentMode = "Net Banking",
                ServiceChoosen = "Hair Spa",
                status = "Approved"
            });
            list.Add(new BookingStatusModel
            {
                BookingId = "12558795",
                BookingDate = DateTime.Now.ToShortDateString(),
                Amount = "400",
                BookingTime = DateTime.Now.ToShortTimeString(),
                PaymentMode = "Credit Card",
                ServiceChoosen = "Hair Color",
                status = "Cancelled"
            });
            //new BookingStatusModel { BookingId = "12558725", BookingDate = DateTime.Today.Date, Amount = "100", BookingTime = Convert.ToDateTime("10:50"), PaymentMode = "Net Banking", ServiceChoosen = "Hair Spa", status = "Approved" }
            //);
            //BookingStatusModel bookingStatusModel = new BookingStatusModel {

            //   bookingStatusModel.BookingId = "123456789";
            //list.Add(bookingStatusModel);
            // TextView textView = new TextView(Context);
            // //textView.Text = "Hello M Header";
            //    bookingstat.AddHeaderView(textView);

            bookingstat.Adapter = new BookingStatusListAdapter(this.Activity, list);
        }
        public static BookingStatusListFragment NewInstance()
        {
            var frag2 = new BookingStatusListFragment { Arguments = new Bundle() };
            return frag2;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            
            return inflater.Inflate(Resource.Layout.BookingStatusListview, null);
        }

    }
}