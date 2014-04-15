using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class BaseThreadWorker : AbstractBaseThreadWorker, IExecute
    {

        public BaseThreadWorker()
        {
        }

        protected abstract void ThreadMain();

        public void Execute()
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    ThreadMain();

                }
                catch(Exception e)
                {

                    myExceptionQueue.Value.Enqueue(e);

                }

            });

        }

    }

    public abstract class BaseThreadWorker<T> : AbstractBaseThreadWorker
    {

        public BaseThreadWorker()
        {
        }

        protected abstract void ThreadMain(T TheParameter);

        public void Execute(T TheParameter)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    ThreadMain(TheParameter);

                }
                catch(Exception e)
                {

                    myExceptionQueue.Value.Enqueue(e);

                }

            });

        }

    }

    public abstract class BaseThreadWorker<T1, T2> : AbstractBaseThreadWorker
    {

        public BaseThreadWorker()
        {
        }

        protected abstract void ThreadMain(T1 P1, T2 P2);

        public void Execute(T1 P1, T2 P2)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    ThreadMain(P1, P2);

                }
                catch(Exception e)
                {

                    myExceptionQueue.Value.Enqueue(e);

                }

            });

        }

    }

    public abstract class BaseThreadWorker<T1, T2, T3> : AbstractBaseThreadWorker
    {

        public BaseThreadWorker()
        {
        }

        protected abstract void ThreadMain(T1 P1, T2 P2, T3 P3);

        public void Execute(T1 P1, T2 P2, T3 P3)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    ThreadMain(P1, P2, P3);

                }
                catch(Exception e)
                {

                    myExceptionQueue.Value.Enqueue(e);

                }

            });

        }

    }

    public abstract class BaseThreadWorker<T1, T2, T3, T4> : AbstractBaseThreadWorker
    {

        public BaseThreadWorker()
        {
        }

        protected abstract void ThreadMain(T1 P1, T2 P2, T3 P3, T4 P4);

        public void Execute(T1 P1, T2 P2, T3 P3, T4 P4)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    ThreadMain(P1, P2, P3, P4);

                }
                catch(Exception e)
                {

                    myExceptionQueue.Value.Enqueue(e);

                }

            });

        }

    }

}
