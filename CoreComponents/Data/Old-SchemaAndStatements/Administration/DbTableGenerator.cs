using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Items;
using CoreComponents.Data.SQL;

namespace CoreComponents.Data.Schema.Administration
{

    public interface IDbTableGenerator
    {
    }

    public class DbTableGenerator<TDbTableGenerator> : DbGenerator where TDbTableGenerator : IDbTableGenerator
    {

        public DbTableGenerator()
        {
        }

        public virtual void Generate(DbTable Table, StringBuilder SB)
        {

            if (Table.Columns.Count > 0)
            {

                CreateTable(Table, SB);

                int ColNo = 1;

                foreach (DbColumn Col in Table.Columns)
                {

                    SB.Append(Col.Name);
                    SB.Append(TextEntity.SPACE);
                    //Datatype

                    /*
                    if (Col.IsKey)
                    {
                    }
                    */

                    if (Table.Columns.Count > ColNo)
                    {

                        SB.AppendLine(",");

                    } else
                    {

                        SB.AppendLine();

                    }

                    ColNo++;

                }

                FinishTable(SB);


            }

        }

        public virtual string GenerateText(DbTable Table)
        {

            Clear();

            Generate(Table, mySB);

            return mySB.ToString();

        }

        protected virtual void CreateTable(DbTable Table, StringBuilder SB)
        {
            /*
            SB.Append(ANSI_SQL.CREATE);
            SB.Append(TextEntity.SPACE);
            SB.Append(ANSI_SQL.TABLE);
            SB.Append(TextEntity.SPACE);
            SB.Append(Table.Name);
            SB.Append(TextEntity.SPACE);
            SB.AppendLine("(");
            */ 
             
        }

        protected virtual void FinishTable(StringBuilder SB)
        {

            SB.AppendLine(");");
        }

    }
}
