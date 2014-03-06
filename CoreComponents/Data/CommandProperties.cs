using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Data
{

    public class CommandProperties : ICommandProperties
    {

        [IsDefaultValue]
        public const string DefaultCommandText = "";

        [IsDefaultValue]
        public readonly int DefaultCommandTimeout = 0;

        [IsDefaultValue]
        public readonly CommandType DefaultCommandType = CommandType.Text;

        //protected IDataParameterCollection myParameterCollection;

        //[IsADefaultValue]
        //public static const ReadOnlyList<object> DefaultParameterCollection = new ReadOnlyList<object>(new List<object>());

        //[IsADefaultValue]
        //public readonly SQLParameter[] DefaultParameterCollection = new SQLParameter[] { };

        [IsDefaultValue]
        public readonly Dictionary<string, object> DefaultParameterCollection = new Dictionary<string, object>();

        [IsDefaultValue]
        public readonly UpdateRowSource  DefaultUpdatedRowSource = UpdateRowSource.Both;

        [IsDefaultValue]
        public readonly CommandResultType  DefaultCommandResultType = CommandResultType.ResultSet;

        [IsDefaultValue]
        public readonly CommandBehavior  DefaultCommandBehavior = CommandBehavior.Default;

        protected Dictionary<string, object> myProperties = new Dictionary<string, object>();

        //protected dynamic myProperties = new System.Dynamic.ExpandoObject();

        //protected string myCommandText;

        //protected int myCommandTimeout;

        //protected CommandType myCommandType;

        //DbParameter

        //protected IDataParameterCollection myParameterCollection;

        //protected ReadOnlyList<object> myParameterCollection;

        //protected SQLParameter[] myParameterCollection;

        //protected IDictionary<string, object> myParameterCollection;

        //protected UpdateRowSource myUpdatedRowSource;

        //protected CommandResultType myCommandResultType;

        //protected CommandBehavior myCommandBehavior;

        static ConcurrentDictionary<string, Type> NameAndTypeSet = new ConcurrentDictionary<string, Type>();

        static CommandProperties() 
        {

            NameAndTypeSet.TryAdd(Keys.CommandBehavior, Keys.CommandBehaviorType);

            NameAndTypeSet.TryAdd(Keys.CommandResultType, Keys.CommandResultTypeType);

            NameAndTypeSet.TryAdd(Keys.CommandText, Keys.CommandTextType);

            NameAndTypeSet.TryAdd(Keys.CommandTimeout, Keys.CommandTimeoutType);

            NameAndTypeSet.TryAdd(Keys.CommandType, Keys.CommandTypeType);

            NameAndTypeSet.TryAdd(Keys.ParameterCollection, Keys.ParameterCollectionType);

            NameAndTypeSet.TryAdd(Keys.UpdateRowSource, Keys.UpdatedRowSourceType);

        }

        public CommandProperties(dynamic TheDynamicCommandProperties)
        {

            IDictionary<string, object> CPs = (IDictionary<string, object>)TheDynamicCommandProperties;

            foreach (KeyValuePair<string, object> KeyValues in CPs)
            {

                if (NameAndTypeSet.ContainsKey(KeyValues.Key)) 
                {

                    //if(

                }

            }

        }

        public CommandProperties(string TheCommandText)
        {

            myProperties.Add(Keys.CommandText, TheCommandText);

            //myProperties.CommandText = TheCommandText;
        }

        public CommandProperties(string TheCommandText, IDictionary<string, object> TheParameterCollection)
        {

            myProperties.Add(Keys.CommandText, TheCommandText);

            myProperties.Add(Keys.ParameterCollection, new Dictionary<string,object>(TheParameterCollection));

        }

        public CommandProperties(string TheCommandText, CommandResultType TheCommandResultType)
        {

            myProperties.Add(Keys.CommandText, TheCommandText);

            //myProperties.CommandText = TheCommandText;

            myProperties.Add(Keys.CommandResultType, TheCommandResultType);

            //myProperties.CommandResultType = TheCommandResultType;

        }

        public CommandProperties(string TheCommandText, CommandResultType TheCommandResultType = CommandResultType.ResultSet, CommandBehavior TheCommandBehavior = CommandBehavior.Default, int TheCommandTimeout = 0, System.Data.CommandType TheCommandType = System.Data.CommandType.Text, System.Data.UpdateRowSource TheUpdatedRowSource = System.Data.UpdateRowSource.None) 
        {
            
            //myCommandText = TheCommandText;

            //myCommandTimeout = TheCommandTimeout;

            //myCommandType = TheCommandType;

            //myParameterCollection = DefaultParameterCollection;

            //myCommandResultType = TheCommandResultType;

            //myCommandBehavior = TheCommandBehavior;

        }

        public CommandProperties(string TheCommandText, IDictionary<string, object> TheParameterCollection, CommandResultType TheCommandResultType = CommandResultType.ResultSet, CommandBehavior TheCommandBehavior = System.Data.CommandBehavior.Default, int TheCommandTimeout = 0, System.Data.CommandType TheCommandType = System.Data.CommandType.Text, System.Data.UpdateRowSource TheUpdatedRowSource = System.Data.UpdateRowSource.None)
        {
            //IEnumerable<KeyValuePair<string, object>> TheParameterCollection

            //myCommandText = TheCommandText;

            //myCommandTimeout = TheCommandTimeout;

            //myCommandType = TheCommandType;

            //List<object> SQLParameterList = new List<object>();

            //foreach (object Parameter in TheParameterCollection)
            //{

            //    ObjectList.Add(Parameter);

            //}

            //myParameterCollection = new ReadOnlyList<object>(ObjectList);

            //myParameterCollection = TheParameterCollection.ToArray();

            //myParameterCollection = new Dictionary<string, object>(TheParameterCollection);

            //myCommandResultType = TheCommandResultType;

            //myCommandBehavior = TheCommandBehavior;

        }

        public CommandProperties(string TheCommandText, IDictionary<string, object> TheParameterCollection, CommandResultType TheCommandResultType = CommandResultType.ResultSet /*, params SQLParameter[] TheParameterCollection*/)
        {


            //myCommandText = TheCommandText;

            //myCommandTimeout = DefaultCommandTimeout;

            //myCommandType = DefaultCommandType;

            //myParameterCollection = TheParameterCollection;

            //myCommandResultType = TheCommandResultType;

            //myCommandBehavior = DefaultCommandBehavior;

        }

        public CommandProperties(string TheCommandText, IDictionary<string, object> TheParameterCollection, CommandBehavior TheCommandBehavior = System.Data.CommandBehavior.Default /*, params SQLParameter[] TheParameterCollection*/)
        {

            //myCommandText = TheCommandText;

            //myCommandTimeout = DefaultCommandTimeout;

            //myCommandType = DefaultCommandType;

            //myParameterCollection = new Dictionary<string, object>(TheParameterCollection);

            //myCommandResultType = DefaultCommandResultType;

            //myCommandBehavior = DefaultCommandBehavior;

        }

        public CommandProperties(string TheCommandText, IDictionary<string, object> TheParameterCollection, System.Data.CommandType TheCommandType = System.Data.CommandType.Text /*, params SQLParameter[] TheParameterCollection*/)
        {

            //myCommandText = TheCommandText;
            
            //myCommandTimeout = DefaultCommandTimeout;

            //myCommandType = TheCommandType;

            //myParameterCollection = new Dictionary<string, object>(TheParameterCollection);

            //myCommandResultType = DefaultCommandResultType;

            //myCommandBehavior = DefaultCommandBehavior;

        }

        //[DefaultValue("")]
        public string CommandText 
        {
            get 
            {

                //return myCommandText;
                //return myProperties.CommandText;

                return (string)myProperties[Keys.CommandText];

            }
            /*
            set 
            {

                myCommandText = value;

            }
            */
        }

        public bool HasCommandText
        {
            get
            {

                //return ((IDictionary<string, object>)myProperties).ContainsKey(Keys.CommandText);

                return myProperties.ContainsKey(Keys.CommandText);

            }

        }

        public int CommandTimeout 
        {
            get 
            {

                //return myCommandTimeout;

                return (int)myProperties[Keys.CommandTimeout];
            }
            /*
            set 
            {

                myCommandTimeout = value;

            }
            */
        }

        public CommandType CommandType 
        {
            get
            {

                //return myCommandType;

                return (CommandType)myProperties[Keys.CommandType];

            }
            /*
            set 
            {

                myCommandType = value;

            }
            */

        }

        //[DefaultValue("")]
        //public IDbConnection Connection { get; }

        //public IDataParameterCollection ParameterCollection
        //public ReadOnlyList<object> ParameterCollection
        //{

        //    get 
        //    {

        //        return myParameterCollection;

        //    }

        //}

        //public SQLParameter[] ParameterCollection
        //{

        //    get
        //    {

        //        return (SQLParameter[])myParameterCollection.Clone();

        //    }

        //}

        public Dictionary<string, object> ParameterCollection
        {

            get
            {

                //return new Dictionary<string,object>(myParameterCollection);

                return new Dictionary<string,object>((Dictionary<string, object>)myProperties[Keys.ParameterCollection]);

            }

        }

        public TParameter[] ParameterCollectionToArray<TParameter>() where TParameter : DbParameter, new()
        {

            List<TParameter> DbParameters = new List<TParameter>();

            Dictionary<string,object> ParameterCollection = (Dictionary<string, object>)myProperties[Keys.ParameterCollection];

            foreach (KeyValuePair<string, object> Parameter in ParameterCollection) 
            {

                TParameter NewDbParameter = new TParameter();

                NewDbParameter.ParameterName = Parameter.Key;

                NewDbParameter.Value = Parameter.Value;

                DbParameters.Add(NewDbParameter);

            }

            return DbParameters.ToArray();


        }

        //[DefaultValue("")]
        //public IDbTransaction Transaction { get; set; }

        public UpdateRowSource UpdatedRowSource 
        {

            get 
            {

                //return myUpdatedRowSource;

                return (UpdateRowSource)myProperties[Keys.UpdateRowSource];

            }
            /*
            set 
            {

                myUpdatedRowSource = value;

            }
            */

        }

        public CommandResultType CommandResultType 
        {

            get 
            {

                //return myCommandResultType;

                return (CommandResultType)myProperties[Keys.CommandResultType];

            }

        }

        public CommandBehavior CommandBehavior 
        {

            get 
            {

                //return myCommandBehavior;

                return (CommandBehavior)myProperties[Keys.CommandBehavior];

            }

        }

        //public CommandProperties Create(CommandResultType TheCommandResultType = DefaultCommandResultType, CommandBehavior TheCommandBehavior = DefaultCommandBehavior, int TheCommandTimeout = DefaultCommandTimeout, System.Data.CommandType TheCommandType = DefaultCommandType, System.Data.UpdateRowSource TheUpdatedRowSource = DefaultUpdatedRowSource)
        //{

        //    return new CommandProperties(myCommandText, myParameterCollection, TheCommandResultType, TheCommandBehavior, TheCommandTimeout, TheCommandType, TheUpdatedRowSource);

        //}

        //public CommandProperties Create(IEnumerable<object> TheParameterCollection, CommandResultType TheCommandResultType = DefaultCommandResultType, CommandBehavior TheCommandBehavior = DefaultCommandBehavior, int TheCommandTimeout = DefaultCommandTimeout, System.Data.CommandType TheCommandType = DefaultCommandType, System.Data.UpdateRowSource TheUpdatedRowSource = DefaultUpdatedRowSource) 
        //{

        //    return new CommandProperties(myCommandText, TheParameterCollection, TheCommandResultType, TheCommandBehavior, TheCommandTimeout, TheCommandType, TheUpdatedRowSource);

        //}

        public static class Keys 
        {

            public const string CommandText = "CommandText";

            public const string CommandTimeout = "CommandTimeout";

            public const string CommandType = "CommandType";

            public const string ParameterCollection = "ParameterCollection";

            public const string UpdateRowSource = "UpdateRowSource";

            public const string CommandResultType = "CommandResultType";

            public const string CommandBehavior = "CommandBehavior";

            public static readonly Type CommandTextType = typeof(string);

            public static readonly Type CommandTimeoutType = typeof(int);

            public static readonly Type CommandTypeType = typeof(CommandType);

            public static readonly Type ParameterCollectionType = typeof(IDictionary<string, object>);

            public static readonly Type UpdatedRowSourceType = typeof(UpdateRowSource);
            
            public static readonly Type CommandResultTypeType = typeof(CommandResultType);

            public static readonly Type CommandBehaviorType = typeof(CommandBehavior);

        }

    }

    public enum CommandResultType 
    {

        NonQuery,
        ResultSet,
        Scalar

    }
}
