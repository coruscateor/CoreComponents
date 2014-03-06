using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;
using CoreComponents.Application.Messaging;
using CoreComponents.Items.MessageWriting;

namespace CoreComponents.Application.Sets
{
    public class VisualCachingManager : ICachingSystem
    {

        protected RestrictedQueue<IMessageLine> myDisplayMessages;

        protected RestrictedQueue<IMessageLine> myMessageCache;

        bool myIsActive;

        IMessageWriter myWriter;

        //bool mySharedMode;

        int myDisplayLimit;

        public VisualCachingManager()
        {

            myDisplayLimit = 10;

            myDisplayMessages = new RestrictedQueue<IMessageLine>(myDisplayLimit);

            myMessageCache = new RestrictedQueue<IMessageLine>(100);

            myWriter = new IOMessageWriter();

            Activate();

        }


        public VisualCachingManager(IMessageWriter Writer)
        {

            myDisplayLimit = 10;

            myDisplayMessages = new RestrictedQueue<IMessageLine>(myDisplayLimit);

            myMessageCache = new RestrictedQueue<IMessageLine>(100);

            myWriter = Writer;

            Activate();

        }

        public VisualCachingManager(IMessageWriter Writer, int DisplayLimit, int LogLimit)
        {

            myDisplayLimit = DisplayLimit;

            myDisplayMessages = new RestrictedQueue<IMessageLine>(DisplayLimit);

            myMessageCache = new RestrictedQueue<IMessageLine>(LogLimit);

            myWriter = Writer;

            Activate();

        }

        void CoupleMessageQueues()
        {

            myMessageCache.Fed += MessageCache_Fed;

            myMessageCache.Filled += myMessageCache_Filled;

        }

        void DeCoupleMessageQueues()
        {

            myMessageCache.Fed -= MessageCache_Fed;

            myMessageCache.Filled -= myMessageCache_Filled;

        }

        void OnlyMessageCache()
        {

            myMessageCache.Filled += myMessageCache_Filled;

        }

        void OnlyRemoveMessageCache()
        {

            myMessageCache.Filled -= myMessageCache_Filled;

        }

        void MessageCache_Fed(FedEventArgs<IMessageLine, IReadOnlyCache<IMessageLine>> e)
        {

            myDisplayMessages.Feed(e.FedItem);

        }

        void myMessageCache_Filled(SenderEventArgs<IReadOnlyCache<IMessageLine>> e)
        {

            myMessageCache.Flush();

        }

        void myMessageCache_Emptying(SenderEventArgs<IReadOnlyCache<IMessageLine>> e)
        {

            WriteLog();
            
        }


        //public bool SharedMode
        //{

        //    get
        //    {

        //        return mySharedMode;

        //    }

        //    set
        //    {


        //        if (value != mySharedMode)
        //        {

        //            if (mySharedMode)
        //            {

        //                OnlyRemoveMessageCache();

        //                CoupleMessageQueues();

        //                myDisplayMessages = myMessageCache;


        //            } else
        //            {

        //                DeCoupleMessageQueues();

        //                OnlyMessageCache();

        //                myDisplayMessages = new RestrictedQueue<CacheMessage>(10);

        //            }

        //            mySharedMode = value;

        //        }
                

        //    }

        //}

        //public IEnumerator<IMessageLine> GetEnumerator()
        //{

        //    return myDisplayMessages.GetEnumerator();

        //}

        public RestrictedQueue<IMessageLine> Messages
        {

            get
            {

                return myMessageCache;

            }

        }

        public IMessageWriter Writer
        {

            get
            {

                return myWriter;

            }
            set
            {

                myWriter = value;

            }

        }

        public virtual void WriteLog()
        {

            if(myMessageCache.Count > 0)
                myWriter.Write(myMessageCache);

        }

    
        #region IActivateable Members

        public void Activate()
        {

            myIsActive = true;

            myMessageCache.Emptying += myMessageCache_Emptying;

            CoupleMessageQueues();

        }

        #endregion

        #region IIsActive Members

        public bool IsActive
        {
            get
            {

                return myIsActive;

            }
        }

        #endregion

        #region IDeactivateable Members

        public void Deactivate()
        {

            myIsActive = false;

            //WriteLog();

            myMessageCache.Flush();

            myMessageCache.Emptying -= myMessageCache_Emptying;

            DeCoupleMessageQueues();

        }

        #endregion

        #region IEnumerable<IMessageLine> Members

        public IEnumerator<IMessageLine> GetEnumerator()
        {
            return myDisplayMessages.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return myDisplayMessages.GetEnumerator();
        }

        #endregion

        #region IDeactivateable Members


        public event Gimmie<SenderEventArgs<IDeactivateable>>.GimmieSomethin Deactivated;

        #endregion

        #region IActivateable Members


        public event Gimmie<SenderEventArgs<IActivateable>>.GimmieSomethin Activated;

        #endregion
    }
}
