using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IExecuteReturn<TResult>
    {

        TResult Execute();

    }

    public interface IExecuteReturn<TResult, TParam>
    {

        TResult Execute(TParam Item);

    }

}
