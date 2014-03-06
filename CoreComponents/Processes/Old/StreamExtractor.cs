using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.Processes
{

    public class StreamExtractor
    {

        protected StreamReader myStreamReader;

        public StreamExtractor()
        {
        }

        public StreamReader StreamReader
        {

            get
            {

                return myStreamReader;

            }
            set
            {

                myStreamReader = value;

            }

        }

        public bool HasStreamReader
        {

            get
            {

                return myStreamReader != null;

            }

        }

        public void SetReaderNull()
        {

            myStreamReader = null;

        }

        //public int Peek()
        //{

        //    return myStreamReader.Peek();

        //}

        //public string ReadLine()
        //{

        //    return myStreamReader.ReadLine();

        //}

        public IEnumerable<string> ReadLines()
        {
 
            Queue<string> OutputSet = new Queue<string>();

            while(!myStreamReader.EndOfStream)
            {

                OutputSet.Enqueue(myStreamReader.ReadLine());

            }

            return OutputSet;

        }

        public IEnumerable<string> ReadLines(int MaxOf)
        {

            Queue<string> OutputSet = new Queue<string>();

            if(MaxOf < 1)
            {

                while(!myStreamReader.EndOfStream)
                {

                    OutputSet.Enqueue(myStreamReader.ReadLine());

                }

            }
            else
            {

                while(!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    OutputSet.Enqueue(myStreamReader.ReadLine());

                    MaxOf--;

                }

            }

            return OutputSet.ToArray();

        }

        public void ReadInto(ICollection<string> TheExistingCollection)
        {

            while(!myStreamReader.EndOfStream)
            {

                TheExistingCollection.Add(myStreamReader.ReadLine());

            }

        }

        public void ReadInto(ICollection<string> TheExistingCollection, int MaxOf)
        {

            if(MaxOf < 1)
            {

                while(!myStreamReader.EndOfStream)
                {

                    TheExistingCollection.Add(myStreamReader.ReadLine());

                }

            }
            else if (MaxOf > 0)
            {

                while(!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    TheExistingCollection.Add(myStreamReader.ReadLine());

                    MaxOf--;

                }

            }

        }

        public void ReadInto(Queue<string> TheExistingCollection)
        {

            while(!myStreamReader.EndOfStream)
            {

                TheExistingCollection.Enqueue(myStreamReader.ReadLine());

            }

        }

        public void ReadInto(Queue<string> TheExistingCollection, int MaxOf = 0)
        {

            if(MaxOf < 1)
            {

                while (!myStreamReader.EndOfStream)
                {

                    TheExistingCollection.Enqueue(myStreamReader.ReadLine());

                }

            }
            else if(MaxOf > 0)
            {

                while(!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    TheExistingCollection.Enqueue(myStreamReader.ReadLine());

                    MaxOf--;

                }

            }

        }

        public void ReadInto(Action<string> TheAction)
        {

            while(!myStreamReader.EndOfStream)
            {

                TheAction(myStreamReader.ReadLine());

            }

        }

        public void ReadInto(Action<string> TheAction, int MaxOf = 0)
        {

            if (MaxOf < 1)
            {

                while(!myStreamReader.EndOfStream)
                {

                    TheAction(myStreamReader.ReadLine());

                }

            }
            else if (MaxOf > 0)
            {

                while(!myStreamReader.EndOfStream && MaxOf > 0)
                {

                    TheAction(myStreamReader.ReadLine());

                    MaxOf--;

                }

            }

        }

        public void ReadLine(Action<string> TheDelegate)
        {

            if(!myStreamReader.EndOfStream)
            {

                TheDelegate(myStreamReader.ReadLine());

            }

        }

        public void ReadAllLines(Action<string> TheDelegate)
        {

            while(!myStreamReader.EndOfStream)
            {

                TheDelegate(myStreamReader.ReadLine());

            }

        }

        //public string ReadToEnd()
        //{

        //    return myStreamReader.ReadToEnd();

        //}

        public bool HasEntries
        {

            get
            {

                return !myStreamReader.EndOfStream;

            }

        }

        //public int Read(char[] buffer, int index, int count)
        //{

        //    return myStreamReader.Read(buffer, index, count);

        //}

        //public int ReadBlock(char[] buffer, int index, int count)
        //{

        //    return myStreamReader.ReadBlock(buffer, index, count);

        //}

        public void Close()
        {

            myStreamReader.Close();

            //myStreamReader = null;

        }

        public void Dispose()
        {

            myStreamReader.Dispose();

            //myStreamReader = null;

        }

    }

}
