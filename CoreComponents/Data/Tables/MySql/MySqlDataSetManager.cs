using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for MySqlDataSetManager
/// </summary>
/// 

namespace CoreComponents.Data.Tables.MySql
{

    public class MySqlDataSetManager
    {

        DataSet DS;

        MySqlConnection cn;

        List<MySqlTableManager> TableSet = new List<MySqlTableManager>();

        public MySqlDataSetManager()
        {
            DS = new DataSet();

            //DS.Tables.CollectionChanged += Tables_CollectionChanged;
        }

        public MySqlDataSetManager(MySqlConnection cn)
        {

            this.cn = cn;


        }

        public MySqlDataSetManager(string DataSetName)
        {

            DS = new DataSet(DataSetName);

        }

        public string Name
        {

            get
            {

                return DS.DataSetName;

            }

        }

        public int TableCount
        {

            get
            {

                return DS.Tables.Count;

            }
        }

        public void Add(MySqlTableManager Table)
        {

            if (!TableSet.Contains(Table))
            {

                if (!DS.Tables.Contains(Table.Table.TableName))
                {

                    TableSet.Add(Table);

                    DS.Tables.Add(Table.Table);

                }

            }

        }
		
		/*
        public void Add(string SelectCommand, string TableName)
        {


            if (!DS.Tables.Contains(TableName))
            {

                MySqlTableManager NewTable = new MySqlTableManager(SelectCommand, cn, TableName);

                TableSet.Add(NewTable);

                DS.Tables.Add(NewTable.Table);

            }

        }
		*/

        public void Remove(MySqlTableManager Table)
        {

            if (!TableSet.Contains(Table))
            {

                if (!DS.Tables.Contains(Table.Table.TableName))
                {

                    DS.Tables.Remove(Table.Table);

                    TableSet.Remove(Table);

                }
            }

        }

        public void Remove(string TableName)
        {


            foreach (MySqlTableManager Table in TableSet)
            {

                if (Table.Name == TableName)
                {

                    DS.Tables.Remove(Table.Table);

                    TableSet.Remove(Table);

                    return;
                }

            }
        }


        public MySqlTableManager GetTable(int index)
        {

            return TableSet[index];

        }

        public MySqlTableManager GetTable(string Name)
        {
            foreach (MySqlTableManager Table in TableSet)
            {

                if (Table.Name == Name)
                    return Table;
            }

            return null;

        }

        public bool Contains(MySqlTableManager Table)
        {

            return TableSet.Contains(Table) && DS.Tables.Contains(Table.Table.TableName);

        }

        public DataSet DataSet
        {

            get
            {

                return DS;

            }

        }

        public MySqlConnection Connection
        {

            get
            {

                return cn;

            }

        }


        public void AddRelation(string relationName, DataColumn parentColumn, DataColumn childColumn)
        {

            if (!DS.Relations.Contains(relationName))
                DS.Relations.Add(new DataRelation(relationName, parentColumn, childColumn));

        }


        public void AddRelation(DataRelation Relation)
        {

            if (!DS.Relations.Contains(Relation.RelationName))
                DS.Relations.Add(Relation);

        }

        public void RemoveRelation(string relationName)
        {

            if (DS.Relations.Contains(relationName))
                if (DS.Relations.CanRemove(DS.Relations[relationName]))
                    DS.Relations.Remove(relationName);

        }

        public void RemoveRelation(DataRelation Relation)
        {

            if (DS.Relations.Contains(Relation.RelationName))
                if (DS.Relations.CanRemove(Relation))
                    DS.Relations.Remove(Relation);

        }

        public bool ContainsRelation(DataRelation Relation)
        {

            return DS.Relations.Contains(Relation.RelationName);

        }

        public bool ContainsRelation(string relationName)
        {

            return DS.Relations.Contains(relationName);

        }

        public DataRelation GetRelation(int index)
        {

            return DS.Relations[index];

        }

        public DataRelation GetRelation(string name)
        {

            return DS.Relations[name];

        }

        public void ClearRelations()
        {

            DS.Relations.Clear();

        }

        public void Clear()
        {

            DS.Relations.Clear();

            DS.Clear();

        }

    }

}
