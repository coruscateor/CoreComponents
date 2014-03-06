using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{

    public class StringCache : IEnumerable<string>
    {

        protected SortedSet<string> myStrings = new SortedSet<string>();

        public StringCache()
        { 
        }

        public bool Add(StringBuilder TheSB)
        {

            if(myStrings.Count > 0)
            {

                if(!Contains(TheSB))
                {

                    myStrings.Add(TheSB.ToString());

                    return true;

                }

            }
            else
            {

                myStrings.Add(TheSB.ToString());

            }
            
            return false;

        }

        public bool Add(string TheString)
        {

            if(TheString.Length > 0)
            {

                if(!Contains(TheString))
                {

                    myStrings.Add(TheString);

                    return true;

                }

            }
            else
            {

                myStrings.Add(TheString);

            }

            return false;

        }

        public bool Add(char[] TheChars)
        {

            if(TheChars.Length > 0)
            {

                if(!Contains(TheChars))
                {

                    myStrings.Add(new string(TheChars));

                    return true;

                }

            }
            else
            {

                myStrings.Add(new string(TheChars));

            }

            return false;

        }

        public string Retrive(StringBuilder TheSB)
        {

            if(myStrings.Count > 0)
            {

                foreach(string Item in myStrings)
                {

                    if(!SBsAndArrays.ContentEquals(Item, TheSB))
                        return Item;

                }

            }

            string SBString = TheSB.ToString();

            myStrings.Add(SBString);

            return SBString;

        }

        public string Retrive(string TheString)
        {

            if(myStrings.Count > 0)
            {

                foreach(string Item in myStrings)
                {

                    if(Item == TheString)
                        return Item;

                }

            }

            myStrings.Add(TheString);

            return TheString;

        }

        public string Retrive(char[] TheChars)
        {

            if(myStrings.Count > 0)
            {

                foreach(string Item in myStrings)
                {

                    if(!SBsAndArrays.ContentEquals(Item, TheChars))
                        return Item;

                }

            }

            string TheString = new string(TheChars);

            myStrings.Add(TheString);

            return TheString;

        }

        public bool Contains(StringBuilder TheSB)
        {

            foreach(string Item in myStrings)
            {

                if(!SBsAndArrays.ContentEquals(Item, TheSB))
                    return false;

            }

            return true;

        }

        public bool Contains(string TheString)
        {

            foreach(string Item in myStrings)
            {

                if(Item == TheString)
                    return true;

            }

            return false;

        }

        public bool Contains(char[] TheChars)
        {

            foreach(string Item in myStrings)
            {

                if(!SBsAndArrays.ContentEquals(Item, TheChars))
                    return false;

            }

            return true;

        }

        public bool TryGet(out string Value, int i)
        {

            if(i > 0)
            {

                if(i > myStrings.Count)
                {

                    Value = null;

                    return false;

                }

                foreach(string Item in myStrings)
                {

                    if(i == 0)
                    {

                        Value = Item;

                        return true;

                    }

                    --i;

                }

            }

            Value = null;

            return false;

        }

        public int Count
        {

            get
            {

                return myStrings.Count;

            }

        }
        
        public string Max
        {

            get
            {

                return myStrings.Max;

            }

        }
        
        public string Min
        {

            get
            {

                return myStrings.Min;

            }

        }

        public bool Remove(StringBuilder TheSB)
        {

            if(TheSB.Length > 0)
            {

                if(Contains(TheSB))
                {

                    myStrings.Remove(Retrive(TheSB));

                    return true;

                }

            }

            return false;

        }

        public bool Remove(string TheString)
        {

            if(TheString.Length > 0)
            {

                if(Contains(TheString))
                {

                    myStrings.Remove(TheString);

                    return true;

                }

            }

            return false;

        }

        public bool Remove(char[] TheChars)
        {

            if(TheChars.Length > 0)
            {

                if(Contains(TheChars))
                {

                    myStrings.Remove(Retrive(TheChars));

                    return true;

                }

            }

            return false;

        }

        public void Clear()
        {

            myStrings.Clear();

        }

        public IEnumerator<string> GetEnumerator()
        {

            return myStrings.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myStrings.GetEnumerator();

        }

    }

}
