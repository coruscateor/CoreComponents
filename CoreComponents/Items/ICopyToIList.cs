using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public interface ICopyToIList<T>
    {

        void CopyTo(IList<T> list);

        void CopyTo(IList<T> list, int index);

        void CopyToCount(IList<T> list, int count);

        void CopyTo(IList<T> list, int index, int count);

    }

}
