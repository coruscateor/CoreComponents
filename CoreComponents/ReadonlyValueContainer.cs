using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public class ReadonlyValueContainer : IReadonlyValueContainer
    {

        protected object myValue;

        public ReadonlyValueContainer()
        {
        }

        public ReadonlyValueContainer(object TheValue)
        {

            myValue = TheValue;

        }

        public object Value
        {

            get
            {

                return myValue;

            }

        }

        public bool HasValue
        {

            get
            {
                
                return myValue != null;
            
            }

        }

    }

    public class ReadonlyValueContainer<T> : IReadonlyValueContainer<T>
    {

        protected T myValue;

        public ReadonlyValueContainer()
        {
        }

        public ReadonlyValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public T Value
        {

            get
            {

                return myValue;

            }

        }

    }

}
