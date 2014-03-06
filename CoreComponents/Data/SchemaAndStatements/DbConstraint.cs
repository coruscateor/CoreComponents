using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public abstract class DbConstraint : IDbConstraint
    {

        protected string myName;

        public DbConstraint()
        {
        }
        
        public string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public bool HasName
        {

            get 
            {
                
                return myName != null && myName.Length > 0;
            
            }

        }

        public void ClearName()
        {

            myName = null;

        }

        //public abstract ConstraintType ConstraintType
        //{

        //    get;

        //}
        
    }

}
