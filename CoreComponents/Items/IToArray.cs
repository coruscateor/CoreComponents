using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public interface IToArray
    {

        object[] ToArray();

    }

    public interface IToArray<out T> : IToArray
    {

        new T[] ToArray();

    }

}
