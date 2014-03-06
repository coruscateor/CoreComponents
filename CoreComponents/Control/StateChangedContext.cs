using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public class StateChangedContext<TType> : IParameterisedCommand
    {

        protected Action<TType> myStateChangedAction;

        public StateChangedContext()
        {
        }

        public StateChangedContext(Action<TType> TheStateChangedAction)
        {

            myStateChangedAction = TheStateChangedAction;

        }

        public Action<TType> StatedChangedAction
        {

            get
            {

                return myStateChangedAction;

            }
            set
            {

                if(myStateChangedAction != value)
                {

                    if(value == null)
                        throw new Exception("Action cannot be null");

                    myStateChangedAction = value;

                }

            }

        }

        public virtual void Execute(object TheObject)
        {

            myStateChangedAction((TType)TheObject);

        }

    }

}
