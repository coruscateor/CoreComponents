using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents
{

    public struct Percentage
    {

        uint myValue;

        public Percentage(int TheValue)
        {

            myValue = (uint)TheValue;

        }

        public Percentage(uint TheValue)
        {

            myValue = TheValue;

        }

        public void Increment()
        {

            myValue++;

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

        public static Percentage MaxValue
        {

            get
            {

                return new Percentage(uint.MaxValue);

            }

        }

        public static Percentage MinValue
        {

            get
            {

                return new Percentage(uint.MinValue);

            }

        }

        public static Percentage Get100Percent()
        {

            return new Percentage(100);

        }

        public static Percentage GetMax100(int TheValue)
        {

            if(TheValue <= 100)
            {

                return new Percentage(TheValue);

            }
            else if(TheValue < 0)
            {

                return new Percentage();

            }

            return Get100Percent();

        }

        public static Percentage GetMax100(uint TheValue)
        {

            if(TheValue <= 100)
            {

                return new Percentage(TheValue);

            }

            return Get100Percent();

        }

        public uint GetRaw()
        {

            return myValue;

        }

        public static Percentage Parse(string TheValue)
        {

            char TheLastChar = TheValue[TheValue.Length];

            if(TheLastChar != '%')
                throw new Exception("Percentage sign not present in the provided value");

            int LastIndexBeforePercent = TheValue.Length - 2;

            if(LastIndexBeforePercent < 0)
                throw new Exception("Numeric value not provided");

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            SB.Append(TheValue);

            //Remove percentage

            SB.Remove(TheValue.Length - 2, 1);

            try
            {

                return new Percentage(uint.Parse(SB.ToString()));

            }
            finally
            {

                StringBuilderPool.Put(SB);

            }

        }

        public static Percentage operator +(Percentage TheLeft, Percentage TheRight)
        {

            return new Percentage(TheLeft.GetRaw() + TheRight.GetRaw());

        }

        public static Percentage operator -(Percentage TheLeft, Percentage TheRight)
        {

            return new Percentage(TheLeft.GetRaw() - TheRight.GetRaw());

        }

        public static Percentage operator ++(Percentage TheValue)
        {

            uint RawValue = TheValue.GetRaw();

            RawValue++;

            return new Percentage(RawValue);

        }

        public static Percentage operator --(Percentage TheValue)
        {

            uint RawValue = TheValue.GetRaw();

            RawValue--;

            return new Percentage(RawValue);

        }

        public static bool operator ==(Percentage TheLeft, Percentage TheRight)
        {

            return TheLeft.GetRaw() == TheRight.GetRaw();

        }

        public static bool operator !=(Percentage TheLeft, Percentage TheRight)
        {

            return TheLeft.GetRaw() != TheRight.GetRaw();

        }

        public static bool operator >(Percentage TheLeft, Percentage TheRight)
        {

            return TheLeft.GetRaw() > TheRight.GetRaw();

        }

        public static bool operator <(Percentage TheLeft, Percentage TheRight)
        {

            return TheLeft.GetRaw() < TheRight.GetRaw();

        }

        public override bool Equals(object obj)
        {

            if(obj is Percentage)
                return ((Percentage)obj) == this;

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

    }

}
