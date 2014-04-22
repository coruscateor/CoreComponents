using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Threading.SubThreading;

namespace CoreComponents.Threading
{
    
    public class AsyncLockHog : IDisposable
    {

        LockHogThread myLHT;

        public AsyncLockHog()
        {
            myLHT = new LockHogThread();

        }

        public AsyncLockHog(object TheLockObject)
        {

            myLHT = new LockHogThread(TheLockObject);

        }

        public void Enter()
        {

            myLHT.Enter();

        }

        public void EnterThenExit()
        {

            myLHT.EnterThenExit();

        }

        public void EnterThenExit(int MillisecondsWait)
        {

            myLHT.EnterThenExit(MillisecondsWait);

        }

        public void EnterThenExit(TimeSpan Wait)
        {

            myLHT.EnterThenExit(Wait);

        }

        public void GetLockObject(ConcurrentValueContainer<object> LockObjectContainer, ConcurrentValueContainer<bool> HasWrittenContainer)
        {

            myLHT.GetLockObject(LockObjectContainer, HasWrittenContainer);

        }

        public void SetLockObject(object TheLockObject, ConcurrentValueContainer<bool> HasWrittenContainer)
        {

            myLHT.SetLockObject(TheLockObject, HasWrittenContainer);

        }

        public void TryEnter(int MillisecondsTimeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer)
        {

            myLHT.TryEnter(MillisecondsTimeout, HasEntered, HasWrittenContainer);

        }

        public void TryEnter(TimeSpan Timeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer)
        {

            myLHT.TryEnter(Timeout, HasEntered, HasWrittenContainer);

        }

        public void TryEnter(int MillisecondsTimeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer, int MillisecondsWait)
        {

            myLHT.TryEnter(MillisecondsTimeout, HasEntered, HasWrittenContainer, MillisecondsTimeout);

        }

        public void TryEnter(TimeSpan Timeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer, TimeSpan Wait)
        {

            myLHT.TryEnter(Timeout, HasEntered, HasWrittenContainer, Wait);

        }

        public void Dispose()
        {

            myLHT.TryExit();

            myLHT.JoinExit();

            myLHT.Dispose();

        }

        public class LockHogThread : BaseIsolatedThread
        {

            protected ConcurrentQueue<Action> myDelegateQueue = new ConcurrentQueue<Action>();

            protected LockHog myLockHog = new LockHog();

            public LockHogThread()
            {
            }

            public LockHogThread(object TheLockingObject)
            {

                myLockHog.LockObject = TheLockingObject;

            }

            protected override void ThreadMain()
            {
                
                do
                {

                    Action TheAction;

                    if(myDelegateQueue.TryDequeue(out TheAction))
                        TheAction();

                }
                while(myDelegateQueue.Count > 0);

            }

            public void Enter()
            {

                myDelegateQueue.Enqueue(() => { myLockHog.Enter(); });

            }

            public void IsEntered(ConcurrentValueContainer<bool> HasEnteredContainer, ConcurrentValueContainer<bool> HasWrittenContainer)
            {

                if(HasEnteredContainer == null)
                    throw new Exception("The provided HasEnteredContainer cannot be null");

                myDelegateQueue.Enqueue(() =>
                {
                    
                    HasEnteredContainer.Value = myLockHog.IsEntered();
                    
                    HasWrittenContainer.Value = true;
                
                });

            }

            public void Exit()
            {

                myDelegateQueue.Enqueue(() => { myLockHog.Exit(); });

            }

            public void EnterThenExit()
            {

                myDelegateQueue.Enqueue(() =>
                {

                    myLockHog.Enter();

                    myLockHog.Exit();
                
                });

            }

            public void EnterThenExit(int MillisecondsWait)
            {

                myDelegateQueue.Enqueue(() =>
                {

                    myLockHog.Enter();

                    Thread.Sleep(MillisecondsWait);

                    myLockHog.Exit();

                });

            }

            public void EnterThenExit(TimeSpan Wait)
            {

                myDelegateQueue.Enqueue(() =>
                {

                    myLockHog.Enter();

                    Thread.Sleep(Wait);

                    myLockHog.Exit();

                });

            }

            public void GetLockObject(ConcurrentValueContainer<object> LockObjectContainer, ConcurrentValueContainer<bool> HasWrittenContainer)
            {

                myDelegateQueue.Enqueue(() =>
                {
                    
                    LockObjectContainer.Value = myLockHog.LockObject;
                    
                    HasWrittenContainer.Value = true;
                
                });

            }

            public void SetLockObject(object TheLockObject, ConcurrentValueContainer<bool> HasWrittenContainer)
            {

                if(TheLockObject == null)
                    throw new Exception("The provided LockObject cannot be null");

                myDelegateQueue.Enqueue(() =>
                {

                    myLockHog.LockObject = TheLockObject;

                    HasWrittenContainer.Value = true;

                });

            }

            public void TryEnter(int MillisecondsTimeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer)
            {

                myDelegateQueue.Enqueue(() =>
                {
                    
                    HasEntered.Value = myLockHog.TryEnter(MillisecondsTimeout);
                    
                    HasWrittenContainer.Value = true;
                
                });

            }

            public void TryEnter(TimeSpan Timeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer)
            {

                myDelegateQueue.Enqueue(() =>
                {

                    HasEntered.Value = myLockHog.TryEnter(Timeout);

                    HasWrittenContainer.Value = true;

                });

            }

            public void TryEnter(int MillisecondsTimeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer, int MillisecondsWait)
            {

                myDelegateQueue.Enqueue(() =>
                {

                    bool HasEnteredLock = myLockHog.TryEnter(MillisecondsTimeout);

                    HasEntered.Value = HasEnteredLock;

                    HasWrittenContainer.Value = true;

                    if(HasEnteredLock)
                    {

                        Thread.Sleep(MillisecondsWait);

                        myLockHog.Exit();

                    }

                });

            }

            public void TryEnter(TimeSpan Timeout, ConcurrentValueContainer<bool> HasEntered, ConcurrentValueContainer<bool> HasWrittenContainer, TimeSpan Wait)
            {

                myDelegateQueue.Enqueue(() =>
                {

                    bool HasEnteredLock = myLockHog.TryEnter(Timeout);

                    HasEntered.Value = HasEnteredLock;

                    HasWrittenContainer.Value = true;

                    if(HasEnteredLock)
                    {

                        Thread.Sleep(Wait);

                        myLockHog.Exit();

                    }

                });

            }

        }
        
    }

}
