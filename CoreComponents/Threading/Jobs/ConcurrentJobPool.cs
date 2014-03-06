using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{

    public class ConcurrentJobPool : JobPool
    {

        protected SpinLock mySpinlock;

        public ConcurrentJobPool()
        {

            mySpinlock = new SpinLock(false);

        }

        public override bool Add(IJob TheJob)
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.Add(TheJob);

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override void Clear()
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                base.Clear();

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override bool Contains(IJob TheJob)
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.Contains(TheJob);

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override bool Fetch<T>(ref T TheFoundJob)
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.Fetch<T>(ref TheFoundJob);

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override bool Fetch(Type TheJobType, ref IJob TheFoundJob)
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.Fetch(TheJobType, ref TheFoundJob);

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override bool FetchOut<T>(out T TheFoundJob)
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.FetchOut<T>(out TheFoundJob);

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override int Purge()
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.Purge();

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

        public override bool Remove(IJob TheJob)
        {

            bool lockTaken = false;

            try
            {

                mySpinlock.Enter(ref lockTaken);

                return base.Remove(TheJob);

            }
            finally
            {

                if (lockTaken)
                    mySpinlock.Exit();

            }

        }

    }

}
