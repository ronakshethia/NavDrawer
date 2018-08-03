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
using NavDrawer.Model;

namespace NavDrawer.Adapters
{
   public class BookingStatusListAdapter : BaseAdapter<BookingStatusModel>
    {
        List<BookingStatusModel> statusList;
        Activity context;


        public BookingStatusListAdapter(Activity _context, List<BookingStatusModel> _statusList) : base()
        {
            this.context = _context;
            this.statusList = _statusList;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override BookingStatusModel this[int position]
        {
            get
            {
                return statusList[position];
            }
        }


        public override int Count
        {
            get
            {
                return  statusList.Count;
            }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = statusList[position];
             if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BookingStatusLayout, null);
            }

           convertView.FindViewById<TextView>(Resource.Id.BookingIdTextView).Text = item.BookingId;
            convertView.FindViewById<TextView>(Resource.Id.BookingDateTextview).Text = item.BookingDate;
            convertView.FindViewById<TextView>(Resource.Id.BookingTimeTextview).Text = item.BookingTime;
            convertView.FindViewById<TextView>(Resource.Id.PaymentModeTextview).Text = item.PaymentMode;
            convertView.FindViewById<TextView>(Resource.Id.BookingAmountTextview).Text = item.Amount;
            convertView.FindViewById<TextView>(Resource.Id.BookingServiceTextview).Text = item.ServiceChoosen;
            convertView.FindViewById<TextView>(Resource.Id.StatusTextview).Text = item.status;

            return convertView;
        }
       
   }
}