using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application
{
    class SavingEventArgs<T, O> : LoadEventArgs<T>
    {

        O _SavingItem;

        public SavingEventArgs(T sender, string FileSource, O TheSavingItem) : base(sender, FileSource)
        {

            _SavingItem = TheSavingItem;

        }

        public O SavingItem
        {

            get
            {

                return _SavingItem;

            }

        }

    }

}
