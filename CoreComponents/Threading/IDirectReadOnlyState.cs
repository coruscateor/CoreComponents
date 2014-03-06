using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IDirectReadOnlyState<TKey, TValue> : IDirectCollection
    {

        bool ContainsKey(TKey TheKey, ref bool ContainsTheKey);

        bool TryGetValue(TKey TheKey, ref TValue TheValue, ref bool GotValue);

        bool TryGetKeys(out ICollection<TKey> TheKeys);

        bool TryGetValues(out ICollection<TValue> TheValues);

    }

}
