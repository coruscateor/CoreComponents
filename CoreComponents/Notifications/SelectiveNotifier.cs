using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Notifications
{
    
    public class SelectiveNotifier
    {

        protected MethodSignature myMethodSignature;

        protected UniqueItemList<Delegate> myDelegates = new UniqueItemList<Delegate>();
        
        public SelectiveNotifier()
        {
        }

        public SelectiveNotifier(MethodSignature TheMethodSignature)
        {

            myMethodSignature = TheMethodSignature;

        }

        public SelectiveNotifier(MethodInfo TheMethodInfo)
        {

            myMethodSignature = new MethodSignature(TheMethodInfo);

        }

        public MethodSignature MethodSignature
        {

            get
            {

                return myMethodSignature;

            }
            set
            {

                if(value == null)
                    throw new Exception("The provided MethodSignature must not be null");

                if(myMethodSignature == null)
                {

                    myMethodSignature = value;

                }
                else if(value != myMethodSignature)
                {

                    myDelegates.Clear();

                    myMethodSignature = value;

                }

            }

        }

        public void SetMethodSignature(MethodInfo TheMethodInfo)
        {

            MethodSignature = new MethodSignature(TheMethodInfo);

        }

        public int Count
        {

            get
            {

                return myDelegates.Count;

            }

        }

        public bool Add(Delegate TheDelegate)
        {

            if(MethodSignature.IsCompatableWith(myMethodSignature, TheDelegate.Method))
            {

                if(!myDelegates.Contains(TheDelegate))
                    return myDelegates.Add(TheDelegate);

            }

            return false;

        }

        public bool Remove(Delegate TheDelegate)
        {

            return myDelegates.Remove(TheDelegate);

        }

        public bool Contains(Delegate TheDelegate)
        {

            return myDelegates.Contains(TheDelegate);

        }

        public bool Contains(object TheTarget)
        {

            foreach(var Item in myDelegates)
            {

                if(Item.Target == TheTarget)
                    return true;

            }

            return false;

        }

        public int IndexOf(Delegate TheDelegate)
        {

            return myDelegates.IndexOf(TheDelegate);

        }

        public bool Insert(int TheIndex, Delegate TheDelegate)
        {

            return myDelegates.Insert(TheIndex, TheDelegate);

        }

        public void RemoveAt(int TheIndex)
        {

            myDelegates.RemoveAt(TheIndex);

        }

        public Delegate this[int TheIndex]
        {

            get
            {

                return myDelegates[TheIndex];

            }
            set
            {

                myDelegates[TheIndex] = value;

            }

        }

        public Delegate this[object TheObject]
        {

            get
            {

                foreach(var Item in myDelegates)
                {

                    if(Item.Target == TheObject)
                        return Item;

                }

                throw new Exception("Delegate not found");

            }

        }

        public bool TryGet(int TheIndex, out Delegate TheItem)
        {

            Delegate TheDelegateItem;

            bool Value = myDelegates.TryGet(TheIndex, out TheDelegateItem);

            if(Value)
            {

                TheItem = TheDelegateItem;

                return true;

            }

            TheItem = null;

            return false;

        }

        public long AddRange(IEnumerable<Delegate> TheItems)
        {

            long AddedItems = 0;

            foreach(var Item in TheItems)
            {

                if(myDelegates.Add(Item))
                {

                    unchecked
                    {

                        ++AddedItems;

                    }

                }

            }

            return AddedItems;

        }

        public void Clear()
        {

            myDelegates.Clear();

        }

        public void Notify()
        {

            foreach(var Item in myDelegates)
            {

                Item.DynamicInvoke();

            }

        }

        public void Notify(params object[] TheParameters)
        {

            foreach(var Item in myDelegates)
            {

                Item.DynamicInvoke(TheParameters);

            }

        }

        public void Notify(IEnumerable<object> TheParameters)
        {

            Notify(TheParameters.ToArray());

        }

        public void Notify(IToArray TheParameters)
        {

            Notify(TheParameters.ToArray());

        }

        public void Notify(IToArray<object> TheParameters)
        {

            Notify(TheParameters.ToArray());

        }

        public void Notify(IList<object> TheParameters)
        {

            Notify(TheParameters.ToArray());

        }

        public void NotifyAsync()
        {

            Delegate[] Delegates = myDelegates.ToArray();

            ThreadPool.QueueUserWorkItem((TheParameter) =>
            {

                foreach(var Item in myDelegates)
                {

                    Item.DynamicInvoke();

                }

            });

        }

        public void NotifyAsyncAll()
        {

            Delegate[] Delegates = myDelegates.ToArray();

            ThreadPool.QueueUserWorkItem((TheParameter) =>
            {

                foreach(var Item in myDelegates)
                {

                    ThreadPool.QueueUserWorkItem((TheParameter2) =>
                    {

                        Item.DynamicInvoke();

                    });

                }

            });

        }

        public void NotifyAsync(params object[] TheParameters)
        {

            Delegate[] Delegates = myDelegates.ToArray();

            ThreadPool.QueueUserWorkItem((TheParameter) =>
            {

                foreach(var Item in myDelegates)
                {

                    Item.DynamicInvoke(TheParameters);

                }

            });

        }

        public void NotifyAsyncAll(params object[] TheParameters)
        {

            Delegate[] Delegates = myDelegates.ToArray();

            ThreadPool.QueueUserWorkItem((TheParameter) =>
            {

                foreach(var Item in myDelegates)
                {

                    ThreadPool.QueueUserWorkItem((TheParameter2) =>
                    {

                        Item.DynamicInvoke(TheParameters);

                    });

                }

            });

        }

        public void NotifyExcluding(IList<object> TheExclusionList)
        {

            foreach(var Item in myDelegates)
            {

                if(!TheExclusionList.Contains(Item.Target))
                    Item.DynamicInvoke();

            }

        }

        public void NotifyExcluding(IList<object> TheExclusionList, IList<object> TheParameters)
        {

            foreach(var Item in myDelegates)
            {

                if(!TheExclusionList.Contains(Item.Target))
                    Item.DynamicInvoke(TheParameters);

            }

        }

        public void NotifyIncluding(IList<object> TheInclusionList)
        {

            foreach(var Item in myDelegates)
            {

                if(TheInclusionList.Contains(Item.Target))
                    Item.DynamicInvoke();

            }

        }

        public void NotifyIncluding(IList<object> TheInclusionList, IList<object> TheParameters)
        {

            foreach(var Item in myDelegates)
            {

                if(TheInclusionList.Contains(Item.Target))
                    Item.DynamicInvoke(TheParameters);

            }

        }

    }

}
