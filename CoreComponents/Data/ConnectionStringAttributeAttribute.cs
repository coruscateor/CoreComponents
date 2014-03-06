using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class ConnectionStringAttributeAttribute : Attribute
    {

        AttributeRequrementLevel myAttributeRequrementLevel = AttributeRequrementLevel.Optional;

        string myActualName = "";

        public ConnectionStringAttributeAttribute() 
        {
        }

        public ConnectionStringAttributeAttribute(AttributeRequrementLevel TheLevel)
        {

            myAttributeRequrementLevel = TheLevel;

        }

        public ConnectionStringAttributeAttribute(string TheActualName)
        {

            myActualName = TheActualName;

        }

        public ConnectionStringAttributeAttribute(string TheActualName, AttributeRequrementLevel TheLevel)
        {

            myAttributeRequrementLevel = TheLevel;

            myActualName = TheActualName;

        }


        public AttributeRequrementLevel AttributeRequrementLevel
        {

            get 
            {

                return myAttributeRequrementLevel;

            }

        }

        public string ActualName
        {

            get 
            {

                return myActualName;

            }

        }

        //Has a different name for output from the property it is attached to.
        public bool HasADifferentName() 
        {

            return myActualName.Length > 0; 
                
        }

    }

    public enum AttributeRequrementLevel
    {

        Optional,
        Requred,
        IncludeRegardLess //Can be empty or null


    }
}
