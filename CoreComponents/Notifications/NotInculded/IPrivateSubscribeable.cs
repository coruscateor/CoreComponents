using System;
using System.Collections.Generic;
using System.Text;

namespace CoreComponents.Notifications
{

    //In this namespace records concerning whom is subscibed  to what are kept internally to the issuer.

    //T - Listed item type
    //R - Event Flags
    //E - EventArgs

    public delegate void ChangedHandler(EventArgs args);

    public interface IPrivateSubscribeable<T, R, E>
    {
        //public delegate void ChangedHandler(E EventArgs);

        void Subscribe(T TheObject, R EventCodes, ChangedHandler Del);

    }

    //In this namespace records concerning whom is subscibed to what are kept internally to the issuer.

    //T - Listed item type
    //R - Event Flags
    //E - EventArgs

    public interface IPrivateSubscribeableList<T, R, E>
    {
        //public delegate void ChangedHandler(E EventArgs);

        void Subscribe(T TheObject, R EventCodes, ChangedHandler Del);

    }

}
