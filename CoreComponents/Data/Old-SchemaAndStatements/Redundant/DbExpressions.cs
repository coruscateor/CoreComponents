using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbExpressions
    {

        LazyObject<List<DbColumn>> myIsNull;

        LazyObject<List<DbColumn>> myIsNotNull;

        LazyObject<Dictionary<DbComparasonOperators, Dictionary<object, object>>> myOperations;

        public DbExpressions()
        {
        }

        public List<DbColumn> IsNull
        {

            get
            {

                return myIsNull.Object;

            }

        }

        public bool HasIsNulls
        {

            get
            {

                return myIsNull.HasObject && myIsNull.Object.Count > 0;

            }

        }

        public List<DbColumn> IsNotNull
        {

            get
            {

                return myIsNotNull.Object;

            }

        }

        public bool HasIsNotNulls
        {

            get
            {

                return myIsNotNull.HasObject && myIsNotNull.Object.Count > 0;
                
            }

        }

        public Dictionary<DbComparasonOperators, Dictionary<object, object>> Operations
        {

            get
            {

                return myOperations.Object;

            }
 
        }

        public bool HasOperations
        {

            get
            {

                return myOperations.HasObject && myOperations.Object.Count > 0;

            }

        }

    }

    public enum DbComparasonOperators
    {

        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo,
        EqualTo,
        NotEqualTo,
        Between,
        NotBetween

    }

}
