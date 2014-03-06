using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    [ConstructorRequires(typeof(IWorkContainer))]
    public class IsolatedThreadExecutor : IsolatedThread, IIsolatedWorkExecutor
    {

        private Type myType;

        private IWorkContainer<object, object> myWorkContainer;

        private Action myExecute;

        public IsolatedThreadExecutor(Type TheType)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedThreadExecutor(Type TheType, params object[] TheParameters)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType, TheParameters);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedThreadExecutor(Type TheType, IEnumerable<object> TheParameters)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType, TheParameters);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        private void ExecuteWorkContainer()
        {

            myWorkContainer.Execute(ThreadIO);

        }

        protected override void ThreadMain()
        {

            myExecute();

        }

        public Type TypeOfWorkContainer
        {

            get
            {

                return myType;

            }

        }

        public bool HasTypeOfWorkContainer<TTypeOfWorkContainer>() where TTypeOfWorkContainer : IWorkContainer
        {

            return myType == typeof(TTypeOfWorkContainer);

        }
        
        public void Execute()
        {

            throw new NotImplementedException();

        }

    }

    public class IsolatedThreadExecutor<TWorkContainer> : IsolatedThreadExecutor
        where TWorkContainer : IWorkContainer, new()
    {

        public IsolatedThreadExecutor()
            : base(typeof(TWorkContainer))
        {
        }

    }

}
