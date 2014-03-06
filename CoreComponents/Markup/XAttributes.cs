using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CoreComponents;
using CoreComponents.Items;
using CoreComponents.Text;

namespace CoreComponents.Markup
{

    public interface IXAttribute : ITextEntity
    {

        string Key
        {

            get;

        }

        Type GetTypeOfValue();

        string GetValue();

    }

    public abstract class AXAttribute : TextEntity, IXAttribute
    {

        protected string myKey;

        public AXAttribute()
        {
        }

        public string Key
        {

            get
            {

                return myKey;

            }

        }

        public abstract Type GetTypeOfValue();

        public abstract bool ValueIsType<TTypeValue>();

        //public abstract TValue GetValue<TValue>();

        public abstract string GetValue();

    }


    public abstract class AXAttribute<TValue> : AXAttribute
    {

        public event Gimmie<ChangeEventArgs<TValue, AXAttribute<TValue>>>.GimmieSomethin ValueChanged;

        protected TValue myValue;

        public AXAttribute()
        {
        }

        public AXAttribute(string Key)
        {

            myKey = Key;

        }

        public AXAttribute(string Key, TValue Value)
        {

            myKey = Key;
            myValue = Value;

        }

        public TValue Value
        {

            get
            {

                return myValue;

            }
            set
            {

                TValue OldValue = myValue;

                myValue = value;

                OnValueChanged(OldValue);

            }

        }

        public override Type GetTypeOfValue()
        {

            return typeof(TValue);

        }

        public override bool ValueIsType<TTypeValue>()
        {

            return typeof(TValue) is TTypeValue;
            //return TTypeValue is typeof(TValue);

        }

        protected void OnValueChanged(TValue Item)
        {

            if (ValueChanged != null)
                ValueChanged(new ChangeEventArgs<TValue, AXAttribute<TValue>>(this, Item));

        }

        //public override TMyValue GetValue<TMyValue>()
        //{

        //    return (TMyValue)myValue;  //Error	1	Cannot convert type 'TValue' to 'TMyValue'	C:\SoftwareProjects\CSharp\CoreComponents\CoreComponents\Text\Markup\XAttributes.cs	88	20	CoreComponents

        //}

        //public override string GetValue()
        //{

        //    return (TMyValue)myValue;  //Error	1	Cannot convert type 'TValue' to 'TMyValue'	C:\SoftwareProjects\CSharp\CoreComponents\CoreComponents\Text\Markup\XAttributes.cs	88	20	CoreComponents

        //}

        protected override void Append(StringBuilder SB)
        {
            AppendAttribute(myKey, GetValue(), SB);
        }

    }

    public interface IXStringAttribute : IXAttribute
    {

        string Value
        {

            get;
            set;

        }

    }

    public class XStringAttribute : AXAttribute<string>
    {

        public XStringAttribute(string Key)
        {

            myKey = Key;

        }

        public XStringAttribute(string Key, string Value)
        {

            myKey = Key;
            myValue = Value;

        }

        public override string GetValue()
        {

            return myValue;

        }

    }

    public interface IXIntAttribute : IXAttribute
    {

        int Value
        {

            get;
            set;

        }

    }

    public class XIntAttribute : AXAttribute<int>, IXIntAttribute
    {

        public XIntAttribute (string Key)
        {

            myKey = Key;

        }

        public XIntAttribute (string Key, int Value)
        {

            myKey = Key;

            myValue = Value;

        }

        public override string GetValue()
        {

            return Convert.ToString(myValue);

        }

    }

    //public interface IAttributeList : ITextEntity
    //{
    //}

    public interface IReadonlyXAttributeList : ICountableNameableIndexable<IXAttribute> //where TXAttribute : IXAttribute
    {
    }


    public interface IReadonlyXAttributeList<Sender> : IReadonlyXAttributeList, ISubscribeableSet<IXAttribute, Sender>
        where Sender : IReadonlyXAttributeList
    {
    }

    public abstract class AXAttributeList : TextEntity, IReadonlyXAttributeList, IReadonlyXAttributeList<AXAttributeList> //where Sender : IReadonlyXAttributeList
    {

        protected List<IXAttribute> myAttributeSet;
		
