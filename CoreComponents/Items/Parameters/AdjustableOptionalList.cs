using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Parameters
{
    public class AdjustableOptionalList<TKey, TValue> : OptionalList<TKey, TValue>
    {

        public event Gimmie<ChangeEventArgs<TKey, OptionalList<TKey, TValue>>>.GimmieSomethin AddingOption;

        public event Gimmie<ChangeEventArgs<TKey, OptionalList<TKey, TValue>>>.GimmieSomethin OptionAdded;

        public event Gimmie<ChangeEventArgs<TKey, OptionalList<TKey, TValue>>>.GimmieSomethin RemovingOption;

        public event Gimmie<ChangeEventArgs<TKey, OptionalList<TKey, TValue>>>.GimmieSomethin OptionRemoved;

        public AdjustableOptionalList()
        {

        }

        protected void OnAddingOption(TKey Item)
        {

            if(AddingOption != null)
                AddingOption(new ChangeEventArgs<TKey, OptionalList<TKey,TValue>>(this, Item));


        }

        protected void OnOptionAdded(TKey Item)
        {


            if (OptionAdded != null)
                OptionAdded(new ChangeEventArgs<TKey, OptionalList<TKey, TValue>>(this, Item));

        }

        protected void OnRemovingOption(TKey Item)
        {


            if (RemovingOption != null)
                RemovingOption(new ChangeEventArgs<TKey, OptionalList<TKey, TValue>>(this, Item));

        }

        protected void OnOptionRemoved(TKey Item)
        {


            if (OptionRemoved != null)
                OptionRemoved(new ChangeEventArgs<TKey, OptionalList<TKey, TValue>>(this, Item));

        }

        public void Add(TKey key, TValue value)
        {
			
			if(!myItemList.ContainsKey(key))
			{

            	OnAddingOption(key);

            	myItemList.Add(key, value);

            	OnOptionAdded(key);
				
			}

        }

        public void Remove(TKey key)
        {
			
			if(myItemList.ContainsKey(key))
			{

            	OnRemovingOption(key);

            	myItemList.Remove(key);

            	OnOptionRemoved(key);
			}
			
        }

    }
}
