using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    
    public class DictionaryPseudoTable
    {

        protected string myName;

        protected List<IDictionary<string, object>> myRows;

        public DictionaryPseudoTable()
        {

            myRows = new List<IDictionary<string, object>>();

        }

        public DictionaryPseudoTable(string TheName)
        {

            myName = TheName;

            myRows = new List<IDictionary<string, object>>();

        }

        public DictionaryPseudoTable(string TheName, List<IDictionary<string, object>> TheRows, bool Copy = false)
        {

            myName = TheName;

            if(!Copy)
                myRows = TheRows;
            else
                myRows = new List<IDictionary<string, object>>(TheRows);

        }

        public DictionaryPseudoTable(string TheName, IList<IDictionary<string, object>> TheRows)
        {

            myName = TheName;

            myRows = new List<IDictionary<string, object>>(TheRows);

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

        public List<IDictionary<string, object>> Rows
        {

            get
            {

                return myRows;

            }

        }

    }

}
