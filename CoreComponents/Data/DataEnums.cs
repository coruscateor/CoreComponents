using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Data
{

    public enum ConnectionType
    {

        Transactional,
        Discrete,
        QuickDiscrete

    }

    public enum TransactionAction
    {

        Commit,
        Rollback

    }

}
