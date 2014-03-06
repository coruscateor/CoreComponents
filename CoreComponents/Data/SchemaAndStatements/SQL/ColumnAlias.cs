using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class ColumnAlias
    {

        protected string myAlias;

        protected DbColumn myColumn;

        public ColumnAlias()
        {
        }

        public ColumnAlias(DbColumn TheColumn, string TheAlias)
        {

            myAlias = TheAlias;

            myColumn = TheColumn;

        }

        public string Alias
        {

            get 
            {

                return myAlias;

            }
            set 
            {

                myAlias = value;

            }

        }

        public bool HasAlias
        {

            get
            {

                return myAlias != null && myAlias.Length > 0;

            }

        }

        public DbColumn Column
        {

            get 
            {

                return myColumn;

            }
            set
            {

                myColumn = value;

            }

        }

        public bool HasColumn
        {

            get
            {

                return myColumn != null;

            }

        }

        public override bool Equals(object obj)
        {

            if (obj.GetType() == typeof(ColumnAlias))
            {

                ColumnAlias OtherDbColumnAlias = obj as ColumnAlias;

                return OtherDbColumnAlias.Column == myColumn;

            }

            return false;

        }

        public static bool operator ==(ColumnAlias Left, ColumnAlias Right)
        {

            return Left.Equals(Right);

        }

        public static bool operator !=(ColumnAlias Left, ColumnAlias Right)
        {

            return !Left.Equals(Right);

        }

    }

    public enum ColumnSpecificty
    {

        Column,
        Table,
        Database
        
    }

}
