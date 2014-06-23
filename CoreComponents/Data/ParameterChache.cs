﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{

    public class ParameterChache<TParameter>
           where TParameter : DbParameter, new()
    {

        protected Queue<TParameter> myParameterQueue = new Queue<TParameter>();

        public ParameterChache()
        {
        }

        public TParameter TryFetch()
        {

            if(myParameterQueue.Count > 0)
            {

                return myParameterQueue.Dequeue();

            }
            else
            {

                return new TParameter();

            }

        }

        public TParameter TryFetch(object TheValue)
        {

            if(myParameterQueue.Count > 0)
            {

                TParameter NewParameter = new TParameter();

                NewParameter.Value = TheValue;

                return NewParameter;


            }

            TParameter Item = myParameterQueue.Dequeue();

            Item.Value = TheValue;

            if(Item.ParameterName != "")
                Item.ParameterName = "";

            return Item;

        }

        public TParameter TryFetch(object TheValue, string TheName)
        {

            if(myParameterQueue.Count > 0)
            {

                TParameter NewParameter = new TParameter();

                NewParameter.Value = TheValue;

                NewParameter.ParameterName = TheName;

                return NewParameter;

            }

            TParameter Item = myParameterQueue.Dequeue();

            Item.Value = TheValue;

            Item.ParameterName = TheName;

            return Item;

        }

        public void FetchInto(DbParameterCollection TheParameterCollection)
        {

            if(myParameterQueue.Count > 0)
            {

                TheParameterCollection.Add(myParameterQueue.Dequeue());

            }
            else
            {

                TheParameterCollection.Add(new TParameter());

            }

        }

        public void FetchInto(DbParameterCollection TheParameterCollection, int NumberToFetch)
        {

            for (; NumberToFetch > 0; NumberToFetch--)
            {

                if(myParameterQueue.Count > 0)
                {

                    TheParameterCollection.Add(myParameterQueue.Dequeue());

                }
                else
                {

                    TheParameterCollection.Add(new TParameter());

                }

            }

        }

        public void Put(TParameter TheParameter)
        {

            myParameterQueue.Enqueue(TheParameter);

        }

        public bool RetriveFrom(DbParameterCollection TheParameterCollection)
        {

            int LastIndex = TheParameterCollection.Count - 1;

            if (LastIndex > 0)
            {

                myParameterQueue.Enqueue((TParameter)TheParameterCollection[LastIndex]);

                TheParameterCollection.RemoveAt(LastIndex);

                return true;

            }

            return false;

        }

        public bool RetriveFrom(DbParameterCollection TheParameterCollection, int NumberToRemove)
        {

            int LastIndex = TheParameterCollection.Count - 1;

            int DifferenceIndex = TheParameterCollection.Count - 1 - NumberToRemove;

            if (DifferenceIndex < 1)
                return false;

            while (DifferenceIndex > 0)
            {

                myParameterQueue.Enqueue((TParameter)TheParameterCollection[LastIndex]);

                TheParameterCollection.RemoveAt(LastIndex);

                DifferenceIndex--;

            }

            return true;

        }

        public bool Clear(DbParameterCollection TheParameterCollection)
        {

            if (TheParameterCollection.Count > 0)
            {

                foreach (DbParameter Item in TheParameterCollection)
                {

                    if (Item.ParameterName != string.Empty)
                        Item.ParameterName = string.Empty;

                    myParameterQueue.Enqueue((TParameter)Item);

                }

                TheParameterCollection.Clear();

                return true;

            }

            return false;

        }

    }

}
