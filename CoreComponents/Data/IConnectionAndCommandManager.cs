using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace CoreComponents.Data
{

    public interface IConnectionAndCommandManager : IExecutor
    {

        ConnectionType ConnectionType
        {

            get;
            set;

        }

        IsolationLevel IsolationLevel
        {

            get;
            set;

        }

        TransactionAction TransactionAction
        {

            get;
            set;

        }

    }

}
