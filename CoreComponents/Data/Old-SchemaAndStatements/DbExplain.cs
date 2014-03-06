using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbExplain
    {

        protected bool myQueryPlan;

        protected string myStatement;

        public DbExplain() 
        {
        }

        public bool QueryPlan
        {

            get 
            {

                return myQueryPlan;

            }
            set 
            {

                myQueryPlan = value;

            }

        }

        public string Statement 
        {

            get 
            {

                return myStatement;

            }
            set 
            {

                myStatement = value;

            }

        }

    }

}
