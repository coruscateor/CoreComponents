using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public delegate void EventHandler(object Sender);

    public delegate void EventHandler<T>(T Sender);

    public delegate void EventInfoHandler(object Sender, object EventInfo);

    public delegate void EventInfoHandler<TInfo>(object Sender, TInfo EventInfo);

    public delegate void EventHandler<TSender, TInfo>(TSender Sender, TInfo EventInfo);

}
