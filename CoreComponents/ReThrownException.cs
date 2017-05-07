using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public class ReThrownException : Exception
    {

        public ReThrownException(Exception ex) : base("This Exception was re-thrown", ex)
        {
        }

        public ReThrownException(Exception ex, string message) : base(message, ex)
        {
        }

        public bool TryGetNonReThrown(out Exception ex)
        {

            ex = this;

            var rex = ex.InnerException as ReThrownException;

            while(rex != null)
            {

                var innerEx = rex.InnerException;

                rex = innerEx as ReThrownException;

                if(rex == null && innerEx != null)
                {

                    ex = innerEx;

                    break;

                }

            }

            return ex != null;

        }

        public bool TryGetNonReThrown(out Exception ex, out int levels)
        {

            levels = 0;

            ex = this;

            var rex = ex.InnerException as ReThrownException;

            while(rex != null)
            {

                levels++;

                var innerEx = rex.InnerException;

                rex = innerEx as ReThrownException;

                if(rex == null && innerEx != null)
                {

                    ex = innerEx;

                    break;

                }

            }

            return levels > 0 && ex != null;

        }

    }

}
