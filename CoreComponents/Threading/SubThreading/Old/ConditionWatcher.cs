using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class ConditionWatcher : BaseIsolatedThread
    {

        private static readonly TimeSpan DefaultInterval = new TimeSpan(0, 0, 30);

        private TimeSpan myInterval;

        private volatile bool mySleepRequested;

        public ConditionWatcher()
        {

            myInterval = DefaultInterval;

        }
        
        protected override void ThreadMain()
        {

            do
            {

                if(!mySleepRequested && !StopRequested)
                {

                    if (!Check())
                    {

                        try
                        {

                            if(!StopRequested)
                                Thread.Sleep(myInterval);

                        }
                        catch (ThreadInterruptedException e)
                        {

                            mySleepRequested = false;

                            throw e;

                        }

                    }
                    else
                    {

                        if(!StopRequested)
                            ConditionMet();

                    }

                }
                else
                {

                    try
                    {

                        if (!StopRequested)
                            Thread.Sleep(Timeout.Infinite);

                    }
                    catch (ThreadInterruptedException e)
                    {
                        
                        mySleepRequested = false;

                        throw e;

                    }

                }

            }
            while(!StopRequested);

        }

        public TimeSpan Interval
        {

            get
            {

                return myInterval;

            }
            set
            {

                myInterval = value;

            }

        }

        public void Sleep()
        {

            if(!mySleepRequested)
                mySleepRequested = true;

        }

        protected abstract bool Check();

        protected abstract void ConditionMet();

    }

}
