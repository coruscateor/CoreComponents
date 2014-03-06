using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class UniqueParentedNamedList<TParent, TChild> : ParentedNamedList<TParent, TChild>
        where TChild : IChild<TParent>, IHasName
    {

        public event Action<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>> ItemExistsError;

        public UniqueParentedNamedList(TParent Parent)
            : base(Parent)
		{
			
		}

        protected void OnItemExistsError(TChild item)
        {

            if (ItemExistsError != null)
                ItemExistsError(new ChangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, item));

        }

        public new TChild this[string name]
        {
            get
            {

                return base[name];

            }
            set
            {

                if (!Return.IsInSet<TChild>(this, value))
                {

                    base[name] = value;

                } else
                {

                    OnItemExistsError(value);

                }

            }

        }

        public override void Add(TChild item)
        {

            //if(Return.IsInSet<TChild>(myChildern, item)

            if (!Return.IsInNamedSet<TChild>(this, item))
            {

                base.Add(item);

            } else
            {

                OnItemExistsError(item);

            }

        }

        public override void AddRange(IEnumerable<TChild> items)
        {

            List<TChild> ItemSet = new List<TChild>(items);

            for (int i = 0; ItemSet.Count > i; i++)
            {

                TChild item = ItemSet[i];

                if (Return.IsInSet<TChild>(ItemSet, item))
                {

                    ItemSet.Remove(item);

                } else
                {

                    OnItemExistsError(item);

                }

            }
            
            base.AddRange(items);

        }

    }

}
