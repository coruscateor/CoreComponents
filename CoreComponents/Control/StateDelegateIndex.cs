using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public class StateDelegateIndex
    {

        protected Dictionary<Type, Delegate> myTypesAndCommands = new Dictionary<Type, Delegate>();

        public StateDelegateIndex()
        {
        }

        protected void CheckContains(Type TheStateType)
        {

            if(myTypesAndCommands.ContainsKey(TheStateType))
                myTypesAndCommands.Remove(TheStateType);

        }

        public void ChangeState(object TheValue)
        {

            Type TypeOfValue = TheValue.GetType();

            if(myTypesAndCommands.ContainsKey(TypeOfValue))
            {

                myTypesAndCommands[TypeOfValue].DynamicInvoke();

            }

        }

        public void AddState(Type StateType, Delegate TheDelegate)
        {

            CheckParameters(TheDelegate);

            //Might be redundant

            //foreach(Delegate Item in TheDelegate.GetInvocationList())
            //{

            //    CheckParameters(Item);
                
            //}

            CheckContains(StateType);

            myTypesAndCommands.Add(StateType, TheDelegate);

        }

        protected void CheckParameters(Delegate TheDelegate)
        {

            if(TheDelegate.Method.GetParameters().Length > 0)
                throw new Exception("Provided Delegate must have no paramenters. This includes all delegates in the invocation list.");

        }

        public bool HasExecutionContext(Delegate TheDelegate)
        {

            return myTypesAndCommands.ContainsValue(TheDelegate);

        }

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
