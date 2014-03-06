using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaRetrieval
{
    public class GenericSubCollection : RestrictedSubCollection, IGenericSchemaSubCollection
    {

        public GenericSubCollection() //: base()
        {

            myRestrictionValues = new List<string>();

        }

        public GenericSubCollection(int capacty) //: base(capacty)
        {

            myRestrictionValues = new List<string>(capacty);

        }

        public GenericSubCollection(string theCollectionName) : base(theCollectionName)
        {

            //myCollectionName = theCollectionName;

            myRestrictionValues = new List<string>();

        }

        public GenericSubCollection(string theCollectionName, int capacty) //: base(theCollectionName, capacty)
        {

            myCollectionName = theCollectionName;

            myRestrictionValues = new List<string>(capacty);

        }

        public GenericSubCollection(string theCollectionName, string[] theRestrictionValues) : base(theCollectionName, theRestrictionValues)
        {
        }

        public GenericSubCollection(string theCollectionName, IEnumerable<string> theRestrictionValues) : base(theCollectionName, theRestrictionValues)
        {
        }

        public new string Name
        {

            get
            {

                return myCollectionName;

            }
            set
            {

                myCollectionName = value;

            }

        }

    }
}
