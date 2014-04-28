using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{

    public struct TabIndentationLevelBuilder
    {

        string myValue;

        public TabIndentationLevelBuilder(bool Start = false)
        {

            if(Start)
                myValue = "\t";
            else
                myValue = "";

        }
        
        public TabIndentationLevelBuilder(TabIndentationLevelBuilder TheTabIndentationLevelBuilder)
        {

            myValue = TheTabIndentationLevelBuilder.Value + "\t";

        }

        public string Value
        {

            get
            {

                return myValue;

            }

        }

        public TabIndentationLevelBuilder Add()
        {

            return new TabIndentationLevelBuilder(this);

        }

        public override string ToString()
        {

            return myValue;

        }

    }

}
