using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using CoreComponents.Items;

namespace CoreComponents.Text
{

    public class LongString : IComparable, IConvertible, IComparable<LongString>, IEnumerable<char>, IEquatable<LongString>, ICloneable<LongString>, IToArray<char>
    {

        protected char[] myChars;

        public LongString()
        {

            myChars = new char[0];

        }

        //public static readonly LongString Empty = new LongString();

        //public LongString(char* value)
        //{ 
        //}

        public LongString(char[] value)
        {

            myChars = new char[value.LongLength];

            for(long i = 0; i < value.LongLength; ++i)
            {

                myChars[i] = value[i];

            }

        }

        public LongString(ILongList<char> value)
        {

            myChars = new char[value.Count];

            for(long i = 0; i < value.Count; ++i)
            {

                myChars[i] = value[i];

            }

        }

        //public LongString(sbyte* value)
        //{
        //}

        public LongString(char c, long count)
        {

            myChars = new char[count];

            if(count == 1)
            {

                myChars[0] = c;

            }
            else if(count > 1)
            {

                for(uint i = 0; i < count; ++i)
                {

                    myChars[i] = c;

                }

            }


        }

        //public LongString(char* value, int startIndex, int length)
        //{
        //}

        public LongString(char[] value, long startIndex, long length)
        {

            for(uint i = 0; i < length; ++startIndex)
            {

                myChars[i] = value[startIndex];

                ++startIndex;

            }

        }

        //public LongString(sbyte* value, int startIndex, int length)
        //{
        //}

        //public LongString(sbyte* value, int startIndex, int length, Encoding enc)
        //{
        //}

        public LongString(string TheString)
        {

            myChars = new char[TheString.Length];

            for(int i = 0; i < TheString.Length; ++i)
            {

                myChars[i] = TheString[i];

            }

        }

        public LongString(LongString TheString)
        {

            myChars = new char[TheString.Length];

            for(uint i = 0; i < TheString.Length; ++i)
            {

                myChars[i] = TheString[i];

            }

        }

        //public static bool operator ==(LongString a, string b)
        //{

        //    if(a.Length != b.Length)
        //        return true;

        //    for(int i = 0; i < b.Length; ++i)
        //    {

        //        if(a[i] == b[i])
        //            return true;

        //    }

        //    return false;

        //}

        //public static bool operator !=(LongString a, string b)
        //{

        //    if(a.Length != b.Length)
        //        return true;

        //    for(int i = 0; i < b.Length; ++i)
        //    {

        //        if(a[i] != b[i])
        //            return true;

        //    }

        //    return false;

        //}

        //public static bool operator ==(string a, LongString b)
        //{

        //    if(a.Length == b.Length)
        //        return true;

        //    for(int i = 0; i < b.Length; ++i)
        //    {

        //        if(a[i] == b[i])
        //            return true;

        //    }

        //    return false;

        //}

        //public static bool operator !=(string a, LongString b)
        //{

        //    for(int i = 0; i < b.Length; ++i)
        //    {

        //        if(a[i] != b[i])
        //            return true;

        //    }

        //    return false;

        //}

        public static bool operator !=(LongString a, LongString b)
        {

            if(a == null)
            {

                if(b == null)
                    return false;
            }

            if(b == null)
                return true;

            if(a.Length != b.Length)
                return true;

            for(int i = 0; i < b.Length; ++i)
            {

                if(a[i] != b[i])
                    return true;

            }

            return false;

        }

        public static bool operator ==(LongString a, LongString b)
        {

            if(a == null)
            {

                if(b == null)
                    return true;
            }

            if(b == null)
                return false;

            if(a.Length != b.Length)
                return false;

            for(int i = 0; i < b.Length; ++i)
            {

                if(a[i] == b[i])
                    return false;

            }

            return true;

        }

        public static LongString operator +(LongString a, string b)
        {

            long Left = 0;

            int right = 0;

            if(a != null)
                Left = a.Length;

            if(b != null)
                right = b.Length;

            char[] Chars = new char[Left + right];

            long i = 0;

            for(; i < a.Length; ++i)
            {

                Chars[i] = a[i]; 

            }

            for(int y = 0; y < b.Length; ++y)
            {

                ++i;

                Chars[i] = a[y]; 

            }

            return new LongString(Chars);

        }

        public static LongString operator +(string a, LongString b)
        {

            int Left = 0;

            long right = 0;

            if(a != null)
                Left = a.Length;

            if(b != null)
                right = b.Length;

            char[] Chars = new char[Left + right];

            int i = 0;

            for(; i < a.Length; ++i)
            {

                Chars[i] = a[i];

            }

            for(int y = 0; y < b.Length; ++y)
            {

                ++i;

                Chars[i] = a[y];

            }

            return new LongString(Chars);

        }

