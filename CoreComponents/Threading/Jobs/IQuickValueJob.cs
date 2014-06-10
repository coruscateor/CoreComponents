using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Threading.Jobs
{
    
    public interface IQuickValueJob<T> : IQuickJob, IReferenceValueContainer<T> where T : class
    {
    }

}
