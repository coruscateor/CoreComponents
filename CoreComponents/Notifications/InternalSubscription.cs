using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CoreComponents.Notifications
{
    public abstract class InternalSubscription<T, F> : IInternalSubscription<T, F> //T - Type, F - Flag
    {

        protected T Obj;

        protected Dictionary<F, Delegate> EventFlagPair = new Dictionary<F, Delegate>();

        protected Dictionary<F, Delegate> SuspendedList = new Dictionary<F, Delegate>();

        public InternalSubscription(T Obj)
        {

            this.Obj = Obj;


        }

        public Type ObjectType
        {

            get
            {

                return typeof(T);

            }

        }

        public Type FlagType
        {

            get
            {

                return typeof(F);

            }

        }

        public T Object
        {

            get
            {

                return Obj;

            }

        }

        public void Add(F Flag, Delegate D) {

            if (!EventFlagPair.ContainsKey(Flag) && !SuspendedList.ContainsKey(Flag))
            {
            
            AllocateMethod(Flag, D);

            EventFlagPair.Add(Flag, D);

            }
        
        }

        public bool Remove(F Flag)
        {
            if (EventFlagPair.ContainsKey(Flag))
            {

                if (SuspendedList.ContainsKey(Flag))
                {

                    return SuspendedList.Remove(Flag);

                }

                return JustRemove(Flag);


            } //else if (SuspendedList.ContainsKey(Flag))
            //{

            //    return SuspendedList.Remove(Flag);

            //}

           return false;
        }

        bool JustRemove(F Flag)
        {

            DeAllocateMethod(Flag);

            return EventFlagPair.Remove(Flag);

        }

        public bool Has(F Flag)
        {

            return EventFlagPair.ContainsKey(Flag);

            //if (EventFlagPair.ContainsKey(Flag)) {

            //    return true;

            //} //else
            //{
            //    return SuspendedList.ContainsKey(Flag);
            //}

        }

        public void Clear()
        {

            foreach (KeyValuePair<F, Delegate> HFPair in EventFlagPair) {

                DeAllocateMethod(HFPair.Key);
            
            }

            EventFlagPair.Clear();

            SuspendedList.Clear();

        }

        public void Suspend(F Flag)
        {

            foreach (KeyValuePair<F, Delegate> HFPair in EventFlagPair)
            {

                if (HFPair.Key.Equals(Flag))
                {
                    DeAllocateMethod(HFPair.Key);

                    //if(!SuspendedList.ContainsKey(Flag))
                    SuspendedList.Add(HFPair.Key, HFPair.Value);

                    return;
                }

            }

        }

        public void UnSuspend(F Flag)
        {

            foreach (KeyValuePair<F, Delegate> HFPair in SuspendedList)
            {

                if (HFPair.Key.Equals(Flag))
                {
                    AllocateMethod(HFPair.Key, HFPair.Value);

                    SuspendedList.Remove(HFPair.Key);

                    return;
                }

            }

        }

        public void SuspendAll()
        {

            foreach (KeyValuePair<F, Delegate> HFPair in EventFlagPair)
            {

                DeAllocateMethod(HFPair.Key);

                SuspendedList.Add(HFPair.Key, HFPair.Value);

            }

        }

        public TempEventSuspension<T, F> SuspendTemp(F Flag)
        {

            foreach (KeyValuePair<F, Delegate> HFPair in EventFlagPair)
            {

                if (HFPair.Key.Equals(Flag))
                {

                    return new TempEventSuspension<T, F>(this, Flag);

                }

            }

            return null;

        }


        public void UnSuspendAll()
        {
            //using
            foreach (KeyValuePair<F, Delegate> HFPair in SuspendedList)
            {

                AllocateMethod(HFPair.Key, HFPair.Value);

                SuspendedList.Remove(HFPair.Key);

                EventFlagPair.Add(HFPair.Key, HFPair.Value);

            }

        }

        protected virtual void AllocateMethod(F Flag, Delegate D)
        {


        }

        protected virtual void DeAllocateMethod(F Flag)
        {


        }

        // virtual void DeAllocateMethod(R Flag)
        //{


        //}


        ~InternalSubscription()
        {

            Clear();

        }


    }


    public class TempEventSuspension<T, F> : IDisposable
    {

        IInternalSubscription<T, F> _Journal;

        bool _IsSuspended;

        F _Flag;

        public TempEventSuspension(IInternalSubscription<T, F> Journal, F Flag)
        {

            this._Journal = Journal;

            this._Flag = Flag;

            Journal.Suspend(Flag);

            _IsSuspended = true;

        }

        public bool IsSuspended
        {

            get
            {

                return _IsSuspended;

            }

        }

        public IInternalSubscription<T, F> Journal
        {

            get
            {

                return _Journal;

            }

        }

        public F Flag
        {

            get
            {

                return _Flag;

            }

        }

        public void Reset()
        {

            if (!_IsSuspended)
            {

                Journal.Suspend(_Flag);

                _IsSuspended = true;

            }

        }


        #region IDisposable Members

        public void Dispose()
        {
            Journal.UnSuspend(Flag);

            _IsSuspended = false;
        }

        #endregion
    }
}
