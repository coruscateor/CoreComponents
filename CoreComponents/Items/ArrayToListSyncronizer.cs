using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public abstract class ArrayToListSyncronizer<TList, TArray> where TList : IList
    {

        TList myList;

        public ArrayToListSyncronizer()
        {
        }

        public ArrayToListSyncronizer(TList theList)
        {

            myList = theList;

        }

        protected void Syncronize(TArray[] Items)
        {

            if (Items.Length > 0)
            {

                int LastArrayItem = Items.Length - 1;

                int LastListItem = myList.Count - 1;

                int CurrentLocation = 0;

                for (; CurrentLocation < LastListItem; CurrentLocation++)
                {

                    SyncronizeWithExisting(myList[CurrentLocation], Items[CurrentLocation]);

                }

                if (LastArrayItem > LastListItem)
                {

                    for (; CurrentLocation < LastArrayItem; CurrentLocation++)
                    {

                        AddNew(Items[CurrentLocation], Items[CurrentLocation]);

                    }

                } 
                else if (LastArrayItem < LastListItem)
                {

                    for (; CurrentLocation < LastListItem; CurrentLocation++)
                    {

                        RemoveExcess(Items[CurrentLocation], Items[CurrentLocation]);

                    }

                }

            }

        }

        protected abstract void SyncronizeWithExisting(object ListItem, TArray ArrayItem);

        protected abstract void AddNew(object ListItem, TArray ArrayItem);

        protected abstract void RemoveExcess(object ListItem, TArray ArrayItem);

        public TList List
        {

            get
            {

                return myList;

            }
            set
            {

                myList = value;

            }

        }

    }

}
