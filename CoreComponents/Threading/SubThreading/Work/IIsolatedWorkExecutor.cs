using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IIsolatedWorkExecutor
    {

        Type TypeOfWorkContainer
        {

            get;

        }

        bool HasTypeOfWorkContainer<TTypeOfWorkContainer>() where TTypeOfWorkContainer : IWorkContainer;

        void Execute();

    }

}
