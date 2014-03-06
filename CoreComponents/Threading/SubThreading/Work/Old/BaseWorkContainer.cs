using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Threading.SubThreading.Work
{

    public abstract class BaseWorkContainer : IBaseWorkContainer
    {

        //protected IAsynchronousWorkContainer myAsynchronousWorkContainer;

        private IWorkExecutor myWorkExecutor;

        public BaseWorkContainer()
        {
        }

        public BaseWorkContainer(Type TheIWorkContainerType) //Type TheIAsynchronousWorkContainerType, 
        {

            //CheckandInitalise(TheIAsynchronousWorkContainerType, TheIWorkContainerType);

            CheckandInitalise(TheIWorkContainerType);

        }

        protected void CheckandInitalise(Type TheIWorkContainerType)  //Type TheIAsynchronousWorkContainerType,
        {

            //Type IWorkContainerType = typeof(IWorkContainer);

            //IWorkContainer IWorkContainerInstance = null;

            //foreach (Type Item in TheIWorkContainerType.GetInterfaces())
            //{

            //    if (Item == IWorkContainerType)
            //    {

            //        IWorkContainerInstance = Activator.CreateInstance(TheIWorkContainerType) as IWorkContainer; //, true);

            //        break;
            //    }

            //}

            //if(myWorkContainer == null)
            //    throw new Exception("TheIWorkContainerType does not implement IWorkContainer");

            //Type IAsynchronousWorkContainerType = typeof(IAsynchronousWorkContainer);

            //Type[] Interfaces = TheIAsynchronousWorkContainerType.GetInterfaces();

            //foreach (Type Item in Interfaces)
            //{

            //    if (Item == IWorkContainerType)
            //    {

            //        ConstructorInfo[] ConstructorInfos = TheIAsynchronousWorkContainerType.GetConstructors();

            //        foreach (ConstructorInfo CIItem in ConstructorInfos)
            //        {

            //            ParameterInfo[] Parameters = CIItem.GetParameters();

            //            if (Parameters.Length == 1)
            //            {

            //                Type ParameterType = Parameters[0].ParameterType;

            //                foreach (Type ParameterTypeInterfaces in TheIWorkContainerType.GetInterfaces())
            //                {

            //                    if (ParameterTypeInterfaces == IAsynchronousWorkContainerType)
            //                    {

            //                        myWorkContainer = IWorkContainerInstance;

            //                        myAsynchronousWorkContainer = Activator.CreateInstance(TheIAsynchronousWorkContainerType, myWorkContainer) as IAsynchronousWorkContainer;

            //                        return;

            //                    }

            //                }

            //                //return;

            //            }

            //        }

            //        break;

            //    }

            //}

            //myAsynchronousWorkContainer = new AsynchronousDoNothingContainer();

            //throw new Exception("TheIAsynchronousWorkContainerType does not implement IAsynchronousWorkContainer");

            myWorkContainer = Activator.CreateInstance(TheIWorkContainerType) as IWorkContainer;

            //myAsynchronousWorkContainer = Activator.CreateInstance(TheIAsynchronousWorkContainerType, myWorkContainer) as IAsynchronousWorkContainer;

        }

        //public Type TypeOfAsynchronousWorkContainer
        //{

        //    get
        //    {

        //        return myAsynchronousWorkContainer.GetType();

        //    }

        //}

        public Type TypeOfWorkExecutor
        {

            get
            {

                return myWorkContainer.GetType();

            }

        }

        //public bool IsBusy
        //{
            
        //    get
        //    {
                
        //        return myAsynchronousWorkContainer.IsBusy;
            
        //    }

        //}

    }

    //public abstract class BaseWorkExecutor<TAsynchronousWorkContainer, TWorkContainer> : IBaseWorkExecutor where TAsynchronousWorkContainer : IAsynchronousWorkContainer where TWorkContainer : IWorkContainer
    //{

    //    protected IAsynchronousWorkContainer myAsynchronousWorkContainer;

    //    private IWorkContainer myWorkContainer;

    //    protected void CheckandInitalise()
    //    {

    //        //Type IAsynchronousWorkContainerType = typeof(IAsynchronousWorkContainer);

    //        //Type TAsynchronousWorkContainerType = typeof(TAsynchronousWorkContainer);

    //        myWorkContainer = Activator.CreateInstance(typeof(TWorkContainer)) as IWorkContainer;

    //        //foreach (ConstructorInfo Item in TAsynchronousWorkContainerType.GetConstructors())
    //        //{

    //        //    ParameterInfo[] Parameters = Item.GetParameters();

    //        //    if (Parameters.Length == 1)
    //        //    {

    //        //        Type ParameterType = Parameters[0].ParameterType;

    //        //        foreach (Type ParameterTypeInterfaces in ParameterType.GetInterfaces())
    //        //        {

    //        //            if (ParameterTypeInterfaces == IAsynchronousWorkContainerType)
    //        //            {

    //        //                myAsynchronousWorkContainer = Activator.CreateInstance(TAsynchronousWorkContainerType, myWorkContainer) as IAsynchronousWorkContainer;

    //        //                return;

    //        //            }

    //        //        }

    //        //    }

    //        //}

    //        myAsynchronousWorkContainer = Activator.CreateInstance(typeof(TAsynchronousWorkContainer), myWorkContainer) as IAsynchronousWorkContainer;

    //    }

    //    public Type TypeOfAsynchronousWorkContainer
    //    {

    //        get
    //        {

    //            return myAsynchronousWorkContainer.GetType();

    //        }

    //    }

    //    public Type TypeOfWorkContainer
    //    {

    //        get
    //        {

    //            return myWorkContainer.GetType();

    //        }

    //    }

    //    public bool IsBusy
    //    {

    //        get
    //        {

    //            return myAsynchronousWorkContainer.IsBusy;

    //        }

    //    }

    //}

}
