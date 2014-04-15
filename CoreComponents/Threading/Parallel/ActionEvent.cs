using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class ActionEvent : BaseEvent<Action>, IExecute, IDisposable
    {

        public ActionEvent()
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

    public class ActionEvent<T> : BaseEvent<Action<T>>, IDisposable
    {

        public ActionEvent()
        {
        }

        public void Execute(T Parameter)
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

    public class ActionEvent<T1, T2> : BaseEvent<Action<T1, T2>>, IDisposable
    {

        public ActionEvent()
        {
        }

        public void Execute(T1 P1, T2 P2)
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

}
