using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ReservationDto
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        public int Peoples { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int LocaleTableId { get; set; }
        
    }
}
