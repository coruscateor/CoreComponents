using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class FencedValueContainer<T> : IValueContainer<T>
    {

        protected T myValue;

        public FencedValueContainer()
        {
        }

        public FencedValueContainer(T TheValue)
        {

            myValue = TheValue;

        }
        
        public virtual T Value
        {

            get
            {

                Thread.MemoryBarrier();

                T TheValue = myValue; 

                return TheValue;

            }
            set
            {

                myValue = value;

                Thread.MemoryBarrier();

            }

        }

    }

}
