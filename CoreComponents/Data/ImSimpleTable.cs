using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{

    public class ImSimpleTable
    {

        protected readonly ImSimpleColumnSet myColumns;

        protected readonly ImSimpleRows myRows;

        public ImSimpleTable()
        { 
        }

        public ImSimpleColumnSet Columns
        {

            get
            {

                return myColumns;

            }

        }

        public ImSimpleRows Rows
        {

            get
            {

                return myRows;

            }

        }

        public class ImSimpleColumnSet : IEnumerable<ImSimpleColumn>
        {

            protected readonly ImSimpleColumn[] myImSimpleColumns;

            public ImSimpleColumnSet(IEnumerable<ImSimpleColumn> TheImSimpleColumns)
            {

                myImSimpleColumns = TheImSimpleColumns.ToArray();

            }

            public bool Contains(ImSimpleColumn TheImSimpleColumn)
            {
 
                foreach(ImSimpleColumn Item in myImSimpleColumns)
                {

                    if (Item == TheImSimpleColumn)
                        return true;

                }

                return false;

            }

            public bool RefContains(ImSimpleColumn TheImSimpleColumn)
            {

                foreach (ImSimpleColumn Item in myImSimpleColumns)
                {

                    if (object.ReferenceEquals(Item, TheImSimpleColumn))
                        return true;
                    
                }

                return false;

            }

            public bool Contains(string TheName)
            {

                foreach (ImSimpleColumn Item in myImSimpleColumns)
                {

                    if (Item.Name == TheName)
                        return true;

                }

                return false;

            }

            public int IndexOf(ImSimpleColumn TheImSimpleColumn)
            {

                for(int i = 0; i < myImSimpleColumns.Length; i++)
                {
                    
                    if (myImSimpleColumns[i] == TheImSimpleColumn)
                        return i;

                }

                return -1;

            }

            public int RefIndexOf(ImSimpleColumn TheImSimpleColumn)
            {

                for (int i = 0; i < myImSimpleColumns.Length; i++)
                {

                    if (object.ReferenceEquals(myImSimpleColumns[i], TheImSimpleColumn))
                        return i;

                }

                return -1;

            }

            public int IndexOf(string TheColumnName)
            {

                for (int i = 0; i < myImSimpleColumns.Length; i++)
                {

                    if (myImSimpleColumns[i].Name == TheColumnName)
                        return i;

                }

                return -1;

            }

            public int IndexOf(string TheColumnName, Type TheType)
            {

                for (int i = 0; i < myImSimpleColumns.Length; i++)
                {

                    ImSimpleColumn Column = myImSimpleColumns[i];

                    if (Column.Name == TheColumnName && Column.Type == TheType)
                        return i;

                }

                return -1;

            }

            public int IndexOf<T>(string TheColumnName)
            {

                return IndexOf(TheColumnName, typeof(T));

            }

            public int Count
            {

                get
                {

                    return myImSimpleColumns.Length;

                }

            }

            public ImSimpleColumn[] ToArray()
            {

                return (ImSimpleColumn[])myImSimpleColumns.Clone();

            }
            
            public IEnumerator<ImSimpleColumn> GetEnumerator()
            {

                return (IEnumerator<ImSimpleColumn>)myImSimpleColumns.GetEnumerator();

            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {

                return myImSimpleColumns.GetEnumerator();

            }

        }

        public class ImSimpleColumn
        {

            protected readonly string myName;

            protected readonly Type myType;

            public ImSimpleColumn(string TheName)
            {

                myName = TheName;

                myType = typeof(object);

            }

            public ImSimpleColumn(string TheName, Type TheType)
            {

                myName = TheName;

                myType = TheType;

            }

            public string Name
            {

                get
                {

                    return myName;

                }
 
            }

            public Type Type
            {

                get
                {

                    return myType;

                }

            }

            public static bool operator==(ImSimpleColumn Left, ImSimpleColumn Right)
            {

                return Left.Name == Right.Name && Left.Type == Right.Type;

            }

            public static bool operator !=(ImSimpleColumn Left, ImSimpleColumn Right)
            {

                return Left.Name != Right.Name || Left.Type != Right.Type;

            }

        }

        public class ImSimpleColumn<T> : ImSimpleColumn
        {

            public ImSimpleColumn(string TheName) : base(TheName, typeof(T))
            {
            }

        }

    }

}
