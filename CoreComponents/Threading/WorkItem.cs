using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public abstract class WorkItem : IReset
    {

        bool myIsDone;

        [ThreadSafe]
        public bool IsDone
        {

            [ThreadSafe]
            get
            {

                return Volatile.Read(ref myIsDone);

            }
            [ThreadSafe]
            set
            {

                Volatile.Write(ref myIsDone, value);

            }

        }

        public virtual void Reset()
        {

            myIsDone = false;
            
        }

    }

}
