using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Dynamic;

namespace CoreComponents.Data
{

    public class DiscreteExecutor<TConnection, TCommand, TParameter, TTransaction> : BaseExecutor<TConnection, TCommand, TParameter, TTransaction>, IExecutor
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TTransaction : DbTransaction
    {

        public DiscreteExecutor(TCommand TheCommand) : base(TheCommand)
        {

            myCommand = TheCommand;

        }

        public bool IsActive
        {

            get
            {

                ConnectionState CurrentConnectionState = myCommand.Connection.State;

                return CurrentConnectionState == ConnectionState.Open || CurrentConnectionState == ConnectionState.Connecting || CurrentConnectionState == ConnectionState.Executing || CurrentConnectionState == ConnectionState.Fetching;

            }

        }

        public void Open()
        {

            if(!IsActive)
            {

                try
                {

                    myCommand.Connection.Open();

                }
                catch(Exception e)
                {

                    myCommand.Connection.Close();

                    throw e;

                }

            }

        }

        public void Close()
        {

            myCommand.Connection.Close();

        }

        public int ExecuteNonQuery()
        {

            return myCommand.ExecuteNonQuery();

        }

        public int ExecuteNonQuery(string TheCommand)
        {

            myCommand.CommandText = TheCommand;

            return myCommand.ExecuteNonQuery();

        }

        public int ExecuteNonQuery(IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameterValues(TheParameters);

                return myCommand.ExecuteNonQuery();

            }
            finally
            {

                ResetParameters();

            }

        }

        public int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameterValues(TheParameters);

                myCommand.CommandText = TheCommand;

