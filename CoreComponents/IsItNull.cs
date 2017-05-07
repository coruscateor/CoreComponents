using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    /// <summary>
    /// A container for testing whether ot not a given reference is null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct IsItNull<T> where T : class
    {

        readonly T myRef;

        public IsItNull(T @ref = null)
        {

            myRef = @ref;

        }

        public T Ref
        {

            get
            {

                if(myRef == null)
                    throw new NullReferenceException("Reference cannot be null");

                return myRef;

            }

        }

        public bool IsNull
        {

            get
            {

                return myRef == null;

            }

        }

        public bool TryGet(out T @ref)
        {

            @ref = myRef;

            return @ref != null;

        }

        public bool Try(Action<T> TheAction)
        {

            if(myRef != null)
            {

                TheAction(myRef);

                return true;

            }

            return false;

        }

        public bool Try(Action<T> TheAction, Action NullRef)
        {

            if(myRef != null)
            {

                TheAction(myRef);

                return true;

            }

            NullRef();

            return false;

        }

    }

}
