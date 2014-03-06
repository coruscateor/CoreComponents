using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public class JobPool
    {

        protected HashSet<IJob> myJobPool = new HashSet<IJob>();

        public JobPool()
        {
        }

        public virtual bool Fetch(Type TheJobType, ref IJob TheFoundJob)
        {

            if (!HasItems)
                return false;

            if (!TheJobType.GetInterfaces().Contains(typeof(IJob)))
                return false;

            return FetchJob(TheJobType, TheFoundJob);

        }

        public virtual bool Fetch<T>(ref T TheFoundJob) where T : IJob
        {

            if (!HasItems)
                return false;

            return FetchJob(typeof(T), TheFoundJob);
 
        }

        public virtual bool FetchOut<T>(out T TheFoundJob) where T : IJob
        {

            TheFoundJob = default(T);

            if (HasItems && FetchJob(typeof(T), TheFoundJob))
            {

                return true;

            }

            return false;

        }

        protected bool FetchJob(Type TheJobType, IJob TheFoundJob)
        {

            bool FoundJob = false;

            try
            {

                foreach (IJob Item in myJobPool)
                {

                    if (Item.GetType() == TheJobType && Item.IsDeactivated)
                    {

                        TheFoundJob = Item;

                        //Must reset the state of the job

                        TheFoundJob.WaitingToStart();

                        FoundJob = true;

                        break;

                    }

                }

            }
            catch
            {

                if (TheFoundJob != null)
                    myJobPool.Remove(TheFoundJob);

                return false;

            }

            if(FoundJob)
            {

                myJobPool.Remove(TheFoundJob);

            }

            return FoundJob;

        }

        public virtual bool Add(IJob TheJob)
        {

            return myJobPool.Add(TheJob);

            /*

            if (!myJobPool.Contains(TheJob))
            {

                try
                {

                    myJobPool.Add(TheJob);

                }
                finally
                {
                }

            }

            */ 
        }

        public virtual bool Remove(IJob TheJob)
        {

            return myJobPool.Remove(TheJob);

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

        public virtual bool Contains(IJob TheJob)
        {

            return myJobPool.Contains(TheJob);

        }

        public virtual int Purge()
        {

            if (myJobPool.Count > 0)
            {

                //List<IJob> JobsToRemove = new List<IJob>();

                //foreach (IJob Item in myJobPool)
                //{

                //    if (!Item.IsDeactivated)
                //    {

                //        JobsToRemove.Add(Item);

                //    }

                //}

                //if (JobsToRemove.Count > 0)
                //{

                //    foreach (IJob Item in JobsToRemove)
                //    {

                //        myJobPool.Remove(Item);

                //    }

                //    return JobsToRemove.Count;

                //}

                /*

                for (int i = 0; i < myJobPool.Count; i++)
                {

                    IJob Item = myJobPool[i];

                    if (!Item.IsDeactivated)
                    {

                        myJobPool.Remove(Item);

                        count++;

                    }

                }

                */

                int count = 0;

                List<IJob> FoundItems = null;

                foreach(IJob Item in myJobPool)
                {

                    if(Item.IsDeactivated)
                    {

                        if(FoundItems == null)
                            FoundItems = new List<IJob>();

                        count++;

                    }

                }

                if(FoundItems != null)
                {

                    foreach(IJob Item in FoundItems)
                    {

                        myJobPool.Remove(Item);

                    }

                }

                return count;

            }

            return 0;

        }

        public virtual void Clear()
        {

            myJobPool.Clear();

        }

    }

}
