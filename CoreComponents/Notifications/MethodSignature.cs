using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Items;

namespace CoreComponents.Notifications
{

    public class MethodSignature
    {

        protected readonly Type[] myGenericArguments;

        protected readonly ParameterInfo[] myParameters;

        public MethodSignature(MethodInfo TheMethodInfo)
        {

            ReturnParameter = TheMethodInfo.ReturnParameter;

            ReturnType = TheMethodInfo.ReturnType;

            ReturnTypeCustomAttributes = TheMethodInfo.ReturnTypeCustomAttributes;

            ContainsGenericParameters = TheMethodInfo.ContainsGenericParameters;

            IsAbstract = TheMethodInfo.IsAbstract;

            IsAssembly = TheMethodInfo.IsAssembly;

            IsConstructor = TheMethodInfo.IsConstructor;

            IsFamily = TheMethodInfo.IsFamily;

            IsFamilyAndAssembly = TheMethodInfo.IsFamilyAndAssembly;

            IsFamilyOrAssembly = TheMethodInfo.IsFamilyOrAssembly;

            IsFinal = TheMethodInfo.IsFinal;

            IsGenericMethod = TheMethodInfo.IsGenericMethod;

            IsGenericMethodDefinition = TheMethodInfo.IsGenericMethodDefinition;

            IsPrivate = TheMethodInfo.IsPrivate;

            IsPublic = TheMethodInfo.IsPublic;

            IsStatic = TheMethodInfo.IsStatic;

            IsVirtual = TheMethodInfo.IsVirtual;

            myGenericArguments = TheMethodInfo.GetGenericArguments();

            myParameters = TheMethodInfo.GetParameters();

        }

        public static bool operator ==(MethodSignature left, MethodSignature right)
        {

            if(left.ReturnParameter != right.ReturnParameter)
                return false;

            if(left.ReturnType != right.ReturnType)
                return false;

            if(left.ReturnTypeCustomAttributes != right.ReturnTypeCustomAttributes)
                return false;

            if(left.ContainsGenericParameters != right.ContainsGenericParameters)
                return false;

            if(left.IsAbstract != right.IsAbstract)
                return false;

            if(left.IsAssembly != right.IsAssembly)
                return false;

            if(left.IsConstructor != right.IsConstructor)
                return false;

            if(left.IsFamily != right.IsFamily)
                return false;

            if(left.IsFamilyAndAssembly != right.IsFamilyAndAssembly)
                return false;

            if(left.IsFamilyOrAssembly != right.IsFamilyOrAssembly)
                return false;

            if(left.IsFinal != right.IsFinal)
                return false;

            if(left.IsGenericMethod != right.IsGenericMethod)
                return false;

            if(left.IsGenericMethodDefinition != right.IsGenericMethodDefinition)
                return false;

            if(left.IsPrivate != right.IsPrivate)
                return false;

            if(left.IsPublic != right.IsPublic)
                return false;

            if(left.IsStatic != right.IsStatic)
                return false;

            if(left.IsVirtual != right.IsVirtual)
                return false;

            if(left.GetGenericArguments() != right.GetGenericArguments())
                return false;

            if(left.GetParameters() != right.GetParameters())
                return false;

            return true;

        }

        public static bool operator !=(MethodSignature left, MethodSignature right)
        {

            if(left.ReturnParameter == right.ReturnParameter)
                return false;

            if(left.ReturnType == right.ReturnType)
                return false;

            if(left.ReturnTypeCustomAttributes == right.ReturnTypeCustomAttributes)
                return false;

            if(left.ContainsGenericParameters == right.ContainsGenericParameters)
                return false;

            if(left.IsAbstract == right.IsAbstract)
                return false;

            if(left.IsAssembly == right.IsAssembly)
                return false;

            if(left.IsConstructor == right.IsConstructor)
                return false;

            if(left.IsFamily == right.IsFamily)
                return false;

            if(left.IsFamilyAndAssembly == right.IsFamilyAndAssembly)
                return false;

            if(left.IsFamilyOrAssembly == right.IsFamilyOrAssembly)
                return false;

            if(left.IsFinal == right.IsFinal)
                return false;

            if(left.IsGenericMethod == right.IsGenericMethod)
                return false;

            if(left.IsGenericMethodDefinition == right.IsGenericMethodDefinition)
                return false;

            if(left.IsPrivate == right.IsPrivate)
                return false;

            if(left.IsPublic == right.IsPublic)
                return false;

            if(left.IsStatic == right.IsStatic)
                return false;

            if(left.IsVirtual == right.IsVirtual)
                return false;

            if(left.GenericArgumentsAreEqual(right.GetGenericArguments()))
                return false;

            if(left.ParameterArgumentsAreEqual(right.GetParameters()))
                return false;

            return true;

        }

