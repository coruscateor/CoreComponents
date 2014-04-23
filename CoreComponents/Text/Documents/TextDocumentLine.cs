using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public class TextDocumentLine : ITextDocumentLine
    {

        public event EventInfo<char> Added;

        public event EventInfo<IndexedDocumentItemEvent<char>> Inserted;

        public event EventInfo<IndexedDocumentItemEvent<char>> InsertedOver;

        public event EventInfo<char> Removed;

        public event EventInfo<IndexedDocumentItemEvent<char>> RemovedAt;

        public event EventInfo<IEnumerable<char>> AddedSet;

        public event EventInfo<IndexedDocumentItemEvent<IEnumerable<char>>> InsertedSet;

        public event EventInfo<IndexedDocumentItemEvent<IEnumerable<char>>> InsertedOverSet;

        public event EventInfo<IEnumerable<char>> RemovedSet;

        public event EventInfo<IndexedDocumentItemEvent<IEnumerable<char>>> RemovedAtSet;

        protected List<char> myList = new List<char>();

        public TextDocumentLine()
        {
        }

        public TextDocumentLine(IEnumerable<char> TheItems)
        {

            myList.AddRange(TheItems);

        }

        public int IndexOf(char item)
        {

            return myList.IndexOf(item);

        }

        public void Insert(int index, char item)
        {

            myList.Insert(index, item);

            if(Inserted != null)
                Inserted(this, new IndexedDocumentItemEvent<char>(index, item));

        }

        public void Insert(int index, IEnumerable<char> item)
        {

            foreach(char value in item)
            {

                myList.Insert(index, value);

                index++;

            }

            if(InsertedSet != null)
                InsertedSet(this, new IndexedDocumentItemEvent<IEnumerable<char>>(index, item));

        }

        //public void Insert(int index, string item)
        //{

        //    Insert(index, item);

        //}

        public void RemoveAt(int index)
        {

            if(RemovedAt == null)
            {

                myList.RemoveAt(index);

            }
            else
            {

                char item = myList[index];

                myList.RemoveAt(index);

                RemovedAt(this, new IndexedDocumentItemEvent<char>(index, item));

            }

        }

        public char this[int index]
        {

            get
            {

                return myList[index];

            }
            set
            {

                myList[index] = value;

                if(InsertedOver != null)
                    InsertedOver(this, new IndexedDocumentItemEvent<char>(index, value));

            }

        }

        public void Add(char item)
        {

            myList.Add(item);

            if(Added != null)
                Added(this, item);

        }

        //public void Add(IEnumerable<char> item)
        //{

        //    foreach(char value in item)
        //    {

        //        myList.Add(value);

        //    }

        //}

        //public void Add(string item)
        //{

        //    Add(item);

        //}

        public void Clear()
        {

            if(RemovedSet == null)
            {

                myList.Clear();

            }
            else
            {

                char[] Items = myList.ToArray();

                myList.Clear();

                RemovedSet(this, Items);
 
            }

        }

        public bool Contains(char item)
        {

            return myList.Contains(item);

        }

        public void CopyTo(char[] array, int arrayIndex)
        {
            
            myList.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myList.Count;
            
            }

        }

        //public bool IsReadOnly
        //{

        //    get
        //    {
                
        //        return false;
            
        //    }

        //}

        //public bool Remove(char item)
        //{

        //    if(Removed == null)
        //    {

        //        return myList.Remove(item);

        //    }
        //    else
        //    {

        //        bool ItemRemoved = myList.Remove(item);

        //        Removed(this, item);

        //        return ItemRemoved;

        //    }

        //}

        public void RemoveLast()
        {

            if(Removed == null)
            {

                myList.RemoveAt(myList.Count - 1);

            }
            else
            {

                int LastIndex = myList.Count - 1;

                char LastItem = myList[LastIndex];

                myList.RemoveAt(LastIndex);

                Removed(this, LastItem);

            }

        }

        public IEnumerator<char> GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        public override string ToString()
        {

            return new string(myList.ToArray());

        }

        public void Add(string item)
        {
            throw new NotImplementedException();
        }

    }

}
