using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public abstract class BaseInterThreadStorageWatcher
    {

        protected WeakReference myWeakReference;

        public BaseInterThreadStorageWatcher()
        {
        }

        public void Withdraw()
        {

            myWeakReference.Target = null;

        }

    }

}
