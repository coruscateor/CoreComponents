using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Tables
{

    public class TypedColumnTable : IList<ITypedColumn>
    {

        protected List<ITypedColumn> myColumns = new List<ITypedColumn>();

        public TypedColumnTable()
        {
        }

        public int Find(string TheName, out ITypedColumn TheColumn)
        {

            if(TheName == null)
                throw new Exception("string is null");

            if(myColumns.Count > 0)
            {

                for(int i = 0; i < myColumns.Count; ++i)
                {

                    ITypedColumn ColumnAtIndex = myColumns[i];

                    if(ColumnAtIndex.Name == TheName)
                    {

                        TheColumn = ColumnAtIndex;

                        return i;

                    }

                }

            }

            TheColumn = null;

            return -1;

        }

        public Type[] GetTypes()
        {

            if(myColumns.Count > 0)
            {

                Type[] Types = new Type[myColumns.Count];

                for(int i = 0; i < myColumns.Count; ++i)
                {

                    Types[i] = myColumns[i].Type;

                }

                return Types;

            }

            return new Type[0];

        }

        public string[] GetNames()
        {

            if(myColumns.Count > 0)
            {

                string[] Names = new string[myColumns.Count];

                for(int i = 0; i < myColumns.Count; ++i)
                {

                    Names[i] = myColumns[i].Name;

                }

                return Names;

            }

            return new string[0];

        }

        public int IndexOf(ITypedColumn item)
        {

            return myColumns.IndexOf(item);

        }

        public void Insert(int index, ITypedColumn item)
        {

            myColumns.Insert(index, item);

        }

        public void RemoveAt(int index)
        {
            
            myColumns.RemoveAt(index);

        }

        public ITypedColumn this[int index]
        {

            get
            {

                return myColumns[index];

            }
            set
            {

                myColumns[index] = value;

            }

        }

        public void Add(ITypedColumn item)
        {
            
            myColumns.Add(item);

        }

        public void Clear()
        {
            
            myColumns.Clear();

        }

        public bool Contains(ITypedColumn item)
        {
            
            return myColumns.Contains(item);

        }

        public void CopyTo(ITypedColumn[] array, int arrayIndex)
        {
            
            myColumns.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myColumns.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(ITypedColumn item)
        {

            return myColumns.Remove(item);

        }

        public bool Remove(string TheName)
        {

            if(TheName == null)
                throw new Exception("string is null");

            int IndexToRemove = -1;

            if(myColumns.Count > 0)
            {

                for(int i = 0; i < myColumns.Count; ++i)
                {

                    ITypedColumn ColumnAtIndex = myColumns[i];

                    if(ColumnAtIndex.Name == TheName)
                    {

                        IndexToRemove = i;

                    }

                }

            }

            if(IndexToRemove > -1)
            {

                myColumns.RemoveAt(IndexToRemove);

                return true;

            }

            return false;

        }

        protected ITypedColumn GetColumn(object TheItem)
        {

            Type ItemType = TheItem.GetType();

            if(ItemType.IsClass)
            {

                Type ReferenceColumnType = typeof(TypedReferenceColumn<>).MakeGenericType(ItemType);

                ITypedColumn RefColumn = (ITypedColumn)Activator.CreateInstance(ReferenceColumnType);

                RefColumn.AddObject(TheItem);

                return RefColumn;
            
            }

            Type ValueColumnType = typeof(TypedReferenceColumn<>).MakeGenericType(ItemType);

            ITypedColumn ValColumn = (ITypedColumn)Activator.CreateInstance(ValueColumnType);

            ValColumn.AddObject(TheItem);

            return ValColumn;


        }

        public void AddRow(IEnumerable<object> Items)
        {

            int CurrentIndex = 0;

            foreach(object Item in Items)
            {

                if(CurrentIndex == myColumns.Count)
                {

                    myColumns.Add(GetColumn(Item));

                    ++CurrentIndex;

                    continue;

                }

                myColumns[CurrentIndex].AddObject(Item);

                ++CurrentIndex;

            }

        }

        public bool TryFetch(Type TheType, int Index, out ITypedColumn TheColumn)
        {

            if(Index > -1 && Index < myColumns.Count)
            {

                ITypedColumn FoundColumn = myColumns[Index];
                
                bool Found = false;

                foreach(Type Item in FoundColumn.GetType().GetInterfaces())
                {

                    if(TheType == Item)
                    {

                        Found = true;

                        break;

                    }

                }

                if(Found)
                {

                    TheColumn = (ITypedColumn)Convert.ChangeType(FoundColumn, typeof(ITypedColumn<>).MakeGenericType(TheType));

                    return true;

                }

            }

            TheColumn = null;

            return false;

        }

        public bool TryFetch<T>(int Index, out ITypedColumn<T> TheColumn)
        {

            if(Index > -1 && Index < myColumns.Count)
            {

                ITypedColumn FoundColumn = myColumns[Index];

                if(FoundColumn is ITypedColumn<T>)
                {

                    TheColumn = (ITypedColumn<T>)FoundColumn;

                    return true;

                }

            }

            TheColumn = null;

            return false;

        }

        public IEnumerator<ITypedColumn> GetEnumerator()
        {
            
            return myColumns.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myColumns.GetEnumerator();

        }

    }

}
