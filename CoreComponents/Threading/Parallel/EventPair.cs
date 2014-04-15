using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Parallel
{
    
    public class EventPair
    {

        Event myEvent;

        PublicEvent myPublicEvent;

        public EventPair()
        {

            myEvent = new Event();

            myPublicEvent = new PublicEvent(myEvent);

        }

        public Event Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicEvent PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

}
