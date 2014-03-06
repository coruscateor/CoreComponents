using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.OOM
{

    public class PropertyValuesUpdatedEventArgs<TSender> : ValuesUpdatedEventArgs<TSender,PropertyInfo>
    {

        public PropertyValuesUpdatedEventArgs(TSender TheSender, object TheMonitoredObject, IEnumerable<KeyValuePair<PropertyInfo, object>> TheUpdatedItems)
            : base(TheSender, TheMonitoredObject, TheUpdatedItems) 
        {
        }

    }

}
