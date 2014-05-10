using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    //[ConstructorRequires(typeof(IWorkContainer))]
    public class IsolatedAppDomianExecutor : IsolatedAppDomain, IIsolatedWorkExecutor
    {

        private Type myType;

        private IWorkContainer<object, object> myWorkContainer;

        private Action myExecute;

        public IsolatedAppDomianExecutor(Type TheType, string TheName) 
            : base(TheName)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedAppDomianExecutor(Type TheType, string TheName, params object[] TheParameters)
            : base(TheName)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType, TheParameters);

                myExecute = ExecuteWorkContainer;

                ExecuteWorkContainer();

            };

        }

        public IsolatedAppDomianExecutor(Type TheType, string TheName, IEnumerable<object> TheParameters)
            : base(TheName)
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

    public class IsolatedAppDomainExecutor<TWorkContainer> : IsolatedAppDomianExecutor
        where TWorkContainer : IWorkContainer, new()
    {

        public IsolatedAppDomainExecutor(string TheName)
            : base(typeof(TWorkContainer), TheName)
        {
        }

    }

}
