using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application
{
    public class LoadingEventArgs<T, P> : LoadEventArgs<T>
    {

        P _Percent;

        public LoadingEventArgs(T sender, string FileSource, P Percentege) : base(sender, FileSource)
        {

            _Percent = Percentege;

        }

        public P Progress
        {

            get
            {

                return _Percent;

            }

        }

    }
}
