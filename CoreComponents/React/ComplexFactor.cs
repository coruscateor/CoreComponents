using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.React
{

    public class ComplexFactor<T>
    {

        protected Action<T> mySet;

        protected Func<T> myGet;

        public event EventHandler Updated;
        
        protected void OnUpdated()
        {

            if(Updated != null)
                Updated(this);

        }

        public ComplexFactor(Action<T> TheSetDelegate, Func<T> TheGetDelegate)
        {

            mySet = TheSetDelegate;

            myGet = TheGetDelegate;

        }

        public void Set(T TheItem)
        {

            mySet(TheItem);

            OnUpdated();

        }

        public T Get()
        {

            return myGet();

        }

        public void SetSupressUpdate(T TheItem)
        {

            mySet(TheItem);

        }

        public override string ToString()
        {

            return myGet().ToString();

        }

    }

}
