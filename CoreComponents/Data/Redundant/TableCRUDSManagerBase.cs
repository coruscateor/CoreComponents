using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CoreComponents.Data.Schema;

namespace CoreComponents.Data
{

    public abstract class TableCRUDSManagerBase<TRowIdentifier> //where TRowIdentifier : struct
    {

        //protected Dictionary<string, Type> myTableScheama = new Dictionary<string, Type>();

        protected DbTable myTable;

        protected List<DbColumn> myRowIdentifiers;

        protected List<Dictionary<DbColumn, object>> myObjectValueCache;

        //protected string myName;

        protected DbCommand myDbCommand;

        public TableCRUDSManagerBase() //Dictionary<DbColumn, object> TheObjectValueCache
        {

            //myObjectValueCache = new Dictionary<DbColumn, object>(TheObjectValueCache);

        }

        //public void Create()
        //{
        //}

        //public abstract void Update(TRowIdentifier TheRowIdentifier, string TheColumnName, object TheValue);

        //public abstract void Update(TRowIdentifier TheRowIdentifier, DbColumn TheColumn, object TheValue);

        public abstract void Update(TRowIdentifier TheRowIdentifier, IDictionary<string, object> TheColumnNamesAndValues);

        public abstract void Update(TRowIdentifier TheRowIdentifier, IDictionary<DbColumn, object> TheColumnsAndValues);

        public abstract void Delete(TRowIdentifier TheRowIdentifier);

        public abstract void Insert(params object[] TheValues);

        public abstract object[] Select(TRowIdentifier TheRowIdentifier, params string[] TheColumnNames);

        public abstract object[] Select(TRowIdentifier TheRowIdentifier, params DbColumn[] TheColumns);

        public abstract TRowIdentifier[] SelectIdentifier();

        public abstract TRowIdentifier[] GetSelectIdentifiers(uint TheLimit);

        public abstract TRowIdentifier[] GetSelectIdentifiers(uint TheTop, uint TheLimit);

        public DbConnection DbConnection 
        {

            get
            {

                return myDbCommand.Connection;

            }
            set
            {

                myDbCommand.Connection = value;

            }

        }

        //public DbCommand DbCommand 
        //{

        //    get 
        //    {

        //        return myDbCommand;

        //    }
        //    set 
        //    {

        //        myDbCommand = value;

        //    }

        //}

        //public Dictionary<string, Type> Scheama 
        //{

        //    get 
        //    {

        //        return myTableScheama;

        //    }

        //}

        //public string Name 
        //{

        //    get 
        //    {

        //        return myName;

        //    }
        //    set 
        //    {

        //        myName = value;

        //    }

        //}

    }

}
