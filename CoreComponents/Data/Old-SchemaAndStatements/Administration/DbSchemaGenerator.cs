using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;

namespace CoreComponents.Data.Schema.Administration
{

    public interface IDbSchemaGenerator
    {

        string GenerateSchema(DbDatabase Table);

        string GenerateTable(DbTable Table);

    }

    public abstract class DbSchemaGenerator<TSchemaEditor> : DbGenerator, IDbSchemaGenerator where TSchemaEditor : IDbSchemaGenerator
    {

        

        public DbSchemaGenerator()
        {
        }



        protected void Clear()
        {

            TextEntity.Clear(mySB);

        }

        public abstract string GenerateSchema(DbDatabase Table);

        //public abstract string GenerateTable(DbTable Table);

        //public abstract string GenerateView(DbView Table);

        public string GenerateTable(DbTable Table)
        {

            Clear();

            //Table.

            foreach (DbColumn Col in Table.Columns)
            {

                

            }

            return string.Empty;

        }

        //protected void TableName(

    }
}
