using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.AccessIndication
{

    public class WaitAccessHandler : IAccessHandler
    {

        protected WaitAccessIndicatorInternals myInternals;

        public WaitAccessHandler(WaitAccessIndicatorInternals TheInternals)
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

    public class WaitAccessHandler<T> : IAccessHandler<T>
    {

        protected WaitAccessIndicatorInternals<T> myInternals;

        public WaitAccessHandler(WaitAccessIndicatorInternals<T> TheInternals)
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
