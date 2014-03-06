using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.OOM
{
    public class MonitoredObjectChangedEventArgs<TSender> : SenderEventArgs<TSender>
    {

        object myPreviousObject;

        object myCurrentObject;

        public MonitoredObjectChangedEventArgs(TSender TheSender, object ThePreviousObject, object TheCurrentObject)
            : base(TheSender)
        {

            myPreviousObject = ThePreviousObject;

            myCurrentObject = TheCurrentObject;

        }

        public object PreviousObject 
        {

            get 
            {

                return myPreviousObject;

            }

        }

        public object CurrentObject
        {

            get 
            {

                return myCurrentObject;

            }

        }

        public bool PreviousObjectIsNotNull
        {

            get
            {

                return myPreviousObject != null;

            }

        }

        public bool CurrentObjectIsNotNull
        {

            get
            {

                return myCurrentObject != null;

            }

        }

    }
}
