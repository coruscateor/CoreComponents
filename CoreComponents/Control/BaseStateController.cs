using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public abstract class BaseStateController<TExecutionContext>
    {

        protected Dictionary<Type, TExecutionContext> myTypesAndCommands = new Dictionary<Type, TExecutionContext>();

        public BaseStateController()
        {
        }

        protected void CheckContains(Type TheStateType)
        {

            if(myTypesAndCommands.ContainsKey(TheStateType))
                myTypesAndCommands.Remove(TheStateType);

        }

        public abstract void ChangeState(object TheValue);

        public abstract void AddState(Type StateType, TExecutionContext ExecutionContext);

        public abstract bool HasExecutionContext(TExecutionContext ExecutionContext);

        public bool Contains(Type TheStateType)
        {

            return myTypesAndCommands.ContainsKey(TheStateType);

        }

        public int Count
        {

            get
            {

                return myTypesAndCommands.Count;

            }

        }

    }

}
