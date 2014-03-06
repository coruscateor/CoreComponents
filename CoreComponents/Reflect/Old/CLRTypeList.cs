using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Items;
using CoreComponents.Data;

namespace CoreComponents.Reflect
{

	public class CLRTypeList : ConcealedSourcedList<CLRAssembly, CLRType>
	{

        public CLRTypeList(CLRAssembly theSource) : base(theSource)
		{
		}

        protected override void TheSourceChanged(SenderEventArgs<CLRAssembly> e)
        {

            base.TheSourceChanged(e);

            SetTypes(e.Sender.Source);

        }

        protected void SetTypes(Assembly theAssembly)
        {

            myChildren.Clear();

            Type[] theTypeArray = theAssembly.GetTypes();

            foreach(Type T in theTypeArray)
            {

                //myChildren.Add(new CLRType(T, theAssembly));

            }

        }
		
	}
	
}
