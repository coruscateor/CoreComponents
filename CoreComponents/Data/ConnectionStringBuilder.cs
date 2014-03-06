using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Data
{
    public abstract class ConnectionStringBuilder : IConnectionStringBuilder
    {

        protected List<PropertyInfo> ConnectionPrameters;

        protected List<PropertyInfo> UsedPrameters = new List<PropertyInfo>();

        //Dictionary<string, bool> IncludedPrameters = new Dictionary<string, bool>();

        protected bool _AutoAdd = true;

        public ConnectionStringBuilder(Type CSBType)
        {

            ConnectionPrameters = new List<PropertyInfo>(CSBType.GetProperties());
            //IncludedPrameters
        }

        public void Add(string ParameterName)
        {

            foreach (PropertyInfo Parameter in ConnectionPrameters)
            {

                if (Parameter.Name == ParameterName)
                {

                    if (!UsedPrameters.Contains(Parameter))
                    {

                        UsedPrameters.Add(Parameter);

                    }

                    return;

                }

            }

        }

        public void Remove(string ParameterName)
        {

            foreach (PropertyInfo Parameter in ConnectionPrameters)
            {

                if (Parameter.Name == ParameterName)
                {

                    UsedPrameters.Remove(Parameter);

                    return;

                }

            }

        }

        public bool IsIncluded(string ParameterName)
        {

            foreach (PropertyInfo Parameter in UsedPrameters)
            {

                if (Parameter.Name == ParameterName)
                {

                    return true;

                }

            }

            return false;

        }

        public IEnumerable<KeyValuePair<string, string>> IncludedPrameters()
        {

           

            //List<string> TheIncludedPrameters = new List<string>();

            Dictionary<string, string> TheIncludedPrameters = new Dictionary<string,string>();

            foreach (PropertyInfo Parameter in UsedPrameters)
            {

                TheIncludedPrameters.Add(Parameter.Name, Parameter.PropertyType.FullName);

            }

            return TheIncludedPrameters;

        }


        protected void ClearStringBuilder(StringBuilder SB)
        {

                SB.Remove(0, SB.Length);

        }

        public bool IsAutoAdding()
        {
            return _AutoAdd;
        }

        public void InverseAutoAdd()
        {

            _AutoAdd = !_AutoAdd;

        }

        public virtual string ConnectionType
        {
            get
            {

                return "Generic";

            }
        }

        public override string ToString()
        {

            return "<Null>";

        }
    }
}
