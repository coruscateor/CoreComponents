using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Markup.HTML.Attributes
{

    public interface IBaseAttributes
    {

        string href
        {

            get;
            set;

        }

        string target
        {
            get;
            set;
        }

    }

    public class BaseAttributes : IBaseAttributes
    {

        protected string myhref;
        protected string mytarget;

        public string href
        {

            get
            {

                return myhref;

            }
            set
            {

                myhref = value;

            }

        }

        public string target
        {

            get
            {

                return mytarget;

            }
            set
            {

                mytarget = value;

            }

        }

        //        href  	URL  	Specifies a base URL for all relative URLs on a page  	STF
        //target 	_blank
        //_parent
        //_self
        //_top
        //framename 	Specifies

    }

    public static class targetOptions
    {
        public const string _blank = "_blank";
        public const string _parent = "_parent";
        public const string _self = "_self";
        public const string _top = "_top";
    }
}
