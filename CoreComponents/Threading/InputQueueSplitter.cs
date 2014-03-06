using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class InputQueueSplitter<T> : IInputQueue<T>
    {

        protected IInputQueue<T> myQ1;

        protected IInputQueue<T> myQ2;

        public InputQueueSplitter(IInputQueue<T> Q1, IInputQueue<T> Q2)
        {

            myQ1 = Q1;

            myQ2 = Q2;

        }

        public void Enqueue(T TheItem)
        {

            myQ1.Enqueue(TheItem);

            myQ2.Enqueue(TheItem);

        }

        public int Count
        {

            get
            {
                
                return myQ1.Count;
            
            }

        }

        public bool IsEmpty
        {

            get
            {
 
                return myQ1.IsEmpty;
            
            }

        }

        public int Count2
        {

            get
            {

                return myQ2.Count;

            }

        }

        public bool IsEmpty2
        {

            get
            {

                return myQ2.IsEmpty;

            }

        }

    }

}
