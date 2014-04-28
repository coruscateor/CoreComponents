using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Text;

namespace CoreComponents.W3Etc
{

    public class MultiTagElement : BaseElement, IAppend
    {

        protected object myContents;

        public MultiTagElement()
        {
        }

        public MultiTagElement(string TheName) : base(TheName)
        {
        }

        public MultiTagElement(string TheName, object TheContents)
            : base(TheName)
        {

            myContents = TheContents;

        }

        public MultiTagElement(string TheName, IDictionary<string, object> TheAttributes) : base(TheName, TheAttributes)
        {
        }

        public MultiTagElement(string TheName, IDictionary<string, object> TheAttributes, object TheContents) : base(TheName, TheAttributes)
        {

            myContents = TheContents;

        }

        public object Contents
        {

            get
            {

                return myContents;

            }
            set
            {

                myContents = value;

            }

        }

        public bool HasContents
        {

            get
            {

                return myContents != null;

            }

        }

        public bool TryGetContents<T>(out T TheContents)
        {

            if(myContents != null)
            {

                TheContents = (T)myContents;

                return true;

            }

            TheContents = default(T);

            return false;

        }

        public bool TryGetContents<T>(out T TheContents, Func<object, T> TheConversionFunc)
        {

            if(myContents != null)
            {

                TheContents = TheConversionFunc(myContents);

                return true;

            }

            TheContents = default(T);

            return false;

        }

        public bool TryGetContents<T>(Action<T> TheValueAction)
        {

            if(myContents != null)
            {

                TheValueAction((T)myContents);

                return true;

            }

            return false;

        }

        public bool TryGetContents<T>(Action<T> TheValueAction, Func<object, T> TheConversionFunc)
        {

            if(myContents != null)
            {

                TheValueAction(TheConversionFunc(myContents));

                return true;

            }

            return false;

        }

        public void End(StringBuilder TheSB)
        {

            TheSB.Append("</");

            TheSB.Append(myName);

            TheSB.AppendLine(">");

        }

        public void End(string TheIndentation, StringBuilder TheSB)
        {

            TheSB.Append(TheIndentation);

            Append(TheSB);

        }

        public void Append(StringBuilder TheSB)
        {

            Append(TheSB, new TabIndentationLevelBuilder());

        }

        public void Append(StringBuilder TheSB, TabIndentationLevelBuilder TheIndentation)
        {

            TheSB.Append(TheIndentation);

            Start(TheSB);

            AppendAttributes(TheSB);

            TheSB.AppendLine(">");

            if(myContents != null)
            {

                if(myContents is IAppend)
                {

                    ((IAppend)myContents).Append(TheSB, TheIndentation.Add());

                }
                else if(myContents is IEnumerable<IAppend>)
                {

                    IEnumerable<IAppend> Items = (IEnumerable<IAppend>)myContents;

                    TabIndentationLevelBuilder Next = TheIndentation.Add();

                    foreach(var Item in Items)
                    {

                        Item.Append(TheSB, Next);

                    }

                }
                else if(myContents is IEnumerable<object>)
                {

                    IEnumerable<object> Items = (IEnumerable<object>)myContents;

                    TabIndentationLevelBuilder Next = TheIndentation.Add();

                    foreach(var Item in Items)
                    {

                        if(Item is IAppend)
                        {

                            ((IAppend)Item).Append(TheSB, Next);

                        }
                        else
                        {

                            TheSB.Append(Next);

                            TheSB.Append(Item);

                        }

                    }

                }
                else
                {

                    TheSB.Append(TheIndentation.Add());

                    TheSB.Append(myContents);

                }

            }

            TheSB.Append(TheIndentation);

            End(TheSB);

        }

        public void WriteTo(Stream TheStream)
        {

            WriteTo(new StreamWriter(TheStream));

        }

        public void WriteTo(StreamWriter TheStreamWriter)
        {

            TheStreamWriter.Write(ToString());

        }

        public void WriteTo(string ThePath)
        {

            WriteTo(new StreamWriter(ThePath, false));

        }

        public override string ToString()
        {

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            Append(SB);

            string Result = SB.ToString();

            StringBuilderPool.Put(SB);

            return Result;

        }

    }

}
