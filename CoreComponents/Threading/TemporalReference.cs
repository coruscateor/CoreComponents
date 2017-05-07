using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class TemporalReference<T> : BaseTemporalReference<T> where T : class
    {

        T myReference;

        long myTime;

        public TemporalReference()
            : base(true)
        {
        }

        protected override void CheckAndDeReference(object TheState, bool TimedOut)
        {

            if(!TimedOut)
                return;

            lock(myLockObject)
            {

                if(myReference != null)
                {

                    long Result = myTime - myTimeOutInterval;

                    if(Result <= 0L)
                    {

                        myTime = 0L;

                        if(IsIDisposable)
                            Dispose(myReference);

                        //Unregister();

                    }
                    else
                        myTime = Result;


                }
                else
                {

                    myTime = 0L;

                    //Unregister();

                }

            }

        }

        public T Reference
        {

            get
            {

                lock(myLockObject)
                {

                    return myReference;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myReference = value;

                    myTime = myDefaultTime;

                    Start();

                }

            }

        }

        public long Time
        {

            get
            {

                lock(myLockObject)
                {

                    return myTime;

                }

            }

        }

    }

}
