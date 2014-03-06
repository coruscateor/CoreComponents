using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data.Tables
{
    public interface ITableManager
    {

        DataTable Table
        {

            get;

        }

        string Name
        {

            get;

        }

        DataColumn[] PrimaryKey
        {

            get;

        }

        bool Owns(DataTable Data);

        bool PrimaryKeyIsComposite();

        //void Execute();

        MissingSchemaAction MissingSchema
        {

            get;
            set;

        }

        void PrepareCommand();

        //void Execute(params int[] Locations);

        void SetPKs(IEnumerable<int> Locations);

        void SetPK(int Location);

        void AddConstarint(ForeignKeyConstraint Con);

        void AddConstarint(string constraintName, DataColumn parentColumn, DataColumn childColumn);

        void AddConstarint(string constraintName, DataColumn[] parentColumns, DataColumn[] childColumns);

        void FillTable();

        int Update();

		/*
        int Update(DataUpdateSelection Selection);
		 */
		
        void Clear();

        DataProviderType Provider
        {
            get;
        }

    }
}
