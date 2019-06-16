using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ShowLocaleTableDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocaleName { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsReserved { get; set; }
    }
}
