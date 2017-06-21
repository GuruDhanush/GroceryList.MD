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
    class ItemAdapter : BaseAdapter<Item>
    {

        Context context;

        public ItemAdapter(Context context)
        {
            this.context = context;

            //using Items Static list in MainActivity 
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        //int count; for checking working of layout reuse
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ItemAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ItemAdapterViewHolder;

            if (holder == null)
            {
                //count++;
                holder = new ItemAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.ItemsListViewRow, parent, false);
                holder.Item = view.FindViewById<TextView>(Resource.Id.nameTextView);
                holder.Count = view.FindViewById<TextView>(Resource.Id.countTextView);
                view.Tag = holder;
            }


            //fill in your items
            
            holder.Item.Text = MainActivity.Items[position].Name;
            holder.Count.Text = MainActivity.Items[position].Count.ToString();

            return view;
        }

        //Fill in count here, currently 0
        public override int Count
        {
            get
            {
                return MainActivity.Items.Count;
            }
        }

        public override Item this[int position]
        {
            get
            {
                return MainActivity.Items[position];
            }
        }
    }

    class ItemAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Item { get; set; }
        public TextView Count { get; set; }
    }
}