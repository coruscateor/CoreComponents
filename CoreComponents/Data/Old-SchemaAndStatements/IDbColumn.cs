using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Characters;

namespace CoreComponents.Data.SchemaAndStatements
{
    public interface IDbColumn : IHasName, ITextEntity
    {


        DbType Type
        {

            get;
            set;

        }

        int PrecisionOrLength
        {

            get;
            set;

        }

        bool NotNull
        {

            get;
            set;


        }

        bool HasDefault
        {

            get;
            set;

        }

        string DefaultValue
        {

            get;
            set;

        }

        string Description
        {

            get;
            set;

        }
        /*
        IDbTable<IDbColumn> Table
        {

            get;
            set;

        }
         * */


    }
}
