using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    //public delegate void GenericEventHandler(EventArgs e);

    //public delegate void MasterMethod<T, R>(T item, R EventCode, GenericEventHandler Handler);

    //This class is for grouping a set of objects with a set of event flags and delegates that correspond to each object added.
    //T - objects
    //R - Event Code
    //E - EventArgs

    //public class InternalObjectsAndEventsList<T, R, E> : IInternalObjectAndEventSet<T, R>
    //{
    //public delegate void GenericEventHandler(E e);

    //This class is for grouping a single object with a set of event flags and delegates.

    //T - the type of item that is tracked, R - the type of the EventCode 

    public class InternalObjectAndEventsPairing<T, R, Handler>
    {

        public delegate void MasterMethod(T item, R EventCode, /*GenericEventHandler*/ Handler TheHandler);

        T Object; //The object being tracked

        MasterMethod AddMethod; //The "Master" method to run when a method is added. 

        MasterMethod RemoveMethod; //The "Master" method to run when a method is removed.

        Dictionary<R, Handler> Subscriptionlist = new Dictionary<R, Handler>();

        int ListCap;

        public InternalObjectAndEventsPairing(T Object, MasterMethod AddMethod, MasterMethod RemoveMethod)
        {

            this.Object = Object;

            ListCap = int.MaxValue;

            SetAddAndRemove(AddMethod, RemoveMethod);

        }

        public InternalObjectAndEventsPairing(T Object, MasterMethod AddMethod, MasterMethod RemoveMethod, int ListCapacity)
        {
            this.Object = Object;

            ListCap = ListCapacity;

            SetAddAndRemove(AddMethod, RemoveMethod);

        }

        public T Item
        {
            get
            {
                return Object;

            }

        }


        public void SetAddAndRemove(MasterMethod AddMethod, MasterMethod RemoveMethod)
        {

            this.AddMethod = AddMethod;

            this.RemoveMethod = RemoveMethod;

        }

        public void Subscribe(R EventCode, Handler TheHandler)
        {

            foreach (KeyValuePair<R, Handler> EventDelegateCodeSet in Subscriptionlist)
            {

                if (EventDelegateCodeSet.Key.Equals(EventCode))
                {

                    RemoveMethod(Object, EventDelegateCodeSet.Key, EventDelegateCodeSet.Value); //Deregester if found

                    continue;

                }

            }

            AddMethod(Object, EventCode, TheHandler);

            Subscriptionlist.Add(EventCode, TheHandler);

        }

        public void UnSubscribe(R EventCode)
        {

            foreach (KeyValuePair<R, Handler> EventDelegateCodeSet in Subscriptionlist)
            {

                if (EventDelegateCodeSet.Key.Equals(EventCode))
                {

                    RemoveMethod(Object, EventDelegateCodeSet.Key, EventDelegateCodeSet.Value); //Deregester if found

                    Subscriptionlist.Remove(EventDelegateCodeSet.Key);

                    continue;
                }

            }

        }

        public bool IsSubscribedTo(R EventCode)
        {

            foreach (KeyValuePair<R, Handler> EventDelegateCodeSet in Subscriptionlist)
            {

                if (EventDelegateCodeSet.Key.Equals(EventCode))
                {

                    return true;

                }

            }

            return false;

        }

    }

}
