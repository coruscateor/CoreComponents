using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Text
{
    public class TextMessageOutputCache : RestrictedQueue<TextMessage>
    {

        protected StringBuilder mySB;

        public TextMessageOutputCache()
        {

            Initalise();

        }

        public TextMessageOutputCache(int MaxSize) : base(MaxSize)
        {

            Initalise();

        }
        
        /*
        public TextMessageOutputCache(IEnumerable items) : base(items)
        {

            Initalise();

        }
		*/
		
        void Initalise()
        {

            mySB = new StringBuilder();

        }

        public TextMessage Feed(IHasText item)
        {

            return myTryPush(new TextMessage(item.Text));

        }

        public TextMessage Feed(IHasMessage item)
        {

            return myTryPush(new TextMessage(item.Contents));

        }
        
       	public TextMessage FeedAndReStamp(TextMessage item)
        {

            return myTryPush(new TextMessage(item));

        }

        public string RetrieveMessageContent()
        {

            TextEntity.Clear(mySB);

            foreach (TextMessage item in myList)
            {

                mySB.AppendLine(item.Contents);

            }

            return mySB.ToString();

        }
        
        
        public string RetrieveMessageContentWithStamp()
        {

            TextEntity.Clear(mySB);

            foreach (TextMessage item in myList)
            {

                mySB.AppendLine(item.Contents);

            }

            return mySB.ToString();

        }
        
        /*
        public virtual object Clone()
        {

            return new RestrictedQueue<T>(myList);

        }
        */

    }
}
