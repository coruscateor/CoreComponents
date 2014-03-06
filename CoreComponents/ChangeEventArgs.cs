using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents
{
    public class ChangeEventArgs<T, S> : SenderEventArgs<S>
    {

        T myItem;

        public ChangeEventArgs(S sender, T Item) : base(sender)
        {

            myItem = Item;

        }

        public T Item
        {

            get
            {

                return myItem;

            }

        }

        /*
        public override S Sender
        {

            get
            {

                return mySender;

            }

        }
        */
    }
}
