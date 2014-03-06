using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Characters;

namespace CoreComponents.Data.SchemaAndStatements
{

    public abstract class CommonCommandWriter<TTypeOrTypeAffinity>
    {

        public const string IfExists = "IF EXISTS ";

        public const string IfNotExists = "IF NOT EXISTS ";

        public const string DropTable = "DROP TABLE ";

        protected Dictionary<Type, TTypeOrTypeAffinity> myTypeIndex = new Dictionary<Type, TTypeOrTypeAffinity>();

        protected StringBuilder mySB = new StringBuilder();

        protected bool myTerminateStatement;

        public CommonCommandWriter()
        {
        }

        public abstract string Create(DbDatabase TheDataBase, bool IfNotExists = false);

        public abstract string Create(DbTable TheTable, bool IfNotExists = false);

        public abstract string Drop(DbDatabase TheDataBase, bool IfExists = false);

        public abstract string Drop(DbTable TheTable, bool IfExists = false);

        public abstract string Alter(DbDatabase TheTable);

        public abstract string Alter(DbTable TheTable);

        public Dictionary<Type, TTypeOrTypeAffinity> GetTypeIndex()
        {

            return new Dictionary<Type, TTypeOrTypeAffinity>(myTypeIndex);

        }

        public bool TypeIsRecognised(DbColumn TheColumn)
        {

            return myTypeIndex.ContainsKey(TheColumn.Type);

        }

        public bool TypeIsRecognised(Type TheType)
        {

            return myTypeIndex.ContainsKey(TheType);

        }

        public bool TerminateStatement
        {

            get
            {

                return myTerminateStatement;

            }
            set
            {

                myTerminateStatement = value;

            }

        }

        protected void AppendSpace()
        {

            mySB.Append(CoreComponents.Characters.Text.Space);

        }

        protected void AppendCreate()
        {

            mySB.Append(CommonSQL.CREATE);

            AppendSpace();

        }

        protected void AppendTemporary()
        {

            mySB.Append(CommonSQL.TEMPORARY);

            AppendSpace();

        }

        protected void AppendTable()
        {

            mySB.Append(CommonSQL.TABLE);

            AppendSpace();

        }

        protected void AppendNotNull(DbColumn TheColumn)
        {

            if (TheColumn.NotNull)
            {

                AppendSpace();

                mySB.Append(CommonSQL.NOT);

                AppendSpace();

                mySB.Append(CommonSQL.NULL);

            }

        }

        protected void AppendUnique(DbColumn TheColumn)
        {

            if (TheColumn.Unique)
            {

                AppendSpace();

                mySB.Append(CommonSQL.UNIQUE);

            }

        }

        protected void AppendDefaultValue(object TheValue)
        {

            AppendSpace();

            mySB.Append(CommonSQL.DEFAULT);

            AppendSpace();

            mySB.Append(TheValue.ToString());

        }

        protected void AppendDefaultValue(DbColumn TheColumn)
        {

            if (TheColumn.HasDefaultValue)
            {

                mySB.Append(CommonSQL.DEFAULT);

                AppendSpace();

                mySB.Append(TheColumn.DefaultValue.ToString());

                AppendSpace();

            }

        }

        protected void AppendComma()
        {

            mySB.Append(',');

            AppendSpace();

        }

        protected void AppendPrimaryKey()
        {

            mySB.Append(CommonSQL.PRIMARY);

            AppendSpace();

            mySB.Append(CommonSQL.KEY);

            AppendSpace();

        }

        protected void AppendLeftBraket()
        {

            mySB.Append('(');
 
        }

        protected void AppendRightBraket()
        {

            mySB.Append(')');

        }

        protected void AppendTableName(DbColumn TheTable)
        {

            mySB.Append(TheTable.Name);

        }

        protected void AppendColumnName(DbColumn TheColumn)
        {

            mySB.Append(TheColumn.Name);

        }

        protected void AppendForeignKey()
        {

            mySB.Append(CommonSQL.FOREIGN);

            AppendSpace();

            mySB.Append(CommonSQL.KEY);

            AppendSpace();

        }

        protected void AppendSemiColon()
        {

            if(myTerminateStatement)
                mySB.Append(';');

        }

        protected void AppendIfExists(bool IfExists)
        {

            if (IfExists)
            {

                mySB.Append(IfExists);

            }

        }

        protected void AppendIfNotExists(bool IfNotExists)
        {

            if (IfNotExists)
            {

                mySB.Append(IfNotExists);

            }

        }

        public void AppendDropTable()
        {

            mySB.Append(DropTable);

        }

        //public void Clear()
        //{

        //    mySB.Clear();

        //}

    }

}
