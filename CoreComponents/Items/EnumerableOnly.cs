using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class EnumerableOnly<T> : IEnumerable<T>
    {

        readonly IEnumerable<T> myItems;

        public EnumerableOnly()
        {

            myItems = new T[0];

        }

        public EnumerableOnly(IEnumerable<T> theItems, bool copy = false)
        {

            if(copy)
                myItems = theItems.ToArray();
            else
                myItems = theItems;

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

    }

}
