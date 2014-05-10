using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    //[ConstructorRequires(typeof(IWorkContainer))]
    public class IsolatedTimerExecutor : IsolatedTimer, IIsolatedWorkExecutor
    {

        private Type myType;

        private IWorkContainer<object, object> myWorkContainer;

        private Action myExecute;

        public IsolatedTimerExecutor(Type TheType)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedTimerExecutor(Type TheType, params object[] TheParameters)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType, TheParameters);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedTimerExecutor(Type TheType, IEnumerable<object> TheParameters)
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

    public class IsolatedTimerExecutor<TWorkContainer> : IsolatedTimerExecutor
        where TWorkContainer : IWorkContainer, new()
    {

        public IsolatedTimerExecutor()
            : base(typeof(TWorkContainer))
        {
        }

    }
}