        public static LongString operator +(LongString a, LongString b)
        {

            long Left = 0;

            long right = 0;

            if(a != null)
                Left = a.Length;

            if(b != null)
                right = b.Length;

            char[] Chars = new char[Left + right];

            long i = 0;

            for(; i < a.Length; ++i)
            {

                Chars[i] = a[i];

            }

            for(long y = 0; y < b.Length; ++y)
            {

                ++i;

                Chars[i] = a[y];

            }

            return new LongString(Chars);

        }

        public int Length32
        {

            get
            {

                return myChars.Length;

            }

        }

        public long Length
        {

            get
            {

                return myChars.LongLength;
 
            }
            
        }

        public char this[int index]
        {

            get
            {

                return myChars[index];

            }

        }

        public char this[long index]
        {

            get
            {

                return myChars[index];

            }

        }

        public LongString Clone()
        {

            return new LongString(myChars);

        }

        object ICloneable.Clone()
        {

            return this.Clone();

        }

        //public static int Compare(string strA, string strB);

        //public static int Compare(string strA, string strB, bool ignoreCase);

        //public static int Compare(string strA, string strB, StringComparison comparisonType);

        //public static int Compare(string strA, string strB, bool ignoreCase, CultureInfo culture);

        //public static int Compare(string strA, string strB, CultureInfo culture, CompareOptions options);
 
        //public static int Compare(string strA, int indexA, string strB, int indexB, int length);

        //public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase);

        //public static int Compare(string strA, int indexA, string strB, int indexB, int length, StringComparison comparisonType);

        //public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase, CultureInfo culture);

        //public static int Compare(string strA, int indexA, string strB, int indexB, int length, CultureInfo culture, CompareOptions options);

        //public static int CompareOrdinal(string strA, string strB);

        //public static int CompareOrdinal(string strA, int indexA, string strB, int indexB, int length);

        //public int CompareTo(object value);

        //public int CompareTo(string strB);

        //public int CompareTo(LongString strB);

        //public static string Concat(IEnumerable<string> values);

        //public static string Concat<T>(IEnumerable<T> values);

        //public static string Concat(object arg0);

        //public static string Concat(params object[] args);

        //public static string Concat(params string[] values);

        //public static string Concat(object arg0, object arg1);

        //public static string Concat(string str0, string str1);

        //public static string Concat(object arg0, object arg1, object arg2);

        //public static string Concat(string str0, string str1, string str2);

        //public static string Concat(object arg0, object arg1, object arg2, object arg3);

        //public static string Concat(string str0, string str1, string str2, string str3);

        public bool Contains(char value)
        {

            if(myChars.LongLength > 0)
            {

                for(long i = 0; i < myChars.LongLength; ++i)
                {

                    if(myChars[i] == value)
                        return true;

                }

            }

            return false;

        }

        public bool Contains(string value)
        {

            if(value == null || value.Length < 1)
                return false;

            if(myChars.Length < value.Length)
                return false;

            if(myChars.LongLength > 0)
            {

                char FirstChar = value[0];

                if(value.Length > 1)
                {

                    for(long i = 0; i < myChars.LongLength; ++i)
                    {

                        if(FirstChar == myChars[i])
                        {

                            int LastIndex = value.Length - 1;

                            for(int y = 1; y < value.Length; ++y)
                            {

                                ++i;

                                if(i > myChars.LongLength)
                                    break;

                                char NextChar = value[y];

                                if(NextChar != myChars[i])
                                    break;
                                else if(y == LastIndex)
                                    return true;
                            }   

                        }

                    }

                }
                else
                {

                    for(long i = 0; i < myChars.LongLength; ++i)
                    {

                        if(myChars[i] == FirstChar)
                            return true;

                    }

                }


            }

            return false;

        }

        public bool Contains(LongString value)
        {

            if(value == null || value.Length < 1)
                return false;

            if(myChars.Length < value.Length)
                return false;

            if(myChars.LongLength > 0)
            {

                char FirstChar = value[0];

                if(value.Length > 1)
                {

                    for(long i = 0; i < myChars.LongLength; ++i)
                    {

                        if(FirstChar == myChars[i])
                        {

                            long LastIndex = value.Length - 1;

                            for(int y = 1; y < value.Length; ++y)
                            {

                                ++i;

                                if(i > myChars.LongLength)
                                    break;

                                char NextChar = value[y];

                                if(NextChar != myChars[i])
                                    break;
                                else if(y == LastIndex)
                                    return true;
                            }

                        }

                    }

                }
                else
                {

                    for(long i = 0; i < myChars.LongLength; ++i)
                    {

                        if(myChars[i] == FirstChar)
                            return true;

                    }

                }


            }

            return false;

        }

