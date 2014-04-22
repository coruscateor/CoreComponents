using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class ActiveWaitEvent
    {

        protected static string ProvidedIterationsErrorMessage = "The provided Iterations parameter cannot be less than 1";

        protected bool myIsSignalled;

        protected object myIsSignalledLockObject = new object();

        protected static int myDefaultSpinCount;

        protected int mySpinCount;

        static ActiveWaitEvent()
        {

            int ProcessorCount = Environment.ProcessorCount;

            if(ProcessorCount > 1)
            {

                myDefaultSpinCount = ProcessorCount / 2;

            }
            else
            {

                myDefaultSpinCount = 0;

            }

        }

        public ActiveWaitEvent()
        {

            mySpinCount = myDefaultSpinCount;

        }

        public ActiveWaitEvent(bool IsSignalled)
        {

            myIsSignalled = IsSignalled;

            mySpinCount = myDefaultSpinCount;

        }

        public ActiveWaitEvent(int TheSpinCount)
        {

            if(SpinCount > 1)
                mySpinCount = TheSpinCount;

        }

        public ActiveWaitEvent(bool IsSignalled, int TheSpinCount)
        {

            myIsSignalled = IsSignalled;

            if(SpinCount > 1)
                mySpinCount = TheSpinCount;

        }

        public static int DefaultSpinCount
        {

            get
            {

                return myDefaultSpinCount;

            }

        }

        public bool IsSignalled
        {

            get
            {

                lock(myIsSignalledLockObject)
                {

                    return myIsSignalled;

                }

            }

        }

        public void Set()
        {

            lock(myIsSignalledLockObject)
            {

                myIsSignalled = true;

            }

        }

        public void Reset()
        {

            lock(myIsSignalledLockObject)
            {

                myIsSignalled = false;

            }

        }

        public int SpinCount
        {

            get
            {

                return mySpinCount;

            }

        }

        public void Wait()
        {

            while(!IsSignalled)
            {

                Thread.SpinWait(mySpinCount);

            }

        }

        public bool Wait(CancellationToken TheCancellationToken)
        {

            while(!IsSignalled)
            {

                if(TheCancellationToken.IsCancellationRequested)
                    return true;

                Thread.SpinWait(mySpinCount);

            }

            return false;

        }

        public void WaitCount(int Iterations)
        {

            if(Iterations < 1)
                throw new ArgumentOutOfRangeException(ProvidedIterationsErrorMessage);

            while(!IsSignalled)
            {

                Thread.SpinWait(mySpinCount);

                if(Iterations > 0)
                    --Iterations;
                else
                    break;

            }

        }

        public bool WaitCount(int Iterations, CancellationToken TheCancellationToken)
        {

            if(Iterations < 1)
                throw new ArgumentOutOfRangeException(ProvidedIterationsErrorMessage);

            while(!IsSignalled)
            {

                if(TheCancellationToken.IsCancellationRequested)
                    return true;

                Thread.SpinWait(mySpinCount);

                if(Iterations > 0)
                    --Iterations;
                else
                    break;

            }

            return false;

        }

        public bool Wait(int MillisecondsTimeout)
        {

            if(MillisecondsTimeout < 1)
            {

                if(MillisecondsTimeout == 0)
                {

                    if(!IsSignalled)
                        return false;
                    else
                        return true;

                }

                if(MillisecondsTimeout < 0)
                {

                    while(!IsSignalled)
                    {

                        Thread.SpinWait(mySpinCount);

                    }

                    return true;

                }

            }

            DateTime Finishing = DateTime.Now.AddMilliseconds(MillisecondsTimeout);

            while(!IsSignalled)
            {

                if(DateTime.Now >= Finishing)
                    return false;

                Thread.SpinWait(mySpinCount);

            }

            return true;

        }

        public bool Wait(TimeSpan Timeout)
        {

            DateTime Finishing = DateTime.Now.Add(Timeout);

            while(!IsSignalled)
            {

                if(DateTime.Now >= Finishing)
                    return false;

                Thread.SpinWait(mySpinCount);

            }

            return true;

        }

        public bool Wait(int MillisecondsTimeout, CancellationToken TheCancellationToken)
        {

            if(MillisecondsTimeout < 1)
            {

                if(MillisecondsTimeout == 0)
                {

                    if(TheCancellationToken.IsCancellationRequested)
                        return false;

                    if(!IsSignalled)
                        return false;
                    else
                        return true;

                }

                if(MillisecondsTimeout < 0)
                {

                    while(!IsSignalled)
                    {

                        if(TheCancellationToken.IsCancellationRequested)
                            return false;

                        Thread.SpinWait(mySpinCount);

                    }

                    return true;

                }

            }

            DateTime Finishing = DateTime.Now.AddMilliseconds(MillisecondsTimeout);

            while(!IsSignalled)
            {

                if(TheCancellationToken.IsCancellationRequested)
                    return false;

                if(DateTime.Now >= Finishing)
                    return false;

                Thread.SpinWait(mySpinCount);

            }

            return true;

        }

        public bool Wait(TimeSpan Timeout, CancellationToken TheCancellationToken)
        {

            DateTime Finishing = DateTime.Now.Add(Timeout);

            while(!IsSignalled)
            {

                if(TheCancellationToken.IsCancellationRequested)
                    return false;

                if(DateTime.Now >= Finishing)
                    return false;

                Thread.SpinWait(mySpinCount);

            }

            return true;

        }

        public ConcurrentValueContainer<bool> AsyncWait(ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Wait();

                TheContainer.Value = true;

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWait(CancellationToken TheCancellationToken, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheContainer.Value = Wait(TheCancellationToken);

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWaitCount(int Iterations, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                WaitCount(Iterations);

                TheContainer.Value = true;

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWaitCount(int Iterations, CancellationToken TheCancellationToken, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                WaitCount(Iterations, TheCancellationToken);

                TheContainer.Value = true;

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWait(int MillisecondsTimeout, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheContainer.Value = Wait(MillisecondsTimeout);

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWait(TimeSpan Timeout, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheContainer.Value = Wait(Timeout);

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWait(int MillisecondsTimeout, CancellationToken TheCancellationToken, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheContainer.Value = Wait(MillisecondsTimeout, TheCancellationToken);

            });

            return TheContainer;

        }

        public ConcurrentValueContainer<bool> AsyncWait(TimeSpan Timeout, CancellationToken TheCancellationToken, ConcurrentValueContainer<bool> TheContainer = null)
        {

            if(TheContainer == null)
                TheContainer = new ConcurrentValueContainer<bool>();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheContainer.Value = Wait(Timeout, TheCancellationToken);

            });

            return TheContainer;

        }

    }

}
