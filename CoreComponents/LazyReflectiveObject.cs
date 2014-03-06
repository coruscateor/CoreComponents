using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents
{

    public struct LazyReflectiveObject<T>
        where T : class
    {

        T myObject;

        List<object> myArguments;

        public LazyReflectiveObject(object value)
        {

            myObject = null;

            myArguments = new List<object>();

            myArguments.Add(value);

        }
        public LazyReflectiveObject(IEnumerable<object> values)
        {

            myObject = null;

            myArguments = new List<object>(values);

        }

        public LazyReflectiveObject(params object[] values)
        {

            myObject = null;

            myArguments = new List<object>(values);

        }

        public T Object
        {

            get
            {

                if(myObject == null)
                {

                    Type ObjectType = typeof(T);

                    List<Type> ParamerterTypes = new List<Type>();

                    foreach (object Item in myArguments)
                    {

                        ParamerterTypes.Add(Item.GetType());

                    }

                    Type[] ParamerterTypesArray = ParamerterTypes.ToArray();

                    ConstructorInfo ObjectInfo = ObjectType.GetConstructor(ParamerterTypesArray);

                    myObject = (T)ObjectInfo.Invoke(myArguments.ToArray());

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
