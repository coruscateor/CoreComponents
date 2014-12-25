using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.React
{

    public class Factor : IFactor
    {

        protected object myItem;

        public event EventHandler Updated;

        protected void OnUpdated()
        {

            if(Updated != null)
                Updated(this);

        }

        public Factor()
        {
        }

        public Factor(object TheItem)
        {

            myItem = TheItem;

        }

        public object Item
        {

            get
            {

                return myItem;

            }
            set
            {

                myItem = value;

                OnUpdated();

            }

        }

        public void SetSupressUpdate(object TheItem)
        {

            myItem = TheItem;

        }

        public void SetThen(object TheItem, Action<Factor> TheAction)
        {

            Item = TheItem;

            TheAction(this);

        }

        public override string ToString()
        {

            return myItem.ToString();

        }
        
    }

    public class Factor<T> : IFactor
    {

        protected T myItem;

        public event EventHandler Updated;
        
        protected void OnUpdated()
        {

            if(Updated != null)
                Updated(this);

        }

        public Factor()
        {
        }

        public Factor(T TheItem)
        {

            myItem = TheItem;

        }

        public T Item
        {

            get
            {

                return myItem;

            }
            set
            {

                myItem = value;

                OnUpdated();

            }

        }

        public void SetSupressUpdate(T TheItem)
        {

            myItem = TheItem;

        }

        public void SetThen(T TheItem, Action<Factor<T>> TheAction)
        {

            Item = TheItem;

            TheAction(this);

        }

        public override string ToString()
        {

            return myItem.ToString();

        }

    }

}
