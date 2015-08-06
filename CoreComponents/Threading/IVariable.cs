using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public interface IVariable
    {

        object Value
        {

            get;
            set;

        }

    }

    public interface IVariable<T> : IVariable
    {

        T Value
        {

            get;
            set;

        }

    }

}
