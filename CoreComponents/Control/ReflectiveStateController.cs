using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Control
{

    public class ReflectiveStateController : BaseStateController<object>
    {

        protected static string Execute = "Execute";

        public ReflectiveStateController()
        {
        }

        public override void ChangeState(object TheValue)
        {

            Type TypeOfValue = TheValue.GetType();

            if(myTypesAndCommands.ContainsKey(TypeOfValue))
            {

                object TypeCommand = myTypesAndCommands[TypeOfValue];

                TypeOfValue.InvokeMember(Execute, BindingFlags.InvokeMethod, null, TypeCommand, new object[] { TheValue });

            }

        }

        public override void AddState(Type StateType, object ExecutionContext)
        {

            Type ExecutionContextType = ExecutionContext.GetType();

            MethodInfo[] ExecutionContextTypeMethods = ExecutionContextType.GetMethods();

            bool FoundExecute = false;

            foreach(MethodInfo Item in ExecutionContextTypeMethods)
            {

                if(Item.Name == Execute)
                {

                    ParameterInfo[] ItemParameters = Item.GetParameters();

                    if(ItemParameters.Length == 1)
                    {

                        ParameterInfo ParameterItem = ItemParameters[0];

                        if(ParameterItem.ParameterType == StateType)
                        {

                            FoundExecute = true;

                            break;
 
                        }

                    }

                }

            }

            if(FoundExecute)
            {

                CheckContains(StateType);

                myTypesAndCommands.Add(StateType, ExecutionContext);

            }
            else
            {

                throw new Exception("The provided StateType is not used in a method named \"Execute\" in the accompanying ExecutionContext");

            }

        }

        public override bool HasExecutionContext(object ExecutionContext)
        {

            return myTypesAndCommands.ContainsValue(ExecutionContext);

        }

    }

}