        //public static string Copy(string str);

        //public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        //{

        //    if(sourceIndex > myChars.Length || sourceIndex < 0)
        //        return;

        //    if(destination == null)
        //        return;

        //    if(destinationIndex < destination.Length || destinationIndex < 0)
        //        return;

        //    if(count < 1)
        //        return;

        //    for(; sourceIndex < destination.Length - 1 && count > 0; ++sourceIndex)
        //    {

        //        destination[destinationIndex] = myChars[sourceIndex];

        //        --count;

        //        ++destinationIndex;

        //    }

        //}

        public void CopyTo(long sourceIndex, char[] destination, long destinationIndex, long count)
        {

            if(sourceIndex > myChars.Length || sourceIndex < 0)
                return;

            if(destination == null)
                return;

            if(destinationIndex < destination.Length || destinationIndex < 0)
                return;

            if(count < 1)
                return;

            for(; sourceIndex < destination.LongLength - 1 && count > 0; ++sourceIndex)
            {

                destination[destinationIndex] = myChars[sourceIndex];

                --count;

                ++destinationIndex;

            }

        }

        public bool EndsWith(char value)
        {

            if(myChars.Length == 0)
                return false;

            return myChars[myChars.LongLength - 1] == value;

        }

        public bool EndsWith(string value)
        {

            if(myChars.Length == 0)
                return false;

            if(value == null || value.Length < 1)
                return false;

            if(value.Length > 1)
            {

                int LastIndexOfValue = value.Length - 1;

                for(long i = myChars.LongLength - 1; i > 0; --i)
                {

                    if(myChars[i] != value[LastIndexOfValue])
                        return false;

                    if(LastIndexOfValue == 0)
                        return true;

                    --LastIndexOfValue;

                }

            }
            else
            {

                return myChars[myChars.LongLength - 1] == value[0];

            }

            return false;

        }

        //public bool EndsWith(string value, StringComparison comparisonType)
        //{

        //    throw new NotImplementedException();

        //}

        //public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
        //{

        //    throw new NotImplementedException();

        //}

        public bool EndsWith(LongString value)
        {

            if(myChars.Length == 0)
                return false;

            if(value == null || value.Length < 1)
                return false;

            if(value.Length > 1)
            {
                
                long LastIndexOfValue = value.Length - 1;

                for(long i = myChars.LongLength - 1; i > 0; --i)
                {

                    if(myChars[i] != value[LastIndexOfValue])
                        return false;

                    if(LastIndexOfValue == 0)
                        return true;

                    --LastIndexOfValue;

                }

            }
            else
            {

                return myChars[myChars.LongLength - 1] == value[0];

            }

            return false;

        }

        //public bool EndsWith(LongString value, StringComparison comparisonType)
        //{

        //    throw new NotImplementedException();

        //}

        //public bool EndsWith(LongString value, bool ignoreCase, CultureInfo culture)
        //{

        //    throw new NotImplementedException();

        //}

        public override bool Equals(object obj)
        {

            Type ObjectType = obj.GetType();

            if(ObjectType == typeof(string))
            {

                return Equals((string)obj);

            }
            else if(ObjectType == typeof(LongString))
            {

                return Equals((LongString)obj);

            }

            return false;

        }

        public bool Equals(string value)
        {

            if(value == null)
                return false;

            if(value.Length < 1)
                return value.Length == myChars.Length;

            if(value.Length == myChars.LongLength)
            {

                if(value.Length == 1)
                    return value[0] == myChars[0];

                for(int i = 0; i < value.Length; ++i)
                {

                    if(value[i] != myChars[i])
                        return false;

                }

            }
            else
            {

                return false;

            }

            return true;

        }

        public bool Equals(LongString value)
        {

            if(value == null)
                return false;

            if(value.Length < 1)
                return value.Length == myChars.Length;

            if(value.Length == myChars.LongLength)
            {

                if(value.Length == 1)
                    return value[0] == myChars[0];

                for(long i = 0; i < value.Length; ++i)
                {

                    if(value[i] != myChars[i])
                        return false;

                }

            }
            else
            {

                return false;

            }

            return true;

        }

        //public static bool Equals(string a, string b);

        //public bool Equals(string value, StringComparison comparisonType);

        //public static bool Equals(string a, string b, StringComparison comparisonType);

        //public static string Format(string format, object arg0);

