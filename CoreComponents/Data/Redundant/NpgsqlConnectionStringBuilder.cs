using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

#pragma warning disable 0649

namespace CoreComponents.Data.Npgsql
{
    public class NpgsqlConnectionStringBuilder : ConnectionStringBuilder
    {

        string _Server;

        int _Port;

        int _Protocol;

        string _Database;

        string _User_Id;

        bool _Integrated_Security;

        string _Password;

        bool _SSL;

        bool _Pooling;

        int _MinPoolSize;

        int _MaxPoolSize;

        public int _Timeout;

        int _CommandTimeout;

        Sslmode _Sslmode;

        int _ConnectionLifeTime;

        bool _SyncNotification;

        string _SearchPath;

        bool _Preload_Reader;

        bool _Use_Extended_Types;
 
        public NpgsqlConnectionStringBuilder() : base(typeof(NpgsqlConnectionStringBuilder))
        {
        }

        public string Server
        {
            get
            {

                return _Server;

            }
            set
            {

                value = _Server;

                if(_AutoAdd)
                    Add("Server");
            }

        }

        public int Port
        {
            get
            {

                return _Port;

            }
            set
            {

                _Port = value;

                if (_AutoAdd)
                    Add("Port");

            }

        }

        public int Protocol
        {

            get
            {

                return _Protocol;

            }
            set
            {

                _Protocol = value;

                if (_AutoAdd)
                    Add("Protocol");

            }

        }

        public string Database
        {

            get
            {

                return _Database;

            }
            set
            {

                _Database = value;

                if (_AutoAdd)
                    Add("Database");

            }

        }

        public string User_Id
        {

            get
            {

                return _User_Id;

            }
            set
            {

                _User_Id = value;

                if (_AutoAdd)
                    Add("User_Id");

            }

        }

        public bool Integrated_Security
        {

            get
            {

                return _Integrated_Security;

            }
            set
            {

                _Integrated_Security = value;

                if (_AutoAdd)
                    Add("Integrated_Security");

            }
        
        }

        public string Password
        {

            get
            {

                return _Password;

            }
            set
            {
                _Password = value;

                if (_AutoAdd)
                    Add("Password");

            }

        }

        public bool SSL 
        {

            get
            {

                return _SSL;

            }
            set
            {

                _SSL = value;

                if (_AutoAdd)
                    Add("SSL");

            }

        }

        public bool Pooling
        {

            get
            {

                return _Pooling;

            }
            set
            {

                _Pooling = value;

                if (_AutoAdd)
                    Add("Pooling");

            }

        }

        public int MinPoolSize
        {

            get
            {

                return _MinPoolSize;

            }
            set
            {

                _MinPoolSize = value;

                if (_AutoAdd)
                    Add("Pooling");

            }

        }

        public int MaxPoolSize
        {

            get
            {

                return _MaxPoolSize;

            }
            set
            {

                _MaxPoolSize = value;

                if (_AutoAdd)
                    Add("MaxPoolSize");

            }

        }

        public int Timeout 
        {
            get
            {

                return _Timeout;

            }
            set
            {

                _Timeout = value;

                if (_AutoAdd)
                    Add("Timeout");

            }
        
        }

        public int CommandTimeout
        {
            get
            {

                return _CommandTimeout;

            }
            set
            {

                _CommandTimeout = value;

                if (_AutoAdd)
                    Add("CommandTimeout");

            }
        
        }

        public Sslmode Sslmode 
        {

            get
            {

                return _Sslmode;

            }
            set
            {

                _Sslmode = value;

                if (_AutoAdd)
                    Add("Sslmode");

            }
        
        }
        
        public int ConnectionLifeTime
        {

            get
            {

                return _ConnectionLifeTime;

            }
            set
            {

                _ConnectionLifeTime = value;

                if (_AutoAdd)
                    Add("ConnectionLifeTime");

            }
        
        }

        public bool SyncNotification
        {

            get
            {

                return _SyncNotification;

            }
            set
            {

                _SyncNotification = value;

                if (_AutoAdd)
                    Add("SyncNotification");

            }

        }

