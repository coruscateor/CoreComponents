using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control
{

    public class StateConveyor
    {

        protected List<StateConveyorEntry> myEntries = new List<StateConveyorEntry>();

        protected int myIndex;

        public StateConveyor()
        {
        }

        public void Add(Delegate TheDelegate)
        {

            //myEntries.Add(TheDelegate);

        }

        public void Next()
        {
        }

        public void Next(params object[] TheParameters)
        {
        }

        public bool CanProceed
        {

            get
            {
 
                return myIndex >= myEntries.Count - 1;

            }

        }

        public void Back()
        {
        }

        public bool CanGoBack
        {

            get
            {

                if(myEntries.Count > 1 && myIndex > 1)
                {



                }

                return false;

            }

        }

    }

}
