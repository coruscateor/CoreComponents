using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class ReadonlyFencedContainer<T> : IReadonlyValueContainer<T>
    {

        protected T myValue;

        public ReadonlyFencedContainer()
        {

            myValue = default(T);

        }

        public ReadonlyFencedContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public T Value
        {

            get
            {

                Thread.MemoryBarrier();

                return myValue;

            }

        }

        public bool IsDefault
        {

            get
            {

                Thread.MemoryBarrier();

                return object.Equals(myValue, default(T));

            }

        }

    }

}
