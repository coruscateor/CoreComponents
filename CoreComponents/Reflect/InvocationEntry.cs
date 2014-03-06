using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace CoreComponents.Reflect
{

    public class InvocationEntry
    {

        protected string myName;

        protected BindingFlags myInvokeAttribute = BindingFlags.Default;

        protected Binder myBinder;

        protected LazyObject<List<object>> myArguments;

        protected CultureInfo myCulture;

        protected LazyObject<List<ParameterModifier>> myModifiers;

        protected LazyObject<List<string>> myNamedParameters;

        protected object myResult;

        protected LazyObject<List<InvocationEntryResultToParameter>> myAssignResultTo;

        protected LazyObject<List<Type>> myGenericArguments;

        public InvocationEntry()
        { 
        }
        
        public virtual string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public virtual void SetName(MethodBase TheMethod)
        {

            myName = TheMethod.Name;

        }

        public virtual BindingFlags InvokeAttribute
        {

            get
            {

                return myInvokeAttribute;

            }
            set
            {

                myInvokeAttribute = value;

            }

        }

        public virtual Binder Binder
        {

            get
            {

                return myBinder;

            }
            set
            {

                myBinder = value;

            }

        }

        public virtual IList<object> Arguments
        {

            get
            {

                return myArguments.Object;

            }
 
        }

        public virtual CultureInfo Culture
        {

            get
            {

                return myCulture;

            }
            set
            {

                myCulture = value;

            }
            
        }

        public virtual IList<ParameterModifier> Modifiers
        {

            get
            {

                return myModifiers.Object;

            }

        }

        public virtual IList<string> NamedParameters
        {

            get
            {

                return myNamedParameters.Object;

            }

        }

        public virtual object Result
        {

            get
            {

                return myResult;

            }

        }

        public virtual T GetResult<T>()
        {

            return (T)myResult;

        }

        public virtual IList<InvocationEntryResultToParameter> AssignResultTo
        {

            get
            {

                return myAssignResultTo.Object;

            }

        }

        public virtual IList<Type> GenericArguments
        {

            get
            {

                return myGenericArguments.Object;

            }

        }

        public virtual bool HasGenericArguments
        {

            get
            {

                return myGenericArguments.HasObject && myGenericArguments.Object.Count > 0;

            }

        }

        public virtual void Invoke(object TheInstace)
        {

            object[] InvokeArguments = null;

            ParameterModifier[] InvokeModifiers = null;

            string[] InvokeNamedParameters = null;

            if(myArguments.HasObject)
            {

                InvokeArguments = myArguments.Object.ToArray();

            }

            if(myModifiers.HasObject)
            {

                InvokeModifiers = myModifiers.Object.ToArray();

            }

            if(myNamedParameters.HasObject)
            {

                InvokeNamedParameters = myNamedParameters.Object.ToArray();

            }

            Type TheType = TheInstace.GetType();

            if(HasGenericArguments)
            {

                MethodInfo InstaceMethod = TheType.GetMethod(myName).MakeGenericMethod(myGenericArguments.Object.ToArray());

                myResult = InstaceMethod.Invoke(TheInstace, myInvokeAttribute, myBinder, InvokeArguments, myCulture);

            }
            else
            {

                myResult = TheType.InvokeMember(myName, myInvokeAttribute, myBinder, TheInstace, InvokeArguments, InvokeModifiers, myCulture, InvokeNamedParameters);

            }

            if(myAssignResultTo.HasObject)
            {

                foreach(InvocationEntryResultToParameter Item in myAssignResultTo.Object)
                {

                    if(Item.HasInvocationEntry)
                    {

                        if(Item.ParameterPreference == ParameterPreference.Index)
                        {

                            if(Item.HasIndex)
                            {

                                IList<object> Arguments = Item.InvocationEntry.Arguments;

                                if(Item.Index < Arguments.Count)
                                {

                                    int Difference = Arguments.Count - Item.Index;

                                    if(Difference > 1)
                                    {

                                        Difference--;

                                        for(; Difference > 0; Difference--)
                                        {

                                            Arguments.Add(null);

                                        }

                                    }

                                    Arguments.Add(myResult);

                                }
                                else if(Item.Index < 0)
                                {

                                    continue;

                                }
                                else
                                {

                                    Arguments[Item.Index] = myResult;

                                }

                                continue;

                            }

                        }

                        if(Item.HasName)
                        {

                            InvocationEntry ItemInvocationEntry = Item.InvocationEntry;

                            IList<string> NamedParameters = ItemInvocationEntry.NamedParameters;

                            string Name = Item.Name;

                            if(!NamedParameters.Contains(Name))
                            {

                                NamedParameters.Add(Name);

                            }

                            int NameIndex = NamedParameters.IndexOf(Name);

                            IList<object> ItemArguments = ItemInvocationEntry.Arguments;

                            if(NameIndex > ItemArguments.Count)
                            {

                                int ItemArgumentsMaxIndex = ItemArguments.Count - 1;

                                while(NameIndex > ItemArgumentsMaxIndex)
                                {

                                    ItemArguments.Add(null);

                                }

                                ItemArguments.Add(myResult);

                            }
                            else
                            {

                                ItemInvocationEntry.Arguments[NameIndex] = myResult;

                            }

                        }

                    }

                }

            }

        }

    }

}
