using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents
{

    public struct Percent : IAppendTo
    {

        static readonly Percent myZero;

        static readonly Percent myOneHundred;

        static Percent()
        {

            myZero = new Percent(0);

            myOneHundred = new Percent(100);

        }

        uint myValue;

        public Percent(int TheValue)
        {

            myValue = (uint)TheValue;

        }

        public Percent(uint TheValue)
        {

            myValue = TheValue;

        }

        public static Percent Zero
        {

            get
            {

                return myZero;

            }

        }

        public static Percent OneHundred
        {

            get
            {

                return myOneHundred;

            }

        }

        public void Increment()
        {

            myValue++;

        }

        public bool IncrementTo100()
        {

            uint value = myValue;

            if(value < 100)
            {

                value++;

                myValue = value;

                return value >= 100;

            }

            return true;

        }

        public void Decrement()
        {

            myValue--;

        }

        public void IncrementUnchecked()
        {

            unchecked
            {

                myValue++;

            }

        }

        public void DecrementUnchecked()
        {

            unchecked
            {

                myValue--;

            }

        }

        public static Percent MaxValue
        {

            get
            {

                return new Percent(uint.MaxValue);

            }

        }

        public static Percent MinValue
        {

            get
            {

                return new Percent(uint.MinValue);

            }

        }

        //public static Percentage Get100Percent()
        //{

        //    return new Percentage(100);

        //}

        public static Percent GetMax100(int TheValue)
        {

            if(TheValue <= 100)
            {

                return new Percent(TheValue);

            }
            else if(TheValue < 0)
            {

                return new Percent();

            }

            return myOneHundred;

        }

        public static Percent GetMax100(uint TheValue)
        {

            if(TheValue <= 100)
            {

                return new Percent(TheValue);

            }

            return myOneHundred;

        }

        public uint GetRaw()
        {

            return myValue;

        }

        public bool IsZero
        {

            get
            {

                return this == myZero;

            }

        }

        public bool IsOneHundred
        {

            get
            {

                return this == myOneHundred;

            }

        }

        public static Percent Parse(string TheValue)
        {

            char TheLastChar = TheValue[TheValue.Length];

            if(TheLastChar != '%')
                throw new Exception("Percentage sign not present in the provided value");

            int LastIndexBeforePercent = TheValue.Length - 2;

            if(LastIndexBeforePercent < 0)
                throw new Exception("Numeric value not provided");

            StringBuilder SB = new StringBuilder();

            SB.Append(TheValue);

            //Remove percentage

            SB.Remove(TheValue.Length - 2, 1);

            return new Percent(uint.Parse(SB.ToString()));

        }

        public static Percent operator +(Percent TheLeft, Percent TheRight)
        {

            return new Percent(TheLeft.GetRaw() + TheRight.GetRaw());

        }

        public static Percent operator -(Percent TheLeft, Percent TheRight)
        {

            return new Percent(TheLeft.GetRaw() - TheRight.GetRaw());

        }

        public static Percent operator ++(Percent TheValue)
        {

            uint RawValue = TheValue.GetRaw();

            RawValue++;

            return new Percent(RawValue);

        }

        public static Percent operator --(Percent TheValue)
        {

            uint RawValue = TheValue.GetRaw();

            RawValue--;

            return new Percent(RawValue);

        }

        public static bool operator ==(Percent TheLeft, Percent TheRight)
        {

            return TheLeft.GetRaw() == TheRight.GetRaw();

        }

        public static bool operator !=(Percent TheLeft, Percent TheRight)
        {

            return TheLeft.GetRaw() != TheRight.GetRaw();

        }

        public static bool operator >(Percent TheLeft, Percent TheRight)
        {

            return TheLeft.GetRaw() > TheRight.GetRaw();

        }

        public static bool operator <(Percent TheLeft, Percent TheRight)
        {

            return TheLeft.GetRaw() < TheRight.GetRaw();

        }

        public override bool Equals(object obj)
        {

            if(obj is Percent)
                return ((Percent)obj) == this;

            return base.Equals(obj);

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

        public override string ToString()
        {

            return myValue.ToString() + '%';

        }

        public void AppendTo(StringBuilder TheSB)
        {

            TheSB.Append(myValue.ToString()).Append('%');

        }

        public void AppendToSpace(StringBuilder TheSB)
        {

            TheSB.Append(myValue.ToString()).Append(' ').Append('%');

        }

        public void AppendToTab(StringBuilder TheSB)
        {

            TheSB.Append(myValue.ToString()).Append('\t').Append('%');

        }

    }

}
