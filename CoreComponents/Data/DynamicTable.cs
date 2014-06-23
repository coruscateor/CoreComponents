using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{

    /// <summary>
    /// A table that can have columns posessing values of various types. 
    /// </summary>
    public class DynamicTable
    {

        protected string myName;

        protected List<dynamic> myRows;

        public DynamicTable()
        {

            myRows = new List<dynamic>();

        }

        public DynamicTable(string TheName)
        {

            myName = TheName;

            myRows = new List<dynamic>();

        }

        public DynamicTable(string TheName, List<dynamic> TheRows, bool Copy = false)
        {

            myName = TheName;

            if(!Copy)
                myRows = TheRows;
            else
                myRows = new List<dynamic>(TheRows);

        }

        public DynamicTable(string TheName, IList<dynamic> TheRows)
        {

            myName = TheName;

            myRows = new List<dynamic>(TheRows);

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

                return string.IsNullOrWhiteSpace(myName);

            }

        }

        public bool TryGetName(out string TheName)
        {

            if(!string.IsNullOrWhiteSpace(myName))
            {

                TheName = myName;

                return true;

            }

            TheName = null;

            return false;

        }

        public List<dynamic> Rows
        {

            get
            {

                return myRows;

            }

        }

    }

}
