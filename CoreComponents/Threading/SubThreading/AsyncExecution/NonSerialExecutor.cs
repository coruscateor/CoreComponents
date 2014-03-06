using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.AsyncExecution
{

    public abstract class NonSerialExecutor
    {

        protected Task myTask;

        public NonSerialExecutor()
        {

            myTask = new Task(ExecuteMethod);

        }

        protected virtual void ExecuteMethod()
        {

            Execute();

        }

        protected abstract void Execute();

    }

}
