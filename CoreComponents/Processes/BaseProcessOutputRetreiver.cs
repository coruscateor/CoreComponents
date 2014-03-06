using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CoreComponents.Processes
{

    public abstract class BaseProcessOutputRetreiver
    {

        protected volatile Process myProcess;

        //protected StreamReader myStandardOutputReader;

        //protected StreamReader myStandardErrorReader;

        protected volatile bool myIsActive = false;

        //protected volatile bool myIsListening = false;

        protected volatile bool myStopListening = false;

        protected volatile ProcessStoppedListeningReason myStoppedListeningReason = ProcessStoppedListeningReason.None;

        protected volatile Exception myCaughtException;

		protected Thread myThread;

        public BaseProcessOutputRetreiver()
        {

			Initailse();

        }

        public BaseProcessOutputRetreiver(Process TheProcess)
        {

            Process = TheProcess;

			Initailse();

        }

		protected virtual void Initailse()
		{

			myThread = new Thread(() =>
			{
				
				if (myStoppedListeningReason != ProcessStoppedListeningReason.None)
					myStoppedListeningReason = ProcessStoppedListeningReason.None;
				
				if (myCaughtException != null)
					myCaughtException = null;
				
				try
				{
					
					//myIsListening = true;
					
					do
					{
						
						if (!myProcess.StandardOutput.EndOfStream && !myStopListening)
						{
							
							string FetchedStandardOutput = myProcess.StandardOutput.ReadToEnd();
							
							if (!string.IsNullOrEmpty(FetchedStandardOutput))
								StandardOutput(FetchedStandardOutput);
							
						}
						
						if (!myProcess.StandardError.EndOfStream && !myStopListening)
						{
							
							string FetchedStandardErrorOutput = myProcess.StandardError.ReadToEnd();
							
							if (!string.IsNullOrEmpty(FetchedStandardErrorOutput))
								StandardErrorOutput(FetchedStandardErrorOutput);
							
						}
						
						if (myStopListening)
						{
							
							myStoppedListeningReason = ProcessStoppedListeningReason.Canceled;
							
							return;
							
						}
						
						Thread.Yield();
						
					}
					while (!myProcess.HasExited);
					
					myStoppedListeningReason = ProcessStoppedListeningReason.Exited;
					
				}
				catch (Exception e)
				{
					
					myCaughtException = e;
					
					myStoppedListeningReason = ProcessStoppedListeningReason.Exception;
					
				}
				finally
				{
					
					//myIsListening = false;
					
					myIsActive = false;
					
					if(myStopListening)
						myStopListening = false;
					
				}
				
			});
			
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

                if (value != null && (myProcess == null || myProcess.HasExited) && !myIsActive && !myThread.IsAlive)
                {

                    myProcess = value;

                    //myStandardOutputReader = new StreamReader(Stream.Synchronized(myProcess.StandardOutput.BaseStream));

                    //myStandardErrorReader = new StreamReader(Stream.Synchronized(myProcess.StandardError.BaseStream));

                    //AggregateException

                }
				else
				{

					throw new Exception("ProcessOutputListener is active");

				}

            }

        }

        public bool HasProcess
        {

            get
            {

                return myProcess != null;

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

                    throw new Exception("Process not assigned");

                }

				myThread.Start();

            }
            else
            {

                throw new Exception("ProcessOutputListener is active");

            }

        }

        public bool IsActive
        {

            get
            {

                return myIsActive;

            }

        }

        public bool IsListening
        {

            get
            {

                return myThread.IsAlive;

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

        protected abstract void StandardOutput(string TheOutput);

        protected abstract void StandardErrorOutput(string TheOutput);

        protected abstract void CheckStandardOutput(Action<IEnumerable<string>> HasOutputDelegate);

        protected abstract void CheckStandardErrorOutput(Action<IEnumerable<string>> HasOutputDelegate);

    }

    public enum ProcessStoppedListeningReason
    {
 
        None,
        Canceled,
        Exited,
        Exception

    }

}
