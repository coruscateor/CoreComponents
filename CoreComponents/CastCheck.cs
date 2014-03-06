using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class CastCheck
    {

        public static void Attempt<T>(object FromObject, Action<T> OnSuccess)
        {

            T Item = default(T);

            try
            {

                Item = (T)FromObject;

            }
            catch
            {

                return;

            }

            OnSuccess(Item);

        }

        public static void Attempt<TFrom, TTo>(TFrom FromObject, Action<TTo> OnSuccess)
        {

            TTo Item = default(TTo);

            try
            {

                Item = (TTo)Convert.ChangeType(FromObject, typeof(TTo));

            }
            catch
            {

                return;

            }

            OnSuccess(Item);

        }

        public static TReturn? Attempt<TTo, TReturn>(object FromObject, Func<TTo, TReturn> OnSuccess) where TReturn : struct
        {

            TTo Item = default(TTo);

            bool HasBeenSet = false;

            try
            {

                Item = (TTo)FromObject;

                HasBeenSet = true;

            }
            catch
            {
            }

            if (HasBeenSet)
            {

                return OnSuccess(Item);

            }

            return null;

        }

        public static TReturn? Attempt<TTo, TFrom, TReturn>(TFrom FromObject, Func<TTo, TReturn> OnSuccess) where TReturn : struct
        {

            TTo Item = default(TTo);

            bool HasBeenSet = false;

            try
            {

                Item = (TTo)Convert.ChangeType(FromObject, typeof(TTo));

                HasBeenSet = true;

            }
            catch
            {
            }

            if (HasBeenSet)
            {

                return OnSuccess(Item);

            }

            return null;

        }

        public static TReturn Attempt<TTo, TReturn>(object FromObject, Func<TTo, TReturn> OnSuccess, out bool Sucessfull)
        {

            TTo Item = default(TTo);

            Sucessfull = false;

            try
            {

                Item = (TTo)FromObject;

                Sucessfull = true;

            }
            catch
            {
            }

            if (Sucessfull)
            {

                return OnSuccess(Item);

            }

            return default(TReturn);

        }

        public static TReturn Attempt<TTo, TFrom, TReturn>(TFrom FromObject, Func<TTo, TReturn> OnSuccess, out bool Sucessfull)
        {

            TTo Item = default(TTo);

            Sucessfull = false;

            try
            {

                Item = (TTo)Convert.ChangeType(FromObject, typeof(TTo));

                Sucessfull = true;

            }
            catch
            {
            }

            if (Sucessfull)
            {

                return OnSuccess(Item);

            }

            return default(TReturn);

        }

        public static T? Attempt<T>(object FromObject) where T : struct
        {

            try
            {

                return (T)FromObject;

            }
            catch
            {
            }

            return null;

        }

        public static TTo? Attempt<TFrom, TTo>(TFrom FromObject) where TTo : struct
        {

            try
            {

                return (TTo)Convert.ChangeType(FromObject, typeof(TTo));

            }
            catch
            {
            }

            return null;

        }

        public static bool AreCompatable<T>(object FromObject)
        {

            try
            {

                T Item = (T)FromObject;

                return true;

            }
            catch
            {
            }

            return false;

        }

        public static bool AreCompatable<TFrom, TTo>(TFrom FromObject)
        {

            try
            {

                TTo Item = (TTo)Convert.ChangeType(FromObject, typeof(TTo));

                return true;

            }
            catch
            {
            }

            return false;

        }

        public static bool Contains<T>(IEnumerable<object> TheObjects)
        {

            Type TheType = typeof(T);

            foreach (object Item in TheObjects)
            {

                if (Item.GetType() == TheType)
                    return true;

            }

            return false;

        }

        public static bool Contains<T>(params object[] TheObjects)
        {

            return Contains<T>(TheObjects);

        }

        public static bool Contains(Type TheType, IEnumerable<object> TheObjects)
        {

            foreach (object Item in TheObjects)
            {

                if (Item.GetType() == TheType)
                    return true;

            }

            return false;

        }

        public static bool Contains(Type TheType, params object[] TheObjects)
        {

            return Contains(TheType, TheObjects);

        }

    }

}
