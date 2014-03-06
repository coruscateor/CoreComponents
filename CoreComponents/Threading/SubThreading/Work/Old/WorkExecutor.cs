using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Threading.SubThreading.Work
{

    public class WorkExecutor //: IWorkExecutor //: BaseWorkContainer
    {

        public WorkExecutor(Type TheIAsynchronousWorkContainerType, Type TheIWorkContainerType)
        {

            //CheckandInitalise(TheIAsynchronousWorkContainerType, TheIWorkContainerType);

        }
        
        //public void Check()
        //{

        //    if (!myAsynchronousWorkContainer.IsBusy)
        //        myAsynchronousWorkContainer.Execute();
            
        //}

    }

    public class WorkExecutor<TAsynchronousWorkContainer, TWorkContainer> : BaseWorkContainer
    {

        public WorkExecutor()
        {

            //CheckandInitalise(typeof(TAsynchronousWorkContainer), typeof(TWorkContainer));

        }


    }

}
