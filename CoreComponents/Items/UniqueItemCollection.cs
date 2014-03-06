using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class UniqueItemCollection<T> : Collection<T>
    {

        bool myThrowIfDuplicateFound = false;

        public UniqueItemCollection()
        {
        }

        public UniqueItemCollection(IEnumerable<T> TheItems)
        {

            foreach(T Item in TheItems)
            {

                Add(Item);

            }

        }

        protected override void InsertItem(int index, T item)
        {

            if(!Contains(item))
            {

                base.InsertItem(index, item);

            }
            else
            {

                if(myThrowIfDuplicateFound)
                    throw new Exception("Item already Exists in Collection");

            }

        }

        protected override void SetItem(int index, T item)
        {

            if(!Contains(item))
            {

                base.SetItem(index, item);

            }
            else
            {

                if(myThrowIfDuplicateFound)
                    throw new Exception("Item already Exists in Collection");

            }

        }

        public bool ThrowIfDuplicateFound
        {

            get
            {

                return myThrowIfDuplicateFound;

            }
            set
            {

                myThrowIfDuplicateFound = value;

            }

        }

        public int Validate()
        {

            if(Count > 1)
            {

                int Remainder = 0;

                int RemovedCount = 0;

                for(int i = 0; i < Count; ++i)
                {

                    Remainder = Count - i - 1;

                    if(Remainder > 1)
                    {

                        T CurrentValue = this[i];

                        for(; Remainder < Count; --Remainder)
                        {

                            T Value = this[i];

                            if(CurrentValue.Equals(Value))
                            {

                                Remove(Value);

                                ++RemovedCount;

                            }

                        }

                    }

                }

                return RemovedCount;

            }

            return 0;

        }

    }

}
