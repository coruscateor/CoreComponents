using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    //public delegate void Handler(object sender, EventArgs e);

    //public delegate void MasterMethod();

    //The SubscriberSet is used as a helper class to maintain a set of subscriber records which
    //consists of an of obects and a set of event codes pertaining to the events of that object which have been subscribed to.
    //These event codes are accompined by the actual delegates passed on to the events of the subscriber object.

    //This would be usefull for dealing with subscribing and subscriber situations.

    //The implamenting code should be able to handle all situations without intervention by the Master. 

    //T - The Subscriber/Subscribing object
    //R - EventCode Type

    interface ISubscriberSet<T, R>
    {

        //IEventDelegatePair<T> this[T Object]
        //{
        //    get;
        //}

        KeyValuePair<R, Handler> this[T Object]
        {
            get;
        }

        void Add(T Object, R EventCode, Handler Del);

        void Add(T Object, IDictionary<R, Handler> PairSet);

        //void Add(T Object, IEventDelegatePair<T> PairSet);

        void Add(T Object, KeyValuePair<R, Handler> PairSet);

        void Remove(T Object, R EventCode);

        void Remove(T Object, IEnumerable<KeyValuePair<R, Handler>> EventCodes);

        //void Remove(T Object, IEventDelegatePair<T> EventCodes);

        void Remove(T Object, KeyValuePair<R, Handler> EventCodes);

        //void Add

    }

}
