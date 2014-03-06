using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace CoreComponents.Processes
{

    public class ProcessOutputChache : IProcessOuputReader
    {
        
        protected ProcessManager myProcessManager;

        protected Queue<string> myQueue = new Queue<string>();

        public ProcessOutputChache(ProcessManager TheProcessManager)
        {

            myProcessManager = TheProcessManager;

        }

        public string ReadLine()
        {

            try
            {

                return myQueue.Dequeue();

            }
            catch 
            {

                return string.Empty;

            }

        }

        public string ReadToEnd()
        {

            StringBuilder SB = new StringBuilder();

            int Count = myQueue.Count;

            for(; Count > 0; Count--)
            {

                try
                {

                    SB.Append(myQueue.Dequeue());

                }
                catch
                {

                    break;

                }

            }

            return SB.ToString();

        }

        public IEnumerable<string> ReadLines(int MaxOf = 0)
        {

            if (myQueue.Count > 0)
            {

                Queue<string> Lines = new Queue<string>();

                if (MaxOf > 0)
                {

                    if(MaxOf > myQueue.Count)
                    {
                        MaxOf = myQueue.Count;

                    }

                }
                else
                {

                    MaxOf = myQueue.Count;

                }

                for (; MaxOf > 0; MaxOf--)
                {

                    Lines.Enqueue(myQueue.Dequeue());

                }

                return Lines;

            }

            return new string[0];

        }

        public void ReadInto(ICollection<string> TheExistingCollection, int MaxOf = 0)
        {

            if (myQueue.Count > 0)
            {

                if (MaxOf > 0)
                {

                    if (MaxOf > myQueue.Count)
                    {
                        MaxOf = myQueue.Count;

                    }

                }
                else
                {

                    MaxOf = myQueue.Count;

                }

                for (; MaxOf > 0; MaxOf--)
                {

                    TheExistingCollection.Add(myQueue.Dequeue());

                }

            }

        }

        public bool HasEntries
        {

            get 
            {

                return myQueue.Count > 0;
            
            }

        }

        [CallingMethodDeclaringType(typeof(ProcessManager))]
        public void ClearReader(IProcessOuputReader TheReader)
        {

            StackFrame LastFrame =  new StackTrace().GetFrame(0);

            MethodBase CallingMethod = LastFrame.GetMethod();

            if (CallingMethod.DeclaringType != typeof(ProcessManager))
            {

                return;

            }

            while (TheReader.HasEntries)
            {

                myQueue.Enqueue(TheReader.ReadLine());

            }

        }

        public void Dispose()
        {
        }

    }

}