        public string SearchPath 
        {

            get
            {

                return _SearchPath;

            }
            set
            {

                _SearchPath = value;

                if (_AutoAdd)
                    Add("SearchPath");

            }
        
        }

        public bool Preload_Reader 
        {

            get
            {

                return _Preload_Reader;

            }
            set
            {

                _Preload_Reader = value;

                if (_AutoAdd)
                    Add("Preload_Reader");

            }
        
        }

        public bool Use_Extended_Types
        {

            get
            {

                return _Use_Extended_Types;

            }
            set
            {

                _Use_Extended_Types = value;

                if (_AutoAdd)
                    Add("Use_Extended_Types");

            }

        }

        public override string ToString()
        {

            StringBuilder ConnectionString = new StringBuilder();

            StringBuilder SubConnectionString = new StringBuilder();

            foreach (PropertyInfo Parameter in UsedPrameters)
            {

                ClearStringBuilder(SubConnectionString);

                switch (Parameter.Name)
                {
                    case "Server":
                        SubConnectionString.Append(_Server);
                        goto InsertName;
                    case "Port":
                        SubConnectionString.Append(_Port);
                        goto InsertName;
                    case "Protocol":
                        SubConnectionString.Append(_Protocol);
                        goto InsertName;
                    case "Database":
                        SubConnectionString.Append(_Database);
                        goto InsertName;
                    case "Password":
                        SubConnectionString.Append(_Password);
                        goto InsertName;
                    case "SSL":
                        SubConnectionString.Append(_SSL);
                        goto InsertName;
                    case "MinPoolSize":
                        SubConnectionString.Append(_MinPoolSize);
                        goto InsertName;
                    case "MaxPoolSize":
                        SubConnectionString.Append(_MaxPoolSize);
                        goto InsertName;
                    case "Timeout":
                        SubConnectionString.Append(_Timeout);
                        goto InsertName;
                    case "CommandTimeout":
                        SubConnectionString.Append(_CommandTimeout);
                        goto InsertName;
                    case "SslMode":
                        SubConnectionString.Append(this._Sslmode.ToString());
                        goto InsertName;
                    case "ConnectionLifeTime":
                        SubConnectionString.Append(_ConnectionLifeTime);
                        goto InsertName;
                    case "SyncNotification":
                        SubConnectionString.Append(_SyncNotification);
                        goto InsertName;
                    case "SearchPath":
                        SubConnectionString.Append(_SearchPath);
                        goto InsertName;
                    case "Preload_Reader":
                        SubConnectionString.Append(_Preload_Reader);
                        goto InsertNameReplace;
                    case "Use_Extended_Types":
                        SubConnectionString.Append(_Use_Extended_Types);
                        goto InsertNameReplace;
                    case "Integrated_Security":
                        SubConnectionString.Append(_Integrated_Security);
                        goto InsertNameReplace;
                    case "User_Id":
                        SubConnectionString.Append(_User_Id);
                        goto InsertNameReplace;
                }

            InsertName:
                SubConnectionString.Insert(0, Parameter.Name + "=");
                goto End;

            InsertNameReplace:
                SubConnectionString.Insert(0, Parameter.Name.Replace("_", " ") + "=");

            End:
                SubConnectionString.Append("; ");

                ConnectionString.Append(SubConnectionString.ToString());

            }

            return ConnectionString.ToString();
        }

        public override string ConnectionType
        {
            get
            {

                return "Npgsql";

            }
        }

    }

    public enum Sslmode {

    Prefer,
    Require,
    Allow,
    Disable

    }

    //Mode for ssl connection control. Can be one of the following:

    //Prefer
    //    If it is possible to connect via SLL, SSL will be used.
    //Require
    //    If an SSL connection cannot be established, an exception is thrown.
    //Allow
    //    Not supported yet; connects without SSL.
    //Disable
    //    No SSL connection is attempted.
    //The default value is "Disable".

}
