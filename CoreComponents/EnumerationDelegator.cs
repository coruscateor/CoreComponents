using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class EnumerationDelegator<TType>
    {

        protected Action<TType> myDelegate;

        public EnumerationDelegator(Action<TType> TheDelegate)
        {

            myDelegate = TheDelegate;

        }

        public Action<TType> Delegate
        {

            get
            {

                return myDelegate;

            }

            set
            {

                myDelegate = value;

            }

        }

        public virtual void Enumerate(IEnumerable<TType> Enumerator)
        {

            foreach (TType Item in Enumerator)
            {

                myDelegate(Item);

            }

        }

    }

}
