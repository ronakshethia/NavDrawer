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
using NavDrawer.Utility;

namespace NavDrawer.Adapters
{
   public class OfferingsListAdapter : BaseAdapter<MainModel>
    {
        List<MainModel> items;
        Activity context;
        public OfferingsListAdapter(Activity context, List<MainModel> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override MainModel this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
             //var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg");

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ServiceListRowView, null);
            }
           convertView.FindViewById<TextView>(Resource.Id.ServiceNameTextView).Text = item.OfferingName;
           convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
         convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
       //  convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);

            return convertView;

        }
        }
}