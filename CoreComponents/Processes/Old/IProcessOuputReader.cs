using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public interface IProcessOuputReader : IDisposable
    {

        string ReadLine();

        string ReadToEnd();

        IEnumerable<string> ReadLines(int MaxOf = 0);

        void ReadInto(ICollection<string> TheExistingCollection, int MaxOf = 0);

        bool HasEntries
        {

            get;

        }

    }

}
