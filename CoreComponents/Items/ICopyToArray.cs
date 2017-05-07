using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public interface ICopyToArray<T>
    {

        void CopyTo(T[] array);

        void CopyTo(T[] array, int index);

        void CopyToLength(T[] array, int length);

        void CopyTo(T[] array, int index, int length);

    }

}
