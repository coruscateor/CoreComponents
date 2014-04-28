using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.W3Etc
{
    
    [AttributeUsage(AttributeTargets.Method)]
    public class ObsoleteTagAttribute : Attribute 
    {

        protected string mySinceVersion;

        public ObsoleteTagAttribute(int TheVersion)
        {

            mySinceVersion = TheVersion.ToString();

        }

        public ObsoleteTagAttribute(float TheVersion)
        {

            mySinceVersion = TheVersion.ToString();

        }

        public ObsoleteTagAttribute(Version TheVersion)
        {

            mySinceVersion = TheVersion.ToString();

        }

        public ObsoleteTagAttribute(string SinceVersion)
        {

            mySinceVersion = SinceVersion;

        }

        public string SinceVersion
        {

            get
            {

                return mySinceVersion;

            }

        }

        public bool TryGetVersion(out Version TheVersion)
        {

            Version ParsedVersion;

            if(Version.TryParse(mySinceVersion, out ParsedVersion))
            {

                TheVersion = ParsedVersion;

                return true;

            }

            TheVersion = null;

            return false;

        }

        public bool TryGetVersion(Action<Version> TheVersionAction)
        {

            Version ParsedVersion;

            if(Version.TryParse(mySinceVersion, out ParsedVersion))
            {

                TheVersionAction(ParsedVersion);

                return true;

            }

            return false;

        }

    }

}
