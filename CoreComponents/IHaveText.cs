using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IHaveText : IReadonlyHaveText
    {

        new string Text
        {

            get;
            set;

        }

    }

}
