using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedWorkerThread : IIsolatedThread
    {

        private bool myIsActive;

        private bool myStopRequested;

        private Exception myException;

        private bool myIsContinuing;

        private object myLockObject;

        public BaseIsolatedWorkerThread()
        {

            myLockObject = new object();

        }

        public BaseIsolatedWorkerThread(object LObject)
        {

            myLockObject = LObject;

        }

        public void Start()
        {

            if(!IsActive)
            {

                lock(myLockObject)
                {

                    myIsActive = true;

                    if(myException != null)
                    {

                        myException = null;

                    }

                }

                try
                {

                    ThreadPool.QueueUserWorkItem(RunThreadMain);

                }
                catch
                {

                    lock(myLockObject)
                    {

                        myIsActive = false;

                        throw;

                    }

                }

            }

        }

        private void RunThreadMain(object TheState)
        {

            bool stopRequested;

            lock(myLockObject)
            {

                stopRequested = myStopRequested;

            }

            try
            {

                if(!stopRequested)
                    ThreadMain();

            }
            catch(Exception e)
            {

                lock(myLockObject)
                {

                    myException = e;

                }

            }
            finally
            {

                bool CurrentlyIsContinuing;

                bool CurrentlyStopRequested;

                lock(myLockObject)
                {

                    CurrentlyIsContinuing = myIsContinuing;

                    CurrentlyStopRequested = myStopRequested;

                }

                if(CurrentlyIsContinuing && !CurrentlyStopRequested)
                {

                    try
                    {

                        ThreadPool.QueueUserWorkItem(RunThreadMain);

                    }
                    catch(Exception e)
                    {

                        lock(myLockObject)
                        {

                            myException = e;

                        }

                    }

                }
                else
                {

                    Finish();

                }

            }

        }

        private void Finish()
        {

            if(myStopRequested)
                myStopRequested = false;

            if(myIsContinuing)
                myIsContinuing = false;

            myIsActive = false;

        }

        protected abstract void ThreadMain();

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

            lock(myLockObject)
            {

                if(!myStopRequested)
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

        protected bool Continue()
        {

            lock(myLockObject)
            {

                if(!myIsContinuing)
                {

                    myIsContinuing = true;

                    return true;

                }

            }

            return false;

        }

        public bool IsContinuing
        {

            get
            {

                lock(myLockObject)
                {

                    return myIsContinuing;

                }

            }

        }

        protected bool CheckIsContinuing
        {

            get
            {

                lock(myLockObject)
                {

                    return myIsContinuing;

                }

            }

        }

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

    }

}
