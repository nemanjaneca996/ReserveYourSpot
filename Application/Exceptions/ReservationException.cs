using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ReservationException : Exception
    {
        public ReservationException(string msg)
            : base(msg)
        {

        }
    }
}
