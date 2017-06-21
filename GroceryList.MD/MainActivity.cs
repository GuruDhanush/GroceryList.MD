using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System.Collections.Generic;

namespace GroceryList.MD
{
    [Activity(Label = "GroceryList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //items that are added to list
        public static List<Item> Items = new List<Item>();
        public static int count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);



            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Grocery List";

           

            var ItemsList = FindViewById<ListView>(Resource.Id.listView);
            var ItemsAdapter = new ItemAdapter(this);
            ItemsList.Adapter = ItemsAdapter;

            if(count == 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    Items.Add(new Item("Apple",12));
                    Items.Add(new Item("Banana", 3));
                    Items.Add(new Item("Orange", 2));
                }
            }




        }

        

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //making a toast notification
           /* Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item); */

            if(item.ItemId == Resource.Id.menu_add)
            {
                base.StartActivityForResult(typeof(AddItemActivity), 100);
                return base.OnOptionsItemSelected(item);
            }
            if(item.ItemId == Resource.Id.menu_about)
            {
                base.StartActivity(typeof(AboutActivity));
                return base.OnOptionsItemSelected(item);
            }
            else
                return base.OnOptionsItemSelected(item); 
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent Intent)
        {

            if (requestCode == 100 && resultCode == Result.Ok)
            {
                Bundle b = Intent.GetBundleExtra("UserDetails");



                string name = b.GetString("name");
                int count = b.GetInt("count", -1);

                Items.Add(new Item(name, count));

            }
        }
    }
}

