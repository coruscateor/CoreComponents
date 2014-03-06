using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface IDbConstraint
    {

        string Name
        {

            get;
            set;

        }

        bool HasName
        {

            get;

        }

        void ClearName();

        //ConstraintType ConstraintType
        //{

        //    get;

        //}

    }

}
