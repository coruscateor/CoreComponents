using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class SList<T> : List<T>, IHasCount
    {

        public SList()
            : base()
        {
        }

        public SList(T item, bool setCapacity = false)
            : base()
        {

            if(setCapacity)
                Capacity = 1;

            Add(item);

        }

        public SList(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public SList(int capacity)
            : base(capacity)
        {
        }

        public ImmutableArray<T> ToImmutableArray()
        {

            return new ImmutableArray<T>(this);

        }

    }

}
