using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface IDbCondition
    {

        object LeftValue
        {

            get;
            set;

        }

        object RightValue
        {

            get;
            set;

        }

    }

}
