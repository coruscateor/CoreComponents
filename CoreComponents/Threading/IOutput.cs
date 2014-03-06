using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IOutput
    {

        IOutputQueue<object> OutputQueue
        {

            get;

        }

    }

}
