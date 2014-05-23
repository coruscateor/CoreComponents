﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class FencedReadonlyFacade<T> : IReadonlyValueContainer<T>
    {

        protected FencedValueContainer<T> myValueContainer;

        public FencedReadonlyFacade(FencedValueContainer<T> TheValueContainer)
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

        public bool IsDefault
        {

            get
            {

                return myValueContainer.IsDefault;

            }

        }

    }

}
