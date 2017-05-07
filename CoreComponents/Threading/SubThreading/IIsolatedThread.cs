using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public interface IIsolatedThread //<TID>
    {

        //TID Id
        //{

        //    get;

        //}

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

        Exception Exception
        {

            get;

        }

        bool TryGetException(out Exception Ex);

        bool HasException
        {

            get;

        }

    }

    //public interface IIsolatedThread : IIsolatedThread<Guid>
    //{
    //}

}
