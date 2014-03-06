using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{
    public abstract class DbType
    {
        protected Type myCompatableType;

        protected string myName;

        protected int myLength = -1;

        public DbType() 
        {
        }

        public Type CompatableType 
        {

            get 
            {

                return myCompatableType;

            }

        }

        public string Name 
        {

            get 
            {

                return myName;

            }

        }

        public int Length 
        {

            get 
            {

                return myLength;

            }

        }

    }
}
