using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IBaseWorkContainer
    {

        //Type TypeOfAsynchronousWorkContainer
        //{

        //    get;

        //}

        Type TypeOfWorkContainer
        {

            get;

        }

        bool IsBusy
        {

            get;

        }

    }

}
