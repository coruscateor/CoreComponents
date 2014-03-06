using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.SQL
{
    public class SQLColumn : ItemAlias
    {

        public SQLColumn()
        {

        }

        public override string GetItemName()
        {
            throw new NotImplementedException();
        }

        protected override string SetItem(object theItem)
        {
            throw new NotImplementedException();
        }
    }
}
