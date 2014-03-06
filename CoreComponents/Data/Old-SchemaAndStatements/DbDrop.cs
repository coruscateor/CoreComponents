using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbDrop<TEntity> where TEntity : DbEntity
    {

        protected bool myIfExists;

        protected TEntity myEntity;

        public DbDrop()
        {
        }

        public bool IfExists
        {

            get
            {

                return myIfExists;

            }

        }

        public TEntity Entity
        {

            get 
            {

                return myEntity;

            }
            set 
            {

                myEntity = value;

            }

        }

    }

}
