using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace CoreComponents.Data
{

    public interface IConnectionAndCommandManager : IDisposable
    {

        event Action<ErrorEventArgs> Error;

        void Open();

        void Close();

        ConnectionType ConnectionType
        {

            get;
            set;

        }

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

        ConnectionState ConnectionState
        {

            get;

        }

        bool IsActive
        {

            get;

        }

        bool ConnectionIsActive
        {

            get;

        }

        bool TestConnection();

        bool TestConnectionGetError();

        string TestConnectionVerbose(bool RecordStackTrace = false);

        string TestConnectionVerboseAndGetError(bool RecordStackTrace = false);

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

        IsolationLevel IsolationLevel
        {

            get;
            set;

        }

        TransactionAction TransactionAction
        {

            get;
            set;

        }

        string CommandText
        {

            get;
            set;

        }

        void SetCommandText(StringBuilder SB);

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

        void SetParameterValues(IEnumerable<object> TheParameters);

        void SetParameterValuesParams(params object[] TheParameters);

        void SetParameterNamesAndValues(IEnumerable<KeyValuePair<string, object>> TheParameters);

        void SetParameterNamesAndValuesParams(params KeyValuePair<string, object>[] TheParameters);

        IEnumerable<KeyValuePair<string, object>> GetParameterNamesAndValues();

        void GetParameterNamesAndValuesInto(ICollection<KeyValuePair<string, object>> TheParameterSet);

        void GetParameterNamesAndValuesInto(IDictionary<string, object> TheParameterSet);

        bool HasParameterWithName(string TheName);

        bool HasParameterWithValue(string TheValue);

        object GetValueOfParameter(string TheName);

        bool HasParameters
        {

            get;

        }

        int ExecuteNonQuery();

        int ExecuteNonQuery(Stopwatch TheStopWatch);

        int ExecuteNonQuery(string TheCommand);

        int ExecuteNonQuery(string TheCommand, Stopwatch TheStopWatch);

        int ExecuteNonQuery(StringBuilder TheCommandStringBuilder);

        int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch);

        int ExecuteNonQuery(IEnumerable<object> TheParameters);

        int ExecuteNonQuery(IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters);

        int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters);

        int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        int ExecuteNonQueryParamsOnly(params object[] TheParameters);

        int ExecuteNonQueryTimedParamsOnly(Stopwatch TheStopWatch, params object[] TheParameters);

        int ExecuteNonQueryParams(string TheCommand, params object[] TheParameters);

        int ExecuteNonQueryTimedParams(string TheCommand, Stopwatch TheStopWatch, params object[] TheParameters);

        int ExecuteNonQueryParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters);

        int ExecuteNonQueryTimedParams(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch, params object[] TheParameters);

        DbDataReader ExecuteReader();

        DbDataReader ExecuteReader(Stopwatch TheStopWatch);

        DbDataReader ExecuteReader(string TheCommand);

        DbDataReader ExecuteReader(string TheCommand, Stopwatch TheStopWatch);

        DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder);

        DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch);

        DbDataReader ExecuteReader(IEnumerable<object> TheParameters);

        DbDataReader ExecuteReader(IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters);

        DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters);

        DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        DbDataReader ExecuteReaderParamsOnly(params object[] TheParameters);

        DbDataReader ExecuteReaderParams(string TheCommand, params object[] TheParameters);

        DbDataReader ExecuteReaderTimedParams(Stopwatch TheStopWatch, string TheCommand, params object[] TheParameters);

        DbDataReader ExecuteReaderParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters);

        DbDataReader ExecuteReaderTimedParams(Stopwatch TheStopWatch, StringBuilder TheCommandStringBuilder, params object[] TheParameters);

        object ExecuteScalar();

        object ExecuteScalar(Stopwatch TheStopWatch);

        object ExecuteScalar(string TheCommand);

        object ExecuteScalar(string TheCommand, Stopwatch TheStopWatch);

        object ExecuteScalar(StringBuilder TheCommandStringBuilder);

        object ExecuteScalar(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch);

        object ExecuteScalar(IEnumerable<object> TheParameters);

        object ExecuteScalar(IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters);

        object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        object ExecuteScalar(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters);

        object ExecuteScalar(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        object ExecuteScalarParamsOnly(params object[] TheParameters);

        object ExecuteScalarTimedParamsOnly(Stopwatch TheStopWatch, params object[] TheParameters);

        object ExecuteScalarParams(string TheCommand, params object[] TheParameters);

        object ExecuteScalarTimedParamsOnly(Stopwatch TheStopWatch, string TheCommand, params object[] TheParameters);

        object ExecuteScalarParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters);

        object ExecuteScalarTimedParams(Stopwatch TheStopWatch, StringBuilder TheCommandStringBuilder, params object[] TheParameters);

        DataTable ExecuteDataTable();

        DataTable ExecuteDataTable(Stopwatch TheStopWatch);

        DataTable ExecuteDataTable(string TheCommand);

        DataTable ExecuteDataTable(string TheCommand, Stopwatch TheStopWatch);

        DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder);

        DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch);

        DataTable ExecuteDataTable(IEnumerable<object> TheParameters);

        DataTable ExecuteDataTable(IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters);

        DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters);

        DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch);

        DataTable ExecuteDataTableParamsOnly(params object[] TheParameters);

        DataTable ExecuteDataTableTimedParamsOnly(Stopwatch TheStopWatch, params object[] TheParameters);

        DataTable ExecuteDataTableParams(string TheCommand, params object[] TheParameters);

        DataTable ExecuteDataTableTimedParams(Stopwatch TheStopWatch, string TheCommand, params object[] TheParameters);

        DataTable ExecuteDataTableParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters);

        DataTable ExecuteDataTableTimedParams(Stopwatch TheStopWatch, StringBuilder TheCommandStringBuilder, params object[] TheParameters);

    }

}
