using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class EqualityFuncComparer<T> : IEqualityComparer<T>
    {

        readonly Func<T, T, bool> myFunc;

        public EqualityFuncComparer(Func<T, T, bool> func)
        {

            myFunc = func;

        }

        public bool Equals(T x, T y)
        {

            return myFunc(x, y);

        }

        public int GetHashCode(T obj)
        {

            return obj.GetHashCode();

        }

    }

}
