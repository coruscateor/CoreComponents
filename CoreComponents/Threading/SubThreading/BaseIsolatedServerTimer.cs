using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.ComponentModel;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedServerTimer : ISubThread, IDisposable
    {

        private Timer myTimer;

        private DateTime mySignalTime;

        private bool myEngaged;

        private bool myIsActive;

        private DateTime myMissedSignalTime;

        private bool myStopRequested;

        public BaseIsolatedServerTimer()
        {

            Initialise();

        }

        public BaseIsolatedServerTimer(double TheInterval, bool Start = true)
        {

            myTimer = new Timer(TheInterval);

            if(Start)
                myTimer.Start();

        }

        protected virtual void Initialise()
        {

            myTimer = new Timer();

        }

        private void Engage()
        {

            System.Threading.Thread.MemoryBarrier();

            if (!myEngaged)
            {

                myTimer.Elapsed += myTimer_Elapsed;

                myEngaged = true;

                System.Threading.Thread.MemoryBarrier();

            }

        }

        private void DisEngage()
        {

            System.Threading.Thread.MemoryBarrier();

            if (myEngaged)
            {

                myTimer.Elapsed -= myTimer_Elapsed;

                myEngaged = false;

                System.Threading.Thread.MemoryBarrier();

            }

        }

        public DateTime SignalTime
        {

            get
            {

                System.Threading.Thread.MemoryBarrier();

                return mySignalTime;

            }
 
        }

        public DateTime MissedSignalTime
        {

            get
            {

                System.Threading.Thread.MemoryBarrier();

                return myMissedSignalTime;

            }

        }

        public bool AutoReset 
        {

            get 
            {

                return myTimer.AutoReset;

            }
            set
            {

                myTimer.AutoReset = value;

            }

        }

        public bool IsActive
        {

            get 
            {

                return myTimer.Enabled;

            }
            set 
            {

                myTimer.Enabled = value;

            }

        }
    
        public double Interval
        {

            get
            {

                return myTimer.Interval;
 
            }
            set
            {

                myTimer.Interval = value;

            }

        }

        protected abstract void Main();

        void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            System.Threading.Thread.MemoryBarrier();

            if(!myIsActive)
            {

                myIsActive = true;

                System.Threading.Thread.MemoryBarrier();

                mySignalTime = e.SignalTime;

                System.Threading.Thread.MemoryBarrier();

                try
                {

                    Main();

                }
                finally
                {

                    myIsActive = false;

                    System.Threading.Thread.MemoryBarrier();

                }

            }
            else
            {

                myMissedSignalTime = e.SignalTime;

                System.Threading.Thread.MemoryBarrier();

            }

        }

        public void Start()
        {

            System.Threading.Thread.MemoryBarrier();

            bool CurrentlyActive = myIsActive;

            if(!myTimer.Enabled && !CurrentlyActive)
            {

                System.Threading.Thread.MemoryBarrier();

                if(myStopRequested)
                {

                    myStopRequested = false;

                    System.Threading.Thread.MemoryBarrier();

                }

                myTimer.Start();

            }

        }

        public void Stop()
        {

            System.Threading.Thread.MemoryBarrier();

            bool CurrentlyActive = myIsActive;

            if(myTimer.Enabled && CurrentlyActive)
            {

                System.Threading.Thread.MemoryBarrier();

                if(myStopRequested)
                {

                    myStopRequested = false;

                    System.Threading.Thread.MemoryBarrier();

                }

                myTimer.Stop();

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

        public ISynchronizeInvoke SynchronizingObject
        {

            get
            {

                return myTimer.SynchronizingObject;

            }
            set
            {

                myTimer.SynchronizingObject = value;

            }

        }

        public void Close()
        {

            Dispose();

        }

        public void Dispose()
        {

            DisEngage();

            myTimer.Dispose();

        }

    }

}
