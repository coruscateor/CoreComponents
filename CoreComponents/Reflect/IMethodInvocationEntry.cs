using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Reflect
{

    public interface IMethodInvocationEntry : IInvocationEntry
    {

        void SetName(MethodBase TheMethod);

        IList<Type> GenericArguments
        {

            get;

        }

        bool HasGenericArguments
        {

            get;

        }

    }

}
