using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public abstract class CancelablePercentWorkItem : PercentWorkItem, IReset
    {

        bool myCancel;

        [ThreadSafe]
        public bool Cancel
        {

            [ThreadSafe]
            get
            {

                return Volatile.Read(ref myCancel);

            }
            [ThreadSafe]
            set
            {

                Volatile.Write(ref myCancel, value);

            }

        }

        public override void Reset()
        {

            base.Reset();

            myCancel = false;

        }

    }

}
