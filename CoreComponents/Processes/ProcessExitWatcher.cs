using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace CoreComponents.Processes
{

    public class ProcessExitWatcher
    {

        protected volatile Process myProcess;

        protected volatile bool myIsActive = false;

        //protected volatile bool myIsListening = false;

        protected volatile bool myStopListening = false;

        protected volatile ProcessStoppedListeningReason myStoppedListeningReason = ProcessStoppedListeningReason.None;

        protected volatile Exception myCaughtException;

        Thread myThread;

        public ProcessExitWatcher()
        {

            myThread = new Thread(ListenForExit);

			myThread.IsBackground = true;

        }

		public bool UsesBackgroundThread
		{

			get
			{

				return myThread.IsBackground;

			}
			set
			{

				myThread.IsBackground = value;

			}

		}

		public bool UsesThreadPoolThread
		{

			get
			{

				return myThread.IsThreadPoolThread;

			}

		}

        public Process Process
        {

            get
            {

                return myProcess;

            }
            set
            {

                myProcess = value;

            }

        }

        public bool HasProcess
        {

            get
            {

                return myProcess != null;

            }

        }

        protected void ListenForExit()
        {

            if (myStoppedListeningReason != ProcessStoppedListeningReason.None)
                myStoppedListeningReason = ProcessStoppedListeningReason.None;

            try
            {

                //myIsListening = true;

                while (!myProcess.HasExited)
                {

                    Thread.Yield();

					if(myStopListening)
					{

						myStoppedListeningReason = ProcessStoppedListeningReason.Canceled;

						return;

					}

                }

                myStoppedListeningReason = ProcessStoppedListeningReason.Exited;

            }
            catch (Exception e)
            {

                myCaughtException = e;

                myStoppedListeningReason = ProcessStoppedListeningReason.Exception;

            }
            finally
            {

                myIsActive = false;

				if(myStopListening)
					myStopListening = false;

            }
 
        }

        public void Listen()
        {

            if (!myIsActive && !myThread.IsAlive)
            {

                myIsActive = true;

                if (myProcess == null)
                {

                    myIsActive = false;

                    throw new Exception("Process is null");

                }

                if (!myProcess.HasExited)
                {

                    myThread.Start();

                    //ThreadPool.QueueUserWorkItem((object Input) =>
                    //{

                    //});

                }

            }

        }

        public ProcessStoppedListeningReason StoppedListeningReason
        {

            get
            {

                return myStoppedListeningReason;

            }

        }

        public Exception CaughtException
        {

            get
            {

                return myCaughtException;

            }

        }

        public bool HasCaughtException
        {

            get
            {

                return myCaughtException != null;

            }

        }

		public bool IsStopping
		{
			
			get
			{
				
				return myStopListening;
				
			}
			
		}
		
		public void Stop()
		{
			
			if(!myStopListening)
				myStopListening = true;
			
		}

    }

}
