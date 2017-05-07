using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text.Extensions
{
    
    public static class StringBuilderExtensions
    {

        public static string ToStringClear(this StringBuilder TheSB)
        {

            try
            {
                
                return TheSB.ToString();

            }
            finally
            {

                TheSB.Clear();

            }

        }

    }

}
