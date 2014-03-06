using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{
    
    public class IndentationLevelBuilder : ReadonlyValueContainer<string>
    {

        public IndentationLevelBuilder() : base("")
        {
        }
        
        public IndentationLevelBuilder(IndentationType TheIndentationType)
        {

            if(TheIndentationType == IndentationType.Space)
            {

                myValue = " "; ;

            }
            else
            {

                myValue = "\t";

            }

        }

        public IndentationLevelBuilder(IndentationLevelBuilder TheIndentationLevelBuilder, IndentationType TheIndentationType)
        {

            if(TheIndentationType == IndentationType.Space)
            {

                myValue = TheIndentationLevelBuilder.Value + " "; ;

            }
            else
            {

                myValue = TheIndentationLevelBuilder.Value + "\t";

            }

        }

        public string Value
        {

            get
            {

                return myValue;

            }

        }

        public IndentationLevelBuilder AddSpace()
        {

            return new IndentationLevelBuilder(this, IndentationType.Space);

        }

        public IndentationLevelBuilder AddTab()
        {

            return new IndentationLevelBuilder(this, IndentationType.Tab);

        }

        public IndentationLevelBuilder Add(IndentationType TheIndentationType)
        {

            if(TheIndentationType == IndentationType.Space)
                return new IndentationLevelBuilder(this, IndentationType.Space);

            return new IndentationLevelBuilder(this, IndentationType.Tab);

        }

    }

}
