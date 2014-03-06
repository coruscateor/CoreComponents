using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class UpdateStatementWriter : SQLStatementWriterWithFailureAction
    {

        public UpdateStatementWriter()
        {
        }

        public string Update(IEnumerable<DbColumn> TheColumns, InsertionFailureAction TheInsertionFailureAction = InsertionFailureAction.DEFAULT, IEnumerable<IDbCondition> TheConditions = null)
        {

            DbTable TheTable = AscertainTable(TheColumns);

            DbColumn[] Columns = TheColumns.ToArray();

            StringBuilder SB = new StringBuilder();

            SB.Append(CommonSQL.INSERT_);

            if (TheInsertionFailureAction != InsertionFailureAction.DEFAULT)
            {

                SB.Append(FailureAction(TheInsertionFailureAction));

            }

            SB.Append(CommonSQL.INTO_);

            SB.Append(TheTable.Name);

            SB.Append(' ');

            SB.Append(CommonSQL.SET_);

            for (int i = 0; i < Columns.Length; i++)
            {

                SB.Append('"');

                SB.Append(TheTable.Columns[i].Name);

                SB.Append('"');

                SB.Append("= ?");

                if (i < Columns.Length - 1)
                {

                    SB.Append(", ");

                }

            }

            if (TheConditions != null)
                SQLStatementFragmentWriter.AppendConditions(SB, TheConditions);

            CheckForTermination(SB);

            return SB.ToString();

        }

    }

}
