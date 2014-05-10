using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class IndexChangedEventArgs<TSender, TItem> : ChangeEventArgs<TItem, TSender>
    {

        int myIndex;

        public IndexChangedEventArgs(TSender Sender, TItem Item, int Index) : base(Sender, Item)
        {

            myIndex = Index;

        }

        public int Index
        {

            get
            {

                return myIndex;

            }

        }

    }

}
