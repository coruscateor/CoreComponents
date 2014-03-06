using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class SQLSelectStatementWriter : SQLStatementWriter
    {

        public SQLSelectStatementWriter()
        {
        }

        public string Select(DbTable TheTable, IEnumerable<IDbCondition> TheConditions = null)
        {

            if (TheTable.Validate())
            {

                StringBuilder SB = new StringBuilder();

                SB.Append(CommonSQL.SELECT_);

                int ColumnsCount = TheTable.Columns.Count;

                foreach (DbColumn Item in TheTable.Columns)
                {

                    ColumnsCount--;

                    SB.Append('"');

                    SB.Append(Item.Name);

                    SB.Append('"');

                    if (ColumnsCount > 0)
                    {
 
                        SB.Append(", ");

                    }

                }

                SB.Append(CommonSQL._FROM_);

                SB.Append('"');

                SB.Append(TheTable.Name);

                SB.Append('"');

                if (TheConditions != null)
                    SQLStatementFragmentWriter.AppendConditions(SB, TheConditions);

                CheckForTermination(SB);

                return SB.ToString();
   
            }

            throw new Exception("Invalid Table");

        }

        public string Select(IEnumerable<DbColumn> TheColumns = null, IEnumerable<ColumnAlias> TheAliasedColumns = null, IEnumerable<IDbCondition> TheConditions = null, SQLSingeJoin TheJoin = null)
        {

            int ColumnCount = 0;

            if (TheColumns != null)
            {

                if (TheColumns is Array)
                {

                    ColumnCount = (TheColumns as Array).Length;

                }
                else if (TheColumns is ICollection<DbColumn>)
                {

                    ColumnCount = (TheColumns as ICollection<DbColumn>).Count;

                }
                else
                {

                    int i = 0;

                    foreach (DbColumn Item in TheColumns)
                    {

                        i++;

                    }

                    ColumnCount = i;

                }

            }

            if (TheAliasedColumns != null)
            {

                if (TheAliasedColumns is Array)
                {

                    ColumnCount = (TheAliasedColumns as Array).Length;

                }
                else if (TheAliasedColumns is ICollection<DbColumn>)
                {

                    ColumnCount = (TheAliasedColumns as ICollection<DbColumn>).Count;

                }
                else
                {

                    int i = 0;

                    foreach (DbColumn Item in TheColumns)
                    {

                        i++;

                    }

                    ColumnCount += i;

                }

            }

            if (ColumnCount > 0)
            {

                StringBuilder SB = new StringBuilder();

                SB.Append(CommonSQL.SELECT_);

                List<DbTable> Tables = new List<DbTable>();

                if (TheColumns != null)
                {

                    foreach (DbColumn Item in TheColumns)
                    {

                        if (Item.HasName)
                        {

                            if (Item.HasTable)
                            {

                                if(!Tables.Contains(Item.Table))
                                {

                                    SB.Append('"');

                                    Tables.Add(Item.Table);

                                    SB.Append('"');

                                }

                                SB.Append(Item.Table.Name);

                                SB.Append('.');

                                SB.Append(Item.Name);

                                if (ColumnCount > 0)
                                    SB.Append(", ");
                                else
                                    SB.Append(' ');

                                ColumnCount--;

                            }
                            else
                            {

                                throw new Exception("Column with no table provided");

                            }

                        }
                        else
                        {

                            throw new Exception("Column with no name provided");

                        }

                    }

                }

                if (ColumnCount > 0 && TheAliasedColumns != null)
                {

                    foreach (ColumnAlias Item in TheAliasedColumns)
                    {

                        if (Item.HasColumn)
                        {

                            if (Item.HasAlias)
                            {

                                DbColumn TheColumn = Item.Column;

                                if (TheColumn.HasName)
                                {

                                    if (TheColumn.HasTable)
                                    {

                                        if (!Tables.Contains(TheColumn.Table))
                                        {

                                            Tables.Add(TheColumn.Table);

                                        }

                                        SB.Append(TheColumn.Table.Name);

                                        SB.Append('.');

                                        SB.Append(TheColumn.Name);

                                        SB.Append(CommonSQL._AS_);

                                        SB.Append(Item.Alias);

                                        if (ColumnCount > 0)
                                            SB.Append(", ");
                                        else
                                            SB.Append(' ');

                                        ColumnCount--;

                                    }
                                    else
                                    {

                                        throw new Exception("Column with no table provided");

                                    }

                                }
                                else
                                {

                                    throw new Exception("Column with no name provided");

                                }

                            }
                            else
                            {

                                throw new Exception("No alias provided");

                            }

                        }
                        else 
                        {

                            throw new Exception("No column provided for alias");

                        }

                    }

                }

                SB.Append(CommonSQL._FROM_);

                if (TheJoin != null)
                {

                    if (Tables.Count != 2)
                    {

                        if (TheJoin.HasLeftAndRightTables)
                        {

                            if (TheJoin.LeftAndRightColumnsAreNotEqual)
                            {

                                if (Tables.Contains(TheJoin.LeftTable) && Tables.Contains(TheJoin.RightTable))
                                {

                                    SB.Append(TheJoin.LeftTable.Name);

                                    AppendJoinOperation(SB, TheJoin.JoinOperation);

                                    SB.Append(TheJoin.RightTable.Name);

                                    if (TheJoin.HasOnCondition)
                                    {

                                        SB.Append(CommonSQL._ON_);

                                        TheJoin.OnCondition.AppendTo(SB);

                                    }
                                    else if (TheJoin.HasUsingColumns)
                                    {

                                        SB.Append(CommonSQL._USING_);

                                        SB.Append("( ");

                                        List<DbColumn> UsingColumns = new List<DbColumn>(TheJoin.UsingColumns);

                                        for (int i = UsingColumns.Count; i > 0; i--)
                                        {

                                            DbColumn UsingColumn = UsingColumns[i];

                                            if (UsingColumn.HasTable)
                                            {

                                                SB.Append(UsingColumn.Table.Name);

                                                if (UsingColumn.HasName)
                                                {

                                                    SB.Append('.');

                                                    SB.Append(UsingColumn.Name);

                                                }
                                                else
                                                {

                                                    throw new Exception("Using column with no name detected");

                                                }

                                            }
                                            else
                                            {

                                                throw new Exception("Using column with no table detected");

                                            }

                                        }

                                        SB.Append(" )");

                                    }

                                }
                                else
                                {

                                    throw new Exception("The tables dicerned from the provided columns do not match the tables in the provided join.");

                                }

                            }
                            else
                            {

                                throw new Exception("The left and right columns of the provided join are equal.");

                            }

                        }
                        else
                        {

                            throw new Exception("Not enough tables provided to join");

                        }

                    }
                    else
                    {

                        throw new Exception("Not enough tables provided to join");

                    }

                }
                else if (Tables.Count == 1)
                {

                    SB.Append(Tables[0].Name);

                }
                else
                {

                    for (int i = 0; i < Tables.Count; i++)
                    {

                        SB.Append(Tables[i].Name);

                        if (i < Tables.Count)
                            SB.Append(CommonSQL._NATURAL_);

                    }

                }

                if (TheConditions != null)
                {

                    SB.Append(' ');

                    SQLStatementFragmentWriter.AppendConditions(SB, TheConditions);

                }

                CheckForTermination(SB);

                return SB.ToString();

            }

            throw new Exception("No columns provided");

        }

        protected void AppendJoinOperation(StringBuilder TheSB, SQLJoinOperation TheJoinOperation)
        {

            switch (TheJoinOperation)
            {

                case SQLJoinOperation.Cross:

                    TheSB.Append(CommonSQL._CROSS_);

                    break;
                case SQLJoinOperation.Inner:

                    TheSB.Append(CommonSQL._INNER_);

                    break;
                case SQLJoinOperation.Left:

                    TheSB.Append(CommonSQL._LEFT_);

                    break;
                case SQLJoinOperation.LeftOuter:

                    TheSB.Append(CommonSQL._LEFT_OUTER_);

                    break;
                case SQLJoinOperation.Natural:

                    TheSB.Append(CommonSQL._NATURAL_);

                    break;

            }

            TheSB.Append(CommonSQL.JOIN_);

        }

    }

    public enum SQLJoinOperation
    {

        Default,
        Natural,
        Left,
        LeftOuter,
        Inner,
        Cross

    }

}
