using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Reflect
{
    public abstract class BaseTypeToTypeMapper<TType, TEntityComponentType>
    {

        //protected Lazy<Dictionary<MethodInfo, TEntityComponentType>> myLazyMethodMap = new Lazy<Dictionary<MethodInfo, TEntityComponentType>>();

        //protected Lazy<Dictionary<PropertyInfo, TEntityComponentType>> myLazyPropertyMap = new Lazy<Dictionary<PropertyInfo, TEntityComponentType>>();

        //protected Lazy<Dictionary<FieldInfo, TEntityComponentType>> myLazyFieldMap = new Lazy<Dictionary<FieldInfo, TEntityComponentType>>();

        public event Create<SenderEventArgs<BaseTypeToTypeMapper<TType, TEntityComponentType>>>.ADelegate MemberMapped;

        protected Lazy<Dictionary<MemberInfo, TEntityComponentType>> myLazyMemberMap = new Lazy<Dictionary<MemberInfo, TEntityComponentType>>();

        public BaseTypeToTypeMapper() 
        {
        }

        protected void OnMemberMapped() 
        {

            if (MemberMapped != null)
                MemberMapped(new SenderEventArgs<BaseTypeToTypeMapper<TType, TEntityComponentType>>(this));

        }

        public virtual void MapToMember(MemberInfo TheMemberInfo, TEntityComponentType EntityComponent)
        {

            myLazyMemberMap.Value.Add(TheMemberInfo, EntityComponent);

            OnMemberMapped();

        }

        /*
        public void MapToMethod(MethodInfo TheMethodInfo, TEntityComponentType EntityComponent) 
        {
            myLazyMethodMap.Value.Add(TheMethodInfo, EntityComponent);
        }

        public void MapToProperty(PropertyInfo ThePropertyInfo, TEntityComponentType EntityComponent)
        {

        }

        public void MapToField(FieldInfo TheFieldInfo, TEntityComponentType EntityComponent)
        {

        }
        */

    }
}
