using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{
    
    public interface IHasState
    {

        IState<string, object> State
        {

            get;

        }

    }

}
