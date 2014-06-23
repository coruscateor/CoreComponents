using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace CoreComponents.Data
{

    public class ConnectionAndCommandManager<TConnection, TCommand, TParameter, TTransaction> : IConnectionAndCommandManager
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TTransaction : DbTransaction
    {

        protected ConnectionType myConnectionType = ConnectionType.QuickDiscrete;

        protected IExecutor myCurrentExecutor;

        protected QuickDiscreteExecutor<TConnection, TCommand, TParameter, TTransaction> myQuickDiscreteExecutor;

        protected DiscreteExecutor<TConnection, TCommand, TParameter, TTransaction> myDiscreteExecutor;

        protected TransactionalExecutor<TConnection, TCommand, TParameter, TTransaction> myTransactionExecutor;

        public ConnectionAndCommandManager()
        {

            Initalise();

        }

        public ConnectionAndCommandManager(string TheConnectionString)
        {

            Initalise(TheConnectionString);

        }

        public ConnectionAndCommandManager(ConnectionType TheConnectionType)
        {

            myConnectionType = TheConnectionType;

            Initalise();

        }

        public ConnectionAndCommandManager(string TheConnectionString, ConnectionType TheConnectionType)
        {

            myConnectionType = TheConnectionType;

            Initalise();

        }

        protected void Initalise(string TheConnectionString = "")
        {

            TCommand Command = new TCommand();

            Command.Connection = new TConnection();

            if(TheConnectionString.Length > 0)
                Command.Connection.ConnectionString = TheConnectionString;

            myQuickDiscreteExecutor = new QuickDiscreteExecutor<TConnection, TCommand, TParameter, TTransaction>(Command);

            myDiscreteExecutor = new DiscreteExecutor<TConnection, TCommand, TParameter, TTransaction>(Command);

            myTransactionExecutor = new TransactionalExecutor<TConnection, TCommand, TParameter, TTransaction>(Command);

            myCurrentExecutor = myQuickDiscreteExecutor;

        }

        public ConnectionType ConnectionType
        {

            get
            {

                return myConnectionType;

            }
            set
            {

                if(myConnectionType != value && !myCurrentExecutor.IsActive)
                {

                    myConnectionType = value;

                    SetConnectionExecutor();

                }

            }

        }

        protected void SetConnectionExecutor()
        {

            switch(myConnectionType)
            {

                case ConnectionType.Discrete:

                    if(myCurrentExecutor == myDiscreteExecutor)
                        return;
                    else if(myCurrentExecutor == myTransactionExecutor && myTransactionExecutor.IsActive)
                        myTransactionExecutor.EndTransaction();

                    CheckExecutor(myDiscreteExecutor);

                    myCurrentExecutor = myDiscreteExecutor;

                    break;
                case ConnectionType.QuickDiscrete:

                    if(myCurrentExecutor == myQuickDiscreteExecutor)
                        return;
                    else if(myCurrentExecutor == myTransactionExecutor && myCurrentExecutor == myDiscreteExecutor)
                        myCurrentExecutor.Close();

                    CheckExecutor(myDiscreteExecutor);

                    myCurrentExecutor = myDiscreteExecutor;

                    break;
                case ConnectionType.Transactional:

                    if(myCurrentExecutor == myTransactionExecutor)
                        return;
                    else if(myCurrentExecutor == myDiscreteExecutor && myDiscreteExecutor.IsActive)
                        myTransactionExecutor.BeginTransaction();

                    CheckExecutor(myTransactionExecutor);

                    myCurrentExecutor = myTransactionExecutor;

                    break;

            }

        }

        protected void CheckExecutor(IExecutor TheExecutor)
        {

            if(TheExecutor.RetainParameters != myQuickDiscreteExecutor.RetainParameters)
                TheExecutor.RetainParameters = myQuickDiscreteExecutor.RetainParameters;

        }

        public string ConnectionString
        {

            get
            {

                return myCurrentExecutor.ConnectionString;

            }
            set
            {

                myCurrentExecutor.ConnectionString = value;

            }

        }

        public string Database
        {

            get
            {

                return myCurrentExecutor.Database;

            }
            set
            {

                myCurrentExecutor.Database = value;

            }

        }

        public string DataSource
        {

            get
            {

                return myCurrentExecutor.DataSource;

            }

        }

        public string ServerVersion
        {

            get
            {

                return myCurrentExecutor.ServerVersion;

            }

        }

        public ConnectionState ConnectionState
        {

            get
            {

                return myCurrentExecutor.ConnectionState;

            }

        }

        public bool IsActive
        {

            get
            {

                return myCurrentExecutor.IsActive;

            }

        }

        public bool ConnectionIsActive
        {

            get
            {

                return myCurrentExecutor.ConnectionIsActive;

            }

        }

        public bool ConnectionIsHeldOpen
        {

            get
            {

                return myConnectionType != ConnectionType.QuickDiscrete;

            }

        }

        public IsolationLevel IsolationLevel
        {

            get
            {

                return myTransactionExecutor.IsolationLevel;

            }
            set
            {

                myTransactionExecutor.IsolationLevel = value;

            }

        }

        public TransactionAction TransactionAction
        {

            get
            {

                return myTransactionExecutor.TransactionAction;

            }
            set
            {

                myTransactionExecutor.TransactionAction = value;

            }

        }

        public void Prepare()
        {

            myCurrentExecutor.Prepare();

        }

        public IEnumerable<object> ParameterValues
        {

            get
            {

                return myCurrentExecutor.ParameterValues;

            }
            set
            {

                myCurrentExecutor.ParameterValues = value;

            }

        }

        public void ClearParameters()
        {
            
            myCurrentExecutor.ClearParameters();

        }

        public bool RetainParameters
        {

            get
            {
                
                return myCurrentExecutor.RetainParameters;

            }
            set
            {

                myCurrentExecutor.RetainParameters = value;

            }

        }

        public void SetParameters(IEnumerable<KeyValuePair<string, object>> TheParameters)
        {

            myCurrentExecutor.SetParameters(TheParameters);

        }

        public void SetParameters(dynamic TheParameters)
        {

            myCurrentExecutor.SetParameters(TheParameters);

        }

        public IEnumerable<KeyValuePair<string, object>> GetParameterNamesAndValues()
        {

            return myCurrentExecutor.GetParameterNamesAndValues();

        }

        public void GetParameterNamesAndValuesInto(ref ICollection<KeyValuePair<string, object>> TheParameterSet)
        {

            myCurrentExecutor.GetParameterNamesAndValuesInto(ref TheParameterSet);

        }

        public void GetParameterNamesAndValuesInto(ref IDictionary<string, object> TheParameterSet)
        {

            myCurrentExecutor.GetParameterNamesAndValuesInto(ref TheParameterSet);

        }

        public bool HasParameterWithName(string TheName)
        {

            return myCurrentExecutor.HasParameterWithName(TheName);

        }

        public bool HasParameterWithValue(string TheValue)
        {

            return myCurrentExecutor.HasParameterWithValue(TheValue);

        }

        public object GetValueOfParameter(string TheName)
        {

            return myCurrentExecutor.GetValueOfParameter(TheName);

        }

        public bool TryGetValueOfParameter(string TheName, out object TheValue)
        {

            return myCurrentExecutor.TryGetValueOfParameter(TheName, out TheValue);

        }

        public bool HasParameters
        {

            get
            {

                return myCurrentExecutor.HasParameters;

            }

        }

        public void Open()
        {

            myCurrentExecutor.Open();

        }

        public void Close()
        {

            myCurrentExecutor.Close();

        }

        public bool TestConnection()
        {

            return myCurrentExecutor.TestConnection();

        }

        public bool TestConnection(out Exception TheException)
        {

            return myCurrentExecutor.TestConnection(out TheException);

        }

        public bool TestConnection(out string TheMessage)
        {

            return myCurrentExecutor.TestConnection(out TheMessage);

        }

        public int ConnectionTimeout
        {

            get
            {

                return myCurrentExecutor.ConnectionTimeout;

            }

        }

        public int CommandTimeout
        {

            get
            {

                return myCurrentExecutor.CommandTimeout;

            }
            set
            {

                myCurrentExecutor.CommandTimeout = value;

            }

        }

        public CommandType CommandType
        {

            get
            {

                return myCurrentExecutor.CommandType;

            }
            set
            {

                myCurrentExecutor.CommandType = value;

            }

        }

        public string CommandText
        {

            get
            {

                return myCurrentExecutor.CommandText;

            }
            set
            {

                myCurrentExecutor.CommandText = value;

            }

        }

        public void SetCommandText(object TheCommandObject)
        {

            myCurrentExecutor.CommandText = TheCommandObject.ToString();

        }

        public int ExecuteNonQuery()
        {

            return myCurrentExecutor.ExecuteNonQuery();

        }

        public int ExecuteNonQuery(string TheCommand)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommand);

        }

        public int ExecuteNonQuery(object TheCommandObject)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommandObject.ToString());

        }

        public int ExecuteNonQuery(IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheParameters);

        }

        //public int ExecuteNonQuery(IEnumerable<KeyValuePair<string, object>> TheParameters)
        //{

        //    //return myExecuteNonQueryParameters(TheCommandObject.ToString(), TheParameters);

        //    return 0;

        //}

        public int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommand, TheParameters);

        }

        //public int ExecuteNonQuery(string TheCommand, IEnumerable<KeyValuePair<string, object>> TheParameters)
        //{

        //    //return myExecuteNonQueryParameters(TheCommandObject.ToString(), TheParameters);

        //    return 0;

        //}

        public int ExecuteNonQuery(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommandObject.ToString(), TheParameters);

        }

        //public int ExecuteNonQuery(Object TheCommandObject, IEnumerable<KeyValuePair<string, object>> TheParameters)
        //{

        //    //return myExecuteNonQueryParameters(TheCommandObject.ToString(), TheParameters);

        //    return 0;

        //}

        //-- Talking Params Arrays

        public int ExecuteNonQueryParamsOnly(params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheParameters);

        }

        public int ExecuteNonQueryParams(string TheCommand, params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheParameters);

        }

        public int ExecuteNonQueryParams(object TheCommandObject, params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommandObject.ToString(), TheParameters);

        }

        //public int ExecuteNonQueryParams(Object TheCommandObject, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteNonQueryParameters(TheCommandObject.ToString(), TheParameters);

        //}

        public int ExecuteNonQuery(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommand, TheNamedParameters);
            
        }

        public int ExecuteNonQuery(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommandObject, TheNamedParameters);

        }

        public int ExecuteNonQuery(string TheCommand, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommand, (IDictionary<string, object>)TheNamedParameters);

        }

        public int ExecuteNonQuery(object TheCommandObject, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteNonQuery(TheCommandObject, (IDictionary<string, object>)TheNamedParameters);

        }

        public DbDataReader ExecuteReader()
        {

            return myCurrentExecutor.ExecuteReader();

        }

        public DbDataReader ExecuteReader(string TheCommand)
        {

            return myCurrentExecutor.ExecuteReader(TheCommand);

        }

        public DbDataReader ExecuteReader(object TheCommandObject)
        {

            return myCurrentExecutor.ExecuteReader(TheCommandObject.ToString());

        }

        public DbDataReader ExecuteReader(IEnumerable<object> TheParameters)
        {

            //return myExecuteReaderParametersOnly(TheParameters);

            return myCurrentExecutor.ExecuteReader(TheParameters);

        }

        public DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters)
        {

            //return myExecuteReaderParameters(TheCommand, TheParameters);

            return myCurrentExecutor.ExecuteReader(TheParameters);

        }

        public DbDataReader ExecuteReader(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            //return myExecuteReaderParameters(TheCommandObject.ToString(), TheParameters);

            return myCurrentExecutor.ExecuteReader(TheCommandObject.ToString(), TheParameters);

        }

        //public DbDataReader ExecuteReader(Object TheCommandObject, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheCommandObject.ToString(), TheParameters);

        //}

        //-- Talking Params Arrays

        public DbDataReader ExecuteReaderParamsOnly(params object[] TheParameters)
        {

            //return myExecuteReaderParametersOnly(TheParameters);

            return myCurrentExecutor.ExecuteReader(TheParameters);

        }

        //public DbDataReader ExecuteReaderParams(params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheParameters);

        //}

        public DbDataReader ExecuteReaderParams(string TheCommand, params object[] TheParameters)
        {

            //return myExecuteReaderParameters(TheCommand, TheParameters);

            return myCurrentExecutor.ExecuteReader(TheCommand, TheParameters);

        }

        //public DbDataReader ExecuteReaderParams(string TheCommand, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheCommand, TheParameters);

        //}

        public DbDataReader ExecuteReaderParams(object TheCommandObject, params object[] TheParameters)
        {

            //return myExecuteReaderParameters(TheCommandObject.ToString(), TheParameters);

            return myCurrentExecutor.ExecuteReader(TheCommandObject.ToString(), TheParameters);

        }

        //public DbDataReader ExecuteReaderParams(Object TheCommandObject, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheCommandObject.ToString(), TheParameters);

        //}

        //--

        public DbDataReader ExecuteReader(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteReader(TheCommand, TheNamedParameters);

        }

        public DbDataReader ExecuteReader(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteReader(TheCommandObject, TheNamedParameters);

        }

        public DbDataReader ExecuteReader(string TheCommand, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteReader(TheCommand, TheNamedParameters);

        }

        public DbDataReader ExecuteReader(object TheCommandObject, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteReader(TheCommandObject, TheNamedParameters);

        }

        public object ExecuteScalar()
        {

            return myCurrentExecutor.ExecuteScalar();

        }

        public object ExecuteScalar(string TheCommand)
        {

            return myCurrentExecutor.ExecuteScalar(TheCommand);

        }

        public object ExecuteScalar(object TheCommandObject)
        {

            return myCurrentExecutor.ExecuteScalar(TheCommandObject.ToString());

        }

        public object ExecuteScalar(IEnumerable<object> TheParameters)
        {

            //return myExecuteScalarParametersOnly(TheParameters);

            return myCurrentExecutor.ExecuteScalar(TheParameters);

        }

        public object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters)
        {

            //return myExecuteScalarParameters(TheCommand, TheParameters);

            return myCurrentExecutor.ExecuteScalar(TheCommand, TheParameters);

        }

        //public object ExecuteScalar(string TheCommand, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteScalarParameters(TheCommand, TheParameters);

        //}

        public object ExecuteScalar(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            //return myExecuteScalarParameters(TheCommandObject.ToString(), TheParameters);

            return myCurrentExecutor.ExecuteScalar(TheCommandObject.ToString(), TheParameters);

        }

        //public object ExecuteScalar(Object TheCommandObject, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteScalarParameters(TheCommandObject.ToString(), TheParameters);

        //}

        //-- Talking Params Arrays

        public object ExecuteScalarParamsOnly(params object[] TheParameters)
        {

            //return myExecuteScalarParametersOnly(TheParameters);

            return myCurrentExecutor.ExecuteScalar(TheParameters);

        }

        public object ExecuteScalarParams(string TheCommand, params object[] TheParameters)
        {

            //return myExecuteScalarParameters(TheCommand, TheParameters);

            return myCurrentExecutor.ExecuteScalar(TheCommand, TheParameters);

        }

        public object ExecuteScalarParams(object TheCommandObject, params object[] TheParameters)
        {

            //return myExecuteScalarParameters(TheCommandObject.ToString(), TheParameters);

            return myCurrentExecutor.ExecuteScalar(TheCommandObject.ToString(), TheParameters);

        }

        //public object ExecuteScalarParams(Object TheCommandObject, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteScalarParameters(TheCommandObject.ToString(), TheParameters);

        //}

        //--

        public object ExecuteScalar(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteScalar(TheCommand, TheNamedParameters);

        }

        public object ExecuteScalar(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteScalar(TheCommandObject, TheNamedParameters);

        }

        public object ExecuteScalar(string TheCommand, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteScalar(TheCommand, TheNamedParameters);

        }

        public object ExecuteScalar(object TheCommandObject, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteScalar(TheCommandObject, TheNamedParameters);

        }

        public DataTable ExecuteDataTable()
        {

            return myCurrentExecutor.ExecuteDataTable();

        }

        public DataTable ExecuteDataTable(string TheCommand)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommand);

        }

        public DataTable ExecuteDataTable(object TheCommandObject)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommandObject.ToString());

        }

        public DataTable ExecuteDataTable(IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheParameters);

        }

        public DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommand, TheParameters);

        }

        public DataTable ExecuteDataTable(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommandObject.ToString(), TheParameters);

        }

        //-- Talking Params Arrays

        public DataTable ExecuteDataTableParamsOnly(params object[] TheParameters)
        {

            //return myExecuteDataTableParametersOnly(TheParameters);

            return myCurrentExecutor.ExecuteDataTable(TheParameters);

        }

        public DataTable ExecuteDataTableParams(string TheCommand, params object[] TheParameters)
        {

            //return myExecuteDataTableParameters(TheCommand, TheParameters);

            return myCurrentExecutor.ExecuteDataTable(TheCommand, TheParameters);

        }

        public DataTable ExecuteDataTableParams(object TheCommandObject, params object[] TheParameters)
        {

            //return myExecuteDataTableParameters(TheCommandObject.ToString(), TheParameters);

            return myCurrentExecutor.ExecuteDataTable(TheCommandObject.ToString(), TheParameters);

        }

        public DataTable ExecuteDataTable(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommand, TheNamedParameters);

        }

        public DataTable ExecuteDataTable(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommandObject, TheNamedParameters);

        }

        public DataTable ExecuteDataTable(string TheCommand, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommand, TheNamedParameters);

        }

        public DataTable ExecuteDataTable(object TheCommandObject, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDataTable(TheCommandObject, TheNamedParameters);

        }

        public List<dynamic> ExecuteDynamic()
        {

            return myCurrentExecutor.ExecuteDynamic();

        }

        public List<dynamic> ExecuteDynamic(string TheCommand)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommand);

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommandObject);

        }

        public List<dynamic> ExecuteDynamic(IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheParameters);

        }

        public List<dynamic> ExecuteDynamic(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommand, TheParameters);

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheParameters);

        }

        public List<dynamic> ExecuteDynamicParamsOnly(params object[] TheParameters)
        {
            
            return myCurrentExecutor.ExecuteDynamic(TheParameters);

        }

        public List<dynamic> ExecuteDynamicParams(string TheCommand, params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommand, TheParameters);

        }

        public List<dynamic> ExecuteDynamicParams(object TheCommandObject, params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheParameters);

        }

        public List<dynamic> ExecuteDynamic(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommand, TheNamedParameters);

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheNamedParameters);

        }

        public List<dynamic> ExecuteDynamic(string TheCommand, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommand, TheNamedParameters);

        }

        public List<dynamic> ExecuteDynamic(object TheCommandObject, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheNamedParameters);

        }

        public void ExecuteDynamic(Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheRowAction);

        }

        public void ExecuteDynamic(string TheCommand, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommand, TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheRowAction);

        }

        public void ExecuteDynamic(IEnumerable<object> TheParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheParameters, TheRowAction);

        }

        public void ExecuteDynamic(string TheCommand, IEnumerable<object> TheParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommand, TheParameters, TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, IEnumerable<object> TheParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheParameters, TheRowAction);

        }

        public void ExecuteDynamicParamsOnly(Action<dynamic> TheRowAction, params object[] TheParameters)
        {

            myCurrentExecutor.ExecuteDynamicParamsOnly(TheRowAction, TheRowAction);

        }

        public void ExecuteDynamicParams(string TheCommand, Action<dynamic> TheRowAction, params object[] TheParameters)
        {

            myCurrentExecutor.ExecuteDynamicParams(TheCommand, TheRowAction, TheParameters);

        }

        public void ExecuteDynamicParams(object TheCommandObject, Action<dynamic> TheRowAction, params object[] TheParameters)
        {

            myCurrentExecutor.ExecuteDynamicParams(TheCommandObject, TheRowAction, TheParameters);

        }

        public void ExecuteDynamic(string TheCommand, IDictionary<string, object> TheNamedParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommand, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, IDictionary<string, object> TheNamedParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDynamic(string TheCommand, dynamic TheNamedParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommand, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDynamic(object TheCommandObject, dynamic TheNamedParameters, Action<dynamic> TheRowAction)
        {

            myCurrentExecutor.ExecuteDynamic(TheCommandObject, TheNamedParameters, TheRowAction);

        }

        public List<Dictionary<string, object>> ExecuteDictionary()
        {

            return myCurrentExecutor.ExecuteDictionary();

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommand);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommandObject);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommand, TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, IEnumerable<object> TheParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionaryParamsOnly(params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionaryParams(string TheCommand, params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommand, TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionaryParams(object TheCommandObject, params object[] TheParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommand, TheNamedParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, IDictionary<string, object> TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheNamedParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommand, TheNamedParameters);

        }

        public List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, dynamic TheNamedParameters)
        {

            return myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheNamedParameters);

        }

        public void ExecuteDictionary(Action<Dictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheRowAction);

        }

        public void ExecuteDictionary(string TheCommand, Action<Dictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommand, TheRowAction);

        }

        public void ExecuteDictionary(object TheCommandObject, Action<Dictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheRowAction);

        }

        public void ExecuteDictionary(IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheParameters, TheRowAction);

        }

        public void ExecuteDictionary(string TheCommand, IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommand, TheParameters, TheRowAction);

        }

        public void ExecuteDictionary(object TheCommandObject, IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheParameters, TheRowAction);

        }

        public void ExecuteDictionaryParamsOnly(Action<IDictionary<string, object>> TheRowAction, object[] TheParameters)
        {

            myCurrentExecutor.ExecuteDictionaryParamsOnly(TheRowAction, TheParameters);

        }

        public void ExecuteDictionaryParams(string TheCommand, Action<IDictionary<string, object>> TheRowAction, params object[] TheParameters)
        {

            myCurrentExecutor.ExecuteDictionaryParams(TheCommand, TheRowAction, TheParameters);

        }

        public void ExecuteDictionaryParams(object TheCommandObject, Action<IDictionary<string, object>> TheRowAction, params object[] TheParameters)
        {

            myCurrentExecutor.ExecuteDictionaryParams(TheCommandObject, TheRowAction, TheParameters);

        }

        public void ExecuteDictionary(string TheCommand, IDictionary<string, object> TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommand, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDictionary(object TheCommandObject, IDictionary<string, object> TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDictionary(string TheCommand, dynamic TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommand, TheNamedParameters, TheRowAction);

        }

        public void ExecuteDictionary(object TheCommandObject, dynamic TheNamedParameters, Action<IDictionary<string, object>> TheRowAction)
        {

            myCurrentExecutor.ExecuteDictionary(TheCommandObject, TheNamedParameters, TheRowAction);

        }

        public void Dispose()
        {

            myCurrentExecutor.Dispose();

        }
        
    }

}