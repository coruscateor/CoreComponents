using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents.Text;
using CoreComponents.Data.SQL;

namespace CoreComponents.Data
{
    public abstract class ItemAlias
    {

        protected object myItem;
        protected string myAlias;
        protected bool myIsResolving;

        public ItemAlias()
        {
        }

        public ItemAlias(object theItem)
        {

            SetItem(theItem);

        }

        public virtual object Item
        {

            get
            {

                return myItem;

            }
            set
            {
                if (!myIsResolving)
                    SetItem(value);

            }

        }

        public string Alias
        {

            get
            {

                return myAlias;

            }
            set
            {
                if(!myIsResolving)
                    myAlias = value;

            }

        }

        public virtual string Resolve()
        {

            if (myIsResolving)
            {

                return myAlias;

            } else
            {

                //Frist time it locks it from changes and states the relationship.

                myIsResolving = true;

                //return GetItemName() + TextEntity.SPACE + ANSI_SQL.AS + TextEntity.SPACE + myAlias;

                return "null";

            }

        }

        public void Reset()
        {

            myIsResolving = false;

        }

        public virtual string GetItemName()
        {

            Type SetType = typeof(object);

 	        if(SetType == typeof(string))
            {

                return (string)myItem;

            } else if (SetType == typeof(DataTable))
            {
                return ((DataTable)myItem).TableName;

            } else if (SetType == typeof(DataColumn))
            {
                return ((DataColumn)myItem).ColumnName;
            }

            return "";

        }

        protected abstract string SetItem(object theItem);

    }
}
