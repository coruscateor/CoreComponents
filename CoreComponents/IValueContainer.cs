using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IValueContainer : IReadonlyValueContainer
    {

        object Value
        {

            get;
            set;

        }

    }

    public interface IValueContainer<T> : IReadonlyValueContainer<T>
    {

        T Value
        {

            get;
            set;

        }

    }

}
