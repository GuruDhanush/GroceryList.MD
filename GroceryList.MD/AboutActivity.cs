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

namespace GroceryList.MD
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.About);

            FindViewById<Button>(Resource.Id.learnMoreButton).Click += OnLearnMoreClick;
        }

        void OnLearnMoreClick(object sender, EventArgs e)
        {
            //implicit intent
            var intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("http://bing.com"));

            if (intent.ResolveActivity(PackageManager) != null)
            {
                base.StartActivity(intent);
            }

        }
    }
}