using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Jobs
{

    public class QuickValueJob<T> : QuickJob, IQuickValueJob<T> where T : class
    {

        protected T myValue;

        public QuickValueJob()
        {
        }

        public QuickValueJob(bool TheUsesMemoryBarrier) : base(TheUsesMemoryBarrier)
        {
        }

        public T Value
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    return myValue;

                }
                finally
                {

                    if(LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                mySpinlock.Enter(ref LockTaken);

                myValue = value;

                myState = QuickJobState.Success;

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

            }

        }

        public bool TryGetValue(out T TheValue)
        {

            T CurrentValue = Value;

            if(CurrentValue != null)
            {

                TheValue = CurrentValue;

                return true;

            }

            TheValue = null;

            return false;

        }

        public override void Reset()
        {

            bool LockTaken = false;

            mySpinlock.Enter(ref LockTaken);

            State = QuickJobState.Pending;

            if(myException != null)
                myException = null;

            if(myValue != null)
                myValue = null;

            if(LockTaken)
                mySpinlock.Exit(myUsesMemoryBarrier);

        }

    }

}
