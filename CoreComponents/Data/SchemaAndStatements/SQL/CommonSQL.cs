using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public static class CommonSQL
    {

        public const string SELECT_ = "SELECT ";

        public const string SELECT_ALL_ = "SELECT * ";

        public const string _FROM_ = " FROM ";

        public const string _WHERE_ = " WHERE ";

        public const string CREATE_ = "CREATE ";

        public const string CREATE_TABLE_ = "CREATE TABLE ";

        public const string TABLE_ = "TABLE ";

        public const string IF_NOT_EXISTS_ = "IF NOT EXISTS ";

        public const string TEMP_ = "TEMP ";

        public const string TEMPORARY_ = "TEMPORARY ";

        public const string _AS_ = " AS ";

        public const string AS_ = "AS ";

        public const string _CONSTRAINT_ = " CONSTRAINT ";

        public const string PRIMARY_KEY_ = "PRIMARY KEY ";

        public const string PRIMARY_KEY_Openbracket = "PRIMARY KEY (";

        public const string _PRIMARY_KEY = " PRIMARY KEY";

        public const string FOREIGN_KEY_ = "FOREIGN KEY ";

        public const string FOREIGN_KEY_OpBr_ = "FOREIGN KEY ( ";

        public const string _ASC = " ASC";

        public const string _DESC = " DESC";

        public const string _AUTOINCREMENT = "_AUTOINCREMENT";

        public const string _NOT_NULL = " NOT NULL";

        public const string _UNIQUE = " UNIQUE";

        public const string UNIQUE_ = "UNIQUE ";

        public const string DEFAULT_ = "DEFAULT ";

        public const string REFERENCES_ = "REFERENCES ";

        public const string REFERENCES_OpBr_ = "REFERENCES ( ";

        public const string _ON_ = " ON ";

        public const string DELETE_ = "DELETE ";

        public const string UPDATE_ = "UPDATE ";

        public const string _ON_DELETE_CASCADE = " ON DELETE CASCADE";

        public const string _ON_DELETE_NO_ACTION = " ON DELETE NO ACTION";

        public const string _ON_DELETE_SET_NULL = " ON DELETE SET NULL";

        public const string _ON_DELETE_SET_DEFAULT = " ON DELETE SET DEFAULT";

        public const string _ON_DELETE_RESTRICT = " ON DELETE RESTRICT";

        public const string _ON_UPDATE_CASCADE = " ON UPDATE CASCADE";

        public const string _ON_UPDATE_NO_ACTION = " ON UPDATE NO ACTION";

        public const string _ON_UPDATE_SET_NULL = " ON UPDATE SET NULL";

        public const string _ON_UPDATE_SET_DEFAULT = " ON UPDATE SET DEFAULT";

        public const string _ON_UPDATE_RESTRICT = " ON UPDATE RESTRICT";

        public const string SET_NULL_ = "SET NULL ";

        public const string SET_DEFAULT_ = "SET DEFAULT ";

        public const string CASCADE_ = "CASCADE ";

        public const string RESTRICT_ = "RESTRICT ";

        public const string NO_ACTION_ = "NO ACTION ";

        public const string _MATCH_FULL = " MATCH FULL";

        public const string _MATCH_PARTIAL = " MATCH PARTIAL";

        public const string _MATCH_SIMPLE = " MATCH SIMPLE";

        public const string NOT_ = "NOT ";

        public const string _DEFERRABLE = " DEFERRABLE";

        public const string _DEFERRABLE_INITALLY_DEFERRED = " DEFERRABLE INITALLY DEFERRED";

        public const string _DEFERRABLE_INITALLY_IMMEDIATE = " DEFERRABLE INITALLY IMMEDIATE";

        public const string _NOT_DEFERRABLE = " NOT DEFERRABLE";

        public const string _NOT_DEFERRABLE_INITALLY_DEFERRED = " NOT DEFERRABLE INITALLY DEFERRED";

        public const string _NOT_DEFERRABLE_INITALLY_IMMEDIATE = " NOT DEFERRABLE INITALLY IMMEDIATE";

        public const string INITIALLY_DEFERRED_ = "INITIALLY DEFERRED ";

        public const string INITIALLY_IMMEDIATE_ = "INITIALLY IMMEDIATE ";

        public const string ALTER_TABLE_ = "ALTER TABLE ";

        public const string _RENAME_TO_ = " RENAME TO ";

        public const string _ADD_ = " ADD ";

        public const string _ADD_COLUMN_ = " ADD COLUMN ";

        public const string OR_ROLLBACK_ = "OR ROLLBACK ";

        public const string OR_ABORT_ = "OR ABORT ";

        public const string OR_REPLACE_ = "OR REPLACE ";

        public const string OR_FAIL_ = "OR FAIL ";

        public const string OR_IGNORE_ = "OR IGNORE ";

        public const string SET_ = "SET ";

        public const string INDEXED_BY_ = "INDEXED BY ";

        public const string NOT_INDEXED = "NOT INDEXED";

        public const string ORDER_BY_ = "ORDER BY ";

        public const string LIMIT_ = "LIMIT ";

        public const string OFFSET_ = "OFFSET ";

        public const string INSERT_ = "INSERT ";

        public const string INTO_ = "INTO ";

        public const string REPLACE_ = "REPLACE ";

        public const string _VALUES_ = " VALUES ";

        public const string _DEFAULT_VALUES = " DEFAULT VALUES";

        public const string SELECT_DISTINCT_ = "SELECT DISTINCT ";

        public const string GROUP_BY_ = "GROUP BY ";

        public const string HAVING_ = "HAVING ";

        public const string _NATURAL_ = " NATURAL ";

        public const string _LEFT_ = " LEFT ";

        public const string _OUTER_ = " OUTER ";

        public const string _LEFT_OUTER_ = " LEFT OUTER ";

        public const string _INNER_ = " INNER ";

        public const string _CROSS_ = " CROSS ";

        public const string JOIN_ = "JOIN ";

        public const string COLLATE_ = "COLLATE ";

        public const string _USING_ = " USING ";

        public const string UNION_ = "UNION ";

        public const string ALL_ = "ALL ";

        public const string INTERSECT_ = "INTERSECT ";

        public const string EXECPT_ = "EXECPT ";

        public const string NULL_ = "NULL ";

        public const string NULL = "NULL";

        public const string _BETWEEN_ = " BETWEEN ";

        public const char QuestionMark = '?';

        public const string _SingleEquals_ = " = ";

        public const string _DoubleEquals_ = " == ";

        public const string _GreaterThan_ = " > ";

        public const string _GreaterThanOrEqualto_ = " >= ";

        public const string _LessThan_ = " < ";

        public const string _LessThanOrEqualto_ = " <= ";

        public const string _IN_ = " IN ";

        public const string _IS_ = " IS ";

        public const string _IS_NOT_ = " IS NOT ";

        public const string _GreaterThanLessThan_ = " <> ";

        public const string _ExclamationMarkEquals_ = " != ";

        public const string _NOT_IN_ = " NOT IN ";

        public const string EXPLAIN_ = "EXPLAIN ";

        public const string QUERY_PLAN_ = "QUERY PLAN ";

        public const string _CHECK_Openbraket = " CHECK (";

    }

}
