using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public class StateConveyorEntry
    {

        //protected Action myDefaultAction;

        //protected Delegate myNextDelegate;

        protected object myObject;

        protected string myNextMethodName;

        protected string myBackMethodName;

        public StateConveyorEntry()
        { 
        }

        public object Object
        {

            get
            {

                return myObject;

            }

        }

        public string NextMethodName
        {

            get
            {

                return myNextMethodName;

            }

        }

        public string BackMethodName
        {

            get
            {

                return myBackMethodName;

            }

        }

    }

}
