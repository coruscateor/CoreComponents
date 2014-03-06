using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Control
{

    public class TypeDelegateExecutor
    {

        protected Dictionary<Type, Delegate> myTypesAndDelegates = new Dictionary<Type, Delegate>();

        public TypeDelegateExecutor()
        { 
        }

        public void Add(Type TheType, Delegate TheDelegate)
        {

            //if(TheDelegate.Method.ReturnType != typeof(void))
            //    throw new Exception();

            ParameterInfo[] ParameterInfos = TheDelegate.Method.GetParameters();

            if(ParameterInfos.Length > 1)
                throw new Exception("Method has too many parameters");

            if(ParameterInfos.Length < 1)
                throw new Exception("Method requires one parameter parameters");

            ParameterInfo Parameter = ParameterInfos[0];

            if(Parameter.IsOut)
                throw new Exception("The type of the parameter of the delegate must not be an Out parameter");

            //if(Parameter.IsRetval)
                //throw new Exception("The type of the parameter of the delegate must not be an Ref parameter");

            if(Parameter.ParameterType != TheType)
                throw new Exception("The type of the parameter of the delegate must be the same as the Identifying type");

            myTypesAndDelegates.Add(TheType, TheDelegate);

        }

        public void AddOrUpdate<TType>(Action<TType> TheDelegate)
        {

            Type TheType = typeof(TType);

            CheckContains(TheType);

            myTypesAndDelegates.Add(TheType, TheDelegate);

        }

        public void AddOrUpdate<TType, TResult>(Func<TType, TResult> TheDelegate)
        {

            Type TheType = typeof(TType);

            CheckContains(TheType);

            myTypesAndDelegates.Add(TheType, TheDelegate);

        }

        protected void CheckContains(Type TheType)
        {

            if(myTypesAndDelegates.ContainsKey(TheType))
                myTypesAndDelegates.Remove(TheType);

        }

        public object Invoke(object TheObject)
        {

            return myTypesAndDelegates[TheObject.GetType()].DynamicInvoke(TheObject);

        }

        public object Invoke<TReturn>(object TheObject)
        {

            return (TReturn)Invoke(TheObject);

        }

        public bool Contains(Type TheObject)
        {

            return myTypesAndDelegates.ContainsKey(TheObject);

        }

        public bool HasDelegate(Delegate TheDelegate)
        {

            return myTypesAndDelegates.ContainsValue(TheDelegate);

        }

        public bool GetType(Delegate TheDelegate, out Type TheFetchedType)
        {

            foreach(KeyValuePair<Type, Delegate> Item in myTypesAndDelegates)
            {

                if(TheDelegate == Item.Value)
                {

                    TheFetchedType = Item.Key;

                    return true;

                }

            }

            TheFetchedType = null;

            return false;

        }

        public int Count
        {

            get
            {

                return myTypesAndDelegates.Count;

            }

        }

    }

}
