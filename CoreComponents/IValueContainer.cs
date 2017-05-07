using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IValueContainer : IReadonlyValueContainer
    {

        new object Value
        {

            get;
            set;

        }

    }

    public interface IValueContainer<T> : IValueContainer, IReadonlyValueContainer<T>
    {

        new T Value
        {

            get;
            set;

        }

    }

}
