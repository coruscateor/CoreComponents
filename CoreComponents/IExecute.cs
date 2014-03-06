using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IExecute
    {

        void Execute();

    }

    public interface IExecute<T>
    {

        void Execute(T Item);

    }

}
