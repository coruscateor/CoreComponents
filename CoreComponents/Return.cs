using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CoreComponents
{

    public static class Return
    {

        public static object NullIfNegative(short value)
        {

            if (value <= -1)
            {

                return null;

            } else
            {

                return value;

            }

        }

        public static object NullIfNegative(int value)
        {

            if (value <= -1)
            {

                return null;

            } else
            {

                return value;

            }

        }

        public static object NullIfNegative(long value)
        {

            if (value <= -1)
            {

                return null;

            } else
            {

                return value;

            }

        }

        public static object NullIfEmpty(string value)
        {

            if (value.Length <= -1)
            {

                return null;

            } else
            {

                return value;

            }

        }

        public static int ArrayIndex<T>(T[] array, T item)
        {

            int index = 0;

            foreach (T arrayitem in array)
            {

                if (arrayitem.Equals(item))
                {

                    return index;

                }

                index++;

            }

            return -1;

        }

        public static bool IsNull<TObj>(TObj Obj)
        {

            return object.Equals(Obj, default(TObj));

        }

        public static bool IsNull(object Obj)
        {

            return object.Equals(Obj, null);

        }


        public static bool IsNotNull<TObj>(TObj Obj)
        {

            return !object.Equals(Obj, default(TObj));

        }

        public static bool IsNotNull(object Obj)
        {

            return !object.Equals(Obj, null);

        }

        public static bool IsInSet<TItem>(IEnumerable<TItem> Set, TItem CheckedItem)
        {

            foreach (TItem item in Set)
            {

                if (object.Equals(item, CheckedItem))
                    return true;

            }

            return false;

        }
        
        public static bool IsInNamedSet<TItem>(IEnumerable<TItem> Set, TItem CheckedItem) where TItem : IReadonlyHaveName
        {

            foreach (TItem item in Set)
            {

                if (item.Name == CheckedItem.Name)
                    return true;

            }

            return false;

        }

        public static bool IsGreaterThanZero(int item)
        {

            return item > 0;

        }

        public static bool IsLessThanZero(int item)
        {

            return item < 0;

        }

        /*
        public static TObj Null<TObj>()
        {

            return default(TObj);

        }
        */

        public static string CommaDelimit(object[] TheObjects) 
        {

            if (TheObjects.Length > 0)
            {

                StringBuilder SB = new StringBuilder();

                int MaxIndex = TheObjects.Length - 1;

                for (int i = 0; i < MaxIndex; i++)
                {

                    SB.Append(TheObjects[i]);

                    if (i < MaxIndex)
                    {

                        SB.Append(", ");

                    }
                   

                }

            }

            return "";

        }

        public static string CommaDelimitPrams(params object[] TheObjects) 
        {

            return CommaDelimit(TheObjects);

        }

    }

}