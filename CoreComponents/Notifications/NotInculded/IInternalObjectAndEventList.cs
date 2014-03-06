using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    interface IInternalObjectAndEventSet<T, R, Handler>
    {

        int ListCapacity { get; }

        //void SetAddAndRemove(MasterMethod<T, R> AddMethod, MasterMethod<T, R> RemoveMethod);

        void Subscribe(T item, R EventCode, Handler del);

        void UnSubscribe(T item, R EventCode);

        void UnSubscribe(T item);

        bool IsSubscribedTo(T item);

        bool IsSubscribedTo(T item, R EventCode);

    }

}
