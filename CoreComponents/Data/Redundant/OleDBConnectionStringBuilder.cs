using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

#pragma warning disable 0649

namespace CoreComponents.Data.OleDB
{
    public class OleDBConnectionStringBuilder : ConnectionStringBuilder
    {
        /*
        "Provider=MSDAORA; Data Source=ORACLE8i7;Persist Security Info=False;Integrated Security=Yes"

        "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\bin\LocalAccess40.mdb"

        "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI"
         */

        string _Provider;

        string _Data_Source;

        bool _Persist_Security_Info;

        string _Integrated_Security;

        string _Jet_OLEDB_Database_Password;

        public OleDBConnectionStringBuilder() : base(typeof(OleDBConnectionStringBuilder))
        {
        }

        public string Provider
        {

            get
            {

                return _Provider;

            }
            set
            {

                value = _Provider;

                if (_AutoAdd)
                    Add("Provider");

            }

        }

        public string Data_Source
        {

            get
            {

                return Data_Source;

            }
            set
            {

                value = _Data_Source;

                if (_AutoAdd)
                    Add("Data_Source");


            }

        }

        public bool Persist_Security_Info
        {

            get
            {

                return _Persist_Security_Info;

            }
            set
            {

                value = _Persist_Security_Info;

                if (_AutoAdd)
                    Add("Persist_Security_Info");


            }

        }

        public string Integrated_Security
        {

            get
            {

                return _Integrated_Security;

            }
            set
            {

                value = _Integrated_Security;

                if (_AutoAdd)
                    Add("Integrated_Security");


            }

        }

        public string Jet_OLEDB_Database_Password
        {

            get
            {

                return _Jet_OLEDB_Database_Password;

            }
            set
            {

                value = _Jet_OLEDB_Database_Password;

                if (_AutoAdd)
                    Add("Jet_OLEDB_Database_Password");


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
                    case "Provider":
                        SubConnectionString.Append(_Provider);
                        goto InsertName;
                    case "Data_Source":
                        SubConnectionString.Append(_Data_Source);
                        goto InsertNameReplace;
                    case "Persist_Security_Info":
                        SubConnectionString.Append(_Persist_Security_Info);
                        goto InsertNameReplace;
                    case "Integrated_Security":
                        SubConnectionString.Append(_Integrated_Security);
                        goto InsertNameReplace;
                    case "Jet_OLEDB_Database_Password":
                        SubConnectionString.Append(_Jet_OLEDB_Database_Password);
                        goto InsertColonAt10Replace;
                }

            InsertName:
                SubConnectionString.Insert(0, Parameter.Name + "=");
                goto End;

            InsertNameReplace:
                SubConnectionString.Insert(0, Parameter.Name.Replace("_", " ") + "=");
                goto End;

            InsertColonAt10Replace:
                Parameter.Name.Insert(10, ":");
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

                return "OleDB";

            }
        }

    }

    //public enum OleDBProviders
    //{

    //    MSDAORA,
    //    MicrosoftJetOLEDB4,
    //    SQLOLEDB

    //}

}
