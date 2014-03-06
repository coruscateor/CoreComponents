using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Data
{
    public class CommandResultsEventArgs<TSender> : SenderEventArgs<TSender>
    {

        protected ReadOnlyList<CommandResult> myCommandResults;

        public CommandResultsEventArgs(TSender TheSender, IEnumerable<CommandResult> TheCommandResults) : base(TheSender)
        {

            myCommandResults = new ReadOnlyList<CommandResult>(TheCommandResults.ToArray());

        }

        public ReadOnlyList<CommandResult> CommandResults 
        {

            get 
            {

                return myCommandResults;

            }

        }

    }
}
