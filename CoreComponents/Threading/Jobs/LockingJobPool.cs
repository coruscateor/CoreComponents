using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public class LockingJobPool : JobPool
    {

        protected object myLockObject = new object();
        
        public LockingJobPool()
        { 
        }

        public override bool Add(IJob TheJob)
        {

            lock(myLockObject)
            {

                return base.Add(TheJob);

            }

        }

        public override void Clear()
        {

            lock(myLockObject)
            {

                base.Clear();

            }

        }

        public override bool Contains(IJob TheJob)
        {

            lock(myLockObject)
            {

                return base.Contains(TheJob);

            }

        }

        public override bool Fetch<T>(ref T TheFoundJob)
        {

            lock(myLockObject)
            {

                return base.Fetch<T>(ref TheFoundJob);

            }

        }

        public override bool Fetch(Type TheJobType, ref IJob TheFoundJob)
        {

            lock(myLockObject)
            {

                return base.Fetch(TheJobType, ref TheFoundJob);

            }

        }

        public override bool FetchOut<T>(out T TheFoundJob)
        {

            lock(myLockObject)
            {

                return base.FetchOut<T>(out TheFoundJob);

            }

        }

        public override int Purge()
        {

            lock(myLockObject)
            {

                return base.Purge();

            }

        }

        public override bool Remove(IJob TheJob)
        {

            lock(myLockObject)
            {

                return base.Remove(TheJob);

            }

        }

    }

}
