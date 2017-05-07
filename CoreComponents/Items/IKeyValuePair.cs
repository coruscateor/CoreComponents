using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public interface IKeyValuePair<TKey, TValue> : IReadonlyKeyValuePair<TKey, TValue>
    {

        new TKey Key
        {

            get;
            set;

        }

        new TValue Value
        {

            get;
            set;

        }

    }

}
