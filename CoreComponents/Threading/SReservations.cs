﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class SReservations<T> : Reservations<T>
    {

        public SReservations(T resource)
            : base(resource)
        {
        }

    }

}
