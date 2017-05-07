using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public abstract class BaseByRef<T>
    {

        T myRef;

        bool myIsAssigned;

        public BaseByRef()
        {
        }

        public BaseByRef(T @ref)
        {

            myRef = @ref;

            myIsAssigned = true;

        }

        public T Ref
        {

            get
            {

                return myRef;

            }
            set
            {

                myRef = value;

                Volatile.Write(ref myIsAssigned, true);

            }

        }

        public bool IsAssigned
        {

            get
            {

                return Volatile.Read(ref myIsAssigned);

            }

        }

        public bool TryGet(out T @ref)
        {

            if(IsAssigned)
            {

                @ref = myRef;

                return true;

            }

            @ref = default(T);

            return false;

        }

        public bool TryGetWait(out T @ref, int spins = 10)
        {

            if(IsAssigned)
            {

                @ref = myRef;

                return true;

            }

            SpinWait sw = new SpinWait();

            while(spins > 0)
            {

                if(IsAssigned)
                {

                    @ref = myRef;

                    return true;

                }

                sw.SpinOnce();

                --spins;

            }

            @ref = default(T);

            return false;

        }

        public bool TryGetWaitContinuous(out T @ref)
        {

            if(IsAssigned)
            {

                @ref = myRef;

                return true;

            }

            SpinWait sw = new SpinWait();

            while(!IsAssigned)
                sw.SpinOnce();

            @ref = myRef;

            return true;

        }

        public bool IsDefualt()
        {

            return object.Equals(myRef, default(T));

        }

        public bool IsDefualt(IEqualityComparer<T> comparer)
        {

            return comparer.Equals(myRef, default(T));

        }

        public bool IsDefualt(Func<T, T, bool> func)
        {

            return func(myRef, default(T));

        }

        public void Reset()
        {

            myRef = default(T);

            //Volatile.Write(ref myIsAssigned, false);

            myIsAssigned = false;

        }

    }

}
