using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Text
{
    public class TextOutputCache : RestrictedQueue<string>
    {

        protected StringBuilder mySB;

        public TextOutputCache()
        {

            Initalise();

        }

        public TextOutputCache(int MaxSize) : base(MaxSize)
        {

            Initalise();

        }

        void Initalise()
        {

            mySB = new StringBuilder();

        }

        public string Feed(IHasText item)
        {

            return myTryPush(item.Text);

        }

        public string Feed(IHasMessage item)
        {

            return myTryPush(item.Contents);

        }

        public string GetOutput()
        {

            //TextEntity.Clear(mySB);

            mySB.Clear();

            foreach (string item in myList)
            {

                mySB.AppendLine(item);

            }

            //Flush();

            return mySB.ToString();

        }

    }
}
