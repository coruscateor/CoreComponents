using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public class TextDocumentLineSet : ITextDocumentLineSet
    {

        //public event EventInfo<TextDocumentLine> Added;

        //public event EventInfo<IndexedDocumentItemEvent<TextDocumentLine>> Inserted;

        //public event EventInfo<TextDocumentLine> Removed;

        //public event EventInfo<IndexedDocumentItemEvent<TextDocumentLine>> RemovedAt;

        protected ITextDocument myDocument;

        protected List<ITextDocumentLine> myText = new List<ITextDocumentLine>();

        public TextDocumentLineSet(ITextDocument TheDocument)
        {

            myDocument = TheDocument;

        }

        public ITextDocumentLine this[int i]
        {

            get
            {

                return myText[i];

            }
            set
            {

                myText[i] = value;

            }

        }
        
        public ITextDocument Document
        {

            get
            {

                return myDocument;

            }

        }
        
        public void Add(string TheLine)
        {

            myText.Add(new TextDocumentLine(TheLine));

        }

        public int IndexOf(ITextDocumentLine item)
        {
            
            return myText.IndexOf(item);

        }

        public void Insert(int index, ITextDocumentLine item)
        {
            
            myText.Insert(index, item);
            
        }

        public void RemoveAt(int index)
        {

            myText.RemoveAt(index);

        }

        ITextDocumentLine IList<ITextDocumentLine>.this[int index]
        {

            get
            {

                return myText[index];

            }
            set
            {
                
                myText[index] = value;

            }

        }

        public void Add(ITextDocumentLine item)
        {
            
            myText.Add(item);

        }

        public void Clear()
        {

            myText.Clear();

        }

        public bool Contains(ITextDocumentLine item)
        {
            
            return myText.Contains(item);

        }

        public void CopyTo(ITextDocumentLine[] array, int arrayIndex)
        {

            myText.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myText.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(ITextDocumentLine item)
        {

            return myText.Remove(item);

        }

        public void RemoveLast()
        {

            myText.RemoveAt(myText.Count - 1);

        }

        public IEnumerator<ITextDocumentLine> GetEnumerator()
        {

            return myText.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myText.GetEnumerator();

        }

    }

}
