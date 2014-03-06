using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IWorkContainer
    {

        void Execute(IAsynchronousInputOutput ThreadIO);

    }

    public interface IWorkContainer<T1, T2>
    {

        void Execute(IAsynchronousInputOutput<T1, T2> ThreadIO);

    }

}
