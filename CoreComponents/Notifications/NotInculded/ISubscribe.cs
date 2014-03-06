using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    #region Element Subscriber interfaces

    interface ISubscribeOnly<T>
    {

        void Subscribe(T TheObject);

    }

    interface ISubscribeSelective<T, R>
    {

        void Subscribe(T TheObject, R ParticularEventOrEvents);

    }

    interface IQueryOnly<T, R>
    {

        R SubscribesToWhich(T TheObject);

        bool Subscribes(T TheObject);

    }

    interface IUnSubscribeOnly<T>
    {

        void UnSubscribe(T TheObject);

    }

    interface IUnSubscribeSelective<T, R>
    {

        void UnSubscribe(T TheObject, R ParticularEventOrEvents);

    }

    #endregion

    #region Compound Subscriber interfaces

    interface IQuerySubscribeOnly<T, R> : IQueryOnly<T, R>, ISubscribeOnly<T>
    {
    }

    interface IQueryUnSubscribeOnly<T, R> : IQueryOnly<T, R>, IUnSubscribeOnly<T>
    {
    }

    interface ISubscribe<T, R> : IQueryOnly<T, R>, ISubscribeOnly<T>, IUnSubscribeOnly<T>
    {
    }

    #endregion

}
