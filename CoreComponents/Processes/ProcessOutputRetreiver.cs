using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreComponents.Processes
{

    public class ProcessOutputRetreiver : BaseProcessOutputRetreiver
    {

        protected ConcurrentQueue<string> myStandardOutputQueue = new ConcurrentQueue<string>();

        protected ConcurrentQueue<string> myStandardErrorOutputQueue = new ConcurrentQueue<string>();

        public ProcessOutputRetreiver()
        {
        }

        public ProcessOutputRetreiver(Process TheProcess)
        {

            Process = TheProcess;

        }

		public int StandardOutputQueueCount
		{

			get
			{

				return myStandardOutputQueue.Count;

			}

		}

		public int StandardErrorOutputQueueCount
		{
			
			get
			{
				
				return myStandardErrorOutputQueue.Count;
				
			}
			
		}

		public bool HasStandardOutput
		{
			
			get
			{
				
				return myStandardOutputQueue.Count > 0;
				
			}
			
		}
		
		public bool HasStandardErrorOutputQueue
		{
			
			get
			{
				
				return myStandardErrorOutputQueue.Count > 0;
				
			}
			
		}

        protected override void StandardOutput(string TheOutput)
        {

            myStandardOutputQueue.Enqueue(TheOutput);

        }

        protected override void StandardErrorOutput(string TheOutput)
        {

            myStandardOutputQueue.Enqueue(TheOutput);

        }

		protected void CheckQueue(ConcurrentQueue<string> OutputQueue, Action<IEnumerable<string>> HasOutputDelegate)
		{

			int OutputQueueCount = OutputQueue.Count;
			
			if (OutputQueueCount == 1)
			{
				
				string Output;
				
				if (myStandardOutputQueue.TryDequeue(out Output))
				{
					
					HasOutputDelegate(new string[] { Output });
					
				}
				
			}
			else if (OutputQueueCount > 1)
			{
				
				Queue<string> AssembledOutput = new Queue<string> ();
				
				while (OutputQueueCount > 0)
				{
					
					string Output;
					
					if (myStandardOutputQueue.TryDequeue(out Output)) {
						
						AssembledOutput.Enqueue(Output);
						
						OutputQueueCount--;
						
					}
					else
					{
						
						HasOutputDelegate(AssembledOutput);
						
						return;
						
					}
					
				}
				
				HasOutputDelegate(AssembledOutput);
				
			}

		}

        protected override void CheckStandardOutput(Action<IEnumerable<string>> HasOutputDelegate)
		{

			CheckQueue(myStandardOutputQueue, HasOutputDelegate);

        }

        protected override void CheckStandardErrorOutput(Action<IEnumerable<string>> HasOutputDelegate)
        {

			CheckQueue(myStandardErrorOutputQueue, HasOutputDelegate);

        }

    }

}
