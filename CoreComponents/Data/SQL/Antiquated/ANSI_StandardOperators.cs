using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{

    public enum ANSI_StandardOperators
    {

        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        BETWEEN,
        LIKE,
        IN

    }

    public static class ANSI_ConstStandardOperators
    {

        public const string Equals = "=";
        public const string NotEquals = "<>";
        public const string GreaterThan = ">";
        public const string LessThan = "<";
        public const string GreaterThanOrEqualTo = ">=";
        public const string LessThanOrEqualTo = "<=";
        public const string BETWEEN = "BETWEEN";
        public const string LIKE = "LIKE";
        public const string IN = "IN";

    }

}
