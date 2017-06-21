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
using Android.Support.Design.Widget;


namespace GroceryList.MD
{
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddItem);

            var Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(Toolbar);
            Toolbar.Title = "Add Item";

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus_add, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //making a toast notification
            /*  Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                  ToastLength.Short).Show();
              return base.OnOptionsItemSelected(item); */

            if (item.ItemId == Resource.Id.menu_save)
            {
            
                string name = FindViewById<EditText>(Resource.Id.item).Text;
                string count = FindViewById<EditText>(Resource.Id.count).Text;
                int Count = 0; //to convert

                var view = FindViewById<View>(Resource.Id.LinearLayoutParent);
                if (string.IsNullOrWhiteSpace(name))
                {
                    Snackbar.Make(view, "text to fill", Snackbar.LengthLong).Show();
                    //Snackbar.Make(view, "Text to fill", Snackbar.LengthLong);
                   // Snackbar.Make(view, "Fill the Item Name.", Snackbar.LengthLong).SetAction("OK", (v) => { }).Show();
                    //Toast.MakeText(this, "Fill the Item Name", ToastLength.Long).Show();
                }
                else if (String.IsNullOrEmpty(count))
                {
                    Snackbar.Make(view, "Fill the Item count.", Snackbar.LengthLong).SetAction("OK", (v) => { }).Show();
                    //Toast.MakeText(this, "Fill the Item count", ToastLength.Long).Show();
                }
                else if(!int.TryParse(count, out Count))
                {
                    Snackbar.Make(view, "Please enter valid count", Snackbar.LengthLong).SetAction("OK", (v) => { }).Show();
                    //Toast.MakeText(this, "Please enter valid count", ToastLength.Long).Show();
                }
                else
                {
                    var bundle = new Bundle();
                    bundle.PutString("name", name);
                    bundle.PutInt("count", Count);

                    var intent = new Intent();
                    intent.PutExtra("UserDetails", bundle);

                    SetResult(Result.Ok, intent);
                    base.Finish();

                    Toast.MakeText(this, "Added " + count + " " + name + "'s to Grocery List", ToastLength.Long).Show();

                    
                }
                return base.OnOptionsItemSelected(item);





            }
            if (item.ItemId == Resource.Id.menu_clear)
            {
                Toast.MakeText(this, "Clearing Text is yet to be implemented", ToastLength.Long).Show();
                return base.OnOptionsItemSelected(item);
            }
            else
                return base.OnOptionsItemSelected(item);
        }

    }
}