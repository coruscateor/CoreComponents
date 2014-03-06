using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.SchemaRetrieval
{

    public class SubCollectionSubList<T> : IEnumerable<T> where T : ISchemaSubCollection
    {

        //List<T> mySubcollecionList = new List<T>();

        IList<T> mySubcollecionList;

        //SchemaRetriever mySchemaRetriever = new SchemaRetriever();

        public SubCollectionSubList(IList<T> theSubcollecionList)
        {

            mySubcollecionList = theSubcollecionList;

        }

        //public SchemaRetriever SchemaRetriever
        //{

        //    get
        //    {

        //        return mySchemaRetriever;

        //    }
        //    set
        //    {

        //        mySchemaRetriever = value;

        //    }

        //}

        public T this[int index]
        {
            get
            {

                return mySubcollecionList[index];

            }

        }

        //public int this[T item]
        //{
        //    get
        //    {

        //        return mySubcollecionList[item];

        //    }

        //}

        T this[string name]
        {
            get
            {

                foreach (T item in mySubcollecionList)
                {

                    if (name == item.Name)
                    {

                        return item;

                    }

                }

                return default(T);
            }
        }


        public bool Contains(T item)
        {

            return mySubcollecionList.Contains(item);

        }

        public int indexOf(T item)
        {

            for (int i = 0; i <= mySubcollecionList.Count; i++)
            {

                if (item.Equals(mySubcollecionList[i]))
                    return i;

            }

            return -1;

        }

        public int Count
        {
            get
            {
               return mySubcollecionList.Count;
            }
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return mySubcollecionList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mySubcollecionList.GetEnumerator();
        }

        #endregion
    }

}
