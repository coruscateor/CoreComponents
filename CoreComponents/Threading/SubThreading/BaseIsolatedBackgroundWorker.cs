using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class BaseIsolatedBackgroundWorker : ISubThread, IDisposable
    {

        private BackgroundWorker myBackgroundWorker;

        private Percentage myPercentage;

        private SpinLock myPercentageSpinlock;

        private object myUserState;

        private SpinLock myUserStateSpinlock;

        private bool myIsDisposed;

        private Exception myException;

        private object myResult;

        public BaseIsolatedBackgroundWorker()
        {
        }

        private void SetupBackgroundWorker()
        {

            myBackgroundWorker = new BackgroundWorker();

            myBackgroundWorker.DoWork += myBackgroundWorker_DoWork;

            myBackgroundWorker.ProgressChanged += myBackgroundWorker_ProgressChanged;

            //myBackgroundWorker.RunWorkerCompleted += myBackgroundWorker_RunWorkerCompleted;

            //myBackgroundWorker.Disposed += myBackgroundWorker_Disposed;

        }

        private void DisEngageBackgroundWorker()
        {

            myBackgroundWorker.DoWork -= myBackgroundWorker_DoWork;

            myBackgroundWorker.ProgressChanged -= myBackgroundWorker_ProgressChanged;

            //myBackgroundWorker.RunWorkerCompleted -= myBackgroundWorker_RunWorkerCompleted;

            //myBackgroundWorker.Disposed -= myBackgroundWorker_Disposed;

        }

        public bool IsDisposed
        {

            get
            {

                return myIsDisposed;

            }

        }

        public Percentage Percentage
        {

            get
            {

                
                bool LockTaken = false;

                try
                {

                    myPercentageSpinlock.Enter(ref LockTaken);

                    return myPercentage;

                }
                finally
                {

                    if(LockTaken)
                        myPercentageSpinlock.Exit();

                }

            }

        }

        public object UserState
        {

            get
            {
                                
                bool LockTaken = false;

                try
                {

                    myUserStateSpinlock.Enter(ref LockTaken);

                    return myUserState;

                }
                finally
                {

                    if(LockTaken)
                        myPercentageSpinlock.Exit();

                }

            }

        }

        public bool HasUserState
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myUserStateSpinlock.Enter(ref LockTaken);

                    return myUserState != null;

                }
                finally
                {

                    if(LockTaken)
                        myPercentageSpinlock.Exit();

                }

            }

        }

        public object Result
        {

            get
            {

                return myResult;

            }

        }

        public bool HasResult
        {

            get
            {

                return myResult != null;

            }

        }

        protected void SetResult(object TheResult)
        {

            myResult = TheResult;

        }

        public Exception Exception
        {

            get
            {

                return myException;

            }

        }

        public bool HasException
        {

            get
            {

                return myException != null;

            }

        }

        private void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if(myException != null)
                myException = null;

            if(myUserState != e.Argument)
                myUserState = e.Argument;

            try
            {

                ThreadMain();

            }
            catch(Exception Ex)
            {

                myException = Ex;

            }

        }
        
        protected abstract void ThreadMain();

        private void myBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            bool LockTaken = false;

            if(myPercentage.GetRaw() != e.ProgressPercentage)
            {

                myPercentageSpinlock.Enter(ref LockTaken);

                myPercentage = new Percentage(e.ProgressPercentage);

                if(LockTaken)
                {

                    myPercentageSpinlock.Exit();

                    LockTaken = false;

                }

            }

            if(myUserState != e.UserState)
            {

                myUserStateSpinlock.Enter(ref LockTaken);

                myUserState = e.UserState;

                if(LockTaken)
                    myPercentageSpinlock.Exit();

            }

        }

        //private void myBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //    myException = e.Error;

        //    myResult = e.Result;

        //}

        //private void myBackgroundWorker_Disposed(object sender, EventArgs e)
        //{

        //    DisEngageBackgroundWorker();

        //    myIsDisposed = true;

        //}

        protected void ReportProgress(int PercentProgress)
        {

            myBackgroundWorker.ReportProgress(PercentProgress);

        }

        protected void ReportProgress(int PercentProgress, object TheUserState)
        {

            myBackgroundWorker.ReportProgress(PercentProgress, TheUserState);

        }

        protected void ReportProgress(Percentage PercentProgress)
        {

            myBackgroundWorker.ReportProgress((int)PercentProgress.GetRaw());

        }

        protected void ReportProgress(Percentage PercentProgress, object TheUserState)
        {

            myBackgroundWorker.ReportProgress((int)PercentProgress.GetRaw(), TheUserState);

        }

        public void Dispose()
        {

            if(!myBackgroundWorker.IsBusy)
            {

                myBackgroundWorker.Dispose();

                DisEngageBackgroundWorker();

                myIsDisposed = true;

            }
            else
                throw new Exception("BackgroundWorker is active and cannot be disposed of");

        }

        public void ReInitaise()
        {

            if(myIsDisposed)
            {

                SetupBackgroundWorker();

                myIsDisposed = false;

            }
            else
            {

                throw new Exception("The BackgroundWorker has not been disposed of");

            }

        }

        public void Start()
        {

            myBackgroundWorker.RunWorkerAsync();

        }

        public void Start(object TheArgument)
        {

            myBackgroundWorker.RunWorkerAsync(TheArgument);

        }

        public bool IsActive
        {

            get
            {
                
                return myBackgroundWorker.IsBusy;
            
            }

        }

        public void Stop()
        {

            myBackgroundWorker.CancelAsync();

        }

        public bool StopRequested
        {

            get
            {
                
                return myBackgroundWorker.CancellationPending;
            
            }

        }

        public ResultOrException TryGetResult(out object TheResult, out Exception TheException)
        {

            //if(myBackgroundWorker.IsBusy)
            //    throw new Exception("The Background worker is still operating");

            bool HasTheResult = false;

            bool HasTheException = false;

            if(myResult != null)
            {

                TheResult = myResult;

                HasTheResult = true;

            }
            else
            {

                TheResult = null;

            }

            if(myException != null)
            {

                TheException = myException;

                HasTheException = true;

            }
            else
            {

                TheException = null;

            }

            return new ResultOrException(HasTheResult, HasTheException);

        }

        public struct ResultOrException
        {

            bool myHasResult;

            bool myHasException;

            public ResultOrException(bool HasTheResult, bool HasTheException)
            {

                myHasResult = HasTheResult;

                myHasException = HasTheException;

            }

            public bool HasResult
            {

                get
                {

                    return myHasResult;

                }

            }

            public bool HasException
            {

                get
                {

                    return myHasException;

                }

            }

        }

    }

}
