using System;
using System.Collections.Generic;
using System.Text;

namespace CoreComponents
{

    public struct DisposableReference<T> : IValueContainer<T>, IDisposable where T : class
    {

        T myValue;

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

        public void Instantiate()
        {

            myValue = Activator.CreateInstance<T>();

        }

        public void Instantiate(params object[] TheParams)
        {

            myValue = (T)Activator.CreateInstance(typeof(T), TheParams);

        }

        public void Instantiate(IEnumerable<object> TheParams)
        {

            Instantiate(new List<object>(TheParams).ToArray());

        }

        public void Instantiate(List<object> TheParams)
        {

            Instantiate(TheParams.ToArray());

        }

        public void Instantiate(Queue<object> TheParams)
        {

            Instantiate(TheParams.ToArray());

        }

        public void Instantiate(Stack<object> TheParams)
        {

            Instantiate(TheParams.ToArray());

        }

        public void Instantiate(SortedSet<object> TheParams)
        {

            int Count = TheParams.Count;

            if(Count > 0)
            {

                object[] Items = new object[Count];

                TheParams.CopyTo(Items);

                Instantiate(Items);

            }
            else
            {
                
                Instantiate();

            }

        }

        public void Instantiate(LinkedList<object> TheParams)
        {

            int Count = TheParams.Count;

            if(Count > 0)
            {

                object[] Items = new object[Count];

                TheParams.CopyTo(Items, 0);

                Instantiate(Items);

            }
            else
            {

                Instantiate();

            }

        }

        public void Instantiate(HashSet<object> TheParams)
        {

            int Count = TheParams.Count;

            if(Count > 0)
            {

                object[] Items = new object[Count];

                TheParams.CopyTo(Items, 0);

                Instantiate(Items);

            }
            else
            {

                Instantiate();

            }

        }

        public void Instantiate(IToArray<object> TheParams)
        {

            Instantiate(TheParams.ToArray());

        }

        public bool TryExecute(Action<T> Delegate)
        {

            if(myValue != null)
            {

                using(this)
                {

                    Delegate(myValue);

                }

                return true;

            }

            return false;

        }

        public void Dispose()
        {

            myValue = null;

        }

    }

}
