using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Characters;

namespace CoreComponents.Data.SchemaAndStatements
{
    public abstract class DbColumnReference
    {

        DbColumn myReferencedColumn;

        public DbColumnReference()
        {
        }

        public DbColumnReference(DbColumn ReferedColumn)
        {
        }

        public DbColumn ReferencedColumn
        {

            get
            {

                return myReferencedColumn;

            }
            set
            {

                myReferencedColumn = value;

            }

        }

    }
}