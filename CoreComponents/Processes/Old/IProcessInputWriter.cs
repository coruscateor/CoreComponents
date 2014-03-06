using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public interface IProcessInputWriter : IDisposable
    {

        void Write(char TheValue);

        void Write(char[] TheBuffer);

        void Write(string TheValue);

        void Write(char[] TheBuffer, int Index, int Count);

        void WriteLine(string TheValue);

        void WriteAll(IEnumerable<string> TheValue);
        
        void WriteAllLines(IEnumerable<string> TheValue);

        void Close();

    }

}
