using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Time
{

    public interface IDatedTimeSpan
    {

        DateTime Starts
        {

            get;

        }

        DateTime Finishes
        {

            get;

        }

        TimeSpan Duration
        {

            get;

        }

        bool IsWithin(DateTime TheDateTime);

    }

}
