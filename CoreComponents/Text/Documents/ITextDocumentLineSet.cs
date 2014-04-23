using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public interface ITextDocumentLineSet : IList<ITextDocumentLine>
    {
        
        event EventInfo<TextDocumentLine> Added;

        event EventInfo<IndexedDocumentItemEvent<TextDocumentLine>> Inserted;

        event EventInfo<TextDocumentLine> Removed;

        event EventInfo<IndexedDocumentItemEvent<TextDocumentLine>> RemovedAt;

        ITextDocument Document
        {

            get;

        }

        void Add(string TheLine);

    }

}