		public AXAttributeList()
		{
		}
		
		public AXAttributeList(IEnumerable<IXAttribute> Items)
		{
			myAttributeSet = new List<IXAttribute>(Items);
		}

        #region ICountableNameableIndexable<IXAttribute> Members

        public IXAttribute this[string name]
        {
            get
            {
                foreach (IXAttribute Attribute in myAttributeSet)
                {
                    if (Attribute.Key == name)
                        return Attribute;

                }

                return null;
            }
        }

        #endregion

        #region ICountableIndexable<IXAttribute> Members

        public IXAttribute this[int index]
        {
            get
            {
                return myAttributeSet[index];
            }
        }

        public int Count
        {
            get
            {
                return myAttributeSet.Count;
            }
        }

        #endregion

        #region IEnumerable<IXAttribute> Members

        public IEnumerator<IXAttribute> GetEnumerator()
        {
            return myAttributeSet.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return myAttributeSet.GetEnumerator();
        }

        #endregion

        #region ISubscribeableSet<IXAttribute,Sender> Members

        public event ChangedHandlers<IXAttribute, AXAttributeList>.ChangedHandler Added;

        public event ChangedHandlers<IXAttribute, AXAttributeList>.ChangedHandler Adding;

        public event ChangedHandlers<IXAttribute, AXAttributeList>.ChangedHandler Removed;

        public event ChangedHandlers<IXAttribute, AXAttributeList>.ChangedHandler Removing;

        public event Gimmie<SenderEventArgs<AXAttributeList>>.GimmieSomethin Clearing;

        public event Gimmie<SenderEventArgs<AXAttributeList>>.GimmieSomethin Cleared;

        #endregion

        protected void OnAdded(IXAttribute Item)
        {

            if(Added != null)
                Added(new ChangeEventArgs<IXAttribute, AXAttributeList>(this, Item));

        }

        protected void OnAdding(IXAttribute Item)
        {

              if(Adding != null)
                  Adding(new ChangeEventArgs<IXAttribute, AXAttributeList>(this, Item));

        }

        protected void OnRemoved(IXAttribute Item)
        {

              if(Removed != null)
                  Removed(new ChangeEventArgs<IXAttribute, AXAttributeList>(this, Item));

        }

        protected void OnRemoving(IXAttribute Item)
        {

              if(Removing != null)
                  Removing(new ChangeEventArgs<IXAttribute, AXAttributeList>(this, Item));

        }

        protected void OnClearing()
        {

            if (Clearing != null)
                Clearing(new SenderEventArgs<AXAttributeList>(this));

        }

        protected void OnCleared()
        {

            if (Cleared != null)
                Clearing(new SenderEventArgs<AXAttributeList>(this));

        }

        //public event Gimmie<SenderEventArgs<AXAttributeList>>.GimmieSomethin Cleared;
		
		protected override void Append(StringBuilder SB)
        {

            TextEntityDelimiter.Delimit<IXAttribute>(SB, myAttributeSet);

        }
    }

    public class XAttributeList : AXAttributeList, IIndexableNamedCollection<IXAttribute>
	{
		
		public XAttributeList()
		{
			myAttributeSet = new List<IXAttribute>();
		}

        public XAttributeList(IEnumerable<IXAttribute> Items) : base(Items)
		{
		}

        #region ICollection<IXAttribute> Members

        public void Add(IXAttribute Item)
        {

            OnAdding(Item);

            myAttributeSet.Add(Item);

            OnAdded(Item);
        }

        public void Clear()
        {

            OnClearing();

            myAttributeSet.Clear();

            OnCleared();
        }

        public bool Contains(IXAttribute Item)
        {
            return myAttributeSet.Contains(Item);
        }

        public void CopyTo(IXAttribute[] array, int arrayIndex)
        {

            myAttributeSet.CopyTo(array, arrayIndex);

        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(IXAttribute Item)
        {
            OnRemoving(Item);

            if (myAttributeSet.Remove(Item))
            {

                OnRemoved(Item);

                return true;

            }

            return false;
            
        }

        #endregion

        #region IEnumerable Members

        public new IEnumerator GetEnumerator()
        {
            return myAttributeSet.GetEnumerator();
        }

        #endregion
    }
	
}
