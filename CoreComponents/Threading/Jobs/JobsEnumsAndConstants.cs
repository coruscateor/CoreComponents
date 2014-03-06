using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public enum JobState
    {

        Deactivated,
        Active,
        Waiting,
        WaitingToStart,
        WaitingForInput,
        Paused,
        Completed,
        Canceling,
        Canceled,
        Failed

    }

}
