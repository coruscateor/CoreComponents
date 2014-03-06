using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.MessageWriting
{
    public class WritingExecption : Exception
    {

        public WritingExecption(string message, Exception innerException) : base(message, innerException)
        {

        }


    }
}
