using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IHaveLabel : IReadonlyHaveLabel
    {

        new string Label
        {

            get;
            set;
        }

    }

}
