using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public class TransparentWorkExecutor : IAsynchronousWorkContainer, IWorkExecution
    {

        protected IAsynchronousWorkContainer myAsynchronousWorkContainer;

        public TransparentWorkExecutor(IAsynchronousWorkContainer TheAsynchronousWorkContainer)
        {

            myAsynchronousWorkContainer = TheAsynchronousWorkContainer;

        }

        public void Check()
        {

            if (HasWorkContainer && !myAsynchronousWorkContainer.IsBusy)
                myAsynchronousWorkContainer.Execute();

        }

        public IAsynchronousWorkContainer AsynchronousWorkContainer
        {

            get
            {

                return myAsynchronousWorkContainer;
            
            }
            
        }

        public bool IsBusy
        {

            get
            {

                if (HasWorkContainer)
                {

                    return myAsynchronousWorkContainer.IsBusy;

                }

                return false;

            }

        }

        public bool HasWorkContainer
        {

            get
            {

                return myAsynchronousWorkContainer != null;
            
            }

        }

        public bool SetWork(IAsynchronousWorkContainer TheAsynchronousWorkContainer)
        {

            if (myAsynchronousWorkContainer != TheAsynchronousWorkContainer)
            {

                if (!HasWorkContainer || !myAsynchronousWorkContainer.IsBusy)
                {

                    myAsynchronousWorkContainer = TheAsynchronousWorkContainer;

                    return true;

                }

            }

            return false;

        }

    }

}
