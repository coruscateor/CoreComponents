using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Parameters
{
    public class OptionalParamList : OptionalList<string, bool>
    {

        public OptionalParamList(params string[] Params)
        {

            myItemList = new Dictionary<string, bool>();

            foreach (string s in Params)
            {

                myItemList.Add(s, false);

            }            

        }

    }
}
