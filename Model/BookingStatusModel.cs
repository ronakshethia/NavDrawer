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

namespace NavDrawer.Model
{
   public class BookingStatusModel
    {
        public string BookingId { get; set; }

        public string BookingDate { get; set; }

        public string ServiceChoosen { get; set; }

        public string BookingTime { get; set; }

        public string Amount { get; set; }

        public string PaymentMode { get; set; }

        public string status { get; set; }      

    }
}