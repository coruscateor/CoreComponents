using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Application.Messaging;
//This interface and this sub-namespace cheifly concerns writng text messages to areas 
//which are not screen interfaces such as file-systems, database providers and network interfaces  

namespace CoreComponents.Items.MessageWriting
{
    public interface IMessageWriter : IActivateDeactivate
    {

        event GimmieEvent<IMessageWriter, Exception>.Event WriteError;

        bool IsWriting
        {

            get;

        }

        void Write(IEnumerable<IMessageLine> Messages);

    }
}
