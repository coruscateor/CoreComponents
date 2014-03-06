using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Jobs
{
    
    public interface ITextWriteJobHandler
    {

        ConcurrentInputQueueSubThreadContainer<char> InputQueue
        {

            get;

        }

        void Input(string TheValue);

        void InputAndCheck(string TheValue);

    }

}
