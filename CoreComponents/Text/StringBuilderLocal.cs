using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Text
{

    public static class StringBuilderLocal
    {

        static ThreadLocal<StringBuilder> myLocalSB = new ThreadLocal<StringBuilder>();

        public static StringBuilder Get()
        {

            return myLocalSB.Value;

        }

        public bool IsCreated
        {

            get
            {

                return myLocalSB.IsValueCreated;

            }

        }
        
        [WARNING]
        [CAUTION]
        [DANGER]
        public void Dispose()
        {

            myLocalSB.Dispose();

            myLocalSB = null;

        }

        [WARNING]
        [CAUTION]
        [DANGER]
        public void UnDispose()
        {

            if(myLocalSB != null)
                throw new Exception("ThreadLocal<StringBuilder> already exists");

            myLocalSB = new ThreadLocal<StringBuilder>();

        }

    }

}
