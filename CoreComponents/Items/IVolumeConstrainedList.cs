using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Items
{
    public interface IVolumeConstrainedList<T> : IEditableList<T>
    {

        event Action<SenderEventArgs<IVolumeConstrainedList<T>>> LimitReached;

        int Limit
        {

            get;

        }

        //bool Editable
        //{

        //    get;

        //}

    }
}
