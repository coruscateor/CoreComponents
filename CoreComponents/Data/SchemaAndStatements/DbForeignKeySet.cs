using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbForeignKeySet : IEnumerable<DbForeignKey>
    {

        protected DbTable myTable;

        protected List<DbForeignKey> myRelationships = new List<DbForeignKey>();

        public DbForeignKeySet(DbTable TheTable)
        {

            myTable = TheTable;

        }

        public DbTable Table
        {

            get
            {

                return myTable;

            }

        }

        public int Count
        {

            get
            {

                return myRelationships.Count;

            }

        }

        public int IndexOf(DbForeignKey item)
        {

            return myRelationships.IndexOf(item);

        }

        public bool Insert(int index, DbForeignKey item)
        {

            if (!myRelationships.Contains(item))
            {

                myRelationships.Insert(index, item);

                return true;

            }

            return false;

        }

        public void RemoveAt(int index)
        {

            myRelationships.RemoveAt(index);

        }

        public DbForeignKey this[int index]
        {
            get
            {
                return myRelationships[index];
            }
            set
            {

                if (!myRelationships.Contains(value))
                {

                    myRelationships[index] = value;

                }
                
            }

        }

        public bool Add(DbForeignKey item)
        {

            if (!myRelationships.Contains(item))
            {

                myRelationships.Add(item);

                return true;

            }

            return false;

        }

        public void Clear()
        {

            myRelationships.Clear();

        }

        public bool Contains(DbForeignKey item)
        {

            return myRelationships.Contains(item);

        }

        public bool Remove(DbForeignKey item)
        {

            return myRelationships.Remove(item);

        }

        public void TrimExcess()
        {

            myRelationships.TrimExcess();

        }

        public void Validate()
        {

            if (myRelationships.Count == 1)
            {

                if (!myRelationships[0].CheckValidatity())
                    myRelationships.RemoveAt(0);

            }
            else if (myRelationships.Count > 1)
            {

                Queue<DbForeignKey> RelationshpsToRemove = new Queue<DbForeignKey>();

                foreach (DbForeignKey Item in myRelationships)
                {

                    if (!Item.CheckValidatity())
                    {

                        RelationshpsToRemove.Enqueue(Item);

                    }

                }

                while (RelationshpsToRemove.Count > 0)
                {

                    myRelationships.Remove(RelationshpsToRemove.Dequeue());

                }

            }

        }

        public IEnumerator<DbForeignKey> GetEnumerator()
        {

            return myRelationships.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myRelationships.GetEnumerator();

        }
    }

}
