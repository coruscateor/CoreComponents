using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IAsynchronousInputOutput
    {

        IInputOutputQueue<object> Input
        {

            get;

        }

        IInputOutputQueue<object> Output
        {

            get;

        }

        /*
         
        IState<string, object> State
        {

            get;

        }

        */

        //IInputQueue<object> PublicInput
        //{

        //    get;

        //}

        //IOutputQueue<object> PublicOutput
        //{

        //    get;

        //}

        //IReadOnlyState<string, object> PublicState
        //{

        //    get;

        //}

        //int FlushQueue<T>(ConcurrentQueue<T> TheQueue);

        //int FlushInput();

        //int FlushOutput();

        //int FlushQueues();

        //int FlushQueuesAndClearState();

    }

    public interface IAsynchronousInputOutput<TInput, TOutput>
    {

        IInputOutputQueue<TInput> Input
        {

            get;

        }

        IInputOutputQueue<TOutput> Output
        {

            get;

        }

    }

}
