using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class ValueContainer : IValueContainer
    {

        protected object myValue;

        public ValueContainer()
        {
        }

        public ValueContainer(object TheValue)
        {

            myValue = TheValue;

        }

        public virtual object Value
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

        public bool HasValue
        {

            get
            {

                return myValue != null;

            }

        }

    }

    public class ValueContainer<T> : IValueContainer<T>
    {

        protected T myValue;

        public ValueContainer()
        {
        }

        public ValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public virtual T Value
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

    }

}
