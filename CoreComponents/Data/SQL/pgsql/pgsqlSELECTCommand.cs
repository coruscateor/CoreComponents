﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Caching.Parameters;
using CoreComponents.Data.SQL.pgsql.SubCommands;

namespace CoreComponents.Data.SQL.pgsql
{
    /*
    [ WITH [ RECURSIVE ] with_query [, ...] ]
SELECT [ ALL | DISTINCT [ ON ( expression [, ...] ) ] ]
    * | expression [ [ AS ] output_name ] [, ...]
    [ FROM from_item [, ...] ]
    [ WHERE condition ]
    [ GROUP BY expression [, ...] ]
    [ HAVING condition [, ...] ]
    [ WINDOW window_name AS ( window_definition ) [, ...] ]
    [ { UNION | INTERSECT | EXCEPT } [ ALL ] select ]
    [ ORDER BY expression [ ASC | DESC | USING operator ] [ NULLS { FIRST | LAST } ] [, ...] ]
    [ LIMIT { count | ALL } ]
    [ OFFSET start [ ROW | ROWS ] ]
    [ FETCH { FIRST | NEXT } [ count ] { ROW | ROWS } ONLY ]
    [ FOR { UPDATE | SHARE } [ OF table_name [, ...] ] [ NOWAIT ] [...] ]

where from_item can be one of:

    [ ONLY ] table_name [ * ] [ [ AS ] alias [ ( column_alias [, ...] ) ] ]
    ( select ) [ AS ] alias [ ( column_alias [, ...] ) ]
    with_query_name [ [ AS ] alias [ ( column_alias [, ...] ) ] ]
    function_name ( [ argument [, ...] ] ) [ AS ] alias [ ( column_alias [, ...] | column_definition [, ...] ) ]
    function_name ( [ argument [, ...] ] ) AS ( column_definition [, ...] )
    from_item [ NATURAL ] join_type from_item [ ON join_condition | USING ( join_column [, ...] ) ]

and with_query is:

    with_query_name [ ( column_name [, ...] ) ] AS ( select )

TABLE { [ ONLY ] table_name [ * ] | with_query_name }
*/

    public class pgsqlSELECTCommand : SQLQuery
    {
		
		//WITH
        pgsqlWITHSubcommand myWITH;

		//DISTINCT
        pgsqlALL_DISTINCT_ON_SubCommand myALLDISTINCTON;

		
        public pgsqlSELECTCommand()
        {

            myIncludeList = new OptionalParamList(
                "WITH", "ALL_DISTINCTS_ON");

            //myIncludeList.OptionChanged += myIncludeList_OptionChanged;

        }

        void myIncludeList_OptionChanged(KeyValueChangedEventArgs<OptionalList<string, bool>, string, bool> Somethin)
        {
            switch (Somethin.Key)
            {
                case "WITH":
                    break;

            }
        }

		/*
        public override string ToString()
        {

            StringBuilder SB = new StringBuilder();

            Append(SB);

            return SB.ToString();

        }
        */
		
        protected override void Append(StringBuilder SB)
        {
            //throw new NotImplementedException();
        }
        

    }
}