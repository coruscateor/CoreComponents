using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public interface IApplicationManager : IDisposable
    {

        void Execute(string TheApplicationPath, string TheArgumentsString = "", string TheName = "");

        void Execute();

        string FilePath
        {

            get;
            set;

        }

        IEnumerable<string> ArgumentsEnumerator
        {

            get;
            set;

        }

        int ArgumentsCount
        {

            get;

        }

        void SetArguments(string TheArgumentsString);

        int ReturnCode
        {

            get;

        }

        void Kill();

    }

}
