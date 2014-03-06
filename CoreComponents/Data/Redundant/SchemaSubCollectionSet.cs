using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaRetrieval
{
    public abstract class SchemaSubCollectionSet<T> : IEnumerable<T>, ICountableNameableIndexable<T> where T : IRegulatedSubCollection 
    {

        protected SchemaRetriever mySchemaRetriever;

        protected List<T> Items = new List<T>();

        public event Gimmie<SenderEventArgs<SchemaSubCollectionSet<T>>>.GimmieSomethin SchemaRetrieverChanged;

        public SchemaSubCollectionSet()
        {

            mySchemaRetriever = new SchemaRetriever();

        }

        public SchemaSubCollectionSet(DataProviderType Provider)
        {

            mySchemaRetriever = new SchemaRetriever(Provider);

        }

        public SchemaSubCollectionSet(SchemaRetriever theSchemaRetriever)
        {

            mySchemaRetriever = theSchemaRetriever;

        }

        void OnSchemaRetrieverChanged()
        {

            if (SchemaRetrieverChanged != null)
                SchemaRetrieverChanged(new SenderEventArgs<SchemaSubCollectionSet<T>>(this));

        }

        public T this[int index]
        {
            get
            {

                return (T)Items[index];

            }

        }

        //public int this[T item]
        //{
        //    get
        //    {

        //        return Items[item];

        //    }

        //}

        public T this[string name]
        {
            get
            {

                foreach (T item in Items)
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

            return Items.Contains(item);

        }

        public int indexOf(T item)
        {

            for (int i = 0; i <= Items.Count; i++)
            {

                if (item.Equals(Items[i]))
                    return i;

            }

            return -1;

        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        #endregion

        public SchemaRetriever Retriever
        {

            get
            {

                return mySchemaRetriever;

            }
            set
            {

                mySchemaRetriever = value;

                Items.Clear();

                OnSchemaRetrieverChanged();

            }

        }

        //public SubCollectionSubList<T> UsingRestrictedValues
        //{

        //    get
        //    {

        //        return myUsingRestrictedValues;

        //    }

        //}

        //public SubCollectionSubList<T> NotUsingRestrictedValues
        //{

        //    get
        //    {

        //        return myNotUsingRestrictedValues;

        //    }

        //}

        //public void SetUsingRestrictionValues(T item, bool IsUsing)
        //{
        //    if (IsUsing)
        //    {

        //        if (NotUsingValues.Contains(item))
        //        {

        //            NotUsingValues.Remove(item);
        //            UsingValues.Add(item);

        //        }

        //    } 
        //    else
        //    {

        //        if (UsingValues.Contains(item))
        //        {

        //            UsingValues.Remove(item);
        //            NotUsingValues.Add(item);

        //        }

        //    }

        //}

        public DataTable GetTable(T item)
        {

            foreach (T AnItem in Items)
            {

                if (item.Equals(AnItem))
                    //AnItem.
                    return mySchemaRetriever.GetSchemaTable(AnItem);

            }

            //if (UsingValues.Contains(item))
            //{

            //    return mySchemaRetriever.GetSchemaTable(item, true);

            //}
            //else if(NotUsingValues.Contains(item))
            //{

            //    return mySchemaRetriever.GetSchemaTable(item, false);

            //}

            return null;

        }

        public DataSet GetDataSet()
        {

            //bool RestrictionsOriginalValue;

            DataSet FilteredTables = new DataSet();

            //GenericSubCollection Collection = new GenericSubCollection();

            foreach (T Item in Items)
            {

                //Collection.Name = Item;

                FilteredTables.Tables.Add(mySchemaRetriever.GetSchemaTable(Item));

            }

            //RestrictionsOriginalValue = mySchemaRetriever.UseRestrictions;

            //AquireFilteredData(FilteredTables);

            //AquireUnFilteredData(FilteredTables);

            //if (RestrictionsOriginalValue != mySchemaRetriever.UseRestrictions)
            //    mySchemaRetriever.UseRestrictions = RestrictionsOriginalValue;

            return FilteredTables;

        }

        public virtual void ObtainSchemaTableList()
        {

        }

        public bool HasContetns()
        {

            return Items.Count > 0;

        }



        //void AquireFilteredData(DataSet FilteredTables)
        //{

        //    if (!mySchemaRetriever.UseRestrictions)
        //        mySchemaRetriever.InverseUseRestrictions();

        //    AddTables(FilteredTables, (IEnumerable<ISchemaSubCollection>)UsingValues);

        //}

        //void AquireUnFilteredData(DataSet FilteredTables)
        //{

        //    if (mySchemaRetriever.UseRestrictions)
        //        mySchemaRetriever.InverseUseRestrictions();

        //    AddTables(FilteredTables, (IEnumerable<ISchemaSubCollection>)NotUsingValues);

        //}

        //void AddTables(DataSet FilteredTables, IEnumerable<ISchemaSubCollection> TheList)
        //{

        //    foreach(ISchemaSubCollection Collection in TheList)
        //    {

        //        FilteredTables.Tables.Add(mySchemaRetriever.GetSchemaTable((ISchemaSubCollection)Collection));

        //    }

        //}

    }
}
