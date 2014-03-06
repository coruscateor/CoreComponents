using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data.Schema
{
    public interface ITypeConverter
    {

        DbType Lookup(string DbType);

        //string GetDefaultValue(DbType ToType, string DefaultValue);

    }
}
