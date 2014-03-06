using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class NameChangeEventArgs : SenderEventArgs
    {

        protected string myName;

        public NameChangeEventArgs(object sender, string TheName)
            : base(sender)
        {

            myName = TheName;

        }

        public string Name
        {

            get
            {

                return myName;

            }

        }

    }

    public class NameChangeEventArgs<TSender> : SenderEventArgs<TSender> where TSender : IReadonlyHaveName
    {

        public NameChangeEventArgs(TSender sender)
            : base(sender)
        {

        }

        public string Name
        {

            get
            {

                return Sender.Name;

            }

        }

    }

}
