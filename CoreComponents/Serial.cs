using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    public static class Serial
    {

        public static void Invoke(Action Action1, Action Action2)
        {

            Action1();

            Action2();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3)
        {

            Action1();

            Action2();

            Action3();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4)
        {

            Action1();

            Action2();

            Action3();

            Action4();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5)
        {

            Action1();

            Action2();

            Action3();

            Action4();

            Action5();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6)
        {

            Action1();

            Action2();

            Action3();

            Action4();

            Action5();

            Action6();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7)
        {

            Action1();

            Action2();

            Action3();

            Action4();

            Action5();

            Action6();

            Action7();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Action Action8)
        {

            Action1();

            Action2();

            Action3();

            Action4();

            Action5();

            Action6();

            Action7();

            Action8();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Action Action8, Action Action9)
        {

            Action1();

            Action2();

            Action3();

            Action4();

            Action5();

            Action6();

            Action7();

            Action8();

            Action9();

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Action Action8, Action Action9, Action Action10)
        {

            Action1();

            Action2();

            Action3();

            Action4();

            Action5();

            Action6();

            Action7();

            Action8();

            Action9();

            Action10();

        }

        //Quit is true??

        public static void Invoke(Action Action1, Action Action2, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action5();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action5();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action6();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action5();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action6();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action7();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Action Action8, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action5();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action6();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action7();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action8();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Action Action8, Action Action9, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action5();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action6();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action7();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action8();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action9();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(Action Action1, Action Action2, Action Action3, Action Action4, Action Action5, Action Action6, Action Action7, Action Action8, Action Action9, Action Action10, Func<Exception, bool> ExceptionFunc)
        {

            try
            {

                Action1();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action2();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action3();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action4();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action5();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action6();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action7();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action8();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action9();

            }
            catch(Exception e)
            {

                if(ExceptionFunc(e))
                    return;

            }

            try
            {

                Action10();

            }
            catch(Exception e)
            {

                ExceptionFunc(e);

            }

        }

        public static void Invoke(IEnumerable<Action> Actions)
        {

            foreach(var Item in Actions)
            {

                Item();

            }

        }

        public static void Invoke(IEnumerable<Action> Actions, Func<Exception, bool> ExceptionFunc)
        {

            foreach(var Item in Actions)
            {

                try
                {

                    Item();

                }
                catch(Exception e)
                {

                    if(ExceptionFunc(e))
                        return;

                }

            }

        }

        public static void InvokeParams(params Action[] Actions)
        {

            for(long i = 0; i < Actions.LongLength; ++i)
            {

                Actions[i]();

            }

        }

        public static void InvokeParams(Func<Exception, bool> ExceptionFunc, params Action[] Actions)
        {

            for(long i = 0; i < Actions.LongLength; ++i)
            {

                try
                {

                    Actions[i]();

                }
                catch(Exception e)
                {

                    if(ExceptionFunc(e))
                        return;

                }

            }

        }

        public static void Invoke<T>(Func<T> Func1, Action<T> Last)
        {

            Last(Func1());

        }

        public static void Invoke<T>(Func<T> Func1, Func<T, T> Func2, Action<T> Last)
        {

            Last(Func2(Func1()));

        }

        public static void Invoke<T>(Func<T> Func1, Func<T, T> Func2, Func<T, T> Func3, Action<T> Last)
        {

            Last(Func3(Func2(Func1())));

        }

        public static void Invoke<T>(Func<T> Func1, Func<T, T> Func2, Func<T, T> Func3, Func<T, T> Func4, Action<T> Last)
        {

            Last(Func4(Func3(Func2(Func1()))));

        }

        public static void Invoke<T>(Func<T> Func1, Action<T> Last, IEnumerable<Func<T, T>> Funcs)
        {

            T Result = Func1();

            foreach(var Item in Funcs)
            {

                Result = Item(Result);

            }

            Last(Result);

        }

        public static void InvokeParams<T>(Func<T> Func1, Action<T> Last, params Func<T, T>[] Funcs)
        {

            T Result = Func1();

            for(long i = 0; i < Funcs.LongLength; ++i)
            {

                Result = Funcs[i](Result);

            }

            Last(Result);

        }

        public static void Invoke(int First, int Last, Func<int, bool> ForAction)
        {

            if(First > Last)
            {

                for(; First >= Last; --First)
                {

                    if(ForAction(First))
                        return;

                }

            }
            else
            {

                for(; First <= Last; ++First)
                {

                    if(ForAction(First))
                        return;

                }

            }

        }

        public static void Invoke(uint First, uint Last, Func<uint, bool> ForAction)
        {

            if(First > Last)
            {

                for(; First >= Last; --First)
                {

                    if(ForAction(First))
                        return;

                }

            }
            else
            {

                for(; First < Last; ++First)
                {

                    if(ForAction(First))
                        return;

                }

            }

        }

        public static void Invoke(long First, long Last, Func<long, bool> ForAction)
        {

            if(First > Last)
            {

                for(; First >= Last; --First)
                {

                    if(ForAction(First))
                        return;

                }

            }
            else
            {

                for(; First <= Last; ++First)
                {

                    if(ForAction(First))
                        return;

                }

            }

        }

        public static void Invoke(ulong First, ulong Last, Func<ulong, bool> ForAction)
        {

            if(First > Last)
            {

                for(; First >= Last; --First)
                {

                    if(ForAction(First))
                        return;

                }

            }
            else
            {

                for(; First <= Last; ++First)
                {

                    if(ForAction(First))
                        return;

                }

            }

        }

    }

}
