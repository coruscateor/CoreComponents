using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public class DbHasExpressions
    {

        protected List<object> myExpresions;

        public DbHasExpressions()
        {
        }

        public List<object> Expresions
        {

            get
            {

                return myExpresions;

            }

        }

        public bool HasExpresions
        {

            get
            {

                return myExpresions.Count > 0;

            }

        }

    }

}
