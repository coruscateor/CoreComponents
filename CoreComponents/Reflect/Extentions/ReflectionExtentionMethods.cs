using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace CoreComponents.Reflect.Extentions
{

    public static class ReflectionExtentionMethods
    {

        public static List<MethodInfo> GetMethods(this Type TheType, Regex TheRegex)
        {

            List<MethodInfo> RetrivedMethodInfos;

            MethodInfo[] MethodInfos = TheType.GetMethods();

            int MethodInfosLength = MethodInfos.Length;

            if(MethodInfosLength > 0)
            {

                RetrivedMethodInfos = new List<MethodInfo>(MethodInfosLength);

                foreach(var Item in MethodInfos)
                {

                    if(TheRegex.IsMatch(Item.Name))
                        RetrivedMethodInfos.Add(Item);

                }

            }
            else
            {

                RetrivedMethodInfos = new List<MethodInfo>(0);

            }

            return RetrivedMethodInfos;

        }

    }

}
