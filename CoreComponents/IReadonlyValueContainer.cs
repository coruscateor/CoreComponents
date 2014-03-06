using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IReadonlyValueContainer
    {

        object Value
        {

            get;

        }

        bool HasValue
        {

            get;

        }

    }

    public interface IReadonlyValueContainer<T>
    {

        T Value
        {

            get;

        }

    }

}
