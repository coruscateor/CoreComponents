using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IFencedContainer<T> : IValueContainer<T> 
    {

        bool IsDefault
        {

            get;

        }

        bool ComapreSet(ref T TheValue);

        bool ComapreSwap(ref T TheValue);

    }

}
