using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public interface IHasAConnectionString
    {

        string ConnectionString
        {

            get;
            set;

        }

    }

    public interface IHasAReadonlyConnectionString
    {

        string ConnectionString
        {

            get;

        }

    }
}
