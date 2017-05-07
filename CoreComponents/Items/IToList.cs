using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{
    
    public interface IToList<T>
    {

        IList<T> ToList();

    }

}
