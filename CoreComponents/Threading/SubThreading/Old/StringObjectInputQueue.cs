using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace CoreComponents.Threading.SubThreading
{
    public class StringObjectInputQueue : InputQueue<IDictionary<string, object>>
    {

        public StringObjectInputQueue(Lazy<ConcurrentQueue<IDictionary<string, object>>> TheLazyQueue) : base(TheLazyQueue) 
        {
        }

        public void Enqueue(ExpandoObject TheObjects)
        {

            myLazyQueue.Value.Enqueue(new Dictionary<string, object>((IDictionary<string, object>)TheObjects));

        }

    }
}
