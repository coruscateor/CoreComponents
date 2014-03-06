using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.AccessIndication
{

    public class AccessHandler : IAccessHandler
    {

        protected AccessIndicatorInternals myInternals;

        public AccessHandler(AccessIndicatorInternals TheInternals)
        {

            myInternals = TheInternals;

        }

        public bool IsBeingAccessed
        {

            get
            {

                return myInternals.IsBeingAccessed;

            }

        }

        public bool IsNotBeingAccessed
        {

            get
            {

                return myInternals.IsNotBeingAccessed;

            }

        }

        public bool IsBeingAccessedByThisThead
        {

            get
            {

                return myInternals.IsBeingAccessedByThisThead;

            }

        }

        public bool IsNotBeingAccessedByThisThead
        {

            get
            {

                return myInternals.IsNotBeingAccessedByThisThead;

            }

        }

        public virtual void Dispose()
        {

            myInternals.Reset();

        }

    }

    public class AccessHandler<T> : IAccessHandler<T>
    {

        protected AccessIndicatorInternals<T> myInternals;

        public AccessHandler(AccessIndicatorInternals<T> TheInternals)
        {

            myInternals = TheInternals;

        }
        
        public T Item
        {

            get
            {

                return myInternals.Item;

            }

        }

        public bool IsBeingAccessed
        {

            get
            {

                return myInternals.IsBeingAccessed;

            }

        }

        public bool IsNotBeingAccessed
        {

            get
            {

                return myInternals.IsNotBeingAccessed;

            }

        }

        public bool IsBeingAccessedByThisThead
        {

            get
            {

                return myInternals.IsBeingAccessedByThisThead;

            }

        }

        public bool IsNotBeingAccessedByThisThead
        {

            get
            {

                return myInternals.IsNotBeingAccessedByThisThead;

            }

        }

        public virtual void Dispose()
        {
            
            myInternals.Reset();

        }

    }

}
