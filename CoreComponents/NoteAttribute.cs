using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class NoteAttribute : Attribute
    {
        
        protected string myNote;

        public NoteAttribute(string TheNote)
        {

            myNote = TheNote;

        }

        public string Note
        {

            get
            {

                return myNote;

            }

        }

    }

}
