using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public abstract class VariableIsolatedThreadExecutor : VariableIsolatedThread, IIsolatedWorkExecutor
    {

        private Type myType;

        private IWorkContainer<object, object> myWorkContainer;

        private Action myExecute;

        public VariableIsolatedThreadExecutor(Type TheType, string TheName = "")
            : base(TheName)
        {

            InitaliseDelegate(TheType);

        }

        public VariableIsolatedThreadExecutor(Type TheType, ExecutionMethod TheExecutionMethod)
            : base("", TheExecutionMethod)
        {

            InitaliseDelegate(TheType);

        }

        public VariableIsolatedThreadExecutor(Type TheType, string TheName, ExecutionMethod TheExecutionMethod)
            : base(TheName, TheExecutionMethod)
        {

            InitaliseDelegate(TheType);

        }

        private void InitaliseDelegate(Type TheType)
        {

            myType = TheType;

            myExecute = () =>
            {

                myWorkContainer = WorkContainerCreator<object, object>.Create(myType);

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

    public class VariableIsolatedThreadExecutor<TWorkContainer> : VariableIsolatedThreadExecutor
    where TWorkContainer : IWorkContainer, new()
    {

        public VariableIsolatedThreadExecutor()
            : base(typeof(TWorkContainer))
        {
        }

        public VariableIsolatedThreadExecutor(string TheName = "")
            : base(typeof(TWorkContainer), TheName)
        {
        }

        public VariableIsolatedThreadExecutor(ExecutionMethod TheExecutionMethod)
            : base(typeof(TWorkContainer), "", TheExecutionMethod)
        {
        }

        public VariableIsolatedThreadExecutor(string TheName, ExecutionMethod TheExecutionMethod)
            : base(typeof(TWorkContainer), TheName, TheExecutionMethod)
        {
        }

        protected override void ThreadMain()
        {

            base.ThreadMain();

        }

    }

}
