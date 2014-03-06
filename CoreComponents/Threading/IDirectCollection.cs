using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IDirectCollection : IWeakReferenceHolder
    {

        bool GetCount(ref int TheCount);

        bool IsEmpty(ref bool IsEmpty);

    }

}
