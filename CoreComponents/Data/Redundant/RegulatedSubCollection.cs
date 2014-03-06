using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data.SchemaRetrieval
{
    public class RegulatedSubCollection : SchemaSubCollection, IRegulatedSubCollection
    {

        //DataTable Table;

        SchemaSubCollectionSet<IRegulatedSubCollection> myParent;

        public RegulatedSubCollection(SchemaSubCollectionSet<IRegulatedSubCollection> Parent, string theCollectionName)
        {

            myParent = Parent;

            myCollectionName = theCollectionName;

            //myParent.Retriever.ConnectionStringChanged += new Gimmie<SenderEventArgs<SchemaRetriever>>.GimmieSomethin(Retriever_ConnectionStringChanged);

            //myParent.SchemaRetrieverChanged += new Gimmie<SenderEventArgs<SchemaSubCollectionSet<IRegulatedSubCollection>>>.GimmieSomethin(myParent_SchemaRetrieverChanged);

        }

        //void myParent_SchemaRetrieverChanged(SenderEventArgs<SchemaSubCollectionSet<IRegulatedSubCollection>> Somethin)
        //{
        //    throw new NotImplementedException();
        //}

        //void Retriever_ConnectionStringChanged(SenderEventArgs<SchemaRetriever> Somethin)
        //{
        //    throw new NotImplementedException();
        //}

        public RegulatedSubCollection(SchemaSubCollectionSet<IRegulatedSubCollection> Parent, string theCollectionName, string[] theRestrictionValues)
        {

            myParent = Parent;

            myCollectionName = theCollectionName;

            myRestrictionValues = new List<string>(theRestrictionValues);

        }

        public RegulatedSubCollection(SchemaSubCollectionSet<IRegulatedSubCollection> Parent, string theCollectionName, IEnumerable<string> theRestrictionValues)
        {

            myParent = Parent;

            myCollectionName = theCollectionName;

            myRestrictionValues = new List<string>(theRestrictionValues);

        }


        #region IRegulatedSubCollection Members

        public DataTable GetTable()
        {

            if (myUseRestrictionValues)
            {

                //if (Table == null)
                //    Refresh();

                //return Table;

                return myParent.GetTable(this);

            }

            return null;


        }

        //public void Refresh()
        //{

        //    Table = myParent.GetTable(this);

        //}

        #endregion

        #region IEditableValuesSubcollection Members

        public List<string> RestrictionValueCollection
        {

            get
            {
                return myRestrictionValues;
            }

        }

        #endregion

        #region IReadOnlyChild<SubCollectionSet<IRegulatedSubCollection>> Members

        public SchemaSubCollectionSet<IRegulatedSubCollection> Parent
        {
            get
            {
                return myParent;
            }
        }

        #endregion

        //#region ICacheQuerySubCollection Members


        //public void Refresh()
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }
}
