using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items.Extensions
{

    public static class Array1DExtensions
    {

        public static T[] Add<T>(this T[] array, T item)
        {

            int length = array.Length;

            int newLength = array.Length + 1;

            T[] newArray = new T[newLength];

            for(int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[newLength - 1] = item;

            return newArray;

        }

        public static bool Contains<T>(this T[] array, T item, IEqualityComparer<T> eq)
        {

            for(int i = 0; i < array.Length; i++)
            {

                if(eq.Equals(array[i], item))
                    return true;

            }

            return false;

        }

        public static bool Contains<T>(this T[] array, T item, Func<T, T, bool> func)
        {

            for(int i = 0; i < array.Length; i++)
            {

                if(func(array[i], item))
                    return true;

            }

            return false;

        }

        public static int IndexOf<T>(this T[] array, T item, IEqualityComparer<T> eq)
        {

            for(int i = 0; i < array.Length; i++)
            {

                if(eq.Equals(array[i], item))
                    return i;

            }

            return -1;

        }

        public static int IndexOf<T>(this T[] array, T item, Func<T, T, bool> func)
        {

            for(int i = 0; i < array.Length; i++)
            {

                if(func(array[i], item))
                    return i;

            }

            return -1;

        }

        public static bool IndexOf<T>(this T[] array, T item, IEqualityComparer<T> eq, out int index)
        {

            for(int i = 0; i < array.Length; i++)
            {

                if(eq.Equals(array[i], item))
                {

                    index = i;

                    return true;

                }

            }

            index = -1;

            return false;

        }

        public static bool IndexOf<T>(this T[] array, T item, Func<T, T, bool> func, out int index)
        {

            for(int i = 0; i < array.Length; i++)
            {

                if(func(array[i], item))
                {

                    index = i;

                    return true;

                }

            }

            index = -1;

            return false;

        }

        public static T[] Remove<T>(this T[] array, T item, IEqualityComparer<T> eq)
        {

            int length = array.Length;

            if(length < 1)
                return array;

            int newLength = array.Length - 1;

            T[] newArray = new T[newLength];

            int index;

            if(!array.IndexOf(item, eq, out index))
                throw new ArgumentException();

            for(int i = 0; i < index; i++)
            {

                newArray[i] = array[i];

            }

            for(int i = index + 1; i < newLength; i++)
            {

                newArray[i - 1] = array[i];

            }

            return newArray;

        }

        public static T[] Remove<T>(this T[] array, T item, Func<T, T, bool> func)
        {

            int length = array.Length;

            if(length < 1)
                return array;

            int newLength = array.Length - 1;

            T[] newArray = new T[newLength];

            int index;

            if(!array.IndexOf(item, func, out index))
                throw new ArgumentException();

            for(int i = 0; i < index; i++)
            {

                newArray[i] = array[i];

            }

            for(int i = index + 1; i < newLength; i++)
            {

                newArray[i - 1] = array[i];

            }

            return newArray;

        }

        public static T[] RemoveFirst<T>(this T[] array)
        {

            int length = array.Length;

            if(length < 1)
                return array;

            int newLength = array.Length - 1;

            T[] newArray = new T[newLength];

            for(int i = 0; i < newLength; i++)
                newArray[i] = array[i + 1];

            return newArray;

        }

        public static T[] RemoveLast<T>(this T[] array)
        {

            int length = array.Length;

            if(length < 1)
                return array;

            int newLength = array.Length - 1;

            T[] newArray = new T[newLength];

            for(int i = 0; i < newLength; i++)
                newArray[i] = array[i];

            return newArray;

        }

        public static T[] Extend<T>(this T[] array)
        {

            int length = array.Length;

            if(length < 1)
                return array;

            int newLength = array.Length + 1;

            T[] newArray = new T[newLength];

            for(int i = 0; i < length; i++)
                newArray[i] = array[i];

            return newArray;

        }

        public static T[] Extend<T>(this T[] array, int count)
        {

            if(count < 1)
                throw new ArgumentException();

            int length = array.Length;

            if(length < 1)
                return array;

            int newLength = array.Length + count;

            T[] newArray = new T[newLength];

            for(int i = 0; i < length; i++)
                newArray[i] = array[i];

            return newArray;

        }

    }

}
