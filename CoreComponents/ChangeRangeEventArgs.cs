using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type Altered in the collection</typeparam>
    /// <typeparam name="S">The type of the emmiting object</typeparam>

    public class ChangeRangeEventArgs<T, S> : SenderEventArgs<S>, IEnumerable<T>, IEnumerable
    {

        IEnumerable<T> items;

        public ChangeRangeEventArgs(S sender, IEnumerable<T> items) : base(sender)
        {

            this.items = items;
            
        }

        public IEnumerable<T> Items
        {
            get
            {

                return items;

            }


        }

        public override S Sender
        {

            get
            {

                return mySender;

            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
