using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Streaming
{

    public class Streamer : MarshalByRefObject, IStream
    {

        protected Stream myStream;

        public Streamer(Stream TheStream)
        {

            myStream = TheStream;

        }

        public bool CanRead
        {

            get
            {
 
                return myStream.CanRead;
            
            }

        }

        public bool CanSeek
        {

            get
            {
                
                return myStream.CanSeek;
            
            }

        }

        public bool CanTimeout
        {

            get
            { 
                
                return myStream.CanTimeout;
            
            }

        }

        public bool CanWrite
        {

            get
            {
                
                return CanWrite;
            
            }

        }

        public long Length
        {

            get
            {

                return myStream.Length;
            
            }

        }

        public long Position
        {

            get
            {

                return myStream.Position;

            }
            set
            {

                myStream.Position = value;

            }

        }

        public int ReadTimeout
        {

            get
            {

                return myStream.ReadTimeout;
                    
            }
            set
            {

                myStream.ReadTimeout = value;

            }

        }

        public int WriteTimeout
        {

            get
            {

                return myStream.WriteTimeout;

            }
            set
            {

                myStream.WriteTimeout = value;

            }

        }

        public Stream BaseStream
        {

            get
            {

                return myStream;

            }

        }

        public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            
            return myStream.BeginRead(buffer, offset, count, callback, state);

        }

        public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {

            return myStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public void Close()
        {

            myStream.Close();

        }

        public void CopyTo(Stream destination)
        {

            myStream.CopyTo(destination);

        }

        public void CopyTo(Stream destination, int bufferSize)
        {

            myStream.CopyTo(destination, bufferSize);

        }

        public Task CopyToAsync(Stream destination)
        {
            
            return myStream.CopyToAsync(destination);

        }

        public Task CopyToAsync(Stream destination, int bufferSize)
        {

            return myStream.CopyToAsync(destination, bufferSize);

        }

        public Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {

            return myStream.CopyToAsync(destination, bufferSize, cancellationToken);

        }

        public void CopyTo(IStream destination)
        {

            throw new NotImplementedException();

        }

        public void CopyTo(IStream destination, int bufferSize)
        {

            throw new NotImplementedException();

        }

        public Task CopyToAsync(IStream destination)
        {

            throw new NotImplementedException();

        }

        public Task CopyToAsync(IStream destination, int bufferSize)
        {

            throw new NotImplementedException();

        }

        public Task CopyToAsync(IStream destination, int bufferSize, System.Threading.CancellationToken cancellationToken)
        {

            throw new NotImplementedException();

        }

        public int EndRead(IAsyncResult asyncResult)
        {

            return myStream.EndRead(asyncResult);

        }

        public void EndWrite(IAsyncResult asyncResult)
        {

            myStream.EndWrite(asyncResult);

        }

        public void Flush()
        {

            myStream.Flush();

        }

        public Task FlushAsync()
        {

            return myStream.FlushAsync();

        }

        public Task FlushAsync(CancellationToken cancellationToken)
        {

            return myStream.FlushAsync(cancellationToken);

        }

        public int Read(byte[] buffer, int offset, int count)
        {

            return myStream.Read(buffer, offset, count);

        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {

            return myStream.ReadAsync(buffer, offset, count);

        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {

            return myStream.ReadAsync(buffer, offset, count, cancellationToken);

        }

        public int ReadByte()
        {

            return myStream.ReadByte();

        }

        public long Seek(long offset, SeekOrigin origin)
        {

            return myStream.Seek(offset, origin);

        }

        public void SetLength(long value)
        {

            myStream.SetLength(value);

        }

        public void Write(byte[] buffer, int offset, int count)
        {

            myStream.Write(buffer, offset, count);

        }

        public Task WriteAsync(byte[] buffer, int offset, int count)
        {

            return myStream.WriteAsync(buffer, offset, count);

        }

        public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {

            return myStream.WriteAsync(buffer, offset, count, cancellationToken);

        }

        public void WriteByte(byte value)
        {

            myStream.WriteByte(value);

        }

        public void Dispose()
        {

            myStream.Dispose();

        }

    }

}
