using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data
{
    public static class Data
    {

        public static string[] GetKeyNames(DataColumn[] PrimaryKey)
        {

            string[] KeyNames = new string[PrimaryKey.Length];

            int PKLength = PrimaryKey.Length;

            for (int i = 0; i < PKLength; i++)
            {

                KeyNames[i] = PrimaryKey[i].ColumnName;

            }

            return KeyNames;

        }

    }
}
