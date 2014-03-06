using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class WeakStore
    {

        protected WeakReference myWR;

        public WeakStore()
        {

            myWR = new WeakReference(null);

        }

        public WeakStore(object TheTarget)
        {

            myWR = new WeakReference(TheTarget);

        }

        public WeakStore(bool TrackResurrection)
        {

            myWR = new WeakReference(null, TrackResurrection);

        }

        public WeakStore(object TheTarget, bool TrackResurrection)
        {

            myWR = new WeakReference(TheTarget, TrackResurrection);

        }

        public bool TrackResurrection
        {

            get
            {

                return myWR.TrackResurrection;

            }
            set
            {

                if(value == myWR.TrackResurrection)
                {

                    object TargetValue = myWR.Target;

                    myWR = new WeakReference(TargetValue, value);

                }

            }

        }

        public void DoTrackResurrection()
        {

            if(!myWR.TrackResurrection)
                TrackResurrection = true;

        }

        public void DontTrackResurrection()
        {

            if(myWR.TrackResurrection)
                TrackResurrection = false;

        }

        public bool IsAlive
        {

            get
            {

                return myWR.IsAlive;

            }

        }

        public object Target
        {

            get
            {

                return myWR.Target;

            }
            set
            {

                myWR.Target = value;

            }

        }

        public bool TryGetTarget(out object TheTarget)
        {

            TheTarget = myWR.Target;

            if(TheTarget != null)
                return true;

            return false;

        }

        public bool TryGetTarget(out object TheTarget, Action TheAction)
        {

            TheTarget = myWR.Target;

            if(TheTarget != null)
            {

                TheAction();

                return true;

            }

            return false;

        }

        public bool TryGetTarget(out object TheTarget, Action<object> TheAction)
        {

            TheTarget = myWR.Target;

            if(TheTarget != null)
            {

                TheAction(TheTarget);

                return true;

            }

            return false;

        }

        public bool TryGetTarget<TTaget>(out object TheTarget, Action<TTaget> TheAction)
        {

            TheTarget = myWR.Target;

            if(TheTarget != null)
            {

                TheAction((TTaget)TheTarget);

                return true;

            }

            return false;

        }

    }

    public class WeakStore<TTarget>
    {

        protected WeakReference myWR;

        public WeakStore()
        {

            myWR = new WeakReference(null);

        }

        public WeakStore(TTarget TheTarget)
        {

            myWR = new WeakReference(TheTarget);

        }

        public WeakStore(bool TrackResurrection)
        {

            myWR = new WeakReference(null, TrackResurrection);

        }

        public WeakStore(TTarget TheTarget, bool TrackResurrection)
        {

            myWR = new WeakReference(TheTarget, TrackResurrection);

        }

        public bool TrackResurrection
        {

            get
            {

                return myWR.TrackResurrection;

            }
            set
            {

                if(value == myWR.TrackResurrection)
                {

                    object TargetValue = myWR.Target;

                    myWR = new WeakReference(TargetValue, value);

                }

            }

        }

        public void DoTrackResurrection()
        {

            if(!myWR.TrackResurrection)
                TrackResurrection = true;

        }

        public void DontTrackResurrection()
        {

            if(myWR.TrackResurrection)
                TrackResurrection = false;

        }

        public bool IsAlive
        {

            get
            {

                return myWR.IsAlive;

            }

        }

        public TTarget Target
        {

            get
            {

                object TargetValue = myWR.Target;

                if(TargetValue == null)
                    return default(TTarget);

                return (TTarget)TargetValue;

            }
            set
            {

                myWR.Target = value;

            }

        }

        public bool TryGetTarget(out TTarget TheTarget)
        {

            TheTarget = (TTarget)myWR.Target;

            if(TheTarget != null)
                return true;

            return false;

        }

        public bool TryGetTarget(out TTarget TheTarget, Action TheAction)
        {

            TheTarget = (TTarget)myWR.Target;

            if(TheTarget != null)
            {

                TheAction();

                return true;

            }

            return false;

        }

        public bool TryGetTarget(out TTarget TheTarget, Action<TTarget> TheAction)
        {

            TheTarget = (TTarget)myWR.Target;

            if(TheTarget != null)
            {

                TheAction(TheTarget);

                return true;

            }

            return false;

        }

    }

}
