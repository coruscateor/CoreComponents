using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{
    
    public class ComplicatedClicker : IComplicatedClicker
    {

        protected ComplicatedClickerState myState = ComplicatedClickerState.NotClicked;

        protected SpinLock myClickedSpinLock;

        protected bool myUsesMemoryBarrier;

        protected Exception myException;

        public ComplicatedClicker()
        {
        }

        public ComplicatedClicker(bool UsesMemoryBarrier)
        {

            myUsesMemoryBarrier = UsesMemoryBarrier;

        }

        public ComplicatedClickerState State
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myClickedSpinLock.Enter(ref LockTaken);

                    return myState;

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

            bool Error = false;

            myClickedSpinLock.Enter(ref LockTaken);

            if(myState != ComplicatedClickerState.NotClicked)
            {

                Error = true;

            }
            else
            {

                myState = ComplicatedClickerState.Clicked;

            }

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);

            if(Error)
                throw new Exception("The state has been changed from not Clicked");


        }

        public virtual void Caught(Exception TheException)
        {

            bool LockTaken = false;

            bool Error = false;

            myClickedSpinLock.Enter(ref LockTaken);

            if(myState != ComplicatedClickerState.NotClicked)
            {

                Error = true;

            }
            else
            {

                myState = ComplicatedClickerState.CaughtException;

                myException = TheException;

            }

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);

            if(Error)
                throw new Exception("The state has been changed from not Clicked");

        }

        public virtual void Reset()
        {

            bool LockTaken = false;

            myClickedSpinLock.Enter(ref LockTaken);

            myState = ComplicatedClickerState.NotClicked;

            if(myException != null)
                myException = null;

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);

        }

        public Exception Exception
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myClickedSpinLock.Enter(ref LockTaken);

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        myClickedSpinLock.Exit(myUsesMemoryBarrier);

                }

            }

        }

        public bool TryGetException(out Exception TheException)
        {

            Exception CurrentException = Exception;

            if(CurrentException != null)
            {

                TheException = CurrentException;

                return true;

            }

            TheException = null;

            return false;

        }

        public bool CheckState(Action TheClickedAction, Action<Exception> TheExceptionAction)
        {

            ComplicatedClickerState CurrentState;

            Exception CurrentException;

            bool LockTaken = false;

            myClickedSpinLock.Enter(ref LockTaken);

            CurrentState = ComplicatedClickerState.NotClicked;

            CurrentException = myException;

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);

            switch(CurrentState)
            {

                case ComplicatedClickerState.Clicked:

                    TheClickedAction();

                    break;
                case ComplicatedClickerState.CaughtException:

                    TheExceptionAction(CurrentException);

                    break;

            }

            return false;

        }

        public void CheckState(Action TheNotClickedAction, Action TheClickedAction, Action<Exception> TheExceptionAction)
        {

            ComplicatedClickerState CurrentState;

            Exception CurrentException;

            bool LockTaken = false;

            myClickedSpinLock.Enter(ref LockTaken);

            CurrentState = ComplicatedClickerState.NotClicked;

            CurrentException = myException;

            if(LockTaken)
                myClickedSpinLock.Exit(myUsesMemoryBarrier);

            switch(CurrentState)
            {

                case ComplicatedClickerState.NotClicked:

                    TheNotClickedAction();

                    break;
                case ComplicatedClickerState.Clicked:

                    TheClickedAction();

                    break;
                case ComplicatedClickerState.CaughtException:

                    TheExceptionAction(CurrentException);

                    break;

            }

        }

    }

}
