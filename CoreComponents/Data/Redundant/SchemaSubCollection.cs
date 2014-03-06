using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaRetrieval
{
    public abstract class SchemaSubCollection : ISchemaSubCollection
    {

        protected string myCollectionName;

        protected List<string> myRestrictionValues;

        protected bool myUseRestrictionValues;

        public SchemaSubCollection()
        {
        }

        public SchemaSubCollection(string theCollectionName)
        {

            myCollectionName = theCollectionName;


        }

        public SchemaSubCollection(string theCollectionName, string[] theRestrictionValues)
        {

            myCollectionName = theCollectionName;

            myRestrictionValues = new List<string>(theRestrictionValues);

        }

        public SchemaSubCollection(string theCollectionName, IEnumerable<string> theRestrictionValues)
        {

            myCollectionName = theCollectionName;

            myRestrictionValues = new List<string>(theRestrictionValues);

        }

        public string Name
        {

            get
            {

                return myCollectionName;

            }

        }

        public string[] RestrictionValues()
        {

            return myRestrictionValues.ToArray();

        }

        public bool CanProcureValues()
        {

            return myRestrictionValues != null;

        }

        public bool UseRestrictionValues
        {
            get
            {
                return myUseRestrictionValues;
            }
            set
            {
                myUseRestrictionValues = value;
            }
        }

        public void InverseUseRestrictionValues()
        {

            myUseRestrictionValues = !myUseRestrictionValues;

        }

    }
}
