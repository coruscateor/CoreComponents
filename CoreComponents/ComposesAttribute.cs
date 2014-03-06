using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents
{

    //Since we can't inherit from multiple classes, we should at least have a clear way to indicate what our objects are composed of.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ComposesAttribute : Attribute
    {

        protected readonly Type[] myTypes;

        public ComposesAttribute(params Type[] TheTypes)
        {

            if(TheTypes.Length > 0)
            {

                myTypes = TheTypes;

            }
            else
            {

                myTypes = new Type[] { typeof(object) };

            }

        }

        public Type[] Types
        {

            get
            {

                return ArrayCopier<Type>.Clone(myTypes);

            }

        }

    }

}
