using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface ILabelled : IReadonlyLabelled
    {

        string Label
        {

            get;
            set;
        }

    }

}
