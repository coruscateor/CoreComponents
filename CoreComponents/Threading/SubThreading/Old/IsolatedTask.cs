using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{
    public abstract class IsolatedTask : IsolatedThreadBase
    {
        protected Task myTask;

        public IsolatedTask(bool StartNow = false) 
        {
            if (StartNow)
            {

                myTask = new Task(Main);

            }
            else
            {

                myTask = Task.Factory.StartNew(Main);
                
            }
        }

        public void Execute(TaskScheduler TheTaskScheduler = null) 
        {

            //If is started

            if(TheTaskScheduler != null)
            {

                //try
                //{

                 myTask.Start(TheTaskScheduler);
                    
                //}
                //catch (ObjectDisposedException) 
                //{

                //    myTask = new Task(Main);

                //    myTask.Start(TheTaskScheduler);

                //}

            }
            else
            {

                //try
                //{


                 myTask.Start();

                //}
                //catch (ObjectDisposedException)
                //{

                //    myTask = Task.Factory.StartNew(Main);

                //}
                
            }
        }

        protected abstract void Main();

        public bool IsInitiated
        {

            get
            {

                return myTask.Status == TaskStatus.Running;

            }

        }

        //ReInitaliseTask

        public Task TheTask 
        {

            get
            {

                return myTask;

            }

        }

        //public void InputObjects(IDictionary<string, object> TheObjects) 
        //{

        //    myLazyObjectsInputQueue.Value.Enqueue(TheObjects);

        //}

    }

    public abstract class IsolatedTask<TResult> : IsolatedThreadBase 
    {

        protected Task<TResult> myTask;

        public IsolatedTask(bool StartNow = false) 
        {

            if (StartNow)
            {

                myTask = new Task<TResult>(Main);

            }
            else
            {

                myTask = Task<TResult>.Factory.StartNew(Main);

            }

        }

        public void Execute()
        {

            myTask.Start();

        }

        public void Execute(TaskScheduler TheTaskScheduler)
        {

            myTask.Start(TheTaskScheduler);

        }

        protected abstract TResult Main();

        public bool IsInitiated
        {

            get
            {

                return myTask.Status == TaskStatus.Running;

            }

        }

        public Task<TResult> TheTask
        {

            get
            {

                return myTask;

            }

        }

    }
}
