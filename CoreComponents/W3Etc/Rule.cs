using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{
    
    public class Rule : DynamicObject, IAppendTo
    {

        protected List<object> mySelectors = new List<object>();

        protected Dictionary<string, object> myDeclarations = new Dictionary<string, object>();

        public Rule()
        {
        }

        public List<object> Selectors
        {

            get
            {

                return mySelectors;

            }

        }

        public Dictionary<string, object> Declarations
        {

            get
            {

                return myDeclarations;

            }

        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {

            return myDeclarations.Keys;

        }

        public override bool TryGetMember(GetMemberBinder TheBinder, out object TheResult)
        {

            object Value;

            if(myDeclarations.TryGetValue(TheBinder.Name, out Value))
            {

                TheResult = Value;

                return true;

            }

            throw new ArgumentException("Property with the provided name does not exist");

        }

        public override bool TrySetMember(SetMemberBinder TheBinder, object TheValue)
        {

            if(!myDeclarations.ContainsKey(TheBinder.Name))
            {

                myDeclarations.Add(TheBinder.Name, TheValue);

            }
            else
            {

                myDeclarations[TheBinder.Name] = TheValue;

            }

            return true;

        }

        public override bool TryDeleteMember(DeleteMemberBinder TheBinder)
        {

            return myDeclarations.Remove(TheBinder.Name);

        }

        public void AppendTo(StringBuilder TheSB)
        {

            AppendTo(TheSB, new TabIndentationLevelBuilder());

        }

        public void AppendTo(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation)
        {

            TheSB.Append(TheIndentation);

            if(mySelectors.Count < 1)
                throw new Exception("No selectors present in Rule");

            if(mySelectors.Count == 1)
            {

                AppendItem(mySelectors[0], TheSB);

            }
            else
            {

                int i = 0;

                do
                {

                    AppendItem(mySelectors[i], TheSB);

                    ++i;

                    if(i < mySelectors.Count)
                        TheSB.Append(" ,");
                    else
                        break;

                }
                while(true);

            }

            TheSB.AppendLine();

            TheSB.Append(TheIndentation);

            TheSB.Append('{');

            TheSB.AppendLine();

            TheSB.Append(TheIndentation);

            TheSB.AppendLine();

            TabIndentationLevelBuilder NextLevel = TheIndentation.Add();

            foreach(var Item in myDeclarations)
            {

                TheSB.Append(NextLevel);

                TheSB.Append(Item);

                TheSB.Append(": ");

                AppendItem(Item.Value, TheSB);

                TheSB.Append(';');

                TheSB.AppendLine();

            }

            TheSB.Append(TheIndentation);

            TheSB.AppendLine();

            TheSB.Append(TheIndentation);

            TheSB.Append('}');

            TheSB.AppendLine();

            TheSB.Append(TheIndentation);

            TheSB.AppendLine();

        }

        protected void AppendItem(object TheItem, StringBuilder TheSB)
        {

            if(TheItem is IAppendTo)
            {

                ((IAppendTo)TheItem).AppendTo(TheSB);

            }
            else
            {

                TheSB.Append(TheItem);

            }

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
