using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.AccessIndication
{

    public interface IAccessIndicatorInternals : IReset
    {

        int CurrentThreadId
        {

            get;

        }

        void SetCurrentThread();

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

        bool IsBeingAccessed
        {

            get;

        }

    }

    public interface IAccessIndicatorInternals<T> : IAccessIndicatorInternals
    {

        T Item
        {

            get;

        }
    
    }

}
