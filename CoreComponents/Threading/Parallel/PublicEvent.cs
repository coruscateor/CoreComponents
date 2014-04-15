using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CoreComponents.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class PublicEvent : BasePublicEvent<Event, Delegate>, IExecute
    {

        public PublicEvent(Event TheEvent) : base(TheEvent)
        {
        }

        public void Execute()
        {

            myEvent.Execute();

        }

        public void Execute(params object[] TheParameters)
        {

            myEvent.Execute(TheParameters);

        }

        public void Execute(ConcurrentQueue<object> TheQueue)
        {

            myEvent.Execute(TheQueue);

        }

        public void Execute(ConcurrentQueue<object> TheQueue, params object[] TheParameters)
        {

            myEvent.Execute(TheQueue, TheParameters);

        }

        public void Execute(IInputQueue<object> TheQueue)
        {

            myEvent.Execute(TheQueue);

        }

        public void Execute(IInputQueue<object> TheQueue, params object[] TheParameters)
        {

            myEvent.Execute(TheQueue, TheParameters);

        }

    }

}
