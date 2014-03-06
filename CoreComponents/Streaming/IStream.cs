using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Streaming
{

    public interface IStream : IDisposable
    {

        bool CanRead
        {

            get;
        
        }

        bool CanSeek
        {
            
            get;
        
        }

        bool CanTimeout
        {
            
            get;
        
        }
        
        bool CanWrite
        {
            
            get;
        
        }

        long Length
        {
            
            get;
        
        }

        long Position
        {
            
            get;
            set;
        
        }

        int ReadTimeout
        {
            
            get;
            set;
        
        }

        int WriteTimeout
        {
            
            get;
            set;
        
        }

        IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state);

        IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state);

        void Close();

        void CopyTo(Stream destination);

        void CopyTo(Stream destination, int bufferSize);

        Task CopyToAsync(Stream destination);

        Task CopyToAsync(Stream destination, int bufferSize);

        Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken);

        void CopyTo(IStream destination);

        void CopyTo(IStream destination, int bufferSize);

        Task CopyToAsync(IStream destination);

        Task CopyToAsync(IStream destination, int bufferSize);

        Task CopyToAsync(IStream destination, int bufferSize, CancellationToken cancellationToken);

        int EndRead(IAsyncResult asyncResult);

        void EndWrite(IAsyncResult asyncResult);
 
        void Flush();

        Task FlushAsync();

        Task FlushAsync(CancellationToken cancellationToken);

        int Read(byte[] buffer, int offset, int count);

        Task<int> ReadAsync(byte[] buffer, int offset, int count);

        Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);

        int ReadByte();

        long Seek(long offset, SeekOrigin origin);
 
        void SetLength(long value);
        
        void Write(byte[] buffer, int offset, int count);

        Task WriteAsync(byte[] buffer, int offset, int count);

        Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);

        void WriteByte(byte value);

    }

}
