using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.Streaming
{

    public class StreamList : IList<Stream>
    {

        protected List<Stream> myStreamList = new List<Stream>();

        protected bool myCloseAtEnd = true;

        public StreamList()
        {
        }

        public void Broadcast(Stream TheSteam)
        {

            CheckReadStream(TheSteam);

            int TheByte = TheSteam.ReadByte();

            while(TheByte > -1)
            {

                for(int i = 0; i < myStreamList.Count; ++i)
                {

                    Stream CurrentStream = myStreamList[i];

                    if(CurrentStream.CanWrite)
                    {

                        try
                        {

                            CurrentStream.WriteByte((byte)TheByte);

                        }
                        catch
                        {

                            myStreamList.Remove(CurrentStream);

                        }

                    }
                    else
                    {

                        myStreamList.Remove(CurrentStream);

                    }

                }

                TheByte = TheSteam.ReadByte();

            }

            if(myCloseAtEnd)
                TheSteam.Close();

        }

        public void Broadcast(StreamReader TheStreamReader)
        {

            Broadcast(TheStreamReader.BaseStream);

        }

        public void BroadcastOnce(Stream TheSteam)
        {

            CheckReadStream(TheSteam);

            int TheByte = TheSteam.ReadByte();

            if(TheByte > -1)
            {

                for(int i = 0; i < myStreamList.Count; ++i)
                {

                    Stream CurrentStream = myStreamList[i];

                    if(CurrentStream.CanWrite)
                    {

                        try
                        {

                            CurrentStream.WriteByte((byte)TheByte);

                        }
                        catch
                        {

                            myStreamList.Remove(CurrentStream);

                        }

                    }
                    else
                    {

                        myStreamList.Remove(CurrentStream);

                    }

                }

            }

            if(myCloseAtEnd)
                TheSteam.Close();

        }

        public void BroadcastOnce(StreamReader TheStreamReader)
        {

            BroadcastOnce(TheStreamReader.BaseStream);

        }

        public void Broadcast(Stream TheSteam, int Offset, int Count)
        {

            CheckReadStream(TheSteam);

            byte[] TheBytes = new byte[Count];

            int ByteCount = TheSteam.Read(TheBytes, Offset, Count);

            while(ByteCount > 0)
            {

                for(int i = 0; i < myStreamList.Count; ++i)
                {

                    Stream CurrentStream = myStreamList[i];

                    if(CurrentStream.CanWrite)
                    {

                        try
                        {

                            CurrentStream.Write(TheBytes, Offset, ByteCount);

                        }
                        catch
                        {

                            myStreamList.Remove(CurrentStream);

                        }

                    }
                    else
                    {

                        myStreamList.Remove(CurrentStream);

                    }

                }

                ByteCount = TheSteam.Read(TheBytes, Offset, ByteCount);

            }

            if(myCloseAtEnd)
                TheSteam.Close();

        }

        public void Broadcast(StreamReader TheStreamReader, int Offset, int Count)
        {

            Broadcast(TheStreamReader.BaseStream, Offset, Count);

        }

        public void BroadcastOnce(Stream TheSteam, int Offset, int Count)
        {

            CheckReadStream(TheSteam);

            byte[] TheBytes = new byte[Count];

            int ByteCount = TheSteam.Read(TheBytes, Offset, Count);

            if(ByteCount > 0)
            {

                for(int i = 0; i < myStreamList.Count; ++i)
                {

                    Stream CurrentStream = myStreamList[i];

                    if(CurrentStream.CanWrite)
                    {

                        try
                        {

                            CurrentStream.Write(TheBytes, Offset, ByteCount);

                        }
                        catch
                        {

                            myStreamList.Remove(CurrentStream);

                        }

                    }
                    else
                    {

                        myStreamList.Remove(CurrentStream);

                    }

                }

            }

            if(myCloseAtEnd)
                TheSteam.Close();

        }

        public void BroadcastOnce(StreamReader TheStreamReader, int Offset, int Count)
        {

            BroadcastOnce(TheStreamReader.BaseStream, Offset, Count);

        }

        protected bool CheckReadStream(Stream TheSteam)
        {

            if(!TheSteam.CanRead)
                return false;

            if(myStreamList.Count < 1)
                return false;

            return true;

        }

        protected bool CheckWriteStream(Stream TheStream)
        {

            if(!TheStream.CanWrite)
                return false;

            return true;

        }

        public bool CloseAtEnd
        {

            get
            {

                return myCloseAtEnd;

            }
            set
            {

                myCloseAtEnd = value;

            }

        }

        public void Add(Stream TheStream)
        {

            if(!CheckWriteStream(TheStream))
                return;

            if(!myStreamList.Contains(TheStream))
            {

                if(TheStream.CanWrite)
                    myStreamList.Add(TheStream);

            }

        }

        public void Add(StreamWriter TheStreamWriter)
        {

            Add(TheStreamWriter.BaseStream);

        }

        public void Add(IEnumerable<Stream> TheStreams)
        {

            foreach(Stream TheStream in TheStreams)
            {

                Add(TheStream);

            }

        }

        public void Add(IEnumerable<StreamWriter> TheStreamWriters)
        {

            foreach(StreamWriter TheStreamWriter in TheStreamWriters)
            {

                Add(TheStreamWriter);

            }

        }

        public bool Remove(Stream TheStream)
        {

            return myStreamList.Remove(TheStream);

        }

        public bool RemoveAndClose(Stream TheStream)
        {

            bool Removed = myStreamList.Remove(TheStream);

            if(Removed)
                TheStream.Close();

            return Removed;

        }

        public int Count
        {

            get
            {

                return myStreamList.Count;

            }
            
        }

        public bool Contains(Stream TheStream)
        {

            return myStreamList.Contains(TheStream);

        }

        public bool ContainsBaseStream(StreamWriter TheStreamWriter)
        {

            return myStreamList.Contains(TheStreamWriter.BaseStream);

        }
        
        public int IndexOf(Stream item)
        {
            
            return myStreamList.IndexOf(item);

        }

        public void Insert(int index, Stream item)
        {
            
            myStreamList.Insert(index, item);

        }

        public void RemoveAt(int index)
        {

            myStreamList.RemoveAt(index);

        }

        public Stream this[int index]
        {

            get
            {

                return myStreamList[index];

            }
            set
            {

                myStreamList[index] = value;

            }

        }


        public void Clear()
        {
            
            myStreamList.Clear();

        }

        public void CloseAndClearAll()
        {

            foreach(Stream Item in myStreamList)
            {

                try
                {

                    Item.Close();

                }
                catch
                { 
                }

            }

            myStreamList.Clear();

        }

        public void CopyTo(Stream[] array, int arrayIndex)
        {

            myStreamList.CopyTo(array, arrayIndex);

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public IEnumerator<Stream> GetEnumerator()
        {
            
            return myStreamList.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myStreamList.GetEnumerator();

        }

    }

}
