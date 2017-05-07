using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public abstract class BaseTaskFuncParameters<T, TResult> : IReset
    {

        public T P
        {

            get;
            set;

        }

        public Func<T, TResult> Func
        {

            get;
            set;

        }

        public void Set(Func<T, TResult> func, T p)
        {

            Func = func;

            P = p;

        }

        public void Reset()
        {

            P = default(T);

            Func = null;

        }

    }

    public abstract class BaseTaskFuncParameters<T1, T2, TResult> : Parameters<T1, T2>, IReset
    {

        public Func<T1, T2, TResult> Func
        {

            get;
            set;

        }

        public void Set(Func<T1, T2, TResult> func, T1 p1, T2 p2)
        {

            Func = func;

            Set(p1, p2);

        }

        public override void Reset()
        {

            base.Reset();

            Func = null;

        }

    }

    public abstract class BaseTaskFuncParameters<T1, T2, T3, TResult> : Parameters<T1, T2, T3>, IReset
    {

        public Func<T1, T2, T3, TResult> Func
        {

            get;
            set;

        }

        public void Set(Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3)
        {

            Func = func;

            Set(p1, p2, p3);

        }

        public override void Reset()
        {

            base.Reset();

            Func = null;

        }

    }

    public abstract class BaseTaskFuncParameters<T1, T2, T3, T4, TResult> : Parameters<T1, T2, T3, T4>, IReset
    {

        public Func<T1, T2, T3, T4, TResult> Func
        {

            get;
            set;

        }

        public void Set(Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            Func = func;

            Set(p1, p2, p3, p4);

        }

        public override void Reset()
        {

            base.Reset();

            Func = null;

        }

    }

}
