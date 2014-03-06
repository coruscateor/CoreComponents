using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.Schema.Administration
{
    public abstract class DbGenerator
    {

        protected StringBuilder mySB;

        public DbGenerator()
        {
        }

        protected virtual void initalise()
        {

            mySB = new StringBuilder();

        }

        protected virtual void Clear()
        {

            TextEntity.Clear(mySB);

        }

        /*
        protected virtual string GenerateText<TDbOwned>(DbTable TDbOwned) where TDbOwned : IAmOwned
        {

            TextEntity.Clear(mySB);

            Generate(Table, mySB);

            return mySB.ToString();

        }
        */
    }
}
