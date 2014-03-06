using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Data.SQL
{


    public abstract class SQLCommand : SQLExpression //: TextEntity
    {
		
		/*protected List<SQLAlias> AliasList = new List<SQLAlias>();*/

		/*
        #region ITextEntity Members

        //public abstract void AppendTo(StringBuilder SB);

        #endregion

        protected abstract void Append(StringBuilder SB);

        public override string ToString()
        {

            StringBuilder SB = new StringBuilder();

            Append(SB);

            return SB.ToString();

        }

        public virtual void AppendTo(StringBuilder SB)
        {

            Append(SB);

        }
        */
    }
}
