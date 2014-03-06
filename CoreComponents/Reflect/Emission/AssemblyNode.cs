using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Data;

namespace CoreComponents.Reflect.Emission
{

    public class AssemblyNode : IGenericDataProvider<Assembly>
    {

        protected Assembly myAssembly;

        public AssemblyNode(Assembly theAssembly)
        {

            Engage(theAssembly);

        }
		
		protected void Engage(Assembly theAssembly)
		{
			
			if(myAssembly != theAssembly)
			{
				
				if(myAssembly != null)
					Disengage(myAssembly);
				
			}
				
			
		}
		
		protected void Disengage(Assembly theAssembly)
		{
			
			/*
			if(myAssembly != theAssembly)
				myAssembly = theAssembly;
			*/
			
		}
		
		public void Load()
		{
			
			//Engage(Assembly.
			
		}

		/*
        public Type[] Types
        {

            get
            {

                return myAssembly.GetTypes();

            }

        }

        public Type GetType(string name)
        {

            return myAssembly.GetType(name, false, true);

        }

        public Module[] Modules
        {

            get
            {

                return myAssembly.GetModules();

            } 

        }
		*/
    }
}
