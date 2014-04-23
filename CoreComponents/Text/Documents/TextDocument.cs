using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public class TextDocument : ITextDocument
    {

        protected TextDocumentLineSet myLines;

        public TextDocument()
        {

            myLines = new TextDocumentLineSet(this);

        }

        public ITextDocumentLineSet Lines
        {

            get
            {

                return myLines;

            }

        }

    }

}
