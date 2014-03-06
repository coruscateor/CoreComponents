using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class InsertStatementWriter : SQLStatementWriterWithFailureAction
    {

        public InsertStatementWriter()
        {
        }

        public string InsertInto(DbTable TheTable, bool TheDefaultValues = false, InsertionFailureAction TheInsertionFailureAction = InsertionFailureAction.DEFAULT)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(CommonSQL.INSERT_);

            if (TheInsertionFailureAction != InsertionFailureAction.DEFAULT)
            {

                SB.Append(FailureAction(TheInsertionFailureAction));

            }

            SB.Append(CommonSQL.INTO_);

            SB.Append(TheTable.Name);

            if (TheDefaultValues)
            {

                SB.Append(CommonSQL._DEFAULT_VALUES);

            }
            else
            {

                SB.Append(" (");

                for (int i = 0; i < TheTable.Columns.Count; i++)
                {

                    SB.Append(TheTable.Columns[i].Name);

                    if (i < TheTable.Columns.Count - 1)
                    {

                        SB.Append(", ");

                    }

                }

                SB.Append(')');

                SB.Append(CommonSQL._VALUES_);

                for (int i = 0; i < TheTable.Columns.Count; i++)
                {

                    SB.Append(CommonSQL.QuestionMark);

                    if (i < TheTable.Columns.Count - 1)
                    {

                        SB.Append(", ");

                    }

                }

            }

            CheckForTermination(SB);

            return SB.ToString();

        }

        public string InsertInto(IEnumerable<DbColumn> TheDbColumns, InsertionFailureAction TheInsetionFailureAction = InsertionFailureAction.DEFAULT)
        {

            DbTable TheTable = AscertainTable(TheDbColumns);

            DbColumn[] Columns = TheDbColumns.ToArray();

            StringBuilder SB = new StringBuilder();

            SB.Append(CommonSQL.INSERT_);

            if (TheInsetionFailureAction != InsertionFailureAction.DEFAULT)
            {

                SB.Append(FailureAction(TheInsetionFailureAction));

            }

            SB.Append(CommonSQL.INTO_);

            SB.Append(TheTable.Name);

            SB.Append(" (");

            for (int i = 0; i < Columns.Length; i++)
            {

                SB.Append(TheTable.Columns[i].Name);

                if (i < Columns.Length - 1)
                {

                    SB.Append(", ");

                }

            }

            SB.Append(')');

            SB.Append(CommonSQL._VALUES_);

            for (int i = 0; i < Columns.Length; i++)
            {

                SB.Append(CommonSQL.QuestionMark);

                if (i < Columns.Length - 1)
                {

                    SB.Append(", ");

                }

            }

            CheckForTermination(SB);

            return SB.ToString();

        }

    }

}
