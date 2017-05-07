using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public class InputQueue
    {

        IIsolatedThread myIsolatedThread;

        ConcurrentQueue<object> myQueue;

        public InputQueue(IIsolatedThread isolatedThread, ConcurrentQueue<object> queue)
        {

            myIsolatedThread = isolatedThread;

            myQueue = queue;

        }

        public void Enqueue(object item)
        {

            myQueue.Enqueue(item);

            myIsolatedThread.Start();

        }

        public void Enqueue(object item1, object item2)
        {

            myQueue.Enqueue(item1);

            myQueue.Enqueue(item2);

            myIsolatedThread.Start();

        }

        public void Enqueue(object item1, object item2, object item3)
        {

            myQueue.Enqueue(item1);

            myQueue.Enqueue(item2);

            myQueue.Enqueue(item3);

            myIsolatedThread.Start();

        }

        public void Enqueue(object item1, object item2, object item3, object item4)
        {

            myQueue.Enqueue(item1);

            myQueue.Enqueue(item2);

            myQueue.Enqueue(item3);

            myQueue.Enqueue(item4);

            myIsolatedThread.Start();

        }

        public void EnqueueParams(params object[] items)
        {

            foreach(var item in items)
                myQueue.Enqueue(item);

            myIsolatedThread.Start();

        }

        public void EnqueueNoStart(object item)
        {

            myQueue.Enqueue(item);

        }

        public void Enqueue(IEnumerable<object> items)
        {

            foreach(var Item in items)
                myQueue.Enqueue(Item);

            myIsolatedThread.Start();

        }
        public void EnqueueNoStart(object item1, object item2)
        {

            myQueue.Enqueue(item1);

            myQueue.Enqueue(item2);

        }

        public void EnqueueNoStart(object item1, object item2, object item3)
        {

            myQueue.Enqueue(item1);

            myQueue.Enqueue(item2);

            myQueue.Enqueue(item3);

        }

        public void EnqueueNoStart(object item1, object item2, object item3, object item4)
        {

            myQueue.Enqueue(item1);

            myQueue.Enqueue(item2);

            myQueue.Enqueue(item3);

            myQueue.Enqueue(item4);

        }

        public void EnqueueNoStartParams(params object[] items)
        {

            foreach(var item in items)
                myQueue.Enqueue(item);

        }

        public void EnqueueNoStart(IEnumerable<object> items)
        {

            foreach(var Item in items)
                myQueue.Enqueue(Item);

        }

        public void Start()
        {

            myIsolatedThread.Start();

        }

    }

}
