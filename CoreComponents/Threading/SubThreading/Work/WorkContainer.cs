using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public abstract class WorkContainer : IWorkContainer
    {

        public WorkContainer()
        {
        }

        public virtual void Execute(IAsynchronousInputOutput ThreadIO)
        {

            while (ThreadIO.Input.Count > 0)
            {

                if (!InputRecived(ThreadIO))
                {
                    //ThreadIO
                    return;

                }

            }

        }

        protected abstract bool InputRecived(IAsynchronousInputOutput ThreadIO);

    }

}
