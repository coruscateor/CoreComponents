using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Parallel
{
    
    public class ActionEventPair
    {

        ActionEvent myEvent;

        PublicActionEvent myPublicEvent;

        public ActionEventPair()
        {

            myEvent = new ActionEvent();

            myPublicEvent = new PublicActionEvent(myEvent);

        }

        public ActionEvent Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicActionEvent PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

    public class ActionEventPair<T>
    {

        ActionEvent<T> myEvent;

        PublicActionEvent<T> myPublicEvent;

        public ActionEventPair()
        {

            myEvent = new ActionEvent<T>();

            myPublicEvent = new PublicActionEvent<T>(myEvent);

        }

        public ActionEvent<T> Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicActionEvent<T> PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

    public class ActionEventPair<T1, T2>
    {

        ActionEvent<T1, T2> myEvent;

        PublicActionEvent<T1, T2> myPublicEvent;

        public ActionEventPair()
        {

            myEvent = new ActionEvent<T1, T2>();

            myPublicEvent = new PublicActionEvent<T1, T2>(myEvent);

        }

        public ActionEvent<T1, T2> Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicActionEvent<T1, T2> PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

}
