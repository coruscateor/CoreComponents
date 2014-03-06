using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class SourceEventArgs<TSender, TSource> : SenderEventArgs<TSender>
    {

        protected TSource mySource;

        public SourceEventArgs(TSender Sender, TSource Source) : base(Sender)
        {

            mySource = Source;

        }

        public virtual TSource Source
        {

            get
            {

                return mySource;

            }

        }

    }
}
