using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public static class ReflectingCreator<T> where T : class
    {

        public static ConcurrentQueue<T> Create(uint TheCount, object[] TheParameters)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                Type CurrentType = typeof(T);

                while(TheCount > 0)
                {

                    NewQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    --TheCount;

                }


            });

            return NewQueue;

        }

        public static void CreateInto(uint TheCount, ConcurrentQueue<T> TheQueue, object[] TheParameters)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                Type CurrentType = typeof(T);

                while(TheCount > 0)
                {

                    TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    --TheCount;

                }


            });

        }

        public static void CreateInto(uint TheCount, IInputQueue<T> TheQueue, object[] TheParameters)
        {

            Type CurrentType = typeof(T);

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    --TheCount;

                }


            });

        }

        public static void CreateInto(uint TheCount, IInputOutputQueue<T> TheQueue, object[] TheParameters)
        {

            Type CurrentType = typeof(T);

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    --TheCount;

                }

            });

        }

        public static ConcurrentQueue<T> Create(SpinValueContainer<bool> Continue, object[] TheParameters, uint CheckingRegularity = 10)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();
            
            Type CurrentType = typeof(T);

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            NewQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                            --CurrentCount;

                        }

                        if(!Continue.Value)
                            return;

                    }

                });

            }
            else
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        NewQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    }

                });

            }

            return NewQueue;

        }

        public static void CreateInto(SpinValueContainer<bool> Continue, ConcurrentQueue<T> TheQueue, object[] TheParameters, uint CheckingRegularity = 10)
        {
            
            Type CurrentType = typeof(T);

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                            --CurrentCount;

                        }

                        if(!Continue.Value)
                            return;

                    }

                });

            }
            else
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    }

                });

            }

        }

        public static void CreateInto(SpinValueContainer<bool> Continue, IInputQueue<T> TheQueue, object[] TheParameters, uint CheckingRegularity = 10)
        {

            Type CurrentType = typeof(T);

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                            --CurrentCount;

                        }

                        if(!Continue.Value)
                            return;

                    }

                });

            }
            else
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        TheQueue.Enqueue((T)Activator.CreateInstance(CurrentType, TheParameters));

                    }

                });

            }

        }

    }

}
