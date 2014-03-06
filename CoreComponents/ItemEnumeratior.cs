using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public abstract class ItemEnumeratior<TType>
    {

        public ItemEnumeratior()
        {
        }

        protected abstract void WhenItem(TType Item);

        protected void Enumerate(IEnumerable Enumerator)
        {

            foreach (TType Item in Enumerator)
            {

                WhenItem(Item);

            }

        }
    }
}
