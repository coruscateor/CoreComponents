using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IHasText : IReadonlyHaveText
    {

        string Text
        {

            get;
            set;

        }

    }

}
