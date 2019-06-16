using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class LocaleTableQuery : BaseQuery
    {
        public string Name { get; set; }
        public int? LocaleId { get; set; }
        public int? MinNumberOfSeats { get; set; }
        public DateTime? Reservation { get; set; }
    }
}
