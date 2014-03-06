using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{

    public class CommandResult
    {
        protected CommandProperties myCommand;

        protected object myResult;

        protected IRunCommands myIRunCommands;

        public CommandResult(CommandProperties TheCommand, object TheResult, IRunCommands TheIRunCommands = null) 
        {

            myCommand = TheCommand;

            myResult = TheResult;

            myIRunCommands = TheIRunCommands;

        }

        public CommandProperties Command 
        {

            get 
            {

                return myCommand;

            }

        }

        public object Result 
        {

            get 
            {

                return myResult;

            }

        }

        public bool CommandExecuterIsKnown 
        {

            get 
            {

                return myIRunCommands != null;

            }

        }

    }

    public interface IRunCommands
    {

        void Execute(CommandProperties TheCommadProperties);

    }

}
