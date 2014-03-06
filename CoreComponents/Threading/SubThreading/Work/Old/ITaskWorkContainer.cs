using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface ITaskWorkContainer : IWorkContainer
    {

        void Execute(TaskScheduler TheTaskScheduler);

        TaskCreationOptions CreationOptions
        {

            get;

        }

    }

}
