using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public abstract class OneAtATimeWorkContainer : IWorkContainer
    {

        public OneAtATimeWorkContainer()
        {
        }

        public virtual void Execute(IAsynchronousInputOutput ThreadIO)
        {

            object TheInput;

            while(ThreadIO.Output.Count > 0)
            {

                if (ThreadIO.Output.TryDequeue(out TheInput))
                {

                    if (!InputRecived(TheInput, ThreadIO))
                    {

                        return;

                    }

                }

            }

        }

        protected abstract bool InputRecived(object TheItem, IAsynchronousInputOutput ThreadIO);

    }

    public abstract class OneAtATimeWorkContainer<T> : IWorkContainer
    {

        public OneAtATimeWorkContainer()
        {
        }
        
        public virtual void Execute(IAsynchronousInputOutput ThreadIO)
        {

            object TheInput;

            while(ThreadIO.Output.Count > 0)
            {

                if(ThreadIO.Output.TryDequeue(out TheInput))
                {

                    if (TheInput.GetType() == typeof(T))
                    {

                        if (!InputRecived((T)TheInput, ThreadIO))
                        {

                            return;

                        }

                    }

                }

            }

        }

        protected abstract bool InputRecived(T TheItem, IAsynchronousInputOutput ThreadIO);

    }

}
