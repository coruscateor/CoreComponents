using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public sealed class SObject : IEquatable<SObject>
    {

        public bool Equals(SObject other)
        {

            return this == other;

        }

    }

}
