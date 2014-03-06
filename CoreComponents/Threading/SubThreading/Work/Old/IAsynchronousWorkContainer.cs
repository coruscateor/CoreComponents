using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IAsynchronousWorkContainer : IWorkContainer
    {

        public bool IsBusy
        {

            get;

        }

    }

}
