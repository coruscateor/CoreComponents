using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    public struct LazyObjectFunc<T>
        where T : class
    {

        T myObject;

        Func<T> myFunc;

        public LazyObjectFunc(Func<T> Func)
        {

            myFunc = Func;

            myObject = null;

        }

        public T Object
        {

            get
            {

                if(myObject == null)
                {

                    myObject = myFunc();

                    myFunc = null;

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

        public bool TryGet(out T TheObject)
        {

            TheObject = myObject;

            return TheObject != null;

        }

    }

}
