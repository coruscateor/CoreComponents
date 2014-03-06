using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface IDbCondition
    {

        object Left
        {

            get;
            set;

        }

        bool HasLeftObject
        {

            get;

        }

        bool LeftObjectIsNull
        {

            get;

        }

        bool LeftObjectIsDbColumn
        {

            get;

        }

        object Right
        {

            get;
            set;

        }

        bool HasRightObject
        {

            get;

        }

        bool RightObjectIsNull
        {

            get;

        }

        bool RightObjectIsDbColumn
        {

            get;

        }

        void AppendTo(StringBuilder SB);

        string Write();

    }

}
