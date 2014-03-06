using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public static class ArrayCopier<TArray>
    {

        public static void Copy(TArray[] ArrayFrom, TArray[] ArrayTo)
        {

            if(ArrayFrom.LongLength > ArrayTo.LongLength)
                throw new Exception("ArrayFrom must be less than or equal to ArrayTo");

            for(long i = 0; i < ArrayFrom.LongLength; i++)
            {

                ArrayTo[i] = ArrayFrom[i];

            }

        }

        public static TArray[] Clone(TArray[] ArrayFrom)
        {

            TArray[] NewArray = new TArray[ArrayFrom.LongLength];

            Copy(ArrayFrom, NewArray);

            return NewArray;

        }

        public static void Copy(TArray[] ArrayFrom, TArray[] ArrayTo, long StartIndex)
        {

            if(ArrayFrom.LongLength > ArrayTo.LongLength)
                throw new Exception("ArrayFrom must be less than or equal to ArrayTo");

            if(StartIndex < 0)
                throw new Exception("Start Index must be greater than zero");

            for(long i = StartIndex; i < ArrayFrom.LongLength; i++)
            {

                ArrayTo[i] = ArrayFrom[i];

            }

        }

        public static void Copy(TArray[] ArrayFrom, TArray[] ArrayTo, int StartIndex)
        {

            if(ArrayFrom.LongLength > ArrayTo.LongLength)
                throw new Exception("ArrayFrom must be less than or equal to ArrayTo");

            if(StartIndex < 0)
                throw new Exception("Start Index must be greater than zero");

            for(long i = StartIndex; i < ArrayFrom.LongLength; i++)
            {

                ArrayTo[i] = ArrayFrom[i];

            }

        }

        public static void Copy(TArray[] ArrayFrom, TArray[] ArrayTo, long StartIndex, long FinishIndex)
        {

            if(ArrayFrom.LongLength > ArrayTo.LongLength)
                throw new Exception("ArrayFrom must be less than or equal to ArrayTo");

            if(StartIndex < 0)
                throw new Exception("Start Index must be greater than zero");

            if(FinishIndex > ArrayFrom.LongLength)
                throw new Exception("FinishIndex must be less than ArrayFrom LongLength");

            if(FinishIndex > ArrayTo.LongLength)
                throw new Exception("FinishIndex must be less than ArrayTo LongLength");

            for(long i = StartIndex; i <= FinishIndex; i++)
            {

                ArrayTo[i] = ArrayFrom[i];

            }

        }

        public static void Copy(TArray[] ArrayFrom, TArray[] ArrayTo, int StartIndex, int FinishIndex)
        {

            if(ArrayFrom.LongLength > ArrayTo.LongLength)
                throw new Exception("ArrayFrom must be less than or equal to ArrayTo");

            if(StartIndex < 0)
                throw new Exception("Start Index must be greater than zero");

            if(FinishIndex > ArrayFrom.LongLength)
                throw new Exception("FinishIndex must be less than ArrayFrom LongLength");

            if(FinishIndex > ArrayTo.LongLength)
                throw new Exception("FinishIndex must be less than ArrayTo LongLength");

            for(long i = StartIndex; i <= FinishIndex; i++)
            {

                ArrayTo[i] = ArrayFrom[i];

            }

        }

        //public static TArray[] CloneTo(List<TArray> ListFrom)
        //{

        //    TArray[] NewArray = new TArray[ArrayFrom.LongLength];

        //    Copy(ArrayFrom, NewArray);

        //    return NewArray;

        //}

        public static TArray[] PartalClone(TArray[] ArrayFrom, long StartIndex)
        {

            TArray[] NewArray = new TArray[ArrayFrom.LongLength];

            Copy(ArrayFrom, NewArray, StartIndex);

            return NewArray;

        }

        public static TArray[] PartalClone(TArray[] ArrayFrom, int StartIndex)
        {

            TArray[] NewArray = new TArray[ArrayFrom.LongLength];

            Copy(ArrayFrom, NewArray, StartIndex);

            return NewArray;

        }

        public static TArray[] PartalClone(TArray[] ArrayFrom, long StartIndex, long FinishIndex)
        {

            TArray[] NewArray = new TArray[ArrayFrom.LongLength];

            Copy(ArrayFrom, NewArray, StartIndex, FinishIndex);

            return NewArray;

        }

        public static TArray[] PartalClone(TArray[] ArrayFrom, int StartIndex, int FinishIndex)
        {

            TArray[] NewArray = new TArray[ArrayFrom.LongLength];

            Copy(ArrayFrom, NewArray, StartIndex, FinishIndex);

            return NewArray;

        }

        public static TArray[] Extract(TArray[] ArrayFrom, long StartIndex)
        {

            TArray[] NewArray = new TArray[ArrayFrom.LongLength - (StartIndex + 1)];

            for(long i = StartIndex; i <= ArrayFrom.LongLength; i++)
            {

                NewArray[i] = ArrayFrom[i];

            }

            return NewArray;

        }

        public static TArray[] Extract(TArray[] ArrayFrom, long StartIndex, long FinishIndex)
        {

            long FinishLength = FinishIndex + 1;

            TArray[] NewArray = new TArray[FinishLength - StartIndex + 1];

            for(long i = StartIndex; i < FinishLength; i++)
            {

                NewArray[i] = ArrayFrom[i];

            }

            return NewArray;

        }

        public static TArray[] Extract(TArray[] ArrayFrom, int StartIndex, int FinishIndex)
        {

            int FinishLength = FinishIndex + 1;

            TArray[] NewArray = new TArray[FinishLength - StartIndex + 1];

            for(long i = StartIndex; i < FinishLength; i++)
            {

                NewArray[i] = ArrayFrom[i];

            }

            return NewArray;

        }

    }

}
