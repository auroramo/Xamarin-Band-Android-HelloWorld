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

using Microsoft.Band.Portable;

namespace BlogCode_Band_Android {
    class Band {
        private static Band BandDevice;
        public BandClient BandClient { get; set; }
        public String Name { get; set; }

        private Band() {

        }

        private async void PairBand() {
            var bandClientManager = BandClientManager.Instance;
            var bandsFound = await bandClientManager.GetPairedBandsAsync();

            if (bandsFound != null && bandsFound.Count() == 1)
            {
                var bandFound = bandsFound.FirstOrDefault();
                BandDevice.BandClient = await bandClientManager.ConnectAsync(bandFound);
                BandDevice.Name = bandFound.Name;
            }
        }

        public static Band Instance {
            get {
                if (BandDevice == null)
                {
                    BandDevice = new Band();
                    BandDevice.PairBand();
                }
                return BandDevice;
            }
        }
    }
}