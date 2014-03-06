using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public interface ICommunicableSubThread : ISubThread //: ISubThreadExecutable
    {

        IInputQueue<object> Input
        {

            get;

        }

        IOutputQueue<object> Output
        {

            get;

        }

        IReadOnlyState<string, object> State
        {

            get;

        }

    }

}
