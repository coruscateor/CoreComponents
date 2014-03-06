﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IWorkInput : IWorkContainer
    {

        IInputQueue<object> Input
        {

            get;

        }

    }

}
