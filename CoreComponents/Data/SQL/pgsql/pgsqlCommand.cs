using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Caching.Parameters;
using CoreComponents.Data.SQL.pgsql.SubCommands;

namespace CoreComponents.Data.SQL.pgsql
{
	
    public abstract class pgsqlCommand : SQLCommand
    {
		OptionalParamList myIncludeList;
    }
}
