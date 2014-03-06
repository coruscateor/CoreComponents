using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Dynamic;

namespace CoreComponents.Threading.SubThreading
{
    public abstract class IsolatedThread : IsolatedThreadBase
    {

        private Thread myThread;

        private object myParameter = null;

        private AggregateException myException = null;

        public IsolatedThread(bool IsParameterisedThread = false, int? TheMaxStackSize = null) 
        {
            
            if (IsParameterisedThread)
            {

                if (TheMaxStackSize.HasValue)
                {

                    myThread = new Thread(MainTakingAParameter, TheMaxStackSize.Value);
                    
                }
                else
                {

                    myThread = new Thread(MainTakingAParameter);

                }

            }
            else
            {

                if (TheMaxStackSize.HasValue)
                {

                    myThread = new Thread(RunMain, TheMaxStackSize.Value);

                }
                else
                {

                    myThread = new Thread(RunMain);

                }

            }

        }

        public void Execute()
        {
            
            myThread.Start();

        }

        public void Execute(object TheParameter)
        {
            

            myThread.Start(TheParameter);

            
        }

        protected abstract void Main();

        private void RunMain() 
        {
            //try

            Main();

            //catch AggrigateException

        }

        protected virtual void MainTakingAParameter(object TheParameter) 
        {

            //Dictionary<string, object> InitalParameter = new Dictionary<string, object>();

            //InitalParameter.Add("InitalParameter", TheParameter);

            //ThreadIO.ObjectsInputQueue.Enqueue(InitalParameter);

            myParameter = TheParameter;

            RunMain();
            
        }

        public Thread TheThread
        {

            get
            {

                return myThread;
                
            }

        }

        public AggregateException Exception
        {

            get 
            {

                return myException;

            }
        
        }

        public bool CaughtException
        {

            get
            {

                return myException != null;

            }

        }

        public bool IsInitiated 
        {

            get 
            {

                return myThread.IsAlive;

            }

        }

        protected object Parameter 
        {

            get 
            {

                return myParameter;

            }

        }

        protected bool HasParameter
        {

            get
            {

                return myParameter != null;

            }

        }

    }
}
