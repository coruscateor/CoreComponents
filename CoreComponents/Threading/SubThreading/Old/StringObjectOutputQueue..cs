using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace CoreComponents.Threading.SubThreading
{
    public class StringObjectOutputQueue : OutputQueue<IDictionary<string, object>>
    {

        public StringObjectOutputQueue(Lazy<ConcurrentQueue<IDictionary<string, object>>> TheLazyQueue) : base(TheLazyQueue)
        {
        }

        //public void GetLatest(out TType TheItem)
        //{
        //    //Might need to wrap this in a spinner aswell
        //    myLazyQueue.Value.TryPeek(out TheItem);

        //}

    }
}
