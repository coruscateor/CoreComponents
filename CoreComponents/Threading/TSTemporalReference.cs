using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class TSTemporalReference<T> : BaseTemporalReference<T, TimeSpan, DateTime> where T : class
    {

        public TSTemporalReference()
        {

            Initalise();

        }

        public override void Set(T TheReference, TimeSpan TheTimeoutInterval)
        {

            CheckIfActiveOrWaiting();

            TimeOutInterval = TheTimeoutInterval;

            SetRegisteredWaitHandle(ThreadPool.RegisterWaitForSingleObject(mySemaphore, DropReference, null, TheTimeoutInterval, true));

            myTimeSet = DateTime.Now;

        }
        
        public override bool TryGetETD(out TimeSpan TheETD)
        {

            if(!IsActiveOrWaiting)
            {

                TheETD = TimeSpan.Zero;

                return false;

            }

            DateTime CurrentTime = DateTime.Now;

            TheETD = myTimeSet.Add(TimeOutInterval).Subtract(CurrentTime);

            return true;

        }

    }

}
