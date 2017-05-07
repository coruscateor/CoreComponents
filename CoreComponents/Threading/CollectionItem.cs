using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public class CollectionItem<T> : ICloneable<CollectionItem<T>>
    {

        T myValue;

        long myTime;

        public CollectionItem(T TheValue, long TheTime)
        {

            myValue = TheValue;

            myTime = TheTime;

        }

        public T Value
        {

            get
            {

                return myValue;

            }
            set
            {

                myValue = value;

            }

        }

        public long Time
        {

            get
            {

                return myTime;

            }
            set
            {

                myTime = value;

            }

        }

        public CollectionItem<T> Clone()
        {

            return new CollectionItem<T>(myValue, myTime);

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

    }

}
