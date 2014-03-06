using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application
{
    public class LoadedEventArgs<T, O> : LoadEventArgs<T>
    {

        O _LoadedItem;

        public LoadedEventArgs(T sender, string FileSource, O TheLoadedItem) : base(sender, FileSource)
        {

            _LoadedItem = TheLoadedItem;

        }

        public O LoadedItem
        {

            get
            {

                return _LoadedItem;

            }

        }

    }
}