        public static bool IsCompatableWith(MethodSignature left, MethodInfo right)
        {

            if(left.ReturnParameter != right.ReturnParameter)
                return false;

            if(left.ReturnType != right.ReturnType)
                return false;

            if(left.ReturnTypeCustomAttributes != right.ReturnTypeCustomAttributes)
                return false;

            if(left.ContainsGenericParameters != right.ContainsGenericParameters)
                return false;

            if(left.IsAbstract != right.IsAbstract)
                return false;

            if(left.IsAssembly != right.IsAssembly)
                return false;

            if(left.IsConstructor != right.IsConstructor)
                return false;

            if(left.IsFamily != right.IsFamily)
                return false;

            if(left.IsFamilyAndAssembly != right.IsFamilyAndAssembly)
                return false;

            if(left.IsFamilyOrAssembly != right.IsFamilyOrAssembly)
                return false;

            if(left.IsFinal != right.IsFinal)
                return false;

            if(left.IsGenericMethod != right.IsGenericMethod)
                return false;

            if(left.IsGenericMethodDefinition != right.IsGenericMethodDefinition)
                return false;

            if(left.IsPrivate != right.IsPrivate)
                return false;

            if(left.IsPublic != right.IsPublic)
                return false;

            if(left.IsStatic != right.IsStatic)
                return false;

            if(left.IsVirtual != right.IsVirtual)
                return false;

            if(!left.GenericArgumentsAreEqual(right.GetGenericArguments()))
                return false;

            if(!left.ParameterArgumentsAreEqual(right.GetParameters()))
                return false;

            return true;

        }

        public static bool IsInCompatableWith(MethodInfo left, MethodSignature right)
        {

            if(left.ReturnParameter == right.ReturnParameter)
                return false;

            if(left.ReturnType == right.ReturnType)
                return false;

            if(left.ReturnTypeCustomAttributes == right.ReturnTypeCustomAttributes)
                return false;

            if(left.ContainsGenericParameters == right.ContainsGenericParameters)
                return false;

            if(left.IsAbstract == right.IsAbstract)
                return false;

            if(left.IsAssembly == right.IsAssembly)
                return false;

            if(left.IsConstructor == right.IsConstructor)
                return false;

            if(left.IsFamily == right.IsFamily)
                return false;

            if(left.IsFamilyAndAssembly == right.IsFamilyAndAssembly)
                return false;

            if(left.IsFamilyOrAssembly == right.IsFamilyOrAssembly)
                return false;

            if(left.IsFinal == right.IsFinal)
                return false;

            if(left.IsGenericMethod == right.IsGenericMethod)
                return false;

            if(left.IsGenericMethodDefinition == right.IsGenericMethodDefinition)
                return false;

            if(left.IsPrivate == right.IsPrivate)
                return false;

            if(left.IsPublic == right.IsPublic)
                return false;

            if(left.IsStatic == right.IsStatic)
                return false;

            if(left.IsVirtual == right.IsVirtual)
                return false;

            if(!right.GenericArgumentsAreEqual(left.GetGenericArguments()))
                return false;

            if(!right.ParameterArgumentsAreEqual(left.GetParameters()))
                return false;

            return true;

        }

        public ParameterInfo ReturnParameter
        {
            
            get;
            protected set;
                    
        }

        public Type ReturnType
        {
            
            get;
            protected set;
        
        }

        public ICustomAttributeProvider ReturnTypeCustomAttributes
        {
            
            get;
            protected set;
            
        }
        
        public bool ContainsGenericParameters
        {

            get;
            protected set;

        }
        
        public bool IsAbstract
        {

            get;
            protected set;

        }
        
        public bool IsAssembly
        {

            get;
            protected set;

        }
        
        public bool IsConstructor
        {

            get;
            protected set;

        }
        
        public bool IsFamily
        {

            get;
            protected set;

        }
        
        public bool IsFamilyAndAssembly
        {

            get;
            protected set;

        }
        
        public bool IsFamilyOrAssembly
        {

            get;
            protected set;

        }

        public bool IsFinal
        {

            get;
            protected set;

        }
        
        public bool IsGenericMethod
        {

            get;
            protected set;

        }
        
        public virtual bool IsGenericMethodDefinition
        {

            get;
            protected set;

        }
        
        public bool IsPrivate
        {

            get;
            protected set;

        }

        public bool IsPublic
        {

            get;
            protected set;

        }
        
        public bool IsStatic
        {

            get;
            protected set;

        }
        
        public bool IsVirtual
        {

            get;
            protected set;

        }

        public Type[] GetGenericArguments()
        {

            return ArrayCopier<Type>.Clone(myGenericArguments);

        }

        public bool GenericArgumentsAreEqual(Type[] TheGenericArguments)
        {

            return ArrayValueChecker<Type>.ValuesEqual(myGenericArguments, TheGenericArguments);

        }
        
        public ParameterInfo[] GetParameters()
        {

            return  ArrayCopier<ParameterInfo>.Clone(myParameters);

        }

        public bool ParameterArgumentsAreEqual(ParameterInfo[] TheParameterInfos)
        {

            return ArrayValueChecker<ParameterInfo>.ValuesEqual(myParameters, TheParameterInfos);

        }

        public override bool Equals(object obj)
        {

            if(obj is MethodSignature)
            {

                return ((MethodSignature)obj) == this;

            }

            return false;

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

    }

}
