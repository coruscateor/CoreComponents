using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace CoreComponents.Reflect
{

    public interface IInvocationEntry
    {

        string Name
        {

            get;
            set;

        }

        BindingFlags InvokeAttribute
        {

            get;
            set;

        }

        Binder Binder
        {

            get;
            set;

        }

        IList<object> Arguments
        {

            get;

        }

        CultureInfo Culture
        {

            get;
            set;

        }

        IList<ParameterModifier> Modifiers
        {

            get;

        }

        IList<string> NamedParameters
        {

            get;

        }

        object Result
        {

            get;

        }

        T GetResult<T>();

        IList<InvocationEntryResultToParameter> AssignResultTo
        {

            get;

        }

        void Invoke(object TheInstace);

    }

}
