using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Text
{

    public class LongStringBuilder
    {

        LongList<char> myList;

        public LongStringBuilder()
        {

            myList = new LongList<char>(256);
            
        }

        //public StringBuilder(long capacity);

        //public StringBuilder(string value);

        //public StringBuilder(long capacity, long maxCapacity);

        //public StringBuilder(string value, long capacity);

        //public StringBuilder(string value, long startIndex, long length, long capacity);

        //public long Capacity { get; set; }

        public long Length
        {

            get
            {

                return myList.Count;

            }
            //set;
        
        }

        //public long MaxCapacity { get; }

        public char this[long index]
        {

            get
            {

                return myList[index];

            }
            set
            {

                myList[index] = value;

            }
        
        }

        //public char this[int index]
        //{

        //    get
        //    {

        //        return myList[index];

        //    }
        //    set
        //    {

        //        myList[index] = value;

        //    }

        //}

        public void Append(bool value)
        {

            Append(value.ToString());

        }

        public void Append(byte value)
        {

            Append(value.ToString());

        }

        public void Append(char value)
        {

            Append(value.ToString());

        }

        public void Append(char[] value)
        {

            if(value != null)
            {

                for(int i = 0; i < value.Length; ++i)
                {

                    myList.Add(value[i]);

                }

            }

        }

        public void Append(decimal value)
        {

            Append(value.ToString());

        }

        public void Append(double value)
        {

            Append(value.ToString());

        }

        public void Append(float value)
        {

            Append(value.ToString());

        }

        public void Append(int value)
        {

            Append(value.ToString());

        }

        public void Append(long value)
        {

            Append(value.ToString());

        }

        public void Append(object value)
        {

            if(value != null)
            {

                Append(value.ToString());

            }

        }

        public void Append(sbyte value)
        {

            Append(value.ToString());

        }

        public void Append(short value)
        {

            Append(value.ToString());

        }

        public void Append(string value)
        {

            if(value != null)
            {

                for(int i = 0; i < value.Length; ++i)
                {

                    myList.Add(value[i]);

                }

            }

        }

        public void Append(uint value)
        {

            Append(value.ToString());

        }

        public void Append(ulong value)
        {

            Append(value.ToString());

        }

        public void Append(ushort value)
        {

            Append(value.ToString());

        }

        public void Append(LongString value)
        {

            if(value != null && value.Length > 0)
            {

                for(long i = 0; i < value.Length; ++i)
                {

                    myList.Add(value[i]);

                }

            }

        }

        public void Append(LongStringBuilder value)
        {

            if(value != null && value.Length > 0)
            {

                for(long i = 0; i < value.Length; ++i)
                {

                    myList.Add(value[i]);

                }

            }

        }

        public void Append(char value, long repeatCount)
        {

            if(repeatCount > 0)
            {

                for(; repeatCount > 0; --repeatCount)
                {

                    myList.Add(value);

                }

            }

        }

        //public void Append(char[] value, long startIndex, long charCount);

        //public void Append(string value, long startIndex, long count);

        //public void AppendFormat(string format, object arg0);

        //public void AppendFormat(string format, params object[] args);

        //public void AppendFormat(IFormatProvider provider, string format, params object[] args);

        //public void AppendFormat(string format, object arg0, object arg1);

        //public void AppendFormat(string format, object arg0, object arg1, object arg2);

        public void AppendLine()
        {

            Append(Environment.NewLine);

        }

        public void AppendLine(string value)
        {

            Append(value);

            Append(Environment.NewLine);

        }

        public void AppendLine(LongString value)
        {

            Append(value);

            Append(Environment.NewLine);

        }

        public void AppendLine(LongStringBuilder value)
        {

            Append(value);

            Append(Environment.NewLine);

        }

        public void Clear()
        {

            myList.Clear();

        }

        public void CopyTo(long sourceIndex, char[] destination, long destinationIndex, long count)
        {

            if(sourceIndex < 0)
                throw new Exception("sourceIndex must be greater than -1");

            if(destination == null)
                throw new Exception("destination must not be null");

            if(destination.LongLength < 1)
                throw new Exception("destination must have a Length greater than 0");

            if(destinationIndex < 0)
                throw new Exception("destinationIndex must be greater than -1");

            if(count < 0)
                throw new Exception("count must be greater than -1");

            if(destinationIndex > sourceIndex)
                throw new Exception("sourceIndex is greater than destinationIndex");

            for(; sourceIndex < myList.Count; ++sourceIndex)
            {

                destination[destinationIndex] = myList[sourceIndex];

                --count;

                if(count < 1)
                    return;

                ++destinationIndex;

            }

        }

        //public long EnsureCapacity(long capacity);

        public bool Equals(LongStringBuilder sb)
        {

            if(sb == null)
                return false;

            if(sb.Length == 0 && myList.Count == 0)
                return true;

            if(sb.Length == myList.Count)
            {

                for(long i = 0; i < myList.Count; ++i)
                {

                    if(sb[i] != myList[i])
                        return false;

                }

            }

            return true;

        }

        public void Insert(long index, bool value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, byte value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, char value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, char[] value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, decimal value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, double value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, float value)
        {

            Insert(index, value.ToString());

        }
 
        public void Insert(long index, int value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, long value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, object value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, sbyte value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, short value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, string value)
        {

            if(value == null)
                return;

            if(value.Length > 0)
                return;

            for(int i = 0; i < value.Length; ++i)
            {

                myList.InsertRange(index, value, value.Length);

            }

        }

        public void Insert(long index, uint value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, ulong value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, ushort value)
        {

            Insert(index, value.ToString());

        }

        public void Insert(long index, string value, long count)
        {

            if(value == null)
                return;

            if(value.Length > 0)
                return;

            if(index < 0)
                throw new Exception("index must be greater than -1");

            if(count < 0)
                return;

            myList.InsertRange(index, value, count);

        }

        //public void Insert(long index, char[] value, long startIndex, long charCount);

        //public void Remove(long startIndex, long length);

        public void Replace(char oldChar, char newChar)
        {

            if(myList.Count < 1)
                return;

            for(long i = 0; i < myList.Count; ++i)
            {

                char Item = myList[i];

                if(Item == oldChar)
                {

                    myList[i] = newChar;

                }

            }

        }

        //public void Replace(string oldValue, string newValue);

        //public void Replace(char oldChar, char newChar, long startIndex, long count);

        //public void Replace(string oldValue, string newValue, long startIndex, long count);

        public string[] Divide()
        {

            if(myList.Count > 0)
            {

                long IntMaxValue = int.MaxValue;

                if(myList.Count > IntMaxValue)
                {

                    long NumberOfFullStrings = myList.Count / IntMaxValue;

                    bool HasPartialString = myList.Count % IntMaxValue > 0;

                    string[] Strings;

                    if(HasPartialString)
                    {

                        Strings = new string[NumberOfFullStrings];

                    }
                    else
                    {

                        Strings = new string[NumberOfFullStrings + 1];

                    }

                    long Index = 0;

                    long NextIndex = IntMaxValue;

                    char[] Chars = new char[IntMaxValue];

                    for(long i = 0; i < NumberOfFullStrings; ++i)
                    {

                        long ArrayIndex = 0;

                        for(; Index < NextIndex; ++Index)
                        {

                            Chars[ArrayIndex] = myList[Index];

                        }

                        Strings[i] = new string(Chars);

                    }

                    NextIndex += IntMaxValue;

                    if(HasPartialString)
                    {

                        Chars = new char[myList.Count - NextIndex + 1];

                        for(long i = 0; i < myList.Count; ++i)
                        {

                            Chars[i] = myList[NextIndex];

                            ++NextIndex;

                        }

                        Strings[Strings.LongLength - 1] = new string(Chars);

                    }

                    return Strings;

                }

                return new string[] { new string(myList.ToArray()) };

            }

            return new string[0];

        }

        public override string ToString()
        {

            if(myList.Count > int.MaxValue)
            {

                long Max = int.MaxValue;

                char[] Items = new char[Max];

                for(long i = 0; i < Max; ++i)
                {

                    Items[i] = myList[i];

                }

                return new string(Items);

            }

            return new string(myList.ToArray());

        }

        public string ToString(long startIndex, int length)
        {

            if(length < 1)
                return "";

            if(startIndex < 1)
                throw new Exception("startIndex must be greater than 0");

            char[] Chars = new char[length];

            int i = 0;

            for(; startIndex < myList.Count; ++startIndex)
            {

                Chars[i] = myList[startIndex];

                ++i;

            }

            return new string(Chars);

        }

        public LongString ToLongString()
        {

            return new LongString(myList);

        }

        public LongString ToLongString(long startIndex, long length)
        {

            if(length < 1)
                return new LongString();

            if(startIndex < 1)
                throw new Exception("startIndex must be greater than 0");

            char[] Chars = new char[length];

            int i = 0;

            for(; startIndex < myList.Count; ++startIndex)
            {

                Chars[i] = myList[startIndex];

                ++i;

            }

            return new LongString(Chars);

        }

    }

}
