﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public interface ICopyTo<T>
    {

        void CopyTo(T item);

    }

}
