using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class FencedReferenceValueContainer<T> : IValueContainer<T> where T : class
    {

        protected T myValue;

        public FencedReferenceValueContainer()
        {
        }

        public FencedReferenceValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public virtual T Value
        {

            get
            {
                
                return Volatile.Read<T>(ref myValue);

            }
            set
            {

                Volatile.Write<T>(ref myValue, value);

            }

        }

    }

}
