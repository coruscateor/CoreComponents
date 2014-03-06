using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbTypeInfoAttribute<TTypeAffinity> : Attribute //where TTypeAffinity : struct
    {

        protected TTypeAffinity myTTypeAffinity;

        protected bool myHasSizeArgument;

        public DbTypeInfoAttribute(TTypeAffinity TheTypeAffinity, bool HasSizeArgument = false)
        {

            myTTypeAffinity = TheTypeAffinity;

            myHasSizeArgument = HasSizeArgument;

        }

        public TTypeAffinity TypeAffinity
        {

            get
            {

                return myTTypeAffinity;

            }

        }

        public bool HasSizeArgument
        {

            get
            {

                return myHasSizeArgument;

            }

        }

    }

}
