using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;

namespace CoreComponents.SharedResources
{

    public class SecureResource : BaseSecureResource
    {

        public SecureResource(Type TheTypeOfResource, bool Aquire = false)
        {

            myItem = Activator.CreateInstance(TheTypeOfResource);
            
            myTypeOfResource = TheTypeOfResource;

            if(Aquire)
            {

                myOwner = Thread.CurrentThread;

            }

        }

        public bool SucessfullyInitalised
        {

            get
            {

                return myItem != null;

            }

        }

    }

    public class SecureResource<TType> : BaseSecureResource
    {

        public SecureResource()
        {

            myItem = Activator.CreateInstance<TType>();

            myTypeOfResource = typeof(TType);

        }

        public void ReAttemptInitailisation(object[] TheArguments = null)
        {

            ReAttemptInitailisation(TheArguments, typeof(TType));

        }

        public void ReAttemptInitailisation<TTypeOfItem>(object[] TheArguments = null)
        {

            ReAttemptInitailisation(TheArguments, typeof(TTypeOfItem));

        }

    }

}
