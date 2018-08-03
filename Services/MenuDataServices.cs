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
using NavDrawer.Repository;

namespace NavDrawer.Services
{
   public class MenuDataServices
    {
        private static ServiceOfferingRepository serviceOfferingRepository = new ServiceOfferingRepository();
        public List<MainModel> GetAllServiceMenu()
        {
            return serviceOfferingRepository.GetAllServices();
        }

    }
}