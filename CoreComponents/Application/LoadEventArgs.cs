using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application
{
    public class LoadEventArgs<T> : SenderEventArgs<T>
    {

        string _Source;

        public LoadEventArgs(T sender, string FileSource) : base(sender)
        {

            _Source = FileSource;

        }

        public string Source
        {

            get
            {

                return _Source;

            }

        }


    }

}
