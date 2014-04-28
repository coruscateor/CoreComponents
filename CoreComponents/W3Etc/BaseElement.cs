using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{

    public abstract class BaseElement : DynamicObject
    {

        protected string myName;

        protected string myNamespace;

        protected Dictionary<string, object> myAttributes;

        public BaseElement()
        {
        }

        public BaseElement(string TheName)
        {

            myName = TheName;

        }

        public BaseElement(string TheName, IDictionary<string, object> TheAttributes)
        {

            myName = TheName;

            foreach(var Item in TheAttributes)
            {

                myAttributes.Add(Item.Key, Item.Value);

            }

        }

        public string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public bool HasName
        {

            get
            {

                return string.IsNullOrWhiteSpace(myName);

            }

        }

        public string Namespace
        {

            get
            {

                return myNamespace;

            }
            set
            {

                myNamespace = value;

            }

        }


        public bool HasNamespace
        {

            get
            {

                return string.IsNullOrWhiteSpace(myNamespace);

            }

        }

        public Dictionary<string, object> Attributes
        {

            get
            {

                return myAttributes;

            }

        }

        public bool HasAttributes
        {

            get
            {

                return myAttributes.Count > 0;

            }

        }

        public void SetAttribute<T>(string TheKey, T TheValue)
        {

            myAttributes.Add(TheKey, TheValue.ToString());

        }

        public bool TryGetAttribute<T>(string TheKey, out T TheValue)
        {

            object TheFoundValue;

            if(myAttributes.TryGetValue(TheKey, out TheFoundValue))
            {

                TheValue = (T)Convert.ChangeType(TheFoundValue, typeof(T));

                return true;

            }

            TheValue = default(T);

            return false;

        }

        public bool TryGetAttribute<T>(string TheKey, out T TheValue, Func<object, T> TheConversionFunc)
        {

            object TheFoundValue;

            if(myAttributes.TryGetValue(TheKey, out TheFoundValue))
            {

                TheValue = TheConversionFunc(TheFoundValue);

                return true;

            }

            TheValue = default(T);

            return false;

        }

        public bool TryGetAttribute<T>(string TheKey, Action<T> TheValueAction)
        {

            object TheFoundValue;

            if(myAttributes.TryGetValue(TheKey, out TheFoundValue))
            {

                TheValueAction((T)Convert.ChangeType(TheFoundValue, typeof(T)));

                return true;

            }

            return false;

        }

        public bool TryGetAttribute<T>(string TheKey, Action<T> TheValueAction, Func<object, T> TheConversionFunc)
        {

            object TheFoundValue;

            if(myAttributes.TryGetValue(TheKey, out TheFoundValue))
            {

                TheValueAction(TheConversionFunc(TheFoundValue));

                return true;

            }

            return false;

        }

        public void AppendAttributes(StringBuilder TheSB)
        {

            if(myAttributes.Count > 0)
            {

                TheSB.Append(' ');

                foreach(var Item in myAttributes)
                {

                    TheSB.Append(Item.Key);

                    TheSB.Append(" = \"");

                    TheSB.Append(Item.Value);

                    TheSB.Append("\"");

                }

            }

        }

        public string GetAttributes()
        {

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            AppendAttributes(SB);

            string Result = SB.ToString();

            StringBuilderPool.Put(SB);

            return Result;

        }

        public void Start(StringBuilder TheSB)
        {

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            SB.Append('<');

            if(!string.IsNullOrWhiteSpace(myNamespace))
            {

                SB.Append(myNamespace);

                SB.Append(':');

            }

            SB.Append(myName);

        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {

            return myAttributes.Keys;

        }

        public override bool TryGetMember(GetMemberBinder TheBinder, out object TheResult)
        {

            object Value;

            if(myAttributes.TryGetValue(TheBinder.Name, out Value))
            {

                TheResult = Value;

                return true;

            }

            throw new ArgumentException("Property with the provided name does not exist");

        }

        public override bool TrySetMember(SetMemberBinder TheBinder, object TheValue)
        {

            if(!myAttributes.ContainsKey(TheBinder.Name))
            {

                myAttributes.Add(TheBinder.Name, TheValue);

            }
            else
            {

                myAttributes[TheBinder.Name] = TheValue;

            }

            return true;

        }

        public override bool TryDeleteMember(DeleteMemberBinder TheBinder)
        {

            return myAttributes.Remove(TheBinder.Name);

        }

    }

}
