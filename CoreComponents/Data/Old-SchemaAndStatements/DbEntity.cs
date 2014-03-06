using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Characters;

namespace CoreComponents.Data.SchemaAndStatements
{

    public abstract class DbEntity : BaseDbEntity
    {

        public DbEntity()
        {
        }

        public DbEntity(string Name)
        {

            myName = Name;

        }

        public DbEntity(string Name, string Description)
        {

            myName = Name;

            myDescription = Description;

        }

        /*
        void OnNameChanged()
        {

            if (NameChanged != null)
                NameChanged(new SenderEventArgs<DbEntity>(this));

        }
        */

        public new string Name
        {
            
            get
            {

                return myName;

            }
            set
            {

                myName = value;

                //OnNameChanged();

            }

        }

        public new string Description
        {
            /*
            get
            {

                return myDescription;

            }
            */

            set
            {

                myDescription = value;

            }

        }

    }
}
