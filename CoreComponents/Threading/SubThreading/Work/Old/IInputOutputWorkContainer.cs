using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IInputOutputWorkContainer : IWorkContainer
    {

        //void Execute(object TheInput);

        //void Execute(IEnumerable<object> TheInput);

        IInputQueue<object> PublicInputQueue
        {

            get;

        }

        bool HasInputQueue
        {

            get;

        }

        IOutputQueue<object> PublicOutputQueue
        {

            get;

        }

        bool HasOutputQueue
        {

            get;

        }

        IReadOnlyState<string, object> PublicState
        {

            get;

        }

        bool HasState
        {

            get;

        }

    }

}
