using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    public class VersionAttribute : Attribute
    {

        protected string myVersionString;

        public VersionAttribute(int TheVersion)
        {

            myVersionString = TheVersion.ToString();

        }

        public VersionAttribute(float TheVersion)
        {

            myVersionString = TheVersion.ToString();

        }

        public VersionAttribute(Version TheVersion)
        {

            myVersionString = TheVersion.ToString();

        }

        public VersionAttribute(string TheVersionString)
        {

            myVersionString = TheVersionString;

        }

        public string VersionString
        {

            get
            {

                return myVersionString;

            }

        }

        public bool TryGetVersion(out string TheVersion)
        {

            TheVersion = myVersionString;

            return TheVersion != null;

        }

        public bool TryGetVersion(out Version TheVersion)
        {

            Version ParsedVersion;

            if(Version.TryParse(myVersionString, out ParsedVersion))
            {

                TheVersion = ParsedVersion;

                return true;

            }

            TheVersion = null;

            return false;

        }

    }

}
