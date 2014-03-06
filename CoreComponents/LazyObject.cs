using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public struct LazyObject<T>
        where T : class, new()
    {
        
        T myObject;

        public T Object
        {

            get
            {

                if(myObject == null)
                    myObject = new T();

                return myObject;


            }

        }

        public bool HasObject
        {

            get
            {

                return myObject != null;

            }

        }

        public bool TryGet(out T TheObject)
        {

            if(myObject != null)
            {

                TheObject = myObject;

                return true;

            }

            TheObject = null;

            return false;

        }

    }

}
