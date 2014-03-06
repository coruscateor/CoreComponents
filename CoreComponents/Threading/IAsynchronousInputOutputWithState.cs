using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IAsynchronousInputOutputWithState : IAsynchronousInputOutput, IHasState
    {

        IState<string, object> State
        {

            get;

        }

    }

    public interface IAsynchronousInputOutputWithState<TInput, TOutput> : IAsynchronousInputOutput<TInput, TOutput>, IHasState
    {

        IState<string, object> State
        {

            get;

        }

    }

}
