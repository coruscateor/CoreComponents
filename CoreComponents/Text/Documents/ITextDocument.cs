using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public interface ITextDocument
    {

        ITextDocumentLineSet Lines
        {

            get;

        }

    }

}
