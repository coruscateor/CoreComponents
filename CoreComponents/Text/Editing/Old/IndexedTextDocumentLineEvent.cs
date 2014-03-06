using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Editing
{

    public class IndexedTextDocumentLineEvent
    {

        protected int myIndex;
        
        protected TextDocumentLine myTextDocumentLine;

        public IndexedTextDocumentLineEvent(int TheIndex, TextDocumentLine TheTextDocumentLine)
        {

            myIndex = TheIndex;

            myTextDocumentLine = TheTextDocumentLine;

        }

        public int Index
        {

            get
            {

                return myIndex;

            }

        }

        public TextDocumentLine TextDocumentLine
        {

            get
            {

                return myTextDocumentLine;

            }

        }

    }

}
