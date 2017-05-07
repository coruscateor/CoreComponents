using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents
{

    public struct LazyObjectReflect<T>
        where T : class
    {

        T myObject;

        object[] myArguments;

        public LazyObjectReflect(params object[] values)
        {

            myObject = null;

            myArguments = values;

        }

        public LazyObjectReflect(IEnumerable<object> values)
        {

            myObject = null;

            myArguments = values.ToArray();

        }

        public T Object
        {

            get
            {

                if(myObject == null)
                {

                    int argsLength = myArguments.Length;

                    try
                    {

                        if(argsLength > 0)
                        {

                            myObject = (T)Activator.CreateInstance(typeof(T), myArguments);

                        }
                        else
                        {

                            myObject = Activator.CreateInstance<T>();

                        }

                    }
                    finally
                    {

                        myArguments = null;

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

        public bool TryGet(out T TheObject)
        {

            TheObject = myObject;

            return TheObject != null;

        }

    }

}
