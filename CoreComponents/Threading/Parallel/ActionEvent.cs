using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class ActionEvent : BaseEvent<Action>, IExecute
    {

        public ActionEvent()
        {
        }

        public void Execute()
        {

            ThreadPool.QueueUserWorkItem(TheState => 
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                Item();

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

    public class ActionEvent<T> : BaseEvent<Action<T>>
    {

        public ActionEvent()
        {
        }

        public void Execute(T Parameter)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                Item(Parameter);

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

    public class ActionEvent<T1, T2> : BaseEvent<Action<T1, T2>>
    {

        public ActionEvent()
        {
        }

        public void Execute(T1 P1, T2 P2)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                Item(P1, P2);

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

    public class ActionEvent<T1, T2, T3> : BaseEvent<Action<T1, T2, T3>>
    {

        public ActionEvent()
        {
        }

        public void Execute(T1 P1, T2 P2, T3 P3)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                Item(P1, P2, P3);

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

    public class ActionEvent<T1, T2, T3, T4> : BaseEvent<Action<T1, T2, T3, T4>>
    {

        public ActionEvent()
        {
        }

        public void Execute(T1 P1, T2 P2, T3 P3, T4 P4)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    foreach(var Item in myItems)
                    {

                        ThreadPool.QueueUserWorkItem(TheNextState =>
                        {

                            try
                            {

                                Item(P1, P2, P3, P4);

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
