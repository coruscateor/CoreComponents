using System;
using System.Collections.Generic;
using System.Text;

namespace CoreComponents.Notifications
{

    //public delegate void GenericEventHandler(object sender, EventArgs e);

    //public delegate void MasterMethod<T, R>(T ObjectSubscribedTo, R EventCode, GenericEventHandler Handler);

    //This class is for grouping a set of objects with a set of event flags and delegates that correspond to each object added.

    //MasterMethod AddMethod - delegate passed from the Master method to handle when an a particular event has been .

    //MasterMethod RemoveMethod - 

    public class InternalObjectsAndEventsList<T, R, Handler> : IInternalObjectAndEventSet<T, R, Handler>
    {

        public delegate void MasterMethod(T ObjectSubscribedTo, R EventCode, /*GenericEventHandler Handler*/ Handler TheHandler);

        Dictionary<T, Dictionary<R, /*GenericEventHandler*/ Handler>> InternalList = new Dictionary<T, Dictionary<R, /*GenericEventHandler*/ Handler>>();

        MasterMethod AddMethod;

        MasterMethod RemoveMethod;

        int ListCap;

        public InternalObjectsAndEventsList(MasterMethod AddMethod, MasterMethod RemoveMethod)
        {

            ListCap = int.MaxValue;

            SetAddAndRemove(AddMethod, RemoveMethod);

        }

        public InternalObjectsAndEventsList(int ListCapacity, MasterMethod AddMethod, MasterMethod RemoveMethod)
        {

            ListCap = ListCapacity;

            SetAddAndRemove(AddMethod, RemoveMethod);

        }

        public int ListCapacity
        {

            get
            {

                return ListCap;

            }

            //set
            //{

            //    ListCap = value;

            //}
        }

        public void SetAddAndRemove(MasterMethod AddMethod, MasterMethod RemoveMethod)
        {

            this.AddMethod = AddMethod;

            this.RemoveMethod = RemoveMethod;

        }

        public void Subscribe(T ObjectToBeSubscribedTo, R EventCode, /*GenericEventHandler Handler*/ Handler TheHandler)
        {

            Dictionary<R, /*GenericEventHandler*/ Handler> Subscriptionlist = InternalList[ObjectToBeSubscribedTo];

            //if (!InternalList[ObjectSubscribedTo].Exists())
            if(Subscriptionlist == null)
            {

                InternalList.Add(ObjectToBeSubscribedTo, new Dictionary<R, /*GenericEventHandler*/ Handler>(ListCap));
    
            } else {

                foreach (KeyValuePair<R, /*GenericEventHandler*/ Handler> EventDelegateCodeSet in Subscriptionlist) {

                    if (EventDelegateCodeSet.Key.Equals(EventCode)) {

                        RemoveMethod(ObjectToBeSubscribedTo, EventDelegateCodeSet.Key, EventDelegateCodeSet.Value); //Deregester if found

                        continue;

                    }

                }

            }

            AddMethod(ObjectToBeSubscribedTo, EventCode, TheHandler); //Reregester or inital regesteration

            Subscriptionlist.Add(EventCode, TheHandler);

        }

        public void UnSubscribe(T ObjectSubscribedTo, R EventCode)
        {

            Dictionary<R,/*GenericEventHandler*/ Handler> Subscriptionlist = InternalList[ObjectSubscribedTo];

            //if (!InternalList[ObjectSubscribedTo].Exists())
            if(Subscriptionlist != null)
            {

                foreach (KeyValuePair<R, /*GenericEventHandler*/ Handler> EventDelegateCodeSet in Subscriptionlist)
                {

                    if (EventDelegateCodeSet.Key.Equals(EventCode)) {
                
                        RemoveMethod(ObjectSubscribedTo, EventDelegateCodeSet.Key, EventDelegateCodeSet.Value); //Deregester if found
                        
                        Subscriptionlist.Remove(EventDelegateCodeSet.Key);

                        continue;
                    }

                }

                if (Subscriptionlist.Count < 1)
                {

                    InternalList.Remove(ObjectSubscribedTo);

                }

            }

        }

        public void UnSubscribe(T ObjectSubscribedTo)
        {

            Dictionary<R, /*GenericEventHandler*/ Handler> Subscriptionlist = InternalList[ObjectSubscribedTo];

            if (Subscriptionlist != null)
            {

                foreach (KeyValuePair<R, /*GenericEventHandler*/ Handler> EventDelegateCodeSet in Subscriptionlist)
                {

                    RemoveMethod(ObjectSubscribedTo, EventDelegateCodeSet.Key, EventDelegateCodeSet.Value); //Deregester if found

                    Subscriptionlist.Remove(EventDelegateCodeSet.Key);

                }

                InternalList.Remove(ObjectSubscribedTo);

            }
            
        }

        public bool IsSubscribedTo(T ObjectSubscribedTo)
        {

            return InternalList.ContainsKey(ObjectSubscribedTo);

        }

        public bool IsSubscribedTo(T ObjectSubscribedTo, R EventCode)
        {
            Dictionary<R, /*GenericEventHandler*/ Handler> Subscriptionlist = InternalList[ObjectSubscribedTo];

            if (Subscriptionlist != null)
            {

                foreach (KeyValuePair<R, /*GenericEventHandler*/ Handler> EventDelegateCodeSet in Subscriptionlist)
                {

                    if (EventDelegateCodeSet.Key.Equals(EventCode))
                    {

                        return true;

                    }

                }

            }

            return false;
        }

    }

}
