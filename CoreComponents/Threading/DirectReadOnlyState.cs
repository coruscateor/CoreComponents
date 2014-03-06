using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class DirectReadOnlyState<TKey, TValue> : WeakReferenceHolder<IReadOnlyState<TKey, TValue>>, IDirectReadOnlyState<TKey, TValue>
    {

        public DirectReadOnlyState(IReadOnlyState<TKey, TValue> TheReadOnlyState)
            : base(TheReadOnlyState)
        {
        }

        public DirectReadOnlyState(IReadOnlyState<TKey, TValue> TheReadOnlyState, WeakReference TheWeakReference)
            : base(TheReadOnlyState, TheWeakReference)
        {
        }

        public bool ContainsKey(TKey TheKey, ref bool ContainsTheKey)
        {

            bool ContainsTheKeyLocal = false;

            if (FetchReferenceAndDo((IReadOnlyState<TKey, TValue> TheReadOnlyState) => { ContainsTheKeyLocal = TheReadOnlyState.ContainsKey(TheKey); }))
            {

                ContainsTheKey = ContainsTheKeyLocal;

                return true;

            }

            return false;

        }

        public bool TryGetValue(TKey TheKey, ref TValue TheValue, ref bool GotValue)
        {

            bool GotValueLocal = false;

            TValue TheValueLocal = default(TValue);

            if (FetchReferenceAndDo((IReadOnlyState<TKey, TValue> TheReadOnlyState) => { GotValueLocal = TheReadOnlyState.TryGetValue(TheKey, out TheValueLocal); }))
            {

                GotValue = GotValueLocal;

                TheValue = TheValueLocal;

                return true;

            }

            return false;

        }

        public bool GetCount(ref int TheCount)
        {

            int Count;

            if (FetchReferenceAndDo((IReadOnlyState<TKey, TValue> TheReadOnlyState) => { Count = TheReadOnlyState.Count; }))
            {

                Count = TheCount;

                return true;

            }

            return false;

        }

        public bool IsEmpty(ref bool IsEmpty)
        {

            bool IsEmptyLocal = false;

            if (FetchReferenceAndDo((IReadOnlyState<TKey, TValue> TheReadOnlyState) => { IsEmptyLocal = TheReadOnlyState.IsEmpty; }))
            {

                IsEmpty = IsEmptyLocal;

                return true;

            }

            return false;

        }

        public bool TryGetKeys(out ICollection<TKey> TheKeys)
        {

            ICollection<TKey> TheKeysLocal = null;

            if (FetchReferenceAndDo((IReadOnlyState<TKey, TValue> TheReadOnlyState) => { TheKeysLocal = TheReadOnlyState.Keys; }))
            {

                TheKeys = TheKeysLocal;

                return true;

            }

            TheKeys = null;

            return false;
            
        }

        public bool TryGetValues(out ICollection<TValue> TheValues)
        {

            ICollection<TValue> TheValuesLocal = null;

            if (FetchReferenceAndDo((IReadOnlyState<TKey, TValue> TheReadOnlyState) => { TheValuesLocal = TheReadOnlyState.Values; }))
            {

                TheValues = TheValuesLocal;

                return true;

            }

            TheValues = null;

            return false;

        }

    }

}
