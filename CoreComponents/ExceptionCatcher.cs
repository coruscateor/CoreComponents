using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class ExceptionCatcher
    {

        public event EventHandler<ExceptionEventArgs> CaughtExecption;

        public ExceptionCatcher()
        {
        }

        protected void OnCaughtExecption(Exception TheException)
        {

            if (CaughtExecption != null)
            {

                CaughtExecption(this, new ExceptionEventArgs(TheException));

            }

        }

        public void Try(Action TheAction)
        {

            try
            {

                TheAction();

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }

        }

        public void TryFinally(Action TheAction, Action TheFinallyAction)
        {

            try
            {

                TheAction();

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }
            finally
            {

                TheFinallyAction();

            }

        }

        public void Try<T>(Action<T> TheAction, T TheInput)
        {

            try
            {

                TheAction(TheInput);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }

        }

        public void TryFinally<T>(Action<T> TheAction, T TheInput, Action TheFinallyAction)
        {

            try
            {

                TheAction(TheInput);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }
            finally
            {

                TheFinallyAction();

            }

        }

        public void Try<T1, T2>(Action<T1, T2> TheAction, T1 TheInput1, T2 TheInput2)
        {

            try
            {

                TheAction(TheInput1, TheInput2);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }

        }

        public void TryFinally<T1, T2>(Action<T1, T2> TheAction, T1 TheInput1, T2 TheInput2, Action TheFinallyAction)
        {

            try
            {

                TheAction(TheInput1, TheInput2);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }
            finally
            {

                TheFinallyAction();

            }

        }

        public TResult Try<TResult>(Func<TResult> TheFunc)
        {

            try
            {

                return TheFunc();

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }

            return default(TResult);

        }

        public TResult TryFinally<TResult>(Func<TResult> TheFunc, Action TheFinallyAction)
        {

            try
            {

                return TheFunc();

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }
            finally
            {

                TheFinallyAction();

            }

            return default(TResult);

        }

        public TResult Try<T, TResult>(Func<T, TResult> TheFunc, T TheInput)
        {

            try
            {

                return TheFunc(TheInput);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }

            return default(TResult);

        }

        public TResult TryFinally<T, TResult>(Func<T, TResult> TheFunc, T TheInput, Action TheFinallyAction)
        {

            try
            {

                return TheFunc(TheInput);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }
            finally
            {

                TheFinallyAction();

            }

            return default(TResult);

        }

        public TResult Try<T1, T2, TResult>(Func<T1, T2, TResult> TheFunc, T1 TheInput1, T2 TheInput2)
        {

            try
            {

                return TheFunc(TheInput1, TheInput2);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }

            return default(TResult);

        }

        public TResult Try<T1, T2, TResult>(Func<T1, T2, TResult> TheFunc, T1 TheInput1, T2 TheInput2, Action TheFinallyAction)
        {

            try
            {

                return TheFunc(TheInput1, TheInput2);

            }
            catch (Exception e)
            {

                OnCaughtExecption(e);

            }
            finally
            {

                TheFinallyAction();

            }

            return default(TResult);

        }

    }

}
