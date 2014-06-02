using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class FuncEvent<TResult> : BaseEvent<Func<TResult>>
    {

        public FuncEvent()
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults)
        {

            ThreadPool.QueueUserWorkItem(TheState => 
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item());

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

        public void Execute(IInputQueue<TResult> TheResults)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item());

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

    }

    public class FuncEvent<TParameter, TResult> : BaseEvent<Func<TParameter, TResult>>
    {

        public FuncEvent()
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults, TParameter TheParameter)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(TheParameter));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

        public void Execute(IInputQueue<TResult> TheResults, TParameter TheParameter)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(TheParameter));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

    }

    public class FuncEvent<TP1, TP2, TResult> : BaseEvent<Func<TP1, TP2, TResult>>
    {

        public FuncEvent()
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults, TP1 P1, TP2 P2)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(P1, P2));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

        public void Execute(IInputQueue<TResult> TheResults, TP1 P1, TP2 P2)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(P1, P2));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

    }

    public class FuncEvent<TP1, TP2, TP3, TResult> : BaseEvent<Func<TP1, TP2, TP3, TResult>>
    {

        public FuncEvent()
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults, TP1 P1, TP2 P2, TP3 P3)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(P1, P2, P3));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

        public void Execute(IInputQueue<TResult> TheResults, TP1 P1, TP2 P2, TP3 P3)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(P1, P2, P3));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

    }

    public class FuncEvent<TP1, TP2, TP3, TP4, TResult> : BaseEvent<Func<TP1, TP2, TP3, TP4, TResult>>
    {

        public FuncEvent()
        {
        }

        public void Execute(ConcurrentQueue<TResult> TheResults, TP1 P1, TP2 P2, TP3 P3, TP4 P4)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(P1, P2, P3, P4));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

        public void Execute(IInputQueue<TResult> TheResults, TP1 P1, TP2 P2, TP3 P3, TP4 P4)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheResults.Enqueue(Item(P1, P2, P3, P4));

                            }
                            catch(Exception e)
                            {

                                Exception = e;

                            }

                        });

                    }

                }
                catch(Exception e)
                {

                    Exception = e;

                }

            });

        }

    }

}
