using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application.Messaging
{
    public class ReadonlyCacheMessage : IMessageLine
    {

        protected static string statDelimiter = " - ";

        protected DateTime myTimeStamp;

        protected string myMessage;

        public ReadonlyCacheMessage()
        {

            InitaliseTime();

        }

        public ReadonlyCacheMessage(string TheMessage)
        {

            myMessage = TheMessage;

            InitaliseTime();

        }

        protected void InitaliseTime()
        {

            myTimeStamp = DateTime.Now;

        }

        public DateTime TimeStamp
        {

            get
            {

                return myTimeStamp;

            }


        }

        public string Message
        {

            get
            {

                return myMessage;

            }

        }

        public override string ToString()
        {

            return GetOut(myTimeStamp, myMessage);

        }

        public static string GetOutNow(string TheMessage)
        {

            return GetOut(DateTime.Now, TheMessage);

        }


        public static string GetOut(DateTime TimeStamp, string TheMessage)
        {

            return TimeStamp.ToString() + statDelimiter + TheMessage + "\n";

        }

        public static string TheDelimiter
        {

            get
            {

                return statDelimiter;

            }
            set
            {

                statDelimiter = value;

            }

        }


    }
}
