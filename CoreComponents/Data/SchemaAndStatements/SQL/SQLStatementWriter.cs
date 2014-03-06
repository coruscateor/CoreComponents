using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public abstract class SQLStatementWriter : ITerminateStatement
    {

        protected bool myTerminate = false;

        public SQLStatementWriter()
        {
        }

        public bool Terminate
        {

            get
            {

                return myTerminate;

            }
            set
            {

                myTerminate = value;

            }

        }

        public void CheckForTermination(StringBuilder TheSB)
        {

            if (myTerminate)
                TheSB.Append(';');

        }

    }

}
