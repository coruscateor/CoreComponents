using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    public interface IInternalSubscription<T, F>
    {

        Type ObjectType
        {

            get;

        }

        Type FlagType
        {

            get;

        }

        T Object
        {

            get;

        }

        void Add(F Flag, Delegate D);

        bool Remove(F Flag);

        bool Has(F Flag);

        void Clear();

        void Suspend(F Flag);

        TempEventSuspension<T, F> SuspendTemp(F Flag);

        void UnSuspend(F Flag);

        void SuspendAll();

        void UnSuspendAll();

    }

    public interface IInternalSubscriptionList<T, F> : IEnumerable<IInternalSubscription<T, F>>, IEnumerable
    {

        IInternalSubscription<T, F> this[T Object]
        {

            get;

        }
        
        T this[IInternalSubscriptionList<T, F> Set]
        {

            get;
        }

        void Add(T TheObject);

        void Add(IInternalSubscription<T, F> Journal);

        bool ClearAndRemove(T TheObject);

        bool ClearAndRemove(IInternalSubscription<T, F> Journal);

        bool Remove(T TheObject);

        bool Remove(IInternalSubscription<T, F> Journal);

        void Suspend();

        void SuspendAndRemove(T TheObject);

        void SuspendAndRemove(IInternalSubscription<T, F> Journal);

        void Clear();

        void ClearAll();


    }

}
