using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class PublicFuncEvent<TResult> : BasePublicEvent<FuncEvent<TResult>, Func<TResult>>
    {

        public PublicFuncEvent(FuncEvent<TResult> TheEvent) : base(TheEvent)
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults)
        {

            myEvent.Execute(TheResults);

        }

        public void Execute(IInputQueue<TResult> TheResults)
        {

            myEvent.Execute(TheResults);

        }

    }

    public class PublicFuncEvent<TParameter, TResult> : BasePublicEvent<FuncEvent<TParameter, TResult>, Func<TParameter, TResult>>
    {

        public PublicFuncEvent(FuncEvent<TParameter, TResult> TheEvent)
            : base(TheEvent)
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults, TParameter TheParameter)
        {

            myEvent.Execute(TheResults, TheParameter);

        }

        public void Execute(IInputQueue<TResult> TheResults, TParameter TheParameter)
        {

            myEvent.Execute(TheResults, TheParameter);

        }

    }

    public class PublicFuncEvent<TP1, TP2, TResult> : BasePublicEvent<FuncEvent<TP1, TP2, TResult>, Func<TP1, TP2, TResult>>
    {

        public PublicFuncEvent(FuncEvent<TP1, TP2, TResult> TheEvent)
            : base(TheEvent)
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults, TP1 P1, TP2 P2)
        {

            myEvent.Execute(TheResults, P1, P2);

        }

        public void Execute(IInputQueue<TResult> TheResults, TP1 P1, TP2 P2)
        {

            myEvent.Execute(TheResults, P1, P2);

        }

    }

}
