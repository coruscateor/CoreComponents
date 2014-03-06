using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public static class SQLStatementFragmentWriter
    {

        public static void AppendConditions(StringBuilder TheSB, IEnumerable<IDbCondition> TheConditions)
        {

            int Count = 0;

            if (TheConditions is Array)
            {

                Count = (TheConditions as Array).Length;

            }
            else if (TheConditions is ICollection<IDbCondition>)
            {

                Count = (TheConditions as ICollection<IDbCondition>).Count;

            }

            if (Count > 0)
            {

                TheSB.Append(CommonSQL._WHERE_);

                foreach (IDbCondition Item in TheConditions)
                {

                    Count--;

                    Item.AppendTo(TheSB);

                    if (Count > 0)
                    {

                        TheSB.Append(", ");

                    }

                }

            }

        }

    }

}
