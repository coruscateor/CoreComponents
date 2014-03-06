﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public interface IUnDisposable : IDisposable
    {

        bool IsDisposed
        {

            get;

        }

        void UnDispose();

    }

}
