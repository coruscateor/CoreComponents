using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public interface ISubThread
    {

        void Start();

        bool IsActive
        {

            get;

        }

        void Stop();

        bool StopRequested
        {

            get;

        }

    }

}
