using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{
    public abstract class IsolatedTimer : IsolatedThreadBase
    {

        private Timer myTimer;

        private object myState;

        public IsolatedTimer() 
        {

            myTimer = new Timer(RunMain);

        }

        public IsolatedTimer(int TheDueTime, int ThePeriod, object TheState = null)
        {

            myTimer = new Timer(RunMain, TheState, TheDueTime, ThePeriod);

        }

        public IsolatedTimer(long TheDueTime, long ThePeriod, object TheState = null)
        {

            myTimer = new Timer(RunMain, TheState, TheDueTime, ThePeriod);

        }

        public IsolatedTimer(TimeSpan TheDueTime, TimeSpan ThePeriod, object TheState = null)
        {

            myTimer = new Timer(RunMain, TheState, TheDueTime, ThePeriod);

        }

        public IsolatedTimer(uint TheDueTime, uint ThePeriod, object TheState = null)
        {

            myTimer = new Timer(RunMain, TheState, TheDueTime, ThePeriod);

        }

        protected abstract void Main();

        private void RunMain(object TheState) 
        {

            //Lock Here if needed
            //Also some contention detection would be good too.

            myState = TheState;

            Main();

            //Unlock here

        }

        public Timer TheTimer
        {

            get
            {

                return myTimer;

            }

        }

    }
}
