using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public sealed class SRandom : Random
    {

        public SRandom() : base()
        {
        }

        public SRandom(int seed) : base(seed)
        {
        }

    }

}
