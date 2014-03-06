using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.AsyncExecution
{

    public interface IAsyncExecutor
    {

        void Execute(object TheInput);

    }

    public interface IAsyncExecutor<in TIn> : IAsyncExecutor
    {

        void Execute(TIn TheInput);

    }

}
