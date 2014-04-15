using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class PublicActionEvent : BasePublicEvent<ActionEvent, Action>
    { 

        public PublicActionEvent(ActionEvent TheEvent) : base(TheEvent)
        {
        }

        public void Execute()
        {

            myEvent.Execute();

        }

    }

    public class PublicActionEvent<T> : BasePublicEvent<ActionEvent<T>, Action<T>>
    {

        public PublicActionEvent(ActionEvent<T> TheEvent)
            : base(TheEvent)
        {
        }

        public void Execute(T TheParameter)
        {

            myEvent.Execute(TheParameter);

        }

    }

    public class PublicActionEvent<T1, T2> : BasePublicEvent<ActionEvent<T1, T2>, Action<T1, T2>>
    {

        public PublicActionEvent(ActionEvent<T1, T2> TheEvent)
            : base(TheEvent)
        {
        }

        public void Execute(T1 P1, T2 P2)
        {

            myEvent.Execute(P1, P2);

        }

    }

}
