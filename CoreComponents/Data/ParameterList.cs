using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Reflection;

namespace CoreComponents.Data
{

    public class ParameterList<TParameter> : IParameterList<TParameter>, IList<TParameter>, IToArray<TParameter> where TParameter : DbParameter, new()
    {

        protected List<TParameter> myParameters;

        public ParameterList()
        {

            myParameters = new List<TParameter>();

        }

        public ParameterList(IEnumerable<TParameter> TheParameters)
        {

            myParameters = new List<TParameter>(TheParameters);

        }

        public ParameterList(int TheCapacity)
        {

            myParameters = new List<TParameter>(TheCapacity);

        }

        public int IndexOf(TParameter TheItem)
        {

            return myParameters.IndexOf(TheItem);

        }

        public void Insert(int TheIndex, TParameter TheItem)
        {

            myParameters.Insert(TheIndex, TheItem);

        }

        public void RemoveAt(int TheIndex)
        {

            myParameters.RemoveAt(TheIndex);

        }

        public TParameter this[int TheIndex]
        {

            get
            {

                return myParameters[TheIndex];

            }
            set
            {

                myParameters[TheIndex] = value;

            }

        }

        public void Add(TParameter TheItem)
        {
            
            myParameters.Add(TheItem);

        }

        public void AddRange(IEnumerable<TParameter> TheCollection)
        {

            foreach(var Item in TheCollection)
            {

                myParameters.Add(Item);

            }

        }

        public void Add(object TheValue)
        {

            TParameter NewParameter = new TParameter();

            NewParameter.Value = TheValue;

            myParameters.Add(NewParameter);
        }

        public void Add(string TheName, object TheValue)
        {

            TParameter NewParameter = new TParameter();

            NewParameter.ParameterName = TheName;

            NewParameter.Value = TheValue;

            myParameters.Add(NewParameter);
        }

        public void Swap(int FirstIndex, int SecondIndex)
        {

            TParameter Item1 = myParameters[FirstIndex];

            TParameter Item2 = myParameters[SecondIndex];

            myParameters[FirstIndex] = Item2;

            myParameters[SecondIndex] = Item1;

        }

        public void Set(int Index, object TheValue)
        {

            myParameters[Index].Value = TheValue;

        }

        public void Set(int Index, string TheName, object TheValue)
        {

            TParameter Item = myParameters[Index];

            Item.ParameterName = TheName;

            Item.Value = TheValue;

        }

        public bool TrySet(int Index, object TheValue)
        {

            if(myParameters.Count < 1)
                return false;

            if(Index < 0)
                return false;

            if(Index >= myParameters.Count)
                return false;

            myParameters[Index].Value = TheValue;

            return true;

        }

        public bool TrySet(int Index, string TheName, object TheValue)
        {

            if(myParameters.Count < 1)
                return false;

            if(Index < 0)
                return false;

            if(Index >= myParameters.Count)
                return false;

            TParameter Item = myParameters[Index];

            Item.ParameterName = TheName;

            Item.Value = TheValue;

            return true;

        }

        public void AddTo(DbParameterCollection TheCollection)
        {

            foreach(var Item in myParameters)
            {

                TheCollection.Add(Item);

            }

        }

        public void AddToAndClear(DbParameterCollection TheCollection)
        {

            foreach(var Item in myParameters)
            {

                TheCollection.Add(Item);

            }

            myParameters.Clear();

        }

        public void AddTo(DbCommand TheCommand)
        {

            AddTo(TheCommand.Parameters);

        }

        public void AddToAndClear(DbCommand TheCommand)
        {

            AddToAndClear(TheCommand.Parameters);

        }

        public void SetParametersOf(DbParameterCollection TheCollection)
        {

            TheCollection.Clear();

            AddToAndClear(TheCollection);

        }

        public void SetParametersOf(DbCommand TheCommand)
        {

            TheCommand.Parameters.Clear();

            AddToAndClear(TheCommand.Parameters);

        }

        public void GetFrom(object TheObject)
        {

            Type ObjectType = TheObject.GetType();

            foreach(var Item in ObjectType.GetProperties(BindingFlags.Public))
            {

                MethodInfo GetMethod = Item.GetMethod;

                if(GetMethod == null)
                    continue;

                bool Ignore = false;

                string NameToUse = null;

                foreach(var Attribute in Item.GetCustomAttributes(false))
                {

                    Type AttributeType = Attribute.GetType(); 

                    if(AttributeType == typeof(IgnoreAttribute))
                    {

                        Ignore = true;

                        break;

                    }

                    if(AttributeType == typeof(NameAttribute))
                    {

                        NameToUse = ((NameAttribute)Attribute).Name;

                    }

                }

                if(Ignore)
                    break;

                if(NameToUse == null)
                {

                    NameToUse = Item.Name;

                }

                Add(NameToUse, GetMethod.Invoke(TheObject, null));

            }

        }

        public void GetFromItems(IDictionary<string, object> Items)
        {

            foreach(var Item in Items)
            {

                Add(Item.Key, Item.Value);

            }

        }

        public void GetFromItems(dynamic Items)
        {

            GetFrom((IDictionary<string, object>)Items);

        }

        public void SetFrom(object TheObject)
        {

            myParameters.Clear();

            GetFrom(TheObject);

        }

        public void SetFromItems(IDictionary<string, object> Items)
        {

            myParameters.Clear();

            GetFromItems(Items);

        }

        public void SetFromItems(dynamic Items)
        {

            myParameters.Clear();

            GetFromItems(Items);

        }

        public void Clear()
        {

            myParameters.Clear();

        }

        public bool Contains(TParameter TheItem)
        {

            return myParameters.Contains(TheItem);

        }

        public void CopyTo(TParameter[] TheArray, int TheArrayIndex)
        {

            myParameters.CopyTo(TheArray, TheArrayIndex);

        }

        public int Count
        {

            get
            {

                return myParameters.Count;

            }

        }

        public bool IsReadOnly
        {

            get
            {

                return false;

            }

        }

        public bool Remove(TParameter TheItem)
        {
            
            return myParameters.Remove(TheItem);

        }

        public bool RemoveFirst()
        {

            if(myParameters.Count < 1)
                return false;

            TParameter FirstItem = myParameters[0];

            return myParameters.Remove(FirstItem);

        }

        public bool RemoveLast()
        {

            if(myParameters.Count < 1)
                return false;

            TParameter LastItem = myParameters[myParameters.Count - 1];

            return myParameters.Remove(LastItem);

        }

        public IEnumerator<TParameter> GetEnumerator()
        {

            return myParameters.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myParameters.GetEnumerator();

        }

        public TParameter[] ToArray()
        {

            return myParameters.ToArray();

        }

    }

}
