using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.ComponentModel;

namespace CoreComponents.Data
{
    public abstract class ConnectionStringDetails
    {

        public static char DefaultAssignmentSymbol = '=';

        public static char DefaultAttributeSeparator = ';';

        //public event Create<ErrorEventArgs<ConnectionStringDetails>>.ADelegate Exception; 

        protected StringBuilder myStringBuilder = new StringBuilder();

        protected object myLockObject;

        protected char myAssignmentSymbol = DefaultAssignmentSymbol;

        protected char myAttributeSeparator = DefaultAttributeSeparator;

        public ConnectionStringDetails() 
        {
        }

        public abstract void Parse(string cs);

        public virtual void Parse(ConnectionStringSettings css) 
        {

            Parse(css.ConnectionString);

        }

        public virtual string GetString() 
        {

            
            return GetString<ConnectionStringDetails>(this);

        }

        protected void OnException(Exception e)
        {

            //if (Exception != null)
            //    Exception(new ErrorEventArgs<ConnectionStringDetails>(this, e));

        }

        protected virtual string GetString<TConnectionStringDetails>(TConnectionStringDetails Details) where TConnectionStringDetails : ConnectionStringDetails
        {

            lock (myLockObject)
            {

                lock (Details)
                {

                    //try...

                    myStringBuilder.Clear();

                    Type t = typeof(TConnectionStringDetails);

                    PropertyInfo[] CSAAProperties = GetPropertiesWithTheCSAA<TConnectionStringDetails>(t);

                    //t.GetProperties(

                    //ConnectionStringAttributeAttribute CSAA = Attribute.GetCustomAttribute(t, (Attribute)typeof(ConnectionStringAttributeAttribute));

                    foreach (PropertyInfo CSAAProperty in CSAAProperties) 
                    {

                        string PropertyValue = (string)CSAAProperty.GetValue(Details, null);

                        string PropertyNameToUse;

                        ConnectionStringAttributeAttribute Attribute = (ConnectionStringAttributeAttribute)(CSAAProperty.GetCustomAttributes(typeof(ConnectionStringAttributeAttribute), true))[0];
                        
                        //Has a name that is not the name of the property.
                        if (Attribute.HasADifferentName()) 
                        {

                            PropertyNameToUse = Attribute.ActualName;

                        } else
                        {
                            //Use the property name.
                            PropertyNameToUse = CSAAProperty.Name;

                        }

                        //Start butliding the string.
                        myStringBuilder.Append(PropertyNameToUse);
                        myStringBuilder.Append(myAssignmentSymbol);

                        if (PropertyValue.Length > 0)
                        {


                            string DefaultPropertyValue = GetDefaultValue(CSAAProperty);

                            if (DefaultPropertyValue.Length > 0)
                            {

                                PropertyValue = DefaultPropertyValue;

                            }

                            myStringBuilder.Append(PropertyValue);
                            continue;

                        }
                        //else
                        //{

                            switch (Attribute.AttributeRequrementLevel) 
                            {

                                case AttributeRequrementLevel.Requred:
                                    throw new Exception("Connectionstring attribute must have a value");
                                    //break;
                                case AttributeRequrementLevel.IncludeRegardLess:
                                    myStringBuilder.Append(myAttributeSeparator);
                                    continue;

                            }

                            //If the property doesnt have a value and is not Requred...
                            continue;

                        //}

                    }

               }

                return myStringBuilder.ToString();

             }

        }

        protected PropertyInfo[] GetPropertiesWithTheCSAA<TConnectionStringDetails>(Type TheConnectionStringDetailsType) 
        {

            List<PropertyInfo> PropertiesWithTheCSAA = new List<PropertyInfo>(TheConnectionStringDetailsType.GetProperties());

            //List<PropertyInfo> PropertiesWithNoCSAA = new List<PropertyInfo>();

            //Add the prperties with the CSAA only.
            foreach (PropertyInfo pi in PropertiesWithTheCSAA) 
            {

                object[] CSAAAttributes = pi.GetCustomAttributes(typeof(ConnectionStringAttributeAttribute), true);

                if (CSAAAttributes.Length > 0) 
                {

                    PropertiesWithTheCSAA.Add(pi);

                    continue;

                }

            }

            //Remove properties without the CSAA;
            //if (PropertiesWithNoCSAA.Count >= 0) 
            //{

            //    for(int i = 0; i < PropertiesWithNoCSAA.Count; i++) 
            //    {

            //        PropertiesWithTheCSAA.Remove(PropertiesWithNoCSAA[i]);

            //    }

            //}

            return PropertiesWithTheCSAA.ToArray();

        }

        protected string GetDefaultValue(PropertyInfo Property) 
        {

            DefaultValueAttribute DVA = (DefaultValueAttribute)(Property.GetCustomAttributes(typeof(DefaultValueAttribute), true))[0];

            //Property.PropertyType.to)

            return Convert.ToString(DVA.Value);

        }
        
        /*
        protected bool GetDefaultValueIsOfTheCorrectType(PropertyInfo Property, DefaultValueAttribute DVA) 
        {

            Type PType = Property.PropertyType;

            

        }
         */

    }
}
