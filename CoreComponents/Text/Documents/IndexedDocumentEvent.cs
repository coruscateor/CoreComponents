using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public class IndexedDocumentItemEvent<TDocumentItem>
    {

        protected int myIndex;

        protected TDocumentItem myDocumentItem;

        public IndexedDocumentItemEvent(int TheIndex, TDocumentItem TheDocumentItem)
        {

            myIndex = TheIndex;

            myDocumentItem = TheDocumentItem;

        }

        public int Index
        {

            get
            {

                return myIndex;

            }

        }

        public TDocumentItem DocumentItem
        {

            get
            {

                return myDocumentItem;

            }

        }

    }

}
