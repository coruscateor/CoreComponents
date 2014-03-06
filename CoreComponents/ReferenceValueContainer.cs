using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class ReferenceValueContainer<T> : ValueContainer<T> where T : class
    {

        public ReferenceValueContainer()
        {
        }

        public ReferenceValueContainer(T TheValue)
            : base(TheValue)
        {
        }

        public bool ValueIsNull
        {

            get
            {

                return myValue == null;

            }

        }

        public bool ValueIsNotNull
        {

            get
            {

                return myValue != null;

            }

        }

        public bool TryGetValue(out T TheValue)
        {

            if(myValue != null)
            {

                TheValue = myValue;

                return true;

            }

            TheValue = null;

            return false;

        }

    }

}
