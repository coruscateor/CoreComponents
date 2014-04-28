using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{

    public struct SpaceIndentationLevelBuilder
    {

        string myValue;

        public SpaceIndentationLevelBuilder(bool Start = false)
        {

            if(Start)
                myValue = " ";
            else
                myValue = "";

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

        public SpaceIndentationLevelBuilder Add()
        {

            return new SpaceIndentationLevelBuilder(this);

        }

        public override string ToString()
        {

            return myValue;

        }

    }

}
