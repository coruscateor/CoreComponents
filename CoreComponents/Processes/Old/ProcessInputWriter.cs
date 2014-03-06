using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.Processes
{

    public class ProcessInputWriter : IProcessInputWriter
    {

        protected ProcessManager myProcessManager;

        protected StreamWriter myStreamWriter;

        //protected Lazy<List<string>> myLazyStringList = new Lazy<List<string>>();

        public ProcessInputWriter(ProcessManager TheProcessManager, StreamWriter TheStreamWriter)
        {

            myProcessManager = TheProcessManager;

            myStreamWriter = TheStreamWriter;

        }
        
        public void Write(char TheValue)
        {

            myStreamWriter.Write(TheValue);

        }

        public void Write(char[] TheBuffer)
        {

            myStreamWriter.Write(TheBuffer);

        }

        public void Write(string TheValue)
        {

            myStreamWriter.Write(TheValue);

        }

        public void Write(char[] TheBuffer, int Index, int Count)
        {

            myStreamWriter.Write(TheBuffer, Index, Count);

        }

        public void WriteLine(string TheValue)
        {

            myStreamWriter.Write(TheValue);

        }

        public void WriteAll(IEnumerable<string> TheValue)
        {

            foreach (string Item in TheValue)
            {

                myStreamWriter.Write(Item);

            }

        }

        public void WriteAllLines(IEnumerable<string> TheValue)
        {

            foreach (string Item in TheValue)
            {

                myStreamWriter.WriteLine(Item);

            }

        }

        public void Close()
        {

            myStreamWriter.Close();

        }

        public void Dispose()
        {

            myStreamWriter.Dispose();

        }

    }

}
