using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{
    
    public class XComment : IAppend
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

        public void Append(StringBuilder TheSB)
        {

            TheSB.Append("<--");

            TheSB.Append(myValue);

            TheSB.Append("-->");

        }

        public void Append(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation)
        {

            TheSB.Append(TheIndentation.Value);

            Append(TheSB);

        }

    }

}
