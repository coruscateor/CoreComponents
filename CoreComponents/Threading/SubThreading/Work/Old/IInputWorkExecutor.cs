using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IInputWorkExecutor
    {

        void PassAndCheck(IEnumerable<object> TheParameters);

    }

    public interface IWorkExecutorTakingParameters<T>
    {

        void PassAndCheck(IEnumerable<T> TheParameters);

    }

}