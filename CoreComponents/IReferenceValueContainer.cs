using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface IReferenceValueContainer<T> : IValueContainer<T>, IReadonlyReferenceValueContainer<T> where T : class
    {
    }

}
