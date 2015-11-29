using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Microsoft.Band.Portable;

namespace BlogCode_Band_Android {
    [Activity(Label = "BlogCode_Band_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                var myBand = Band.Instance;

                button.Text = string.Format("Connected to {0}!", myBand.Name);
            };
        }
    }
}

