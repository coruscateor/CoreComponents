using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class FencedValueContainer<T> : IFencedContainer<T> 
    {

        protected T myValue;

        public FencedValueContainer()
        {

            myValue = default(T);

        }

        public FencedValueContainer(T TheValue)
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
            set
            {

                myValue = value;

                Thread.MemoryBarrier();

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

        public bool ComapreSet(ref T TheValue)
        {

            Thread.MemoryBarrier();

            if(!object.Equals(myValue, TheValue))
            {

                myValue = TheValue;

                Thread.MemoryBarrier();

                return true;

            }

            return false;

        }

        public bool ComapreSwap(ref T TheValue)
        {

            Thread.MemoryBarrier();

            if(!object.Equals(myValue, TheValue))
            {

                T TempValue = myValue;

                myValue = TheValue;

                myValue = TempValue;

                Thread.MemoryBarrier();

                return true;

            }

            return false;

        }

    }

}
