using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public abstract class LockBase
    {

        protected object myLockObject = new object();

    }

}
