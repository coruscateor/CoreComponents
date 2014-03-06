using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public interface IIsolatedWaitForSingleObject<TTimeoutInterval> : ISubThread
    {
        
        TTimeoutInterval TimeoutInterval
        {

            get;
            set;

        }

        bool ExecuteOnlyOnce
        {

            get;
            set;

        }


    }

}
