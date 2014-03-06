using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    public class SlimWaitAccessHandler : IAccessHandler
    {

        protected SlimWaitAccessIndicatorInternals myInternals;

        public SlimWaitAccessHandler(SlimWaitAccessIndicatorInternals TheInternals)
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

    public class SlimWaitAccessHandler<T> : IAccessHandler<T>
    {

        protected SlimWaitAccessIndicatorInternals<T> myInternals;

        public SlimWaitAccessHandler(SlimWaitAccessIndicatorInternals<T> TheInternals)
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
        
        public T Item
        {

            get
            {

                return myInternals.Item;

            }

        }

    }

}
