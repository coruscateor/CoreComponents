using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Items
{

    public class ParentedNamedList<TParent, TChild> : ParentedList<TParent, TChild>
        where TChild : IChild<TParent>, IHasName
    {

        public ParentedNamedList(TParent Parent) : base(Parent)
		{
			
		}

        public virtual TChild this[string name]
        {
            get
            {

                foreach (TChild Child in myChildren)
                {

                    if (Child.Name == name)
                    {

                        return Child;

                    }

                }

                return default(TChild);

            }
            set
            {

                if (!object.Equals(value, default(TChild)))
                {

                    int index = 0;

                    foreach (TChild Child in myChildren)
                    {

                        index++;

                        if (Child.Name == name)
                            break;

                    }

                    if (index >= myChildren.Count)
                        return;

                    TChild item = myChildren[index];

                    Remove(item);

                    //OnAdding(value);

                    myChildren.Insert(index, value);

                    item.Parent = myOwner;

                    OnAdded(value);

                }
            }
        }

        public virtual int GetIndex(string name)
        {

            int index = 0;

            foreach (TChild Child in myChildren)
            {

                index++;

                if (Child.Name == name)
                    break;

            }

            if (index >= myChildren.Count)
            {

                return -1;

            }

            return index;
                

        }

    }
}
