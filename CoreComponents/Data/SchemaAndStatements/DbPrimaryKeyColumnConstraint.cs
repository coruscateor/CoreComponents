using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbPrimaryKeyColumnConstraint //: DbConstraint
    {

        protected AscendingDecending myAscendingDecending = AscendingDecending.Default;

        protected bool myAutoIncrement;

        public DbPrimaryKeyColumnConstraint()
        {
        }

        //public override ConstraintType ConstraintType
        //{

        //    get
        //    {
        //        return ConstraintType.Column;
            
        //    }

        //}

        public bool AutoIncrement
        {

            get
            {

                return myAutoIncrement;

            }
            set
            {

                myAutoIncrement = value;

            }

        }

        public AscendingDecending AscendingDecending
        {

            get
            {

                return myAscendingDecending;

            }
            set
            {

                myAscendingDecending = value;

            }

        }

    }

}
