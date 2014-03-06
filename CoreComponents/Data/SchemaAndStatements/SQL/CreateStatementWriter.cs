using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public abstract class CreateStatementWriter : SQLStatementWriter
    {

        protected ISystemDatabaseTypes mySystemDatabaseTypes;

        protected const string ConstraintAlreadyPresent = " column-constraint already present in constarint set.";

        public CreateStatementWriter(ISystemDatabaseTypes TheSystemDatabaseTypes)
        {

            mySystemDatabaseTypes = TheSystemDatabaseTypes;

        }

        public ISystemDatabaseTypes SystemDatabaseTypes
        {

            get
            {

                return mySystemDatabaseTypes;

            }

        }

        public virtual string GetCreateTableStatement(DbTable TheTable, bool IfNotExists = false)
        {

            if (TheTable.Validate())
            {

                StringBuilder SB = new StringBuilder();

                if (TheTable.IsTemporary)
                {

                    SB.Append(CommonSQL.CREATE_);

                    SB.Append(CommonSQL.TEMP_);

                    SB.Append(CommonSQL.TABLE_);

                }
                else
                {

                    SB.Append(CommonSQL.CREATE_TABLE_);

                }

                if (IfNotExists)
                    SB.Append(CommonSQL.IF_NOT_EXISTS_);

                SB.Append('"');

                if (TheTable.HasDatabase)
                {

                    SB.Append(TheTable.Database.Name);

                    SB.Append('.');

                }

                SB.Append(TheTable.Name);

                SB.Append("\" (");

                WriteColumnsAndConatraints(TheTable, SB);

                SB.Append(')');

                //Action<DbColumn> WriteColumn = (TheColumn) =>
                //{
                    
                //    SB.Append(TheColumn.Name);

                //    SB.Append(' ');

                //    SB.Append(mySystemDatabaseTypes.GetDatabaseType(TheColumn)); //To be translated...
                
                //};

                //bool WritePrimaryKeysAsTableConstraints = false;

                //if (TheTable.HasPrimaryKey)
                //{

                //    if (TheTable.PrimaryKey.IsComposite)
                //    {

                //        WritePrimaryKeysAsTableConstraints = true;

                //    }
                //    else
                //    {

                //        Action<DbColumn> WriteNormalColumn = WriteColumn;

                //        WriteColumn = (TheColumn) =>
                //        {

                //            if (TheTable.PrimaryKey[0] == TheColumn)
                //            {

                //                WriteNormalColumn(TheColumn);

                //                SB.Append(' ');

                //                SB.Append(CommonSQL.PRIMARY_KEY_);

                //                if (TheTable.PrimaryKey.AutoIncrement && TheTable.PrimaryKey.IsInteger)
                //                {

                //                    SB.Append(CommonSQL.AUTOINCREMENT_);

                //                }

                //                WriteColumn = WriteNormalColumn;

                //            }

                //        };

                //    }

                //}

                //foreach (DbColumn Item in TheTable.Columns)
                //{

                //    WriteColumn(Item);

                //}

                //SB.Append(')');

                //if (WritePrimaryKeysAsTableConstraints)
                //{

                //    SB.Append(" (");

                //    for (int i = 0; i < TheTable.PrimaryKey.Count; i++)
                //    {

                //        DbColumn Item = TheTable.PrimaryKey[i];

                //        SB.Append(Item.Name);

                //        if (i < TheTable.PrimaryKey.Count)
                //        {

                //            SB.Append(", ");

                //        }

                //    }

                //    SB.Append(')');

                //}

                //if (TheTable.HasForeignKeys)
                //{

                //    if (WritePrimaryKeysAsTableConstraints)
                //        SB.Append(", ");

                //    for (int i = 0; i < TheTable.ForeignKeys.Count; i++)
                //    {

                //        DbForeignKey Item = TheTable.ForeignKeys[i];

                //        SB.Append(CommonSQL.FOREIGN_KEY_OpBr_);

                //        SB.Append(Item.ForeignKeyColumn.Name);

                //        SB.Append(" ) ");

                //        SB.Append(CommonSQL.REFERENCES_);

                //        SB.Append(SB.Append(Item.ReferencedColumn.Table.Name));

                //        SB.Append(" (");
                        
                //        SB.Append(Item.ReferencedColumn.Name);

                //        SB.Append(')');

                //        if (i < TheTable.PrimaryKey.Count)
                //        {

                //            SB.Append(", ");

                //        }

                //    }

                //}

                if (myTerminate)
                    SB.Append(';');

            }

            return "";

        }

        protected void WriteColumnsAndConatraints(DbTable TheTable, StringBuilder TheSB)
        {

            if (TheTable.Columns.Count > 0)
            {

                int ColumnsCount = TheTable.Columns.Count;

                bool HasPrimaryKeyTableConstraint = false;

                foreach (DbColumn Item in TheTable.Columns)
                {

                    ColumnsCount--;

                    TheSB.Append('"');

                    TheSB.Append(Item.Name);

                    TheSB.Append("\" ");

                    TheSB.Append(mySystemDatabaseTypes.GetDatabaseType(Item));

                    if (Item.Constraints.Count > 0)
                    {

                        DbPrimaryKeyColumnConstraint PKColumnConstraint = null;

                        DbNotNullColumnConstraint NNColumnConstraint = null;

                        DbUniqueColumnConstraint UNColumnConstraint = null;

                        DbCheckConstraint CHConstraint = null;

                        DbDefaultColumnConstraint DEColumnConstraint = null;

                        foreach (IDbConstraint ItemConstraint in Item.Constraints)
                        {

                            WriteConstraintName(ItemConstraint, TheSB);

                            Type TypeOfItemConstraint = ItemConstraint.GetType();

                            if (TypeOfItemConstraint == typeof(DbPrimaryKeyColumnConstraint))
                            {

                                if (PKColumnConstraint != null)
                                {

                                    PKColumnConstraint = ItemConstraint as DbPrimaryKeyColumnConstraint;

                                    HasPrimaryKeyTableConstraint = true;

                                    TheSB.Append(CommonSQL._PRIMARY_KEY);

                                    if (PKColumnConstraint.AscendingDecending == AscendingDecending.Ascending)
                                    {

                                        TheSB.Append(CommonSQL._ASC);

                                    }
                                    else if (PKColumnConstraint.AscendingDecending == AscendingDecending.Decending)
                                    {

                                        TheSB.Append(CommonSQL._DESC);

                                    }

                                    if (PKColumnConstraint.AutoIncrement)
                                    {

                                        TheSB.Append(CommonSQL._AUTOINCREMENT);

                                    }

                                }
                                else
                                {

                                    throw new Exception("Primary Key" + ConstraintAlreadyPresent);

                                }

                            }


                            if (TypeOfItemConstraint == typeof(DbNotNullColumnConstraint))
                            {

                                if (NNColumnConstraint != null)
                                {

                                    NNColumnConstraint = ItemConstraint as DbNotNullColumnConstraint;

                                    TheSB.Append(CommonSQL._NOT_NULL);

                                }
                                else
                                {

                                    throw new Exception("Not Null" + ConstraintAlreadyPresent);

                                }

                            }

                            if (TypeOfItemConstraint == typeof(DbUniqueColumnConstraint))
                            {
                            
                                if (UNColumnConstraint != null)
                                {

                                    UNColumnConstraint = ItemConstraint as DbUniqueColumnConstraint;

                                    TheSB.Append(CommonSQL._UNIQUE);

                                }
                                else
                                {

                                    throw new Exception("Unique" + ConstraintAlreadyPresent);

                                }

                            }

                            if (TypeOfItemConstraint == typeof(DbCheckConstraint))
                            {

                                if (CHConstraint != null)
                                {

                                    CHConstraint = ItemConstraint as DbCheckConstraint;

                                    TheSB.Append(CommonSQL._CHECK_Openbraket);

                                    CHConstraint.Condition.AppendTo(TheSB);

                                    TheSB.Append(')');

                                }
                                else
                                {

                                    throw new Exception("Check" + ConstraintAlreadyPresent);

                                }

                            }

                            if (TypeOfItemConstraint == typeof(DbDefaultColumnConstraint))
                            {

                                if (DEColumnConstraint != null)
                                {

                                    DEColumnConstraint = ItemConstraint as DbDefaultColumnConstraint;

                                    TheSB.Append(CommonSQL.DEFAULT_);

                                    if (DEColumnConstraint.IsExpression)
                                    {

                                        string DefaultValue = Convert.ToString(DEColumnConstraint.Value);

                                        if (DefaultValue.Length > 0)
                                        {

                                            bool FirstCharacterIsOpenBracket = DefaultValue[0] == '(';

                                            bool LastCharacterIsCloseBracket = DefaultValue[DefaultValue.Length] == ')';

                                            if (FirstCharacterIsOpenBracket && LastCharacterIsCloseBracket)
                                            {

                                                DefaultValue = "(" + DefaultValue + ")";

                                            }
                                            else if (FirstCharacterIsOpenBracket)
                                            {

                                                DefaultValue = "(" + DefaultValue;

                                            }
                                            else if (LastCharacterIsCloseBracket)
                                            {

                                                DefaultValue = DefaultValue + ")";

                                            }

                                        }

                                    }
                                    else
                                    {

                                        Convert.ToString(DEColumnConstraint.Value);

                                    }

                                }
                                else
                                {

                                    throw new Exception("Default" + ConstraintAlreadyPresent);

                                }

                            }

                        }

                    }

                    if (ColumnsCount < 1)
                        TheSB.Append(", ");

                }

                if (TheTable.HasConstraints)
                {

                    DbPrimaryKeyTableConstraint PKTableConstraint = null;

                    DbUniqueTableConstraint UNTableConstraint = null;

                    DbCheckConstraint CHConstraint = null;

                    DbForeignKeyTableConstraint FKColumnConstraint = null;

                    foreach (IDbConstraint Item in TheTable.Constraints)
                    {

                        TheSB.Append(", ");

                        WriteConstraintName(Item, TheSB);

                        Type TypeOfItemConstraint = Item.GetType();

                        if (TypeOfItemConstraint == typeof(DbPrimaryKeyColumnConstraint))
                        {

                            if (PKTableConstraint != null)
                            {

                                if (!HasPrimaryKeyTableConstraint)
                                {

                                    PKTableConstraint = Item as DbPrimaryKeyTableConstraint;

                                    if (PKTableConstraint.Columns.Count > 0)
                                    {

                                        int PKTableConstraintColumnsCount = PKTableConstraint.Columns.Count;

                                        TheSB.Append(CommonSQL.PRIMARY_KEY_Openbracket);

                                        foreach (DbColumn ColumnItem in PKTableConstraint.Columns)
                                        {

                                            PKTableConstraintColumnsCount--;

                                            TheSB.Append('"');

                                            TheSB.Append(ColumnItem.Name);

                                            if (PKTableConstraintColumnsCount > 0)
                                                TheSB.Append("\", ");
                                            else
                                                TheSB.Append('"');

                                        }

                                        TheSB.Append(')');

                                    }
                                    else 
                                    {

                                        throw new Exception("Provoided Primary Key table-constraint has no columns");

                                    }

                                }
                                else
                                {

                                    throw new Exception("Primary Key" + ConstraintAlreadyPresent);

                                }

                            }
                            else
                            {

                                throw new Exception("Primary Key" + ConstraintAlreadyPresent);

                            }

                        }

                        if (TypeOfItemConstraint == typeof(DbUniqueTableConstraint))
                        {

                            if (UNTableConstraint != null)
                            {

                                UNTableConstraint = Item as DbUniqueTableConstraint;

                                if (UNTableConstraint.Columns.Count > 0)
                                {

                                    TheSB.Append(CommonSQL.UNIQUE_);

                                    int UNTableConstraintColumnsCount = UNTableConstraint.Columns.Count;

                                    foreach (DbColumn ColumnItem in PKTableConstraint.Columns)
                                    {

                                        UNTableConstraintColumnsCount--;

                                        TheSB.Append(ColumnItem.Name);

                                        if (UNTableConstraintColumnsCount > 0)
                                            TheSB.Append("\", ");
                                        else
                                            TheSB.Append('"');

                                    }

                                    TheSB.Append(')');

                                }
                                else
                                {

                                    throw new Exception("Provoided Primary Key table-constraint has no columns");

                                }

                            }
                            else
                            {

                                throw new Exception("Unique" + ConstraintAlreadyPresent);

                            }

                        }

                        if (TypeOfItemConstraint == typeof(DbCheckConstraint))
                        {

                            if (CHConstraint != null)
                            {

                                CHConstraint = Item as DbCheckConstraint;

                                TheSB.Append(CommonSQL._CHECK_Openbraket);

                                CHConstraint.Condition.AppendTo(TheSB);

                                TheSB.Append(')');

                            }
                            else
                            {

                                throw new Exception("Unique" + ConstraintAlreadyPresent);

                            }

                        }

                        if (TypeOfItemConstraint == typeof(DbForeignKeyTableConstraint))
                        {

                            if (FKColumnConstraint != null)
                            {

                                FKColumnConstraint = Item as DbForeignKeyTableConstraint;

                                if (FKColumnConstraint.Columns.Count > 0)
                                {

                                    int FKColumnConstraintColumnsCount = FKColumnConstraint.Columns.Count;

                                    TheSB.Append(CommonSQL.FOREIGN_KEY_OpBr_);

                                    foreach (DbColumn ColumnItem in FKColumnConstraint.Columns)
                                    {

                                        FKColumnConstraintColumnsCount--;

                                        TheSB.Append(ColumnItem.Name);

                                        if (FKColumnConstraintColumnsCount > 0)
                                            TheSB.Append("\", ");
                                        else
                                            TheSB.Append('"');

                                    }

                                    TheSB.Append(')');

                                    switch (FKColumnConstraint.RowChangeAction)
                                    {

                                        case RowChangeAction.Default:
                                            break;
                                        case RowChangeAction.On_delete_cascade:

                                            TheSB.Append(CommonSQL._ON_DELETE_CASCADE);

                                            break;
                                        case RowChangeAction.On_delete_no_action:

                                            TheSB.Append(CommonSQL._ON_DELETE_NO_ACTION);

                                            break;
                                        case RowChangeAction.On_delete_restrict:

                                            TheSB.Append(CommonSQL._ON_DELETE_RESTRICT);

                                            break;
                                        case RowChangeAction.On_delete_set_default:

                                            TheSB.Append(CommonSQL._ON_DELETE_SET_DEFAULT);

                                            break;
                                        case RowChangeAction.On_delete_set_null:

                                            TheSB.Append(CommonSQL._ON_DELETE_SET_NULL);

                                            break;
                                        case RowChangeAction.On_update_cascade:

                                            TheSB.Append(CommonSQL._ON_UPDATE_CASCADE);

                                            break;
                                        case RowChangeAction.On_update_no_action:

                                            TheSB.Append(CommonSQL._ON_UPDATE_NO_ACTION);

                                            break;
                                        case RowChangeAction.On_update_restrict:

                                            TheSB.Append(CommonSQL._ON_UPDATE_RESTRICT);

                                            break;
                                        case RowChangeAction.On_update_set_default:

                                            TheSB.Append(CommonSQL._ON_UPDATE_SET_DEFAULT);

                                            break;
                                        case RowChangeAction.On_update_set_null:

                                            TheSB.Append(CommonSQL._ON_UPDATE_SET_NULL);

                                            break;

                                    }

                                    switch(FKColumnConstraint.ForeignKeyMatching)
                                    {

                                        case ForeignKeyMatching.Default:
                                            break;
                                        case ForeignKeyMatching.Full:

                                            TheSB.Append(CommonSQL._MATCH_SIMPLE);

                                            break;
                                        case ForeignKeyMatching.Partial:

                                            TheSB.Append(CommonSQL._MATCH_PARTIAL);

                                            break;
                                        case ForeignKeyMatching.Simple:

                                            TheSB.Append(CommonSQL._MATCH_SIMPLE);

                                            break;

                                    }

                                    switch (FKColumnConstraint.Deferablity)
                                    {

                                        case Deferablity.Default:
                                            break;
                                        case Deferablity.Deferable:

                                            TheSB.Append(CommonSQL._DEFERRABLE);

                                            break;
                                        case Deferablity.Deferable_initally_deferred:

                                            TheSB.Append(CommonSQL._DEFERRABLE_INITALLY_DEFERRED);

                                            break;
                                        case Deferablity.Deferable_initally_immediate:

                                            TheSB.Append(CommonSQL._DEFERRABLE_INITALLY_IMMEDIATE);

                                            break;
                                        case Deferablity.Not_deferable:

                                            TheSB.Append(CommonSQL._NOT_DEFERRABLE);

                                            break;
                                        case Deferablity.Not_deferable_initally_deferred:

                                            TheSB.Append(CommonSQL._NOT_DEFERRABLE_INITALLY_DEFERRED);

                                            break;
                                        case Deferablity.Not_deferable_initally_immediate:

                                            TheSB.Append(CommonSQL._NOT_DEFERRABLE_INITALLY_IMMEDIATE);

                                            break;

                                    }

                                }
                                else
                                {

                                    throw new Exception("Provoided Primary Key table-constraint has no columns");

                                }

                            }
                            else
                            {

                                throw new Exception("Unique" + ConstraintAlreadyPresent);

                            }

                        }

                    }

                }

            }
            else
            {

                throw new Exception("No Columns found in the provided Table");

            }

        }

        protected void WriteConstraintName(IDbConstraint TheConstraint, StringBuilder TheSB)
        {

            if (TheConstraint.HasName)
            {

                TheSB.Append(CommonSQL._CONSTRAINT_);

                TheSB.Append('"');

                TheSB.Append(TheConstraint.Name);

                TheSB.Append("\" ");

            }
            else
            {

                throw new Exception("Provided constraint Has no name");

            }

        }

        //protected void Write(DbPrimaryKeyColumnConstraint ThePrimaryKeyColumnConstraint, StringBuilder TheSB)
        //{
        //    if (ThePrimaryKeyColumnConstraint.AutoIncrement)
        //    {
        //    }
        //}

        //protected void Write(DbNotNullColumnConstraint TheNotNullColumnConstraint, StringBuilder TheSB)
        //{
        //}

        //protected void Write(DbUniqueColumnConstraint TheUniqueColumnConstraint, StringBuilder TheSB)
        //{
        //}

        //protected void Write(DbCheckConstraint TheCheckConstraint, StringBuilder TheSB)
        //{
        //}

        //protected void Write(DbDefaultColumnConstraint TheDefaultColumnConstraint, StringBuilder TheSB)
        //{
        //}

    }

}