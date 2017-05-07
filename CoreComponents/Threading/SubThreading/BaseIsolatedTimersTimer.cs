using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.ComponentModel;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedTimersTimer : IIsolatedThread, IDisposable
    {

        private Timer myTimer;

        private bool myIsActive;

        private bool myStopRequested;

        private Exception myException;

        private object myLockObject;

        public BaseIsolatedTimersTimer()
        {

            InitaliseTimer();

            myLockObject = new object();

        }

        public BaseIsolatedTimersTimer(object LObj)
        {

            InitaliseTimer();

            myLockObject = LObj;

        }

        public BaseIsolatedTimersTimer(double Ival)
        {

            InitaliseTimer(Ival);

            myLockObject = new object();

        }

        public BaseIsolatedTimersTimer(double Ival, object LObj)
        {

            InitaliseTimer(Ival);

            myLockObject = LObj;

        }

        private void InitaliseTimer()
        {

            myTimer = new Timer();

            myTimer.Elapsed += Timer_Elapsed;

        }

        private void InitaliseTimer(double Ival)
        {

            myTimer = new Timer(Ival);

            myTimer.Elapsed += Timer_Elapsed;

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

        public bool AutoReset 
        {

            get 
            {

                lock(myLockObject)
                {

                    return myTimer.AutoReset;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myTimer.AutoReset = value;

                }

            }

        }

        public bool IsActive
        {

            get 
            {

                lock(myLockObject)
                {

                    return myTimer.Enabled;

                }

            }
            set 
            {

                lock(myLockObject)
                {

                    myTimer.Enabled = value;

                }

            }

        }
    
        public double Interval
        {

            get
            {

                lock(myLockObject)
                {

                    return myTimer.Interval;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myTimer.Interval = value;

                }

            }

        }

        protected abstract void ThreadMain();

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            //Re-entrancy protection

            bool HasLock = System.Threading.Monitor.TryEnter(this);

            if(!HasLock)
            {

                lock(myLockObject)
                {

                    myException = new ReentrancyException("Reentrant call detected");

                }

                return;

            }

            bool CurrentStopRequested;

            lock(myLockObject)
            {

                CurrentStopRequested = myStopRequested;

                if(myException != null)
                    myException = null;

            }

            if(!CurrentStopRequested)
            {

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

            System.Threading.Monitor.Exit(this);

        }

        public void Start()
        {

            lock(myLockObject)
            {

                if(!myTimer.Enabled && !myIsActive)
                {

                    if(myStopRequested)
                        myStopRequested = false;

                    myTimer.Start();

                    myIsActive = true;

                }

            }

        }

        public void Stop()
        {

            lock(myLockObject)
            {

                if(myTimer.Enabled && myIsActive)
                {

                    if(!myStopRequested)
                        myStopRequested = true;

                    myTimer.Stop();

                    myIsActive = false;

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

        public ISynchronizeInvoke SynchronizingObject
        {

            get
            {

                lock(myLockObject)
                {

                    return myTimer.SynchronizingObject;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myTimer.SynchronizingObject = value;

                }

            }

        }

        public ISite Site
        {

            get
            {

                lock(myLockObject)
                {

                    return myTimer.Site;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myTimer.Site = value;

                }

            }

        }

        public void Dispose()
        {

            lock(myLockObject)
            {

                Stop();

                myTimer.Elapsed -= Timer_Elapsed;

                myTimer.Dispose();

            }

        }

    }

}
