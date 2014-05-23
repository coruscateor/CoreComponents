using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public static class Creator<T> where T : class, new()
    {

        public static ConcurrentQueue<T> Create(uint TheCount)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            ThreadPool.QueueUserWorkItem((object TheParameter) => {

                while(TheCount > 0)
                {

                    NewQueue.Enqueue(new T());

                    --TheCount;

                }
            
            
            });

            return NewQueue;

        }

        public static void CreateInto(uint TheCount, ConcurrentQueue<T> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(new T());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(uint TheCount, IInputQueue<T> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(new T());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(uint TheCount, IInputOutputQueue<T> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(new T());

                    --TheCount;

                }

            });

        }

        public static ConcurrentQueue<T> Create(uint TheCount, Func<T> TheCreationFunc)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    NewQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }


            });

            return NewQueue;

        }

        public static void CreateInto(uint TheCount, ConcurrentQueue<T> TheQueue, Func<T> TheCreationFunc)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(uint TheCount, IInputQueue<T> TheQueue, Func<T> TheCreationFunc)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(uint TheCount, IInputOutputQueue<T> TheQueue, Func<T> TheCreationFunc)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }

            });

        }

        public static ConcurrentQueue<T> Create(ulong TheCount)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    NewQueue.Enqueue(new T());

                    --TheCount;

                }


            });

            return NewQueue;

        }

        public static void CreateInto(ulong TheCount, ConcurrentQueue<T> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(new T());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(ulong TheCount, IInputQueue<T> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(new T());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(ulong TheCount, IInputOutputQueue<T> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(new T());

                    --TheCount;

                }

            });

        }

        public static ConcurrentQueue<T> Create(ulong TheCount, Func<T> TheCreationFunc)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    NewQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }


            });

            return NewQueue;

        }

        public static void CreateInto(ulong TheCount, ConcurrentQueue<T> TheQueue, Func<T> TheCreationFunc)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(ulong TheCount, IInputQueue<T> TheQueue, Func<T> TheCreationFunc)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }


            });

        }

        public static void CreateInto(ulong TheCount, IInputOutputQueue<T> TheQueue, Func<T> TheCreationFunc)
        {

            ThreadPool.QueueUserWorkItem((object TheParameter) =>
            {

                while(TheCount > 0)
                {

                    TheQueue.Enqueue(TheCreationFunc());

                    --TheCount;

                }

            });

        }

        public static ConcurrentQueue<T> Create(SpinValueContainer<bool> Continue, uint CheckingRegularity = 10)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            NewQueue.Enqueue(new T());

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

                        NewQueue.Enqueue(new T());

                    }
                
                });

            }

            return NewQueue;

        }

        public static void CreateInto(SpinValueContainer<bool> Continue, ConcurrentQueue<T> TheQueue, uint CheckingRegularity = 10)
        {
            
            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue(new T());

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

                        TheQueue.Enqueue(new T());

                    }
                
                });

            }

        }

        public static void CreateInto(SpinValueContainer<bool> Continue, IInputQueue<T> TheQueue, uint CheckingRegularity = 10)
        {

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue(new T());

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

                        TheQueue.Enqueue(new T());

                    }
                
                });

            }

        }

        public static ConcurrentQueue<T> CreatePerpetually(SpinValueContainer<bool> Continue, Func<T> TheCreationFunc, uint CheckingRegularity = 10)
        {

            ConcurrentQueue<T> NewQueue = new ConcurrentQueue<T>();

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            NewQueue.Enqueue(TheCreationFunc());

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

                        NewQueue.Enqueue(TheCreationFunc());

                    }
                
                });

            }

            return NewQueue;

        }

        public static void CreateIntoPerpetually(SpinValueContainer<bool> Continue, ConcurrentQueue<T> TheQueue, Func<T> TheCreationFunc, uint CheckingRegularity = 10)
        {

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue(TheCreationFunc());

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

                        TheQueue.Enqueue(TheCreationFunc());

                    }

                });

            }

        }

        public static void CreateIntoPerpetually(SpinValueContainer<bool> Continue, IInputQueue<T> TheQueue, Func<T> TheCreationFunc, uint CheckingRegularity = 10)
        {

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue(TheCreationFunc());

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

                        TheQueue.Enqueue(TheCreationFunc());

                    }

                });

            }

        }

        public static void CreateInto(SpinValueContainer<bool> Continue, IInputOutputQueue<T> TheQueue, Func<T> TheCreationFunc, uint CheckingRegularity = 10)
        {

            if(CheckingRegularity > 0)
            {

                ThreadPool.QueueUserWorkItem((object TheParameter) =>
                {

                    while(true)
                    {

                        uint CurrentCount = CheckingRegularity;

                        while(CurrentCount > 0)
                        {

                            TheQueue.Enqueue(TheCreationFunc());

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

                        TheQueue.Enqueue(TheCreationFunc());

                    }

                });

            }

        }

    }

}
