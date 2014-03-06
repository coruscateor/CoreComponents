using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.FileSystem.Writing;
using CoreComponents.Application.Messaging;
using CoreComponents.Items.MessageWriting;

namespace CoreComponents.Items.MessageWriting
{
    public class IOMessageWriter : IMessageWriter
    {


        string myPath;

        bool myIsWriting;

        bool myActivated;
		
		QuickFileWriter QFW;

        public IOMessageWriter()
        {

            QFW = new QuickFileWriter();

        }

        public string Path
        {

            get
            {

                return myPath;

            }

            set
            {

                if (!myIsWriting)
                {

                    myPath = value;

                    if(!myActivated)
                        myActivated = true;

                }

            }

        }

        protected void OnWriteError(Exception e)
        {

            if(WriteError != null)
            	WriteError(this, e);
			
			if(myActivated)
            	myActivated = false;

        }


        #region IMessageWriter Members

        public event GimmieEvent<IMessageWriter, Exception>.Event WriteError;

        public bool IsWriting
        {

            get
            {

                return myIsWriting;

            }

        }

        public void Write(IEnumerable<IMessageLine> Messages)
        {

            if (myActivated) {

                if (!myIsWriting)
                {

                    myIsWriting = true;
					
					QFW.Write(myPath, Messages, false, OnWriteError);
					
                    myIsWriting = false;

                }
            }
        }

        #endregion


        #region IActivateable Members

        public void Activate()
        {
            myActivated = true;
        }

        #endregion

        #region IDeactivateable Members

        public void Deactivate()
        {
            myActivated = false;
        }

        #endregion

        #region IIsActive Members

        public bool IsActive
        {
            get
            {
                return myActivated;
            }
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
