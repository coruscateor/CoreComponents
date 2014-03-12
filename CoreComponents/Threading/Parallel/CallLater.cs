using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{
    
    public static class CallLater
    {

        //Actions

        public static void Setup(WaitHandleRegestered WHR, Action TheAction, int MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    TheAction();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction(Action TheAction, int MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WaitHandleRegestered WHR = new WaitHandleRegestered(new Semaphore(1, 1));

            Setup(WHR, TheAction, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

            return WHR;

        }

        public static void Setup(WaitHandleRegestered WHR, Action TheAction, long MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    TheAction();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction(Action TheAction, long MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WaitHandleRegestered WHR = new WaitHandleRegestered(new Semaphore(1, 1));

            Setup(WHR, TheAction, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

            return WHR;

        }

        public static void Setup(WaitHandleRegestered WHR, Action TheAction, TimeSpan TheTimeOut, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    TheAction();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, TheTimeOut, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction(Action TheAction, TimeSpan TheTimeOut, bool ExecuteOnlyOnce = true)
        {

            WaitHandleRegestered WHR = new WaitHandleRegestered(new Semaphore(1, 1));

            Setup(WHR, TheAction, TheTimeOut, ExecuteOnlyOnce);

            return WHR;

        }

        public static void Setup(WaitHandleRegestered WHR, Action TheAction, uint MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    TheAction();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction(Action TheAction, uint MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WaitHandleRegestered WHR = new WaitHandleRegestered(new Semaphore(1, 1));

            Setup(WHR, TheAction, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

            return WHR;

        }

        //Funcs

        public static void Setup<T>(GetReturnValueWHR<T> WHR, Func<T> TheFunc, int MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    WHR.ReturnValue = TheFunc();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction<T>(Func<T> TheFunc, int MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            GetReturnValueWHR<T> WHR = new GetReturnValueWHR<T>(new Semaphore(1, 1));

            Setup<T>(WHR, TheFunc, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

            return WHR;

        }

        public static void Setup<T>(GetReturnValueWHR<T> WHR, Func<T> TheFunc, long MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    WHR.ReturnValue = TheFunc();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction<T>(Func<T> TheFunc, long MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            GetReturnValueWHR<T> WHR = new GetReturnValueWHR<T>(new Semaphore(1, 1));

            Setup<T>(WHR, TheFunc, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

            return WHR;

        }

        public static void Setup<T>(GetReturnValueWHR<T> WHR, Func<T> TheFunc, TimeSpan TheTimeout, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    WHR.ReturnValue = TheFunc();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, TheTimeout, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction<T>(Func<T> TheFunc, TimeSpan TheTimeout, bool ExecuteOnlyOnce = true)
        {

            GetReturnValueWHR<T> WHR = new GetReturnValueWHR<T>(new Semaphore(1, 1));

            Setup<T>(WHR, TheFunc, TheTimeout, ExecuteOnlyOnce);

            return WHR;

        }

        public static void Setup<T>(GetReturnValueWHR<T> WHR, Func<T> TheFunc, uint MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            WHR.RegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(WHR.WaitHandle, (TheState, HasTimedOut) =>
            {

                if(!HasTimedOut)
                    return;

                try
                {

                    WHR.ReturnValue = TheFunc();

                }
                catch(Exception e)
                {

                    WHR.Exception = e;

                }

            }, null, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

        }

        public static WaitHandleRegestered SetupAction<T>(Func<T> TheFunc, uint MillisecondsTimeOutInterval, bool ExecuteOnlyOnce = true)
        {

            GetReturnValueWHR<T> WHR = new GetReturnValueWHR<T>(new Semaphore(1, 1));

            Setup<T>(WHR, TheFunc, MillisecondsTimeOutInterval, ExecuteOnlyOnce);

            return WHR;

        }

    }

}
