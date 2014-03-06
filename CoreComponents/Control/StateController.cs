using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public class StateController : BaseStateController<IParameterisedCommand>
    {

        public StateController()
        {
        }

        public override void ChangeState(object TheValue)
        {

            Type TypeOfValue = TheValue.GetType();

            if(myTypesAndCommands.ContainsKey(TypeOfValue))
            {

                myTypesAndCommands[TypeOfValue].Execute(TheValue);

            }

        }

        public override void AddState(Type StateType, IParameterisedCommand ExecutionContext)
        {

            Type ExecutionContextType = ExecutionContext.GetType();

            CheckContains(StateType);

            myTypesAndCommands.Add(StateType, ExecutionContext);

        }

        public override bool HasExecutionContext(IParameterisedCommand ExecutionContext)
        {

            return myTypesAndCommands.ContainsValue(ExecutionContext);

        }

    }

}
