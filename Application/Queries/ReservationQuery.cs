using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class ReservationQuery : BaseQuery
    {
        public int? LocaleId { get; set; }
        public int? LocaleTableId { get; set; }
        public int? UserId { get; set; }
        public int? Peoples { get; set; }
    }
}
