using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Items
{
    public class ChildToParentAdapter<TParent, TChild, TList>
        where TChild : IChild<TParent>
        where TList : IParentedList<TParent, TChild>
    {

        TParent myOwnersParent;

        TChild myOwner;

        static Type myParentType;

        PropertyInfo myProperty;

        //IParentedList<TParent, TChild> myParentList;

        //ParentedList<TParent, TChild> myParentList;

		TList myParentList;
		
        static ChildToParentAdapter()
        {

            myParentType = typeof(TParent);

        }

        public ChildToParentAdapter(TChild Owner, string ListTypeName)
        {

            myOwner = Owner;

            myProperty = myParentType.GetProperty(ListTypeName);

        }

        //160310 PCS To stop the endless recursion situation where the parents are unaware of the children and vice versa,
        //           you change the Parent reference immediately so that when it is checked in the contaning list its child's
        //           Parent property isn't reassigned, if the child is being removed through a all to 'child.Parent'. 
        //           If Parent.Remove is called the Parent.FocusedChild property is set so that it can be checked by the
        //           child that it is being added or removed when the parent property is set.

        public void SetParent(TParent NewParent)
        {

            if (!object.Equals(myOwnersParent, NewParent))
            {

                TParent OldParent = myOwnersParent;
                
                myOwnersParent = NewParent;

                if (!object.Equals(OldParent, default(TParent)))
                {

                    if (!object.Equals(myParentList.FocusedChild(), myOwner)) //If my schema is not removing me.
                    {

                        myParentList.Remove(myOwner);

                        myParentList = default(TList);

                    }

                }

                //Owner's new parent is not null 
                if(!object.Equals(myOwnersParent, default(TParent))) {

                    //Update owners parent list reference.
                    SetCurrentParent(myOwnersParent);

                    //This is the parent list from the preivious owner. Reference is updated in SetCurrentParent(TParent NewParent)
                    if (!object.Equals(myParentList.FocusedChild(), myOwner)) //If my schema is not removing me.
                    {

                        myParentList.Add(myOwner);


                    }

                }

            }

        }

        void SetCurrentParent(TParent NewParent)
        {

            MethodInfo PropMethod = myProperty.GetGetMethod();

            myParentList = (TList)PropMethod.Invoke(myOwnersParent, null); //IParentedList<TParent, TChild>
        }

        public IChild<TParent> Owner
        {

            get
            {

                return myOwner;

            }

        }

        public TParent OwnersParent
        {

            get
            {

                return myOwnersParent;

            }

        }

        public bool OwnerIsOrphin()
        {
			
            return object.Equals(myOwnersParent, default(TParent));
			
        }
    }
}
