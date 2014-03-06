using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    public class ReferenceConcurrentValueContainer<T> : ConcurrentValueContainer<T> where T : class
    {

        public ReferenceConcurrentValueContainer()
        {
        }

        public ReferenceConcurrentValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

    }

}
