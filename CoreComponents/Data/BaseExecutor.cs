using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Dynamic;

namespace CoreComponents.Data
{

    public abstract class BaseExecutor<TConnection, TCommand, TParameter>
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
    {

        protected TCommand myCommand;

        protected bool myRetainParameters;

        public BaseExecutor(TCommand TheCommand)
        {

            myCommand = TheCommand;

        }

        protected DataTable GetDataTable(DbDataReader TheDbDataReader)
        {

            DataTable DT = new DataTable();

            try
            {

                if(TheDbDataReader.HasRows && !TheDbDataReader.IsClosed)
                {

                    int NumberOfRows = TheDbDataReader.FieldCount;

                    //Setup Columns

                    for(int i = 0; i < NumberOfRows; ++i)
                    {

                        DT.Columns.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetFieldType(i));

                    }

                    //Add Data

                    while(TheDbDataReader.Read())
                    {

                        object[] Values = new object[NumberOfRows];

                        TheDbDataReader.GetValues(Values);

                        DT.Rows.Add(Values);

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

            return DT;

        }

        protected void SetDictionary(DbDataReader TheDbDataReader, IDictionary<string, object> TheDictionary)
        {

            try
            {

                if(TheDbDataReader.HasRows && !TheDbDataReader.IsClosed)
                {

                    int NumberOfRows = TheDbDataReader.FieldCount;

                    for(int i = 0; i < NumberOfRows; ++i)
                    {

                        TheDictionary.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetValue(i));

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

        }

        protected void SetDictionaries(DbDataReader TheDbDataReader, IEnumerable<IDictionary<string, object>> TheList)
        {

            try
            {

                if(TheDbDataReader.HasRows && !TheDbDataReader.IsClosed)
                {

                    foreach(var Item in TheList)
                    {

                        int NumberOfRows = TheDbDataReader.FieldCount;

                        for(int i = 0; i < NumberOfRows; ++i)
                        {

                            Item.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetValue(i));

                        }

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

        }

        protected List<dynamic> GetExpandoObjects(DbDataReader TheDbDataReader)
        {

            List<dynamic> Items = new List<dynamic>();

            try
            {

                if(!TheDbDataReader.IsClosed)
                {

                    while(TheDbDataReader.Read())
                    {

                        IDictionary<string, object> Item = new ExpandoObject();

                        int NumberOfRows = TheDbDataReader.FieldCount;

                        for(int i = 0; i < NumberOfRows; ++i)
                        {

                            Item.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetValue(i));

                        }

                        Items.Add(Item);

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

            return Items;

        }

        protected List<Dictionary<string, object>> GetDictionaries(DbDataReader TheDbDataReader)
        {

            List<Dictionary<string, object>> Items = new List<Dictionary<string, object>>();

            try
            {

                if(!TheDbDataReader.IsClosed)
                {

                    while(TheDbDataReader.Read())
                    {

                        Dictionary<string, object> Item = new Dictionary<string, object>();

                        int NumberOfRows = TheDbDataReader.FieldCount;

                        for(int i = 0; i < NumberOfRows; ++i)
                        {

                            Item.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetValue(i));

                        }

                        Items.Add(Item);

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

            return Items;

        }

        protected void GetDictionaries(DbDataReader TheDbDataReader, Action<Dictionary<string, object>> TheRowAction)
        {

            try
            {

                if(!TheDbDataReader.IsClosed)
                {

                    while(TheDbDataReader.Read())
                    {

                        Dictionary<string, object> Item = new Dictionary<string, object>();

                        int NumberOfRows = TheDbDataReader.FieldCount;

                        for(int i = 0; i < NumberOfRows; ++i)
                        {

                            Item.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetValue(i));

                        }

                        TheRowAction(Item);

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

        }

        protected void GetExpandoObjects(DbDataReader TheDbDataReader, Action<dynamic> TheRowAction)
        {

            try
            {

                if(!TheDbDataReader.IsClosed)
                {

                    while(TheDbDataReader.Read())
                    {

                        IDictionary<string, object> Item = new ExpandoObject();

                        int NumberOfRows = TheDbDataReader.FieldCount;

                        for(int i = 0; i < NumberOfRows; ++i)
                        {

                            Item.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetValue(i));

                        }

                        TheRowAction(Item);

                    }

                }

            }
            finally
            {

                TheDbDataReader.Close();

            }

        }

        public void Prepare()
        {

            myCommand.Prepare();

        }

        //Parameters

        public IEnumerable<object> ParameterValues
        {

            get
            {

                if(myCommand.Parameters.Count > 0)
                {

                    object[] Items = new object[myCommand.Parameters.Count];

                    for(int i = 0; i < myCommand.Parameters.Count; i++)
                    {

                        Items[i] = myCommand.Parameters[i].Value;

                    }

                    return Items;

                }

                return new object[0];

            }
            set
            {

                SetParameterValues(value);

            }

        }

        public void ClearParameters()
        {

            myCommand.Parameters.Clear();

        }

        protected void ResetParameters()
        {

            if(!myRetainParameters)
            {

                ClearParameters();

            }

        }

        public bool RetainParameters
        {

            get
            {

                return myRetainParameters;

            }
            set
            {

                myRetainParameters = value;

            }

        }

        public void SetParameters(params object[] TheParameters)
        {

            SetParameterValues(TheParameters);

        }

        public void SetParameters(IEnumerable<KeyValuePair<string, object>> TheParameters)
        {

            ClearParameters();

            foreach(KeyValuePair<string, object> Item in TheParameters)
            {

                TParameter NewParameter = new TParameter();

                NewParameter.Value = Item.Value;

                NewParameter.ParameterName = Item.Key;

                myCommand.Parameters.Add(NewParameter);

            }

        }

        public void SetParameters(dynamic TheParameters)
        {

            ClearParameters();

            foreach(KeyValuePair<string, object> Item in TheParameters)
            {

                TParameter NewParameter = new TParameter();

                NewParameter.Value = Item.Value;

                NewParameter.ParameterName = Item.Key;

                myCommand.Parameters.Add(NewParameter);

            }

        }

        public void SetParameterValues(IEnumerable<object> TheParameters)
        {

            ClearParameters();

            foreach(object Item in TheParameters)
            {

                TParameter NewParameter = new TParameter();

                NewParameter.Value = Item;

                myCommand.Parameters.Add(NewParameter);

            }

        }

        public void SetParameters(params KeyValuePair<string, object>[] TheParameters)
        {

            SetParameters(TheParameters);

        }

        public IEnumerable<KeyValuePair<string, object>> GetParameterNamesAndValues()
        {

            Queue<KeyValuePair<string, object>> myParameterQueue = new Queue<KeyValuePair<string, object>>();

            foreach(DbParameter Item in myCommand.Parameters)
            {

                myParameterQueue.Enqueue(new KeyValuePair<string, object>(Item.ParameterName, Item.Value));

            }

            return myParameterQueue;

        }

        public void GetParameterNamesAndValuesInto(ref ICollection<KeyValuePair<string, object>> TheParameterSet)
        {

            foreach(DbParameter Item in myCommand.Parameters)
            {

                TheParameterSet.Add(new KeyValuePair<string, object>(Item.ParameterName, Item.Value));

            }

        }

        public void GetParameterNamesAndValuesInto(ref IDictionary<string, object> TheParameterSet)
        {

            foreach(DbParameter Item in myCommand.Parameters)
            {

                TheParameterSet.Add(Item.ParameterName, Item.Value);

            }

        }

        public bool HasParameterWithName(string TheName)
        {

            return myCommand.Parameters.Contains(TheName);

        }

        public bool HasParameterWithValue(string TheValue)
        {

            return myCommand.Parameters.Contains(TheValue);

        }

        public object GetValueOfParameter(string TheName)
        {

            foreach(var Item in myCommand.Parameters)
            {

                DbParameter CurrentDbParameter = (DbParameter)Item;

                if(CurrentDbParameter.ParameterName == TheName)
                    return CurrentDbParameter.Value;

            }

            return null;

        }

        public bool TryGetValueOfParameter(string TheName, out object TheValue)
        {

            foreach(var Item in myCommand.Parameters)
            {

                DbParameter CurrentDbParameter = (DbParameter)Item;

                if(CurrentDbParameter.ParameterName == TheName)
                {

                    TheValue = CurrentDbParameter.Value;

                    return true;

                }

            }

            TheValue = null;

            return false;

        }

        public bool HasParameters
        {

            get
            {

                return myCommand.Parameters.Count > 0;

            }

        }

        public string ConnectionString
        {

            get
            {

                return myCommand.Connection.ConnectionString;

            }
            set
            {

                myCommand.Connection.ConnectionString = value;

            }

        }

        public string Database
        {

            get
            {

                return myCommand.Connection.Database;

            }
            set
            {

                myCommand.Connection.ChangeDatabase(value);

            }

        }

        public string DataSource
        {

            get
            {

                return myCommand.Connection.DataSource;

            }

        }

        public string ServerVersion
        {

            get
            {

                return myCommand.Connection.ServerVersion;

            }

        }

        public ConnectionState ConnectionState
        {

            get
            {

                return myCommand.Connection.State;

            }

        }

        public int ConnectionTimeout
        {

            get
            {

                return myCommand.Connection.ConnectionTimeout;

            }

        }

        public int CommandTimeout
        {

            get
            {

                return myCommand.CommandTimeout;

            }
            set
            {

                myCommand.CommandTimeout = value;

            }

        }

        public CommandType CommandType
        {

            get
            {

                return myCommand.CommandType;

            }
            set
            {

                myCommand.CommandType = value;

            }

        }

        public string CommandText
        {

            get
            {

                return myCommand.CommandText;
                
            }
            set
            {

                myCommand.CommandText = value;

            }

        }

        public void SetCommandText(object TheCommandObject)
        {

            myCommand.CommandText = TheCommandObject.ToString();

        }

        public bool ConnectionIsActive
        {

            get
            {

                ConnectionState State = myCommand.Connection.State;

                return State == ConnectionState.Open || State == ConnectionState.Connecting || State == ConnectionState.Executing || State == ConnectionState.Fetching;

            }

        }

        public bool TestConnection()
        {

            if(!ConnectionIsActive)
            {

                try
                {

                    myCommand.Connection.Open();

                }
                catch
                {

                    return false;

                }
                finally
                {

                    myCommand.Connection.Close();

                }

            }

            return true;

        }

        public bool TestConnection(out Exception TheException)
        {

            if(!ConnectionIsActive)
            {

                try
                {

                    myCommand.Connection.Open();

                }
                finally
                {

                    myCommand.Connection.Close();

                }

            }

            TheException = null;

            return true;

        }

        public bool TestConnection(out string TheMessage)
        {

            if(!ConnectionIsActive)
            {

                try
                {

                    myCommand.Connection.Open();

                }
                catch(Exception e)
                {

                    TheMessage = e.Message;

                    return false;

                }
                finally
                {

                    myCommand.Connection.Close();

                }

            }

            TheMessage = "Connection Succeeded!";

            return true;

        }

    }

}
