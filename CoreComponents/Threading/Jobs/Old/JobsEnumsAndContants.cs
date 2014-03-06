using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{
    public enum JobState
    {

        Active,
        Canceled,
        Canceling,
        Completed,
        WaitingForInput,
        Deactivated,
        WaitingToStart,
        Failed,
        Paused,
        Waiting

    }
}
