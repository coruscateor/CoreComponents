using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public interface IQueue<T> : IEnumerable<T>
    {
        
        int Count
        {
            
            get;
        
        }

        bool IsEmpty
        {
            
            get;
        
        }

        //void CopyTo(T[] array, int index);

        void Enqueue(T item);

        IEnumerator<T> GetEnumerator();

        //T[] ToArray();

        bool TryDequeue(out T result);

        //bool TryPeek(out T result);

    }

}
