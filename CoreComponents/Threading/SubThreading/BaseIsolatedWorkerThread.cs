using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedWorkerThread : ISubThread
    {

        private bool myIsActive;

        private bool myStopRequested;

        private object myState;

        private Exception myException;

        private bool myIsContinuing;

        private object myContinuationState;

        public BaseIsolatedWorkerThread()
        {
        }

        public void Start()
        {

            Thread.MemoryBarrier();

            if(!myIsActive)
            {

                Initialise();

                try
                {

                    ThreadPool.QueueUserWorkItem(RunThreadMain);

                }
                catch
                {

                    myIsActive = false;

                    Thread.MemoryBarrier();

                    throw;
 
                }

            }

        }

        public void Start(object TheState)
        {

            Thread.MemoryBarrier();

            if(!myIsActive)
            {

                Initialise();

                try
                {

                    ThreadPool.QueueUserWorkItem(RunThreadMain, TheState);

                }
                catch
                {
                    
                    myIsActive = false;

                    Thread.MemoryBarrier();

                    throw;

                }

            }

        }

        private void Initialise()
        {

            myIsActive = true;

            Thread.MemoryBarrier();

            if(myException != null)
            {

                myException = null;

                Thread.MemoryBarrier();

            }

        }

        private void RunThreadMain(object TheState)
        {

            if(TheState != null)
                myState = TheState;
            else if(myState != null)
                myState = null;

            Thread.MemoryBarrier();

            if(myIsContinuing)
            {

                myIsContinuing = false;

                Thread.MemoryBarrier();

            }

            try
            {

                Thread.MemoryBarrier();

                if(!myStopRequested)
                    ThreadMain();

            }
            catch(Exception e)
            {

                myException = e;

                Thread.MemoryBarrier();

            }
            finally
            {

                Thread.MemoryBarrier();

                bool CurrentlyIsContinuing = myIsContinuing;

                Thread.MemoryBarrier();

                bool CurrentlyStopRequested = myStopRequested;

                if(CurrentlyIsContinuing && !CurrentlyStopRequested)
                {

                    try
                    {

                        Thread.MemoryBarrier();

                        if(myContinuationState == null)
                        {

                            ThreadPool.QueueUserWorkItem(RunThreadMain);

                        }
                        else
                        {

                            ThreadPool.QueueUserWorkItem(RunThreadMain, myContinuationState);

                            myContinuationState = null;

                        }

                    }
                    catch(Exception e)
                    {

                        myException = e;

                        Thread.MemoryBarrier();

                        Conclude();

                    }

                }
                else
                {

                    Conclude();

                }

            }

        }

        private void Conclude()
        {

            Thread.MemoryBarrier();

            if(myStopRequested)
            {

                myStopRequested = false;

                Thread.MemoryBarrier();

            }

            if(myIsContinuing)
            {

                myIsContinuing = false;

                Thread.MemoryBarrier();

            }

            myIsActive = false;

            Thread.MemoryBarrier();

        }

        protected abstract void ThreadMain();

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myIsActive;
            
            }

        }

        public void Stop()
        {

            Thread.MemoryBarrier();

            if(!myStopRequested)
            {

                myStopRequested = true;

                Thread.MemoryBarrier();

            }

        }

        public bool StopRequested
        {

            get
            {

                Thread.MemoryBarrier();

                return myStopRequested;
            
            }

        }

        protected bool Continue()
        {

            Thread.MemoryBarrier();

            if(myContinuationState != null)
            {

                myContinuationState = null;

                Thread.MemoryBarrier();

            }

            Thread.MemoryBarrier();

            if(!myIsContinuing)
            {

                myIsContinuing = true;

                Thread.MemoryBarrier();

                return true;

            }

            return false;

        }

        protected bool Continue(object TheState)
        {

            Thread.MemoryBarrier();

            if(myContinuationState != TheState)
            {

                myContinuationState = TheState;

                Thread.MemoryBarrier();

            }

            Thread.MemoryBarrier();

            if(!myIsContinuing)
            {

                myIsContinuing = true;

                Thread.MemoryBarrier();

                return true;

            }

            return false;

        }

        public bool IsContinuing
        {

            get
            {

                Thread.MemoryBarrier();

                return myIsContinuing;

            }

        }

        protected bool CheckIsContinuing
        {

            get
            {

                return myIsContinuing;

            }

        }

        protected object State
        {

            get
            {

                return myState;

            }

        }

        protected bool HasState
        {
            
            get
            {

                return myState != null;

            }

        }

        public Exception Exception
        {

            get
            {

                Thread.MemoryBarrier();

                return myException;

            }

        }

        public bool HasException
        {

            get
            {

                Thread.MemoryBarrier();

                return myException != null;

            }

        }

    }

}
