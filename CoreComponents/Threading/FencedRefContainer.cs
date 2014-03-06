using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public struct FencedRefContainer<T> : IFencedContainer<T> where T : class
    {

        T myValue;

        //public FencedRefContainer()
        //{

        //    myValue = null;

        //}

        public FencedRefContainer(T TheValue)
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
        
        public bool IsDefault
        {
            get { throw new NotImplementedException(); }
        }

    }

}
