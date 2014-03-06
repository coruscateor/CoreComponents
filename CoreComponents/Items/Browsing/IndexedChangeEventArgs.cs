using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Browsing
{
    public class IndexChangedEventArgs<S, T> : ChangeEventArgs<T, S>
    {

        int myIndex;

        public IndexChangedEventArgs(S sender, T item, int index) : base(sender, item)
        {

            myIndex = index;

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
