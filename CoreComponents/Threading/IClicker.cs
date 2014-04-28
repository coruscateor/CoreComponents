using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    public interface IClicker
    {

        bool IsClicked
        {

            get;

        }

        void Click();

        void Reset();

    }

}
