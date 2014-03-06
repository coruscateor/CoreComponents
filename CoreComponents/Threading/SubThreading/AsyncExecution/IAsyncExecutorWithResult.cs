using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.AsyncExecution
{
    interface IAsyncExecutorWithResult : IAsyncExecutor
    {

        void Execute(object TheInput);

        bool GetResult(ref object TheValue);

    }

    public interface IAsyncExecutorWithResult<in TIn, in TOut> : IAsyncExecutorWithResult, IAsyncExecutor<TIn>
    {

        void Execute(TIn TheInput);

        bool GetResult(ref TOut TheValue);

    }

    public interface IAsyncExecutorWithResult<in TIn1, in TIn2, in TOut>
    {

        void Execute(TIn1 TheInput1, TIn2 TheInput2);

        bool GetResult(ref TOut TheValue);

    }

    public interface IAsyncExecutorWithResult<in TIn1, in TIn2, in TIn3, in TOut>
    {

        void Execute(TIn1 TheInput1, TIn2 TheInput2, TIn3 TheInput3);

        bool GetResult(ref TOut TheValue);

    }

    public interface IAsyncExecutorWithResult<in TIn1, in TIn2, in TIn3, in TIn4, in TOut>
    {

        void Execute(TIn1 TheInput1, TIn2 TheInput2, TIn3 TheInput3, TIn4 TheInput4);

        bool GetResult(ref TOut TheValue);

    }
}
