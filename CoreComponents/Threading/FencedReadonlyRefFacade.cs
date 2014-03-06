using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class FencedReadonlyRefFacade<T> : IReadonlyValueContainer<T> where T : class
    {

        protected FencedRefContainer<T> myValueContainer;

        public FencedReadonlyRefFacade(FencedRefContainer<T> TheValueContainer)
        {

            myValueContainer = TheValueContainer;

        }

        public T Value
        {

            get
            {
                
                return myValueContainer.Value;
            
            }

        }

        public bool IsNull
        {

            get
            {

                return myValueContainer.IsNull;

            }

        }

        public bool TryGetValue(out T TheValue)
        {

            return myValueContainer.TryGetValue(out TheValue);

        }

    }

}
