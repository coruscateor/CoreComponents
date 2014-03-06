using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Characters;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbTable : DbDatabaseEntity<DbTable>, IDbDatabaseEntity
    {

        protected DbColumnList myColumns;

        protected DbPrimaryKey myPrimaryKey;

        protected DbForeignKeyList myForignKeys;

        protected bool myIsTemporary;

        //protected bool myCreateOrDropIfNotExists;

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

            myColumns = new DbColumnList(this);

            //myPrimaryKey = new DbPrimaryKey(this);

            myForignKeys = new DbForeignKeyList(this);

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

        public DbColumnList Columns
        {
            get
            {

                return myColumns;

            }

        }

        public DbPrimaryKey PrimaryKey
		{
			get
			{
				
				return myPrimaryKey;
				
			}

		}

        public bool HasPrimaryKey
        {

            get
            {

                return myPrimaryKey.Count > 0;

            }

        }

        public DbForeignKeyList ForignKeys
		{
			
			get
			{
				
				return myForignKeys;
				
			}
			
		}

        public bool HasForignKeys
        {

            get
            {

                return myForignKeys.Count > 0;

            }

        }

        public bool IsTemporary
        {

            get 
            {

                return myIsTemporary;

            }
            set 
            {

                myIsTemporary = value;

            }

        }

        //public bool IfNotExists
        //{

        //    get
        //    {

        //        return myCreateOrDropIfNotExists;

        //    }
        //    set
        //    {

        //        myCreateOrDropIfNotExists = value;

        //    }

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

