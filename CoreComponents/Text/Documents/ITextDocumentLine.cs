using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public interface ITextDocumentLine : IEnumerable<char>, IEnumerable
    {

        event EventInfo<char> Added;

        event EventInfo<IndexedDocumentItemEvent<char>> Inserted;

        event EventInfo<IndexedDocumentItemEvent<char>> InsertedOver;

        event EventInfo<char> Removed;

        event EventInfo<IndexedDocumentItemEvent<char>> RemovedAt;

        event EventInfo<IEnumerable<char>> AddedSet;

        event EventInfo<IndexedDocumentItemEvent<IEnumerable<char>>> InsertedSet;

        event EventInfo<IndexedDocumentItemEvent<IEnumerable<char>>> InsertedOverSet;

        event EventInfo<IEnumerable<char>> RemovedSet;

        event EventInfo<IndexedDocumentItemEvent<IEnumerable<char>>> RemovedAtSet;

        void Insert(int index, IEnumerable<char> item);

        void Add(char item);

        void Add(string item);

        char this[int index] { get; set; }

        int IndexOf(char item);

        void Insert(int index, char item);
        
        void RemoveAt(int index);

        int Count 
        {

            get;
        
        }

        void Clear();
        
        bool Contains(char item);
        
        void CopyTo(char[] array, int arrayIndex);

        void RemoveLast();

    }

}
