using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{

    public class TabIndentationLevelBuilder : ReadonlyValueContainer<string>
    {

        public TabIndentationLevelBuilder()
        {

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

        public TabIndentationLevelBuilder AddTab()
        {

            return new TabIndentationLevelBuilder(this);

        }

    }

}
