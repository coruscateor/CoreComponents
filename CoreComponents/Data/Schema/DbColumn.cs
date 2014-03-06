using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{
    public class DbColumn : DbEntity, IChild<DbTable>
    {

        protected static Type[] SystemTypeArray;

        //protected Type myType;
		
		//protected DbType myType;

        protected Type myType;

        protected int myNumericPrecision = -1;

        protected bool myAllowNull = true;

        //protected bool myHasDefault;

        protected bool myIsReadOnly;

        protected string myDefaultValue;

        protected int myMaxLength = -1;

        protected int myNumericScale = -1;

        protected bool myIsAutoIncrement;

        //protected long myAutoIncrementSeed;

        //protected long myAutoIncrementStep;

        protected bool myIsRestrictedToSystemTypes = true;

        protected ChildToParentAdapter<DbTable, DbColumn, IParentedList<DbTable, DbColumn>> myAdapter;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin TypeChanged;

        public event Gimmie<MessageEventArgs<DbColumn>>.GimmieSomethin TypeChangeFailure;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin NumericPrecisionChanged;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin AllowNullChanged;

        //public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin HasDefaultChanged;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin IsReadOnlyChanged;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin DefaultValueChanged;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin MaxLengthChanged;

        public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin IsAutoIncrementChanged;

        //public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin AutoIncrementSeedChanged;

        //public event Gimmie<SenderEventArgs<DbColumn>>.GimmieSomethin AutoIncrementStepChanged;

        static DbColumn()
        {

            SystemTypeArray = PrimativeConstants.GetTypeArray();

        }

        public DbColumn()
        {

            myName = "New Column";

            myType = SystemTypeArray[0];

            Initalise();

        }

        public DbColumn(string Name, Type TheType)
        {
			
            myName = Name;

            myType = TheType;

            Initalise();

        }

        public DbColumn(string Name, Type TheType, int Precision)
        {

            myName = Name;

            myType = TheType;

            myNumericPrecision = Precision;

            Initalise();

        }

        void Initalise()
        {

            myAdapter = new ChildToParentAdapter<DbTable, DbColumn, IParentedList<DbTable, DbColumn>>(this, "Columns");

            myType = typeof(object);

        }

        protected void OnTypeChanged()
        {

            if (TypeChanged != null)
                TypeChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnTypeChangeFailure()
        {

            if (TypeChangeFailure != null)
                TypeChangeFailure(new MessageEventArgs<DbColumn>(this, "The assigned Type must be as system type.")); 

        }

        protected void OnNumericPrecisionChanged()
        {

            if (NumericPrecisionChanged != null)
                NumericPrecisionChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnAllowNullChanged()
        {

            if (AllowNullChanged != null)
                AllowNullChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnIsReadOnlyChanged()
        {

            if (IsReadOnlyChanged != null)
                IsReadOnlyChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnDefaultValueChanged()
        {

            if (DefaultValueChanged != null)
                DefaultValueChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnMaxLengthChanged()
        {

            if (MaxLengthChanged != null)
                MaxLengthChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnIsAutoIncrementChanged()
        {

            if (IsAutoIncrementChanged != null)
                IsAutoIncrementChanged(new SenderEventArgs<DbColumn>(this));

        }

        /*
        protected void OnAutoIncrementSeedChanged()
        {

            if (AutoIncrementSeedChanged != null)
                AutoIncrementSeedChanged(new SenderEventArgs<DbColumn>(this));

        }

        protected void OnAutoIncrementStepChanged()
        {

            if (AutoIncrementStepChanged != null)
                AutoIncrementStepChanged(new SenderEventArgs<DbColumn>(this));

        }
        */

        public Type Type
        {

            get
            {

                return myType;

            }

            set
            {

                if (myIsRestrictedToSystemTypes)
                {

                    foreach (Type sysType in SystemTypeArray)
                    {

                        if (sysType == value)
                        {

                            myType = value;

                            OnTypeChanged();

                            return;

                        }

                    }

                    OnTypeChangeFailure();

                } else
                {

                    myType = value;

                    OnTypeChanged();

                }
            }

        }

        public bool IsRestrictedToSystemTypes
        {

            get
            {

                return myIsRestrictedToSystemTypes;

            }

        }

        public bool IsReadOnly
        {

            get
            {

                return myIsReadOnly;

            }
            set
            {

                myIsReadOnly = value;

                OnIsReadOnlyChanged();

            }

        }

        public int NumericPrecision
        {

            get
            {

                return myNumericPrecision;

            }
            set
            {

                myNumericPrecision = value;

                OnNumericPrecisionChanged();

            }

        }

        public int NumericScale
        {

            get
            {

                return myNumericScale;

            }
            set
            {

                myNumericScale = value;

            }

        }

        public bool AllowNull
        {

            get
            {

                return myAllowNull;

            }
            set
            {

                myAllowNull = value;

                OnAllowNullChanged();

            }

        }

        public bool IsLong
        {

            get
            {

                return (myType == typeof(string) && myMaxLength >= 0);

            }

        }

        /*
        public bool HasDefault
        {

            get
            {

                return myHasDefault;

            }
            set
            {

                myHasDefault = value;

            }

        }
        */

        public string DefaultValue
        {

            get
            {

                return myDefaultValue;

            }
            set
            {

                myDefaultValue = value;

                OnDefaultValueChanged();

            }

        }


        public DbTable Parent
        {

            get
            {

                return myAdapter.OwnersParent;

            }
            set
            {

                myAdapter.SetParent(value);

            }

        }
        

        public bool IsOrphin()
        {
            return myAdapter.OwnersParent == null;
        }

        public int Ordinal
        {

            get
            {

                if (!IsOrphin())
                {

                    return myAdapter.OwnersParent.Columns.IndexOf(this);

                } else
                {

                    return -1;

                }

            }

        }

        public int MaxLength
        {

            get
            {

                return myMaxLength;

            }
            set
            {

                myMaxLength = value;

                OnMaxLengthChanged();

            }

        }

        /*
        public bool IsKey
        {

            get
            {
                if (!IsOrphin())
                {

                    //return myAdapter.OwnersParent.PrimaryKey.Contains(this);
                    return true;

                } else
                {

                    return false;

                }

            }

        }

        public bool IsKeyPart
        {

            get
            {

                return myAdapter.OwnersParent.PrimaryKey.Count > 1;

            }

        }
        */

        public bool IsAutoIncrement
        {

            get
            {

                return myIsAutoIncrement;

            }
            set
            {

                myIsAutoIncrement = value;

                OnIsAutoIncrementChanged();

            }

        }

        /*
        public long AutoIncrementSeed
        {

            get
            {

                return myAutoIncrementSeed;

            }
            set
            {

                myAutoIncrementSeed = value;

                OnAutoIncrementSeedChanged();

            }

        }

        public long AutoIncrementStep
        {

            get
            {

                return myAutoIncrementStep;

            }
            set
            {

                myAutoIncrementStep = value;

                OnAutoIncrementStepChanged();

            }

        }
        */

        public static Type[] SystemTypes
        {

            get
            {

                return SystemTypeArray;

            }

        }

		/*
        public bool IsPrimaryKey()
        {

            if (!IsOrphin())
            {

                foreach (DbColumn Column in myAdapter.OwnersParent.PrimaryKey)
                {

                    if (Column == this)
                    {

                        return true;

                    }

                }

            }

            return false;
        }

        public bool IsForiegnKey()
        {

            if (!IsOrphin())
            {

                foreach (KeyValuePair<DbColumn, DbColumn> Column in myAdapter.OwnersParent.ForignKeys)
                {

                    if (Column.Key == this)
                    {

                        return true;

                    }

                }

            }

            return false;
        }
        */
		
    }
}
