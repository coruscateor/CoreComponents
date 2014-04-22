using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface ICloneWith<TItemToClone, TItemToPass>
    {

        TItemToClone CloneWith(TItemToPass TheItem);

    }

}
