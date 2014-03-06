using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public abstract class DbEntity
    {

        protected string myName;

        public DbEntity()
        {
        }

        public DbEntity(string TheName)
        {

            myName = TheName;

        }

        public string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public bool HasName
        {

            get
            {

                return myName != null && myName.Length > 0;

            }

        }

    }

}
