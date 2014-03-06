using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CoreComponents.Processes
{

    public class ProcessOutputReader : IProcessOuputReader
    {

        protected ProcessManager myProcessManager;

        protected StreamReader myStreamReader;

        protected Lazy<List<string>> myLazyStringList = new Lazy<List<string>>();

        public ProcessOutputReader(ProcessManager TheProcessManager, StreamReader TheStreamReader)
        {

            myProcessManager = TheProcessManager;

            myStreamReader = TheStreamReader;

        }

        public int Peek()
        {

            return myStreamReader.Peek();

        }

        public string ReadLine()
        {

            return myStreamReader.ReadLine();

        }

        public IEnumerable<string> ReadLines(int MaxOf = 0)
        {

            try
            {

                if (MaxOf < 1)
                {

                    while (!myStreamReader.EndOfStream)
                    {

                        myLazyStringList.Value.Add(myStreamReader.ReadLine());

                    }

                }
                else 
                {

                    while (MaxOf > 0 && !myStreamReader.EndOfStream)
                    {

                        myLazyStringList.Value.Add(myStreamReader.ReadLine());

                        MaxOf--;

                    }


                }

                return myLazyStringList.Value.ToArray();

            }
            finally
            {

                myLazyStringList.Value.Clear();

            }

        }

        public void ReadInto(ICollection<string> TheExistingCollection, int MaxOf = 0) 
        {

            if (MaxOf < 1)
            {

                while (!myStreamReader.EndOfStream)
                {

                    TheExistingCollection.Add(myStreamReader.ReadLine());

                }

            }
            else if (MaxOf > 0)
            {

                while (!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    TheExistingCollection.Add(myStreamReader.ReadLine());

                    MaxOf--;

                }

            }

        }

        public string ReadToEnd()
        {

            return myStreamReader.ReadToEnd();

        }

        public bool HasEntries
        {

            get 
            {

                return !myStreamReader.EndOfStream;

            }

        }

        public int Read(char[] buffer, int index, int count)
        {

            return myStreamReader.Read(buffer, index, count);

        }

        public int ReadBlock(char[] buffer, int index, int count)
        {

            return myStreamReader.ReadBlock(buffer, index, count);

        }

        public void Close()
        {

            myStreamReader.Close();
            
        }

        public void Dispose()
        {

            myStreamReader.Dispose();
            
        }

    }

}
