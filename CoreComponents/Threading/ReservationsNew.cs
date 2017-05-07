using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class ReservationsNew<T> : Reservations<T> where T : new()
    {

        public ReservationsNew()
            : base(new T())
        {
        }

    }

}
