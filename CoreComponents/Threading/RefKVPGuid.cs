using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public sealed class RefKVPGuid<TValue> : BaseRefKVP<Guid, TValue>
    {

        public RefKVPGuid()
        {
        }

        public RefKVPGuid(TValue value)
        {

            myKVP = new ImmutableKeyValuePair<Guid, TValue>(Guid.NewGuid(), value);

        }

        public void Set(TValue value)
        {

            Volatile.Write<ImmutableKeyValuePair<Guid, TValue>>(ref myKVP, new ImmutableKeyValuePair<Guid, TValue>(Guid.NewGuid(), value));

        }

    }

}
