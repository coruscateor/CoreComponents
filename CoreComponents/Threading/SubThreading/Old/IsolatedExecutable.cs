using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedExecutable : BareIsolatedExecutable, ISubThread
    {

        private IAsynchronousInputOutput myThreadIO;

        public IsolatedExecutable(IAsynchronousInputOutput TheThreadIO)
        {

            myThreadIO = TheThreadIO;

        }

        protected IAsynchronousInputOutput ThreadIO
        {

            get
            {

                return myThreadIO;

            }

        }

    }

}
