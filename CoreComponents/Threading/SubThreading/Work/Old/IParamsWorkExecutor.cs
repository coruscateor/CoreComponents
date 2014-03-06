using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IParamsWorkExecutor
    {

        void AddAndCheck(params object[] TheParameters);

    }

    public interface IParamsWorkExecutor<T>
    {

        void AddAndCheck(params T[] TheParameters);

    }

}
