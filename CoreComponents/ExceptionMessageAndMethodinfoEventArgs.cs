using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CoreComponents
{
    public class ExceptionMessageAndMethodinfoEventArgs<TSender, TException> : ExceptionAndMessageEventArgs<TSender, TException> where TException : _Exception
    {

        MethodInfo myMethodInfo;

        public ExceptionMessageAndMethodinfoEventArgs(TSender Sender, TException TheException, string TheMessage, MethodInfo TheMethodInfo)
            : base(Sender, TheException, TheMessage)
        {

            myMethodInfo = TheMethodInfo;

        }

        public MethodInfo MethodInfo
        {

            get 
            {

                return myMethodInfo;

            }

        }


    }
}
