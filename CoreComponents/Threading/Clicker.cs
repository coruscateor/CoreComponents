using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class Clicker : IClicker, IUsesMemoryBarrier
    {

        protected bool myIsClicked;

        protected SpinLock myClickedSpinLock;

        protected bool myUsesMemoryBarrier;

        public Clicker()
        {
        }

        public Clicker(bool UsesMemoryBarrier)
        {

            myUsesMemoryBarrier = UsesMemoryBarrier;

        }

        public bool IsClicked
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myClickedSpinLock.Enter(ref LockTaken);

                    return myIsClicked;

                }
                finally
                {

                    if(LockTaken)
                        myClickedSpinLock.Exit(myUsesMemoryBarrier);

                }

            }

        }

        public bool UsesMemoryBarrier
        {

            get
            {

                return myUsesMemoryBarrier;

            }
            set
            {

                myUsesMemoryBarrier = value;

            }

        }

        public virtual void Click()
        {

            bool LockTaken = false;

            myClickedSpinLock.Enter(ref LockTaken);

            myIsClicked = true;

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);



        }

        public virtual void Reset()
        {

            bool LockTaken = false;

            myClickedSpinLock.Enter(ref LockTaken);

            myIsClicked = false;

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);

        }

    }

}
