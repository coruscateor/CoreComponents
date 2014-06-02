using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Threading;

namespace CoreComponents.Text
{
    
    public class ConcurrentStringBuilderCache : ConcurrentCache<StringBuilder>
    {

        public ConcurrentStringBuilderCache()
        {
        }

        public override void Put(StringBuilder TheItem)
        {

            TheItem.Clear();

            base.Put(TheItem);

        }

    }

}