        //public static string Format(string format, params object[] args);

        //public static string Format(IFormatProvider provider, string format, params object[] args);

        //public static string Format(string format, object arg0, object arg1);

        //public static string Format(string format, object arg0, object arg1, object arg2);

        //public CharEnumerator GetEnumerator();

        //public override int GetHashCode()
        //{

        //    return this.GetHashCode();

        //}

        //public TypeCode GetTypeCode()
        //{

        //    return this.GetTypeCode();

        //}

        public long IndexOf(char value)
        {

            if(myChars.LongLength> 0)
            {

                if(myChars.LongLength == 1)
                {

                    if(myChars[0] == value)
                        return 0;

                }

                for(long i = 0; i < myChars.LongLength; ++i)
                {

                    if(myChars[i] == value)
                        return i;

                }

            }

            return -1;

        }

        public long IndexOf(string value)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(LongString value)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(char value, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(string value, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(string value, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(LongString value, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(LongString value, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(char value, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(string value, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(string value, long startIndex, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(string value, long startIndex, long count, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(LongString value, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(LongString value, long startIndex, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long IndexOf(LongString value, long startIndex, long count, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long IndexOfAny(char[] anyOf)
        {

            throw new NotImplementedException();

        }

        public long IndexOfAny(char[] anyOf, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long IndexOfAny(char[] anyOf, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public LongString Insert(long startIndex, string value)
        {

            throw new NotImplementedException();

        }

        public LongString Insert(long startIndex, LongString value)
        {

            throw new NotImplementedException();

        }

        //public static string Intern(string str);

        //public static string IsInterned(string str);

        //public bool IsNormalized();

        //public bool IsNormalized(NormalizationForm normalizationForm);

        //public static bool IsNullOrEmpty(string value);

        //public static bool IsNullOrWhiteSpace(string value);

        //public static string Join(string separator, IEnumerable<string> values);

        //public static string Join<T>(string separator, IEnumerable<T> values);

        //public static string Join(string separator, params object[] values);

        //public static string Join(string separator, params string[] value);

        //public static string Join(string separator, string[] value, int startIndex, int count);

        public long LastIndexOf(string value)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(LongString value)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(char value, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(string value, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(string value, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(LongString value, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(LongString value, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(char value, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(string value, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(string value, long startIndex, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(string value, long startIndex, long count, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(LongString value, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(LongString value, long startIndex, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOf(LongString value, long startIndex, long count, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOfAny(char[] anyOf)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOfAny(char[] anyOf, long startIndex)
        {

            throw new NotImplementedException();

        }

        public long LastIndexOfAny(char[] anyOf, long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        //public string Normalize();

        //public string Normalize(NormalizationForm normalizationForm);

        public LongString PadLeft(long totalWidth)
        {

            throw new NotImplementedException();

        }

        public LongString PadLeft(long totalWidth, char paddingChar)
        {

            throw new NotImplementedException();

        }

        public LongString PadRight(long totalWidth)
        {

            throw new NotImplementedException();

        }

        public LongString PadRight(long totalWidth, char paddingChar)
        {

            throw new NotImplementedException();

        }

        public LongString Remove(long startIndex)
        {

            throw new NotImplementedException();

        }

        public LongString Remove(long startIndex, long count)
        {

            throw new NotImplementedException();

        }

        public LongString Replace(char oldChar, char newChar)
        {

            throw new NotImplementedException();

        }

        public LongString Replace(string oldValue, string newValue)
        {

            throw new NotImplementedException();

        }

        public LongString[] Split(params char[] separator)
        {

            throw new NotImplementedException();

        }

        public LongString[] Split(char[] separator, long count)
        {

            throw new NotImplementedException();

        }

        public LongString[] Split(char[] separator, StringSplitOptions options)
        {

            throw new NotImplementedException();

        }

        public LongString[] Split(string[] separator, StringSplitOptions options)
        {

            throw new NotImplementedException();

        }

        public LongString[] Split(char[] separator, long count, StringSplitOptions options)
        {

            throw new NotImplementedException();

        }

        public LongString[] Split(string[] separator, long count, StringSplitOptions options)
        {

            throw new NotImplementedException();

        }

        public string[] Divide()
        {

            if(myChars.LongLength > 0)
            {

                long IntMaxValue = int.MaxValue;

                if(myChars.LongLength > IntMaxValue)
                {

                    long NumberOfFullStrings = myChars.LongLength / IntMaxValue;

                    bool HasPartialString = myChars.LongLength % IntMaxValue > 0;

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

                            Chars[ArrayIndex] = myChars[Index];

                        }

                        Strings[i] = new string(Chars);

                    }

                    NextIndex += IntMaxValue;

                    if(HasPartialString)
                    {

                        Chars = new char[myChars.LongLength - NextIndex + 1];

                        for(long i = 0; i < myChars.LongLength; ++i)
                        {

                            Chars[i] = myChars[NextIndex];

                            ++NextIndex;

                        }

                        Strings[Strings.LongLength - 1] = new string(Chars);

                    }

                    return Strings;

                }

                return new string[] { new string(myChars) };

            }

            return new string[0];

        }

        //public string[] SplitInto(params char[] separator);

        ////public string[] SplitIntoParams(params char[] separator);

        //public string[] SplitInto(char[] separator, long count);

        //public string[] SplitInto(char[] separator, StringSplitOptions options);

        //public string[] SplitInto(string[] separator, StringSplitOptions options);

        //public string[] SplitInto(char[] separator, long count, StringSplitOptions options);

        //public string[] SplitInto(string[] separator, long count, StringSplitOptions options);

        public bool StartsWith(string value)
        {

            throw new NotImplementedException();

        }

        public bool StartsWith(string value, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
        {

            throw new NotImplementedException();

        }

        public bool StartsWith(LongString value)
        {

            throw new NotImplementedException();

        }

        public bool StartsWith(LongString value, StringComparison comparisonType)
        {

            throw new NotImplementedException();

        }

        public bool StartsWith(LongString value, bool ignoreCase, CultureInfo culture)
        {

            throw new NotImplementedException();

        }

        public LongString Substring(long startIndex)
        {

            throw new NotImplementedException();

        }

        public LongString Substring(long startIndex, long length)
        {

            throw new NotImplementedException();

        }

        public char[] ToArray()
        {

            return ArrayCopier<char>.Clone(myChars);

        }

        public char[] ToArray(long startIndex, long length)
        {

            if(startIndex > myChars.LongLength)
                throw new ArgumentOutOfRangeException();

            long FinalIndex = startIndex + length;

            long TheLastIndex = myChars.LongLength - 1;

            if(TheLastIndex < FinalIndex)
                length = TheLastIndex - startIndex;

            char[] Chars = new char[length];

            for(long i = 0; i < FinalIndex; ++i)
            {

                Chars[i] = myChars[startIndex];

                ++startIndex;

            }

            return Chars;

        }

        public LongString ToLower()
        {

            throw new NotImplementedException();

        }

        public LongString ToLower(CultureInfo culture)
        {

            throw new NotImplementedException();

        }

        public LongString ToLowerInvariant()
        {

            throw new NotImplementedException();

        }

        public override string ToString()
        {

            return new string(myChars);

        }

        public LongString ToLongString(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public LongString ToUpper()
        {

            throw new NotImplementedException();

        }

        public LongString ToUpper(CultureInfo culture)
        {

            throw new NotImplementedException();

        }

        public LongString ToUpperInvariant()
        {

            throw new NotImplementedException();

        }

        public LongString Trim()
        {

            throw new NotImplementedException();

        }

        public LongString Trim(params char[] trimChars)
        {

            throw new NotImplementedException();

        }

        public LongString Trim(IList<char> trimChars)
        {

            throw new NotImplementedException();

        }

        //public LongString TrimParams(params char[] trimChars);

        public LongString TrimEnd(params char[] trimChars)
        {

            throw new NotImplementedException();

        }

        public LongString TrimEnd(IList<char> trimChars)
        {

            throw new NotImplementedException();

        }

        //public LongString TrimEndParams(params char[] trimChars);

        public LongString TrimStart(params char[] trimChars)
        {

            throw new NotImplementedException();

        }

        public LongString TrimStart(IList<char> trimChars)
        {

            throw new NotImplementedException();

        }

        //public LongString TrimStartParams(params char[] trimChars);

        public IEnumerator<char> GetEnumerator()
        {

            return (IEnumerator<char>)myChars.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myChars.GetEnumerator();

        }

        public int CompareTo(object obj)
        {

            throw new NotImplementedException();

        }

        public int CompareTo(LongString other)
        {

            throw new NotImplementedException();

        }

        public TypeCode GetTypeCode()
        {

            throw new NotImplementedException();

        }

        public bool ToBoolean(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public byte ToByte(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public char ToChar(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public DateTime ToDateTime(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public decimal ToDecimal(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public double ToDouble(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public short ToInt16(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public sbyte ToSByte(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public float ToSingle(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public ushort ToUInt16(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public uint ToUInt32(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public ulong ToUInt64(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }
        
        public string ToString(IFormatProvider provider)
        {

            throw new NotImplementedException();

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

    }

}
