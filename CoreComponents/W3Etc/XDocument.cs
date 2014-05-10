using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{
    
    public class XDocument : IList<BaseElement>, IToStringBuilder
    {

        protected List<BaseElement> myItems = new List<BaseElement>();

        public XDocument()
        {
        }

        public int IndexOf(BaseElement TheItem)
        {

            return myItems.IndexOf(TheItem);

        }

        public void Insert(int TheIndex, BaseElement TheItem)
        {

            myItems.Insert(TheIndex, TheItem);

        }

        public void RemoveAt(int TheIndex)
        {

            myItems.RemoveAt(TheIndex);

        }

        public BaseElement this[int TheIndex]
        {
            get
            {

                return myItems[TheIndex];

            }
            set
            {

                myItems[TheIndex] = value;

            }
        }

        public void Add(BaseElement TheItem)
        {

            myItems.Add(TheItem);

        }

        public void AddRange(IEnumerable<BaseElement> TheCollection)
        {

            myItems.AddRange(TheCollection);

        }

        public void Clear()
        {

            myItems.Clear();

        }

        public bool Contains(BaseElement TheItem)
        {

            return myItems.Contains(TheItem);

        }

        public void CopyTo(BaseElement[] TheArray, int TheArrayIndex)
        {

            myItems.CopyTo(TheArray, TheArrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myItems.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(BaseElement TheItem)
        {

            return myItems.Remove(TheItem);

        }

        public IEnumerator<BaseElement> GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

        public void Write(StreamWriter TheStreamWriter)
        {

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            string Contents;

            try
            {

                ToStringBuilder(SB);

                Contents = SB.ToString();

            }
            finally
            {

                StringBuilderPool.Put(SB);

            }

            TheStreamWriter.Write(Contents);

        }

        public void Write(Stream TheStream)
        {

            Write(new StreamWriter(TheStream));

        }

        public void ToStringBuilder(StringBuilder TheSB)
        {

            foreach(var Item in myItems)
            {

                if(Item is IAppendTo)
                {

                    ((IAppendTo)Item).AppendTo(TheSB);

                }
                else if(Item is IEnumerable<IAppendTo>)
                {

                    IEnumerable<IAppendTo> Items = (IEnumerable<IAppendTo>)Item;

                    foreach(var Item1 in Items)
                    {

                        Item1.AppendTo(TheSB);

                    }

                }
                else
                {

                    throw new Exception("Tag type not valid");

                }

            }

        }

        public override string ToString()
        {

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            string Contents;

            try
            {

                ToStringBuilder(SB);

                Contents = SB.ToString();

            }
            finally
            {

                StringBuilderPool.Put(SB);

            }

            return Contents;

        }

        public StringBuilder ToStringBuilder()
        {

            StringBuilder SB = new StringBuilder();

            ToStringBuilder(SB);

            return SB;

        }

    }

}
