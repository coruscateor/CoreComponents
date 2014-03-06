using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class SQLExplainStatementWriter
    {

        public SQLExplainStatementWriter()
        {
        }

        public string Expalain(string TheStatement, bool QueryPlan = false)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(CommonSQL.EXPLAIN_);

            if (QueryPlan)
                SB.Append(CommonSQL.QUERY_PLAN_);

            SB.Append(TheStatement);

            return SB.ToString();

        }

    }

}
