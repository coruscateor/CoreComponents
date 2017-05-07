using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public struct MuhTicks : IReset
    {

        const long intmax = int.MaxValue;

        int mySetAt;

        int myTicks;

        int myExpiresAt;

        bool myOverflows;

        public MuhTicks(int ticks)
        {

            var setAt = Environment.TickCount;

            mySetAt = setAt;

            myTicks = ticks;

            //over flow check

            int ticksFromMax = int.MaxValue - ticks;

            if(setAt > ticksFromMax)
            {

                myExpiresAt = ticks - setAt;

                myOverflows = true;

            }
            else
            {

                myExpiresAt = setAt + ticks;

                myOverflows = false;

            }

        }

        public void Set(int ticks)
        {

            var setAt = Environment.TickCount;

            mySetAt = setAt;

            myTicks = ticks;

            //over flow check

            int ticksFromMax = int.MaxValue - ticks;

            if(setAt > ticksFromMax)
            {

                myExpiresAt = ticks - setAt;

                myOverflows = true;

            }
            else
            {

                myExpiresAt = setAt + ticks;

                myOverflows = false;

            }

        }

        public int SetAt
        {

            get
            {

                return mySetAt;

            }

        }

        public int Ticks
        {

            get
            {

                return myTicks;

            }

        }

        public int ExpiresAt
        {

            get
            {

                return myExpiresAt;

            }

        }

        public bool Overflows
        {

            get
            {

                return myOverflows;

            }

        }

        public void Reset()
        {

            Set(myTicks);

        }

        public void Stop()
        {

            mySetAt = -1;

            myTicks = -1;

            myExpiresAt = -1;

            myOverflows = false;

        }

        public bool HasExpired()
        {

            return myExpiresAt >= Environment.TickCount;

        }

        public bool HasExpiredReset()
        {

            if(Environment.TickCount >= myExpiresAt)
            {

                Set(myTicks);

                return true;

            }

            return false;

        }

    }

}
