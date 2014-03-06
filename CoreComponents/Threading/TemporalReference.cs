using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Time;

namespace CoreComponents.Threading
{
    
    public class TemporalReference<T> : BaseTemporalReference<T, int, int> where T : class
    {

        public TemporalReference()
        {

            Initalise();

        }

        public override void Set(T TheReference, int TheMillisecondsTimeoutInterval)
        {

            CheckIfActiveOrWaiting();

            TimeOutInterval = TheMillisecondsTimeoutInterval;

            SetRegisteredWaitHandle(ThreadPool.RegisterWaitForSingleObject(mySemaphore, DropReference, null, TheMillisecondsTimeoutInterval, true));

            myTimeSet = Environment.TickCount;

        }

        public void SetSeconds(T TheReference, int TheSecondsTimeoutInterval)
        {

            Set(TheReference, TimeConversions.SecondsToMilliseconds(TheSecondsTimeoutInterval));

        }

        public void SetMinutes(T TheReference, int TheMinutesTimeoutInterval)
        {

            Set(TheReference, TimeConversions.MinutesToMilliseconds(TheMinutesTimeoutInterval));

        }

        public void SetHours(T TheReference, int TheHoursTimeoutInterval)
        {

            Set(TheReference, TimeConversions.HoursToMilliseconds(TheHoursTimeoutInterval));

        }

        public void SetDays(T TheReference, int TheDaysTimeoutInterval)
        {

            Set(TheReference, TimeConversions.HoursToMilliseconds(TheDaysTimeoutInterval));

        }

        public void SetDHMSMs(T TheReference, int TheDaysTimeoutInterval = 0, int TheHoursTimeoutInterval = 0, int TheMinutesTimeoutInterval = 0, int TheSecondsTimeoutInterval = 0, int TheMillisecondsTimeoutInterval = 0)
        {

            Set(TheReference, TimeConversions.DHMSToMilliseconds(TheDaysTimeoutInterval, TheHoursTimeoutInterval, TheMinutesTimeoutInterval, TheSecondsTimeoutInterval) + TheMillisecondsTimeoutInterval);

        }

        public void SetTimeSpan(T TheReference, TimeSpan TheTimeSpan)
        {

            Set(TheReference, TimeConversions.GetMilliseconds(TheTimeSpan));

        }

        public TimeSpan GetTimeSet()
        {

            int CurrentTimeSet = TimeSet;

            return new TimeSpan(CurrentTimeSet);

        }

        public override bool TryGetETD(out int TheETD)
        {

            if(!IsActiveOrWaiting)
            {

                TheETD = -1;

                return false;

            }

            int CurrentTime = Environment.TickCount;

            int CurrentTimeSet = myTimeSet;

            int CurrentTimeOutInterval = TimeOutInterval;

            int OverByHowMuch;

            //int UnderByHowMuch;

            //Check if the tick count has been reset

            if(Overflows.CheckIfIsOver(CurrentTime, CurrentTimeOutInterval, out OverByHowMuch))  //out UnderByHowMuch
            {

                //Move everything back to Int32.MaxValue

                TheETD = CurrentTimeOutInterval - (int.MaxValue - (CurrentTimeSet - OverByHowMuch));

                //(CurrentTime - OverByHowMuch)

                return true;

            }

            //TheETD = TimeSetPlusTimeOut - CurrentTime;

            //The result of the current time minus time when set subtracted from the timeout interval 

            TheETD = CurrentTimeOutInterval - (CurrentTime - CurrentTimeSet);

            return true;

        }

        public bool TryGetETD(out TimeSpan TheETD)
        {

            int ETDResult;

            if(TryGetETD(out ETDResult))
            {

                TheETD = new TimeSpan(ETDResult);

                return true;

            }

            TheETD = TimeSpan.MinValue;

            return false;

        }

    }

}
