using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public interface IEnabled
    {

        void Enable();

        bool Enabled
        {

            get;
            set;

        }

        void Disable();

    }

    public interface IEnabled<TInfo> : IEnabled
    {

        new event EventInfo<TInfo> Enabled;

        event EventInfo<TInfo> Disabled;

    }

}
