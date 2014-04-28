using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    public interface IComplicatedClicker
    {

        ComplicatedClickerState State
        {

            get;

        }

        void Click();

        void Caught(Exception TheException);

        void Reset();

        Exception Exception
        {

            get;

        }

        bool TryGetException(out Exception TheException);

    }

}
