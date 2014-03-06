using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Text;

namespace CoreComponents.Markup
{
    public abstract class PropertyAttributeSet : TextEntity
    {

        public PropertyAttributeSet()
        {
        }

        public static void AppendAttributes<TType>(TType TheObject, StringBuilder SB)
        {

            Type TypeObject = typeof(TType);

            PropertyInfo[] Items = TypeObject.GetProperties(BindingFlags.IgnoreCase);

            foreach (PropertyInfo Item in Items)
            {
                
                AppendAttribute(Item.Name, TypeObject.InvokeMember(Item.Name, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, Type.DefaultBinder, TheObject, null), SB);

            }

        }

        public static void AppendAttributes<TType>(TType TheObject, StringBuilder SB, params string[] props)
        {

            Type TypeObject = typeof(TType);

            PropertyInfo[] Items = TypeObject.GetProperties(BindingFlags.IgnoreCase);

            List<string> propList = new List<string>(props);

            foreach (PropertyInfo Item in Items)
            {

                foreach(string prop in propList)
                {

                    if (Item.Name == prop)
                    {

                        AppendAttribute(Item.Name, TypeObject.InvokeMember(Item.Name, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, Type.DefaultBinder, TheObject, null), SB);

                        propList.Remove(prop);

                    }

                }

            }

        }

    }
}
