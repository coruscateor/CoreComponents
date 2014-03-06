using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class LoadEventArgs<TSender, TSource> : SenderEventArgs<TSender>
    {

        TSource mySource;

        public LoadEventArgs(TSender sender, TSource theSource)
            : base(sender)
        {

            mySource = theSource;

        }

        public TSource Source
        {

            get
            {

                return mySource;

            }

        }


    }
}
