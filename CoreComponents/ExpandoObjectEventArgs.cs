using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace CoreComponents
{
    public class ExpandoObjectEventArgs<TSender> : IDictionaryEventArgs<TSender, string, object>
    {

        public ExpandoObjectEventArgs(TSender TheSender, ExpandoObject TheKeyValueSet)
            : base(TheSender, (IDictionary<string, object>)TheKeyValueSet)
        {
        }

        public dynamic AsExpandoObject
        {

            get 
            {

                return (ExpandoObject)myKeyValueSet;

            }

        }

    }
}
