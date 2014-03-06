using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Parameters
{
    //public class OptionalPropertyList : OptionalItemList<string, bool>
    //{

    //    //public OptionalPropertyList(Type TheType, IEnumerable<string> Exclusions)
    //    //{

    //    //    List<string> ExclusionSet = new List<string>(Exclusions);

    //    //    List<PropertyInfo> AllProperties = new List<PropertyInfo>(TheType.GetProperties());

    //    //    myItemList = new Dictionary<string,bool>();

    //    //    foreach (string s in ExclusionSet)
    //    //    {

    //    //        //if (p.Name.Equals(s))
    //    //        //{

    //    //        if (AllProperties.Contains(s))
    //    //        {
    //    //            AllProperties.Remove(p);
    //    //        }

    //    //        ExclusionSet.Remove(s);

    //    //        //}

    //    //    }

    //    //    if (AllProperties.Count != 0)
    //    //    {

    //    //        foreach (PropertyInfo p in AllProperties)
    //    //        {

    //    //            myItemList.Add(p.Name, false);

    //    //        }

    //    //    } else
    //    //    {

    //    //        OnError("No Properties left to Include", null);

    //    //    }

    //    //}

    //    public OptionalPropertyList(params string[] Params)
    //    {

    //        foreach (string s in Params)
    //        {

    //            myItemList.Add(s, false);

    //        }            

    //    }

    //}
}
