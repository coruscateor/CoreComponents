using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.AccessIndication
{

    public interface IAccessIndicator : IReset, IDisposable
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

        //bool TryAccess(out AccessHandler TheAccessHandler);

    }

    public interface IAccessIndicator<T> : IReset, IDisposable
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

        //bool TryAccess(out AccessHandler<T> TheAccessHandler);
        
    }

}
