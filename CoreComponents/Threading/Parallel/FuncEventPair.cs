using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Parallel
{

    public class FuncEventPair<TReturn>
    {

        ActionEvent<TReturn> myEvent;

        PublicActionEvent<TReturn> myPublicEvent;

        public FuncEventPair()
        {

            myEvent = new ActionEvent<TReturn>();

            myPublicEvent = new PublicActionEvent<TReturn>(myEvent);

        }

        public ActionEvent<TReturn> Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicActionEvent<TReturn> PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

    public class FuncEventPair<TParameter, TReturn>
    {

        FuncEvent<TParameter, TReturn> myEvent;

        PublicFuncEvent<TParameter, TReturn> myPublicEvent;

        public FuncEventPair()
        {

            myEvent = new FuncEvent<TParameter, TReturn>();

            myPublicEvent = new PublicFuncEvent<TParameter, TReturn>(myEvent);

        }

        public FuncEvent<TParameter, TReturn> Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicFuncEvent<TParameter, TReturn> PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

    public class FuncEventPair<TP1, TP2, TReturn>
    {

        FuncEvent<TP1, TP2, TReturn> myEvent;

        PublicFuncEvent<TP1, TP2, TReturn> myPublicEvent;

        public FuncEventPair()
        {

            myEvent = new FuncEvent<TP1, TP2, TReturn>();

            myPublicEvent = new PublicFuncEvent<TP1, TP2, TReturn>(myEvent);

        }

        public FuncEvent<TP1, TP2, TReturn> Event
        {

            get
            {

                return myEvent;

            }

        }

        public PublicFuncEvent<TP1, TP2, TReturn> PublicEvent
        {

            get
            {

                return myPublicEvent;

            }

        }

    }

}
