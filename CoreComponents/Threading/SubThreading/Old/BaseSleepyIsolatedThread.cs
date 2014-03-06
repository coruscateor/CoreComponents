using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseSleepyIsolatedThread : BaseIsolatedThread
    {

        public BaseSleepyIsolatedThread()
        {
        }

        public BaseSleepyIsolatedThread(bool IsParameterisedThread, int? TheMaxStackSize = null) : base(IsParameterisedThread)
        {
        }

        public BaseSleepyIsolatedThread(bool IsParameterisedThread, int? TheMaxStackSize) : base(IsParameterisedThread, TheMaxStackSize)
        {
        }

        protected override void ThreadMain()
        {

            while(!StopRequested)
            {

                SleepyThreadMain();

                try
                {

                    Sleep();

                }
                catch(ThreadInterruptedException e)
                {
                }

            }

        }

        protected abstract void SleepyThreadMain();

    }

}
