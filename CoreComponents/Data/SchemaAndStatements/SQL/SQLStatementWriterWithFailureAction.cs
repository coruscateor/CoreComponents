using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public abstract class SQLStatementWriterWithFailureAction : SQLStatementWriter
    {

        public SQLStatementWriterWithFailureAction()
        {
        }

        protected DbTable AscertainTable(IEnumerable<DbColumn> TheColumns)
        {

            DbTable TheTable = null;

            foreach (DbColumn Item in TheColumns)
            {

                if (!Item.HasName)
                    throw new Exception("Column with no name found.");

                if (!Item.HasTable)
                    throw new Exception("Column " + Item.Name + " is not part of a table.");

                if (TheTable == null)
                {

                    TheTable = Item.Table;

                }

                if (Item.Table != TheTable)
                    throw new Exception("Only columns that are from the same table may be added.");

            }

            if (TheTable == null)
                throw new Exception("No columns have been provided.");

            return TheTable;

        }

        protected string FailureAction(InsertionFailureAction TheInsertionFailureAction)
        {

            switch (TheInsertionFailureAction)
            {

                case InsertionFailureAction.ABORT:
                    return CommonSQL.OR_ABORT_;
                case InsertionFailureAction.FAIL:
                    return CommonSQL.OR_FAIL_;
                case InsertionFailureAction.IGNORE:
                    return CommonSQL.OR_IGNORE_;
                case InsertionFailureAction.REPLACE:
                    return CommonSQL.OR_REPLACE_;
                case InsertionFailureAction.ROLLBACK:
                    return CommonSQL.OR_ROLLBACK_;
                default:
                    return string.Empty;
            }

        }

    }

    public enum InsertionFailureAction
    {

        DEFAULT,
        ROLLBACK,
        ABORT,
        REPLACE,
        FAIL,
        IGNORE

    }

}
