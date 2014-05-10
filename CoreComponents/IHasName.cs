using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IHasName : IReadonlyHaveName
    {

        new string Name
        {

            get;
            set;

        }

    }

}
