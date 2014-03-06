using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public interface IBaseIsolatedTask : ISubThread, IDisposable
    {

        void ReInstantiateTask();

    }

}
