using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Text
{

    public sealed class TextOutputCache : RestrictedQueue<string>
    {

        readonly StringBuilder mySB;

        public TextOutputCache()
        {

            mySB = new StringBuilder();

        }

        public TextOutputCache(int MaxSize)
            : base(MaxSize)
        {

            mySB = new StringBuilder();

        }

        public string Enqueue(object item)
        {

            return Enqueue(item.ToString());

        }

        public string GetOutput()
        {

            mySB.Clear();

            foreach(string item in myQueue)
            {

                mySB.AppendLine(item);

            }

            return mySB.ToString();

        }

        public override string ToString()
        {

            return GetOutput();

        }

    }

}
