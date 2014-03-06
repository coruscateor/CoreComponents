using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CoreComponents.Items;

namespace CoreComponents.OOM
{
    public class ValuesUpdatedEventArgs<TSender, TMemberInfo> : SenderEventArgs<TSender> where TMemberInfo : MemberInfo
    {

        protected object myMonitoredObject;

        protected ReadOnlyList<KeyValuePair<TMemberInfo, object>> myUpdatedItemsList;

        protected DateTime myDateTime; //= DateTime.Now

        public ValuesUpdatedEventArgs(TSender TheSender, object TheMonitoredObject, IEnumerable<KeyValuePair<TMemberInfo, object>> TheUpdatedItems)
            : base(TheSender)
        {

            myDateTime = DateTime.Now;

            myMonitoredObject = TheMonitoredObject;

            myUpdatedItemsList = new ReadOnlyList<KeyValuePair<TMemberInfo, object>>(new List<KeyValuePair<TMemberInfo, object>>(TheUpdatedItems));

        }

        public ValuesUpdatedEventArgs(TSender TheSender, object TheMonitoredObject, params KeyValuePair<TMemberInfo, object>[] TheUpdatedItems)
            : base(TheSender)
        {

            myDateTime = DateTime.Now;

            myMonitoredObject = TheMonitoredObject;

            myUpdatedItemsList = new ReadOnlyList<KeyValuePair<TMemberInfo, object>>(new List<KeyValuePair<TMemberInfo, object>>(TheUpdatedItems));

        }

        public object MonitoredObject 
        {

            get 
            {
                
                return myMonitoredObject;

            }

        }

        public ReadOnlyList<KeyValuePair<TMemberInfo, object>> UpdatedItemsList 
        {

            get 
            {

                return myUpdatedItemsList;

            }

        }

        public DateTime DateTime 
        {

            get 
            {

                return myDateTime;

            }

        }

    }

}
