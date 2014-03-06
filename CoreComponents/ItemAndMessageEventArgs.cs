using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class ItemAndMessageEventArgs<TSender, TItem> : ItemEventArgs<TSender, TItem>, IHasMessage
    {

        protected string myContents;

        public ItemAndMessageEventArgs(TSender sender, TItem Item, string theContents)
            : base(sender, Item)
        {

            myContents = theContents;

        }

        public string Contents
        {

            get
            {

                return myContents;

            }

        }

    }
}
