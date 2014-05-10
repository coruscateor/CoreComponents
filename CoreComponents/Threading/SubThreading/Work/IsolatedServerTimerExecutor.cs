using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    //[ConstructorRequires(typeof(IWorkContainer))]
    public class IsolatedServerTimerExecutor : IsolatedServerTimer, IIsolatedWorkExecutor
    {

        private Type myType;

        private IWorkContainer<object, object> myWorkContainer;

        private Action myExecute;

        public IsolatedServerTimerExecutor(Type TheType)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedServerTimerExecutor(Type TheType, params object[] TheParameters)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType, TheParameters);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedServerTimerExecutor(Type TheType, IEnumerable<object> TheParameters)
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

        protected override void Main()
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

            Start();

        }

    }

    public class IsolatedServerTimerExecutor<TWorkContainer> : IsolatedServerTimerExecutor
        where TWorkContainer : IWorkContainer, new()
    {

        public IsolatedServerTimerExecutor()
            : base(typeof(TWorkContainer))
        {
        }

    }

}
