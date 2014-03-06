using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.Tables
{

    public interface IColumn : IHasName
    {

        Type ValueType
        {

            get;

        }

        int Count
        {

            get;

        }

        object GetValue(int TheIndex);

        void Insert(int index, object TheItem);

        void RemoveAt(int index);

        void Clear();

        void Add();

        void Add(object TheItem);

    }

}
