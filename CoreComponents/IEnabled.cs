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

        new event EventHandler<TInfo> Enabled;

        event EventHandler<TInfo> Disabled;

    }

}
