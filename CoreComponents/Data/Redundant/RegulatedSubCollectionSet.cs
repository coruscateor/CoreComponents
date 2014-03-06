using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaRetrieval
{
    public class RegulatedSubCollectionSet : SchemaSubCollectionSet<IRegulatedSubCollection>
    {

        public RegulatedSubCollectionSet()
        {

        }

        public RegulatedSubCollectionSet(DataProviderType Provider) : base(Provider)
        {

        }

        public RegulatedSubCollectionSet(SchemaRetriever theSchemaRetriever) : base(theSchemaRetriever)
        {

        }

        public override void ObtainSchemaTableList()
        {

            DataTable SchemaIndex = mySchemaRetriever.GetSchemaIndex();

            foreach (DataRow Row in SchemaIndex.Rows)
            {

                Items.Add(new RegulatedSubCollection(this, Convert.ToString(Row.ItemArray[0])));

            }

        }

    }
}
