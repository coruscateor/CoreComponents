using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public static class SQLKeywords
    {

        public const string SELECT = "SELECT";

        public const string Astrisk = "*";

        public const string FROM = "FROM";

        public const string WHERE = "WHERE";

        public const string CREATE = "CREATE";

        public const string TABLE = "TABLE";

        //(SiteId INTEGER DEFAULT 0, UnixTimestamp INTEGER NOT NULL, Timestamp DATETIME NOT NULL, NumberOfFiles INTERGER DEFAULT 0, FileTypes TEXT DEFAULT "", FOREIGN KEY (SiteId) REFERENCES Sites (Id))

        public const string INTEGER = "INTEGER";

        public const string DEFAULT = "DEFAULT";

        public const string NOT = "NOT";

        public const string NULL = "NULL";

        public const string DATETIME = "DATETIME";

        public const string TEXT = "TEXT";

        public const string FOREIGN = "FOREIGN";

        public const string KEY = "KEY";

        public const string REFERENCES = "REFERENCES";

        public const string CONSTRIANT = "CONSTRIANT";

        public const string PRIMARY = "PRIMARY";

        public const string ASC = "ASC";

        public const string DESC = "DESC";

        public const string AUTOINCREMENT = "AUTOINCREMENT";

        public const string AS = "AS";

        public const string UNIQUE = "UNIQUE";

        public const string CHECK = "CHECK";

        public const string COLLATE = "COLLATE";

        public const string ON = "ON";

        public const string DELETE = "DELETE";

        public const string UPDATE = "UPDATE";

        public const string SET = "SET";

        public const string CASCADE = "CASCADE";

        public const string RESTRICT = "RESTRICT";

        public const string NO = "ACTION";

        public const string MATCH = "MATCH";

        public const string DEFERABLE = "DEFERABLE";

        public const string INITALLY = "INITALLY";

        public const string DEFERRED = "DEFERRED";

        public const string IMMEDIATE = "IMMEDIATE";

    }

}
