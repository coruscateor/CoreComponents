using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbEntityWithConstraints : DbEntity
    {

        protected List<IDbConstraint> myConstraints = new List<IDbConstraint>();

        public DbEntityWithConstraints()
        {
        }

        public DbEntityWithConstraints(string TheName) : base(TheName)
        {
        }

        public List<IDbConstraint> Constraints
        {

            get
            {

                return myConstraints;

            }

        }

        public bool HasConstraints
        {

            get
            {

                return myConstraints.Count > 0;

            }

        }

    }

}
