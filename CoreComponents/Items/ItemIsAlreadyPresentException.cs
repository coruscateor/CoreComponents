using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public class ItemIsAlreadyPresentException<T> : Exception
    {

        protected T myItem;

        public ItemIsAlreadyPresentException(T TheItem)
        {

            myItem = TheItem;

        }

        public T Item
        {

            get
            {

                return myItem;

            }

        }

    }

}
