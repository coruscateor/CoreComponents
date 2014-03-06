using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public struct Octet : ICloneable<Octet>, IToArray<bool>, IAppendToStringBuilder, IEnumerable<bool>
    {
        
        bool myFirstBit;

        bool mySecondBit;

        bool myThirdBit;

        bool myFourthBit;

        bool myFifthBit;

        bool mySixthBit;

        bool mySeventhBit;

        bool myEigthBit;

        public Octet(byte Value)
        {

            myFirstBit = false;

            mySecondBit = false;

            myThirdBit = false;

            myFourthBit = false;

            myFifthBit = false;

            mySixthBit = false;

            mySeventhBit = false;

            myEigthBit = false;

            Set(Value);

        }

        public Octet(bool TheFirstBit = false, bool TheSecondBit = false, bool TheThirdBit = false, bool TheFourthBit = false, bool TheFifthBit = false, bool TheSixthBit = false, bool TheSeventhBit = false, bool TheEigthBit = false)
        {

            myFirstBit = false;

            mySecondBit = false;

            myThirdBit = false;

            myFourthBit = false;

            myFifthBit = false;

            mySixthBit = false;

            mySeventhBit = false;

            myEigthBit = false;

            SetBits(TheFirstBit, TheSecondBit, TheThirdBit, TheFourthBit, TheFifthBit, TheSixthBit, TheSeventhBit, TheEigthBit);

        }

        public Octet(string Value)
        {

            myFirstBit = false;

            mySecondBit = false;

            myThirdBit = false;

            myFourthBit = false;

            myFifthBit = false;

            mySixthBit = false;

            mySeventhBit = false;

            myEigthBit = false;

            Set(Value);

        }

        public Octet(OctetActivation OA)
        {

            myFirstBit = false;

            mySecondBit = false;

            myThirdBit = false;

            myFourthBit = false;

            myFifthBit = false;

            mySixthBit = false;

            mySeventhBit = false;

            myEigthBit = false;

            if(OA == OctetActivation.All)
                AllOn();

        }

        public Octet(Octet TheOctet)
        {

            myFirstBit = false;

            mySecondBit = false;

            myThirdBit = false;

            myFourthBit = false;

            myFifthBit = false;

            mySixthBit = false;

            mySeventhBit = false;

            myEigthBit = false;

            Set(TheOctet);

        }

        public bool FirstBit
        {

            get
            {

                return myFirstBit;

            }
            set
            {

                myFirstBit = value;

            }

        }

        public bool SecondBit
        {

            get
            {

                return mySecondBit;

            }
            set
            {

                mySecondBit = value;

            }

        }

        public bool ThirdBit
        {

            get
            {

                return myThirdBit;

            }
            set
            {

                myThirdBit = value;

            }

        }

        public bool FourthBit
        {

            get
            {

                return myFourthBit;

            }
            set
            {

                myFourthBit = value;

            }

        }

        public bool FifthBit
        {

            get
            {

                return myFifthBit;

            }
            set
            {

                FifthBit = value;

            }

        }

        public bool SixthBit
        {

            get
            {

                return mySixthBit;

            }
            set
            {

                mySixthBit = value;

            }

        }

        public bool SeventhBit
        {

            get
            {

                return mySeventhBit;

            }
            set
            {

                mySeventhBit = value;

            }

        }

        public bool EigthBit
        {

            get
            {

                return myEigthBit;

            }
            set
            {

                myEigthBit = value;

            }

        }

        public void FlipFirstBit()
        {

            myFirstBit = !myFirstBit;

        }

        public void FlipSecondBit()
        {

            mySecondBit = !mySecondBit;

        }

        public void FlipThirdBit()
        {

            myThirdBit = !myThirdBit;

        }

        public void FlipFourthBit()
        {

            myFourthBit = !myFourthBit;

        }

        public void FlipFifthBit()
        {

            myFifthBit = !myFifthBit;

        }

        public void FlipSixthBit()
        {

            mySixthBit = !mySixthBit;

        }

        public void FlipSeventhBit()
        {

            mySeventhBit = !mySeventhBit;

        }

        public void FlipEigthBit()
        {

            myEigthBit = !myEigthBit;

        }

        public void Flip(byte Index)
        {

            switch(Index)
            {

                case 1:

                    myFirstBit = !myFirstBit;

                    break;

                case 2:

                    mySecondBit = !mySecondBit;

                    break;

                case 3:

                    myThirdBit = !myThirdBit;

                    break;

                case 4:

                    myFourthBit = !myFourthBit;

                    break;

                case 5:

                    myFifthBit = !myFifthBit;

                    break;

                case 6:

                    mySixthBit = !mySixthBit;

                    break;

                case 7:

                    mySeventhBit = !mySeventhBit;

                    break;

                case 8:

                    myEigthBit = !myEigthBit;

                    break;

            }

        }

        public void SetBits(bool TheFirstBit = false, bool TheSecondBit = false, bool TheThirdBit = false, bool TheFourthBit = false, bool TheFifthBit = false, bool TheSixthBit = false, bool TheSeventhBit = false, bool TheEigthBit = false)
        {

            myFirstBit = TheFirstBit;

            mySecondBit = TheSecondBit;

            myThirdBit = TheThirdBit;

            myFourthBit = TheFourthBit;

            myFifthBit = TheFifthBit;

            mySixthBit = TheSixthBit;

            mySeventhBit = TheSeventhBit;

            myEigthBit = TheEigthBit;

        }

        public void GetBits(out bool TheFirstBit, out bool TheSecondBit, out bool TheThirdBit, out bool TheFourthBit, out bool TheFifthBit, out bool TheSixthBit, out bool TheSeventhBit, out bool TheEigthBit)
        {

            TheFirstBit = myFirstBit;

            TheSecondBit = mySecondBit;

            TheThirdBit = myThirdBit;

            TheFourthBit = myFourthBit;

            TheFifthBit = myFifthBit;

            TheSixthBit = mySixthBit;

            TheSeventhBit = mySeventhBit;

            TheEigthBit = myEigthBit;

        }

        public bool this[byte Index]
        {

            get
            {

                switch(Index)
                {

                    case 1:

                        return myFirstBit;

                    case 2:

                        return mySecondBit;

                    case 3:

                        return myThirdBit;

                    case 4:

                        return myFourthBit;

                    case 5:

                        return myFifthBit;

                    case 6:

                        return mySixthBit;

                    case 7:

                        return mySeventhBit;

                    case 8:

                        return myEigthBit;

                }

                throw new IndexOutOfRangeException();

            }
            set
            {

                switch(Index)
                {

                    case 1:

                        myFirstBit = value;

                        return;

                    case 2:

                        mySecondBit = value;

                        return;

                    case 3:

                        myThirdBit = value;

                        return;

                    case 4:

                        myFourthBit = value;

                        return;

                    case 5:

                        myFifthBit = value;

                        return;

                    case 6:

                        mySixthBit = value;

                        return;

                    case 7:

                        mySeventhBit = value;

                        return;

                    case 8:

                        myEigthBit = value;

                        return;

                }

                throw new IndexOutOfRangeException();

            }

        }

        public byte ToByte()
        {

            byte NewByte = 0;

            if(myFirstBit)
                ++NewByte;

            if(mySecondBit)
                NewByte += 2;

            if(myThirdBit)
                NewByte += 4;

            if(myFourthBit)
                NewByte += 8;

            if(myFifthBit)
                NewByte += 16;

            if(mySixthBit)
                NewByte += 32;

            if(mySeventhBit)
                NewByte += 64;

            if(myEigthBit)
                NewByte += 128;

            return NewByte;

        }

        public void Set(byte Value)
        {

            if(Value > 0)
            {

                if(Value >= 128)
                {

                    Value -= 128;

                    myEigthBit = true;

                }

                if(Value >= 64)
                {

                    Value -= 64;

                    mySeventhBit = true;

                }

                if(Value >= 32)
                {

                    Value -= 32;

                    mySixthBit = true;

                }

                if(Value >= 16)
                {

                    Value -= 16;

                    myFifthBit = true;

                }

                if(Value >= 8)
                {

                    Value -= 8;

                    myFourthBit = true;

                }

                if(Value >= 4)
                {

                    Value -= 4;

                    myThirdBit = true;

                }

                if(Value >= 2)
                {

                    Value -= 2;

                    mySecondBit = true;

                }

                if(Value >= 1)
                {

                    --Value;

                    myFirstBit = true;

                }

            }
            else
            {

                AllOff();

            }

        }

        public void Set(string Value)
        {

            if(Value != null && Value.Length > 0)
            {

                if(Value.Length >= 1)
                {

                    switch(Value[0])
                    {
 
                        case '1':

                            myFirstBit = true;

                            break;

                        case '0':

                            myFirstBit = false;

                            break;

                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 2)
                {

                    switch(Value[1])
                    {

                        case '1':

                            mySecondBit = true;

                            break;

                        case '0':

                            mySecondBit = false;

                            break;

                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 3)
                {

                    switch(Value[2])
                    {

                        case '1':

                            myThirdBit = true;

                            break;

                        case '0':

                            myThirdBit = false;

                            break;

                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 4)
                {

                    switch(Value[3])
                    {

                        case '1':

                            myFourthBit = true;

                            break;

                        case '0':

                            myFourthBit = false;

                            break;
                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 5)
                {

                    switch(Value[4])
                    {

                        case '1':

                            myFifthBit = true;

                            break;

                        case '0':

                            myFifthBit = false;

                            break;
                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 6)
                {

                    switch(Value[5])
                    {

                        case '1':

                            mySixthBit = true;

                            break;

                        case '0':

                            mySixthBit = false;

                            break;
                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 7)
                {

                    switch(Value[6])
                    {

                        case '1':

                            mySeventhBit = true;

                            break;

                        case '0':

                            mySeventhBit = false;

                            break;
                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

                if(Value.Length >= 8)
                {

                    switch(Value[7])
                    {

                        case '1':

                            myEigthBit = true;

                            break;

                        case '0':

                            myEigthBit = false;

                            break;
                        default:

                            throw new Exception("Character values must only be either be 1 or 0");

                    }

                }

            }

        }

        public void Set(Octet Value)
        {

            myFirstBit = Value.FirstBit;

            mySecondBit = Value.SecondBit;

            myThirdBit = Value.ThirdBit;

            myFourthBit = Value.FourthBit;

            myFifthBit = Value.FifthBit;

            mySixthBit = Value.SixthBit;

            mySeventhBit = Value.SeventhBit;

            myEigthBit = Value.EigthBit;

        }

        public void SetInverseOf(Octet Value)
        {

            myFirstBit = !Value.FirstBit;

            mySecondBit = !Value.SecondBit;

            myThirdBit = !Value.ThirdBit;

            myFourthBit = !Value.FourthBit;

            myFifthBit = !Value.FifthBit;

            mySixthBit = !Value.SixthBit;

            mySeventhBit = !Value.SeventhBit;

            myEigthBit = !Value.EigthBit;

        }

        public void AllOn()
        {

            myFirstBit = true;

            mySecondBit = true;

            myThirdBit = true;

            myFourthBit = true;

            myFifthBit = true;

            mySixthBit = true;

            mySeventhBit = true;

            myEigthBit = true;

        }

        public void AllOff()
        {

            myFirstBit = false;

            mySecondBit = false;

            myThirdBit = false;

            myFourthBit = false;

            myFifthBit = false;

            mySixthBit = false;

            mySeventhBit = false;

            myEigthBit = false;

        }

        public void FlipAll()
        {

            myFirstBit = !myFirstBit;

            mySecondBit = !mySecondBit;

            myThirdBit = !myThirdBit;

            myFourthBit = !myFourthBit;

            myFifthBit = !myFifthBit;

            mySixthBit = !mySixthBit;

            mySeventhBit = !mySeventhBit;

            myEigthBit = !myEigthBit;

        }

        public static Octet operator ~(Octet TheOctet)
        {

            return TheOctet.GetInverse();

        }

        public static implicit operator byte(Octet TheOctet)
        {

            return TheOctet.ToByte();

        }

        public static implicit operator sbyte(Octet TheOctet)
        {

            return (sbyte)TheOctet.ToByte();

        }

        public static implicit operator short(Octet TheOctet)
        {

            return (short)TheOctet.ToByte();

        }

        public static implicit operator ushort(Octet TheOctet)
        {

            return (ushort)TheOctet.ToByte();

        }

        public static implicit operator int(Octet TheOctet)
        {

            return (int)TheOctet.ToByte();

        }

        public static implicit operator uint(Octet TheOctet)
        {

            return (uint)TheOctet.ToByte();

        }

        public static implicit operator long(Octet TheOctet)
        {

            return (long)TheOctet.ToByte();

        }

        public static implicit operator ulong(Octet TheOctet)
        {

            return (ulong)TheOctet.ToByte();

        }

        public static implicit operator float(Octet TheOctet)
        {

            return (float)TheOctet.ToByte();

        }

        public static implicit operator double(Octet TheOctet)
        {

            return (double)TheOctet.ToByte();

        }

        public static implicit operator decimal(Octet TheOctet)
        {

            return (decimal)TheOctet.ToByte();

        }

        public static Octet operator &(Octet Left, Octet Right)
        {

            return Left.GetLogicalAND(Right);

        }

        public static Octet operator ^(Octet Left, Octet Right)
        {

            return Left.GetLogicalXOR(Right);

        }

        public static Octet operator |(Octet Left, Octet Right)
        {

            return Left.GetLogicalOR(Right);

        }

        public static Octet operator >>(Octet TheOctet, int TheAmmount)
        {

            return TheOctet.GetRightShift(TheAmmount);

        }

        public static Octet operator <<(Octet TheOctet, int TheAmmount)
        {

            return TheOctet.GetLeftShift(TheAmmount);

        }

        public Octet GetLeftShift(int TheAmmount)
        {

            if(TheAmmount < 0)
                throw new Exception("Value must be above -1");

            Octet Result = new Octet();

            switch(TheAmmount)
            {
 
                case 1:

                    Result.FirstBit = mySecondBit;

                    Result.SecondBit = myThirdBit;

                    Result.ThirdBit = myFourthBit;

                    Result.FourthBit = myFifthBit;

                    Result.FifthBit = mySixthBit;

                    Result.SixthBit = mySeventhBit;

                    Result.SeventhBit = myEigthBit;

                    break;

                case 2:

                    Result.FirstBit = myThirdBit;

                    Result.SecondBit = myFourthBit;

                    Result.ThirdBit = myFifthBit;

                    Result.FourthBit = mySixthBit;

                    Result.FifthBit = mySeventhBit;

                    Result.SixthBit = myEigthBit;

                    break;

                case 3:

                    Result.FirstBit = myFourthBit;

                    Result.SecondBit = myFifthBit;

                    Result.ThirdBit = mySixthBit;

                    Result.FourthBit = mySeventhBit;

                    Result.FifthBit = myEigthBit;

                    break;

                case 4:

                    Result.FirstBit = myFifthBit;

                    Result.SecondBit = mySixthBit;

                    Result.ThirdBit = mySeventhBit;

                    Result.FourthBit = myEigthBit;

                    break;

                case 5:

                    Result.FirstBit = mySixthBit;

                    Result.SecondBit = mySeventhBit;

                    Result.ThirdBit = myEigthBit;

                    break;

                case 6:

                    Result.FirstBit = mySeventhBit;

                    Result.SecondBit = myEigthBit;

                    break;

                case 7:

                    Result.FirstBit = myEigthBit;

                    break;

            }

            return Result;

        }

        public Octet GetRightShift(int TheAmmount)
        {

            if(TheAmmount < 0)
                throw new Exception("Value must be above -1");

            Octet Result = new Octet();

            switch(TheAmmount)
            {

                case 1:

                    Result.EigthBit = mySeventhBit;

                    Result.SeventhBit = mySixthBit;

                    Result.SixthBit = myFifthBit;

                    Result.FifthBit = myFourthBit;

                    Result.FourthBit = myThirdBit;

                    Result.ThirdBit = mySecondBit;

                    Result.SecondBit = myFirstBit;

                    break;

                case 2:

                    Result.EigthBit = mySixthBit;

                    Result.SeventhBit = myFifthBit;

                    Result.SixthBit = myFourthBit;

                    Result.FifthBit = myThirdBit;

                    Result.FourthBit = mySecondBit;

                    Result.ThirdBit = myFirstBit;

                    break;

                case 3:

                    Result.EigthBit = myFifthBit;

                    Result.SeventhBit = myFourthBit;

                    Result.SixthBit = myThirdBit;

                    Result.FifthBit = mySecondBit;

                    Result.FourthBit = myFirstBit;

                    break;

                case 4:

                    Result.EigthBit = myFourthBit;

                    Result.SeventhBit = myThirdBit;

                    Result.SixthBit = mySecondBit;

                    Result.FifthBit = myFirstBit;

                    break;

                case 5:

                    Result.EigthBit = myThirdBit;

                    Result.SeventhBit = mySecondBit;

                    Result.SixthBit = myFirstBit;

                    break;
                case 6:

                    Result.EigthBit = mySecondBit;

                    Result.SeventhBit = myFirstBit;

                    break;

                case 7:

                    Result.EigthBit = myFirstBit;

                    break;

            }

            return Result;

        }

        public Octet GetLogicalAND(Octet TheOctet)
        {

            Octet Result = new Octet();

            Result.FirstBit = myFirstBit & TheOctet.FirstBit;

            Result.SecondBit = mySecondBit & TheOctet.SecondBit;

            Result.ThirdBit = myThirdBit & TheOctet.ThirdBit;

            Result.FourthBit = myFourthBit & TheOctet.FourthBit;

            Result.FifthBit = myFifthBit & TheOctet.FifthBit;

            Result.SixthBit = mySixthBit & TheOctet.SixthBit;

            Result.SeventhBit = mySeventhBit & TheOctet.SeventhBit;

            Result.EigthBit = myEigthBit & TheOctet.EigthBit;

            return Result;

        }

        public Octet GetLogicalXOR(Octet TheOctet)
        {

            Octet Result = new Octet();

            Result.FirstBit = myFirstBit ^ TheOctet.FirstBit;

            Result.SecondBit = mySecondBit ^ TheOctet.SecondBit;

            Result.ThirdBit = myThirdBit ^ TheOctet.ThirdBit;

            Result.FourthBit = myFourthBit ^ TheOctet.FourthBit;

            Result.FifthBit = myFifthBit ^ TheOctet.FifthBit;

            Result.SixthBit = mySixthBit ^ TheOctet.SixthBit;

            Result.SeventhBit = mySeventhBit ^ TheOctet.SeventhBit;

            Result.EigthBit = myEigthBit ^ TheOctet.EigthBit;

            return Result;

        }

        public Octet GetLogicalOR(Octet TheOctet)
        {

            Octet Result = new Octet();

            Result.FirstBit = myFirstBit | TheOctet.FirstBit;

            Result.SecondBit = mySecondBit | TheOctet.SecondBit;

            Result.ThirdBit = myThirdBit | TheOctet.ThirdBit;

            Result.FourthBit = myFourthBit | TheOctet.FourthBit;

            Result.FifthBit = myFifthBit | TheOctet.FifthBit;

            Result.SixthBit = mySixthBit | TheOctet.SixthBit;

            Result.SeventhBit = mySeventhBit | TheOctet.SeventhBit;

            Result.EigthBit = myEigthBit | TheOctet.EigthBit;

            return Result;

        }

        public void LogicalAND(Octet TheOctet)
        {

            myFirstBit = myFirstBit & TheOctet.FirstBit;

            mySecondBit = mySecondBit & TheOctet.SecondBit;

            myThirdBit = myThirdBit & TheOctet.ThirdBit;

            myFourthBit = myFourthBit & TheOctet.FourthBit;

            myFifthBit = myFifthBit & TheOctet.FifthBit;

            mySixthBit = mySixthBit & TheOctet.SixthBit;

            mySeventhBit = mySeventhBit & TheOctet.SeventhBit;

            myEigthBit = myEigthBit & TheOctet.EigthBit;

        }

        public void LogicalXOR(Octet TheOctet)
        {

            myFirstBit = myFirstBit ^ TheOctet.FirstBit;

            mySecondBit = mySecondBit ^ TheOctet.SecondBit;

            myThirdBit = myThirdBit ^ TheOctet.ThirdBit;

            myFourthBit = myFourthBit ^ TheOctet.FourthBit;

            myFifthBit = myFifthBit ^ TheOctet.FifthBit;

            mySixthBit = mySixthBit ^ TheOctet.SixthBit;

            mySeventhBit = mySeventhBit ^ TheOctet.SeventhBit;

            myEigthBit = myEigthBit ^ TheOctet.EigthBit;

        }

        public void LogicalOR(Octet TheOctet)
        {

            myFirstBit = myFirstBit | TheOctet.FirstBit;

            mySecondBit = mySecondBit | TheOctet.SecondBit;

            myThirdBit = myThirdBit | TheOctet.ThirdBit;

            myFourthBit = myFourthBit | TheOctet.FourthBit;

            myFifthBit = myFifthBit | TheOctet.FifthBit;

            mySixthBit = mySixthBit | TheOctet.SixthBit;

            mySeventhBit = mySeventhBit | TheOctet.SeventhBit;

            myEigthBit = myEigthBit | TheOctet.EigthBit;

        }

        public Octet GetInverse()
        {

            return new Octet(!myFirstBit, !mySecondBit, !myThirdBit, !myFourthBit, !myFifthBit, !mySixthBit, !mySeventhBit, !myEigthBit);

        }

        public Octet Clone()
        {

            return new Octet(myFirstBit, mySecondBit, myThirdBit, myFourthBit, myFifthBit, mySixthBit, mySeventhBit, myEigthBit);

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

        public void AppendTo(StringBuilder TheSB)
        {

            if(myFirstBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(mySecondBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(myThirdBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(myFourthBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(myFifthBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(mySixthBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(mySeventhBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

            if(myEigthBit)
                TheSB.Append('1');
            else
                TheSB.Append('0');

        }

        public bool[] ToArray()
        {

            bool[] Bits = new bool[8];

            Bits[0] = myFirstBit;

            Bits[1] = mySecondBit;

            Bits[2] = myThirdBit;

            Bits[3] = myFourthBit;

            Bits[4] = myFifthBit;

            Bits[5] = mySixthBit;

            Bits[6] = mySeventhBit;

            Bits[7] = myEigthBit;

            return Bits;

        }

        public override string ToString()
        {

            char[] BitChars = new char[8];

            if(myFirstBit)
                BitChars[0] = '1';
            else
                BitChars[0] = '0';

            if(mySecondBit)
                BitChars[1] = '1';
            else
                BitChars[1] = '0';

            if(myThirdBit)
                BitChars[2] = '1';
            else
                BitChars[2] = '0';

            if(myFourthBit)
                BitChars[3] = '1';
            else
                BitChars[3] = '0';

            if(myFifthBit)
                BitChars[4] = '1';
            else
                BitChars[4] = '0';

            if(mySixthBit)
                BitChars[5] = '1';
            else
                BitChars[5] = '0';

            if(mySeventhBit)
                BitChars[6] = '1';
            else
                BitChars[6] = '0';

            if(myEigthBit)
                BitChars[7] = '1';
            else
                BitChars[7] = '0';

            return new string(BitChars);

        }

        public IEnumerator<bool> GetEnumerator()
        {

            for(byte i = 0; i < 8; ++i)
            {

                yield return this[i];

            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

    }

    public enum OctetActivation
    {
 
        All,
        None

    }

}
