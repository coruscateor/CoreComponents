using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class Event : BaseEvent<Delegate>, IExecute
    {

        public Event()
        {
        }
        
        public void Execute()
        {

            ThreadPool.QueueUserWorkItem((TheState) => 
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                Item.DynamicInvoke();

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

        public void Execute(params object[] TheParameters)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                Item.DynamicInvoke(TheParameters);

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

        public void Execute(ConcurrentQueue<object> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheQueue.Enqueue(Item.DynamicInvoke());

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

        public void Execute(ConcurrentQueue<object> TheQueue, params object[] TheParameters)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheQueue.Enqueue(Item.DynamicInvoke(TheParameters));

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

        public void Execute(IInputQueue<object> TheQueue)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheQueue.Enqueue(Item.DynamicInvoke());

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

        public void Execute(IInputQueue<object> TheQueue, params object[] TheParameters)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem((TheNextState) =>
                        {

                            try
                            {

                                TheQueue.Enqueue(Item.DynamicInvoke(TheParameters));

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

        public override void Add(Delegate TheDelegate)
        {

            foreach(var Item in myItems)
            {

                if(TheDelegate.Method != Item.Method)
                    throw new Exception("Method signature is incompatable");
                else
                    break;

            }
            
            base.Add(TheDelegate);

        }
        
    }

}
