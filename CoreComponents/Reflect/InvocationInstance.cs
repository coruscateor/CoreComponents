using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Reflect
{

    public class InvocationInstance
    {

        protected object myInstace;

        protected List<InvocationEntry> myInvocationEntrys = new List<InvocationEntry>();

        public InvocationInstance(object TheInstace)
        {

            myInstace = TheInstace;

        }

        public InvocationInstance(Type TheType)
        {

            myInstace = Activator.CreateInstance(TheType);

        }

        public InvocationInstance(Type TheType, object[] TheParameters)
        {

            myInstace = Activator.CreateInstance(TheType, TheParameters);

            //myInstace = Activator.CreateInstance(TheType, TheParameters, null); //??

        }

        public Type InstanceType
        {

            get
            {

                return myInstace.GetType();

            }

        }

        public object Instace
        {

            get
            {

                return myInstace;

            }
            set
            {

                myInstace = value;

            }

        }

        public List<InvocationEntry> InvocationEntrys
        {

            get
            {

                return myInvocationEntrys;

            }

        }

        public void Execute()
        {

            foreach(InvocationEntry Item in myInvocationEntrys)
            {

                Item.Invoke(myInstace);

            }

        }

    }

}
