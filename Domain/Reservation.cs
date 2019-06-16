using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Reservation : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public int Peoples { get; set; }
        public int UserId { get; set; }
        public int LocaleTableId { get; set; }
        public LocaleTable LocaleTable { get; set; }
        public User User { get; set; }
    }
}
