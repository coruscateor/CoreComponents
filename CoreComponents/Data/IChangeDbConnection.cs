using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public interface IChangeDbConnection
    {

        event Action<DbConnectionEventArgs<IChangeDbConnection>> DbConnectionChanged;

    }
}
