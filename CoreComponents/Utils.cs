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

        public static async void UseAsync(Action TryAction, Action FinallyAction)
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

        public static async void UseAsync<T>(T UsingObject, Action<T> TryAction, Action<T> FinallyAction)
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

    }

}
