using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{
    public class ColumnList : ParentedList<DbTable, DbColumn> //UniqueParentedNamedList<DbTable, DbColumn>
    {

        public ColumnList(DbTable Parent) : base(Parent)
        {
        }

        public List<string> ColumnNameList()
        {

            List<string> itemlist = new List<string>();

            foreach (DbColumn item in myChildren)
            {

                itemlist.Add(item.Name);

            }

            return itemlist;

        }

        public string[] ColumnNameArray()
        {

            return ColumnNameList().ToArray();

        }

    }

    public class PrimaryKey : SubscriableDictionary<DbColumn, DbColumn>
    {

        public PrimaryKey()
        {
        }

        public override void Add(DbColumn KeyItem, DbColumn ValueItem)
        {
            base.Add(KeyItem, ValueItem);
        }

        public bool Contains
        {

            get
            {

                return myList.Count > 0;

            }

        }

    }

    public class ForignKeyList : SubscriableDictionary<DbColumn, DbColumn>
    {

        public ForignKeyList()
        {

        }

    }

    public class DbTable : DbDatabaseEntity<DbTable>
    {

        protected ColumnList myColumns;

        //protected List<DbColumn> myColumns;

        protected PrimaryKey myPrimaryKey;

        protected ForignKeyList myForignKeys;

        //public event Gimmie<ChangeEventArgs<DbColumn, DbTable>>.GimmieSomethin ColumnAdded;

        //public event Gimmie<ChangeEventArgs<DbColumn, DbTable>>.GimmieSomethin Adding;

        //public event Gimmie<ChangeEventArgs<DbColumn, DbTable>>.GimmieSomethin ColumnRemoved;

        //public event Gimmie<ChangeEventArgs<DbColumn, DbTable>>.GimmieSomethin Removing;

        //public event Gimmie<IndexChangedEventArgs<DbTable, DbColumn>>.GimmieSomethin Inserting;

        //public event Gimmie<IndexChangedEventArgs<DbTable, DbColumn>>.GimmieSomethin ColumnInserted;

        //public event Gimmie<IndexChangedEventArgs<DbTable, DbColumn>>.GimmieSomethin Extracting;

        //public event Gimmie<IndexChangedEventArgs<DbTable, DbColumn>>.GimmieSomethin ColumnExtracted;

        public DbTable()
        {

            myName = "New Table";

            Initalise();

        }

        public DbTable(string Name)
        {

            myName = Name;

            Initalise();

        }

        public DbTable(string Name, string Description)
        {

            myName = Name;

            myDescription = Description;

            Initalise();

        }

        public DbTable(DbDatabase Schema, string Name)
        {

            myName = Name;

            myAdapter.SetParent(Schema);

            Initalise();

        }

        public DbTable(DbDatabase Schema, string Name, string Description)
        {

            myName = Name;

            myAdapter.SetParent(Schema);

            Initalise();

        }

        protected void Initalise()
        {

            myColumns = new ColumnList(this);

            //myColumns = new List<DbColumn>();

			myPrimaryKey = new PrimaryKey();
			
			myForignKeys = new ForignKeyList();

            myAdapter = new ChildToParentAdapter<DbDatabase, DbTable, IParentedList<DbDatabase, DbTable>>(this, "Tables");

        }

        public bool HasValidName()
        {

            if (myName.Length > 0)
            {

                return false;

            }

            return true;

        }

        /*
        protected void OnAdding(DbColumn item)
        {

            if (Adding != null)
                Adding(new ChangeEventArgs<DbColumn, DbTable>(this, item));

        }
        */

        //protected void OnColumnAdded(DbColumn item)
        //{

        //    if (ColumnAdded != null)
        //        ColumnAdded(new ChangeEventArgs<DbColumn, DbTable>(this, item));

        //}
        
        /*
        protected void OnRemoving(DbColumn item)
        {

            if (Removing != null)
                Removing(new ChangeEventArgs<DbColumn, DbTable>(this, item));

        }
        */

        //protected void OnColumnRemoved(DbColumn item)
        //{

        //    if (ColumnRemoved != null)
        //        ColumnRemoved(new ChangeEventArgs<DbColumn, DbTable>(this, item));

        //}

        //
        /*
        protected void OnInserting(DbColumn Item, int Index)
        {

            if (Inserting != null)
                Inserting(new IndexChangedEventArgs<DbTable, DbColumn>(this, Item, Index));

        }
        */

        //protected void OnColumnInserted(DbColumn Item, int Index)
        //{

        //    if (ColumnInserted != null)
        //        ColumnInserted(new IndexChangedEventArgs<DbTable, DbColumn>(this, Item, Index));

        //}

        /*
        protected void OnExtracting(DbColumn Item, int Index)
        {

            if (Extracting != null)
                Extracting(new IndexChangedEventArgs<DbTable, DbColumn>(this, Item, Index));

        }
        */

        //protected void OnColumnExtracted(DbColumn Item, int Index)
        //{

        //    if (ColumnExtracted != null)
        //        ColumnExtracted(new IndexChangedEventArgs<DbTable, DbColumn>(this, Item, Index));

        //}


        public ColumnList Columns
        {
            get
            {

                return myColumns;

            }

        }
		
		public PrimaryKey PrimaryKey
		{
			get
			{
				
				return myPrimaryKey;
				
			}
		}
		
        /*
        public DbColumn this[int index]
        {

            get
            {

                return myColumns[index];

            }
            set
            {

                myColumns[index] = value;

            }

        }

        public DbColumn this[string name]
        {

            get
            {

                return myColumns[name];

            }
            set
            {

                myColumns[name] = value;

            }

        }
        */
        //public void Add(DbColumn column)
        //{

        //    myColumns.Add(column);

        //    OnColumnAdded(column);

        //}

        //public void Remove(DbColumn column)
        //{

        //    myColumns.Remove(column);

        //    OnColumnRemoved(column);

        //}

        //public void Insert(DbColumn column, int index)
        //{

        //    myColumns.Insert(index, column);

        //    OnColumnInserted(column, index);

        //}

        //public void RemoveAt(int index)
        //{
        //    DbColumn column = myColumns[index];

        //    myColumns.RemoveAt(index);

        //    OnColumnExtracted(column, index);

        //}

        //Column, Forign Column

        public ForignKeyList ForignKeys
		{
			
			get
			{
				
				return myForignKeys;
				
			}
			
		}

        /*
		public bool HasForignKeys()
        {

            return myForignKeys.Count > 0;

        }
        */

        /*
        public int Count
        {

            get
            {
                return myColumns.Count;

            }

        }
        */
        /*
        public int GetIndex(int i)
        {

            return myColumns.IndexOf(i);

        }
        */

        //public int IndexOf(DbColumn column)
        //{

        //    return myColumns.IndexOf(column);

        //}

        //public int GetIndex(string name)
        //{

        //    return myColumns.GetIndex(name);

        //}
	


        //PCS 21072010 Taken from: http://msdn.microsoft.com/en-us/library/system.data.datatablereader.getschematable.aspx

        //PCS 22072010 Well it was an interseting idea... 

        /*
        public DataTable GetSchemaAsDataTable()
        {
            DataTable SchemaTable = new DataTable(myName);

            SchemaTable.Columns.Add("ColumnName", typeof(string));
            SchemaTable.Columns.Add("ColumnOrdinal", typeof(int));
            SchemaTable.Columns.Add("ColumnSize", typeof(int));
            SchemaTable.Columns.Add("NumericPrecision", typeof(int));
            SchemaTable.Columns.Add("NumericScale", typeof(int));
            SchemaTable.Columns.Add("DataType", typeof(Type));
            SchemaTable.Columns.Add("ProviderType", typeof(Type));
            SchemaTable.Columns.Add("IsLong", typeof(bool));
            SchemaTable.Columns.Add("AllowDBNull", typeof(bool));
            SchemaTable.Columns.Add("IsReadOnly", typeof(bool));
            SchemaTable.Columns.Add("IsRowVersion", typeof(bool));
            SchemaTable.Columns.Add("IsUnique", typeof(bool));
            SchemaTable.Columns.Add("IsKey", typeof(bool));
            SchemaTable.Columns.Add("IsAutoIncrement", typeof(bool));

            SchemaTable.Columns.Add("BaseCatalogName", typeof(string));
            SchemaTable.Columns.Add("BaseSchemaName", typeof(string));
            SchemaTable.Columns.Add("BaseTableName", typeof(string));
            SchemaTable.Columns.Add("BaseColumnName", typeof(string));
            SchemaTable.Columns.Add("AutoIncrementSeed", typeof(long));
            SchemaTable.Columns.Add("AutoIncrementStep", typeof(long));
            SchemaTable.Columns.Add("DefaultValue", typeof(string));
            SchemaTable.Columns.Add("Expression", typeof(string));

            SchemaTable.Columns.Add("ColumnMapping", typeof(MappingType));
            SchemaTable.Columns.Add("BaseTableNamespace", typeof(string));
            SchemaTable.Columns.Add("BaseColumnNamespace", typeof(string));

            List<object> RowValues = new List<object>();

            foreach (DbColumn Col in myColumns)
            {

                RowValues.Add(Col.Name);
                RowValues.Add(Col.Ordinal);
                RowValues.Add(Return.NullIfNegative(Col.MaxLength));

                RowValues.Add(Return.NullIfNegative(Col.NumericPrecision));
                RowValues.Add(Return.NullIfNegative(Col.NumericScale));
                RowValues.Add(Col.Type);

                RowValues.Add(Col.Type);
                RowValues.Add(Col.IsLong);
                RowValues.Add(Col.AllowNull);

                RowValues.Add(Col.IsReadOnly);
                RowValues.Add(false);

                bool iskey = Col.IsKey;

                RowValues.Add(iskey);

                RowValues.Add(iskey);
                RowValues.Add(Col.IsAutoIncrement);
                RowValues.Add(null);

                RowValues.Add(null);
                RowValues.Add(myName);
                RowValues.Add(Col.Name);

                RowValues.Add(Col.AutoIncrementSeed);
                RowValues.Add(Col.AutoIncrementStep);
                RowValues.Add(Col.DefaultValue);

                RowValues.Add(null);
                RowValues.Add(MappingType.Element);
                RowValues.Add(string.Empty);
                RowValues.Add(string.Empty);

                SchemaTable.Rows.Add(RowValues.ToArray());

                RowValues.Clear();

            }

            return SchemaTable;

        }
        */

    }

}

