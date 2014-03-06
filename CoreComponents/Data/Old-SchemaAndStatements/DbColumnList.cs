using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbColumnList : ParentedList<DbTable, DbColumn> 
    {

        LazyObject<Dictionary<DbColumn, DbColumn>> myLazySubstituteColumns;

        public DbColumnList(DbTable Parent)
            : base(Parent)
        {
        }

        public IEnumerable<string> ColumnNames()
        {
            
            List<string> itemlist = new List<string>();

            foreach (DbColumn item in myChildren)
            {

                itemlist.Add(item.Name);

            }

            return itemlist;

        }

        public override void RemoveAt(int index)
        {

            if ((myChildren.Count - 1) >= index && index > 0)
            {

                DbColumn Column = myChildren[index];

                RemoveFromForignKeyListOrPrimaryKey(Column);

                base.RemoveAt(index);

            }

        }

        public override bool Remove(DbColumn Item)
        {

            if (base.Remove(Item))
            {

                RemoveFromForignKeyListOrPrimaryKey(Item);

                return true;

            }

            return false;

        }

        protected void RemoveFromForignKeyListOrPrimaryKey(DbColumn Item)
        {

            if (myOwner.PrimaryKey.Contains(Item))
            {

                myOwner.PrimaryKey.Remove(Item);

            }
            else if (myOwner.ForignKeys.ContainsKey(Item))
            {

                myOwner.ForignKeys.Remove(Item);

            }

        }

        public bool SetSubstituteColumns(DbColumn TargetColumn, DbColumn SubstituteColumn)
        {
            
            Dictionary<DbColumn, DbColumn> SubstituteColumns = myLazySubstituteColumns.Object;
            
            if (myChildren.Contains(TargetColumn) && myChildren.Contains(SubstituteColumn))
            {

                if (!SubstituteColumns.ContainsKey(TargetColumn) && !SubstituteColumns.ContainsValue(TargetColumn) && !SubstituteColumns.ContainsKey(SubstituteColumn) && !SubstituteColumns.ContainsValue(SubstituteColumn))
                {

                    SubstituteColumns.Add(TargetColumn, SubstituteColumn);

                    return true;

                }

            }

            return false;

        }

        public bool HasSubstituteColumns
        {

            get
            {

                if (myLazySubstituteColumns.HasObject)
                {

                    return myLazySubstituteColumns.Object.Count > 0;

                }

                return false;

            }

        }

        public int SubstituteColumnsCount
        {

            get
            {

                return myLazySubstituteColumns.Object.Count;

            }

        }

        public IEnumerator<KeyValuePair<DbColumn, DbColumn>> SubstituteColumnEnumerator
        {

            get
            {

                return myLazySubstituteColumns.Object.GetEnumerator();

            }

        }

        public bool ConstansTargetColumn(DbColumn TargetColumn)
        {

            return myLazySubstituteColumns.Object.ContainsKey(TargetColumn);

        }

        public bool ConstansSubstituteColumn(DbColumn SubstituteColumn)
        {

            return myLazySubstituteColumns.Object.ContainsKey(SubstituteColumn);

        }

        public void RemoveSubstituteColumn(DbColumn TargetColumn)
        {

            myLazySubstituteColumns.Object.Remove(TargetColumn);

        }

        public void ClearSubstituteColumns()
        {

            myLazySubstituteColumns.Object.Clear();

        }

        public Dictionary<DbColumn, DbColumn> CopySubstituteColumns()
        {

            return new Dictionary<DbColumn, DbColumn>(myLazySubstituteColumns.Object);

        }

    }

}
