using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public struct QuasiUnion<T1, T2>
    {

        T1 myFirstItem;

        bool myHasFirstItem;

        T2 mySecondItem;

        bool myHasSecondItem;

        public QuasiUnion(T1 FirstItem)
        {

            myFirstItem = FirstItem;

            myHasFirstItem = true;

            mySecondItem = default(T2);

            myHasSecondItem = false;

        }

        public QuasiUnion(T2 SecondItem)
        {

            myFirstItem = default(T1);

            myHasFirstItem = false;

            mySecondItem = SecondItem;

            myHasSecondItem = true;

        }

        public T1 FirstItem
        {

            get
            {

                return myFirstItem;

            }

        }

        public bool HasFirstItem
        {

            get
            {

                return myHasFirstItem;

            }

        }

        public T2 SecondItem
        {

            get
            {

                return mySecondItem;

            }

        }

        public bool HasSecondItem
        {

            get
            {

                return myHasSecondItem;

            }

        }

        public bool TryGetItem(out T1 TheItem)
        {

            if(myHasFirstItem)
            {

                TheItem = myFirstItem;

                return true;

            }

            TheItem = default(T1);

            return false;

        }

        public bool TryGetItem(out T2 TheItem)
        {

            if(myHasSecondItem)
            {

                TheItem = mySecondItem;

                return true;

            }

            TheItem = default(T2);

            return false;

        }

        public void GetItem(Action<T1> TheDelegate)
        {

            if(myHasFirstItem)
                TheDelegate(myFirstItem);

        }

        public void GetItem(Action<T2> TheDelegate)
        {

            if(myHasSecondItem)
                TheDelegate(mySecondItem);

        }

        public void GetItem(Action<T1> FirstDelegate, Action<T2> SecondDelegate)
        {

            if(myHasFirstItem)
                FirstDelegate(myFirstItem);
            else if(myHasSecondItem)
                SecondDelegate(mySecondItem);

        }

    }

}
