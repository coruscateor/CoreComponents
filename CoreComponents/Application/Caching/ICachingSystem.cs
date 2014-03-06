using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;
using CoreComponents.Application.Messaging;
using CoreComponents.Items.MessageWriting;

namespace CoreComponents.Application.Sets
{
    public interface ICachingSystem : IActivateDeactivate, IEnumerable<IMessageLine>
    {

        //IEnumerator<IMessageLine> GetEnumerator();

        RestrictedQueue<IMessageLine> Messages
        {

            get;

        }

        IMessageWriter Writer
        {

            get;
            set;

        }

        void WriteLog();

    }
}
