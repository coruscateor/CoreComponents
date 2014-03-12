using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//[assembly: AssemblySafety(Safety.Safe)]

namespace CoreComponents
{

    public delegate void Event(object Sender);

    public delegate void Event<T>(T Sender);

    public delegate void EventInfo(object Sender, object EventInfo);

    public delegate void EventInfo<TInfo>(object Sender, TInfo EventInfo);

    public delegate void EventInfo<TSender, TInfo>(TSender Sender, TInfo EventInfo);

}
