using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{

    public class SingleTagElement : BaseElement, IAppendTo
    {

        protected bool myTerminate;

        //Tag Types

        public SingleTagElement()
        {
        }

        public SingleTagElement(string TheName)
        {

            myName = TheName;

        }

        public SingleTagElement(string TheName, bool Terminate)
        {

            myName = TheName;

            myTerminate = Terminate;

        }

        public SingleTagElement(string TheName, IDictionary<string, object> TheAttributes) : base(TheName, TheAttributes)
        {
        }

        public bool Terminate
        {

            get
            {

                return myTerminate;

            }
            set
            {

                myTerminate = value;

            }

        }

        public void End(StringBuilder TheSB)
        {

            if(myTerminate)
                TheSB.AppendLine(" />");
            else
                TheSB.AppendLine(">");

        }

        public void AppendTo(StringBuilder TheSB)
        {

            Start(TheSB);

            AppendAttributes(TheSB);

            End(TheSB);

        }

        public void AppendTo(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation)
        {

            TheSB.Append(TheIndentation);

            AppendTo(TheSB);

        }

        public override string ToString()
        {

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            AppendTo(SB);

            string Result = SB.ToString();

            StringBuilderPool.Put(SB);

            return Result;

        }

    }

}
