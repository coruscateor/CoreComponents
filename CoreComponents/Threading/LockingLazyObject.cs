using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class LockingLazyObject<T>
        where T : class, new()
    {

        T myObject;

        object myLockingObject;

        public LockingLazyObject()
        {

            myObject = null;

            myLockingObject = new object();

        }

        public T Object
        {

            get
            {

                if(myObject == null)
                {

                    lock(myLockingObject)
                    {

                        if(myObject == null)
                        {

                            myObject = new T();

                        }

                    }

                }

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

    }

}
