using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public abstract class BaseDbEntity //: IROHasName
    {

        protected string myName;

        protected string myDescription;

        public BaseDbEntity() 
        {
        }


        public virtual string Name
        {

            get 
            {

                return Name;

            }

        }

        public virtual bool HasName
        {

            get
            {

                return myName != null && myDescription.Length > 0;


            }

        }

        public virtual string Description
        {

            get
            {

                return myDescription;

            }

        }

        public virtual bool HasDescription
        {

            get
            {

                return myDescription != null && myDescription.Length > 0;


            }

        }

    }

}
