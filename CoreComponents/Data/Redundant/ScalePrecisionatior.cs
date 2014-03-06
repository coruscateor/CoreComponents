using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CoreComponents.Text;

namespace CoreComponents.Data
{
    public static class ScalePrecisionatior
    {

        static StringBuilder SB = new StringBuilder();

        public static string get(int precision, int scale)
        {

            TextEntity.Clear(SB);

            TextEntity.OpenBracket(SB);

            SB.Append(precision);

            TextEntity.Comma(SB);

            SB.Append(scale);

            TextEntity.CloseBracket(SB);

            return SB.ToString();

        }

        /*
        public string get(Point p)
        {

            TextEntity.Clear(SB);

            TextEntity.OpenBracket(SB);

            //precision
            SB.Append(p.X);

            TextEntity.Comma(SB);

            //scale
            SB.Append(p.Y);

            TextEntity.CloseBracket(SB);

            return SB.ToString();

        }
        */
        //public static

    }
}
