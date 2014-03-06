using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.Schema
{
    public abstract class BaseDbEntity : IROHasName
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

        public virtual string Description
        {

            get
            {

                return myDescription;

            }

        }

        public virtual bool HasDescription()
        {

            return myDescription.Length > 0;

        }
    }
}
