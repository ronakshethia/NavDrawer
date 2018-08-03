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

namespace NavDrawer.Repository
{
   public class ServiceOfferingRepository
    {
        public List<MainModel> GetAllServices()
        {

            IEnumerable<MainModel> servicesoffers =
                from serviceGroup in ServicesOfferGroups
                from sergroup in serviceGroup.mainModel
                select sergroup;
            return servicesoffers.ToList<MainModel>();

        }






        private static List<OfferingServiceGroup> ServicesOfferGroups = new List<OfferingServiceGroup>()
        {
            new OfferingServiceGroup()
            {
                OfferingGroupId=1,
                Title ="Hair",
                ImagePath ="",
                mainModel= new List<MainModel>()
                {
                    new MainModel()
                    {
                        OfferingId =1,
                        ShortDescription ="Hair Cut",
                        Price = 50,
                        Available = true,
                        Includes = new List<string>(){"Finger Cut", "Round Cut" }
                    },
                     new MainModel()
                    {
                        OfferingId =2,
                        ShortDescription ="Long Hair Cut",
                        Price = 100,
                        Available = true,
                        Includes = new List<string>(){"Long Finger Cut", "Shampoo Cut" }
                    },

                }

            }


        };

        }
}