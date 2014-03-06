using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BareIsolatedExecutable : ISubThreadExecutable
    {

        private bool myIsActive;

        //private Thread myThread;

        public BareIsolatedExecutable()
        {
        }

        protected abstract void Main();
        
        public void Execute()
        {

            if (!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    //myThread = Thread.CurrentThread;

                    Main();

                }
                finally
                {

                    myIsActive = false;

                }

            }

            //Error!

        }

        public bool IsActive
        {

            get 
            {
                
                return myIsActive;
            
            }

        }

        //public bool IsOnThisThread
        //{

        //    get
        //    {

        //        return myThread == Thread.CurrentThread;

        //    }

        //}

    }

}
