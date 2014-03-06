using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackingEventsDelegatesAndObjects.Events;
using TrackingEventsDelegatesAndObjects.MessengerSubscriberForm;
using System.Windows.Forms;

namespace TrackingEventsDelegatesAndObjects
{
    public class ASubscribeableList : ISubscribeableList<MessengerSubscriberForm.BaseMessengerSubscriberForm, object, ChangedReason> //, ISubscribeable<Form, ChangedReason>
    {

        public event ChangedHandler SubscribeChangedRange;

        public event ChangedHandler SubscribeChange;

        //#region IList<MessengerSubscriberForm> Members

        public int IndexOf(MessengerSubscriberForm.BaseMessengerSubscriberForm item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, MessengerSubscriberForm.BaseMessengerSubscriberForm item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        MessengerSubscriberForm.BaseMessengerSubscriberForm IList<MessengerSubscriberForm.BaseMessengerSubscriberForm>.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //#endregion

        //#region ICollection<MessengerSubscriberForm> Members

        public void Add(MessengerSubscriberForm.BaseMessengerSubscriberForm item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(MessengerSubscriberForm.BaseMessengerSubscriberForm item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(MessengerSubscriberForm.BaseMessengerSubscriberForm[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Remove(MessengerSubscriberForm.BaseMessengerSubscriberForm item)
        {
            throw new NotImplementedException();
        }

        //#endregion

        //#region IEnumerable<MessengerSubscriberForm> Members

        public IEnumerator<MessengerSubscriberForm.BaseMessengerSubscriberForm> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //#endregion

        //#region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //#endregion

        //#region ISubscribeableFacdeListMultiChange<MessengerSubscriberForm,object,ChangedReason> Members

        //public void SubscribeAddRange(object Subscriber, ChangedRangeHandler<MessengerSubscriberForm.BaseMessengerSubscriberForm, ChangedReason> Del)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SubscribeRemoveRange(object Subscriber, ChangedRangeHandler<MessengerSubscriberForm.BaseMessengerSubscriberForm, ChangedReason> Del)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        //#region ISubscribeableFacdeList<MessengerSubscriberForm,object,ChangedReason> Members

        //public void SubscribeAdd(object Subscriber, ChangedHandler<MessengerSubscriberForm.BaseMessengerSubscriberForm, ChangedReason> Del)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SubscribeRemove(object Subscriber, ChangedHandler<MessengerSubscriberForm.BaseMessengerSubscriberForm, ChangedReason> Del)
        //{
        //    throw new NotImplementedException();
        //}

        MessengerSubscriberForm.BaseMessengerSubscriberForm ISubscribeableFacdeList<MessengerSubscriberForm.BaseMessengerSubscriberForm, object>.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int this[MessengerSubscriberForm.BaseMessengerSubscriberForm item]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //#endregion

        //public void SubscribeChange(object Subscriber, ChangedHandler Del)
        //{
        //}

        //public void SubscribeChangedRange(object Subscriber, ChangedRangeHandler Del)
        //{
        //}

    }
}
