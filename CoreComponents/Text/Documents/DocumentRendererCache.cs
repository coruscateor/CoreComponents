using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public class DocumentRendererCache<TFont>
    {

        List<FontString<TFont>> myFontStrings = new List<FontString<TFont>>();

        ITextDocument myTextDocument;

        public DocumentRendererCache()
        {
        }

        public ITextDocument TextDocument
        {

            get
            {

                return myTextDocument;

            }
            set
            {

                myTextDocument = value;

            }

        }

    }

}
