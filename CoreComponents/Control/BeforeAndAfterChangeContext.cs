using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public class BeforeAndAfterChangeContext<TType> : StateChangedContext<TType>
    {

        protected Action myBeforeAction;

        public BeforeAndAfterChangeContext()
        { 
        }

        public BeforeAndAfterChangeContext(Action TheBeforeAction, Action<TType> TheStateChangedAction)
        {

            myBeforeAction = TheBeforeAction;

            myStateChangedAction = TheStateChangedAction;

        }

        public Action BeforeAction
        {

            get
            {

                return myBeforeAction;

            }
            set
            {

                if(myBeforeAction != value)
                {

                    if(value == null)
                        throw new Exception("Action cannot be null");

                    myBeforeAction = value;

                }

            }
 
        }
        
        public override void Execute(object TheObject)
        {

            myBeforeAction();

            myStateChangedAction((TType)TheObject);
            
        }

    }

}
