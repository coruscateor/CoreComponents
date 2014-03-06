using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedAppDomain : ISubThread
    {

        private AppDomain myAppDomian;

        private bool myIsActive;

        private bool myStopRequested;

        //private static ConcurrentLazyObject<Random> myLazyRandomObject;

        public BaseIsolatedAppDomain()
        {

            //string TheName = "AppDomain" + myLazyRandomObject.Object.Next();

            string TheName = "AppDomain_" + Environment.TickCount; 

            myAppDomian = AppDomain.CreateDomain(TheName, null);

        }

        public BaseIsolatedAppDomain(string TheName)
        {

            myAppDomian = AppDomain.CreateDomain(TheName, null);
            
        }

        protected abstract void ThreadMain();

        //New Thread Starts here!
        private void RunThreadMain()
        {

            System.Threading.Thread.MemoryBarrier();

            if(!myIsActive)
            {

                System.Threading.Thread.MemoryBarrier();

                if(!myStopRequested)
                {

                    try
                    {

                        myIsActive = true;

                        System.Threading.Thread.MemoryBarrier();

                        if (!myStopRequested)
                            ThreadMain();

                    }
                    finally
                    {

                        myIsActive = false;

                        System.Threading.Thread.MemoryBarrier();

                        if(myStopRequested)
                        {

                            myStopRequested = false;

                            System.Threading.Thread.MemoryBarrier();

                        }

                    }

                }
                else
                {

                    myStopRequested = false;

                    System.Threading.Thread.MemoryBarrier();

                }

            }
            
        }

        public void Start()
        {

            System.Threading.Thread.MemoryBarrier();

            if(!myIsActive)
            {

                System.Threading.Thread.MemoryBarrier();

                if(myStopRequested)
                {

                    myStopRequested = false;

                    System.Threading.Thread.MemoryBarrier();

                }

                myAppDomian.DoCallBack(RunThreadMain);
                
            }

        }

        //public AppDomain TheAppDomain
        //{

        //    get
        //    {

        //        return myAppDomian;

        //    }

        //}

        public bool IsActive
        {

            get
            {

                System.Threading.Thread.MemoryBarrier();

                return myIsActive;

            }

        }

        public void Stop()
        {

            System.Threading.Thread.MemoryBarrier();

            bool CurrentlyActive = myIsActive;

            System.Threading.Thread.MemoryBarrier();

            bool CurrentlyStopRequested = myStopRequested;

            if(!CurrentlyActive && !CurrentlyStopRequested)
            {

                myStopRequested = true;

                System.Threading.Thread.MemoryBarrier();

            }

        }

        public bool StopRequested
        {

            get 
            {

                System.Threading.Thread.MemoryBarrier();

                return myStopRequested; 
            
            }

        }

        //public long MonitoringTotalAllocatedMemorySize
        //{


        //    get
        //    {

        //        return myAppDomian.MonitoringTotalAllocatedMemorySize;

        //    }
 
        //}

        //public TimeSpan MonitoringTotalProcessorTime
        //{

        //    get
        //    {

        //        return myAppDomian.MonitoringTotalProcessorTime;

        //    }

        //}

    }

}
