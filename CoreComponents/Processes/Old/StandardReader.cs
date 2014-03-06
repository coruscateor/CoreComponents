using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CoreComponents.Processes
{

    public abstract class StandardReader
    {

        protected Process myProcess;

        protected StreamReader myStreamReader;

        public StandardReader()
        {
        }

        public StandardReader(Process TheProcess)
        {

            myProcess = TheProcess;

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

                SetOutputStream();

            }

        }

        public bool HasProcess
        {

            get
            {

                return myProcess != null;

            }

        }

        protected abstract void SetOutputStream();

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

            Queue<string> OutputSet = new Queue<string>();

            if (MaxOf < 1)
            {

                while (!myStreamReader.EndOfStream)
                {

                    OutputSet.Enqueue(myStreamReader.ReadLine());

                }

             }
             else 
             {

                 while (!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    OutputSet.Enqueue(myStreamReader.ReadLine());

                    MaxOf--;

                }

             }

             return OutputSet.ToArray();

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

        public void ReadInto(Queue<string> TheExistingCollection, int MaxOf = 0)
        {

            if (MaxOf < 1)
            {

                while (!myStreamReader.EndOfStream)
                {

                    TheExistingCollection.Enqueue(myStreamReader.ReadLine());

                }

            }
            else if (MaxOf > 0)
            {

                while (!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    TheExistingCollection.Enqueue(myStreamReader.ReadLine());

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
