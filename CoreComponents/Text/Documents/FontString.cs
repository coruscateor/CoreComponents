using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text.Documents
{

    public class FontString<TFont>
    {

        protected TFont myFont;

        protected string myString;

        public FontString()
        { 
        }

        public FontString(TFont TheFont)
        {

            myFont = TheFont;

        }

        public TFont Font
        {

            get
            {

                return myFont;

            }
            set
            {

                myFont = value;

            }

        }

        public string String
        {

            get
            {

                return myString;

            }
            set
            {

                myString = value;

            }

        }

        public bool HasString
        {

            get
            {

                return myString != null && myString.Length > 0;

            }

        }

    }

}
