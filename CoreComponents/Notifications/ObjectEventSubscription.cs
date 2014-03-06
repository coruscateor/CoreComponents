using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Notifications
{

    //public delegate void GenericEventHandler(EventArgs e);

    public abstract class ObjectEventSubscription<T, R, Handler> : IObjectEventSubscrption<T, R, Handler> //where Handler : delegate //T is the targeted object. R is the flag used to differencciate bettween events.
    {

        //public delegate void SubscribeToEventHandler(T Object, R Flag, Handler H);

        //public delegate void UnSubscribeToEventHandler(T Object, R Flag, Handler H);

        //SubscribeToEventHandler AllocateMethod;

        //UnSubscribeToEventHandler DeAllocateMethod;

        protected T myObj;

        protected Dictionary<R, Handler> EventFlagPair = new Dictionary<R, Handler>();

        public ObjectEventSubscription(T Obj /*, SubscribeToEventHandler AllocateMethod, UnSubscribeToEventHandler DeAllocateMethod*/)
        {
            //new ObjectEventSubscription<String, bool, GenericEventHandler>();
            //this.AllocateMethod = AllocateMethod;

            //this.DeAllocateMethod = DeAllocateMethod;

            myObj = Obj;

        }

        //public ObjectEventSubscription() {
    
        //}

        public T SubscribedObject
        {

            get
            {

                return myObj;

            }

            set
            {

                Clear();

                myObj = value;

            }

        }

        public void Add(R Flag, Handler H) {

            AllocateMethod(Flag, H);

            EventFlagPair.Add(Flag, H);
        
        }

        public bool Remove(R Flag)
        {
            if (EventFlagPair.ContainsKey(Flag))
            {
                DeAllocateMethod(Flag, EventFlagPair[Flag]);

                return EventFlagPair.Remove(Flag);
            }

            return false;
        }

        public bool Has(R Flag)
        {

            return EventFlagPair[Flag].Equals(default(T));

        }

        //Call this when done.
        public void Clear()
        {

            foreach (KeyValuePair<R, Handler> HFPair in EventFlagPair) {

                DeAllocateMethod(HFPair.Key, HFPair.Value);

                //EventFlagPair.Remove(HFPair.Key);
            
            }

            EventFlagPair.Clear();

        }

        protected abstract void AllocateMethod(R Flag, Handler H);

        protected abstract void DeAllocateMethod(R Flag, Handler H);


        //protected virtual void AllocateMethod(T Object, R Flag, Handler H)
        //{


        //}

        //protected virtual void DeAllocateMethod(T Object, R Flag, Handler H)
        //{


        //}

        /*
        ~ObjectEventSubscription()
        {

            Clear();

        }
        */
    }

}
