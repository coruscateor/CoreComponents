using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace CoreComponents
{
    
    public class DynamicAndNot<T> where T : DynamicObject
    {

        protected const string myNullExceptionMessage = "The provided reference cannot be null";

        protected T myItem;

        protected dynamic myX;

        public DynamicAndNot()
        {

            AttemptInstantiation();

        }

        public DynamicAndNot(params object[] TheParameters)
        {

            AttemptInstantiation(TheParameters);

        }

        public DynamicAndNot(T TheItem)
        {

            if(TheItem == null)
                throw new NullReferenceException(myNullExceptionMessage);

            myItem = TheItem;

            myX = TheItem;

        }

        public T Item
        {

            get
            {

                return myItem;

            }
            set
            {

                if(value == null)
                    throw new NullReferenceException(myNullExceptionMessage);

                myItem = value;

                myX = value;

            }

        }

        public dynamic X
        {

            get
            {

                return myX;

            }

        }

        public void AttemptInstantiation()
        {

            myItem = Activator.CreateInstance<T>();

            myX = myItem;

        }

        public void AttemptInstantiation(params object[] TheParameters)
        {
            
            myItem = (T)Activator.CreateInstance(typeof(T), TheParameters);

            myX = myItem;

        }

    }

}
