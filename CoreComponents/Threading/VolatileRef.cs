using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class VolatileRef<T> : IReset where T : class
    {

        T myRef;

        public VolatileRef()
        {
        }

        public VolatileRef(T @ref)
        {

            myRef = @ref;

        }

        //public static VolatileRef<T> FromCache()
        //{

        //    return ObjectReuseCaches<VolatileRef<T>>.Get();

        //}

        //public static VolatileRef<T> FromCache(T item)
        //{

        //    var @ref = ObjectReuseCaches<VolatileRef<T>>.Get();

        //    @ref.Ref = item;

        //    return @ref;

        //}

        public T Ref
        {

            get
            {

                return Volatile.Read<T>(ref myRef);

            }
            set
            {

                Volatile.Write<T>(ref myRef, value);

            }

        }

        public bool TryGet(out T @ref)
        {

            @ref = Volatile.Read<T>(ref myRef);

            return @ref != null;

        }

        public void Reset()
        {

            myRef = default(T);

        }

    }

}
