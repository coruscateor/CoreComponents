using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CoreComponents.Processes
{

    public abstract class BaseAsyncronousProcessOutputManager
    {

        protected Process myProcess;

        protected bool myOutputEngaged = true;

        protected bool myErrorOutputEngaged = true;

        protected bool myEngaged = true;

        protected bool myAutoEngage = true;

        public BaseAsyncronousProcessOutputManager()
        {
        }

        public BaseAsyncronousProcessOutputManager(Process TheProcess)
        {

            myProcess = TheProcess;

            Engage();

        }

        public BaseAsyncronousProcessOutputManager(Process TheProcess, bool AutoEngage)
        {

            myProcess = TheProcess;

            if (AutoEngage)
                Engage();

        }

        public Process Process
        {

            get
            {

                return myProcess;

            }

            set
            {

                if (myProcess != value)
                {
                    DisEngage();

                    myProcess = value;

                    if(myProcess != null && myAutoEngage)
                        Engage();

                }

            }

        }

        public bool HasProcess
        {

            get
            {

                return myProcess != null;

            }

        }

        public void Engage()
        {

            if (myProcess != null && !myEngaged)
            {

                EngageOutput();

                EngageErrorOutput();

                myProcess.Disposed += myProcess_Disposed;

                myEngaged = true;

            }

        }

        public void DisEngage()
        {

            if (myEngaged && myProcess != null)
            {

                if (myOutputEngaged)
                    DisEngageOutput();

                if (myErrorOutputEngaged)
                    DisEngageErrorOutput();
                
                myProcess.Disposed -= myProcess_Disposed;

                myEngaged = false;

            }

        }

        protected void EngageOutput()
        {

            if (!myOutputEngaged)
                myProcess.OutputDataReceived += OutputDataReceived;

        }

        protected void DisEngageOutput()
        {

            if (myOutputEngaged)
                myProcess.OutputDataReceived -= OutputDataReceived;

        }

        protected void EngageErrorOutput()
        {

            if (!myErrorOutputEngaged)
                myProcess.ErrorDataReceived += ErrorDataReceived;

        }

        protected void DisEngageErrorOutput()
        {

            if (myErrorOutputEngaged)
                myProcess.ErrorDataReceived -= ErrorDataReceived;

        }

        public bool OutputEngaged
        {

            get
            {

                return myOutputEngaged;

            }
            set
            {

                if (myEngaged && value)
                {

                    EngageOutput();

                }
                else if (!value)
                {

                    DisEngageOutput();

                }

                myOutputEngaged = value;

            }

        }

        public bool ErrorOutputEngaged
        {

            get
            {

                return myErrorOutputEngaged;

            }
            set
            {

                if (myEngaged && value)
                {

                    EngageErrorOutput();

                }
                else if (!value)
                {

                    DisEngageErrorOutput();

                }

                myErrorOutputEngaged = value;
 
            }

        }

        public bool Engaged
        {

            get
            {

                return myEngaged;

            }
            set
            {

                if (value != myEngaged)
                {

                    if (value)
                    {

                        Engage();

                    }
                    else
                    {

                        DisEngage();

                    }

                }

            }

        }

        public bool AutoEngage
        {

            get
            {

                return myAutoEngage;

            }
            set
            {

                myAutoEngage = value;

            }

        }

        void myProcess_Disposed(object sender, EventArgs e)
        {

            if (myEngaged)
            {

                if (myOutputEngaged)
                    DisEngageOutput();

                if (myErrorOutputEngaged)
                    DisEngageErrorOutput();

                myProcess.Disposed -= myProcess_Disposed;

            }

            DisEngage();

            myProcess = null;

        }

        protected abstract void OutputDataReceived(object sender, DataReceivedEventArgs e);

        protected abstract void ErrorDataReceived(object sender, DataReceivedEventArgs e);

    }

}
