using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public abstract class PercentWorkItem : WorkItem, IReset
    {

        Percent myCurrentPercent;

        SpinLock myPercentSpinlock;

        [ThreadSafe]
        public Percent CurrentPercent
        {

            [ThreadSafe]
            get
            {

                bool lockTaken = false;

                try
                {

                    myPercentSpinlock.Enter(ref lockTaken);

                    return myCurrentPercent;

                }
                finally
                {

                    if(lockTaken)
                        myPercentSpinlock.Exit();

                }

            }
            [ThreadSafe]
            private set
            {

                bool lockTaken = false;

                try
                {

                    myPercentSpinlock.Enter(ref lockTaken);

                    myCurrentPercent = value;

                }
                finally
                {

                    if(lockTaken)
                        myPercentSpinlock.Exit();

                }

            }

        }

        [ThreadSafe]
        protected bool IncrementTo100Pct()
        {

            var pct = CurrentPercent;

            bool result = pct.IncrementTo100();

            CurrentPercent = pct;

            return result;

        }

        [ThreadSafe]
        protected void Increment()
        {

            var pct = CurrentPercent;

            pct++;

            CurrentPercent = pct;

        }

        public override void Reset()
        {

            base.Reset();

            myCurrentPercent = Percent.Zero;

        }

    }

}
