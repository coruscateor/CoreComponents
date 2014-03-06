using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.AccessIndication
{

    public interface IAccessHandler : IDisposable
    {

        bool IsBeingAccessed
        {

            get;

        }

        bool IsNotBeingAccessed
        {

            get;

        }

        bool IsBeingAccessedByThisThead
        {

            get;

        }

        bool IsNotBeingAccessedByThisThead
        {

            get;

        }

    }

    public interface IAccessHandler<T> : IAccessHandler
    {

        T Item
        {

            get;

        }

    }

}
