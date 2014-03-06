using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.Text
{

    public class ByteReader
    {

        //BaseTokeniser

        protected long myChunkLength = 500;

        protected Action<byte[]> myBytesRead;

        public ByteReader()
        {
        }

        public void Read(StreamReader TheStreamReader, Action<byte[]> TheBytesRead)
        {

            Read(TheStreamReader.BaseStream, TheBytesRead);

        }

        public void Read(Stream TheStream, Action<byte[]> TheBytesRead)
        {
            
            byte[] ByteBuffer;

            long Remainder = TheStream.Length - TheStream.Position;

            if (myChunkLength > Remainder)
            {

                ByteBuffer = new byte[Remainder];

            }
            else
            {

                ByteBuffer = new byte[myChunkLength];

            }

            while (TheStream.Position < TheStream.Length)
            {

                TheStream.Read(ByteBuffer, 0, ByteBuffer.Length - 1);

                Remainder = TheStream.Length - TheStream.Position;

                TheBytesRead(CopyToLimit<byte>(ByteBuffer, Remainder));

            }

        }

        public void TimedRead(Stream TheStream, Action<byte[]> TheBytesRead, int TheWaitTime)
        {

            Read(TheStream, (byte[] TheBytes) => { TheBytesRead(TheBytes); System.Threading.Thread.Sleep(TheWaitTime); }); 

        }

        public void TimedRead(StreamReader TheStreamReader, Action<byte[]> TheBytesRead, int TheWaitTime)
        {

            TimedRead(TheStreamReader.BaseStream, TheBytesRead, TheWaitTime);

        }

        public void ReadAndClose(FileStream TheFileStream, Action<byte[]> TheBytesRead, Action StreamClosed)
        {

            try
            {

                Read(TheFileStream, TheBytesRead);

            }
            finally
            {

                TheFileStream.Close();

                StreamClosed();

            }

        }

        public void TimedReadAndClose(FileStream TheFileStream, Action<byte[]> TheBytesRead, Action StreamClosed, int TheWaitTime)
        {

            try
            {

                TimedRead(TheFileStream, TheBytesRead, TheWaitTime);

            }
            finally
            {

                TheFileStream.Close();

                StreamClosed();

            }

        }

        public void ReadFile(string ThePath, Action<byte[]> TheBytesRead, Action StreamClosed)
        {

            ReadAndClose(File.OpenRead(ThePath), TheBytesRead, StreamClosed);

        }

        public void ReadFile(FileInfo TheFile, Action<byte[]> TheBytesRead, Action StreamClosed)
        {

            ReadAndClose(TheFile.OpenRead(), TheBytesRead, StreamClosed);

        }

        public void TimedReadFile(string ThePath, Action<byte[]> TheBytesRead, Action StreamClosed, int TheWaitTime)
        {

            TimedReadAndClose(File.OpenRead(ThePath), TheBytesRead, StreamClosed, TheWaitTime);

        }

        public void TimedReadFile(FileInfo TheFile, Action<byte[]> TheBytesRead, Action StreamClosed, int TheWaitTime)
        {

            TimedReadAndClose(TheFile.OpenRead(), TheBytesRead, StreamClosed, TheWaitTime);

        }

        public T[] CopyToLimit<T>(T[] TheArray, long TheUpperBound)
        {

            T[] ArrayCopy = new T[TheUpperBound];

            for (long Index = 0; Index < TheUpperBound; Index++)
            {

                ArrayCopy[Index] = TheArray[Index];

            }

            return ArrayCopy;

        }

        public long ChunkLength
        {

            get
            {

                return myChunkLength;

            }
            set
            {

                myChunkLength = value;

            }

        }

    }

}
