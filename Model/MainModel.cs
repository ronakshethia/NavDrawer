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
    public class MainModel
    {
        public int OfferingId
        {
            get; set;
        }

        public string OfferingName
        {
            get; set;
        }

        public string ShortDescription { get; set; }


        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int Price { get; set; }

        public bool Available{ get; set; }

        public string GroupName { get; set; }

        public List<string> Includes
        {
            get;
            set;
        }

    }
}