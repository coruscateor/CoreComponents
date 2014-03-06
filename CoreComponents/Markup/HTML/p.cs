using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Markup.HTML.Attributes;

namespace CoreComponents.Markup.HTML
{
    public class p : HTMLEventdBaseEntity<StandardAttributes, StandardEvents>
    {

        public p() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "p";
            }
        } 

    }
}
