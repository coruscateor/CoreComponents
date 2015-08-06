using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public struct CouldBeNull<T> : ICloneable<CouldBeNull<T>> where T : class
    {

        T myItem;

        public CouldBeNull(T TheItem)
        {

            myItem = TheItem;

        }

        public T Item
        {

            get
            {

                return myItem;

            }
            set
            {

                myItem = value;

            }

        }

        public bool IsNull
        {

            get
            {

                return myItem == null;

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

        public ReadonlyCouldBeNull<T> ToReadonly()
        {

            return new ReadonlyCouldBeNull<T>(myItem);

        }

        public CouldBeNull<T> Clone()
        {

            return new CouldBeNull<T>(myItem);

        }

        object ICloneable.Clone()
        {

            return new CouldBeNull<T>(myItem);

        }

    }

}
