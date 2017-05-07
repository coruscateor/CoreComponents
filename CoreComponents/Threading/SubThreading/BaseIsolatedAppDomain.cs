using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedAppDomain : IIsolatedThread //<TID>
    {

        private AppDomain myAppDomian;

        private bool myIsActive;

        private bool myStopRequested;

        private Exception myException;

        //private readonly TID myId;

        private object myLockObject;

        //public BaseIsolatedAppDomain(TID TheId)
        //{

        //    myAppDomian = AppDomain.CreateDomain(GetDefaultName(), null);

        //    myId = TheId;

        //    myLockObject = new object();

        //}

        //public BaseIsolatedAppDomain(TID TheId, string TheName)
        //{

        //    myAppDomian = AppDomain.CreateDomain(TheName, null);

        //    myId = TheId;

        //    myLockObject = new object();

        //}

        //public BaseIsolatedAppDomain(TID TheId, object LObj)
        //{

        //    myAppDomian = AppDomain.CreateDomain(GetDefaultName(), null);

        //    myId = TheId;

        //    myLockObject = LObj;

        //}

        //public BaseIsolatedAppDomain(TID TheId, string TheName, object LObj)
        //{

        //    myAppDomian = AppDomain.CreateDomain(TheName, null);

        //    myId = TheId;

        //    myLockObject = LObj;

        //}

        public BaseIsolatedAppDomain()
        {

            myAppDomian = AppDomain.CreateDomain(GetDefaultName(), null);

            myLockObject = new object();

        }

        public BaseIsolatedAppDomain(string TheName)
        {

            myAppDomian = AppDomain.CreateDomain(TheName, null);

            myLockObject = new object();

        }

        public BaseIsolatedAppDomain(object LObj)
        {

            myAppDomian = AppDomain.CreateDomain(GetDefaultName(), null);

            myLockObject = LObj;

        }

        public BaseIsolatedAppDomain(string TheName, object LObj)
        {

            myAppDomian = AppDomain.CreateDomain(TheName, null);

            myLockObject = LObj;

        }

        //public TID Id
        //{

        //    get
        //    {

        //        return myId;

        //    }

        //}

        public Exception Exception
        {

            get
            {

                lock(myLockObject)
                {

                    return myException;

                }

            }

        }

        public bool TryGetException(out Exception Ex)
        {

            lock(myLockObject)
            {

                Ex = myException;

            }

            return Ex != null;

        }

        public bool HasException
        {

            get
            {

                lock(myLockObject)
                {

                    return myException != null;

                }

            }

        }

        private static string GetDefaultName()
        {

            return "AppDomain_" + Environment.TickCount; 

        }

        protected abstract void ThreadMain();

        //New Thread Starts here!
        private void RunThreadMain()
        {

            bool CurrentIsActive;

            bool CurrentStopRequested;

            lock(myLockObject)
            {

                CurrentIsActive = myIsActive;

                CurrentStopRequested = myStopRequested;

            }

            if(!CurrentIsActive)
            {

                if(!CurrentStopRequested)
                {

                    try
                    {

                        if(!CurrentStopRequested)
                        {

                            lock(myLockObject)
                            {

                                myIsActive = true;

                            }

                            try
                            {

                                ThreadMain();

                            }
                            catch(Exception Ex)
                            {

                                lock(myLockObject)
                                {

                                    myException = Ex;

                                }

                            }

                        }

                    }
                    finally
                    {

                        lock(myLockObject)
                        {

                            myIsActive = false;

                            if(myStopRequested)
                            {

                                myStopRequested = false;

                            }

                        }

                    }

                }
                else
                {

                    lock(myLockObject)
                    {

                        myStopRequested = false;

                    }

                }

            }
            
        }

        public void Start()
        {

            bool CurrentIsActive;

            bool CurrentStopRequested;

            lock(myLockObject)
            {

                CurrentIsActive = myIsActive;

                CurrentStopRequested = myStopRequested;

            }

            if(!CurrentIsActive)
            {

                if(CurrentStopRequested)
                {

                    lock(myLockObject)
                    {

                        myStopRequested = false;

                        return;

                    }

                }

                myAppDomian.DoCallBack(RunThreadMain);
                
            }

        }
        
        public bool IsActive
        {

            get
            {

                lock(myLockObject)
                {

                    return myIsActive;

                }

            }

        }

        public void Stop()
        {

            bool CurrentlyActive;

            bool CurrentlyStopRequested;

            lock(myLockObject)
            {

                CurrentlyActive = myIsActive;

                CurrentlyStopRequested = myStopRequested;

            }

            if(!CurrentlyActive && !CurrentlyStopRequested)
            {

                lock(myLockObject)
                {

                    myStopRequested = true;

                }

            }

        }

        public bool StopRequested
        {

            get 
            {

                lock(myLockObject)
                {

                    return myStopRequested;

                }

            }

        }

        public long MonitoringTotalAllocatedMemorySize
        {

            get
            {

                return myAppDomian.MonitoringTotalAllocatedMemorySize;

            }

        }

        public TimeSpan MonitoringTotalProcessorTime
        {

            get
            {

                return myAppDomian.MonitoringTotalProcessorTime;

            }

        }

    }

}
