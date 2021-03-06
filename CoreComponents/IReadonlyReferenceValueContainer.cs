﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface IReadonlyReferenceValueContainer<T> : IReadonlyValueContainer<T> where T : class
    {

        bool TryGetValue(out T TheValue);

    }

}
