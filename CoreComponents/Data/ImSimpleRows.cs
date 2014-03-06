using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data
{

    public class ImSimpleRows : ImDataCollection
    {

        protected ImSimpleTable myTable;

        public ImSimpleRows(ImSimpleTable TheTable, IEnumerable<IEnumerable<object>> TheData)
        {

            List<object> ItemSet = new List<object>();

            int TotalRows = TheData.Count();

            myRows = new object[TotalRows][];

            int CurrentRow = -1;

            foreach (IEnumerable<object> Item in TheData)
            {

                ItemSet.AddRange(Item);

                CurrentRow++;

                if (TheTable.Columns.Count < ItemSet.Count)
                {

                    int Ammount = TheTable.Columns.Count - ItemSet.Count;

                    for (; Ammount < 0; Ammount--)
                    {

                        ItemSet.RemoveAt(ItemSet.Count - 1);

                    }

                }

                myRows[CurrentRow] = (object[])ItemSet.ToArray();

                ItemSet.Clear();

            }

            myTable = TheTable;

        }

        public ImSimpleRows(ImSimpleTable TheTable, DataTable TheDataTable) : base(TheDataTable)
        {

            myTable = TheTable;

        }

    }

}
