using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IHaveName : IReadonlyHaveName
    {

        new string Name
        {

            get;
            set;

        }

    }

}
