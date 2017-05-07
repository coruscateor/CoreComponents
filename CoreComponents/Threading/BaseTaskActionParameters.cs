using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public abstract class BaseTaskActionParameters<T> : IReset
    {
        
        public T P
        {

            get;
            set;

        }

        public Action<T> Action
        {

            get;
            set;

        }
        
        public void Set(Action<T> action, T p)
        {

            Action = action;

            P = p;

        }

        public void Reset()
        {

            P = default(T);

            Action = null;

        }

    }

    public abstract class BaseTaskActionParameters<T1, T2> : Parameters<T1, T2>, IReset
    {

        public Action<T1, T2> Action
        {

            get;
            set;

        }


        public void Set(Action<T1, T2> action, T1 p1, T2 p2)
        {

            Action = action;

            Set(p1, p2);

        }

        public override void Reset()
        {

            base.Reset();

            Action = null;

        }

    }

    public abstract class BaseTaskActionParameters<T1, T2, T3> : Parameters<T1, T2, T3>, IReset
    {

        public Action<T1, T2, T3> Action
        {

            get;
            set;

        }

        public void Set(Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {

            Action = action;

            Set(p1, p2, p3);

        }

        public override void Reset()
        {

            base.Reset();

            Action = null;

        }

    }

    public abstract class BaseTaskActionParameters<T1, T2, T3, T4> : Parameters<T1, T2, T3, T4>, IReset
    {
        
        public Action<T1, T2, T3, T4> Action
        {

            get;
            set;

        }

        public void Set(Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            Action = action;

            Set(p1, p2, p3, p4);

        }

        public override void Reset()
        {

            base.Reset();

            Action = null;

        }

    }

}
