using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Notifications
{

    public class InternalSubscriptionList<T, F> : IInternalSubscriptionList<T, F>
    {

        List<IInternalSubscription<T, F>> EventFlagPairs = new List<IInternalSubscription<T, F>>();

        public InternalSubscriptionList()
        {
        }



        #region IInternalSubscriptionList<T,F> Members

        public IInternalSubscription<T, F> this[T Object]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T this[IInternalSubscription<T, F> Set]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T TheObject)
        {
            throw new NotImplementedException();
        }

        public void Add(IInternalSubscription<T, F> Journal)
        {
            throw new NotImplementedException();
        }

        public bool ClearAndRemove(T TheObject)
        {
            throw new NotImplementedException();
        }

        public bool ClearAndRemove(IInternalSubscription<T, F> Journal)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T TheObject)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IInternalSubscription<T, F> Journal)
        {
            throw new NotImplementedException();
        }

        public void Suspend()
        {
            throw new NotImplementedException();
        }

        public void SuspendAndRemove(T TheObject)
        {
            throw new NotImplementedException();
        }

        public void SuspendAndRemove(IInternalSubscription<T, F> Journal)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }

        #endregion

        public IEnumerator<IInternalSubscription<T, F>> GetEnumerator()
        {
            return EventFlagPairs.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return EventFlagPairs.GetEnumerator();
        }

        #region IInternalSubscriptionList<T,F> Members


        public T this[IInternalSubscriptionList<T, F> Set]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }

}
