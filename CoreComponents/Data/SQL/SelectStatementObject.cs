using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public abstract class SelectStatementObject
    {

        protected string myValue;

        protected string myAlias;

        public SelectStatementObject() 
        {
        }

        public SelectStatementObject(string TheValue)
        {

            myValue = TheValue;

        }

        public SelectStatementObject(string TheValue, string TheAlias)
        {

            myValue = TheValue;

            myAlias = TheAlias;

        }

        public virtual string Value
        {

            get
            {

                return myValue;

            }

        }

        public virtual bool IsValid
        {

            get
            {

                return myValue.Length > 0;

            }

        }

        public string Alias
        {

            get
            {
                return myAlias;

            }

        }

        public bool HasAlias
        {

            get
            {

                return myAlias.Length > 0;

            }

        }

        public virtual bool IsSubQuery
        {

            get
            {

                return false;

            }
        }

    }
}
