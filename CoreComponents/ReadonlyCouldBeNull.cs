using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public struct ReadonlyCouldBeNull<T> : ICloneable<ReadonlyCouldBeNull<T>> where T : class
    {

        readonly T myItem;

        public ReadonlyCouldBeNull(T TheItem)
        {

            myItem = TheItem;

        }

        public T Item
        {

            get
            {

                return myItem;

            }

        }

        public bool IsNull
        {

            get
            {

                return myItem != null;

            }

        }

        public bool TryGet(out T TheItem)
        {

            if(myItem != null)
            {

                TheItem = myItem;

                return true;

            }

            TheItem = null;

            return false;

        }

        public bool Try(Action<T> TheAction)
        {

            if(myItem != null)
            {

                TheAction(myItem);

                return true;

            }

            return false;

        }

        public CouldBeNull<T> ToMutable()
        {

            return new CouldBeNull<T>(myItem);

        }

        public ReadonlyCouldBeNull<T> Clone()
        {

            return new ReadonlyCouldBeNull<T>(myItem);

        }

        object ICloneable.Clone()
        {

            return new ReadonlyCouldBeNull<T>(myItem);

        }

    }

}
