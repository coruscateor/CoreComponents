using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{
    public abstract class CachedTextEntity : ICachedTextEntity
    {

        protected string OutputCache;


        #region ITextEntity Members

        public override string ToString()
        {
            return OutputCache;
        }

        public virtual void Cache()
        {
        }

        public void AppendTo(StringBuilder SB)
        {
        }

        #endregion
    }
}
