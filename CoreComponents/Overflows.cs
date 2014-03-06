using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public static class Overflows
    {

        //Determines if and by how much a secondry value is over Int32.MaxValue if a primary and secondary value are to be added together.

        public static bool CheckIfIsOver(int ThePrimayValue, int TheSecondaryValue, out int OverByHowmuch) //, out int UnderByHowmuch
        {

            int PrimaryFromLimit = int.MaxValue - (int.MaxValue - ThePrimayValue);

            if(TheSecondaryValue > PrimaryFromLimit)
            {

                OverByHowmuch = PrimaryFromLimit - TheSecondaryValue;

                //UnderByHowmuch = TheSecondaryValue - OverByHowmuch;

                return true;

            }

            OverByHowmuch = -1;

            //UnderByHowmuch = -1;

            return false;

        }

    }
    
}
