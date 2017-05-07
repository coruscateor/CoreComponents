using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public static class Utils
    {

        public static void Use(Action TryAction, Action FinallyAction)
        {

            try
            {

                TryAction();

            }
            finally
            {

                FinallyAction();

            }

        }

        public static async Task UseAsync(Action TryAction, Action FinallyAction)
        {

            await Task.Run(() =>
            {

                try
                {

                    TryAction();

                }
                finally
                {

                    FinallyAction();

                }

            });

        }

        public static void Use<T>(T UsingObject, Action<T> TryAction, Action<T> FinallyAction)
        {

            try
            {

                TryAction(UsingObject);

            }
            finally
            {

                FinallyAction(UsingObject);

            }

        }

        public static async Task UseAsync<T>(T UsingObject, Action<T> TryAction, Action<T> FinallyAction)
        {

            await Task.Run(() =>
            {

                try
                {

                    TryAction(UsingObject);

                }
                finally
                {

                    FinallyAction(UsingObject);

                }

            });

        }

        public static string YesNo(bool Value)
        {

            if(Value)
                return "Yes";

            return "No";

        }

        public static int GetTicksRemaining()
        {

            unchecked
            {

                return int.MaxValue - Environment.TickCount;

            }

        }

        //https://msdn.microsoft.com/en-us/library/system.environment.tickcount%28v=vs.110%29.aspx

        //https://msdn.microsoft.com/en-us/library/system.datetime.ticks.aspx

        //public static DateTime TicksElapseAt()
        //{

        //    return DateTime.Now.AddTicks((long)int.MaxValue - Environment.TickCount);

        //}

        //public static DateTime TicksElapseAtUtc()
        //{

        //    return DateTime.UtcNow.AddTicks((long)int.MaxValue - Environment.TickCount);

        //}

        //public static TimeSpan TicksElapseTimeSpan()
        //{

        //    return new TimeSpan((long)int.MaxValue - Environment.TickCount);

        //}

    }

}
