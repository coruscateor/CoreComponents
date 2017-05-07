using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    public struct DecCheck : IReset
    {

        int myCurrentCount;

        int mySetCount;

        public DecCheck(int count)
        {

            myCurrentCount = count;

            mySetCount = count;

        }

        public void Set(int count)
        {

            myCurrentCount = count;

            mySetCount = count;

        }

        public int CurrentCount
        {

            get
            {

                return myCurrentCount;

            }

        }

        public int SetCount
        {

            get
            {

                return mySetCount;

            }

        }

        public int GetDifference()
        {

            return mySetCount - myCurrentCount;

        }

        public bool IsDone
        {

            get
            {

                return myCurrentCount > 0;

            }

        }

        public void Reset()
        {

            myCurrentCount = mySetCount;

        }

        public void Stop()
        {

            myCurrentCount = -1;

            mySetCount = -1;

        }

        public bool Check()
        {

            myCurrentCount--;

            return myCurrentCount > 0;

        }

        public bool CheckReset()
        {

            myCurrentCount--;

            if(myCurrentCount < 1)
            {

                Set(mySetCount);

                return false;

            }

            return true;

        }

    }

}
