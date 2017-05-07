using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public interface IIsolatedThreadWithId<TID> : IIsolatedThread
    {

        TID Id
        {

            get;

        }

    }

}
