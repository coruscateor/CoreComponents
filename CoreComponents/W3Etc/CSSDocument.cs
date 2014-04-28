using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{

    public class CSSDocument : IList<Rule>, IToStringBuilder
    {

        List<Rule> myRules = new List<Rule>();

        public CSSDocument()
        {
        }

        public int IndexOf(Rule TheItem)
        {

            return myRules.IndexOf(TheItem);

        }

        public void Insert(int TheIndex, Rule TheItem)
        {

            myRules.Insert(TheIndex, TheItem);

        }

        public void RemoveAt(int TheIndex)
        {

            myRules.RemoveAt(TheIndex);

        }

        public Rule this[int TheIndex]
        {

            get
            {

                return myRules[TheIndex];

            }
            set
            {

                myRules[TheIndex] = value;

            }
        }

        public void Add(Rule TheItem)
        {

            myRules.Add(TheItem);

        }

        public void Clear()
        {

            myRules.Clear();

        }

        public bool Contains(Rule TheItem)
        {

            return myRules.Contains(TheItem);

        }

        public void CopyTo(Rule[] TheArray, int TheArrayIndex)
        {

            myRules.CopyTo(TheArray, TheArrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myRules.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(Rule TheItem)
        {

            return myRules.Remove(TheItem);

        }

        public IEnumerator<Rule> GetEnumerator()
        {

            return myRules.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

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
            
            TabIndentationLevelBuilder FirstLevel = new TabIndentationLevelBuilder();

            foreach(var Item in myRules)
            {

                Item.Append(TheSB, FirstLevel);

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
