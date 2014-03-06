using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;

namespace CoreComponents.SharedResources
{

    public abstract class BaseSecureResource
    {

        protected object myItem;

        protected object myLockObject;

        protected Thread myOwner;

        protected Type myTypeOfResource;

        public BaseSecureResource()
        {
        }

        public void ReAttemptInitailisation(object[] TheArguments = null, Type TheTypeOfResource = null)
        {

            lock (myLockObject)
            {

                if (myItem == null && IsOwnedByCurrentThread())
                {

                    Type TypeToUse;

                    if (myTypeOfResource != null)
                    {

                        TypeToUse = myTypeOfResource;

                    }
                    else
                    {

                        if (TheTypeOfResource != null)
                        {

                            TypeToUse = TheTypeOfResource;

                        }
                        else
                        {

                            throw new Exception();

                        }

                    }

                    if (TheArguments == null)
                    {

                        myItem = Activator.CreateInstance(TypeToUse);

                    }
                    else
                    {

                        myItem = Activator.CreateInstance(TypeToUse, TheArguments);

                    }

                    if (myTypeOfResource == null)
                    {

                        myTypeOfResource = TypeToUse;

                    }

                }

            }

        }

        public Thread Owner
        {

            get
            {

                return myOwner;

            }

        }

        public bool IsOwnedByCurrentThread()
        {

            return myOwner == Thread.CurrentThread;

        }

        public bool IsOwned
        {

            get
            {

                if (myOwner != null)
                {

                    return myOwner.IsAlive;

                }

                return false;

            }

        }

        public Type TypeOfResource()
        {

            return myTypeOfResource;

        }

        public bool HasTypeOfResource()
        {

            return myTypeOfResource != null;

        }

        public bool Aqure()
        {

            lock(myLockObject)
            {

                if (!IsOwned)
                {

                    myOwner = Thread.CurrentThread;

                    return true;

                }

            }

            return false;

        }

        public bool Exectute(string TheName, ref object ReturnValue, BindingFlags TheInvokeAttribute = BindingFlags.Default, Binder TheBinder = null, object[] TheArguments = null, ParameterModifier[] TheModifiers = null, System.Globalization.CultureInfo TheCulture = null, string[] TheNamedParameters = null)
        {

            lock(myLockObject)
            {

                if (!IsOwnedByCurrentThread())
                {

                    return false;

                }

            }

            ReturnValue = myTypeOfResource.InvokeMember(TheName, TheInvokeAttribute, TheBinder, myItem, TheArguments, TheModifiers, TheCulture, TheNamedParameters);

            return true;

        }

        public void Release()
        {

            if(IsOwnedByCurrentThread())
            {

                myOwner = null;

            }

        }

    }

}
