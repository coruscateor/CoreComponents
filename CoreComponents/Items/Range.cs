using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public struct Range : IEnumerable<int>
    {

        readonly int myStart;

        readonly int myEnd;

        //public Range()
        //    : this(0, 0)
        //{
        //}

        //public Range(int end)
        //    : this(0, end)
        //{
        //}

        public Range(int start, int end)
        {

            if(end > start)
            {

                myStart = end;

                myEnd = start;

            }
            else
            {

                myStart = start;

                myEnd = end;

            }

        }

        public int Start
        {

            get
            {

                return myStart;

            }

        }

        public int End
        {

            get
            {

                return myEnd;

            }

        }

        public int Length
        {

            get
            {

                return myStart - myEnd;

            }

        }

        public int ExclusiveLength
        {

            get
            {

                return myStart + 1 - myEnd - 1;

            }

        }

        public bool IsWithin(int value)
        {

            return myStart < value && myEnd > value;

        }

        public bool IsExclusiveWithin(int value)
        {

            return myStart + 1 < value && myEnd - 1 > value;

        }

        public IEnumerator<int> GetEnumerator()
        {

            for(int i = myStart; i < myEnd; i++)
                yield return i;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

    }

}
