using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    public interface IObjectEventSubscrption<T, R, Handler>
    {

        T SubscribedObject
        {

            get;

        }

        void Add(R Flag, Handler H);

        bool Remove(R Flag);

        bool Has(R Flag);

        void Clear();

        ///*virtual*/ void AllocateMethod(T Object, R Flag, Handler H);

        ///*virtual*/ void DeAllocateMethod(T Object, R Flag, Handler H);


    }

    public interface IObjectEventSubscrptionList<T, R, Handler> : IEnumerable<IObjectEventSubscrption<T, R, Handler>>, IEnumerable
    {

        IObjectEventSubscrption<T, R, Handler> this[T Object]
        {

            get;

        }

        T this[IObjectEventSubscrption<T, R, Handler> Set]
        {

            get;
        }

        void Add(T TheObject);

        void Add(IObjectEventSubscrption<T, R, Handler> ObjectJournal);

        bool ClearAndRemove(IObjectEventSubscrption<T, R, Handler> ObjectJournal);

        bool Remove(T TheObject);

        bool Remove(IObjectEventSubscrption<T, R, Handler> ObjectJournal);

        void ClearEverything();

        void ClearSet();


    }

}
