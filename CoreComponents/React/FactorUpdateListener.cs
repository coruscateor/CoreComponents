using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.React
{

    public class FactorUpdateListener : IList<IFactor>
    {

        protected List<IFactor> myFactorList = new List<IFactor>();

        protected Action<object> myOnUpdate;

        public FactorUpdateListener(Action<object> OnUpdateDelegate)
        {

            myOnUpdate = OnUpdateDelegate;

        }

        public FactorUpdateListener(Action<object> OnUpdateDelegate, IEnumerable<IFactor> Items)
        {

            myOnUpdate = OnUpdateDelegate;

            myFactorList.AddRange(Items);

        }

        public Action<object> OnUpdate
        {

            get
            {

                return myOnUpdate;

            }
            set
            {

                myOnUpdate = value;

            }

        }

        protected void Updated(object TheSender)
        {

            OnUpdate(TheSender);

        }

        public int IndexOf(IFactor item)
        {

            return myFactorList.IndexOf(item);

        }

        public void Insert(int index, IFactor item)
        {

            myFactorList.Insert(index, item);

        }

        public void RemoveAt(int index)
        {

            IFactor CurrentItem = myFactorList[index];

            CurrentItem.Updated -= Updated;

            myFactorList.Remove(CurrentItem);

        }

        public IFactor this[int index]
        {

            get
            {

                return myFactorList[index];

            }
            set
            {

                IFactor CurrentItem = myFactorList[index];

                CurrentItem.Updated -= Updated;

                value.Updated += Updated;
                
                myFactorList[index] = value;

            }

        }

        public void Add(IFactor item)
        {

            item.Updated += Updated;

            myFactorList.Add(item);

        }

        public void Clear()
        {
            
            foreach(var Item in myFactorList)
            {

                Item.Updated -= Updated;

            }

            myFactorList.Clear();

        }

        public bool Contains(IFactor item)
        {
            
            return myFactorList.Contains(item);

        }

        public void CopyTo(IFactor[] array, int arrayIndex)
        {

            myFactorList.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myFactorList.Count;

            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;

            }

        }

        public bool Remove(IFactor item)
        {
            
            if(myFactorList.Remove(item))
            {

                item.Updated -= Updated;

                return true;

            }

            return false;

        }

        public IEnumerator<IFactor> GetEnumerator()
        {

            return myFactorList.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myFactorList.GetEnumerator();

        }

    }

}
