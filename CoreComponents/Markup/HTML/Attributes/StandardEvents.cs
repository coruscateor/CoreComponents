using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Markup.HTML.Attributes
{
    public class StandardEvents : TextEntity
    {

        protected string myonclick;
        protected string myondblclick;
        protected string myonmousedown;
        protected string myonmousemove;
        protected string myonmouseout;
        protected string myonmouseover;
        protected string myonkeydown;
        protected string myonkeypress;
        protected string myonkeyup;

        public string onclick
        {

            get
            {

                return myonclick;

            }
            set
            {

                myonclick = value;

            }

        }

        public string ondblclick
        {

            get
            {

                return myondblclick;

            }
            set
            {

                myondblclick = value;

            }

        }

        public string onmousedown
        {

            get
            {

                return myonmousedown;

            }
            set
            {

                myonmousedown = value;

            }


        }

        public string onmousemove
        {

            get
            {

                return myonmousemove;

            }
            set
            {

                myonmousemove = value;

            }


        }

        public string onmouseout
        {

            get
            {

                return myonmouseout;

            }
            set
            {

                myonmouseout = value;

            }

        }

        public string onmouseover
        {

            get
            {

                return myonmouseover;

            }
            set
            {

                myonmouseover = value;

            }

        }

        public string onkeydown
        {

            get
            {

                return myonkeydown;

            }
            set
            {

                myonkeydown = value;

            }

        }

        public string onkeypress
        {

            get
            {

                return myonkeypress;

            }
            set
            {

                myonkeypress = value;

            }

        }

        public string onkeyup
        {

            get
            {

                return myonkeyup;

            }
            set
            {

                myonkeyup = value;

            }

        }

//        onclick  	script  	Script to be run on a mouse click  	STF
//ondblclick 	script 	Script to be run on a mouse double-click 	STF
//onmousedown 	script 	Script to be run when mouse button is pressed 	STF
//onmousemove 	script 	Script to be run when mouse pointer moves 	STF
//onmouseout 	script 	Script to be run when mouse pointer moves out of an element 	STF
//onmouseover 	script 	Script to be run when mouse pointer moves over an element 	STF
//onmouseup 	script 	Script to be run when mouse button is released 	STF
//onkeydown 	script 	Script to be run when a key is pressed 	STF
//onkeypress 	script 	Script to be run when a key is pressed and released 	STF
//onkeyup 	script 	Script to be run when a key is released 	STF


        protected override void Append(StringBuilder SB)
        {

        }
    }
}
