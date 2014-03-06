using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreComponents.Processes
{

    public abstract class BaseProcessOutputExtractior
    {

        protected Process myProcess;

        protected StreamExtractor myOutputStreamExtractor = new StreamExtractor();

        protected StreamExtractor myErrorStreamExtractor = new StreamExtractor();
        
        public BaseProcessOutputExtractior()
        {
        }

        public void SetProcess(Process TheProcess)
        {

            myProcess = TheProcess;

            SetExtractors();

        }

        protected void SetExtractors()
        {

            myOutputStreamExtractor.StreamReader = myProcess.StandardOutput;

            myErrorStreamExtractor.StreamReader = myProcess.StandardError;

        }

        protected void SetExtractorsNull()
        {

            myOutputStreamExtractor.SetReaderNull();

            myErrorStreamExtractor.SetReaderNull();

        }

        public bool OutputHasEntries
        {

            get
            {

                return myOutputStreamExtractor.HasEntries;

            }

        }

        public bool ErrorHasEntries
        {

            get
            {

                return myErrorStreamExtractor.HasEntries;

            }

        }

        public void Close()
        {

            myOutputStreamExtractor.Close();

            myErrorStreamExtractor.Close();

        }

        public void Dispose()
        {

            myOutputStreamExtractor.Dispose();

            myErrorStreamExtractor.Dispose();

        }

    }

}
