using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Tables
{

    public struct CellValue<T>
    {

        T myValue;

        //int myIndex;

        bool myIsEmpty;

        static readonly bool myIsClass;

        static CellValue()
        {

            myIsClass = typeof(T).IsClass;

        }

        //public CellValue() //int TheIndex = -1
        //{

        //    myValue = default(T);

        //    //myIndex = TheIndex;

        //    myIsEmpty = false;

        //}

        public CellValue(T TheValue) //, int TheIndex = -1
        {

            myValue = TheValue;

            //myIndex = TheIndex;

            if(myIsClass)
            {

                myIsEmpty = object.Equals(TheValue, null);

            }
            else
            {

                myIsEmpty = false;
 
            }

        }

        //public CellValue(T? TheNullable)
        //{
            
        //    myIsEmpty = TheNullable.HasValue;

        //    if(TheNullable.HasValue)
        //    {

        //        myValue = TheNullable.Value;

        //    }
        //    else
        //    {

        //        myValue = default(T);

        //    }

        //}

        public static bool IsClass
        {

            get
            {

                return myIsClass;

            }

        }

        public T Value
        {

            get
            {

                return myValue;

            }

        }

        //public int Index
        //{

        //    get
        //    {

        //        return myIndex;

        //    }

        //}

        public bool IsEmpty
        {

            get
            {

                return myIsEmpty;

            }

        }

    }

}
