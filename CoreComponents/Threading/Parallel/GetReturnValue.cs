using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class GetReturnValue<T> : GetException
    {

        protected T myReturnValue;

        protected bool myValueIsClass;

        public GetReturnValue()
        {

            myValueIsClass = typeof(T).IsClass;

        }

        public T ReturnValue
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myReturnValue;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    myReturnValue = value;

                    myIsActive = false;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool ValueIsClass
        {

            get
            {

                return myValueIsClass;

            }

        }

        public bool TryGetValue(out T TheValue)
        {

            T CurrentValue = ReturnValue;

            if(myValueIsClass)
            {

                if(!CurrentValue.Equals(default(T)))
                {

                    TheValue = CurrentValue;

                    return true;

                }

                TheValue = default(T);

                return false;

            }

            TheValue = CurrentValue;

            return true;

        }

        public bool CheckValue(Action<T> TheAction)
        {

            T CurrentValue = ReturnValue;

            if(myValueIsClass)
            {

                if(!CurrentValue.Equals(default(T)))
                {

                    TheAction(CurrentValue);

                    return true;

                }

                return false;

            }

            TheAction(CurrentValue);

            return true;

        }

        public CallCheckResult Check(Action<T> TheValueAction, Action<Exception> TheExceptionAction)
        {

            T CurrentValue;

            if(TryGetValue(out CurrentValue))
            {

                TheValueAction(CurrentValue);

                return CallCheckResult.Value;

            }

            Exception CurrentException;

            if(TryGetException(out CurrentException))
            {

                TheExceptionAction(CurrentException);

                return CallCheckResult.Exception;

            }

            return CallCheckResult.Neither;

        }

        public override void Reset()
        {

            base.Reset();

            bool LockTaken = false;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                myReturnValue = default(T);

            }
            finally
            {

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

        //[NotSupported]
        //public override void SetInActive()
        //{

        //    throw new NotSupportedException();

        //}

    }

}
