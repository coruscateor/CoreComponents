using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
    public static class ConnectionTester
    {

        /*
        public static readonly KeyValuePair<bool, string> StringNotRecognised;

        static ConnectionTester()
        {

            StringNotRecognised = new KeyValuePair<bool, string>(false, "Database string not recogised");

        }
        */

        static ConnectionTester()
        {
        }

        public static KeyValuePair<bool, string> Test(DbConnection Connection)
        {

            KeyValuePair<bool, string> Result;

            try
            {

                Connection.Open();

                Result = new KeyValuePair<bool, string>(true, "Connection Succeeded!");


            } catch (Exception e)
            {

                Result = new KeyValuePair<bool, string>(false, e.Message);

            } finally
            {

                Connection.Close();

            }

            return Result;

        }

        public static bool QuickTest(DbConnection Connection)
        {

            bool Result;

            try
            {

                Connection.Open();

                Result = true;

            } finally
            {

                Connection.Close();

            }

            return Result;

        }
    }
}
