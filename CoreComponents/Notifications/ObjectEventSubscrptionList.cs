using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Notifications
{

    public abstract class ObjectEventSubscrptionList<T, R, Handler> : IObjectEventSubscrptionList<T, R, Handler>
    {

        protected List<IObjectEventSubscrption<T, R, Handler>> OESSet = new List<IObjectEventSubscrption<T, R, Handler>>();

        //public ObjectEventSubscrptionList(ObjectEventSubscription<T, R, Handler>.SubscribeToEventHandler AllocateMethod, ObjectEventSubscription<T, R, Handler>.UnSubscribeToEventHandler DeAllocateMethod)
        //{
        //}

        public IObjectEventSubscrption<T, R, Handler> this[T Object]
        {

            get
            {
                foreach (IObjectEventSubscrption<T, R, Handler> Item in OESSet)
                {

                    if (Item.SubscribedObject.Equals(Object))
                    {

                        return Item;

                    }

                }

                return default(IObjectEventSubscrption<T, R, Handler>);

            }

        }


        public T this[IObjectEventSubscrption<T, R, Handler> Set]
        {

            get
            {

                foreach (IObjectEventSubscrption<T, R, Handler> Item in OESSet)
                {

                    if (Item.SubscribedObject.Equals(Set))
                    {

                        return Set.SubscribedObject;

                    }

                }

                return default(T);

            }

        }

        public virtual void Add(T TheObject)
        {

        }

        public void Add(IObjectEventSubscrption<T, R, Handler> ObjectJournal)
        {

            foreach (IObjectEventSubscrption<T, R, Handler> Item in OESSet)
            {
                if (ObjectJournal.SubscribedObject.Equals(Item.SubscribedObject))
                {

                    return;

                }
            }

            OESSet.Add(ObjectJournal);

        }

        public virtual bool Remove(T TheObject)
        {

            return false;

        }

        //public bool Remove(T ObjectJournal)
        //{

        //    foreach (IObjectEventSubscrption<T, R, Handler> Obj in OESSet)
        //    {


        //        if (Obj.Equals(ObjectJournal))
        //        {

        //            return OESSet.Remove(Obj);

        //        }

        //    }

        //    return false;

        //}

        public bool ClearAndRemove(IObjectEventSubscrption<T, R, Handler> ObjectJournal)
        {

            bool Removed = OESSet.Remove(ObjectJournal);

            if (Removed)
                ObjectJournal.Clear();

            return Removed;

        }

        public bool Remove(IObjectEventSubscrption<T, R, Handler> ObjectJournal)
        {

            return OESSet.Remove(ObjectJournal);

        }

        public void ClearEverything()
        {

            foreach (IObjectEventSubscrption<T, R, Handler> Item in OESSet)
            {

                Item.Clear();

            }

            OESSet.Clear();

        }


        public void ClearSet()
        {

            OESSet.Clear();

        }

        public IEnumerator<IObjectEventSubscrption<T, R, Handler>> GetEnumerator()
        {
            return OESSet.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return OESSet.GetEnumerator();
        }

    }

}
