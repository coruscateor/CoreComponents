using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface IDefaultValueConverter
    {

        string Convert(DbType ToType, string DefaultValue);

    }

}
