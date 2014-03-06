using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
    public class IdentifyingDataExtractor : DataExtractor
    {

        string myColumnName;

        int myValue1 = 0;

        int myValue2 = 100;

        int myIncrement;

        public IdentifyingDataExtractor(string TableName, string ColumnName)
            : base(TableName)
        {

            myColumnName = ColumnName;

        }

        public IdentifyingDataExtractor(string TableName, string ColumnName, int Value1, int Value2)
            : base(TableName)
        {

            myColumnName = ColumnName;

            myValue1 =  Value1;

            myValue2 = Value2;

        }

        public override System.Data.IDataReader Next()
        {

            if (myValue1 <= myCount)
            {

                IDataReader Reader = null;

                try
                {

                    myCommand.Connection.Open();

                    Reader = myCommand.ExecuteReader();

                    myValue1 += myIncrement;

                    myValue2 += myIncrement;

                    myCommand.CommandText = SelectCommand();

                } catch (Exception e)
                {

                    OnReadException(e);

                } finally
                {

                    myCommand.Connection.Close();
                }

                return Reader;

            }
            else
            {

                OnReadComplete();

            }

            return null;
        }

        public override string SelectCommand()
		{
			
			StringBuilder SB = new StringBuilder();
			
			SB.Append("SELECT * FROM ");
			
			SB.Append(myTableName);
			
			SB.Append(" WHERE ");
			
			SB.Append(myColumnName);
			
			SB.Append(" BETWEEN ");
			
			SB.Append(myValue1);

            SB.Append(" AND ");

            SB.Append(myValue2);
			
			SB.Append(";");
			
			return SB.ToString();
			
		}

        public virtual int Increment
        {

            get
            {

                return myIncrement;

            }

            set
            {

                myIncrement = value;

                myCommand.CommandText = SelectCommand();

            }

        }

        public virtual int Value1
        {

            get
            {

                return myValue1;

            }
            /*
            set
            {

                myValue1 = value;

                myCommand.CommandText = SelectCommand();

            }
            */
        }

        public virtual int Value2
        {

            get
            {

                return myValue2;

            }
            /*
            set
            {

                myValue2 = value;

                myCommand.CommandText = SelectCommand();

            }
            */
        }

    }
}
