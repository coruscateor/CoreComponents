using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class VolatileBool
    {

        bool myValue;

        public VolatileBool()
        {
        }

        public VolatileBool(bool value)
        {

            myValue = value;

        }

        public bool Value
        {

            get
            {

                return Volatile.Read(ref myValue);

            }
            set
            {

                Volatile.Write(ref myValue, value);

            }

        }

        public void SetTrue()
        {

            Volatile.Write(ref myValue, true);

        }

        public void SetFalse()
        {

            Volatile.Write(ref myValue, false);

        }

        /// <summary>
        /// A bit dubious
        /// </summary>
        public void Invert()
        {

            Volatile.Write(ref myValue, !Volatile.Read(ref myValue));

        }

        public bool WaitFalse(int iterations = 10)
        {

            bool result = Volatile.Read(ref myValue);

            if(result)
            {

                SpinWait sw = new SpinWait();

                while(iterations > 0)
                {

                    result = Volatile.Read(ref myValue);

                    if(result)
                    {

                        sw.SpinOnce();

                    }
                    else
                        break;
                }

            }

            return result;

        }

        public bool WaitForFalse()
        {

            bool result = Volatile.Read(ref myValue);

            if(result)
            {

                SpinWait sw = new SpinWait();

                while(true)
                {

                    result = Volatile.Read(ref myValue);

                    if(result)
                    {

                        sw.SpinOnce();

                    }
                    else
                        break;

                }

            }

            return result;

        }

        public void WaitUntilFalse()
        {

            SpinWait.SpinUntil(() => !Volatile.Read(ref myValue));

        }

        public bool WaitUntilFalse(int millisecondsTimeout)
        {

            SpinWait.SpinUntil(() => !Volatile.Read(ref myValue), millisecondsTimeout);

            return !myValue;

        }

        public bool WaitUntilFalse(TimeSpan timeout)
        {

            SpinWait.SpinUntil(() => !Volatile.Read(ref myValue), timeout);

            return !myValue;

        }

        public bool WaitTrue(int iterations = 10)
        {

            bool result = Volatile.Read(ref myValue);

            if(!result)
            {

                SpinWait sw = new SpinWait();

                while(iterations > 0)
                {

                    result = Volatile.Read(ref myValue);

                    if(!result)
                    {

                        sw.SpinOnce();

                    }
                    else
                        break;
                }

            }

            return result;

        }

        public bool WaitForTrue()
        {

            bool result = Volatile.Read(ref myValue);

            if(!result)
            {

                SpinWait sw = new SpinWait();

                while(true)
                {

                    result = Volatile.Read(ref myValue);

                    if(!result)
                    {

                        sw.SpinOnce();

                    }
                    else
                        break;

                }

            }

            return result;

        }

        public void WaitUntilTrue()
        {

            SpinWait.SpinUntil(() => Volatile.Read(ref myValue));

        }

        public bool WaitUntilTrue(int millisecondsTimeout)
        {

            SpinWait.SpinUntil(() => Volatile.Read(ref myValue), millisecondsTimeout);

            return myValue;

        }

        public bool WaitUntilTrue(TimeSpan timeout)
        {

            SpinWait.SpinUntil(() => Volatile.Read(ref myValue), timeout);

            return myValue;

        }

        public static bool operator ==(VolatileBool left, VolatileBool right)
        {

            return left.Value == right.Value;

        }

        public static bool operator==(VolatileBool left, bool right)
        {

            return left.Value == right;

        }

        public static bool operator ==(bool left, VolatileBool right)
        {

            return left == right.Value;

        }

        public static bool operator !=(VolatileBool left, VolatileBool right)
        {

            return left.Value != right.Value;

        }

        public static bool operator !=(VolatileBool left, bool right)
        {

            return left.Value != right;

        }

        public static bool operator !=(bool left, VolatileBool right)
        {

            return left != right.Value;

        }

        public static bool operator !(VolatileBool thebool)
        {

            return !thebool.Value;

        }

        public static bool operator &(VolatileBool left, VolatileBool right)
        {

            return left.Value & right.Value;

        }

        public static bool operator &(bool left, VolatileBool right)
        {

            return left & right.Value;

        }

        public static bool operator &(VolatileBool left, bool right)
        {

            return left.Value & right;

        }

        public static bool operator |(VolatileBool left, VolatileBool right)
        {

            return left.Value | right.Value;

        }

        public static bool operator |(bool left, VolatileBool right)
        {

            return left | right.Value;

        }

        public static bool operator |(VolatileBool left, bool right)
        {

            return left.Value | right;

        }


        public static implicit operator VolatileBool(bool thebool)
        {

            return new VolatileBool(thebool);

        }

        public static implicit operator bool(VolatileBool thebool)
        {

            return thebool.Value;

        }

        public static bool operator true(VolatileBool thebool)
        {

            return thebool.Value;

        }

        public static bool operator false(VolatileBool thebool)
        {

            return thebool.Value;

        }

        public override bool Equals(object obj)
        {

            var wb = obj as VolatileBool;

            if(wb != null)
                return this == wb;

            return base.Equals(obj);

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

    }

}
