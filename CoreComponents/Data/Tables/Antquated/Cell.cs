using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.Tables
{

    public class Cell<T> : IValueContainer<T>
    {

        public Cell()
        { 
        }

        public Cell(T TheValue)
        {

            Value = TheValue;

        }

        public T Value
        {

            get;
            set;
        }

    }

}
