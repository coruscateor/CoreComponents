using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class SourceAndMessageEventArgs<TSender, TSource> : SourceEventArgs<TSender, TSource>, IHasMessage
    {

        protected string myContents;

        public SourceAndMessageEventArgs(TSender Sender, TSource Source, string theContents)
            : base(Sender, Source)
        {

            myContents = theContents;

        }

        public string Contents
        {

            get
            {

                return myContents;

            }

        }

    }
}
