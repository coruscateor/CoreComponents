using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseSleepyIsolatedThread : BaseIsolatedThread
    {

        public BaseSleepyIsolatedThread(bool IsParameterisedThread = false, int TheMaxStackSize = 0, bool TheSleepAtEnd = false)
            : base(IsParameterisedThread, TheMaxStackSize, TheSleepAtEnd)
        {

            SetDefault();

        }

        public void SetDefault()
        {

            SleepAtEnd = true;

            IsBackground = true;

        }

    }

}
