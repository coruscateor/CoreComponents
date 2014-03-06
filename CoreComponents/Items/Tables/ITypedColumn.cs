using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Tables
{

    public interface ITypedColumn : IHasName //, IList
    {

        Type Type
        {

            get;

        }

        int Count
        {

            get;

        }

        bool AddObject(object item);

        bool RemoveObject(object item);

        bool ContainsObject(object item);

        bool IndexOfObject(object item, out int index);

        bool InsertObject(int index, object item);

        void RemoveAt(int index);

    }

    public interface ITypedColumn<T> : ITypedColumn, IList<T>, IToArray<T>
    {

        CellValue<T> GetValue(int index);

        bool TryGetValue(int index, out T Value);

    }

}
