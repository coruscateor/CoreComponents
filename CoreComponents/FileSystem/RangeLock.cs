using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.FileSystem
{

    public class RangeLock
    {

        protected long myPosition;

        protected long myLength;

        public RangeLock()
        {
        }

        public RangeLock(long ThePosition, long TheLength)
        {

            myPosition = ThePosition;

            myLength = TheLength;

        }

        public long Position
        {

            get
            {

                return myPosition;

            }
            set
            {

                if(value < 0)
                    throw new ArgumentOutOfRangeException();

                myPosition = value;

            }

        }

        public long Length
        {

            get
            {

                return myLength;

            }
            set
            {

                if(value < 0)
                    throw new ArgumentOutOfRangeException();
                
                myLength = value;

            }

        }

        public void Advance()
        {

            myPosition = myPosition + myLength;

        }

        public bool Lock(Action<FileStream, long, long> TheAction, FileStream TheFileStream)
        {

            if(myPosition > TheFileStream.Length)
                return false;

            long TotalLength = myPosition + myLength;

            long CurrentLength;

            if(TotalLength > TheFileStream.Length)
                CurrentLength = TotalLength - myPosition;
            else
                CurrentLength = myLength;

            try
            {

                TheFileStream.Lock(myPosition, CurrentLength);

                TheAction(TheFileStream, myPosition, CurrentLength);

            }
            finally
            {

                TheFileStream.Unlock(myPosition, CurrentLength);

            }

            return true;

        }

    }

}
