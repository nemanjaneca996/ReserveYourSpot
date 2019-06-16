using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LocaleTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocaleId { get; set; }
        public int NumberOfSeats { get; set; }
        public ICollection<Reservation> Reservations{ get; set; }
        public Locale Locale { get; set; }
    }
}
