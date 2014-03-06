using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.OOM
{

    //Maintins a list of properties and values that are or were contained in those properties.
    //One of the expectations is that the values contined by the Properties vales list will be able to be haded over to annother
    //party for persistant storage for restoration at a later time among other uses.
    public class PropertyValueManager
    {

        public delegate void UpdatedPropertysDelegate(PropertyValuesUpdatedEventArgs<PropertyValueManager> Parameter);

        public delegate void MonitoredObjectChangedDelegate(MonitoredObjectChangedEventArgs<PropertyValueManager> Parameter);

        public event UpdatedPropertysDelegate PropertysHaveUpdated;

        public event MonitoredObjectChangedDelegate MonitoredObjectHasChanged;

        protected object myMonitoredObject;

        protected object myLockObject;

        //The list of propeties and their last "checked in" values. 
        protected Dictionary<PropertyInfo, object> myPropertyValuesList = new Dictionary<PropertyInfo, object>();

        protected bool myIsUpdating;

        public PropertyValueManager(object TheMonitoredObject)
        {

            myMonitoredObject = TheMonitoredObject;

            PropertyInfo[] MonitoredObjectTypePropertyInfo = myMonitoredObject.GetType().GetProperties();

            foreach(PropertyInfo PI in MonitoredObjectTypePropertyInfo)
            {

                if (PI.GetSetMethod() == null || PI.GetGetMethod() == null) 
                {

                    continue;

                }

                //Adds the method to the list and its value within the monitered at that time.
                myPropertyValuesList.Add(PI, PI.GetGetMethod().Invoke(myMonitoredObject, null));

            }

        }

        public void OnPropertysHaveUpdated(List<KeyValuePair<PropertyInfo, object>> TheUpdatedProperties) 
        {

            if (TheUpdatedProperties.Count > 0)
            {

                if (PropertysHaveUpdated != null)
                    PropertysHaveUpdated(new PropertyValuesUpdatedEventArgs<PropertyValueManager>(this, myMonitoredObject, TheUpdatedProperties));

            }

        }

        public void OnMonitoredObjectHasChanged(object ThePreviousObject, object TheCurrentObject ) 
        {

            if(MonitoredObjectHasChanged != null)
                MonitoredObjectHasChanged(new MonitoredObjectChangedEventArgs<PropertyValueManager>(this, ThePreviousObject, TheCurrentObject));

        }

        public void Update()
        {

            lock (myLockObject)
            {

                myIsUpdating = true;

                List<KeyValuePair<PropertyInfo, object>> UpdatedProperties = new List<KeyValuePair<PropertyInfo, object>>();

                foreach (KeyValuePair<PropertyInfo, object> Field in myPropertyValuesList) 
                {

                    object CurrentObject = Field.Key.GetGetMethod().Invoke(myMonitoredObject, null);

                    if (Field.Value.Equals(CurrentObject)) 
                    {

                        UpdatedProperties.Add(Field);

                    }

                }

                OnPropertysHaveUpdated(UpdatedProperties);

                myIsUpdating = false;

            }

        }

        public object MonitoredObject 
        {

            get 
            {

                return myMonitoredObject;

            }
            set 
            {

                lock (myLockObject) 
                {

                    if(!object.ReferenceEquals(myMonitoredObject, value))
                    {

                        object PreviousObject = myMonitoredObject;

                        myMonitoredObject = value;

                        OnMonitoredObjectHasChanged(PreviousObject, myMonitoredObject);

                    }

                }

            }

        }

        //public bool IsMonitoringAnObject

        //public void StopMonitoring

        public bool IsUpdating 
        {

            get 
            {

                return myIsUpdating;

            }

        }

    }

}
