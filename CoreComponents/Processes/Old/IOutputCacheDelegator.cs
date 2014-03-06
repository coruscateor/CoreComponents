using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public interface IOutputCacheDelegator
    {

        Action<string> OutputDelegate
        {

            get;
            set;

        }

        Action<string> ErrorDelegate
        {

            get;
            set;

        }

        uint OutputMax
        {

            get;
            set;

        }

        uint ErrorMax
        {

            get;
            set;

        }

        void FetchOneOutput();

        void FetchOneError();

        void FetchOutput();

        void FetchError();

    }

}
