using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface ICloneable<out T> : ICloneable
    {

        T Clone();

    }

}