                return myCommand.ExecuteNonQuery();

            }
            finally
            {

                ResetParameters();

            }

        }

        public int ExecuteNonQuery(object TheCommandObject)
        {

            return ExecuteNonQuery(TheCommandObject.ToString());

        }

        public int ExecuteNonQuery(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return ExecuteNonQuery(TheCommandObject.ToString(), TheParameters);

        }

        public int ExecuteNonQueryParamsOnly(params object[] TheParameters)
        {

            return ExecuteNonQuery(TheParameters);

        }

        public int ExecuteNonQueryParams(string TheCommand, params object[] TheParameters)
        {

            return ExecuteNonQuery(TheCommand, TheParameters);

        }

        public int ExecuteNonQueryParams(object TheCommandObject, params object[] TheParameters)
        {

            return ExecuteNonQuery(TheCommandObject.ToString(), TheParameters);

        }

        public int ExecuteNonQuery(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            try
            {

                myCommand.CommandText = TheCommand;

                SetParameters(TheNamedParameters);

                return myCommand.ExecuteNonQuery();

            }
            finally
            {

                myCommand.Connection.Close();

                ResetParameters();

            }

        }

        public int ExecuteNonQuery(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteNonQuery(TheCommandObject.ToString(), TheNamedParameters);

        }

        public int ExecuteNonQuery(string TheCommand, dynamic TheNamedParameters)
        {

            return ExecuteNonQuery(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public int ExecuteNonQuery(object TheCommandObject, dynamic TheNamedParameters)
        {

            return ExecuteNonQuery(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters);

        }

        public DbDataReader ExecuteReader()
        {

            return myCommand.ExecuteReader();

        }

        public DbDataReader ExecuteReader(string TheCommand)
        {

            myCommand.CommandText = TheCommand;

            return myCommand.ExecuteReader();

        }

        public DbDataReader ExecuteReader(IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameterValues(TheParameters);

                return myCommand.ExecuteReader();

            }
            finally
            {

                ResetParameters();

            }

        }

        public DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters)
        {

            try
            {

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return myCommand.ExecuteReader();

            }
            finally
            {

                ResetParameters();

            }

        }

        public DbDataReader ExecuteReader(object TheCommandObject)
        {

            return ExecuteReader(TheCommandObject.ToString());

        }

        public DbDataReader ExecuteReader(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return ExecuteReader(TheCommandObject.ToString(), TheParameters);

        }

        public DbDataReader ExecuteReaderParamsOnly(params object[] TheParameters)
        {

            return ExecuteReader(TheParameters);

        }

        public DbDataReader ExecuteReaderParams(string TheCommand, params object[] TheParameters)
        {

            return ExecuteReader(TheCommand, TheParameters);

        }

        public DbDataReader ExecuteReaderParams(object TheCommandObject, params object[] TheParameters)
        {

            return ExecuteReader(TheCommandObject, TheParameters);

        }

        public DbDataReader ExecuteReader(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            try
            {

                myCommand.CommandText = TheCommand;

                SetParameters(TheNamedParameters);

                return myCommand.ExecuteReader();

            }
            finally
            {

                ResetParameters();

            }

        }

        public DbDataReader ExecuteReader(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteReader(TheCommandObject, TheNamedParameters);

        }

        public DbDataReader ExecuteReader(string TheCommand, dynamic TheNamedParameters)
        {

            return ExecuteReader(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public DbDataReader ExecuteReader(object TheCommandObject, dynamic TheNamedParameters)
        {

            return ExecuteReader(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters);

        }

        public object ExecuteScalar()
        {

            return myCommand.ExecuteScalar();

        }

        public object ExecuteScalar(string TheCommand)
        {

            myCommand.CommandText = TheCommand;

            return myCommand.ExecuteScalar();

        }

        public object ExecuteScalar(object TheCommandObject)
        {

            myCommand.CommandText = TheCommandObject.ToString();

            return myCommand.ExecuteScalar();

        }

        public object ExecuteScalar(IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameterValues(TheParameters);

                return myCommand.ExecuteScalar();

            }
            finally
            {

                ResetParameters();

            }

        }

        public object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters)
        {

            try
            {

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return myCommand.ExecuteScalar();

            }
            finally
            {

                ResetParameters();

            }

        }

        public object ExecuteScalar(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return ExecuteScalar(TheCommandObject.ToString(), TheParameters);

        }

        public object ExecuteScalarParamsOnly(params object[] TheParameters)
        {

            return ExecuteScalar(TheParameters);

        }

        public object ExecuteScalarParams(string TheCommand, params object[] TheParameters)
        {

            return ExecuteScalar(TheCommand, TheParameters);

        }

        public object ExecuteScalarParams(object TheCommandObject, params object[] TheParameters)
        {

            return ExecuteScalar(TheCommandObject.ToString(), TheParameters);

        }

        public object ExecuteScalar(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteScalar(TheCommand, TheNamedParameters);

        }

        public object ExecuteScalar(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteScalar(TheCommandObject.ToString(), TheNamedParameters);

        }

        public object ExecuteScalar(string TheCommand, dynamic TheNamedParameters)
        {

            return ExecuteScalar(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public object ExecuteScalar(object TheCommandObject, dynamic TheNamedParameters)
        {

            return ExecuteScalar(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters);

        }

        public DataTable ExecuteDataTable()
        {

            return GetDataTable(myCommand.ExecuteReader());

        }

        public DataTable ExecuteDataTable(string TheCommand)
        {

            myCommand.CommandText = TheCommand;

            return GetDataTable(myCommand.ExecuteReader());

        }

        public DataTable ExecuteDataTable(IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameterValues(TheParameters);

                return GetDataTable(myCommand.ExecuteReader());

            }
            finally
            {
                
                ResetParameters();

            }

        }

        public DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters)
        {

            try
            {

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return GetDataTable(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public DataTable ExecuteDataTable(object TheCommandObject)
        {

            return ExecuteDataTable(TheCommandObject.ToString());

        }

        public DataTable ExecuteDataTable(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return ExecuteDataTable(TheCommandObject.ToString(), TheParameters);

        }

        public DataTable ExecuteDataTableParamsOnly(params object[] TheParameters)
        {

            return ExecuteDataTable(TheParameters);

        }

        public DataTable ExecuteDataTableParams(string TheCommand, params object[] TheParameters)
        {

            return ExecuteDataTable(TheCommand, TheParameters);

        }

        public DataTable ExecuteDataTableParams(object TheCommandObject, params object[] TheParameters)
        {

            return ExecuteDataTable(TheCommandObject.ToString(), TheParameters);

        }

        public DataTable ExecuteDataTable(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            try
            {

                SetParameters(TheNamedParameters);

                myCommand.CommandText = TheCommand;

                return GetDataTable(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public DataTable ExecuteDataTable(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteDataTable(TheCommandObject.ToString(), TheNamedParameters);

        }

        public DataTable ExecuteDataTable(string TheCommand, dynamic TheNamedParameters)
        {

            return ExecuteDataTable(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public DataTable ExecuteDataTable(object TheCommandObject, dynamic TheNamedParameters)
        {

            return ExecuteDataTable(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary()
        {

            return GetDictionaries(myCommand.ExecuteReader());

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand)
        {

            myCommand.CommandText = TheCommand;

            return GetDictionaries(myCommand.ExecuteReader());

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject)
        {

            return ExecuteDictionary(TheCommandObject.ToString());

        }

        public List<Dictionary<string, object>> ExecuteDictionary(IEnumerable<object> TheParameters)
        {

            return GetDictionaries(myCommand.ExecuteReader());

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, IEnumerable<object> TheParameters)
        {

            return GetDictionaries(myCommand.ExecuteReader());

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return ExecuteDictionary(TheCommandObject.ToString(), TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionaryParamsOnly(params object[] TheParameters)
        {

            return ExecuteDictionary(TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionaryParams(string TheCommand, params object[] TheParameters)
        {

            return ExecuteDictionary(TheCommand, TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionaryParams(object TheCommandObject, params object[] TheParameters)
        {

            return ExecuteDictionary(TheCommandObject.ToString(), TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            try
            {

                SetParameters(TheNamedParameters);

                myCommand.CommandText = TheCommand;

                return GetDictionaries(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteDictionary(TheCommandObject.ToString(), TheNamedParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, dynamic TheNamedParameters)
        {

            return ExecuteDictionary(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, dynamic TheNamedParameters)
        {

            return ExecuteDictionary(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters);

        }

        public void ExecuteDictionary(Action<Dictionary<string, object>> TheRowAction)
        {

            GetDictionaries(myCommand.ExecuteReader(), TheRowAction);

        }

        public void ExecuteDictionary(string TheCommand, Action<Dictionary<string, object>> TheRowAction)
        {

            myCommand.CommandText = TheCommand;

            GetDictionaries(myCommand.ExecuteReader());

        }

        public void ExecuteDictionary(object TheCommandObject, Action<Dictionary<string, object>> TheRowAction)
        {

            ExecuteDictionary(TheCommandObject.ToString(), TheRowAction);

        }

        public void ExecuteDictionary(IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            try
            {

                SetParameters(TheParameters);

                GetDictionaries(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public void ExecuteDictionary(string TheCommand, IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            try
            {

                SetParameters(TheParameters);

                myCommand.CommandText = TheCommand;
                
                GetDictionaries(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public void ExecuteDictionary(object TheCommandObject, IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            ExecuteDictionary(TheCommandObject.ToString(), TheParameters, TheRowAction);

        }

        public void ExecuteDictionaryParamsOnly(Action<IDictionary<string, object>> TheRowAction, object[] TheParameters)
        {

            ExecuteDictionary(TheParameters, TheRowAction);

        }

        public void ExecuteDictionaryParams(string TheCommand, Action<IDictionary<string, object>> TheRowAction, params object[] TheParameters)
        {

            ExecuteDictionary(TheCommand, TheParameters, TheRowAction);

        }

        public void ExecuteDictionaryParams(object TheCommandObject, Action<IDictionary<string, object>> TheRowAction, params object[] TheParameters)
        {

            ExecuteDictionary(TheCommandObject.ToString(), TheParameters, TheRowAction);

        }

        public void ExecuteDictionary(string TheCommand, IDictionary<string, object> TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            try
            {

                SetParameters(TheNamedParameters);

                myCommand.CommandText = TheCommand;

                GetDictionaries(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public void ExecuteDictionary(object TheCommandObject, IDictionary<string, object> TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            ExecuteDictionary(TheCommandObject.ToString(), TheNamedParameters, TheRowAction);

        }

        public void ExecuteDictionary(string TheCommand, dynamic TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            ExecuteDictionary(TheCommand, (IDictionary<string, object>)TheNamedParameters, TheRowAction);

        }

        public void ExecuteDictionary(object TheCommandObject, dynamic TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            ExecuteDictionary(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters, TheRowAction);

        }

        public List<dynamic> ExecuteDynamic()
        {

            return GetExpandoObjects(myCommand.ExecuteReader());

        }

        public List<dynamic> ExecuteDynamic(string TheCommand)
        {

            myCommand.CommandText = TheCommand;

            return GetExpandoObjects(myCommand.ExecuteReader());

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject)
        {

            return ExecuteDynamic(TheCommandObject.ToString());

        }

        public List<dynamic> ExecuteDynamic(IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameters(TheParameters);

                return GetExpandoObjects(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public List<dynamic> ExecuteDynamic(string TheCommand, IEnumerable<object> TheParameters)
        {

            try
            {

                SetParameters(TheParameters);

                myCommand.CommandText = TheCommand;

                return GetExpandoObjects(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return ExecuteDynamic(TheCommandObject.ToString(), TheParameters);

        }

        public List<dynamic> ExecuteDynamicParamsOnly(params object[] TheParameters)
        {

            return ExecuteDynamic(TheParameters);

        }

        public List<dynamic> ExecuteDynamicParams(string TheCommand, params object[] TheParameters)
        {

            return ExecuteDynamic(TheCommand, TheParameters);

        }

        public List<dynamic> ExecuteDynamicParams(object TheCommandObject, params object[] TheParameters)
        {

            return ExecuteDynamic(TheCommandObject.ToString(), TheParameters);

        }

        public List<dynamic> ExecuteDynamic(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            try
            {

                SetParameters(TheNamedParameters);

                myCommand.CommandText = TheCommand;

                return GetExpandoObjects(myCommand.ExecuteReader());

            }
            finally
            {

                ResetParameters();

            }

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return ExecuteDynamic(TheCommandObject.ToString(), TheNamedParameters);

        }

        public List<dynamic> ExecuteDynamic(string TheCommand, dynamic TheNamedParameters)
        {

            return ExecuteDynamic(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject, dynamic TheNamedParameters)
        {

            return ExecuteDynamic(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters);

        }

        public void ExecuteDynamic(Action<dynamic> TheRowAction)
        {

            GetExpandoObjects(myCommand.ExecuteReader(), TheRowAction);

        }

        public void ExecuteDynamic(string TheCommand, Action<dynamic> TheRowAction)
        {

            myCommand.CommandText = TheCommand;

            GetExpandoObjects(myCommand.ExecuteReader(), TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, Action<dynamic> TheRowAction)
        {

            ExecuteDynamic(TheCommandObject.ToString(), TheRowAction);

        }

        public void ExecuteDynamic(IEnumerable<object> TheParameters, Action<dynamic> TheRowAction)
        {

            try
            {

                SetParameters(TheParameters);

                GetExpandoObjects(myCommand.ExecuteReader(), TheRowAction);

            }
            finally
            {

                ResetParameters();

            }

        }

        public void ExecuteDynamic(string TheCommand, IEnumerable<object> TheParameters, Action<dynamic> TheRowAction)
        {

            try
            {

                SetParameters(TheParameters);

                myCommand.CommandText = TheCommand;

                GetExpandoObjects(myCommand.ExecuteReader(), TheRowAction);

            }
            finally
            {

                ResetParameters();

            }

        }

        public void ExecuteDynamic(object TheCommandObject, IEnumerable<object> TheParameters, Action<dynamic> TheRowAction)
        {

            ExecuteDynamic(TheCommandObject.ToString(), TheParameters, TheRowAction);

        }

        public void ExecuteDynamicParamsOnly(Action<dynamic> TheRowAction, object[] TheParameters)
        {

            ExecuteDynamic(TheParameters, TheRowAction);

        }

        public void ExecuteDynamicParams(string TheCommand, Action<dynamic> TheRowAction, params object[] TheParameters)
        {

            ExecuteDynamic(TheCommand, TheParameters, TheRowAction);

        }

        public void ExecuteDynamicParams(object TheCommandObject, Action<dynamic> TheRowAction, params object[] TheParameters)
        {

            ExecuteDynamic(TheCommandObject.ToString(), TheParameters, TheRowAction);

        }

        public void ExecuteDynamic(string TheCommand, IDictionary<string, object> TheNamedParameters, Action<dynamic> TheRowAction)
        {

            ExecuteDynamic(TheCommand, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, IDictionary<string, object> TheNamedParameters, Action<dynamic> TheRowAction)
        {

            ExecuteDynamic(TheCommandObject.ToString(), TheNamedParameters, TheRowAction);

        }

        public void ExecuteDynamic(string TheCommand, dynamic TheNamedParameters, Action<dynamic> TheRowAction)
        {

            ExecuteDynamic(TheCommand, (IDictionary<string, object>)TheNamedParameters, TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, dynamic TheNamedParameters, Action<dynamic> TheRowAction)
        {

            ExecuteDynamic(TheCommandObject.ToString(), (IDictionary<string, object>)TheNamedParameters, TheRowAction);

        }

        public void Dispose()
        {

            myCommand.Dispose();

        }

    }

}
