﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public interface IToDictionary<TKey, TValue>
    {

        IDictionary<TKey, TValue> ToDictionary();

    }

}
