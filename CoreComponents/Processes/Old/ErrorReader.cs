using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CoreComponents.Processes
{

    public class ErrorReader : StandardReader
    {

        public ErrorReader()
        {
        }

        public ErrorReader(Process TheProcess)
            : base(TheProcess)
        {
        }

        protected override void SetOutputStream()
        {

            if (myProcess != null)
            {

                myStreamReader = myProcess.StandardError;

            }
            else
            {

                if (myStreamReader != null)
                    myStreamReader = null;

            }

        }

    }
}
