using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public class JobPool
    {

        protected List<IJob> myJobPool = new List<IJob>();

        public JobPool()
        {
        }

        public bool Fetch(Type TheJobType, ref IJob TheFoundJob)
        {

            if (!HasItems)
                return false;

            if (!TheJobType.GetInterfaces().Contains(typeof(IJob)))
                return false;

            return FetchJob(TheJobType, TheFoundJob);

        }

        public bool Fetch<T>(ref T TheFoundJob) where T : IJob
        {

            if (!HasItems)
                return false;

            return FetchJob(typeof(T), TheFoundJob);

        }

        public bool FetchOut<T>(out T TheFoundJob) where T : IJob
        {

            TheFoundJob = default(T);

            if (HasItems && FetchJob(typeof(T), TheFoundJob))
            {

                TheFoundJob.WaitingToStart();

                return true;

            }

            return false;

        }

        protected bool FetchJob(Type TheJobType, IJob TheFoundJob)
        {

            bool FoundJob = false;

            foreach (IJob Item in myJobPool)
            {

                if (Item.GetType() == TheJobType)
                {

                    TheFoundJob = Item;

                    TheFoundJob.WaitingToStart();

                    FoundJob = true;

                    break;

                }

            }

            if (FoundJob)
            {

                myJobPool.Remove(TheFoundJob);

            }

            return FoundJob;

        }

        public void Add(IJob TheJob)
        {

            if (!myJobPool.Contains(TheJob))
            {

                try
                {

                    if (!TheJob.IsDeactivated)
                        TheJob.Deactivate();

                    myJobPool.Add(TheJob);

                }
                catch
                {

                    if (TheJob.Take())
                        myJobPool.Add(TheJob);

                }

            }

        }

        public int Count
        {

            get
            {

                return myJobPool.Count;

            }

        }

        public bool HasItems
        {

            get
            {

                return myJobPool.Count > 0;

            }

        }

        public void Clear()
        {

            myJobPool.Clear();

        }

        public bool Contains(IJob TheJob)
        {

            return myJobPool.Contains(TheJob);

        }

    }

}
