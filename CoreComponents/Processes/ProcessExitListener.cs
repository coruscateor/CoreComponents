using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreComponents.Processes
{

    public abstract class ProcessExitListener
    {

        protected volatile Process myProcess;

        public ProcessExitListener()
        { 
        }

        public ProcessExitListener(Process TheProcess)
        {

            Engage(TheProcess);

        }

        public void Engage(Process TheProcess)
        {

            if (TheProcess != null)
            {

                myProcess = TheProcess;

                myProcess.Exited += myProcess_Exited;

            }
            else
            {

                DisEngage();

            }

        }

        public void DisEngage()
        {

            if (myProcess != null)
            {

                myProcess.Exited -= myProcess_Exited;

                myProcess = null;

            }

        }

        public Process Process
        {

            get
            {

                return myProcess;

            }
            set
            {

                Engage(value);

            }

        }

        public bool HasProcess
        {

            get
            {

                return myProcess != null;

            }

        }

        void myProcess_Exited(object sender, EventArgs e)
        {

            ProcessExited();

        }

        protected abstract void ProcessExited();

    }

}
