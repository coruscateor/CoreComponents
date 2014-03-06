using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoreComponents;
using CoreComponents.Characters;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbColumn : DbEntity, IChild<DbTable>
    {

        //protected static Type[] mySystemTypes;

        protected Type myType;

        protected uint? myNumericPrecision;

        protected bool myNotNull;

        //protected bool myIsReadOnly;

        protected object myDefaultValue;

        protected uint? myMaxLength;

        protected uint? myNumericScale;

        protected bool myAutoIncrement;

        protected bool myUnique;

        protected ChildToParentAdapter<DbTable, DbColumn, IParentedList<DbTable, DbColumn>> myAdapter;

        //static DbColumn()
        //{

        //    mySystemTypes = SystemTypes.GetTypes();

        //}

        public DbColumn()
        {

            myName = "New Column";

            //myType = mySystemTypes[0];

            myType = typeof(object);

            Initalise();

        }

        public DbColumn(string Name, Type TheType, uint? Precision = null)
        {

            myName = Name;

            myType = TheType;

            if(Precision != null)
                myNumericPrecision = Precision;

            Initalise();

        }

        void Initalise()
        {

            myAdapter = new ChildToParentAdapter<DbTable, DbColumn, IParentedList<DbTable, DbColumn>>(this, "Columns");

            myType = typeof(object);

        }

        public Type Type
        {

            get
            {

                return myType;

            }

            set
            {

                myType = value;

                //foreach (Type sysType in mySystemTypes)
                //{

                //    if (sysType == value)
                //    {

                //        myType = value;

                //        return;

                //    }

                //}

            }

        }

        //public bool IsReadOnly
        //{

        //    get
        //    {

        //        return myIsReadOnly;

        //    }
        //    set
        //    {

        //        myIsReadOnly = value;

        //    }

        //}

        public uint? NumericPrecision
        {

            get
            {

                return myNumericPrecision;

            }
            set
            {

                myNumericPrecision = value;

            }

        }

        public uint? NumericScale
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

        public bool NotNull
        {

            get
            {

                return myNotNull;

            }
            set
            {

                myNotNull = value;

            }

        }

        public object DefaultValue
        {

            get
            {

                return myDefaultValue;

            }
            set
            {

                if (value.GetType() == myType && myDefaultValue == null)
                {

                    myDefaultValue = value;

                }

            }

        }

        public bool HasDefaultValue
        {

            get
            {

                return myDefaultValue != null;

            }

        }

        public void RemoveDefaultValue()
        {

            myDefaultValue = null;

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

            return myAdapter.OwnerIsOrphin();

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

        public uint? MaxLength
        {

            get
            {

                return myMaxLength;

            }
            set
            {

                myMaxLength = value;

            }

        }

        public bool AutoIncrement
        {

            get
            {

                return myAutoIncrement;

            }
            set
            {

                myAutoIncrement = value;

            }

        }

        public bool Unique
        {

            get
            {

                return myUnique;

            }
            set
            {

                myUnique = value;

            }

        }

        public bool IsPrimaryKey()
        {

            if (!IsOrphin())
            {

                return myAdapter.OwnersParent.PrimaryKey.Contains(this);

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
		
    }

}
