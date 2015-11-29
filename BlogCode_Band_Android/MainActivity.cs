using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Microsoft.Band.Portable;

namespace BlogCode_Band_Android {
    [Activity(Label = "Hello World Band Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            // get new instance
            var myBand = Band.Instance;

            button.Click += delegate
            {
                if (myBand != null && myBand.BandClient.IsConnected)
                    button.Text = string.Format("Connected to {0}!", myBand.Name);
                else
                    Toast.MakeText(this, "Band not yet connected or not found!", ToastLength.Long);
            };
        }
    }
}

