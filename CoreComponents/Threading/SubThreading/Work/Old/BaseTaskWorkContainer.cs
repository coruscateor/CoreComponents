using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Work
{

    public abstract class BaseTaskWorkContainer : BaseWorkContainer //: ITaskWorkContainer
    {

        Task myTask;

        public BaseTaskWorkContainer()
        {

            myTask = new Task(Main);

        }

        public BaseTaskWorkContainer(TaskCreationOptions TheTaskCreationOptions)
        {

            myTask = new Task(Main, TheTaskCreationOptions);
            
        }

        protected abstract void Main();

        //public void Execute()
        //{

        //    myTask.Start();

        //}

        //public void Execute(TaskScheduler TheTaskScheduler)
        //{

        //    myTask.Start(TheTaskScheduler);

        //}

        public bool IsActive
        {

            get
            {

                return myTask.Status != TaskStatus.Running && myTask.Status != TaskStatus.WaitingToRun && myTask.Status != TaskStatus.WaitingForActivation && myTask.Status != TaskStatus.WaitingForChildrenToComplete;

            }

        }

        public TaskCreationOptions CreationOptions
        {

            get
            {

                return myTask.CreationOptions;

            }

        }

    }

}
