using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Observer
{

    public interface ISimpleFeeder<T, R>
    {
        //R Subject
        //{

        //    get;
        //    set;

        //}   

        void Feed(R sender, T message);

    }

}
