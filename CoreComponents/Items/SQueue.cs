using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class SQueue<T> : Queue<T>, IHasCount
    {

        public SQueue()
            : base()
        {
        }

        public SQueue(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public SQueue(int capacity)
            : base(capacity)
        {
        }

    }

}
