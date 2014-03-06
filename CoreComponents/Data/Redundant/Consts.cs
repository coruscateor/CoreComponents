using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public static class Consts
    {

        public const string varmax = "(255)";
        public const string defprec = "(5,2)";
        

    }

    public static class DatabaseTypeStrings
    {

        public const string SQLite = "SQLite";
        public const string SQLServer = "SQLServer";

    }

    public enum DatabaseTypeEnum
    {

        SQLite,
        SQLServer

    }
}
