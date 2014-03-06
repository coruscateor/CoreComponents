using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class ReadonlyFencedRefContainer<T> : IReadonlyValueContainer<T> where T : class
    {

        protected T myValue;

        public ReadonlyFencedRefContainer()
        {

            myValue = null;

        }

        public ReadonlyFencedRefContainer(T TheValue)
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

        public bool IsNull
        {

            get
            {

                Thread.MemoryBarrier();

                return myValue == null;

            }

        }

        public bool TryGetValue(out T TheValue)
        {

            Thread.MemoryBarrier();

            if(myValue != null)
            {

                //The myValue field may be out of date here but we've already confimed that it is not null at this point so we can't set TheValue to null and return true.

                TheValue = myValue;

                return true;

            }

            TheValue = null;

            return false;


        }

    }

}
