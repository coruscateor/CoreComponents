using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public abstract class Parameters<T1, T2> : IReset
    {

        public T1 P1
        {

            get;
            set;

        }

        public T2 P2
        {

            get;
            set;

        }

        public void Set(T1 p1, T2 p2)
        {

            P1 = p1;

            P2 = p2;

        }

        public virtual void Reset()
        {

            P1 = default(T1);

            P2 = default(T2);

        }

    }

    public abstract class Parameters<T1, T2, T3> : Parameters<T1, T2>, IReset
    {
        
        public T3 P3
        {

            get;
            set;

        }

        public void Set(T1 p1, T2 p2, T3 p3)
        {

            P1 = p1;

            P2 = p2;

            P3 = p3;

        }

        public override void Reset()
        {

            base.Reset();

            P3 = default(T3);

        }

    }

    public abstract class Parameters<T1, T2, T3, T4> : Parameters<T1, T2, T3>, IReset
    {

        public T4 P4
        {

            get;
            set;

        }

        public void Set(T1 p1, T2 p2, T3 p3, T4 p4)
        {

            P1 = p1;

            P2 = p2;

            P3 = p3;

            P4 = p4;

        }

        public override void Reset()
        {

            base.Reset();

            P4 = default(T4);

        }

    }

}
