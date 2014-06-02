using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Parallel
{

    public abstract class BasePublicEvent<TEvent, TDelegate>
        where TEvent : BaseEvent<TDelegate>
        where TDelegate : class
    {

        protected TEvent myEvent;

        public BasePublicEvent(TEvent TheEvent)
        {

            myEvent = TheEvent;

        }

        public int Count
        {

            get
            {

                return myEvent.Count;

            }

        }

        public Exception Exception
        {

            get
            {

                return myEvent.Exception;

            }

        }

        public bool TryGetException(out Exception TheException)
        {

            Exception Item;

            if(myEvent.TryGetException(out TheException))
            {

                Item = TheException;

                return true;

            }

            Item = null;

            return false;

        }

        public void TryClearException()
        {

            myEvent.TryClearException();

        }

        public void Add(TDelegate TheAction)
        {

            myEvent.Add(TheAction);

        }

    }

}
