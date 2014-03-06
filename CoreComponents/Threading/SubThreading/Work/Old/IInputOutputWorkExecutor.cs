using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IWorkExecutorTakingParametersWithOutput : IInputWorkExecutor, IOutput
    {
    }

    public interface IWorkExecutorTakingParametersWithOutput<T> : IWorkExecutorTakingParameters<T>, IOutput
    {
    }

}
