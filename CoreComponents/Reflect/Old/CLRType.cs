using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Data;

namespace CoreComponents.Reflect
{
	public class CLRType : IOpenSourceProvider<Type>
	{

		protected Type myType;

        protected CLRAssembly myAssembly;
		
		public CLRType(Type theType)
		{

            myType = theType;
			
		}

        public CLRType(Type theType, CLRAssembly theAssembly)
		{

            myType = theType;

            VerafyAssembly(theType, theAssembly);
			
            //myType.

		}

        protected void VerafyAssembly(Type theType, CLRAssembly theAssembly)
        {

            if (theType.Assembly == theAssembly.Source)
            {

                myAssembly = theAssembly;

            }

        }

        public Type Source
        {
            get
            {
                return myType;
            }
        }


        public CLRAssembly Assembly
        {

            get
            {

                return myAssembly;

            }

        }

        public bool HasAssembly
        {

            get
            {

                return Return.IsNotNull<CLRAssembly>(myAssembly);

            }

        }

    }

}
