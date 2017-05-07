using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    /// <summary>
    /// Implys a copy of some or all of the values or reference contained in the implementing object to the new instances.
    /// </summary>
    public interface ICopy
    {

        object Copy();

    }

    /// <summary>
    /// Implys a copy of some or all of the values or reference contained in the implementing object to the new instances.
    /// </summary>
    public interface ICopy<T> : ICopy
        where T : class
    {

        new T Copy();

    }

}
