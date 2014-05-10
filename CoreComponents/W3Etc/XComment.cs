using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{
    
    public class XComment : IAppendTo
    {

        protected string myValue;

        public XComment()
        {

            myValue = "";

        }

        public XComment(string TheValue)
        {

            myValue = TheValue;

        }

        public string Value
        {

            get
            {

                return myValue;

            }
            set
            {

                if(value == null)
                {

                    myValue = "";

                    return;

                }

                myValue = value;

            }

        }

        public void AppendTo(StringBuilder TheSB)
        {

            TheSB.Append("<--");

            TheSB.Append(myValue);

            TheSB.Append("-->");

        }

        public void AppendTo(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation)
        {

            TheSB.Append(TheIndentation.Value);

            AppendTo(TheSB);

        }
        
    }

}
