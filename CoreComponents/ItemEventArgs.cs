using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class ItemEventArgs<TSender, TItem> : SenderEventArgs<TSender>
    {

        protected TItem myItem;

        public ItemEventArgs(TSender sender, TItem Item) : base(sender)
        {

            myItem = Item;

        }

        public TItem Item
        {

            get
            {

                return myItem;

            }

        }

    }
}
