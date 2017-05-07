using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface IMutableResult<T> : IResult<T>
    {

        new T Result
        {

            get;
            set;

        }

    }

}
