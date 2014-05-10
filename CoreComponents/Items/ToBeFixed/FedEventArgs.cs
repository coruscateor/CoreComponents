using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public class FedEventArgs<T, Sender> : SenderEventArgs<Sender>
    {

        T feditem;
        T droppeditem;

        public FedEventArgs(Sender sender, T feditem, T droppeditem) : base(sender)
        {

            this.feditem = feditem;
            this.droppeditem = droppeditem;

        }

        public T FedItem
        {

            get
            {

                return feditem;

            }

        }

        public T DroppedItem
        {

            get
            {

                return droppeditem;

            }

        }

    }
}
