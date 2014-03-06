using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreComponents.Items
{
    public interface IOutput<TEventArgs, TOutput>
    {

        event EventInfo<TEventArgs> OutputCacheUpdated;

        TOutput GetOutput();

        /*
        uint Step
        {
            get;
            set;
        }

        uint CurrentStep
        {

            get;

        }
        */

    }
}
