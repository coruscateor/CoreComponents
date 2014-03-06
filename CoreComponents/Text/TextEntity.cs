using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 0162

namespace CoreComponents.Text
{

	public abstract class TextEntity : ITextEntity
	{

        public const string constQuote = "\"";

        public const string constLine = "\n";

        public const string constLineCr = "\r\n";

        public const string SPACE = " ";

        public delegate void AppendsString(StringBuilder SB);

        public static readonly string OSSeperator;

        static TextEntity()
        {
            //string[] s; // = new string[]();

            //List<string> l = new List<string>;

            //l.

            OperatingSystem OS = Environment.OSVersion;

            switch (OS.Platform)
            {

                case PlatformID.Win32NT:

                    OSSeperator = "\\";

                    break;

                case PlatformID.Win32S:

                    goto case PlatformID.Win32NT;

                    break;

                case PlatformID.Win32Windows:

                    goto case PlatformID.Win32NT;

                    break;

                case PlatformID.WinCE:

                    goto case PlatformID.Win32NT;

                    break;

                case PlatformID.Xbox:

                    goto case PlatformID.Win32NT;

                    break;

                default:

                    OSSeperator = "/";

                    break;

            }

        }

		public TextEntity()
		{
		}
		
		protected abstract void Append(StringBuilder SB);
		

		
        #region ITextEntity Members

        public virtual void AppendTo(StringBuilder SB)
        {
            Append(SB);
        }

        #endregion


        public override string ToString()
        {

            StringBuilder SB = new StringBuilder();

            Append(SB);

            return SB.ToString();

        }
		
		public static bool HasLength(string Item)
		{
			
			return Item.Length > 0;
			
		}

        public static void Clear(StringBuilder SB)
        {

            SB.Remove(0, SB.Length);
            
        }

        public static void OSSepertior(StringBuilder SB)
        {

            SB.Append(OSSeperator);

        }

        public static void OSSepertiorL(StringBuilder SB)
        {

            SB.AppendLine(OSSeperator);

        }

        public static void AddSpace(StringBuilder SB)
        {

            SB.Append(SPACE);

        }

        public static void AddSpaceL(StringBuilder SB)
        {

            SB.AppendLine(SPACE);

        }

        public static void Tab(StringBuilder SB)
        {

            SB.Append("\t");

        }

        public static void TabL(StringBuilder SB)
        {

            SB.AppendLine("\t");

        }

        public static void Equals(StringBuilder SB)
        {

            SB.Append("=");

        }

        public static void SpacedEquals(StringBuilder SB)
        {

            SB.Append(" = ");

        }

        public static void AppendAttribute(object Key, object Value, StringBuilder SB)
        {

            AddSpace(SB);

            SB.Append(Key);

            Equals(SB);

            InQuotes(Value, SB);

        }

        public static void AppendSQAttribute(object Key, object Value, StringBuilder SB)
        {

            AddSpace(SB);

            SB.Append(Key);

            Equals(SB);

            InSQuotes(Value, SB);

        }

        public static void Comma(StringBuilder SB)
        {

            SB.Append(",");

        }

        public static void CommaS(StringBuilder SB)
        {

            SB.Append(", ");

        }

        public static void SQuote(StringBuilder SB)
        {

            SB.Append("\'");

        }

        public static void Quote(StringBuilder SB)
        {

            SB.Append(constQuote);

        }

        public static void InQuotes(object Item, StringBuilder SB)
        {

            SB.Append("\"");

            SB.Append(Item);

            SB.Append("\"");

        }

        public static void InSQuotes(object Item, StringBuilder SB)
        {

            SB.Append("\'");

            SB.Append(Item);

            SB.Append("\'");

        }

        public static void DoubleQuote(StringBuilder SB)
        {

            SB.Append(@"""");

        }

        public static void InBrackets(object Item, StringBuilder SB)
        {

            SB.Append("(");

            SB.Append(Item);

            SB.Append(")");

        }

        public static void Dot(StringBuilder SB)
        {

            SB.Append(".");

        }

        public static void OpenBracket(StringBuilder SB)
        {

            SB.Append("(");

        }

        public static void CloseBracket(StringBuilder SB)
        {

            SB.Append(")");

        }

        public static void OpenBracketL(StringBuilder SB)
        {

            SB.AppendLine("(");

        }

        public static void CloseBracketL(StringBuilder SB)
        {

            SB.AppendLine(")");

        }

        public static void CloseBracketSemiColon(StringBuilder SB)
        {

            SB.Append(");");

        }

        public static void CloseBracketSemiColonL(StringBuilder SB)
        {

            SB.AppendLine(");");

        }

        public static void SemiColon(StringBuilder SB)
        {

            SB.Append(";");

        }

        public static void SemiColonL(StringBuilder SB)
        {

            SB.AppendLine(";");

        }

        public static void InBrackets(StringBuilder SB, params object[] items)
        {

            PutInBrackets(SB, items, CommaS);

        }

        public static void InBrackets(StringBuilder SB, Array items)
        {

            PutInBrackets(SB, items, Comma);

        }

        public static void InBracketsS(StringBuilder SB, params object[] items)
        {
            
            PutInBrackets(SB, items, CommaS);

        }

        public static void InBracketsS(StringBuilder SB, Array items)
        {

            PutInBrackets(SB, items, CommaS);

        }

        protected static void PutInBrackets(StringBuilder SB, Array items, AppendsString AddComma)
        {

            OpenBracket(SB);

            int itemlength = items.Length - 1;

            int i = 0;

            foreach(var Obj in items)
            {

                SB.Append(Obj);

                i++;

                if (i <= itemlength)
                {

                    AddComma(SB);

                }
            }

            CloseBracket(SB);

        }

        public static void PointInBrackets(StringBuilder SB, System.Drawing.Point p)
        {

            TextEntity.Clear(SB);

            TextEntity.OpenBracket(SB);

            //precision
            SB.Append(p.X);

            TextEntity.Comma(SB);

            //scale
            SB.Append(p.Y);

            TextEntity.CloseBracket(SB);

        }

        public static void SpacePadSingle(StringBuilder SB, string ItemToPad)
        {

            SB.Append(SPACE);

            SB.Append(ItemToPad);

            SB.Append(SPACE);

        }

        public static void SpacePadSingleLeft(StringBuilder SB, string ItemToPad)
        {

            SB.Append(SPACE);

            SB.Append(ItemToPad);

        }

        public static void SpacePadSingleRight(StringBuilder SB, string ItemToPad)
        {

            SB.Append(ItemToPad);

            SB.Append(SPACE);

        }

        public static List<char> ToCharList(string str)
        {

            return new List<char>(str.ToCharArray());

        }

        public static List<char> ToCharList(char[] chrlist)
        {

            return new List<char>(chrlist);

        }

        public static string ToString(char[] chrlist)
        {

            return new StringBuilder().Append(chrlist).ToString();

        }

        public static StringBuilder ToSB(char[] chrlist)
        {

            return new StringBuilder().Append(chrlist);

        }

	}

}
