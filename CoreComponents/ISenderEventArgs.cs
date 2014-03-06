using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public interface ISenderEventArgs<out TSender>
    {

        TSender Sender
        {

            get;

        }

    }
}
