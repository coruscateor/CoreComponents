using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IInputOutputQueue<T> : IInputQueue<T>, IOutputQueue<T> //, IEnumerable<T>
    {
        
        bool PeekType(out Type TheType);

        bool PeekNextType(Action<Type> TheTypeAction);

        bool PeekNextIsType<TType>();

        bool PeekNextIsType(Type TheType);

    }

}
