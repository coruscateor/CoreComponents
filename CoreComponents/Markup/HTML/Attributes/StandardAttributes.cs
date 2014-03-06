using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Markup.HTML.Attributes
{
    public class StandardAttributes : TextEntity
    {

        protected string myClass;
        protected dirOptions mydir;
        protected string myid;
        protected string mylang;
        protected string mystyle;
        protected string mytitle;
        protected string myxmllang;

        //class - Specifies a classname for an element
        public string Class
        {

            get
            {

                return myClass;

            }
            set
            {

                myClass = value;

            }

        }

        //Specifies the text direction for the content in an element
        public dirOptions dir
        {

            get
            {

                return mydir;

            }
            set
            {

                mydir = value;

            }

        }


        //Specifies a unique id for an element
        public string id
        {

            get
            {

                return myid;

            }
            set
            {

                myid = value;

            }

        }

        //Specifies a language code for the content in an element
        public string lang
        {

            get
            {

                return mylang;

            }
            set
            {

                mylang = value;

            }

        }

        //Specifies an inline style for an element
        public string style
        {

            get
            {

                return mystyle;

            }
            set
            {

                mystyle = value;

            }

        }

        //Specifies extra information about an element
        public string title
        {

            get
            {

                return mytitle;

            }
            set
            {

                mytitle = value;

            }

        }

        //xml:lang - Specifies a language code for the content in an element, in XHTML documents
        public string xmllang
        {

            get
            {

                return myxmllang;

            }
            set
            {

                myxmllang = value;

            }

        }


        protected override void Append(StringBuilder SB)
        {
            throw new NotImplementedException();
        }
    }

    public enum dirOptions
    {

        rtl,
        ltr 

    }
}
