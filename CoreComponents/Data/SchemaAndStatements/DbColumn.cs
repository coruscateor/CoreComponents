using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbColumn : DbEntityWithConstraints
    {

        protected Type myType = typeof(object);

        //protected bool myAllowNull;

        //protected bool myIsUnique;

        //protected object myDefaultValue = null;

        protected DbTable myTable;

        //protected DbColumn myRelation;

        //protected DbPrimaryKeyColumnConstraint myPrimaryKeyColumnConstraint;

        public DbColumn(string TheName)
        {

            myName = TheName;

        }

        public DbColumn(string TheName, DbTable TheTable)
        {

            myName = TheName;

            Table = TheTable;

        }

        public DbColumn(string TheName, DbTable TheTable, object TheDefaultValue)
        {

            myName = TheName;

            Table = TheTable;

            myConstraints.Add(new DbDefaultColumnConstraint(TheDefaultValue));

            //myDefaultValue = TheDefaultValue;

        }

        public DbColumn(string TheName, Type TheType)
        {

            myName = TheName;

            myType = TheType;

        }

        public DbColumn(string TheName, Type TheType, object TheDefaultValue)
        {

            myName = TheName;

            myType = TheType;

            myConstraints.Add(new DbDefaultColumnConstraint(TheDefaultValue));

            //myDefaultValue = TheDefaultValue;

        }

        public DbColumn(string TheName, Type TheType, DbTable TheTable)
        {

            myName = TheName;

            myType = TheType;

            Table = TheTable;

        }

        //public DbColumn(string TheName, Type TheType, DbTable TheTable, string TheDefaultValue)
        //{

        //    myName = TheName;

        //    myType = TheType;

        //    Table = TheTable;

        //    myDefaultValue = TheDefaultValue;

        //}

        public Type Type
        {

            get
            {

                return myType;

            }

            set
            {

                myType = value;

            }

        }

        //public bool AllowNull
        //{

        //    get
        //    {

        //        return myAllowNull;

        //    }
        //    set
        //    {

        //        myAllowNull = value;

        //    }

        //}

        //public bool IsUnique
        //{

        //    get
        //    {

        //        return myIsUnique;

        //    }
        //    set
        //    {

        //        myIsUnique = value;

        //    }

        //}

        //public object DefaultValue
        //{

        //    get
        //    {

        //        return myDefaultValue;

        //    }
        //    set
        //    {

        //        myDefaultValue = value;

        //    }

        //}

        //public bool HasDefaultValue
        //{

        //    get 
        //    {

        //        return myDefaultValue != null; // && myDefaultValue.Length > 0;

        //    }

        //}

        //public void SetDefaultValue(object TheValue)
        //{

        //    myDefaultValue = TheValue as string;

        //}

        public DbTable Table
        {

            get
            {

                return myTable;

            }
            set
            {

                if (myTable != value)
                {

                    if (value != null)
                    {

                        if (!value.Columns.Contains(this))
                            value.Columns.Add(this);

                    }

                    myTable = value;

                }

            }

        }

        public bool HasTable
        {

            get
            {

                return myTable != null;

            }

        }

        public bool IsInteger
        {

            get
            {

                return myType == SystemTypes.Short || myType == SystemTypes.Ushort || myType == SystemTypes.Int || myType == SystemTypes.Uint || myType == SystemTypes.Long || myType == SystemTypes.Ulong;

            }

        }

        //public DbPrimaryKeyColumnConstraint PrimaryKeyColumnConstraint
        //{

        //    get
        //    {

        //        return myPrimaryKeyColumnConstraint;

        //    }
        //    set
        //    {

        //        myPrimaryKeyColumnConstraint = value;

        //    }

        //}

        //public DbColumn Relation
        //{

        //    get
        //    {

        //        return myRelation;

        //    }
        //    set
        //    {

        //        if (myRelation != value && value.HasTable && myTable != null && myTable.PrimaryKey.Contains(this) && !myTable.Columns.Contains(value))
        //        {

        //            myRelation = value;

        //            if (myRelation.Relation != this)
        //            {

        //                myRelation.Relation = this;

        //                if (myRelation.Relation != this)
        //                    myRelation = null;

        //            }

        //        }

        //    }

        //}

        //public void ValidateRelation()
        //{

        //    if (myRelation != null)
        //    {

        //        if (!myRelation.HasTable || myRelation.Relation != this)
        //        {

        //            myRelation = null;

        //        }

        //    }

        //}

        public override bool Equals(object obj)
        {

            if (obj.GetType() == typeof(DbColumn))
            {

                DbColumn OtherColumn = obj as DbColumn;

                return OtherColumn.Table == myTable && OtherColumn.Name == myName; //&& OtherColumn.Type == myType;

            }

            return false;

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

        public static bool operator ==(DbColumn Left, DbColumn Right)
        {

            return Left.Equals(Right);

        }

        public static bool operator !=(DbColumn Left, DbColumn Right)
        {

            return !Left.Equals(Right);

        }

    }

}
