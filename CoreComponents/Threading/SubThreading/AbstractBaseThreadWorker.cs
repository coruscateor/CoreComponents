using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class AbstractBaseThreadWorker
    {

        protected ThreadLocal<ConcurrentQueue<Exception>> myExceptionQueue;

        public AbstractBaseThreadWorker()
        {
        }

        public void GetExceptions(Action<Exception> TheExceptionAction)
        {
            
            IList<ConcurrentQueue<Exception>> Items = myExceptionQueue.Values;

            if(Items.Count < 1)
                return;

            foreach(var Item in Items)
            {

                while(Item.Count > 0)
                {

                    Exception CurrentException;

                    if(Item.TryDequeue(out CurrentException))
                        TheExceptionAction(CurrentException);

                }

            }

        }

        public void GetExceptions(Func<Exception, bool> TheExceptionAction)
        {

            IList<ConcurrentQueue<Exception>> Items = myExceptionQueue.Values;

            if(Items.Count < 1)
                return;

            foreach(var Item in Items)
            {

                while(Item.Count > 0)
                {

                    Exception CurrentException;

                    if(Item.TryDequeue(out CurrentException))
                    {

                        if(!TheExceptionAction(CurrentException))
                            return;

                    }

                }

            }

        }

    }

}
