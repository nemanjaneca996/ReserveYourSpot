using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ShowReservationDto
    {
        public DateTime StartTime { get; set; }
        public int Peoples { get; set; }
        public string Username { get; set; }
        public string LocaleTableName { get; set; }
        public string LocaleName { get; set; }

    }
}
