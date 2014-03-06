using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    //public enum ColumnConstraintType
    //{

    //    PrimaryKey,
    //    NotNull,
    //    Unique,
    //    Check,
    //    Default

    //}

    //public enum TableConstraintType
    //{

    //    PrimaryKey,
    //    Unique,
    //    Check,
    //    ForeignKey

    //}

    public enum AscendingDecending
    {

        Ascending,
        Decending,
        Default

    }

    public enum ForeignKeyMatching
    {

        Full,
        Partial,
        Simple,
        Default

    }

    public enum RowChangeAction
    {
 
        On_delete_set_null,
        On_delete_set_default,
        On_delete_cascade,
        On_delete_restrict,
        On_delete_no_action,
        On_update_set_null,
        On_update_set_default,
        On_update_cascade,
        On_update_restrict,
        On_update_no_action,
        Default

    }

    public enum Deferablity
    {
 
        Deferable,
        Not_deferable,
        Deferable_initally_immediate,
        Not_deferable_initally_immediate,
        Deferable_initally_deferred,
        Not_deferable_initally_deferred,
        Default

    }

}
