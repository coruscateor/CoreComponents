using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CoreComponents.Processes
{

    public class OutputReader : StandardReader
    {

        public OutputReader()
        {
        }

        public OutputReader(Process TheProcess) : base(TheProcess)
        {
        }

        protected override void SetOutputStream()
        {

            if (myProcess != null)
            {

                myStreamReader = myProcess.StandardOutput;

            }
            else
            {

                if (myStreamReader != null)
                    myStreamReader = null;

            }

        }

    }

}
