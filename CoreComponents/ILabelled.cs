using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface ILabelled : IReadonlyLabelled
    {

        new string Label
        {

            get;
            set;
        }

    }

}
