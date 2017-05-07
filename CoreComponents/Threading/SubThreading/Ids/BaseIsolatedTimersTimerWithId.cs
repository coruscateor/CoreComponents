using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedTimersTimerWithId<TID> : BaseIsolatedTimersTimer, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        private readonly TID myId;

        public BaseIsolatedTimersTimerWithId(TID TheId)
            : base()
        {

            myId = TheId;

        }

        public BaseIsolatedTimersTimerWithId(TID TheId, object LObj)
            : base(LObj)
        {

            myId = TheId;

        }

        public BaseIsolatedTimersTimerWithId(TID TheId, double Ival)
            : base(Ival)
        {

            myId = TheId;

        }

        public BaseIsolatedTimersTimerWithId(TID TheId, double Ival, object LObj)
            : base(Ival, LObj)
        {

            myId = TheId;

        }

        public TID Id
        {

            get
            {

                return myId;

            }

        }

    }

}
