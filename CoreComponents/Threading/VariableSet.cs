using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class VariableSet<T1, T2> : LockBase
    {

        T1 Value1;

        T2 Value2;

        public void VariableSet()
        {
        }

        public void VariableSet(T1 V1, T2 V2)
        {

            Value1 = V1;

            Value2 = V2;

        }

        public void Set(T1 V1, T2 V2)
        {

            lock(myLockObject)
            {

                Value1 = V1;

                Value2 = V2;

            }

        }

        public void Get(out T1 V1, out T2 V2)
        {

            lock(myLockObject)
            {

                V1 = Value1;

                V2 = Value2;

            }

        }

        public void Get(Action<T1, T2> Act)
        {

            lock(myLockObject)
            {

                Act(Value1, Value2);

            }

        }

    }

    public sealed class VariableSet<T1, T2, T3> : LockBase
    {

        T1 Value1;

        T2 Value2;

        T3 Value3;

        public void VariableSet()
        {
        }

        public void VariableSet(T1 V1, T2 V2, T3 V3)
        {

            Value1 = V1;

            Value2 = V2;

            Value3 = V3;

        }

        public void Set(T1 V1, T2 V2, T3 V3)
        {

            lock(myLockObject)
            {

                Value1 = V1;

                Value2 = V2;

                Value3 = V3;

            }

        }

        public void Get(out T1 V1, out T2 V2, out T3 V3)
        {

            lock(myLockObject)
            {

                V1 = Value1;

                V2 = Value2;

                V3 = Value3;

            }

        }

        public void Get(Action<T1, T2, T3> Act)
        {

            lock(myLockObject)
            {

                Act(Value1, Value2, Value3);

            }

        }

    }

    public sealed class VariableSet<T1, T2, T3, T4> : LockBase
    {

        T1 Value1;

        T2 Value2;

        T3 Value3;

        T4 Value4;

        public void VariableSet()
        {
        }

        public void VariableSet(T1 V1, T2 V2, T3 V3, T4 V4)
        {

            Value1 = V1;

            Value2 = V2;

            Value3 = V3;

            Value4 = V4;

        }

        public void Set(T1 V1, T2 V2, T3 V3, T4 V4)
        {

            lock(myLockObject)
            {

                Value1 = V1;

                Value2 = V2;

                Value3 = V3;

                Value4 = V4;

            }

        }

        public void Get(out T1 V1, out T2 V2, out T3 V3, out T4 V4)
        {

            lock(myLockObject)
            {

                V1 = Value1;

                V2 = Value2;

                V3 = Value3;

                V4 = Value4;

            }

        }

        public void Get(Action<T1, T2, T3, T4> Act)
        {

            lock(myLockObject)
            {

                Act(Value1, Value2, Value3, Value4);

            }

        }

    }

}
