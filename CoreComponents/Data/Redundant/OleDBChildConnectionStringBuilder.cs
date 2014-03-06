using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.OleDB
{
    public class OleDBChildConnectionStringBuilder : OleDBConnectionStringBuilder, IReadonlyChild<IHasAConnectionString>
    {

        IHasAConnectionString _Parent;

        public OleDBChildConnectionStringBuilder(IHasAConnectionString TheParent)
        {

            _Parent = TheParent;

        }

        #region IReadOnlyChild<IHasAConnectionString> Members

        public IHasAConnectionString Parent
        {
            get
            {
                return _Parent;
            }
        }

        #endregion

        void SetParentCS()
        {

            _Parent.ConnectionString = ToString();

        }
		
		public bool IsOrphin()
		{
			
			return false;
			
		}


    }

}
