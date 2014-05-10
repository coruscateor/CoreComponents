using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.ComponentModel;

namespace CoreComponents.Time
{

    public delegate void FiniteElapsedEventHandler(FiniteElapsedEventArgs e);

    public class FiniteEmmissionTimer //: IComponent
    {
        uint Limit;
        
        uint CurrentTime = 0;

        Timer TheTime;

        public event FiniteElapsedEventHandler Elapsed;

        public FiniteEmmissionTimer(uint Limit) {

            this.Limit = Limit; 

            TheTime = new Timer();

            TheTime.Elapsed += TheTime_Elapsed; //new ElapsedEventHandler(TheTime_Elapsed);
        
        }

        public FiniteEmmissionTimer(uint Limit, double Interval) {

            this.Limit = Limit;

            TheTime = new Timer(Interval);

            TheTime.Elapsed += TheTime_Elapsed; //new ElapsedEventHandler();
            
        
        }

        void TheTime_Elapsed(object sender, ElapsedEventArgs e)
        {

            CurrentTime++;

            if (Elapsed != null)
                Elapsed(new FiniteElapsedEventArgs(this, e.SignalTime, CurrentTime, Limit));

            //if (Limit <= CurrentTime) {
            if (CurrentTime == Limit)
            {

                //TheTime.Stop();

                //TheTime.Elapsed -= TheTime_Elapsed; //new ElapsedEventHandler();

                Stop();

                Reset();

            }


        }

        public void Start()
        {
            TheTime.Elapsed += TheTime_Elapsed; //new ElapsedEventHandler();

            TheTime.Start();


        }

        public void Stop()
        {

            TheTime.Stop();

            TheTime.Elapsed -= TheTime_Elapsed; //new ElapsedEventHandler();

        }

        public void Reset()
        {
            
            CurrentTime = 0;

        }

        public bool Enabled
        {

            get
            {

                return TheTime.Enabled;

            }
            set
            {

                if (TheTime.Enabled)
                {
                    Stop();

                } else
                {

                    Start();

                }
                
            }

        }

        public double Interval
        {

            get
            {
                return TheTime.Interval;

            }
            set
            {

                TheTime.Interval = value;

            }

        }

        public uint EmitionLimit {

            get {

                return Limit;

            }
            set
            {

                if(!TheTime.Enabled) 
                    Limit = value;

            }
        
        }

        //#region IComponent Members

        //public event EventHandler Disposed;

        //public ISite Site
        //{
        //    get
        //    {
        //        return null;
        //    }
        //    set
        //    {

        //    }
        //}

        //#endregion

        //#region IDisposable Members

        //public void Dispose()
        //{
        //    if (Disposed != null)
        //        Disposed(this, new EventArgs());
        //}

        //#endregion
    }

    public class FiniteElapsedEventArgs : SenderEventArgs<FiniteEmmissionTimer>
    {

        uint _CurrentTime;
        uint _Limit;
        DateTime _SignalTime;

        public FiniteElapsedEventArgs(FiniteEmmissionTimer sender, DateTime SignalTime, uint CurrentTime, uint Limit) : base(sender)
        {

            _CurrentTime = CurrentTime;

            _SignalTime = SignalTime;

            _Limit = Limit;
        
        }

        public uint EmitionLimit
        {

            get
            {

                return _Limit;

            }

        }

        public uint CurrentTime
        {

            get
            {

                return _CurrentTime;

            }

        }

        public DateTime SignalTime
        {

            get
            {

                return _SignalTime;

            }

        }
    
    }
}
