using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Globalization;

namespace CoreComponents.Threading.Parallel
{
    
    public static class CallSoon
    {

        //Actions

        public static void JustAction(Action TheAction)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    TheAction();

                }
                catch
                {
                }

            });

        }

        public static void JustAction<T1>(Action<T1> TheAction, T1 P1)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    TheAction(P1);

                }
                catch
                {
                }

            });

        }

        public static void JustAction<T1, T2>(Action<T1, T2> TheAction, T1 P1, T2 P2)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    TheAction(P1, P2);

                }
                catch
                {
                }

            });

        }

        public static void JustAction<T1, T2, T3>(Action<T1, T2, T3> TheAction, T1 P1, T2 P2, T3 P3)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    TheAction(P1, P2, P3);

                }
                catch
                {
                }

            });

        }

        public static void JustAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> TheAction, T1 P1, T2 P2, T3 P3, T4 P4)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                try
                {

                    TheAction(P1, P2, P3, P4);

                }
                catch
                {
                }

            });

        }

        public static void Setup(GetException TheEx, Action TheAction)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheEx.Reset();

                try
                {

                    TheAction();

                    TheEx.SetInActive();

                }
                catch(Exception e)
                {

                    TheEx.Exception = e;

                }

            });

        }

        public static GetException SetupAction(Action TheAction)
        {

            GetException Ex = new GetException();

            Setup(Ex, TheAction);

            return Ex;

        }

        public static void Setup<T1>(GetException TheEx, Action<T1> TheAction, T1 P1)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheEx.Reset();

                try
                {

                    TheAction(P1);

                    TheEx.SetInActive();

                }
                catch(Exception e)
                {

                    TheEx.Exception = e;

                }

            });

        }

        public static GetException SetupAction<T1>(Action<T1> TheAction, T1 P1)
        {

            GetException Ex = new GetException();

            Setup(Ex, TheAction, P1);

            return Ex;

        }

        public static void Setup<T1, T2>(GetException TheEx, Action<T1, T2> TheAction, T1 P1, T2 P2)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheEx.Reset();

                try
                {

                    TheAction(P1, P2);

                    TheEx.SetInActive();

                }
                catch(Exception e)
                {

                    TheEx.Exception = e;

                }

            });

        }

        public static GetException SetupAction<T1, T2>(Action<T1, T2> TheAction, T1 P1, T2 P2)
        {

            GetException Ex = new GetException();

            Setup(Ex, TheAction, P1, P2);

            return Ex;

        }

        public static void Setup<T1, T2, T3>(GetException TheEx, Action<T1, T2, T3> TheAction, T1 P1, T2 P2, T3 P3)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheEx.Reset();

                try
                {

                    TheAction(P1, P2, P3);

                    TheEx.SetInActive();

                }
                catch(Exception e)
                {

                    TheEx.Exception = e;

                }

            });

        }

        public static GetException SetupAction<T1, T2, T3>(Action<T1, T2, T3> TheAction, T1 P1, T2 P2, T3 P3)
        {

            GetException Ex = new GetException();

            Setup(Ex, TheAction, P1, P2, P3);

            return Ex;

        }

        public static void Setup<T1, T2, T3, T4>(GetException TheEx, Action<T1, T2, T3, T4> TheAction, T1 P1, T2 P2, T3 P3, T4 P4)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheEx.Reset();

                try
                {

                    TheAction(P1, P2, P3, P4);

                    TheEx.SetInActive();

                }
                catch(Exception e)
                {

                    TheEx.Exception = e;

                }

            });

        }

        public static GetException SetupAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> TheAction, T1 P1, T2 P2, T3 P3, T4 P4)
        {

            GetException Ex = new GetException();

            Setup(Ex, TheAction, P1, P2, P3, P4);

            return Ex;

        }

        public static void Setup<T>(Action<T> TheAction, ConcurrentQueue<T> TheInputQueue)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                while(true)
                {

                    T Parameter;

                    if(TheInputQueue.TryDequeue(out Parameter))
                    {

                        try
                        {

                            TheAction(Parameter);

                        }
                        catch
                        {
                        }

                    }
                    else
                    {

                        break;

                    }

                }

            });

        }

        public static void Setup<T>(Action<T> TheAction, ConcurrentQueue<T> TheInputQueue, ConcurrentQueue<Exception> TheExceptionQueue)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                while(true)
                {

                    T Parameter;

                    if(TheInputQueue.TryDequeue(out Parameter))
                    {

                        try
                        {

                            TheAction(Parameter);

                        }
                        catch(Exception e)
                        {

                            TheExceptionQueue.Enqueue(e);

                        }

                    }
                    else
                    {

                        break;

                    }

                }

            });

        }

        public static void Setup<T>(Action<T> TheAction, ConcurrentQueue<T> TheInputQueue, Action<Exception> TheExceptionAction)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                while(true)
                {

                    T Parameter;

                    if(TheInputQueue.TryDequeue(out Parameter))
                    {

                        try
                        {

                            TheAction(Parameter);

                        }
                        catch(Exception e)
                        {

                            TheExceptionAction(e);

                        }

                    }
                    else
                    {

                        break;

                    }

                }

            });

        }

        public static void Setup<T>(Action<T> TheAction, IOutputQueue<T> TheInputQueue, IInputQueue<Exception> TheExceptionQueue)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                while(true)
                {

                    T Parameter;

                    if(TheInputQueue.TryDequeue(out Parameter))
                    {

                        try
                        {

                            TheAction(Parameter);

                        }
                        catch(Exception e)
                        {

                            TheExceptionQueue.Enqueue(e);

                        }

                    }
                    else
                    {

                        break;

                    }

                }

            });

        }

        //Funcs

        public static void Setup<T>(GetReturnValue<T> TheRV, Func<T> TheFunc)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    TheRV.ReturnValue = TheFunc();

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<T> SetupFunc<T>(Func<T> TheFunc)
        {

            GetReturnValue<T> Ex = new GetReturnValue<T>();

            Setup<T>(Ex, TheFunc);

            return Ex;

        }

        public static void Setup<T, T1>(GetReturnValue<T> TheRV, Func<T1, T> TheFunc, T1 P1)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    TheRV.ReturnValue = TheFunc(P1);

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<T> SetupFunc<T, T1>(Func<T1, T> TheFunc, T1 P1)
        {

            GetReturnValue<T> RV = new GetReturnValue<T>();

            Setup<T, T1>(RV, TheFunc, P1);

            return RV;

        }

        public static void Setup<T, T1, T2>(GetReturnValue<T> TheRV, Func<T1, T2, T> TheFunc, T1 P1, T2 P2)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    TheRV.ReturnValue = TheFunc(P1, P2);

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<T> SetupFunc<T, T1, T2>(Func<T1, T2, T> TheFunc, T1 P1, T2 P2)
        {

            GetReturnValue<T> RV = new GetReturnValue<T>();

            Setup<T, T1, T2>(RV, TheFunc, P1, P2);

            return RV;

        }

        public static void Setup<T, T1, T2, T3>(GetReturnValue<T> TheRV, Func<T1, T2, T3, T> TheFunc, T1 P1, T2 P2, T3 P3)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    TheRV.ReturnValue = TheFunc(P1, P2, P3);

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<T> SetupFunc<T, T1, T2, T3>(Func<T1, T2, T3, T> TheFunc, T1 P1, T2 P2, T3 P3)
        {

            GetReturnValue<T> RV = new GetReturnValue<T>();

            Setup<T, T1, T2, T3>(RV, TheFunc, P1, P2, P3);

            return RV;

        }

        public static void Setup<T, T1, T2, T3, T4>(GetReturnValue<T> TheRV, Func<T1, T2, T3, T4, T> TheFunc, T1 P1, T2 P2, T3 P3, T4 P4)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    TheRV.ReturnValue = TheFunc(P1, P2, P3, P4);

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<T> SetupFunc<T, T1, T2, T3, T4>(Func<T1, T2, T3, T4, T> TheFunc, T1 P1, T2 P2, T3 P3, T4 P4)
        {

            GetReturnValue<T> RV = new GetReturnValue<T>();

            Setup<T, T1, T2, T3, T4>(RV, TheFunc, P1, P2, P3, P4);

            return RV;

        }

        //Reflection

        public static void Setup(GetReturnValue<object> TheRV, Delegate TheDelegate, params object[] TheParams)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    object ReturnValue = TheDelegate.DynamicInvoke(TheParams);

                    if(ReturnValue != null)
                        TheRV.ReturnValue = ReturnValue;
                    else
                        TheRV.SetInActive();

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<object> SetupDelegate(Delegate TheDelegate, params object[] TheParams)
        {

            GetReturnValue<object> RV = new GetReturnValue<object>();

            Setup(RV, TheDelegate, TheParams);

            return RV;

        }

        static Type[] GetTypes(object[] TheObjects)
        {

            Type[] FoundTypes = new Type[TheObjects.Length];

            for(int i = 0; i < TheObjects.Length; ++i)
            {

                FoundTypes[i] = TheObjects[i].GetType();

            }

            return FoundTypes;

        }

        public static void Setup(GetReturnValue<object> TheRV, object TheInstance, string TheMethodName, Type[] TypeParams, params object[] TheParams)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    Type InstanceType = TheInstance.GetType();

                    bool HasParams = TheParams != null && TheParams.Length > 0;

                    bool HasTypeParameters = TypeParams != null && TypeParams.Length > 0;

                    if(HasParams)
                    {

                        MethodInfo MI = InstanceType.GetMethod(TheMethodName, GetTypes(TheParams));

                        if(HasTypeParameters)
                            MI = MI.MakeGenericMethod(TypeParams);

                        object ReturnValue = MI.Invoke(TheInstance, TheParams);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }
                    else
                    {

                        MethodInfo MI = InstanceType.GetMethod(TheMethodName);

                        if(HasTypeParameters)
                            MI = MI.MakeGenericMethod(TypeParams);

                        object ReturnValue = MI.Invoke(TheInstance, TheParams);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<object> SetupInvocation(object TheInstance, string TheMethodName, Type[] TypeParams, params object[] TheParams)
        {

            GetReturnValue<object> RV = new GetReturnValue<object>();

            Setup(RV, TheInstance, TheMethodName, TypeParams, TheParams);

            return RV;

        }

        public static void Setup(GetReturnValue<object> TheRV, object TheInstance, MethodInfo TheMethodInfo, Type[] TypeParams, params object[] TheParams)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    Type InstanceType = TheInstance.GetType();

                    bool HasParams = TheParams != null && TheParams.Length > 0;

                    bool HasTypeParameters = TypeParams != null && TypeParams.Length > 0;

                    if(HasParams)
                    {

                        if(HasTypeParameters)
                            TheMethodInfo = TheMethodInfo.MakeGenericMethod(TypeParams);

                        object ReturnValue = TheMethodInfo.Invoke(TheInstance, TheParams);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }
                    else
                    {

                        if(HasTypeParameters)
                            TheMethodInfo = TheMethodInfo.MakeGenericMethod(TypeParams);

                        object ReturnValue = TheMethodInfo.Invoke(TheInstance, TheParams);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<object> SetupInvocation(object TheInstance, MethodInfo TheMethodInfo, Type[] TypeParams, params object[] TheParams)
        {

            GetReturnValue<object> RV = new GetReturnValue<object>();

            Setup(RV, TheInstance, TheMethodInfo, TypeParams, TheParams);

            return RV;

        }

        public static void Setup(GetReturnValue<object> TheRV, object TheInstance, BindingFlags TheInvokeAttr, Binder TheBinder, CultureInfo TheCulture, string TheMethodName, Type[] TypeParams, params object[] TheParams)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    Type InstanceType = TheInstance.GetType();

                    bool HasParams = TheParams != null || TheParams.Length > 0;

                    bool HasTypeParameters = TypeParams != null && TypeParams.Length > 0;

                    if(HasParams)
                    {

                        MethodInfo MI = InstanceType.GetMethod(TheMethodName, GetTypes(TheParams));

                        if(HasTypeParameters)
                            MI = MI.MakeGenericMethod(TypeParams);

                        object ReturnValue = MI.Invoke(TheInstance, TheInvokeAttr, TheBinder, TheParams, TheCulture);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }
                    else
                    {

                        MethodInfo MI = InstanceType.GetMethod(TheMethodName);

                        if(HasTypeParameters)
                            MI = MI.MakeGenericMethod(TypeParams);

                        object ReturnValue = MI.Invoke(TheInstance, TheInvokeAttr, TheBinder, null, TheCulture);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<object> SetupInvocation(object TheInstance, BindingFlags TheInvokeAttr, Binder TheBinder, CultureInfo TheCulture, string TheMethodName, Type[] TypeParams, params object[] TheParams)
        {

            GetReturnValue<object> RV = new GetReturnValue<object>();

            Setup(RV, TheInstance, TheInvokeAttr, TheBinder, TheCulture, TheMethodName, TypeParams, TheParams);

            return RV;

        }

        public static void Setup(GetReturnValue<object> TheRV, object TheInstance, BindingFlags TheInvokeAttr, Binder TheBinder, CultureInfo TheCulture, MethodInfo TheMethodInfo, Type[] TypeParams, params object[] TheParams)
        {

            ThreadPool.QueueUserWorkItem(TheState =>
            {

                TheRV.Reset();

                try
                {

                    Type InstanceType = TheInstance.GetType();

                    bool HasParams = TheParams != null || TheParams.Length > 0;

                    bool HasTypeParameters = TypeParams != null && TypeParams.Length > 0;

                    if(HasParams)
                    {

                        if(HasTypeParameters)
                            TheMethodInfo = TheMethodInfo.MakeGenericMethod(TypeParams);

                        object ReturnValue = TheMethodInfo.Invoke(TheInstance, TheInvokeAttr, TheBinder, TheParams, TheCulture);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }
                    else
                    {

                        if(HasTypeParameters)
                            TheMethodInfo = TheMethodInfo.MakeGenericMethod(TypeParams);

                        object ReturnValue = TheMethodInfo.Invoke(TheInstance, TheInvokeAttr, TheBinder, null, TheCulture);

                        if(ReturnValue != null)
                            TheRV.ReturnValue = ReturnValue;
                        else
                            TheRV.SetInActive();

                    }

                }
                catch(Exception e)
                {

                    TheRV.Exception = e;

                }

            });

        }

        public static GetReturnValue<object> SetupInvocation(object TheInstance, BindingFlags TheInvokeAttr, Binder TheBinder, CultureInfo TheCulture, MethodInfo TheMethodInfo, Type[] TypeParams, params object[] TheParams)
        {

            GetReturnValue<object> RV = new GetReturnValue<object>();

            Setup(RV, TheInstance, TheInvokeAttr, TheBinder, TheCulture, TheMethodInfo, TypeParams, TheParams);

            return RV;

        }

    }

}
