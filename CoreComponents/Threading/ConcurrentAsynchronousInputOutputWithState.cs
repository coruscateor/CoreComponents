using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentAsynchronousInputOutputWithState<TInput, TOutput> : ConcurrentAsynchronousInputOutput<TInput, TOutput>, IAsynchronousInputOutputWithState<TInput, TOutput>
    {

        private ConcurrentState<string, object> myState;

        public ConcurrentAsynchronousInputOutputWithState(ConcurrentQueue<TInput> TheInputQueue, ConcurrentQueue<TOutput> TheOutputQueue, ConcurrentDictionary<string, object> TheState)
            : base(TheInputQueue, TheOutputQueue)
        {

            myState = new ConcurrentState<string, object>(TheState);

        }

        public IState<string, object> State
        {

            get
            {

                return myState;

            }

        }

    }

}
