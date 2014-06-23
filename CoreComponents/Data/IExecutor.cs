using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
    
    public interface IExecutor : IDisposable
    {

        string ConnectionString
        {

            get;
            set;

        }

        string Database
        {

            get;
            set;

        }

        string DataSource
        {

            get;

        }

        string ServerVersion
        {

            get;

        }

        bool ConnectionIsActive
        {

            get;

        }

        bool TestConnection();

        bool TestConnection(out Exception TheException);

        bool TestConnection(out string TheMessage);

        ConnectionState ConnectionState
        {

            get;

        }

        bool IsActive
        {

            get;

        }

        int ConnectionTimeout
        {

            get;

        }

        int CommandTimeout
        {

            get;
            set;

        }

        void Prepare();

        CommandType CommandType
        {

            get;
            set;

        }

        string CommandText
        {

            get;
            set;

        }

        void SetCommandText(object TheCommandObject);

        IEnumerable<object> ParameterValues
        {

            get;
            set;

        }

        void ClearParameters();

        bool RetainParameters
        {

            get;
            set;

        }

        void SetParameters(IEnumerable<KeyValuePair<string, object>> TheParameters);

        void SetParameters(dynamic TheParameters);

        IEnumerable<KeyValuePair<string, object>> GetParameterNamesAndValues();

        void GetParameterNamesAndValuesInto(ref ICollection<KeyValuePair<string, object>> TheParameterSet);

        void GetParameterNamesAndValuesInto(ref IDictionary<string, object> TheParameterSet);

        bool HasParameterWithName(string TheName);

        bool HasParameterWithValue(string TheValue);

        object GetValueOfParameter(string TheName);

        bool TryGetValueOfParameter(string TheName, out object TheValue);

        bool HasParameters
        {

            get;

        }
        
        void Open();

        void Close();

        int ExecuteNonQuery();

        int ExecuteNonQuery(string TheCommand);

        int ExecuteNonQuery(object TheCommandObject);

        int ExecuteNonQuery(IEnumerable<object> TheParameters);

        int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters);

        int ExecuteNonQuery(object TheCommandObject, IEnumerable<object> TheParameters);

        int ExecuteNonQueryParamsOnly(params object[] TheParameters);

        int ExecuteNonQueryParams(string TheCommand, params object[] TheParameters);

        int ExecuteNonQueryParams(object TheCommandObject, params object[] TheParameters);

        int ExecuteNonQuery(string TheCommand, IDictionary<string, object> TheNamedParameters);

        int ExecuteNonQuery(object TheCommandObject, IDictionary<string, object> TheNamedParameters);

        int ExecuteNonQuery(string TheCommand, dynamic TheNamedParameters);

        int ExecuteNonQuery(object TheCommandObject, dynamic TheNamedParameters);

        DbDataReader ExecuteReader();

        DbDataReader ExecuteReader(string TheCommand);

        DbDataReader ExecuteReader(object TheCommandObject);

        DbDataReader ExecuteReader(IEnumerable<object> TheParameters);

        DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters);

        DbDataReader ExecuteReader(object TheCommandObject, IEnumerable<object> TheParameters);

        DbDataReader ExecuteReaderParamsOnly(params object[] TheParameters);

        DbDataReader ExecuteReaderParams(string TheCommand, params object[] TheParameters);

        DbDataReader ExecuteReaderParams(object TheCommandObject, params object[] TheParameters);

        DbDataReader ExecuteReader(string TheCommand, IDictionary<string, object> TheNamedParameters);

        DbDataReader ExecuteReader(object TheCommandObject, IDictionary<string, object> TheNamedParameters);

        DbDataReader ExecuteReader(string TheCommand, dynamic TheNamedParameters);

        DbDataReader ExecuteReader(object TheCommandObject, dynamic TheNamedParameters);

        object ExecuteScalar();

        object ExecuteScalar(string TheCommand);

        object ExecuteScalar(object TheCommandObject);

        object ExecuteScalar(IEnumerable<object> TheParameters);

        object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters);

        object ExecuteScalar(object TheCommandObject, IEnumerable<object> TheParameters);

        object ExecuteScalarParamsOnly(params object[] TheParameters);

        object ExecuteScalarParams(string TheCommand, params object[] TheParameters);

        object ExecuteScalarParams(object TheCommandObject, params object[] TheParameters);

        object ExecuteScalar(string TheCommand, IDictionary<string, object> TheNamedParameters);

        object ExecuteScalar(object TheCommandObject, IDictionary<string, object> TheNamedParameters);

        object ExecuteScalar(string TheCommand, dynamic TheNamedParameters);

        object ExecuteScalar(object TheCommandObject, dynamic TheNamedParameters);

        DataTable ExecuteDataTable();

        DataTable ExecuteDataTable(string TheCommand);

        DataTable ExecuteDataTable(object TheCommandObject);

        DataTable ExecuteDataTable(IEnumerable<object> TheParameters);

        DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters);

        DataTable ExecuteDataTable(object TheCommandObject, IEnumerable<object> TheParameters);

        DataTable ExecuteDataTableParamsOnly(params object[] TheParameters);

        DataTable ExecuteDataTableParams(string TheCommand, params object[] TheParameters);

        DataTable ExecuteDataTableParams(object TheCommandObject, params object[] TheParameters);

        DataTable ExecuteDataTable(string TheCommand, IDictionary<string, object> TheNamedParameters);

        DataTable ExecuteDataTable(object TheCommandObject, IDictionary<string, object> TheNamedParameters);

        DataTable ExecuteDataTable(string TheCommand, dynamic TheNamedParameters);

        DataTable ExecuteDataTable(object TheCommandObject, dynamic TheNamedParameters);

        List<Dictionary<string, object>> ExecuteDictionary();

        List<Dictionary<string, object>> ExecuteDictionary(string TheCommand);

        List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject);

        List<Dictionary<string, object>> ExecuteDictionary(IEnumerable<object> TheParameters);

        List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, IEnumerable<object> TheParameters);

        List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, IEnumerable<object> TheParameters);

        List<Dictionary<string, object>> ExecuteDictionaryParamsOnly(params object[] TheParameters);

        List<Dictionary<string, object>> ExecuteDictionaryParams(string TheCommand, params object[] TheParameters);

        List<Dictionary<string, object>> ExecuteDictionaryParams(object TheCommandObject, params object[] TheParameters);

        List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, IDictionary<string, object> TheNamedParameters);

        List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, IDictionary<string, object> TheNamedParameters);

        List<Dictionary<string, object>> ExecuteDictionary(string TheCommand, dynamic TheNamedParameters);

        List<Dictionary<string, object>> ExecuteDictionary(object TheCommandObject, dynamic TheNamedParameters);

        void ExecuteDictionary(Action<Dictionary<string, object>> TheRowAction);

        void ExecuteDictionary(string TheCommand, Action<Dictionary<string, object>> TheRowAction);

        void ExecuteDictionary(object TheCommandObject, Action<Dictionary<string, object>> TheRowAction);

        void ExecuteDictionary(IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction);

        void ExecuteDictionary(string TheCommand, IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction);

        void ExecuteDictionary(object TheCommandObject, IEnumerable<object> TheParameters, Action<IDictionary<string, object>> TheRowAction);

        void ExecuteDictionaryParamsOnly(Action<IDictionary<string, object>> TheRowAction, object[] TheParameters);

        void ExecuteDictionaryParams(string TheCommand, Action<IDictionary<string, object>> TheRowAction, params object[] TheParameters);

        void ExecuteDictionaryParams(object TheCommandObject, Action<IDictionary<string, object>> TheRowAction, params object[] TheParameters);

        void ExecuteDictionary(string TheCommand, IDictionary<string, object> TheNamedParameters, Action<IDictionary<string, object>> TheRowAction);

        void ExecuteDictionary(object TheCommandObject, IDictionary<string, object> TheNamedParameters, Action<IDictionary<string, object>> TheRowAction);

        void ExecuteDictionary(string TheCommand, dynamic TheNamedParameters, Action<IDictionary<string, object>> TheRowAction);

        void ExecuteDictionary(object TheCommandObject, dynamic TheNamedParameters, Action<IDictionary<string, object>> TheRowAction);

        List<dynamic> ExecuteDynamic();

        List<dynamic> ExecuteDynamic(string TheCommand);

        List<dynamic> ExecuteDynamic(object TheCommandObject);

        List<dynamic> ExecuteDynamic(IEnumerable<object> TheParameters);

        List<dynamic> ExecuteDynamic(string TheCommand, IEnumerable<object> TheParameters);

        List<dynamic> ExecuteDynamic(object TheCommandObject, IEnumerable<object> TheParameters);

        List<dynamic> ExecuteDynamicParamsOnly(params object[] TheParameters);

        List<dynamic> ExecuteDynamicParams(string TheCommand, params object[] TheParameters);

        List<dynamic> ExecuteDynamicParams(object TheCommandObject, params object[] TheParameters);

        List<dynamic> ExecuteDynamic(string TheCommand, IDictionary<string, object> TheNamedParameters);

        List<dynamic> ExecuteDynamic(object TheCommandObject, IDictionary<string, object> TheNamedParameters);

        List<dynamic> ExecuteDynamic(string TheCommand, dynamic TheNamedParameters);

        List<dynamic> ExecuteDynamic(object TheCommandObject, dynamic TheNamedParameters);

        void ExecuteDynamic(Action<dynamic> TheRowAction);

        void ExecuteDynamic(string TheCommand, Action<dynamic> TheRowAction);

        void ExecuteDynamic(object TheCommandObject, Action<dynamic> TheRowAction);

        void ExecuteDynamic(IEnumerable<object> TheParameters, Action<dynamic> TheRowAction);

        void ExecuteDynamic(string TheCommand, IEnumerable<object> TheParameters, Action<dynamic> TheRowAction);

        void ExecuteDynamic(object TheCommandObject, IEnumerable<object> TheParameters, Action<dynamic> TheRowAction);

        void ExecuteDynamicParamsOnly(Action<dynamic> TheRowAction, object[] TheParameters);

        void ExecuteDynamicParams(string TheCommand, Action<dynamic> TheRowAction, params object[] TheParameters);

        void ExecuteDynamicParams(object TheCommandObject, Action<dynamic> TheRowAction, params object[] TheParameters);

        void ExecuteDynamic(string TheCommand, IDictionary<string, object> TheNamedParameters, Action<dynamic> TheRowAction);

        void ExecuteDynamic(object TheCommandObject, IDictionary<string, object> TheNamedParameters, Action<dynamic> TheRowAction);

        void ExecuteDynamic(string TheCommand, dynamic TheNamedParameters, Action<dynamic> TheRowAction);

        void ExecuteDynamic(object TheCommandObject, dynamic TheNamedParameters, Action<dynamic> TheRowAction);
        
    }

}
