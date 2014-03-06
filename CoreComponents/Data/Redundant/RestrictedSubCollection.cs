using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaRetrieval
{
    public class RestrictedSubCollection : SchemaSubCollection, IRestrictedSubCollection
    {

        public RestrictedSubCollection()
        {
        }

        public RestrictedSubCollection(string theCollectionName) : base(theCollectionName)
        {
        }

        public RestrictedSubCollection(string theCollectionName, string[] theRestrictionValues) : base(theCollectionName, theRestrictionValues)
        {
        }

        public RestrictedSubCollection(string theCollectionName, IEnumerable<string> theRestrictionValues) : base(theCollectionName, theRestrictionValues)
        {
        }

        public List<string> RestrictionValueCollection
        {

            get
            {

                return myRestrictionValues;

            }

        }

    }
}
