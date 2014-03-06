using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{

    public class SpaceIndentationLevelBuilder : ReadonlyValueContainer<string>
    {
        
        public SpaceIndentationLevelBuilder() : base("")
        {
        }

        public SpaceIndentationLevelBuilder(SpaceIndentationLevelBuilder TheSpaceIndentationLevelBuilder)
        {

            myValue = TheSpaceIndentationLevelBuilder.Value + " ";

        }

        public string Value
        {

            get
            {

                return myValue;

            }

        }

        public SpaceIndentationLevelBuilder AddSpace()
        {

            return new SpaceIndentationLevelBuilder(this);

        }

    }

}
