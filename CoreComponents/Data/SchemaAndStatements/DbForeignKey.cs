using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbForeignKey
    {

        protected DbTable myTable;

        protected DbColumn myForeignKeyColumn;

        protected DbColumn myReferencedColumn; 

        public DbForeignKey(DbTable TheTable)
        {

            CheckAndSetTable(TheTable);

        }

        public DbForeignKey(DbTable TheTable, DbColumn TheForigenKeyColumn, DbColumn TheReferencedColumn)
        {

            CheckAndSetTable(TheTable);

            SetForigenKeyColumn(TheForigenKeyColumn);

            SetReferencedColumn(TheReferencedColumn);

        }

        protected void CheckAndSetTable(DbTable TheTable)
        {

            if (TheTable != null)
                myTable = TheTable;
            else
                throw new Exception();
 
        }

        protected void SetForigenKeyColumn(DbColumn TheColumn)
        {

            if (myForeignKeyColumn != null)
            {

                if (TheColumn.Table == myTable)
                    myForeignKeyColumn = TheColumn;
                else
                    throw new Exception();

            }

        }

        protected void SetReferencedColumn(DbColumn TheColumn)
        {

            if (myReferencedColumn != null)
            {

                if (TheColumn.Table != myTable)
                    myReferencedColumn = TheColumn;
                else
                    throw new Exception();

            }

        }

        public DbTable Table
        {

            get
            {

                return myTable;

            }
            set
            {

                CheckAndSetTable(value);

                ResetColumns();

            }

        }

        public bool HasTable
        {

            get
            {

                return myTable != null;

            }

        }

        public DbColumn ForeignKeyColumn
        {

            get
            {

                return myForeignKeyColumn;

            }
            set
            {

                SetForigenKeyColumn(value);

            }

        }

        public bool HasForigenKeyColumn
        {

            get
            {

                return myForeignKeyColumn != null;

            }

        }

        public DbColumn ReferencedColumn
        {

            get
            {

                return myReferencedColumn;

            }
            set
            {

                SetReferencedColumn(value);

            }

        }

        public bool HasReferencedColumn
        {

            get
            {

                return myReferencedColumn != null;

            }

        }

        public void ResetColumns()
        {

            if (myForeignKeyColumn != null)
                myForeignKeyColumn = null;

            if(myReferencedColumn != null)
                myReferencedColumn = null;

        }

        public override bool Equals(object obj)
        {

            if (obj.GetType() == typeof(DbForeignKey))
            {

                DbForeignKey OtherRelationship = obj as DbForeignKey;

                return OtherRelationship.Table == myTable && OtherRelationship.ForeignKeyColumn == myForeignKeyColumn && OtherRelationship.ReferencedColumn == myReferencedColumn;

            }

            return false;

        }

        public static bool operator==(DbForeignKey Left, DbForeignKey Right)
        {

            return Left.Equals(Right);

        }

        public static bool operator !=(DbForeignKey Left, DbForeignKey Right)
        {

            return !Left.Equals(Right);

        }

        public bool CheckValidatity()
        {

            if (myTable != null && myForeignKeyColumn != null && myReferencedColumn != null)
            {

                return myTable.Columns.Contains(myForeignKeyColumn) && myForeignKeyColumn.HasName && myReferencedColumn.HasTable && myReferencedColumn.HasName;

            }

            return false;

        }

    }

}
