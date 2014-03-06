using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public class ColumnValue
    {

        string myColumn;

        string myValue;

        string myTable;

        bool myValueIsParameter;

        public ColumnValue(string TheColumn, string TheValue, string TheTable, bool TheValueIsParameter = false) 
        {

            myColumn = TheColumn;

            myValue = TheValue;

            myTable = TheTable;

            myValueIsParameter = TheValueIsParameter;

        }

        public string Column 
        {

            get 
            {

                return myColumn;

            }

        }

        public string Value 
        {

            get 
            {

                return myValue;

            }

        }

        public string OfTable
        {

            get
            {

                return myTable;

            }

        }

        public bool ValueIsParameter
        {

            get
            {

                return myValueIsParameter;

            }

        }

        //Probably not the best test.
        public bool IfColumnIsTypeValueIsValid<TColumnType>() 
        {

            try
            {

                Convert.ChangeType(myValue, typeof(TColumnType));

            }
            catch 
            {

                return false;

            }

            return true;

        }


    }
}
