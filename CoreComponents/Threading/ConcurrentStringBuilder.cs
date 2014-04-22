using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Threading
{

    public class ConcurrentStringBuilder : IToArray<char>, IToStringBuilder
    {

        protected StringBuilder mySB;

        protected object myLockObject = new object();

        protected char myPaddingValue = ' ';

        public ConcurrentStringBuilder()
        {

            mySB = new StringBuilder();

        }

        public ConcurrentStringBuilder(int TheCapacity)
        {

            mySB = new StringBuilder(TheCapacity);

        }

        public ConcurrentStringBuilder(string TheValue)
        {

            mySB = new StringBuilder(TheValue);

        }

        public ConcurrentStringBuilder(int TheCapacity, int TheMaxCapacity)
        {

            mySB = new StringBuilder(TheCapacity, TheMaxCapacity);

        }

        public ConcurrentStringBuilder(string TheValue, int TheCapacity)
        {

            mySB = new StringBuilder(TheValue, TheCapacity);

        }

        public ConcurrentStringBuilder(string TheValue, int TheCtartIndex, int TheLength, int TheCapacity)
        {

            mySB = new StringBuilder(TheValue, TheCtartIndex, TheLength, TheCapacity);

        }

        public ConcurrentStringBuilder(IEnumerable<char> TheChars)
        {

            mySB = new StringBuilder();

            foreach(var Item in TheChars)
            {

                mySB.Append(Item);

            }

        }

        public int Capacity
        {

            get
            {

                lock(myLockObject)
                {

                    return mySB.Capacity;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    mySB.Capacity = value;

                }

            }

        }

        public int Length
        {

            get
            {

                lock(myLockObject)
                {

                    return mySB.Length;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    mySB.Length = value;

                }

            }

        }

        public int MaxCapacity
        {

            get
            {

                return mySB.MaxCapacity;

            }

        }

        public char PaddingValue
        {

            get
            {

                lock(myLockObject)
                {

                    return myPaddingValue;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myPaddingValue = value;

                }

            }

        }

        public char this[int TheIndex]
        {

            get
            {

                lock(myLockObject)
                {

                    return mySB[TheIndex];

                }

            }
            set
            {

                lock(myLockObject)
                {

                    mySB[TheIndex] = value;

                }

            }

        }

        public void Append(bool TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(byte TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(char TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(char[] TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(decimal TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(double TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(float TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(int TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(long TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(object TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }
 
        public void Append(sbyte TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(short TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }
 
        public void Append(string TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(uint TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(ulong TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(ushort TheValue)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue);

            }

        }

        public void Append(IEnumerable<char> TheEnuerator)
        {

            lock(myLockObject)
            {

                foreach(var Item in TheEnuerator)
                {

                    mySB.Append(Item);

                }

            }

        }

        public void Append(StringBuilder TheStringBuilder)
        {

            lock(myLockObject)
            {

                for(int i = 0; i < TheStringBuilder.Length; ++i) 
                {

                    mySB.Append(TheStringBuilder[i]);

                }

            }

        }

        public void Append(ConcurrentStringBuilder TheStringBuilder)
        {

            if(TheStringBuilder == this)
            {

                TheStringBuilder.Append(ToArray());

                return;

            }

            lock(myLockObject)
            {

                for(int i = 0; i < TheStringBuilder.Length; ++i)
                {

                    mySB.Append(TheStringBuilder[i]);

                }

            }

        }

        public void Append(char TheValue, int RepeatCount)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue, RepeatCount);

            }

        }

        public void Append(char[] TheValue, int StartIndex, int CharCount)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue, StartIndex, CharCount);

            }

        }

        public void Append(string TheValue, int StartIndex, int TheCount)
        {

            lock(myLockObject)
            {

                mySB.Append(TheValue, StartIndex, TheCount);

            }

        }

        public void AppendFormat(string Format, object Arg0)
        {

            lock(myLockObject)
            {

                mySB.AppendFormat(Format, Arg0);

            }

        }

        public void AppendFormat(string Format, params object[] Args)
        {

            lock(myLockObject)
            {

                mySB.AppendFormat(Format, Args);

            }

        }

        public void AppendFormat(IFormatProvider Provider, string Format, params object[] Args)
        {

            lock(myLockObject)
            {

                mySB.AppendFormat(Provider, Format, Args);

            }

        }

        public void AppendFormat(string Format, object Arg0, object Arg1)
        {

            lock(myLockObject)
            {

                mySB.AppendFormat(Format, Arg0, Arg1);

            }

        }

        public void AppendFormat(string Format, object Arg0, object Arg1, object Arg2)
        {

            lock(myLockObject)
            {

                mySB.AppendFormat(Format, Arg0, Arg1, Arg2);

            }

        }

        public void AppendLine()
        {

            lock(myLockObject)
            {

                mySB.AppendLine();

            }

        }

        public void AppendLine(string TheValue)
        {

            lock(myLockObject)
            {

                mySB.AppendLine(TheValue);

            }

        }


        public void Clear()
        {

            lock(myLockObject)
            {

                mySB.Clear();

            }

        }
 
        public void CopyTo(int TheSourceIndex, char[] TheDestination, int DestinationIndex, int TheCount)
        {

            lock(myLockObject)
            {

                mySB.CopyTo(TheSourceIndex, TheDestination, DestinationIndex, TheCount);

            }

        }

        public int EnsureCapacity(int TheCapacity)
        {

            lock(myLockObject)
            {

                return mySB.EnsureCapacity(TheCapacity);

            }

        }

        public bool Equals(StringBuilder TheStringBuilder)
        {

            lock(myLockObject)
            {

                return mySB.Equals(TheStringBuilder);

            }

        }

        public bool Equals(ConcurrentStringBuilder TheStringBuilder)
        {

            if(TheStringBuilder == this)
                return true;

            lock(myLockObject)
            {

                if(mySB.Length != TheStringBuilder.Length)
                    return false;

                for(int i = 0; i < mySB.Length; i++)
                {

                    if(mySB[i] == TheStringBuilder[i])
                        return false;

                }

            }

            return true;

        }

        public void Pad(int Count)
        {

            lock(myLockObject)
            {

                ProtectedPad(Count);

            }

        }

        protected void ProtectedPad(int Count)
        {

            for(; Count > 0; --Count)
            {

                mySB.Append(myPaddingValue);

            }

        }

        public void PadTo(int TheLength)
        {

            lock(myLockObject)
            {

                ProtectedPadTo(TheLength);

            }

        }

        protected void ProtectedPadTo(int TheLength)
        {

            int i = mySB.Length - TheLength;

            if(i > 0)
            {

                for(; i > 0; --i)
                {

                    mySB.Append(myPaddingValue);

                }

            }

        }

        public void Insert(int Index, bool TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, byte TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, char TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, char[] TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, decimal TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }
        
        public void Insert(int Index, double TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }
        
        public void Insert(int Index, float TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }
        
        public void Insert(int Index, int TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, long TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, object TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, sbyte TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, short TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, string TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, uint TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, ulong TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, ushort TheValue)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, IEnumerable<char> TheEnuerator)
        {

            foreach(var Item in TheEnuerator)
            {

                Insert(Index++, Item);

            }

        }

        public void Insert(int Index, StringBuilder TheStringBuilder)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                int FinalIndex = Index + TheStringBuilder.Length - 1;

                for(; Index < FinalIndex; ++Index)
                {

                    mySB.Append(TheStringBuilder[Index]);

                }

            }

        }

        public void Insert(int Index, ConcurrentStringBuilder TheStringBuilder)
        {

            if(TheStringBuilder == this)
                throw new Exception("A ConcurrentStringBuilder cannot insert or append to itself");

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                int FinalIndex = Index + TheStringBuilder.Length - 1;

                for(; Index < FinalIndex; ++Index)
                {

                    mySB.Append(TheStringBuilder[Index]);

                }

            }

        }

        public void Insert(int Index, string TheValue, int count)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Insert(int Index, char[] TheValue, int startIndex, int charCount)
        {

            lock(myLockObject)
            {

                if(Index > mySB.Length)
                    ProtectedPadTo(Index);

                mySB.Insert(Index, TheValue);

            }

        }

        public void Remove(int StartIndex, int TheLength)
        {

            lock(myLockObject)
            {

                mySB.Remove(StartIndex, TheLength);

            }

        }

        public void Replace(char OldChar, char NewChar)
        {

            lock(myLockObject)
            {

                mySB.Replace(OldChar, NewChar);

            }

        }

        public void Replace(string OldValue, string NewValue)
        {

            lock(myLockObject)
            {

                mySB.Replace(OldValue, NewValue);

            }

        }

        public void Replace(char OldChar, char NewChar, int StartIndex, int Count)
        {

            lock(myLockObject)
            {

                mySB.Replace(OldChar, NewChar, StartIndex, Count);

            }

        }

        public void Replace(string OldValue, string NewValue, int StartIndex, int Count)
        {

            lock(myLockObject)
            {

                mySB.Replace(OldValue, NewValue, StartIndex, Count);

            }

        }

        public void ReplaceWithPadding(int Index)
        {

            lock(myLockObject)
            {

                mySB[Index] = myPaddingValue;

            }

        }

        public char[] ToArray()
        {

            lock(myLockObject)
            {

                char[] CharArray = new char[mySB.Length];

                for(int i = 0; i < mySB.Length; ++i)
                {

                    CharArray[i] = mySB[i];

                }

                return CharArray;

            }

        }

        public override string ToString()
        {

            lock(myLockObject)
            {

                return mySB.ToString();

            }

        }

        public string ToString(int TheStartIndex, int TheLength)
        {

            lock(myLockObject)
            {

                return mySB.ToString(TheStartIndex, TheLength);

            }

        }

        public StringBuilder ToStringBuilder()
        {

            lock(myLockObject)
            {

                StringBuilder SB = new StringBuilder(mySB.Capacity);

                for(int i = 0; i < mySB.Length; ++i)
                {

                    SB.Append(mySB[i]);

                }

                return SB;

            }

        }

        public StringBuilder ToStringBuilder(int TheStartIndex, int TheLength)
        {

            lock(myLockObject)
            {

                StringBuilder SB = new StringBuilder(mySB.Capacity);

                for(; TheStartIndex < mySB.Length; ++TheStartIndex)
                {

                    SB.Append(mySB[TheStartIndex]);

                    --TheLength;

                    if(TheLength < 1)
                        break;

                }

                return SB;

            }

        }

    }

}
