using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Items
{   /*
    public class SingleChildToParentAdapter<TParent, TChild>
    {

        TParent myOwnersParent;

        TChild myOwner;

        static Type myParentType;

        PropertyInfo myChildRef;

        static SingleChildToParentAdapter()
        {

            myParentType = typeof(TParent);

        }

        public SingleChildToParentAdapter(string ChildRef)
        {

            myOwner = Owner;

            myChildRef = myParentType.GetProperty(ChildRef);

        }

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
                if (!object.Equals(myOwnersParent, default(TParent)))
                {

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
        */
        /*
        void SetCurrentParent()
        {

            MethodInfo PropMethod = myChildRef.GetGetMethod();

            myParentList = (TList)PropMethod.Invoke(myOwnersParent, null); //IParentedList<TParent, TChild>
        }
        */
        /*
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

    }*/
}
